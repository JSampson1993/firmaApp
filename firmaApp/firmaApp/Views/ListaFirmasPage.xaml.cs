using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firmaApp.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firmaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaFirmasPage : ContentPage
    {
        public ListaFirmasPage()
        {
            InitializeComponent();

            
        }

        // mostras lista de personas 

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            List<Firmas> firmas = new List<Firmas>();
            firmas = await App.Basedatos03.ObtenerListaFirmas();
            lstFirmas.ItemsSource = firmas;

        }

        private void lstFirmas_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }
    }
}