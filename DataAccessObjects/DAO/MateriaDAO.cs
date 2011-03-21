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
   public class MateriaDAO
    {
        #region Singleton
        private static MateriaDAO Instance = null;
        private MateriaDAO()
        {

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new MateriaDAO();
            }
        }

        public static MateriaDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion





        public Materia obtenerPorId(long id)
        {

            string sql = "";
            sql = @"SELECT id, codigo, nombre, borrado
                    FROM materias where borrado=false and id=" + id.ToString();

            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();

            Materia m = null;
            if (dr.Read())
            {
                m = CargarMateriaDelDR(dr);
            }
            return m;
        }

        public Dictionary<long, Materia> obtenerTodos()
        {

            string sql = "";
            sql = @"SELECT id, codigo, nombre, borrado
                    FROM materias where borrado=false ";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Materia> dicMaterias = new Dictionary<long, Materia>();

            while (dr.Read())
            {
                Materia m;
                m = CargarMateriaDelDR(dr);


                if (!dicMaterias.ContainsKey(m.Id))
                    dicMaterias.Add(m.Id, m);

            }

            return dicMaterias;

        }


        public Dictionary<long, Materia> obtenerTodosAInscribirse(long id_alumno)
        {

            string sql = "";
            sql = @"SELECT m.id, m.codigo, m.nombre, m.borrado
                    FROM materias m
                    where (
				(
				    m.id not in 
						    (
						    select id_materia from examenes where nota>3 and id_alumno=:id_alumno
						    )

				    and m.id in 
					    (
					      select id_materia from correlativas where id_materia_correlativa
					      in 
						    (
						    select id_materia from examenes where nota>3 and id_alumno=:id_alumno
						    )
					    )
				
				)
				or
				(
					 m.id in 
						    (
						    select id_materia from examenes where nota<4 and id_alumno=:id_alumno
						    )
				)
				or
				(
					 m.id not in 
						    (
						    select id_materia from examenes where nota>3 and id_alumno=:id_alumno
						    )

					and
					 m.id not in 
						     (
							select id_materia from correlativas
						     )
				)
			)
			and
			(
			 m.id not in 
						    (
						    select id_materia from materias_inscriptas where  id_alumno=:id_alumno
						    )	
			)
                    and m.borrado=false";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDb.Instancia.AddCommandParameter(":id_alumno", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_alumno);
           
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Materia> dicMaterias = new Dictionary<long, Materia>();

            while (dr.Read())
            {
                Materia m;
                m = CargarMateriaDelDR(dr);


                if (!dicMaterias.ContainsKey(m.Id))
                    dicMaterias.Add(m.Id, m);

            }

            return dicMaterias;

        }


        public Dictionary<long, Materia> obtenerTodosMenos(long id)
        {

            string sql = "";
            sql = @"SELECT id, codigo, nombre, borrado
                    FROM materias where borrado=false and id<>"+id.ToString();


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Materia> dicMaterias = new Dictionary<long, Materia>();

            while (dr.Read())
            {
                Materia m;
                m = CargarMateriaDelDR(dr);


                if (!dicMaterias.ContainsKey(m.Id))
                    dicMaterias.Add(m.Id, m);

            }

            return dicMaterias;

        }

        private Materia CargarMateriaDelDR(NpgsqlDataReader dr)
        {
            Materia m = new Materia();



            if (!dr.IsDBNull(dr.GetOrdinal("id")))
                m.Id = long.Parse(dr["id"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                m.Nombre = dr.GetString(dr.GetOrdinal("nombre"));

            if (!dr.IsDBNull(dr.GetOrdinal("codigo")))
                m.Codigo = long.Parse(dr["codigo"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("borrado")))
                m.Borrado = dr.GetBoolean(dr.GetOrdinal("borrado"));


           

            return m;
        }


        public List< Materia> obtenerCorrelativas(long id)
        {

            string sql = "";
            sql = @"SELECT m.id, m.codigo, m.nombre, m.borrado
                    FROM materias m 
                    left join correlativas c on c.id_materia_correlativa=m.id
                    where m.borrado=false and c.id_materia=" + id.ToString();


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            List< Materia>  listMaterias = new List< Materia> ();

            while (dr.Read())
            {
                Materia m;
                m = CargarMateriaDelDR(dr);


                if (!listMaterias.Contains(m))
                    listMaterias.Add( m);

            }

            return listMaterias;

        }


        public void insertarMateria(Materia m)
        {
            string queryStr;


            queryStr = @"INSERT INTO materias(
             codigo, nombre, borrado)
            VALUES ( :codigo, :nombre, :borrado);";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":codigo", NpgsqlDbType.Bigint, ParameterDirection.Input, false,m.Codigo);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, m.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, m.Borrado);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

            queryStr = "SELECT currval('materias_id_seq')";
            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                    m.Id = long.Parse(dr[0].ToString());

            }


            QuitarTodasLasCorrelativas(m);
            if (m.ListaMateriasCorrelativas != null)
            {
                foreach (Materia correlativa in m.ListaMateriasCorrelativas)
                {
                    insertarCorrelativa(m, correlativa);
                }
            }

        }


        public void actualizarMateria(Materia m)
        {
            string queryStr;


            queryStr = @"UPDATE materias
                SET codigo=:codigo, nombre=:nombre, borrado=:borrado
                WHERE id=:id";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id", NpgsqlDbType.Bigint, ParameterDirection.Input, false, m.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":codigo", NpgsqlDbType.Bigint, ParameterDirection.Input, false, m.Codigo);
            NpgsqlDb.Instancia.AddCommandParameter(":nombre", NpgsqlDbType.Varchar, ParameterDirection.Input, false, m.Nombre);
            NpgsqlDb.Instancia.AddCommandParameter(":borrado", NpgsqlDbType.Boolean, ParameterDirection.Input, false, m.Borrado);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }


            QuitarTodasLasCorrelativas(m);
            
            if (m.ListaMateriasCorrelativas != null)
            {
                foreach (Materia correlativa in m.ListaMateriasCorrelativas)
                {
                    insertarCorrelativa(m, correlativa);
                }
            }


        }


        public void insertarCorrelativa(Materia materia, Materia correlativa)
        {
            string queryStr;


            queryStr = @"INSERT INTO correlativas(
            id_materia, id_materia_correlativa)
            VALUES ( :id_materia, :id_materia_correlativa)";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia", NpgsqlDbType.Bigint, ParameterDirection.Input, false, materia.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia_correlativa", NpgsqlDbType.Bigint, ParameterDirection.Input, false, correlativa.Id);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

        }

        public void QuitarCorrelativa(Materia materia, Materia correlativa)
        {
            string queryStr;


            queryStr = @"delete FROM correlativas where  id_materia=:id_materia, id_materia_correlativa=:id_materia_correlativa";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia", NpgsqlDbType.Bigint, ParameterDirection.Input, false, materia.Id);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia_correlativa", NpgsqlDbType.Bigint, ParameterDirection.Input, false, correlativa.Id);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

        }

        public void QuitarTodasLasCorrelativas(Materia materia)
        {
            string queryStr;


            queryStr = @"delete FROM correlativas where  id_materia=:id_materia ";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia", NpgsqlDbType.Bigint, ParameterDirection.Input, false, materia.Id);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }

        }


        public Dictionary<long, Materia> obtenerMateriasAsignadas(long p)
        {

            string sql = "";
            sql = @"SELECT id, codigo, nombre, borrado
                  FROM materias
                  left join materias_profesor on id=id_materia 
                  where borrado=false and id_profesor="+p.ToString();


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Materia> dicMaterias = new Dictionary<long, Materia>();

            while (dr.Read())
            {
                Materia m;
                m = CargarMateriaDelDR(dr);


                if (!dicMaterias.ContainsKey(m.Id))
                    dicMaterias.Add(m.Id, m);

            }

            return dicMaterias;
        }

        public void insertarProfesorAsignado(long id_Profesor, long id_Materia)
        {
            string queryStr;


            queryStr = @"INSERT INTO materias_profesor(
            id_profesor, id_materia)
            VALUES ( :id_profesor, :id_materia)";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_profesor", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_Profesor);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_Materia);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }
        }

        public void quitarProfesorAsignado(long id_Profesor, long id_Materia)
        {
            string queryStr;


            queryStr = @"delete from materias_profesor where id_profesor=:id_profesor and id_materia=:id_materia ";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_profesor", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_Profesor);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_Materia);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }
        }



        public void BorrarInscripciones(long id_alumno)
        {
            string queryStr;


            queryStr = @"delete from materias_inscriptas where id_alumno=:id_alumno ";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_alumno", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_alumno);
           
            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }
        }

        public void inscribirAMateria(long id_alumno, long id_Materia)
        {
            string queryStr;


            queryStr = @"INSERT INTO materias_inscriptas(
            id_alumno, id_materia)
            VALUES (:id_alumno, :id_materia);";

            NpgsqlDb.Instancia.PrepareCommand(queryStr);
            NpgsqlDb.Instancia.AddCommandParameter(":id_alumno", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_alumno);
            NpgsqlDb.Instancia.AddCommandParameter(":id_materia", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_Materia);

            try
            {
                NpgsqlDb.Instancia.ExecuteNonQuery();

            }
            catch (System.OverflowException Ex)
            {
                throw Ex;
            }
        }


        public Dictionary<long, Materia> obtenerMateriasInscriptas(long id_alumno)
        {
            string sql = "";
            sql = @"SELECT id, codigo, nombre, borrado
                    FROM materias 
                    inner join materias_inscriptas on id=id_materia
                    where borrado=false and id_alumno=:id_alumno ";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDb.Instancia.AddCommandParameter(":id_alumno", NpgsqlDbType.Bigint, ParameterDirection.Input, false, id_alumno);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, Materia> dicMaterias = new Dictionary<long, Materia>();

            while (dr.Read())
            {
                Materia m;
                m = CargarMateriaDelDR(dr);


                if (!dicMaterias.ContainsKey(m.Id))
                    dicMaterias.Add(m.Id, m);

            }

            return dicMaterias;
        }
    }
}
