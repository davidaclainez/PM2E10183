using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using PM2E10183.Models;
using System.Threading.Tasks;

namespace PM2E10183.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Sitios>().Wait();
        }

        public Task <int> GuardarSitio(Sitios sitios)
        {
            if (sitios.ID == 0)
            {
                return db.InsertAsync(sitios);
            }
            else
            {
                return null;
            }
        }

        public Task<List<Sitios>> GetSitiosAsync()
        {
            return db.Table<Sitios>().ToListAsync();
        }
        public Task<List<Sitios>> GetSitiosById(int IDSitio)
        {
            return db.Table<Sitios>().Where(a=> a.ID == IDSitio).ToListAsync();
        }

        public Task<int> DeleteSitioAsync(Sitios sitio)
        {
            return db.DeleteAsync(sitio);
        } 
    }
}
