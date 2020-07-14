

namespace Armadura.ViewModels
{
    using Models;
    using System;
    using Services;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;
    using System.Collections.Generic;
    public class DatosViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion
        #region Attributes
        private ObservableCollection<Datos> datos;
        #endregion

        #region Properties
        public ObservableCollection<Datos> Datos
        {
            get { return this.datos; }
            set { SetValue(ref this.datos, value); }
        }
        #endregion
        #region Constructor
        public DatosViewModel()
        {
            this.apiService = new ApiService();
            this.LoadDatos();
        }
        #endregion
        #region Metodo
        private async void LoadDatos()
        {

            var conexion = await this.apiService.CheckConnection();
            if (!conexion.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", conexion.Message, "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }

            var response = await this.apiService.GetList<Datos>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all"
                );

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                await Application.Current.MainPage.Navigation.PopAsync();
                return;
            }
            var list = (List<Datos>)response.Result;
            this.Datos = new ObservableCollection<Datos>(list);
        }
        #endregion
    }
}
