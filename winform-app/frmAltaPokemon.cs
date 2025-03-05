using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio; //Para crear el objeto pokemon tengo que poner esto, ya que la clase pokemon esta dentro de dominio.
using negocio;
using Negocio; //Importante para poder usar clases que estan dentro de negocio.
using System.Configuration;
using System.Diagnostics.Eventing.Reader; //Usado para poder usar configurationManagger.
using System.Text.RegularExpressions;

namespace winform_app
{
    public partial class frmAltaPokemon : Form
    {
        private Pokemon pokemon = null; //Creo esta variable de tipo pokemon cuando dupilico los constructores. Es un atributo de tipo pokemon llamado pokemon.
        private OpenFileDialog archivo = null; //Creo la property




        public frmAltaPokemon() //ES IMPORTANTE SABER QUE ESTE ES EL CONSTRUCTOR DE LA CLASE FRMALTAPOKEMON Y LO UNICO QUE HACE ES LLAMAR AL INITIALIZECOMPONENT.
        {
            InitializeComponent();
        }


        //Duplicando el constructor , necesario para modificar pokemons.
        //IMPORTANTE //La clave de duplicar los constructores en la clase frmAltaPokemon es que cuando tocas el boton agregar llama al constructor vacio de esa clase y cuando tocas modificar al pasarle este parametro vas si o si a llamar al constructor duplicado que es el que recibe un pokemon seleccionado.
        //Entonces SI TOCAS AGREGAR TU VARIABLE POKEMON CREADA MAS ARRIBA VA ESTAR NULA , TOCANDO MODIFICAR  SE VA A EJECUTAR EL SEGUNDO CONSTRUCTOR QUE RECIBE SI OSI UN PARAMETRO Y ESE PARAMETRO ES IGUAL A LA VARIABLE POKEMON , ENTONCES ESTA VARIABLE TIENE UN POKEMON CARGADO Y POR ENDE PARA MODIFICAR Y OBVIO NO ES MAS NULA. 


        public frmAltaPokemon(Pokemon pokemon) // Voy a duplicar el constructor para recibir  por parametro un pokemon para que en la clase frmPokemon se lo  envia hacia aqui  y que me permita modificar el pokemon en la lista. Cuando pase por aqui la variable pokemon dejara de estar nula y eso significa que el usuario toco modificar.
        {
            InitializeComponent();          //ESTO ES IMPORTANTE lo de arriba.
            this.pokemon = pokemon; // El pokemon gris es el de arriba y el celeste es el que se envia por parametro , es  vital saber que cuando en la app se toque el boton agregar el valor del pokemon sera null pero cuando se toque el modificar este construtor recibira por parametro un pokemon para modificar enviado desde el evento en la clase frmPokemon.
            Text = "Modificar Pokemon"; //Modifico el nombre del formulario de modificacion de pokemons.
        }



        //METODOS

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close(); // Para cancelar y cerrar la App
        }


        //METODO PARA VALIDAD CAJAS DE TEXTO CON NUMEROS O NO.
        private bool soloNumeros(string cadena) //La cadena es lo que yo pongo en la caja llamada buscar.
        {
            foreach (char caracter in cadena) //Recorro la cadena letra por letra y si hay un numero retorno true y sino hay un numero retorno false.
            {
                if (!(char.IsNumber (caracter)))
                {

                    return false;
                }

            }

            return true;
        }

        private bool contieneAlMenosUnaLetra(string input)
        {


            return Regex.IsMatch(input, @"[a-zA-Z]");

        }

        private bool validarCampos()
        {
            //Validar que los campos no sean nulos o esten vacios tanto de nombre como numero.
            if (string.IsNullOrWhiteSpace(txtNumero.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {

                MessageBox.Show("Los campos numero y/o descripcion no pueden estar vacios");
                return false;
            }

            //Validar que el campo numero solo tenga numeros

            if (!soloNumeros(txtNumero.Text))
            {

                MessageBox.Show("El campo numero solo puede contener valores numericos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            //Validar que el campo nombre no tenga solo numeros

            if (!contieneAlMenosUnaLetra(txtNombre.Text))
            {

                MessageBox.Show("El campo nombre no puede contener solo valores numericos o simbolos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             
                return false;
                
            }


            return true;


        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            
        //    Pokemon poke = new Pokemon();    //Estoy creando un nuevo pokemon llamado poke, de clase Pokemon ya que voy a crear un nuevo pokemon y por ende la clase pokemon tiene sus atributos que se deben completar.
  //IMP //    Comente la linea de arriba porque ya no necesito esa variable poke porque cree mas arriba la variable pokemon cuando duplique el constructor ESTO ES IMPORTANTE - Entonces reemplazo todos los poke Por pokemon.
           
            PokemonNegocio negocio = new PokemonNegocio(); // Creo este objeto llamado negocio de clase PokemonNegocio para poder usar los atributos de esa clase , mas bien para poder usar los metodos que esa clase me da y poder agregar a un pokemon a la lista, es decir poner en esta clase el metodo agregar y pasarle el poke que cree cuando toque el boton agregar y luego poder mostrar la lista con el metodo Listar.De lo contrario no se podria.

            try
            {

                //Debo capturar los datos de las cajas de texto (num desc nombre) y convertirlos en un objeto de tipo pokemon que tiene esos atributos de la clase pokemon obviamente.

                if(pokemon == null)
                {
                    pokemon = new Pokemon(); //Si el atributo de la clase que cree arriba de todo sigue nulo entonces esa variable la convierto en un objeto de tipo pokemon llamado pokemon y las props se cargan con lo que el usuario coloque en el form de alta del pokemon.

                }
                else
                {
                    //Sino esta nulo todos las propiedades que estan mas abjo se cargan automaticamente con las del pokemon que llega por parametro y que es el seleccionado para modificar. o pisar los datos del pokemon que tenes que modificar.
                }

                //Si el usuario toco  y el pokemon esta nulo quiere dcir que tocaste el boton agregar pokemon  un pokemon nuevo entonces generas ese pokemon en la linea de abajo  





                //Aqui cargo los datos del pokemon nuevo si toco agregar o cargo todos los datos del pokemon seleccionado si toco modificar (se pisan). Es importante saber que aqui si osi la variable pokemon deja de ser nula y se llena con un pokemon que se agrega o modifica.
                //Tambien debo previo a cargar el campo de la caja de texto numero hacer una validacion ya que esta va ser parseada y no puedo validar algo a lo que yo le aseguro como programador que va a tener una determianda variable, en este caso un int.
                //ES VITAL SABER QUE SI MODIFICAMOS TODOS ESTAS PROPIEDADES VAN A ESTAR YA LLENAS Y SI AGREGAMOS VAN A ESTAR VACIAS.


                //VALIDACION DE TODAS LAS CAJAS DE TEXTO CON FUNCION VALIDAR CAMPOS.


                if (!validarCampos())
                    return;
             //funcion que valida que las cajs de texto nombre y numero no sean vacias ni contengan caracteres invalidos.
             //Validar campo retorna false si algo no salio bien y no se valido correctamente por eso a la inversa retorna true si alho no salio bien , por eso aqui retorna true (return solo quiere decir true) y entonces corta el programa.Sino lo continua como si fuera un else.

                //CARGA DE TODOS LAS PROPIEDADES DE LA CLASE (SI SOLO CONTIENE NUMEROS SE CARGA LA PROPIEDAD POKEMON.NUMERO SINO MUESTRA EL EL MENSAJE DE ARRIBA AL TOCAR ACPETAR.)

                pokemon.Numero = int.Parse(txtNumero.Text); //Devuelve un string y la variable num es int , hay que parsearlo.
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.UrlImagen = txtUrlImagen.Text;

               
                
                //ATRIBUTOS DE LOS COMBOBOX - CARGA DE LOS MISMOS
                //Estos atributos se capturan del cboBox y son de tipo Elemento pero pertencen al pokemon que creo ya que la clase elemento esta dentro de clase pokemon.

                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;  //Al contrario de las anteriores propiedades(num, nom , desc) este devuelve un objeto  al querer capturar el item del combobox , por eso debo castearlo poniendo que se que es un objeto elemento que como sabemos esta dentro del objeto Pokemon. // Aqui tipo es una propiedad del elemento que es una clase que esta dentro de la clase pokemon.

                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem; //Lo mismo que en la linea de arriba.





                //DECISION FINAL ---- AGREGA O MODIFICA 
                //Ahora tengo que agregar o modificar y se tiene que ejecutar alguna de las 2 funciones, podriamos hacer un if y ver si la variable pokemon esta nula o no pero esto no es posible ya que sea que agregues o modifiques la variable pokemon ya no es mas null, o tiene un pokemon para modificar o tiene un nuevo pokemon para agregar por eso usamos el id y por eso lo agregamos a los atributos del metodo MODIFICAR creado en pokemonNeogcio.


                if (pokemon.Id != 0) //Se agrega en pokemonNegocio la propiedad id al metodo modificar para hacer esta validacion ya que con el null no se puede porque a esta altura del codigo ya la variable pokemon no sera nula y tendra adentro un pokemon ya sea para cargar o modificar.
                {                   // Si el id es diferente a 0 es porque hay que modificar Y SI ES CERO ES PORQUE NO HAY UN POKEMON (ya que no se puede tener id 0 entonces se agrega)

                    negocio.modificar(pokemon); //Le estoy mandando por parametro el pokemon que recibo en el constructor duplicado.
                    MessageBox.Show("Modificado Exitosamente");

                }

                else
                {

                    //Agrego pokemon con el objeto negocio creado en linea 32 y el metodo agregar creado en la clase POkemonNegocio pasandole como parametro el pokemon creado qeu seria el objeto.

                    negocio.agregar(pokemon); //Es el llamante de la funcion que pasa por parametro el objeto de tipo pokemon llamado poke (ahora se llama pokemon) que en la clase pokemon negocio se llamara nuevo. Ademas uso el metodo agregar y lo empleo en la variable negocio que es de tipo ElementoNegocio y asi agrego el pokemon - Para eso cree esa variable negocio precisamente.
                    //Este parametro que paso es el pokemon que creo en la linea 88 cuando esa misma variable seguia nula. No es el mismo pokemon que paso por parametro en la variable modificar.
                    MessageBox.Show("Agregado Exitosamente");

                   
                }




                //IMAGEN URL - DESCARGAR O NO A LA PC.

                //AQUI HAGO LA LOGICA DEL GUARDADO DE LAS IMAGENES EN LA CARPETA CREADA POR MI LOCALMENTE.
                //Aqui voy a guardar la imagen si la levanto localmente cuando toco el boton aceptar y no antes, si la img proviene de internet o no se agrega img o si la misma esta repetida enviara el texturl a la bd y se cargara el pokemon pero NO DESCARGARA LA IMG.

                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")) && File.Exists(txtUrlImagen.Text) == false) //La prop arranca nula porque cuando toque el boton + ya la variable archivo tendra cargada una img y dejara de ser null, entonces descarga el archivo en la pc. Ademas el archivo no tiene que tener http porque sino seria de la web, porl lo que no se tiene que descargar. - OJO poner http con mayuscula porque esta toupper en la validacion. Ademas le agregue el exits para ver si el archivo ya existe.
                {

                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName); //Vamos a copiar el archivo con una clase estatica llamada file , y en el segundas comillas le vamos a darl el destino pero no copiamos la ruta directamente ahi, sino que vamos a copiar la ruta de la carpeta creada por nosotros anteriormente y vamos a ir a app config dentro del proyrecyo winformapp de mi solucion y lo configuro.

                }
                
                
                Close(); //Cerramos la ventana.
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

       
        
        
        
        private void frmAltaPokemon_Load(object sender, EventArgs e) // Este metodo es el que carga la pantalla cuando se toca el boton agregegar, modificar, eliminar etc
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio(); //Creo un objeto de tipo elementoNegocio para poder usar el metodo listar de esa clase y que en el combobox me llegue la lista de elementos desde la bd.
            try
            {

                //Voy a PRECARGAR los combo box para cuando toque boton modificar ya aparezcan precargados - Tengo que poner esto : 
                cboTipo.DataSource = elementoNegocio.listar(); // Aqui  con el metodo listar que retorna una lista obtengo la lista de elementos. Recordar que en elemento.cs yo modifique el metodo toString para que solo me muestre la descripcion del elemento , ya que al ser una lista de objetos no sabe cual de las propiedades del mismo mostrar (en este caso id o descrpcion)

                cboTipo.ValueMember = "Id"; //El id queda oculto por atras.
                cboTipo.DisplayMember = "Descripcion"; //Entiendo que este item se va a mostrar precaegado cuando toque el boton. // Estos 2 items son las props de mi clase Elemento y si son mas de 2 props siempre pongo uan y una.

                //PrecRGO EL SIGUIENTE COMBOBOX

                cboDebilidad.DataSource = elementoNegocio.listar(); //Coloco 2 metodos lista para ir 2 veces a la bd ya que al ser cboboxs distintos pueden fallar si lo hago con una sola lista.
                cboDebilidad.ValueMember = "Id";    
                cboDebilidad.DisplayMember= "Descripcion";



                if (pokemon != null ) //SI TOCAS MODIFICAR ENTONCES POKEMON != NULL 
                {
                     //Si el pokemon cuando se toca el boton modificar es diferente a nulo (deberia ser asi siempre) entonces precargamos en la pantalla los datos del nuevo pokemon que nos llega por parametro y que pusimos thispokemon = pokemon.
                     // Cargamos los campos text y los campos combobox...

                    txtNumero.Text = pokemon.Numero.ToString(); // Convierte el num en string.
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagen.Text = pokemon.UrlImagen;  
                    cargarImagen(pokemon.UrlImagen);    //Cargamos la imagen apenas mostramos el menu para modificar (frmAltaPokemon)

                    //Si el pokemon es dierente a nulo cuando se toca modificar entonces debo precargar definitivamente los cbobox haciendo : 
                    
                    cboTipo.SelectedValue = pokemon.Tipo.id; //Aqui esta clave que esta oculta en este caso id.
                    cboDebilidad.SelectedValue = pokemon.Debilidad.id; //Nuevamente pongo el id ya que es la clase oculta y me mostrara su miembro que es la descripcion.

                    // MUYYYY IMPORTANTE MODIFICAR CONSULTA EN POKEMONNEGOCIO.

                    //Pese a hacer todo esto no va a funcionar ya que en el metodo listar(CREADO EN POKEMON NEGOCIO CLASS) que estoy usando en este caso para listar los elementos  no me trae el valor del id de cada elemento ya que si hago la consulta que tengo en el metodo listar veremos que no devuelve la columna del id de elelento sino la columna llamada tipo y debilidad.
                    //Por ende hay que modiifcar la consulta para que me traiga tambien la columna de id con estas columnas agregadas Y TENIENDO ESTE ID PUEDO PRECARGAR LOS COMBOBOX CUANDO SE TOQUE MODIFICAR. SINO MODIFICO LA CONSULTA NUNCA PODRE TENER EL ID ENTONCES NO PRECARGARELOS COMBOBOX CUANDO SE TOCA MODIFICAR.
                    //Luego ademas de cambiar la consulta debo modificar lo que se va ver en la tabla en la clase PokemonNegocio, es decir agrego la columna IDtipo y IdDebilidad que inclui en la consulta asi el lector los lee.
                    

;
                }


            } 
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());   //No lanza la excepcion sino que muestra un msj determinado.
            }
        }


        private void txtUrlImagen_Leave(object sender, EventArgs e) //Evento para cuando tabeas el campo urlImagen aparezca la imagen del pokemon en el pictureBox.
        {
            cargarImagen(txtUrlImagen.Text);
        }



        private void cargarImagen(string imagen) //Metodo para cargar la imagen de un pokemon cada vez que se hace un load , ya sea en la pantalla inicial cuando se abre inicalmente como en la linea 41 o como en la linea 57 cuando selecciono en la grilla el pokemon tmb aparece la imagen correspondiente. Esta iniciado 2 veces en las 2 clases de disenio.
        {

            try
            {
                pbxPokemon.Load(imagen); // ojo que el picturebox de frmAltaPokemon se llama pbxPokemon y el de frmPokemon se llama pbPokemon en sus propiedades de disenio.
            }
            catch (Exception ex)
            {
                pbxPokemon.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e) //Con este boton + vamos a poner una imagen que vamos a tener en una carpeta en la pc y enviaremos a la bd la ruta de acceso a ella como un string.
        {
            archivo = new OpenFileDialog();  // Ya cree como property privada la variable de tipo openFildeDialog en las primeras lineas y voy al evento del boton aceptar para agregar un pokemon.
            archivo.Filter = "jpg|* .jpg;|png|*.png"; //Va a crear una ventana donde se agregaran diferentes archivos, por ejm jpg en este caso. - Filtrar que archivos me permite elegir el cuadro de dialogo.

            if (archivo.ShowDialog() == DialogResult.OK)  //Esta ventna me permite captrurar un archivo si esta todo ok. Habria que ver si pongo un archivo que es incorrecto qeu excepcion tira o si se rompe.
            { 
                txtUrlImagen.Text= archivo.FileName;    //Esto me guarda la ruta que coloque el la caja de texto urlImagen en un string.Es decir que le da nombre al archivo y la ruta.
                cargarImagen(archivo.FileName); // El metodo cargar imagen renderiza una imagen en el picturebox de al lado de la grilla, donde se muestran los pokenons, a este metodo se le pasa un stringo por parametro que es el nombre del archivo mas la ruta que esta todo en archivo.filename. -- LLAMANTE DE LA FUNCION.

                
                
                
                
                //Guadar la imagen en una carpeta de la pc

                
                //Para poder leer el archivo que colocamos en el app config hay que ir a referencias y darle a agregar referencia  y darle a asemmblies y agrergar la assemblie system.configuratuion t despeus en los using de esta clase incluirlo.
                //La finalidad es que todo archivo qeu nosotros seleccionemos se guarde en la carpeta de poke-app.
                //Pero yo quiero guardar la imagen cuando toque el boton aceptar y realmente guarde el pokemon, por eso voy a comentar el codigo de fileCopy de mas arriba.
                
                
                //Yo quiero que la img quede guardada y que a la bd vaya solo el string con la ruta de la img , ahora la guarda aunque no haya tocado aceptar para guardar el pokemon y eso esta mal. .Nuestra app tiene que mostrar la img ya sea venga de la nube o la tengamos en la pc localmente.

                //Para lograr esto hago: 


            }

        }





      

       



    }

      

}