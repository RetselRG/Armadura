

namespace Armadura.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Views;
    public class LoginViewModel : BaseViewModel
    {
        #region Atributos
        private bool isRunning;
        private string password;
        private bool isEnabled;
        private string email;
        #endregion

        #region Propiedades
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }
        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }
        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        public bool EsRecordado
        {
            get;
            set;
        }

        #endregion
        #region Constructores
        public LoginViewModel()
        {
            this.EsRecordado = true;
            this.Email = "lrobledo2@gmail.com";
            this.Password = "12345";
            //   this.IsEnable = false;
        }
        #endregion
        #region Comandos
        public ICommand LoginCommad
        {
            get
            {
                return new RelayCommand(Login);
            }

        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe ingresar el Mail", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debe ingresar el Password", "Aceptar");
                return;
            }
            this.IsRunning = true;
            this.IsEnabled = false;

            if (this.Email != "lrobledo2@gmail.com" || this.Password != "12345")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error", "Email o Password incorrectos", "Aceptar");
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Datos = new DatosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new DatosPage());
            //await Application.Current.MainPage.DisplayAlert("Ok", "Excelente", "Aceptar");
        }
        #endregion
    }
}
