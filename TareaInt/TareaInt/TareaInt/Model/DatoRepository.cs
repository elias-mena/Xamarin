using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace TareaInt.Model
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
        public int AddNewData(string description, int importancia)
        {
            int result = 0;
            try
            {
                result = con.Insert(new Dato
                {
                    Description = description,
                    Importancia = importancia
                });
                EstadoMensaje = string.Format("Registros: {0}", result);
            }
            catch (Exception e)
            { EstadoMensaje = e.Message; }
            return result;
        }
        public IEnumerable<Dato> GetAllData()
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

        public void Modify(int id)
        {
            try
            {
                var data = con.Table<Dato>();
                var registro = from i in data where i.Id == id select i.Description;
                registro = registro.ToArray();
                string newMessage = "";
                foreach (var i in registro)
                {
                    newMessage += "*";
                }
                //Dato re = new Dato(id = id,
                 //                   Description = description);
                con.Update(data);

            }
            catch (Exception e)
            {
                EstadoMensaje = e.Message;
            }
        }

    }
}
