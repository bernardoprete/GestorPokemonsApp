using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
     public  class Elemento // Clase que tiene propiedades sobre el elemento (fuego, agua atc) de cada elemento y su id.
    {
        public int id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString() //Sobreescribi el metodo ToString para que me muestre la descripcion. Al ser Elemento un objeto no sabe cual de las properties mostrar el sistema (id, descripcion , en este caso) entonces mediante el metodo toString te muestra el namespace mas el nombre de la clase en pantalla. Hay que hacer esto para arreglarlo. De todas formas desde otros lugares puedo acceder al id haciendo variable.tipo.id por ejemplo o variable.Descripcion para acceder a la descripcion.
        {
            return Descripcion;         }
    }
}
