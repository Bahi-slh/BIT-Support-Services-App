using BITDesktopApp.BLL;
using BITDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BITDesktopApp.ViewModels
{
    public class ContractorManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Contractor> _contractors;
        private Contractor _selectedContractor;
        private Contractor _contractor;
        private RelayCommand _addCommand;
        private RelayCommand _updateCommand;
        private string _searchText;
        private string _searchChoice;
        private RelayCommand _searchCommand;
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null) //this is checking if we do have an event handler
            {
                //PropertyChanged() is a delegate that will call an EventHandler
                //depending on who is Subscribed to listen to this event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        public RelayCommand AddCommand //MY NOTE: RelayCommand acts as a way to bind commands between the viewmodel and UI elements.
        {
            get
            {
                if (_addCommand == null)
                {
                    _addCommand = new RelayCommand(this.AddMethod, true);
                }
                return _addCommand;
            }
            set
            {
                _addCommand = value;
            }
        }
        public RelayCommand UpdateCommand
        {
            get
            {
                if (_updateCommand == null)
                {
                    _updateCommand = new RelayCommand(this.UpdateMethod, true);

                }
                return _updateCommand;
            }
            set
            {
                _updateCommand = value;
            }
        }

        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(this.SearchMethod, true);

                }
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
            }
        }
        public ContractorManagementViewModel()
        {
            //for adding a new contractor
            _contractor = new Contractor();

            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
        }

        public Contractor NewContractor
        {
            get {
                _contractor.Dob = DateTime.Today;
                return _contractor; }
            set { _contractor = NewContractor; }
        }

        public void AddMethod()
        {
            try
            {
            string resultMsg = NewContractor.AddContractor();
            MessageBox.Show(resultMsg);

            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            }
            catch
            {
                MessageBox.Show("Please try again!");
            }

        }

        public void UpdateMethod()
        {
            string resultMsg = SelectedContractor.UpdateContractor();
            MessageBox.Show(resultMsg);

            Contractors allContractors = new Contractors();
            this.Contractors = new ObservableCollection<Contractor>(allContractors);
            //try
            //{

            //}
            //catch
            //{
            //    MessageBox.Show("Please try again!");
            //}


        }


        public ObservableCollection<Contractor> Contractors
        {
            get { return _contractors; }
            set
            {
                _contractors = value;
                OnPropertyChanged("Contractors");
            }
        }
        public Contractor SelectedContractor
        {
            get { return _selectedContractor; }
            set
            {
                _selectedContractor = value;
                OnPropertyChanged("SelectedContractor");
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value; OnPropertyChanged("SearchText");
            }
        }

        public string SearchChoice
        {
            get { return _searchChoice; }
            set
            {
                _searchChoice = value; OnPropertyChanged("SearchChoice");
            }
        }

        public void SearchMethod()
        {

            try
            {
                Contractors allContractors = new Contractors(this.SearchChoice, this.SearchText);
                this.Contractors = new ObservableCollection<Contractor>(allContractors);

            }
            catch
            {
                MessageBox.Show("Please enter your choice of search and fill the search box!");
            }
        }
    }
}
