using PracticalTask1.Database;
using SQLite;
using System.Collections.ObjectModel;

namespace PracticalTask1.Models
{
    public class PackageModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Weight { get; set; }

        public DatabaseHandler databaseHandler = new();
        public void InsertUpdatePackages(ObservableCollection<Package> packages)
        {
            using (var db = new SQLiteConnection(databaseHandler.fullPath, SQLiteOpenFlags.ReadWrite))
            {
                foreach (var package in packages)
                {
                    if (db.Find<Package>(package.Id) != null)
                    {
                        db.Update(package);
                    }
                    else
                    {
                        db.Insert(package);
                    }
                }
            }
        }

        public void GetPackagesFromDatabase(ObservableCollection<Package> packages)
        {
            packages.Clear();
            using (var db = new SQLiteConnection(databaseHandler.fullPath, SQLiteOpenFlags.ReadOnly))
            {
                db.Table<Package>().ToList().ForEach(i => packages.Add(i));
            }
        }
    }
}
