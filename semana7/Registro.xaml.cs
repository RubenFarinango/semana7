using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<database>().GetConnection();
        }

        private void btnregistro_Clicked(object sender, EventArgs e)
        {
            var datos = new estudiante
            {
                Nombre = txtnombre.Text,
                Usuario = txtusuario.Text,
                contrasena = txtcontrasena.Text
            };
            con.InsertAsync(datos);
            txtnombre.Text = "";
            txtusuario.Text = "";
            txtcontrasena.Text = "";
            Navigation.PushAsync(new login());
        }
    }
}