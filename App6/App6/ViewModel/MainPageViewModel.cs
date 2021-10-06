using App6.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App6.ViewModel
{
    class MainPageViewModel : BaseViewModel
    {
        private string _user;
        private string _pass;
        private Command _loginCommand;
        private bool isErrorLogin;
        public MainPageViewModel(INavigation navigation) : base(navigation)
        {
            Navigation = navigation ?? App.Navigation;
        }

        public string User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }
        public string Pass
        {
            get => _pass;
            set
            {
                _pass = value;
                OnPropertyChanged();
            }
        }

        public Command LoginCommand
        {
            get => _loginCommand ?? (_loginCommand = new Command(GoToLoginAction));
        }
        public bool IsErrorLogin
        {
            get => isErrorLogin;
            set
            {
                isErrorLogin = value;
                OnPropertyChanged();
            }
        }
        private void GoToLoginAction()
        {
            IsErrorLogin = !(User == "Osvaldo" && Pass == "1234");
            if (!IsErrorLogin)
            {
                User = String.Empty;
                Pass = String.Empty;
                Navigation.PushAsync(new PageTwo());
            }
        }
    }
}
