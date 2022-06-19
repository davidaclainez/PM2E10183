using System;
using SQLite;
using PM2E10183.Models;

namespace PM2E10183.Data
{
	public class SQLiteHelper	()
	{	
		SQLiteAsyncConnection db;
		public SQLiteHelper(string dbPath)
    {
		db = new SQLiteAsyncConnection(dbPath);
		db.CreateTableAsync<sitios>().Wait;
    }
	}
}
