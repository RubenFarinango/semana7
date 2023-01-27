using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace semana7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaResgistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<estudiante> testudiante;
        public ConsultaResgistro()
        {
            InitializeComponent();
            con = DependencyService.Get<database>().GetConnection();
            Listar();
        }
        public async void Listar()
        {
            var resultado = await con.Table<estudiante>().ToListAsync();
            testudiante = new ObservableCollection<estudiante>(resultado);
            ListaEstudiantes.ItemsSource = testudiante;

        }
         public void OnSelection(object sender, SelectedItemChangedEventArgs e)
         {
            var obj = (estudiante)e.SelectedItem;
            var item = obj.id.ToString();
            var id = Convert.ToInt32(item);
            var nombre = obj.Nombre.ToString();
            var usuario = obj.Usuario.ToString();
            var constrasena = obj.contrasena.ToString();
            Navigation.PushAsync(new Elemento(id, nombre, usuario, constrasena));


        }
        private void btnregresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new login());
        }
    }
}