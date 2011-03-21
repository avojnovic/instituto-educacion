using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using BussinesObjects.BussinesObjects;
using Npgsql;
using System.Data;
using NpgsqlTypes;

namespace DataAccessObjects.DAO
{
   public class ExamenDAO
    {
       #region Singleton
        private static ExamenDAO Instance = null;
        private ExamenDAO()
        {

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new ExamenDAO();
            }
        }

        public static ExamenDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion


        public List<Examen> obtenerTodosPorAlumno(long id_Alumno)
        {

            string sql = "";
            sql = @"SELECT id, id_materia, id_alumno, fecha, nota
              FROM examenes
             where id_alumno=:id_alumno";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDb.Instancia.AddCommandParameter(":id_alumno", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_Alumno);
           
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            List<Examen> listaExamenes = new List<Examen>();

            while (dr.Read())
            {
                Examen e;
                e = CargarExamenDelDR(dr);
                listaExamenes.Add( e);

            }

            return listaExamenes;

        }

        private Examen CargarExamenDelDR(NpgsqlDataReader dr)
        {
            Examen e = new Examen();



            if (!dr.IsDBNull(dr.GetOrdinal("id")))
                e.Id = long.Parse(dr["id"].ToString());

            long id_materia=0;
            if (!dr.IsDBNull(dr.GetOrdinal("id_materia")))
                id_materia = long.Parse(dr["id_materia"].ToString());

            e.Materia = MateriaDAO.Instancia.obtenerPorId(id_materia);
           
            long id_alumno = 0;
            if (!dr.IsDBNull(dr.GetOrdinal("id_alumno")))
                id_alumno = long.Parse(dr["id_alumno"].ToString());
            e.Alumno =(Alumno) PersonaDAO.Instancia.obtenerPorId(id_alumno);


            if (!dr.IsDBNull(dr.GetOrdinal("fecha")))
                e.Fecha = dr.GetDateTime(dr.GetOrdinal("fecha"));

             if (!dr.IsDBNull(dr.GetOrdinal("nota")))
                 e.Nota =Double.Parse(dr["nota"].ToString());


            return e;
        }

       
    }
}
