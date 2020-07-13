

namespace Armadura.ViewModels
{
   
   public class MainViewModel
    {
        private static MainViewModel instance;
        #region Viewmodel
        public LoginViewModel Login
        {
            get;
            set;
        }
        #endregion
        #region Constructor
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }
            return instance;
        }
        #endregion
    }
}
