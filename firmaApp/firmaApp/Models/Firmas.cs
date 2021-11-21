using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace firmaApp.Models
{
    public class Firmas
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(100)]
        public string name { get; set; }

        [MaxLength(250)]
        public string descripcion { get; set; }

        public byte[]  MiImagen { get; set; }

     ///   public ImageSource MiImagen { get; set; }


    }
}
