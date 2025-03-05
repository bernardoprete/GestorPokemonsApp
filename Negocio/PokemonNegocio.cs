using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using Negocio;
using System.Security.Cryptography.X509Certificates; //COLOCAR ESTO


//En las clases negocio voy a crear la logica y los metodos para realizar las acciones que necesito.


// Cuando refactorizo el proyecto ahora las clases pokemon y elemento no recomocen el nuevo proyecto llamado dominio, entonces tengo que hacer algo para que lo recomozca
//Entonces le tengo qeu decir al proyecto winformApp que va a usar el poryecto dominio , entonces en las referencias del pryecto que necesita usar las clases del otro proyecto, 
// En este caso el proyecto winformAPp voy a darle click derecho agregar referencia y tildo al proyecto que voy a usar , en este caso voy a winform agrego referencia y tildo dominio
// Winform ahora puede usar las clases de dominio pero no al reves .. IMPORTANTE.
//Ademas debo cambiar los modificadores de visibilidad de las clases que estan en  dominio para que las clases qye estan en winformApp puedan recomocerlas y  usar sus clases, --  ponerlas en PUBLIC 

namespace negocio
{
    public class PokemonNegocio
    {
        // IMPORTANTE ----- Voy a tener 2 clases una llamada elementoNegocio y otro POkemonNegocio para diversificar responsabilidades y poder manejar de manera independientes los elementos, de las otras caracteristicas del pokemon como nombre num etc , Esto sirve tmb para hacerm as escalable la app. 


        //En esta clase voy a crear los metodos de acceso a datos para los pokemons.
        //En esta clase voy a ejecutar la consulta y setearla (metodos creados en acceso a datos class, pero de forma manual y mas larga).




        //METODOS DE LA CLASE



        public List<Pokemon> listar() //metodo listar es de tipo ListPokemon, por eso es de tipo list y no void o int por ejm. 
        {

            //metodo de tipo List.

            List<Pokemon> lista = new List<Pokemon>(); // Creo un objeto que sera una lista.Esto tengo que hacerlo si o si.

            //CONEXION A SQL 


            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand(); // Necesario para realizar acciones.
            SqlDataReader lector; // No instacion el objeto porque voy a obtener como resultado un objeto de tipo SqlDataReader.




            //Primero voy a hacer manejo de excepciones.
            // Aqui voy a renderizar la tabla de pokemons que me muestra en el datagrid una vez que se inicia la app. La consulta a la bd  arma las columnas y me dice que datos traer a la grilla. IMPORTANTE.

            try
            {

                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=POKEDEX_DB; integrated security= true"; //A donde me voy a conectar.
                comando.CommandType = System.Data.CommandType.Text;     // Es la accion, en este caso vamos a realizar la accion de lectura sobre la BD.
                comando.CommandText = "select Numero , Nombre, P.Descripcion, UrlImagen ,E.Descripcion as Tipo, DEB.Descripcion as Debilidad, P.IdTipo , P.IdDebilidad , P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS DEB where E.id = P.IdTipo and DEB.Id = P.IdDebilidad and P.Activo =1\r\n"; // Si algo no se lista o se renderiza en el front es porque quizas la consulta combinada o relacionada de esta linea no tiene en cuenta otras consultas que se hacen con otros metodos como por ejm agregar pokemon. -- Esta consulta renderiza la lista de pokemones , es decir que trae la lista que se muestra en pantalla y que columnas se muestran.
                comando.Connection = conexion; // Ese comando que estoy utilizando va a conectar en la conexion de la primera linea.

                conexion.Open(); // Abro la conexion
                lector = comando.ExecuteReader(); // Realizo la lectura y lo guardo en la variable de tipo sqldatareader lector que cree mas arriba.

                while (lector.Read())
                { //Si hay una lectura es decir algo por leer entonces se entra al while.

                    Pokemon aux = new Pokemon(); // Genero un objeto llamado aux y voy a cargarlo con los datos que traigo de la BD.
                    aux.Id = (int)lector["Id"];
                    aux.Numero = (int)lector["Numero"]; //Leo la columna numero 
                    aux.Nombre = (string)lector["Nombre"]; // Leo columna nombre
                    aux.Descripcion = (string)lector["Descripcion"];//Leo columna desc


                    if (!(lector["UrlImagen"] is DBNull))  //VALIDACION : Si lo que se lee no es nulo entonces leelo.
                        aux.UrlImagen = (string)lector["UrlImagen"];//Leo columna URlIMagen - IMPORTANTE : Aqui la app tiraba una excepcion porque en la bd en la columna de Urlimagen hay un valor null y no pueede leerlo - Tengo que ver la referencia y manejar a excepcion donde la ref me lleve.



                    aux.Tipo = new Elemento(); // Hay que instanciar el objeto elemento para poder usar despues el .Tipo.Descripcion sino me devuelve referencia nula, el objeto que esta en pokemon.cs no tiene instancia por eso hay que instanciarlo si queremos usar sus propiedades. Tipo es un atributo de la clase pokemon que esta dentro de la clase elemento.
                    aux.Tipo.id = (int)lector["IdTipo"]; //LO AGREGUE A LA CONSULTA Y AQUI CUANDO PRECARGUE LOS CBOBOX EN LA CLASE FRMALTAPOKEMON. Entre parentesis va el mismo nombre de la columna.
                    aux.Tipo.Descripcion = (string)lector["Tipo"]; //Tipo es un objeto de tipo elemento que creamos en la clase pokemon y que tiene sus propiedades en la clase elemento, por eso le ponemos el .Descripcion.

                    aux.Debilidad = new Elemento(); //Creo como hice  arriba la instancia para poder usar las propiedades de la clase elemento.
                    aux.Debilidad.id = (int)lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)lector["Debilidad"];





                    lista.Add(aux); // Agrego el pokemon a la lista. 


                }
                conexion.Close(); // Para cerrar la conexion.
                return lista; // Me devuelve la lista

            }
            catch (Exception ex)
            {

                throw ex;
            }




        }

                                                          //METODO
        public void agregar(Pokemon nuevo) //Parametro que la funcion agregar necesita y es pasado por parametro desde el llamante que esta en frmaltapokemon y se llama poke

        {
            AccesoDatos datos = new AccesoDatos(); //Con este objeto ahora puedo tener acceso a los atributos y mas que nada a los metodos creados en esta clase para poder conectarme directamente y de manera mas rapida a la bd sin escribir todo de nuevo.


            try  //Vamos a hacer un insert en la base de datos para agregar pokemon.
            {
                datos.setearConsulta("insert into POKEMONS(Numero, Nombre, Descripcion, Activo, IdTipo, IdDebilidad, UrlImagen)values (" + nuevo.Numero + ",'" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1, @idTipo, @idDebilidad, @urlImagen )\r\n"); //Llamamos al metodo seteearConsulta creado en la clase acceso a datos para ahorrar codigo y hacerlo mas facil. Esta consulta me dice que renderizo y muestro cuando se agrega a un pokemon, sino la hago solo va a agregar el pokemon en la bd solamente.
                //Hay 2 formas, la segunda es haciendolo por algo que se llama parametros, para eso necesitamos el comando que en esta clase nace en la funcion listar y por ende no se puede usar, pero aqui no lo tenemos por eso tenemos que ir a la clase acceso a datos y hacer un nuevo metodo para agregar esos parametros.

                datos.setearParametro("@idTipo", nuevo.Tipo.id); // Llamante de la funcion setearParametros que tenemos en acceso a datos y pasamos por parametros precisamente los prametros.
                datos.setearParametro("@idDebilidad", nuevo.Debilidad.id);
                datos.setearParametro("@urlImagen", nuevo.UrlImagen);

                datos.ejecutarAccion(); // llamamos al metodo ejectutar accion tmb creado en Acceso a datos class , para realizar esa "No consulta" e insertar el pokemon en la bd.
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion(); // Tambien metodo creado en Acceso a datos class para facilitar y modularizar las cosas y en este caso cerrar la conexion.
            }

        }



                                                           //METODO

        public void modificar(Pokemon poke)   //Parametro que la funcion modificar necesita y es pasado por parametro desde el llamante que esta en frmaltapokemon y se llama pokemon
        {

            AccesoDatos datos = new AccesoDatos(); //Creo otra vez un objeto del tipo acceso a datos.

            try //Repito toda la secuencia del metodo agregar pero todos las propiedades las agrego o las piso con parametros.
            {
                datos.setearConsulta("update POKEMONS set Numero  = @numero , Nombre = @nombre, Descripcion = @desc, UrlImagen = @img, IdTipo = @idTipo, IdDebilidad = @idDebilidad where id = @id\r\n");
                datos.setearParametro("@numero", poke.Numero);
                datos.setearParametro("@nombre", poke.Nombre);
                datos.setearParametro("@desc", poke.Descripcion);
                datos.setearParametro("@img", poke.UrlImagen);
                datos.setearParametro("@idTipo", poke.Tipo.id);
                datos.setearParametro("@idDebilidad", poke.Debilidad.id);
                datos.setearParametro("@id", poke.Id);


                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }

            finally
            {
                datos.cerrarConexion(); // Tambien metodo creado en Acceso a datos class para facilitar y modularizar las cosas y en este caso cerrar la conexion.
            }



        }


                                                               //METODO

         public void eliminar(int id ) //Esta funcion va a recibir un id del pokemon a eliminar -- ELIMINA FISCAMENTE
        {
            AccesoDatos datos = new AccesoDatos(); // Creo nuevamente nuestra clase acceso a datos como en los otros metodos.

            try
            {
                datos.setearConsulta("delete from POKEMONS where id = @id");
                datos.setearParametro("@id", id);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }




                                                                   //METODO

        public void eliminarLogico(int id) //ELIMINA LOGICAMENTE.
        {

            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("update POKEMONS set Activo = 0 where id= @id"); //Realizo nueva consulta pero esta vez con un update ya que solo tengo que pasar la columna activo de la bd a a 0 , es decir a inactivo. ES IMPORTANTE SABER QUE ESTA CUANDO SE TOCA EL BOTON ELIMINARLOGICO a traves de esta consulta el id del pokemon queda en 0 , es decir true , por eso cuando en la logica de los eventos se recibe este cero se valida y quiere decir que es un eliminar logico si tiene 1 quiere decir que es fisico y que se toco el boton eliminar fisico.
                datos.setearParametro("@id", id); //Seteamos el parametro como veniamos haciendolo.
                datos.ejecutarAccion();
                //IMPORTANTE 
                //Luego de configurar esto voy a la logica del boton eliminar logico en frmPokemons para configurar el evento. 
            }
            catch (Exception ex)
            {

                throw ex;
            }
               
          }




                                         //METODO (METODO QUE SE LLAMA EN EL EVENTO BUSCAR DEL FRM POKEMON)

        public List<Pokemon> filtrar(string campo, string criterio, string filtro) //IMPORTANTE - Este metodo que es llamado en el btnBuscar  me tiene que devolver una lista de tipo pokemons con los pokemons filtrados segun los campos cargados por el usuario (campo - criterio y filtro) que estan en el evento que se realiza cuando tocamos en el boton buscar en el form inicial y que vemos su logica en la clase frmPokemons.
        {

            List<Pokemon> lista = new List<Pokemon>(); //Esto que vamos a hacer se parece mucho al metodo listaR , ya que vamos a realizar una lista de pokemons pero con el filtro. Por eso creo este objeto.
            AccesoDatos datos = new AccesoDatos(); //Creamos este objeto ya que vamos a tener que realizar una consulta sql.


            try
            {
                string consulta = "select Numero , Nombre, P.Descripcion, UrlImagen ,E.Descripcion as Tipo, DEB.Descripcion as Debilidad, P.IdTipo , P.IdDebilidad , P.Id from POKEMONS P, ELEMENTOS E, ELEMENTOS DEB where E.id = P.IdTipo and DEB.Id = P.IdDebilidad and P.Activo =1 and "; //A esta consulta le falta una parte dependiendo de lo que cargue el usuario en los combobox y la caja de textos la vamos a completar de la siguiente manera concatenando....
                if (campo == "Numero")
                {
                    switch (criterio)
                    {
                        case "Mayor a ":
                            consulta += "Numero > " + filtro; //En el caso de que se elija mayor a concatenamos a la consulta el numero + el filtro
                            break;

                        case "Menor a ":
                            consulta += "Numero < " + filtro;
                            break;

                        case "Igual a ":
                            consulta += "Numero = " + filtro;
                            break;

                    }

                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Nombre like '" + filtro + "%' ";
                            break;

                        case "Termina con":
                            consulta += "Nombre like '%" + filtro + "'";

                            break;


                        case "Contiene":
                            consulta += "Nombre like '%" + filtro + "%'";
                            break;

                    }

                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "P.Descripcion like '" + filtro + "%' ";           //En el caso de que se elija mayor a concatenamos a la consulta el numero + el filtro - Importante saber que en la consulta el like va seguido de "loqueescribausuario%" donde el % cambia depende de si es al final o al principio - Sino mirar video cuando restan 7min 40 seg.
                                                                                           //Aqui va P.Descripcion porque la columna se llama descripcion pero la que ahora buscamos es la descripcion del pokemons y no la de elementos que es E.Descripcion, en cambio las otras columnas tenian un nombre unico.
                         break;

                        case "Termina con":
                            consulta += "P.Descripcion like '%" + filtro + "'";
                            break;

                        case "Contiene":
                            consulta += "P.Descripcion like '%" + filtro + "%'";
                            break;

                    }

                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();



                //Copio esta parte del metodo listar: (Despues podria hacer un metodo y guardar este codigo)
                //Esto es para que me lea los datos que traigo de la DB, como hice antes. Copio lo mismo porque la consulta trae las mismas columnas aunque me las trae filtradas segun lo que el usuario coloque en combobox y caja textos.
                //Con la diferencia de qeu cuando aparece lector yo tengo que poner datos.lector. IMPORTANTE ademas lector aqui esta con mayuscula.

                while (datos.Lector.Read())
                { //Si hay una lectura es decir algo por leer entonces se entra al while.

                    Pokemon aux = new Pokemon(); // Genero un objeto llamado aux y voy a cargarlo con los datos que traigo de la BD.
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Numero = (int)datos.Lector["Numero"]; //Leo la columna numero 
                    aux.Nombre = (string)datos.Lector["Nombre"]; // Leo columna nombre
                    aux.Descripcion = (string)datos.Lector["Descripcion"];//Leo columna desc


                    if (!(datos.Lector["UrlImagen"] is DBNull))  //VALIDACION : Si lo que se lee no es nulo entonces leelo.
                        aux.UrlImagen = (string)datos.Lector["UrlImagen"];//Leo columna URlIMagen - IMPORTANTE : Aqui la app tiraba una excepcion porque en la bd en la columna de Urlimagen hay un valor null y no pueede leerlo - Tengo que ver la referencia y manejar a excepcion donde la ref me lleve.



                    aux.Tipo = new Elemento(); // Hay que instanciar el objeto elemento para poder usar despues el .Tipo.Descripcion sino me devuelve referencia nula, el objeto que esta en pokemon.cs no tiene instancia por eso hay que instanciarlo si queremos usar sus propiedades. Tipo es un atributo de la clase pokemon que esta dentro de la clase elemento.
                    aux.Tipo.id = (int)datos.Lector["IdTipo"]; //LO AGREGUE A LA CONSULTA Y AQUI CUANDO PRECARGUE LOS CBOBOX EN LA CLASE FRMALTAPOKEMON. Entre parentesis va el mismo nombre de la columna.
                    aux.Tipo.Descripcion = (string)datos.Lector["Tipo"]; //Tipo es un objeto de tipo elemento que creamos en la clase pokemon y que tiene sus propiedades en la clase elemento, por eso le ponemos el .Descripcion.

                    aux.Debilidad = new Elemento(); //Creo como hice  arriba la instancia para poder usar las propiedades de la clase elemento.
                    aux.Debilidad.id = (int)datos.Lector["IdDebilidad"];
                    aux.Debilidad.Descripcion = (string)datos.Lector["Debilidad"];





                    lista.Add(aux); // Agrego el pokemon a la lista. 

                }
                return lista; //Finalemte el metodo me va a retornar la lista que cumpla con las condiciones que establecio el usuario.

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
