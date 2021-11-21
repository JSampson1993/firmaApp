using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firmaApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignatureSample : ContentPage
    {
        public SignatureSample()
        {
            InitializeComponent();
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                var mStream = (MemoryStream)image;
                byte[] data = mStream.ToArray();
                string base64Val = Convert.ToBase64String(data);
                lblBase64Value.Text = base64Val;
                imgSignature.Source = ImageSource.FromStream(() => mStream);

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }
 

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.ListaFirmasPage());
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {

            var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            string base64Val = Convert.ToBase64String(data);
            lblBase64Value.Text = base64Val;
            imgSignature.Source = ImageSource.FromStream(() => mStream);

            try
            {
                var firmas = new Models.Firmas
                {
                    //latitud = Convert.ToDouble(this.txtlatitud.Text),
                    //longitud = Convert.ToDouble(this.txtlongitud.Text),
                    name = this.txtnombre.Text,
                    descripcion = this.txtdescrip.Text,
                    //MiImagen = imgSignature.Source = ImageSource.FromStream(() => mStream)
                    MiImagen = data


            };

                var resultado = await App.Basedatos03.GrabarFirma(firmas);


                if (resultado == 1)
                {
                    await DisplayAlert("Mensaje", "Ingresada Exitosamente", "OK");
                }
                else
                {
                    await DisplayAlert("Mensaje", "Error, No se logro guardar Ubicacion", "OK");

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Mensaje", ex.Message.ToString(), "OK");

            }
        }
    }
}