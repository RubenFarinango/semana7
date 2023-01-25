using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.IO;
using semana7.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(sqlcliente))]
namespace semana7.Droid
{
    public class sqlcliente : database
    {
        public SQLiteAsyncConnection GetConnection()
        {
          var ruta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(ruta, "uisrael2023.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}