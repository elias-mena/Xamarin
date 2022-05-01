using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace TareaSQLite.Model
{
    class DatoRepository
    {
        private SQLiteConnection con;
        private static DatoRepository instancia;
        public static DatoRepository Instancia
        {
            get
            {
                if (instancia == null)
                    throw new Exception("Debe llamar al inicializador, acción detenida");
                return instancia;
            }
        }
        public static void Inicializador(String filename)
        {
            if (filename == null)
            {
                throw new ArgumentException();
            }
            if (instancia != null)
            {
                instancia.con.Close();
            }
            instancia = new DatoRepository(filename);
        }
        private DatoRepository(String dbPath)
        {
            con = new SQLiteConnection(dbPath);
            con.CreateTable<Dato>();
        }
        public string EstadoMensaje;
        public int AddNewUser(string username, string email, string password)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Dato
                {
                    Username = username,
                    Email = email,
                    Password = password
                });
                EstadoMensaje = string.Format("Cantidad filas : {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<Dato> GetAllUsers()
        {
            try
            {
                return con.Table<Dato>();
            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
            return Enumerable.Empty<Dato>();
        }

    }
}
