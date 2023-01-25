using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        private SQLiteAsyncConnection con;
        public login()
        {
            InitializeComponent();
            con = DependencyService.Get<database>().GetConnection();
        }

        public static IEnumerable<estudiante> Select_Where(SQLiteConnection db, string usuario, string contrasena)
        {
            return db.Query<estudiante>("SELECT * FROM estudiante where usuario=? and contrasena=?", usuario, contrasena);
        }
        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael2023.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<estudiante>();
                IEnumerable<estudiante> resultado = Select_Where(db, txtusuario.Text, txtcontrasema.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaResgistro());
                }
                else
                {
                    DisplayAlert("Alerta", "usuario o contraseña incorrecto", "Cerrar");
                }
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btnregistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}