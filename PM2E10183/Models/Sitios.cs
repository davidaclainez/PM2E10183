using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PM2E10183.Models
{
    public class Sitios
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Imagen { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Descripcion { get; set; }

    }
}
