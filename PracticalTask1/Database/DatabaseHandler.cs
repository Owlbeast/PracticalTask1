using SQLite;
using System;
using System.IO;

namespace PracticalTask1.Database
{
    public class DatabaseHandler
    {
        public string fullPath;

        public DatabaseHandler()
        {
            var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            fullPath =  Path.Combine(basePath, "packagesdb.sqlite");

            using (var _db = new SQLiteConnection(fullPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create))
            {
                _db.CreateTable<Package>();
                _db.Close();
            }
        }
    }
}
