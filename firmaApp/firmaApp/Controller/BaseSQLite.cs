using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using firmaApp.Models;

namespace firmaApp.Controller
{
    public class BaseSQLite
    {
        readonly SQLiteAsyncConnection db;

        //constructor de la clase DataBaseSQLite
        public BaseSQLite(String pathdb)
        {
            //crear una conexion a la base de datos
            db = new SQLiteAsyncConnection(pathdb);

            //creacion de la tabla personas dentro de SQLite
            db.CreateTableAsync<Firmas>().Wait();
        }

        //opaciones CRUD con SQLite
        //READ List Way
        public Task<List<Firmas>> ObtenerListaFirmas()
        {
            return db.Table<Firmas>().ToListAsync();

        }

        //retornar una persona //READ one by one
        //(retorna el primero que encuentre ya que pueden a ver varios del dp choluteca)
        public Task<Firmas> ObtenerFirma(int pcodigo)
        {
            return db.Table<Firmas>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GrabarFirma(Firmas firma)
        {
            if (firma.codigo != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {

                return db.InsertAsync(firma);
            }
        }

        //delete
        public Task<int> EliminarUbicacion(Firmas firma)
        {
            return db.DeleteAsync(firma);
        }
    }
}
