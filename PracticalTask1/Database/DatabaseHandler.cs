using SQLite;
using System;
using System.IO;

namespace PracticalTask1.Database
{
    public class DatabaseHandler
    {
        private SQLiteConnection _db;

        public DatabaseHandler()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var fullPath =  Path.Combine(basePath, "packagesdb.sqlite");
            _db = new SQLiteConnection(fullPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
            _db.CreateTable<Package>();
        }
    }
}
