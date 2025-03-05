using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio; //Como es una clase de winformApp esta que estoy ahora debo agregar el using para poder leer las clases pokemons y elemento que ahora son clases del proyecto dominio. Las clasestienen que ser publicas.

using negocio; // Acordarse que las clases que esten dentro del proyecto negocio sean PUBLICAS para que dentro de este proyecto pueda usarlaas.
namespace winform_app
{
    public partial class frmPokemons : Form
    {
       
        
        private List<Pokemon> listaPokemon; //Este es un atributo , es una variable de tipo ListPokemon, luego tendremos una lista. Recordemos que frmPokemons tambien es una clase entonces podemos poner variables de cualquier tipo. Hicimos esta lista como un atributo (en vez de instanciar un objeto) de la clase para poder usarlo en los diferentes eventos que se vyan creando en esta clase , sino adentro de cada evento tendria que instanciar un nuevo objeto, aqui al estar en el scoop global en la clase puedo usarla directamente como en el evento para filtrar.
        //Otra cosa importante es que al cargar esta lista como atributo entonces durante la ejecucion de todo lo que pasa en esta clase esta lista esta viva, por ende cuando filtramos por ejm  siempre filtra sobre esta lista inicial.
        
        public frmPokemons()
        {
            InitializeComponent();
            Text = "Poke App"; //Modifico el nombre del formulario inicial de la app

        }


                                                          //EVENTO LOAD
        private void frmPokemons_Load(object sender, EventArgs e) //Pokemonnegocio tira una excepcion porque en la bd hay campos nulos y me trae hasta aqui por medio de la referencia (se busca en pokemonNegocio) - Hay que trabajar aqui entonces y manejar la excepcion con try y catch para que no se rompa, pero el error en la app sigue estando y hay que solucionarlo en POKEMONNEGOCIO ya que es un error al leer la bd.
        {

                inicializarFormulario();

        }




                                                            //EVENTO 

        private void inicializarFormulario ()
            {

            cargar(); //Llamo al metodo que cree abajo para que cada vez que en el formulario inicial de la app se cargue me aparezca la grilla con todos los pokemons.

            //Voy a cargar los combobox para hacer el filtro avanzado , lo hago en el load para que despues que aparezca la grilla , ya los cboBox esten cargados.


            

            // Reinicia los ComboBox y la caja de texto
            cboCampo.Items.Clear(); // Limpia los elementos antes de agregarlos nuevamente
            cboCriterio.Items.Clear();

            cboCampo.Items.Add("Numero");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripcion");

            cboCampo.SelectedIndex = -1; // Deja el ComboBox sin selección o se que no se ven las opciones aunque estan cargadas.
            cboCriterio.SelectedIndex = -1;
            txtFiltroAvanzado.Text = ""; // Borra el texto ingresado
            txtFiltro.Text = "";





            //El segundo cboBox lo voy a cargar dependiendo de lo que elija en el primerp obviamente, entonces ...
            //Por ejm si elegiste algo numerico le vamos a poner la opcion de mayor a igual a menor a y si elegiste algo con letras ponemos que contenga, que empiece con o que termine con.
            // Le hago doble click al primer despegable y se abre su evento .. lo tenemos mas abajo en esta clase.



        }



   
      

       
                                                        //EVENTO
                                                           

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e) // Seleccionar cada fila de la grilla y que cambie y me muestre la imgaen del pokemon. El selected Changed es un evento de la grilla.
        {

            if (dgvPokemons.CurrentRow != null) //Cuandp filtro la lista y ejecuto el evento de btnFiltro me da un error  ya que cuando inserto campos en el textbox y borro puede ser que en un momento el dgvPokemon.Current row este nullo y quiera transformar ese nulo en un objeto pokemon, al agregar este if si esta nulo no hace nada y la app no se rompe.
            {
            // tengo que tomar la fila actual donde esta seleccionado el pokemon dentro de la grilla, para tomarlo hago: 
            Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem; // Selecciono de cada fila de la grilla el pokemon enlazado, pero esto es un object por eso debo hacer un casteo explicito para Convertirlo en una variable de tipo clase pokemon y guardarlo ahi. 
            cargarImagen(seleccionado.UrlImagen); // Entonces cuando se inicia la app se carga el pokemon 0 de la lista (logica arriba) y vuando selecciono en la grilla se carga el pokemon corerspondiente.
            // Si aca no hiciera el casteo ni tampoco pusiera la variable seleccionado como uan variable de tipo pokemon no podria utilizar el atributo urlImagen que es de la clase Pokemon.
           
            }


        }

       
        
        
       
       

                                                       //EVENTO
       private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaPokemon alta  = new frmAltaPokemon();    // Crear siempre el objeto del alta, que seria el nombre del formulario de disenio llamado frmAltaPokemon.
            alta.ShowDialog(); // Con esto visualizo la ventana y no me puedo salir de ella porque tengo el show dialog.
            cargar(); // Otro llamanete de la funcion cargar para que cada vez que agregue un pokemon con el boton agregar se actualice directamente la pantalla y no hay que cerrar la app para ello.
        }




                                                       //EVENTO

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //A este formulario le voy a pasar por parametro el objeto pokemon que quiero modificar AL CONSTRUCTOR DE LA CLASE

            // Verificar si la grilla está vacía primero asi si esta vacia o nula no puedo MODIFICAR nada y me tira el cartel.
            if (dgvPokemons.Rows.Count != 0 || dgvPokemons.CurrentRow != null) //Sino esta vacia o nula hago el resto
            {
                Pokemon seleccionado;
                seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem; //Casteo


                if (dgvPokemons != null)
                {

                    frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);    // Crear siempre el objeto del alta, que seria el nombre del formulario de disenio llamado frmModificaraPokemon.
                                                                                    // AQui arriba le voy a enviar por parametro al constructor de la clase frmAltaPOkemon este pokemon llamado seleccionado para que cuando toquemmos el boton modificar en frmAltapokemon reciba este para modificarlo - No es una funcion PERO SE PUEDEN PASAR PARAMETROS EN EL CONSTRUCTOR.
                                                                                    //La clave de duplicar los constructores en la clase frmAltaPokemon es que cuando tocas el boton agregar llama al constructor vacio de esa clase y cuando tocas modificar al pasarle este parametro vas si o si a llamar al constructor duplicado que es el que recibe un pokemon seleccionado.

                    modificar.ShowDialog(); // Con esto visualizo la ventana y no me puedo salir de ella porque tengo el show dialog.
                    cargar(); // Otro llamanete de la funcion cargar para que cada vez que agregue un pokemon con el boton agregar se actualice directamente la pantalla y no hay que cerrar la app para ello.

                }
            }
            else
            {

                MessageBox.Show("No hay un Pokémon seleccionado. Selecciona uno o agrégalo a la lista.");
                return; // Sale del método para evitar errores
            } 
           
        }

                                                    

                                                      //EVENTO


        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar(); //Siempre que yo toque este boton el numero el idActivo en la tabla de la bd deberia ser false y enviarse por parametro 1 o ningun parametro.
        }   //LLAMANTE del metodo eliminar creado mas abajo.




                                                      //EVENTO
        

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true); //Siempre que yo toque este boton el numero el idActivo en la tabla de la bd deberia ser true por eso recibe parametro true (es decir seria 1 el numero enviado desde Activo.id) y enviarse por parametro 1.
            //LLAMANTE del metodo eliminar creado mas abajo
        }

        //Creo un metodo aqui mismo para acortar codigo y no hacer un eliminar logico y un eliminar fisico.Por ende de los 2 eventos borro todo y llamo a la funcion o metodo que creo mas abajo directamente y dependiendo de si le mando un parametro en false (num 1 o no envia parametro) o un true (numero 0) dependiendo de que boton toque obvio va a elegir eliminar fisico o logico.
        //OJO no confundir este metodo con el metodo eliminar que se crea en PokemonNeogcio que es el eliminarFIsico - Este eliminar toma true o false e implementa que eliminacion se realiza , por eso se le pasa este metodo a los eventos ya que este metodo adentro tiene la funcion eliminar logico y fisico.
        private void eliminar(bool logico = false) // Le paso un valor OPCIONAL por parametro, es decir que puedo no mandarle el parametro pero sino se lo mando se toma falso por defecto.
        {

            if (dgvPokemons.Rows.Count != 0 || dgvPokemons.CurrentRow != null)
            {
                PokemonNegocio negocio = new PokemonNegocio();
                Pokemon seleccionado;

                try
                {
                    DialogResult respuesta = MessageBox.Show("De verdad queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //El metodo show digamos que siemore devuelve un valor qu es un DIALOGRESULT este dato  no lo  manejamos o que esta oculto , en este caso nosotros decidimos guardarlo en una variable de tipo dialog result y le damos una respuesta por SI oNO .... Con esas respuestas SI o NO  evaluamos que hacer, si volver a la app si es NO o definitivamente eliminar si es un SI.
                    if (respuesta == DialogResult.Yes) // Si la variable respuesta es un SI se ejecuta y si es un NO no hace nada y por ende no lo elimina.
                    {
                        seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem; // Asi seleccionamos la fila o sea el pokemon a eliminar.


                        //Aqui hacemos una validacion para ver a cual de los "Eliminar" se elige

                        if (logico) //Si logico es true (si es =0)  entonces eliminamos logicamente pero si es false eliminamos fisicamente.
                        {
                            negocio.eliminarLogico(seleccionado.Id);  //eliminarLogico esta en pokemon negocio por eso creamos la variable negocio para poder usarlo
                                                                      //LOGICO = TRUE = ID 0

                        }
                        else
                        {

                            negocio.eliminar(seleccionado.Id); // Es llamante del metodo eliminar que seria eliminar fisico y que se crea en a; c;ase pokemonNegocio --  Instancio el objeto negocio de tipo elemento negocio para poder ejecutar el metodo eliminar que se encuentra hecgo en esa clase y le emvio por parametro el id del pokemon que seleccione en la grilla que es lo que necesita el metodo eliminar.
                                                               //FISICO = FALSE = ID 1 o parametro vacio.
                                                               //eliminar  esta en pokemon negocio por eso creamos la variable negocio para poder usarlo - NO CONFUNDIR CON EL METODO ELIMINAR CREADO MAS ARRIBA - ESTE ES OTRO METODO DE OTRA CLASE QUE ELIMINA DE LA BD FISICAMENTE.
                        }


                        //PESE A TODO ESTO AUN NO FUNCIONA ya que debemos ir a pokemonNegocio y agregar a la consulta que hacemos en el metodo listar , que tambien traiga los idActvo que son igual a 1 , es decir que no se eliminaron logicamente, si se eliminaron fisicamente desaparecen de la bd obvio.



                        cargar(); //Metodo que permite cargar de manera instantanea la grilla cuando eliminamos un pokemon o modificamos o agregamos.
                    }



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
            else
            {

                MessageBox.Show("Debes seleccionar un pokemon para eliminar.Si la lista esta vacia debes agregar uno previamente");
            }


              

        }



                                                        //EVENTO


        private void btnFiltro_Click(object sender, EventArgs e) //boton buscar DE LA BUSQUEDA AVANZADA.
        {
            //Cuando toco el boton buscar voy a capturar los campos de campo criterio y filtro que es un textBox.

            PokemonNegocio negocio = new PokemonNegocio(); //Instancio el objeto llamado negocio para poder usar el metodo que voy a crer que precisamente se va a crear en esa clase pokemonNeogcio y se llamara FILTRAR pasarle por parametros los valores capturados en los cboBox y caja de texto.

            try //Hacemos el manejo de excepciones y capturamos valores.
            {

                if (validarFiltro()) //si validar filtro es como en este caso true me valida ya que no hay campos seleccionados, me muestra el mensaje y abajo pongo el return hace que se corte la ejecucion del evento.
                    return;

                //else ...segui el programa

                // Pero si esta todo ok el programa sigue su curso y paso a capturar los valores de lo escrito por el usuario y a filtrar la lista con el metodo filtrar.

                string campo = cboCampo.SelectedItem.ToString(); // Guardo la seleccion del campo en una variable llamada campo.
                string criterio = cboCriterio.SelectedItem.ToString(); //Idem arriba
                string filtro = txtFiltroAvanzado.Text; //Asi capturo lo que escribi en la caja de texto llamada filtro.


                dgvPokemons.DataSource = negocio.filtrar(campo, criterio, filtro); //Esto se convierte en el llamante de la funcion filtrar que pasa por parametros los valores que carga el usuario y es una LISTAAAA
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }



                                                             

                                                              //EVENTO

        private void txtFiltro_TextChanged(object sender, EventArgs e)  // Esta logica la hago para que cada vez que tipeo en el campo de filtro me busque automaticamente y rapidamente los pokemon que su nombr o descripcion contenga lo que estoy tipenado letra a letra. PARTE DE LA BUSQYEDA RAPIDA.

        {
            List<Pokemon> listaFiltrada; // Creo una variable de tipo listPokemon llamada listaFiltrada , no instancio un objeto ya que la listaPokemon que cree en las lineas iniciales va ser la base para realizar el filtrado y esta listaPokemons es una variable que al ser de tipo list obviamente devuelve una lista que entonces yo guardo en esta variable de tipo list tambien.Si instancio un objeto seria lo mismo pero estaria haciendo algo de mas, es decir innecesario ya que la variable lista filtrada devuelve una lista como dije.
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 3) //Le digo que si el espacio del textbox que se llama filtro esta distinto de vacio, es decir con alguna letra , entonces me devuelva la lista filtrada.
            {                      //El filtro filtra a partir de 3 caracteres

                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToUpper().Contains(filtro.ToUpper()) || x.Tipo.Descripcion.ToUpper().Contains(filtro.ToUpper())); //Utilizo el metodo de busqueda findAll para buscar todos los elementos de la lista que cumplan la condicion que pongo en el parametro, en este caso que me de todos los pokemons que tengan los nombres de lo que el usuario coloca en la caja de texto llamada filtro.Recordar que listaPokemon siempre esta viva en esta clase al ser creada como un atributo de la clase en las lineas iniciales.Puedo tambien agregar otras condiciones con  un || o por ejem aplicando tmb un contains para ver si una cosa contiene a la otra sacando el igual.

            }
            else
            {

                listaFiltrada = listaPokemon; // De lo contrario si esta vacio o == vacio que me muestre la lista original que como dijimos es listaPokemon.
            }



            //Agrego la lista al DAtaSource , es decir la cargo en el datagridviewer o en la grilla mejor dicho.

            dgvPokemons.DataSource = null; // Primero Tengo que limpiar si o si la grilla.
            dgvPokemons.DataSource = listaFiltrada; // La nueva grilla ahora contiene los datos filtrados, ya sean los mismos de antes si listaFiltrada == listaPokemons o los filtrados.
            ocultarColumnas(); //Me oculta columnas de id y urlImagen
        }





                                                            //EVENTO


        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e) //PARA EL FILTRO AVANZADO - Carga los cbo de criterio depemdiemdo si tocas antes el cbo de numero o no.
        {

            string opcion = cboCampo.SelectedItem.ToString(); //Esto me guarda en la variable opcion el elemento seleccionado que puede ser nombre numero o texto.
            if (opcion == "Numero")
            {
                cboCriterio.Items.Clear(); //Debo borrar primero -- 

                // Si es un numero agrego en el desplegable las siguientes opciones: 

                cboCriterio.Items.Add("Mayor a ");
                cboCriterio.Items.Add("Menor a ");
                cboCriterio.Items.Add("Igual a ");
                //

            }
            else
            {
                //Si elegis algo que no sea un nro cargamos las siguientes opciones en el desplegable de criterio que depende del de campo.
                cboCriterio.Items.Clear(); //Debo borrar primero -- 
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");


                //IMPORTANTE
                //El paso siguiente es en el formulario cuando pulses el boton buscar que un metodo tome lo que esta elegido en los campos de campo y criterio y sumado a lo escrito por el usuario en el la caja de texto y haga la busqueda trayendo registros de la BD  - Esto se podria hacer tambien como hicimos antes teniendo en cuenta los registros que hay en la app sin ir a la base de datos, es decision mia.
                //Hago doble click en el boton buscar para configurar el evento y seguramente llamar al metodo que va a estar en la clase pokemonNegocio.


            }
        }



                                                          //EVENTO
        private void btnRecargarBusqueda_Click(object sender, EventArgs e)
        {
            inicializarFormulario(); //Cada vez que se recarga con el boton recargar se inicializa el form. 


        }







                                                         
        
        
        
        
                                                             // METODOS DE LA CLASE






        // METODO PARA VALIDAR CARGA DE DESPLEGABLES EN LA PANTALLA INICIAL DE LA APP

        private bool validarFiltro() //Contiene adentro la funcion soloNumeros.
            //SI en las validaciones algo es true se tira el mensaje correspondiente pero si esta todo ok se queda del laado del else que es falso y busca la info. 
        {
         
          
            if (cboCampo.SelectedIndex < 0)//Selected index me dice si tiene algo seleccionado o no , si es mayor que 0 tiene algo seleccionado
            {

                MessageBox.Show("Por favor seleccione el campo para filtrar");
                return true; //Corta el evento

            }

            if (cboCriterio.SelectedIndex < 0)
            {

                MessageBox.Show("Por favor seleccione el criterio para filtrar");
                return true;//Corta el evento

            }
            if (cboCampo.SelectedItem.ToString() == "Numero")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text)) //Si el campo esta nulo o vacio retorna true.
                {

                    MessageBox.Show("El filtro para numericos no puede estar vacio... Debes cargarlo");
                    return true;//Corta el evento
                }

                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Debes colocar solamente numeros para filtrar por campo numerico");
                    return true;//Corta el evento
                }

            }

           return false; // 


        }




                                                          //METODO

        //METODO QUE VALIDA QUE SI SELECCIONO CAMPO NUMERO Y ALGUN CRITERIO EN LA CAJA DE BUSCAR SOLO SE PUEDAN COLOCAR NUMEROS


        private  bool soloNumeros(string cadena) //La cadena es lo que yo pongo en la caja llamada buscar.
        {
            foreach (char caracter in cadena) //Recorro la cadena letra por letra y si hay un numero retorno true y sino hay un numero retorno false.
            {
                if (!(char.IsNumber(caracter)))
                {

                    return false;
                }

            }

            return true; 
        }


                                                                    //METODO
                                                            


          private void cargar() //Nuevo metodo que lista los pokemons y actualiza la pantalla, es decir que actualiza la grilla y lo muestra en pantalla.
        {

            try //Lo que tenia aca adentro que listaba los pokemons y los mostraba en la grilla cada vez que se actualizaba la pagina ahora lo voy a llevar auna funcion para reutlizarlo mas abajo para que cuando agregue un pokemon con el boton  agregar se actualice directamente. Asi tmb ahorro codigo.
            {

                PokemonNegocio negocio = new PokemonNegocio(); // Creo un objeto de tipo PokemonNegocio que se llama negocio. Lo hago para poder usar los metodo creados en esa clase como por ejm listar.
                listaPokemon = negocio.listar(); // Uso la variable creada mas arriba -  Ahora todos los pokemons estan en una variable de tipo listPokemons llamada listaPokemon. -Recordar que no puedo guardar una lista de pokemons en una variable que no sea de tipo listpokemon como esta. IMPORTANTE.
                dgvPokemons.DataSource = listaPokemon; // Le doy nacimiento a la grilla.
                ocultarColumnas(); //Cree el metodo mas abajo para poder reutlizarlo en otros eventos.

                if (listaPokemon.Count != 0) // SI la lista de pokemons no esta vacia o sea si en la grilla hay algo para mostrar entonces carga la imagen pero sino no hagas nada y mostra la grilla sin nada cargado - Con este if evitamos que la app se rompa al iniciar.
                {
                    cargarImagen(listaPokemon[0].UrlImagen); // Siempre carga la imagen del indice 0. LLAMANTE A LA FUNCION

                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }


                                                                //METODO

        private void ocultarColumnas() //Metodo para ocultar columnas de id y urlImagen.
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false; // Oculte la columna urlIMagen en del disenio de la app.  // cargarImagen(listaPokemon[0].UrlImagen) / Siempre carga la imagen del indice 0.
            dgvPokemons.Columns["Id"].Visible = false;

        }




                                                                 //METODO
        private void cargarImagen(string imagen) //Metodo para cargar la imagen de un pokemon cada vez que se hace un load , ya sea en la pantalla inicial cuando se abre inicalmente como en la linea 41 o como en la linea 57 cuando selecciono en la grilla el pokemon tmb aparece la imagen correspondiente.
        {

            try
            {
                pbxPokemon.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxPokemon.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }


















    }
}


