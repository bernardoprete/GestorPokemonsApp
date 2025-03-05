using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Pokemon
    {
        public int Id { get; set; }

        [DisplayName("Número")] // Anotation para modificar nombre de columnas que debe llevar acento o palabras compuestas.
        public int Numero { get; set; }
        public string Nombre { get; set; }


        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; } // Es un objeto de tipo elemento  -- En la bd seria la columna de idElmento y la descripcion solo la renderizamos en la app.

        public Elemento Debilidad { get; set; } // Creo una property de tipo elemento que es un objeto como hice con tipo. En la bd seria la columna de idDebilidad y la descripcion solo la renderizamos en la app.


    }
}