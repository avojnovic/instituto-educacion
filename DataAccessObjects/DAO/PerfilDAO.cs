using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using Npgsql;

namespace DataAccessObjects.DAO
{
   public class PerfilDAO
    {

        #region Singleton
        private static PerfilDAO Instance = null;
        private PerfilDAO()
        {

        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void CreateInstance()
        {
            if (Instance == null)
            {
                Instance = new PerfilDAO();
            }
        }

        public static PerfilDAO Instancia
        {
            get
            {
                CreateInstance();
                return Instance;
            }
        }
        #endregion




        public Dictionary<long, BussinesObjects.BussinesObjects.Perfil> obtenerTodos()
        {

            string sql = "";
            sql = @"SELECT id, numero, nombre FROM perfiles;";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, BussinesObjects.BussinesObjects.Perfil> _perfiles = new Dictionary<long, BussinesObjects.BussinesObjects.Perfil>();

            while (dr.Read())
            {
                BussinesObjects.BussinesObjects.Perfil e ;
                e = getPerfilDelDataReader(dr);

                if (!_perfiles.ContainsKey(e.Id))
                    _perfiles.Add(e.Id, e);
            }

            return _perfiles;
        }

        public Dictionary<long, BussinesObjects.BussinesObjects.Perfil> obtenerPerfiles()
        {

            string sql = "";
            sql = @"SELECT id, numero, nombre FROM perfiles where numero<>3";


            NpgsqlDb.Instancia.PrepareCommand(sql);
            NpgsqlDataReader dr = NpgsqlDb.Instancia.ExecuteQuery();
            Dictionary<long, BussinesObjects.BussinesObjects.Perfil> _perfiles = new Dictionary<long, BussinesObjects.BussinesObjects.Perfil>();

            while (dr.Read())
            {
                BussinesObjects.BussinesObjects.Perfil e;
                e = getPerfilDelDataReader(dr);

                if (!_perfiles.ContainsKey(e.Id))
                    _perfiles.Add(e.Id, e);
            }

            return _perfiles;
        }

        private BussinesObjects.BussinesObjects.Perfil getPerfilDelDataReader(NpgsqlDataReader dr)
        {
            BussinesObjects.BussinesObjects.Perfil e = new BussinesObjects.BussinesObjects.Perfil();


            if (!dr.IsDBNull(dr.GetOrdinal("id")))
                e.Id = long.Parse(dr["id"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("numero")))
                e.Numero = int.Parse(dr["numero"].ToString());

            if (!dr.IsDBNull(dr.GetOrdinal("nombre")))
                e.Nombre = dr.GetString(dr.GetOrdinal("nombre"));

            return e;
        }
    }
}
