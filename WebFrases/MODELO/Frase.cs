using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFrases.MODELO
{
    public class ModeloFrase
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public int IdAutor { get; set; }
        public int IdCategoria { get; set; }
    }
}