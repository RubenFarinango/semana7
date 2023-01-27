using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<estudiante> releminar;
        IEnumerable<estudiante> ractualizar;

        public Elemento(int id, string Nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            txtnombre.Text = Nombre;
            txtusuario.Text = usuario;
            txtcontrasena.Text = contrasena;
            IdSeleccionado = id;

        }

        public static IEnumerable<estudiante> delete (SQLiteConnection db, int id)
        {
            return db.Query<estudiante>("DELETE FROM estudiante WHERE id =?", id);
        }

        public static IEnumerable<estudiante> update(SQLiteConnection db, int id, string nombre, string usuario, string contrasena)
        {
            return db.Query<estudiante>("UPDATE estudiante set nombre =?, usuario =?, contrasena=? Where id =?" , nombre, usuario, contrasena,id);
        }

        private void btnactualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael2023.db3");
                var db = new SQLiteConnection(ruta);
                ractualizar = update(db, IdSeleccionado, txtnombre.Text, txtusuario.Text, txtcontrasena.Text);
                Navigation.PushAsync(new ConsultaResgistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void btneliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael2023.db3");
                var db = new SQLiteConnection(ruta);
                releminar = delete(db, IdSeleccionado);
                Navigation.PushAsync(new ConsultaResgistro());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}