using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using BussinesObjects.BussinesObjects;
using Npgsql;
using NpgsqlTypes;
using System.Data;

namespace DataAccessObjects.DAO
{
    public class PersonaDAO
    {

        #region Singleton
        private static PersonaDAO Instance = null;
        private PersonaDAO()
        {

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new PersonaDAO();
            }
        }

        public static PersonaDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion


        public Persona verificarUsuario(string usuario, string password)
        {

            string sql = "";
            sql = @"SELECT p.*,pe.id as idPerfil, pe.numero, pe.nombre as Perfil 
            from personas p  
             LEFT JOIN perfiles pe ON p.id_perfil=pe.id 
             where p.borrado=false and upper(p.usuario)='" + usuario.Trim().ToUpper() + "' and upper(p.contrasena)='" + password.Trim().ToUpper() + "'";
            
            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();

            Persona p = null;
            if (dr.Read())
            {
                p = CargarPersonaDelDR(dr);
            }
            return p;
        }


        public Persona obtenerPorId(long id)
        {

            string sql = "";
            sql = @"SELECT p.*,pe.id as idPerfil, pe.numero, pe.nombre as Perfil 
            from personas p  
             LEFT JOIN perfiles pe ON p.id_perfil=pe.id 
             where p.borrado=false and p.id=" + id.ToString();

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();

            Persona p = null;
            if (dr.Read())
            {
                p = CargarPersonaDelDR(dr);
            }
            return p;
        }

        public Dictionary<long, Persona> obtenerPersonaTodos()
        {

            string sql = "";
            sql = @"SELECT p.*,pe.id as idPerfil, pe.numero, pe.nombre as Perfil 
            from personas p  
             LEFT JOIN perfiles pe ON p.id_perfil=pe.id 
             where p.borrado=false";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Persona> dicPersona = new Dictionary<long, Persona>();

            while (dr.Read())
            {
                Persona p;
                p = CargarPersonaDelDR(dr);


                if (!dicPersona.ContainsKey(p.Id))
                    dicPersona.Add(p.Id, p);

            }

            return dicPersona;

        }

        public Dictionary<long, Persona> obtenerTodosPorPerfil(int numero)
        {

            string sql = "";
            sql = @"SELECT p.*,pe.id as idPerfil, pe.numero, pe.nombre as Perfil 
            from personas p  
             LEFT JOIN perfiles pe ON p.id_perfil=pe.id 
             where p.borrado=false and pe.numero=" + numero.ToString();


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Persona> dicPersona = new Dictionary<long, Persona>();

            while (dr.Read())
            {
                Persona p;
                p = CargarPersonaDelDR(dr);


                if (!dicPersona.ContainsKey(p.Id))
                    dicPersona.Add(p.Id, p);

            }

            return dicPersona;

        }


        public List<Persona> obtenerTodosPorMateria(long id_Materia)
        {

            string sql = "";
            sql = @"SELECT p.*,pe.id as idPerfil, pe.numero, pe.nombre as Perfil 
                From personas p  
                LEFT JOIN perfiles pe ON p.id_perfil=pe.id 
                left join materias_inscriptas m on m.id_alumno=p.id

                where p.borrado=false and m.id_materia= " + id_Materia.ToString(); 


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            List<Persona> listPersona = new List<Persona>();

            while (dr.Read())
            {
                Persona p;
                p = CargarPersonaDelDR(dr);


                if (!listPersona.Contains(p))
                    listPersona.Add(p);

            }

            return listPersona;

        }

        private Persona CargarPersonaDelDR(NpgsqlDataReader dr)
        {
            Persona p;
           
                int tipo = 0;

                if (!dr.IsDBNull(dr.GetOrdinal("numero")))
                    tipo = int.Parse(dr["numero"].ToString());

                if (tipo == 1)
                { //Profesor
                    p = new Profesor();
                }
                else
                { //Alumno
                    p = new Alumno();

                }


                if (!dr.IsDBNull(dr.GetOrdinal("id")))
                    p.Id = long.Parse(dr["id"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                    p.Nombre = dr.GetString(dr.GetOrdinal("nombre"));
                if (!dr.IsDBNull(dr.GetOrdinal("apellido")))
                    p.Apellido = dr.GetString(dr.GetOrdinal("apellido"));
                if (!dr.IsDBNull(dr.GetOrdinal("dni")))
                    p.Dni = long.Parse(dr["dni"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("usuario")))
                    p.Usuario = dr.GetString(dr.GetOrdinal("usuario"));
                if (!dr.IsDBNull(dr.GetOrdinal("contrasena")))
                    p.Password = dr.GetString(dr.GetOrdinal("contrasena"));
                if (!dr.IsDBNull(dr.GetOrdinal("borrado")))
                    p.Borrado = dr.GetBoolean(dr.GetOrdinal("borrado"));

                p.Perfil = new Perfil();

                if (!dr.IsDBNull(dr.GetOrdinal("idPerfil")))
                    p.Perfil.Id = long.Parse(dr["idPerfil"].ToString());
                if (!dr.IsDBNull(dr.GetOrdinal("Perfil")))
                    p.Perfil.Nombre = dr.GetString(dr.GetOrdinal("Perfil"));
                if (!dr.IsDBNull(dr.GetOrdinal("numero")))
                    p.Perfil.Numero = int.Parse(dr["numero"].ToString());


           
            return p;
        }


        public void insertarPersona(Persona _persona)
        {
            string queryStr;


            queryStr = @"INSERT INTO personas(
            dni, nombre, apellido, usuario, contrasena, id_perfil, borrado)
    VALUES (:dni, :nombre, :apellido, :usuario, :contrasena, :id_perfil, :borrado);";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":dni", NpgsqlDbType.Bigint, ParameterDirection.Input, false, _persona.Dni);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":apellido", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Apellido);
            NpgsqlDb.Instancia.AddCommandParameter(":usuario", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Usuario);
            NpgsqlDb.Instancia.AddCommandParameter(":contrasena", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Password);
            NpgsqlDb.Instancia.AddCommandParameter(":id_perfil", NpgsqlDbType.Bigint, ParameterDirection.Input, false, _persona.Perfil.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, _persona.Borrado);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }




            //queryStr = "select currval('personas_id_seq');";
            //NpgsqlDb.Instancia.PrepareCommand(queryStr);
            //string idper = "";
            //try
            //{
            //    NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            //    while (dr.Read())
            //    {
            //        if (!dr.IsDBNull(dr.GetOrdinal("personas_id_seq")))
            //            idper = dr.GetString(dr.GetOrdinal("personas_id_seq"));

            //        _persona.Id = long.Parse(idper);
            //    }

            //}
            //catch (System.OverflowException Ex)
            //{
            //    throw Ex;
            //}
        }

        public void actualizarPersona(Persona _persona)
        {
            string queryStr;


            queryStr = @"UPDATE personas
   SET  dni=:dni, nombre=:nombre, apellido=:apellido, usuario=:usuario, contrasena=:contrasena, id_perfil=:id_perfil, 
       borrado=:borrado
 WHERE id=:id";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id", NpgsqlDbType.Bigint, ParameterDirection.Input, false, _persona.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":dni", NpgsqlDbType.Bigint, ParameterDirection.Input, false, _persona.Dni);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":apellido", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Apellido);
            NpgsqlDb.Instancia.AddCommandParameter(":usuario", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Usuario);
            NpgsqlDb.Instancia.AddCommandParameter(":contrasena", NpgsqlDbType.Varchar, ParameterDirection.Input, false, _persona.Password);
            NpgsqlDb.Instancia.AddCommandParameter(":id_perfil", NpgsqlDbType.Bigint, ParameterDirection.Input, false, _persona.Perfil.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, _persona.Borrado);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }
        }

        public Dictionary<long, Persona> obtenerTodosPorPerfil(PerfilesEnum perfilesEnum)
        {
            return obtenerTodosPorPerfil(Convert.ToInt32( perfilesEnum));
        }
    }
}
