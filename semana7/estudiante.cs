using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace semana7
{
    public class estudiante
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Usuario { get; set;}
        [MaxLength(50)]
        public string contrasena { get; set;}
    }
}
