using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class CuentaDAL
    {
        #region Global Variables 4
        private string BookName = "bCuenta";
        private string TableName = "dbENC73";
        #endregion

        #region Properties
        public string ConnectionString
        {
            get;set;
        }
        #endregion

        #region Methods
        ///<summary>
        /// Busca un registro con el Id que se proporciona
        ///</summary>
        /// <param name="Id">Identificador del elemento a buscar</param>
        ///<return>
        ///Devuelve una entidad con los datos del registro que encontró.
        ///</return>
        public Entity.CuentaInfo GetEntityObject(int Id)
        {
            string SqlStatement = $"select NUM_DOC,nombres,apellidos,email,genero,fecha_nacimient, usuario_id from {TableName} where {Entity.CuentaInfo.FieldName.Id} = {Id}";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);
            if (dt == null || dt.Rows.Count == 0) throw new Exception($"No se encontraron registros con el id {Id}");
            return GetEntityObject(dt.Rows[0]);
        }


        /// <summary>
        /// Regresa un objeto entidad con los datos recibidos del DataRow
        /// </summary>
        /// <param name="Row">La fila de tabla table donde se toma los datos para formar un objeto</param>
        /// <returns>
        /// Un objeto con los datos del row
        /// </returns>
        private Entity.CuentaInfo GetEntityObject(DataRow Row)
        {
            if (Row == null) throw new ArgumentNullException("No se recibió el DataRow para obtener los datos");

            Entity.CuentaInfo CuentaInfo = new Entity.CuentaInfo();
            CuentaInfo.Id = Convert.ToInt32(Row[Entity.CuentaInfo.FieldName.Id]);
            CuentaInfo.Nombres = Row[Entity.CuentaInfo.FieldName.Nombres].ToString();
            CuentaInfo.Apellidos = Row[Entity.CuentaInfo.FieldName.Apellidos].ToString();
            CuentaInfo.Email = Row[Entity.CuentaInfo.FieldName.Email].ToString();
            CuentaInfo.Genero = Row[Entity.CuentaInfo.FieldName.Genero].ToString(); 
            CuentaInfo.Usuario_Id = Convert.ToInt32(Row[Entity.CuentaInfo.FieldName.Usuario_Id]);
            CuentaInfo.Fecha_Nacimiento = Row[Entity.CuentaInfo.FieldName.Fecha_Nacimiento].ToString();

            return CuentaInfo;
        }

        ///<summary>
        ///Agrega un nuevo registro a la tabla
        ///</summary>
        /// <param name="CuentaInfo">El objeto con los datos para la inserción</param>
        ///<return>
        ///Devuelve el Id del registro guardado
        ///</return>
        public int Insert(Entity.CuentaInfo CuentaInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("declare @Id int");
            sb.AppendLine($"select @Id = fol_act from dbconf_bloq where des_bloq = '{BookName}'");
            sb.AppendLine($"insert into {TableName}(NUM_DOC,");
            sb.Append($"{Entity.CuentaInfo.FieldName.Nombres}");
            sb.Append($",{Entity.CuentaInfo.FieldName.Apellidos}");
            sb.Append($",{Entity.CuentaInfo.FieldName.Email}");
            sb.Append($",{Entity.CuentaInfo.FieldName.Genero}");
            sb.Append($",{Entity.CuentaInfo.FieldName.Fecha_Nacimiento}");
            sb.Append($",{Entity.CuentaInfo.FieldName.Usuario_Id}");
            sb.AppendLine(")");
            sb.AppendLine("values(@Id");
            sb.Append($",'{CuentaInfo.Nombres}'");
            sb.Append($",'{CuentaInfo.Apellidos}'");
            sb.Append($",'{CuentaInfo.Email}'");
            sb.Append($",'{CuentaInfo.Genero}'");
            sb.Append($",{CuentaInfo.Fecha_Nacimiento},");
            sb.Append($"{CuentaInfo.Usuario_Id}");
            sb.AppendLine(")");
            sb.AppendLine($"update dbconf_bloq set fol_act = fol_act + 1 where des_bloq = '{BookName}'");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");

            object Id = Utilerias.SQLHelper.ExecuteScalar(sb.ToString(), ConnectionString);
            if (Id == null) return 0;
            return Convert.ToInt32(Id);
        }


        ///<summary>
        ///Actualiza un registro de la tabla
        ///<summary>
        /// <param name="CuentaInfo">Objeto con los datos del registro para la actualización</param>
        ///<return>
        ///Devuelve el Id del registro que actualizó
        ///</return>
        public int Update(Entity.CuentaInfo CuentaInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"update {TableName} set ");
            sb.Append($"{Entity.CuentaInfo.FieldName.Nombres} = '{CuentaInfo.Nombres}'");
            sb.Append($",{Entity.CuentaInfo.FieldName.Apellidos} = '{CuentaInfo.Apellidos}'");
            sb.Append($",{Entity.CuentaInfo.FieldName.Email} = '{CuentaInfo.Email}'");
            sb.Append($",{Entity.CuentaInfo.FieldName.Genero} = '{CuentaInfo.Genero}'");
            sb.Append($",{Entity.CuentaInfo.FieldName.Fecha_Nacimiento} = '{CuentaInfo.Fecha_Nacimiento}'");
            sb.Append($",{Entity.CuentaInfo.FieldName.Usuario_Id} = '{CuentaInfo.Usuario_Id}'");
            sb.Append($"where {Entity.CuentaInfo.FieldName.Id} = {CuentaInfo.Id}");
            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
            return CuentaInfo.Id;
        }


        public void Delete(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"update {TableName} SET NUM_DOC = NUM_DOC * (-1)");
            sb.Append($" where {Entity.CuentaInfo.FieldName.Id} ={Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);

        }


        ///<summary>
        ///Busca los registro que cumplan con cierto filtro
        ///</summary>
        /// <param name="CuentaInfo">
        /// Objeto con los datos para filtrar los datos de la tabla
        /// </param>
        ///<return>
        ///Devuelve una lista de objetos que cumplan con el filtro
        ///</return>
        public List<CuentaInfo> FindBy(Entity.CuentaInfo CuentaInfo)
        {
            string Filter = string.Empty;
            Entity.CuentaInfo nCuenta = new Entity.CuentaInfo();

            //Se generó un nuevo objeto para comparar y detectar las variaciones
            if (string.Compare(CuentaInfo.Nombres, nCuenta.Nombres, true) != 0)
                Filter += $" and {Entity.CuentaInfo.FieldName.Nombres} = '{CuentaInfo.Nombres}'";

            if (string.Compare(CuentaInfo.Apellidos, nCuenta.Apellidos, true) != 0)
                Filter += $" and {Entity.CuentaInfo.FieldName.Apellidos} = '{CuentaInfo.Apellidos}'";

            if (string.Compare(CuentaInfo.Email, nCuenta.Email, true) != 0)
                Filter += $" and {Entity.CuentaInfo.FieldName.Email} = '{CuentaInfo.Email}'";

            if (string.Compare(CuentaInfo.Genero, nCuenta.Genero, true) != 0)
                Filter += $" and {Entity.CuentaInfo.FieldName.Genero} = '{CuentaInfo.Genero}'";

            if (string.Compare(CuentaInfo.Fecha_Nacimiento,nCuenta.Fecha_Nacimiento, true) !=0)
                Filter += $" and {Entity.CuentaInfo.FieldName.Fecha_Nacimiento} = '{CuentaInfo.Fecha_Nacimiento}'";

            if(CuentaInfo.Usuario_Id != CuentaInfo.Usuario_Id)
                Filter += $" and {Entity.CuentaInfo.FieldName.Usuario_Id} = '{CuentaInfo.Usuario_Id}'";

            if (CuentaInfo.Id != nCuenta.Id)
                Filter += $" and {Entity.CuentaInfo.FieldName.Id} = {nCuenta.Id}";

            //Definición de setencia sql con filtro dinámico
            string sql = $"select * from {TableName} where {Entity.CuentaInfo.FieldName.Id} > 0 " + Filter;
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(sql, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<Entity.CuentaInfo> ListCuentas = new List<Entity.CuentaInfo>();
            foreach (DataRow dr in dt.Rows)
                ListCuentas.Add(GetEntityObject(dr));

            return ListCuentas;

        }


        #endregion

    }
}
