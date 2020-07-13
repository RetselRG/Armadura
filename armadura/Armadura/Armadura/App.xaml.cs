

namespace Armadura
{
    using Views;
    using Xamarin.Forms;
 
    public partial class App : Application
    {
        #region Conctructores
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new MainPage();
        }
        #endregion
        #region Metodos
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
        #endregion
    }
}
