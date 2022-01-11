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
    public class JobManagementViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Client> _clients;
        private Client _selectedClient;
        private ObservableCollection<CompletedJob> _completedJobs;
        private ObservableCollection<JobRequest> _notAssignedJobs;
        //private CompletedJob _completedJob;
        private CompletedJob _selectedCompletedJob;
        private JobRequest _newJobRequest;
        private JobRequest _selectedNotAssignedJob;
        //private JobRequests _jobRequests;
        public event PropertyChangedEventHandler PropertyChanged;
        private RelayCommand _updateCommand;
        private RelayCommand _addCommand;
        
        private RelayCommand _searchCommand;
        private RelayCommand _assignCommand;
        private AvailableContractor _availableContractor;

        private string _searchTextClient;
        private string _searchChoiceClient;
        private RelayCommand _searchClientCommand;
        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            { 
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        public JobManagementViewModel()
        {
            _selectedCompletedJob = new CompletedJob();
            //_selectedNotAssignedJob = new JobRequest();
            _newJobRequest = new JobRequest();
            

            CompletedJobs allCompletedJobs = new CompletedJobs();
            this.CompletedJobs = new ObservableCollection<CompletedJob>(allCompletedJobs);

            JobRequests allJobRequests = new JobRequests();
            this.NotAssignedJobs = new ObservableCollection<JobRequest>(allJobRequests);

            Clients allClients = new Clients();
            this.Clients = new ObservableCollection<Client>(allClients);

            if(AvailableContractor == null) {
                _availableContractor = new AvailableContractor();
            }
            //if (SelectedNotAssignedJob.BookingDate.ToString() !=  "1/01/0001 12:00:00 AM" ) { 
            //AvailableContractors allContractors = new AvailableContractors(this.SelectedNotAssignedJob);
            //this.AvailableContractors = new ObservableCollection<AvailableContractor>(allContractors);}

        }

        public string SearchTextClient
        {
            get { return _searchTextClient; }
            set
            {
                _searchTextClient = value; OnPropertyChanged("SearchTextClient");
            }
        }

        public string SearchChoiceClient
        {
            get { return _searchChoiceClient; }
            set
            {
                _searchChoiceClient = value; OnPropertyChanged("SearchChoiceClient");
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

        public RelayCommand AddCommand
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

        public RelayCommand AssignCommand 
        {
            get
            {
                if (_assignCommand == null)
                {
                    _assignCommand = new RelayCommand(this.AssignMethod, true);
                }
                return _assignCommand;
            }
            set
            {
                _assignCommand = value;
            }
        }
       

        public ObservableCollection<CompletedJob> CompletedJobs
        {
            get { return _completedJobs; }
            set
            {
                _completedJobs = value;
                OnPropertyChanged("CompletedJobs");
            }
        }

        public CompletedJob SelectedCompletedJob
        {
            get { return _selectedCompletedJob; }
            set
            {
                _selectedCompletedJob = value;
                OnPropertyChanged("SelectedCompletedJob");
            }
        }

        public ObservableCollection<Client> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                _selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }

        public JobRequest NewJobRequest
        {
            get {
                //_newJobRequest.BookingDate = DateTime.Today;
                return _newJobRequest; }
            set
            {
                _newJobRequest = value;
                OnPropertyChanged("NewJobRequest");
            }
        }
        

        public ObservableCollection<JobRequest> NotAssignedJobs
        {
            get { return _notAssignedJobs; }
            set
            {
                _notAssignedJobs = value;
                OnPropertyChanged("NotAssignedJobs");
            }
        }

        public JobRequest SelectedNotAssignedJob
        {
            get { return _selectedNotAssignedJob; }
            set
            {
                _selectedNotAssignedJob = value;
                OnPropertyChanged("SelectedNotAssignedJob");
            }
        }

        public AvailableContractor AvailableContractor
        {
            get { return _availableContractor; }
            set
            {
                _availableContractor = value;
                OnPropertyChanged("AvailableContractor");
            }
        }
        public RelayCommand SearchClientCommand
        {
            get
            {
                if (_searchClientCommand == null)
                {
                    _searchClientCommand = new RelayCommand(this.SearchClientMethod, true);

                }
                return _searchClientCommand;
            }
            set
            {
                _searchClientCommand = value;
            }
        }

        public void SearchClientMethod()
        {

            try
            {
                Clients allClients = new Clients(this.SearchChoiceClient, this.SearchTextClient);
                this.Clients = new ObservableCollection<Client>(allClients);

            }
            catch
            {
                MessageBox.Show("Please enter your choice of search and fill the search box!");
            }
        }

        //if(SelectedNotAssignedJob.JobReqId == 0)
        public RelayCommand SearchCommand
        {
            get
            {
                if (_searchCommand == null  )
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
        public void SearchMethod()
        {
            try
            {
                SelectedNotAssignedJob.SearchMethod();
            }
            catch
            {

            }
        }





        public void UpdateMethod()
            
        {
            if(SelectedCompletedJob != null) { 
            
               string resultMsg = SelectedCompletedJob.UpdateStatus();

                MessageBox.Show(resultMsg);

                CompletedJobs allCompletedJobs = new CompletedJobs();
            this.CompletedJobs = new ObservableCollection<CompletedJob>(allCompletedJobs);
            }
        }
        public void AddMethod()
        {
            if (NewJobRequest != null)
            {
                NewJobRequest.ClientId = SelectedClient.ClientId;
                string resultMsg = NewJobRequest.AddJobRequest();
                MessageBox.Show(resultMsg);

                Clients allClients = new Clients();
                this.Clients = new ObservableCollection<Client>(allClients);
            }
        }


        public void AssignMethod()
        {
            SelectedNotAssignedJob.AvailContractor.AvailabilityId = AvailableContractor.AvailabilityId;
            string resultMsg = SelectedNotAssignedJob.AssignContractor();
            MessageBox.Show(resultMsg);

            JobRequests allJobRequests = new JobRequests();
            this.NotAssignedJobs = new ObservableCollection<JobRequest>(allJobRequests);
            //if (NewJobRequest != null)
            //{
            //    NewJobRequest.ClientId = SelectedClient.ClientId;
            //    string resultMsg = NewJobRequest.AddJobRequest();
            //    MessageBox.Show(resultMsg);

            //    Clients allClients = new Clients();
            //    this.Clients = new ObservableCollection<Client>(allClients);
            //}
        }
        
    }
}
