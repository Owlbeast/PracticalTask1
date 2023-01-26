using CommunityToolkit.Mvvm.Input;
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
using System.Windows;
using System.Windows.Input;

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

        private ICommand _UpdateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                _UpdateCommand ??= new RelayCommand(() =>
                    {
                        MessageBox.Show("update clicked");
                    });
                return _UpdateCommand;
            }
        }

        private ICommand _CancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                _CancelCommand ??= new RelayCommand(() =>
                {
                    MessageBox.Show("cancel clicked");
                });
                return _CancelCommand;
            }
        }
    }
}
