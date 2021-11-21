using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using firmaApp.Controller;
using firmaApp.Views;
using System.IO;

namespace firmaApp
{
    public partial class App : Application
    {

        static BaseSQLite basedatos;

        public static BaseSQLite Basedatos03
        {
            get
            {

                if (basedatos == null)
                {
                    basedatos = new BaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "frimaApp.db3"));
                }

                return basedatos;

            }


        }




        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            // MainPage = new Views.SignatureSample();
            MainPage = new NavigationPage(new SignatureSample());


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
