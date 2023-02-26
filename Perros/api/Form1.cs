using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using dominio;
using negocio;

namespace api
{
    public partial class frmPokemons : Form
    {
        private List<Pokemon> listaPokemon;//CREO ESTA LISTA PARA PODER GUARDAR LOS DATOS DE LA BD
        public frmPokemons()
        {
            InitializeComponent();
        }

        private void frmPokemons_Load(object sender, EventArgs e)
        {
            cargar();
            cmbBoxCampo.Items.Add("Numero");
            cmbBoxCampo.Items.Add("Nombre");
            cmbBoxCampo.Items.Add("Descripcion");

        }

        private void cargar()//refresca la base de datos
        {

            try//lo ponemos aca porque sino salta como exepcion null
            {
                //enlasa el formulario con las clases que contienen la conexion a base de datos
                PokemonNegocio negocio = new PokemonNegocio();
                listaPokemon = negocio.listar();//guardo los datos que traigo en una lista
                dgvPokemons.DataSource = listaPokemon;
                ocultarColumnnas();
                cargarImagen(listaPokemon[0].UrlImagen);//MUESTRA LA IMAGEN DEL PRIMER ELEMENTO


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void ocultarColumnnas()
        {
            dgvPokemons.Columns["UrlImagen"].Visible = false;//no quiero mostrar la url, quiero que muestre la imagen
            dgvPokemons.Columns["Id"].Visible = false;
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)//PARA MOSTRAR LA IMAGEN DE LA FILA QUE ESTOY SELECCIONANDO
        {
            if (dgvPokemons.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;//CASTEO EXPLICITO PORQUE DEVUELVE UN OBJETO, PERO ESTAMOS DICIENDO QUE ES UN OBJETO POKEMON
                cargarImagen(seleccionado.UrlImagen);
            }
        }

        private void cargarImagen(string imagen)//funcion para cargar imagen
        {
            try
            {
                pbxPoxemon.Load(imagen);//si esta todo bien

            }
            catch (Exception ex)//si no tiene imaagen
            {

                pbxPoxemon.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)//conecta el formulario de nuevo pokemon con el boton agregar del formulario inicial
        {

            frmAltaPokemon alta = new frmAltaPokemon();
            alta.ShowDialog();//te atrapa en el formulario para que termines tu accion ahi, y no abras nuevamente el mismo formulario, "show" te permite abrir varios
            cargar();//refresca la base de datos para que el cambio se vea instantaneamente


        }

        private void dgvPokemons_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;//casteo implicito

            frmAltaPokemon modificar = new frmAltaPokemon(seleccionado);//frmAltaPokemon es una clase, para crrear el objeto de tipo modificar, estamos "instanciando"
            modificar.ShowDialog();//te atrapa en el formulario para que termines tu accion ahi, y no abras nuevamente el mismo formulario, "show" te permite abrir varios
            cargar();//refresca la base de datos para que el cambio se vea instantaneamente

        }

        private void btnEliminar_Click(object sender, EventArgs e)//lo elimina de la BD
        {
            eliminar();

        }

        private void btnEliminarLogica_Click(object sender, EventArgs e)//lo inactiva osea que no se ve pero sigue estando en la BD
        {
            eliminar(true);
        }
        private void eliminar(bool logico = false)//metodo privado para no repetir codigo
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Pokemon seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿De verdad queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                    if (logico)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminar(seleccionado.Id);

                    cargar();

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private bool validarFiltro()//validacion, para que no se aplique el filtro si estan vacios los campos
        {if(cmbBoxCampo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor; seleccione campo para filtrar...");
                return true;
            }  
        if(cmbBoxCriterio.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor; seleccione criterio para filtrar...");
                return true;
            }
            if (cmbBoxCampo.SelectedIndex.ToString() == "Número")//valida que no este nulo o vacio ni que tenga letras
            {
                if (string.IsNullOrEmpty(tctBoxFiltroAvanzado))
                {
                    MessageBox.Show("Debes cargar el filtro para numericos...");
                    return true;
                }
                if (!(soloNumeros(tctBoxFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Solo numeros para filtrar por campo numerico...");
                    return true;

                }
                
            }
            return false;
        }
        private bool soloNumeros(string cadena)//validacion para que solo entren numeros
        {
            foreach(char caracter in cadena)
            {
                if(!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }
        private void btnFiltro_Click(object sender, EventArgs e)//filtro rapido pero no tan rapido porque ahi que apretar en botton
        {
            /*List<Pokemon> listaFiltrada;
            string filtro = textBox1Filtro.Text;
            if( filtro != "")//carga la lista y el filtro esta vacio
            {
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower())|| x.Tipo.Descripcion.ToLower().Contains(filtro.ToLower()));//filtro doble
                //listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()));//busca si lo que se escribe esta contenido dentro del nombre de la BD
                //listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToLower() == filtro.ToLower());//metodo find , devuelve un objeto que encuentra segun el parametro, metodo findAll  trae toodos los objetos que tengan ese parametro, los parametros se llaman "landa" o landa exprecion, es como un ciclo for ich
                //toUpper o toLower son para que convierta todo en mayo¿uscula mo todo en minuscula y no sea tan engorroso escribir en el buscador
            }
            else
            {
                listaFiltrada = listaPokemon;
            }
            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumnnas();
            */
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if(validarFiltro())
                    return;
                string campo = cmbBoxCampo.SelectedItem.ToString();
                string criterio = cmbBoxCriterio.SelectedItem.ToString();
                string filtro = tctBoxFiltroAvanzado.Text;
                dgvPokemons.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        

        private void textBox1Filtro_TextChanged(object sender, EventArgs e)//filtro rapido rapido sin apretar click
        {
            List<Pokemon> listaFiltrada;
            string filtro = textBox1Filtro.Text;
            if (filtro.Length >= 3)//carga la lista a partir de los 3 caracteres
            {
                listaFiltrada = listaPokemon.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Tipo.Descripcion.ToLower().Contains(filtro.ToLower()));//filtro doble
                //toUpper o toLower son para que convierta todo en mayo¿uscula mo todo en minuscula y no sea tan engorroso escribir en el buscador
            }
            else
            {
                listaFiltrada = listaPokemon;
            }
            dgvPokemons.DataSource = null;
            dgvPokemons.DataSource = listaFiltrada;
            ocultarColumnnas();
        }

        private void cmbBoxCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cmbBoxCampo.SelectedItem.ToString();//guarda el elemento seleccionado
            if(opcion == "Numero")
            {
                cmbBoxCampo.Items.Clear();
                cmbBoxCampo.Items.Add("Mayor a");
                cmbBoxCampo.Items.Add("Menos a");
                cmbBoxCampo.Items.Add("Igual a");
            }
            else
            {
                cmbBoxCampo.Items.Clear();
                cmbBoxCampo.Items.Add("Comienza con");
                cmbBoxCampo.Items.Add("Termina con");
                cmbBoxCampo.Items.Add("Contiene");
            }


        }
    }
}
