using RemindMe.Basic;
using RemindMe.Models;
using RemindMe.Services;
using RemindMe.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace RemindMe.ViewModels
{
    public class RemindMeViewModel: NotifactionObject
    {
        private RemindMeView _remindMeView;
        public RemindMeViewModel(RemindMeView remindMeView)
        {
            _remindMeView = remindMeView;
            _remindMeView.Closed += _remindMeView_Closed;
            InitComamnd();
            InitData();
        }
        private void _remindMeView_Closed(object? sender, EventArgs e)
        {
            ClosedCommandExecute();
        }

        private ObservableCollection<SignInItemModel> _signInItems = new ObservableCollection<SignInItemModel>();
        public ObservableCollection<SignInItemModel> SignInItems
        {
            get { return _signInItems; }
            set
            {
                _signInItems = value;
                this.RaisePropertyChange("SignInItems");
            }
        }
        private SignInItemModel _selectedSignInItem = new SignInItemModel();
        public SignInItemModel SelectedSignInItem
        {
            get
            {
                return _selectedSignInItem;
            }
            set
            {
                _selectedSignInItem = value;
                this.RaisePropertyChange("SelectedSignInItem");
            }
        }
        private string _fileName = "data.json";
        private SignInItemModel _currentSignInItem;
        private void InitData() 
        {
            GetSignInItems();
        }
        /// <summary>
        /// 获取所有的签到列表
        /// </summary>
        private void GetSignInItems() 
        {
            try
            {
                if (File.Exists(_fileName))
                {
                    string json = File.ReadAllText(_fileName);
                    SignInItems = JsonSerializer.Deserialize<ObservableCollection<SignInItemModel>>(json);
                    foreach (SignInItemModel signInItem in SignInItems)
                    {
                        if (!string.IsNullOrEmpty(signInItem.ImageUrl))
                        {
                            signInItem.Image = new BitmapImage(new Uri($"../Images/{signInItem.ImageUrl}", UriKind.RelativeOrAbsolute));
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                
            }
        }
        public ICommand SignInAllCommand
        {
            get;set;
        }
        public ICommand SignInCommand
        {
            get;set;
        }
        public ICommand AddCommand
        {
            get;set;
        }
        public ICommand ClosedCommand
        {
            get;set;
        }
        public ICommand DelCommand
        {
            get;set;
        }
        private void InitComamnd() 
        {
            SignInAllCommand = new DelegateCommand(SignInAllCommandExecute);
            SignInCommand = new DelegateCommand<object>(SignInCommandExecute);
            AddCommand = new DelegateCommand(AddCommandExecute);
            ClosedCommand = new DelegateCommand(ClosedCommandExecute);
            DelCommand = new DelegateCommand(DelCommandExecute);
        }
        private void SignInAllCommandExecute()
        {
            SignInMicrosoftRewards();
            SignInJuejin();
        }
        private void SignInCommandExecute(object obj)
        {
            if (obj != null)
            {
                _currentSignInItem = obj as SignInItemModel;
                if (!string.IsNullOrEmpty(_currentSignInItem.Method)) 
                {
                    MethodInfo methodInfo = typeof(RemindMeViewModel).GetMethod(_currentSignInItem.Method);
                    if(methodInfo != null ) 
                    {
                        methodInfo.Invoke(this, null);
                    }
                }
            }
        }

        private void AddCommandExecute() 
        {
            AddView addView = new AddView();
            AddViewModel addViewModel = new AddViewModel(addView);
            addView.Owner = _remindMeView;
            addView.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
            addView.DataContext=addViewModel;
            addView.ShowDialog();
            if (addViewModel.IsConfirm) 
            {
                addViewModel.SignInItem.Time = DateTime.Parse($"{addViewModel.SignInItem.Hour}:{addViewModel.SignInItem.Minute}:{addViewModel.SignInItem.Second}");
                SignInItems.Add(addViewModel.SignInItem);
            }
        }
        private void ClosedCommandExecute()
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
            }
            if (SignInItems != null)
            {
                foreach (SignInItemModel signInItem in SignInItems) 
                {
                    signInItem.Image = null;
                }
                string json = JsonSerializer.Serialize(SignInItems);
                File.WriteAllText(_fileName,json);
            }
        }
        private void DelCommandExecute() 
        {
            if (SelectedSignInItem != null)
            {
                SignInItems.Remove(SelectedSignInItem);
            }
        }

        #region 签到方法
        public void SignInMicrosoftRewards()
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    string url = $"https://cn.bing.com/search?q={i}";
                    string exePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                    Process.Start(exePath, url);
                }
                if (_currentSignInItem != null) 
                {
                    _currentSignInItem.Status = "已签到";
                }
            }
            catch (Exception ex)
            {

            }
        }
        public void SignInJuejin()
        {
            try
            {
                string url = _currentSignInItem.Url;
                string exePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
                Process.Start(exePath, url);
                if (_currentSignInItem != null)
                {
                    _currentSignInItem.Status = "已签到";
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion 签到方法
    }
}
