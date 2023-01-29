using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight;
using PracticalTask1.Database;
using SQLite;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PracticalTask1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public DatabaseHandler databaseHandler = new DatabaseHandler();
        public ObservableCollection<Package> Packages { get; set; }
        public SQLiteConnection db;

        public MainWindowViewModel() 
        {
            db = new SQLiteConnection(databaseHandler.fullPath, SQLiteOpenFlags.ReadWrite);
            Packages = new ObservableCollection<Package>(db.Table<Package>());
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

                        foreach(var package in Packages)
                        {
                            db.InsertOrReplace(package);
                        }
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
                    Packages.Clear();
                    db.Table<Package>().ToList().ForEach(i => Packages.Add(i));
                });
                return _CancelCommand;
            }
        }
    }
}
