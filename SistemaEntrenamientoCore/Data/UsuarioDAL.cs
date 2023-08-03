using SistemaEntrenamientoCore.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaEntrenamientoCore.Data
{
    public class UsuarioDAL
    {
        #region Global Variables 
        private string BookName = "bUsuario";
        private string TableName = "dbENC74";
        #endregion
        #region Properties
        public string ConnectionString
        {
            get; set;
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
        public Entity.UsuarioInfo GetEntityObject(int Id)
        {
            if (Id == 0) throw new ArgumentNullException("No se recibió el Id");

            string SqlStatement = $"SELECT * FROM {TableName} where {Entity.UsuarioInfo.FieldName.Id}= {Id}";
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SqlStatement, ConnectionString);
            return GetEntityObject(dt.Rows[0]);
        }

        /// <summary>
        /// Regresa un objeto entidad con los datos recibidos del  DataRow
        /// </summary>
        /// <param name="dr">La fila de tabla table donde se toma los datos para formar un objeto</param>
        /// <returns>
        /// Un objeto con los datos del row
        /// </returns>
        public Entity.UsuarioInfo GetEntityObject(DataRow dr)
        {
            UsuarioInfo UsuarioInfo = new UsuarioInfo();
            UsuarioInfo.Id = Convert.ToInt32(dr[Entity.UsuarioInfo.FieldName.Id]);
            UsuarioInfo.Usuario = dr[Entity.UsuarioInfo.FieldName.Usuario].ToString();
            UsuarioInfo.Contrasenia = dr[Entity.UsuarioInfo.FieldName.Contrasenia].ToString();  
            UsuarioInfo.Rol = Convert.ToInt32(dr[Entity.UsuarioInfo.FieldName.Rol]); 
            return UsuarioInfo;
        }


        ///<summary>
        ///Agrega un nuevo registro a la tabla
        ///</summary>
        /// <param name="UsuarioInfo">El objeto con los datos para la inserción</param>
        ///<return>
        ///Devuelve el I
        public int Insert(UsuarioInfo UsuarioInfo)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"declare @Id");
            sb.AppendLine($"select @Id = fol_act from dbconf_bloq where des_bloq = {BookName}");
            sb.AppendLine($"INSERT INTO {TableName}(NUM_DOC,");
            sb.Append($"{UsuarioInfo.FieldName.Usuario},");
            sb.Append($"{UsuarioInfo.FieldName.Contrasenia},");
            sb.Append($"{UsuarioInfo.FieldName.Rol},");
            sb.AppendLine(")");
            sb.AppendLine("values(@Id,");
            sb.Append($"'{UsuarioInfo.Usuario}',");
            sb.Append($"'{UsuarioInfo.Contrasenia}',");
            sb.Append($"{UsuarioInfo.Rol},");
            sb.Append(")");
            sb.AppendLine($"update dbconf_bloq set fol_act = fol_act + 1 where des_bloq = '{BookName}'");
            sb.AppendLine("SELECT SCOPE_IDENTITY()");


            Object Id = Utilerias.SQLHelper.ExecuteScalar(sb.ToString(), ConnectionString);
            if (Id == null) return 0;
            return Convert.ToInt32(Id);
        }


        ///<summary>
        ///Actualiza un registro de la tabla
        ///<summary>
        /// <param name="UsuarioInfo">Objeto con los datos del registro para la actualización</param>
        ///<return>
        ///Devuelve el Id del registro que actualizó
        ///</return>
        public int Update(UsuarioInfo UsuarioInfo)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"UPDATE {TableName} SET(");
            sb.Append($"{UsuarioInfo.FieldName.Usuario} = {UsuarioInfo.Usuario}");
            sb.Append($"{UsuarioInfo.FieldName.Contrasenia} = {UsuarioInfo.Contrasenia}");
            sb.Append($"{UsuarioInfo.FieldName.Rol} = {UsuarioInfo.Rol}");
            sb.Append($"Where {UsuarioInfo.FieldName.Id} = {UsuarioInfo.Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
            return UsuarioInfo.Id;
        }

        ///<summary>
        ///Elimina un registro de la tabLa.
        ///</summary>
        ///<return>
        ///</return>
        public void Delete(int Id)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"UPDATE {TableName} SET NUM_DOC = NUM_DOC * (-1)");
            sb.Append($"where {UsuarioInfo.FieldName.Id} = {Id}");

            Utilerias.SQLHelper.ExecuteNonQuery(sb.ToString(), ConnectionString);
        }

        ///<summary>
        ///Busca los registro que cumplan con cierto filtro
        ///</summary>
        /// <param name="UsuarioInfo">
        /// Objeto con los datos para filtrar los datos de la tabla
        /// </param>
        ///<return>
        ///Devuelve una lista de objetos que cumplan con el filtro
        ///</return>
        public List<UsuarioInfo> FindBy(UsuarioInfo UsuarioInfo)
        {
            if (UsuarioInfo == null) throw new ArgumentNullException("No se recibió el objeto Usuario");

            string Filter = string.Empty;
            Entity.UsuarioInfo nUsuario = new Entity.UsuarioInfo();

            if (string.Compare(UsuarioInfo.Usuario, nUsuario.Usuario, true) != 0)
                Filter += $" and {Entity.UsuarioInfo.FieldName.Usuario} = {UsuarioInfo.Usuario}";
            if (UsuarioInfo.Rol != nUsuario.Rol)
                Filter += $" and {Entity.UsuarioInfo.FieldName.Rol} = {UsuarioInfo.Rol}";
            if (UsuarioInfo.Id != nUsuario.Id)
                Filter += $" and {Entity.UsuarioInfo.FieldName.Id} = {UsuarioInfo.Id}";

            //Definición de setencia sql con filtro dinámico
            string SQLStatement = $"SELECT * FROM {TableName} where {Entity.RolInfo.FieldName.Id} > 0" + Filter;
            DataTable dt = Utilerias.SQLHelper.ExecuteDataTable(SQLStatement, ConnectionString);

            if (dt == null || dt.Rows.Count == 0) return null;

            //Creamos una lista para guardar cada registro de cursos que viene en el datatable
            List<UsuarioInfo> ListUsuarios = new List<UsuarioInfo>();
            foreach (DataRow dr in dt.Rows)
                ListUsuarios.Add(GetEntityObject(dr));


            return ListUsuarios;
        }
        #endregion

    }
}
