using PracticalTask1.Database;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTask1.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public DatabaseHandler databaseHandler = new DatabaseHandler();
        public List<Package> Packages { get; set; }

        public MainWindowViewModel() 
        {
            using(var db = new SQLiteConnection(databaseHandler.fullPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create))
            {
                Packages = db.Table<Package>().ToList();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
