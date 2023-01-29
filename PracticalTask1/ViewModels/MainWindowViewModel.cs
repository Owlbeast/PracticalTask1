using CommunityToolkit.Mvvm.Input;
using GalaSoft.MvvmLight;
using PracticalTask1.Database;
using PracticalTask1.Models;
using SQLite;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PracticalTask1.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Package> Packages { get; set; }
        public PackageModel packageModel;

        public MainWindowViewModel() 
        {
            packageModel = new();
            Packages = new();
            packageModel.GetPackagesFromDatabase(Packages);
        }

        private ICommand _UpdateCommand;

        public ICommand UpdateCommand
        {
            get
            {
                _UpdateCommand ??= new RelayCommand(() =>
                {
                    packageModel.InsertUpdatePackages(Packages);
                    packageModel.GetPackagesFromDatabase(Packages);
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
                    packageModel.GetPackagesFromDatabase(Packages);
                });
                return _CancelCommand;
            }
        }
    }
}
