using RemindMe.Basic;
using RemindMe.Models;
using RemindMe.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RemindMe.ViewModels
{
    public class AddViewModel : NotifactionObject
    {
        public AddViewModel(AddView addView)
        {
            _addView = addView;
            InitCommand();
            InitData();
        }
        public bool IsConfirm = false;
        private AddView _addView;
        private SignInItemModel _signInItem = new SignInItemModel();
        public SignInItemModel SignInItem
        {
            get
            {
                return _signInItem;
            }
            set
            {
                _signInItem = value;
                this.RaisePropertyChange("SignInItem");

            }
        }
        private ObservableCollection<int> _Hour = new ObservableCollection<int>();
        public ObservableCollection<int> Hour
        {
            get
            {
                return _Hour;
            }
            set
            {
                _Hour = value;
                this.RaisePropertyChange("Hour");
            }
        }
        private ObservableCollection<int> _Minute = new ObservableCollection<int>();
        public ObservableCollection<int> Minute
        {
            get 
            {
                return _Minute;
            }
            set
            {
                _Minute= value;
                this.RaisePropertyChange("Minute");
            }
        }
        private ObservableCollection<int> _Second = new ObservableCollection<int>();
        public ObservableCollection<int> Second
        {
            get
            {
                return _Second;
            }
            set
            {
                _Second= value;
                this.RaisePropertyChange("Second");
            }
        }
        public ICommand ConfirmCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        private void InitCommand()
        {
            ConfirmCommand = new DelegateCommand(ConfirmCommandExecute);
            CancelCommand = new DelegateCommand(CancelCommandExecute);
        }
        private void ConfirmCommandExecute()
        {
            IsConfirm = true;
            _addView.Close();
        }
        private void CancelCommandExecute()
        {
            _addView.Close();
        }

        private void InitData() 
        {
            GetTimes();
        }
        private void GetTimes() 
        {
            for (int i = 0; i < 24; i++) 
            {
                Hour.Add(i);
            }
            for (int i = 0; i < 60; i++)
            {
                Minute.Add(i);
                Second.Add(i);
            }
        }
    }
}
