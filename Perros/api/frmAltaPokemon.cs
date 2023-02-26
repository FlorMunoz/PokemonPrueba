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
using dominio;
using negocio;
using System.Configuration;

namespace api
{
    public partial class frmAltaPokemon : Form
    {

        private Pokemon pokemon = null;//esto mas la de la linea 24 hasta 28 es para que se pacen los paramettros de una ventana a la otra
        private OpenFileDialog archivo = null;

        public frmAltaPokemon()
        {
            InitializeComponent();
        }

        public frmAltaPokemon(Pokemon pokemon)
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar Raza";
        }


        private void cargarImagen(string imagen)//funcion para cargar imagen
        {
            try
            {
                pbxUrlImagen.Load(imagen);//si esta todo bien

            }
            catch (Exception ex)//si no tiene imaagen
            {

                pbxUrlImagen.Load("https://t3.ftcdn.net/jpg/02/48/42/64/360_F_248426448_NVKLywWqArG2ADUxDq6QprtIzsF82dMF.jpg");
            }
        }

        private void frmAltaPokemon_Load_1(object sender, EventArgs e)//  muestra la lista desplegable
        {

            ElementoNegocio elementoNegocio = new ElementoNegocio();
            try
            {
                comboBox1Tipo.DataSource = elementoNegocio.listar();
                comboBox1Tipo.ValueMember = "Id";//es para precargar el desplegable, se genera una clave-value
                comboBox1Tipo.DisplayMember = "Descripcion";
                if(pokemon != null)//PRECARGA LOS DATOS DEL POKEMON
                {
                    textBox1Numero.Text = pokemon.Numero.ToString();
                    textBox2Nombre.Text = pokemon.Nombre;
                    textBox3.Text = pokemon.Descripcion;
                    textBox4.Text = pokemon.UrlImagen;
                    cargarImagen(pokemon.UrlImagen);
                    comboBox1Tipo.SelectedValue = pokemon.Tipo.Id;
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button1Aceptar_Click(object sender, EventArgs e)
        {
            
            PokemonNegocio negocio = new PokemonNegocio();

            try
            {//toma lo escrito en el formulario y lo convierte en objetos
                if(pokemon == null)
                    pokemon = new Pokemon();
                pokemon.Numero = int.Parse(textBox1Numero.Text);
                pokemon.Nombre = textBox2Nombre.Text;
                pokemon.Descripcion = textBox3.Text;
                pokemon.UrlImagen = textBox4.Text;
                pokemon.Tipo = (Elemento)comboBox1Tipo.SelectedItem;//casteo explicito para tome el valor como un objeto de tipo elemento

                if (pokemon.Id != 0)
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Modificado exitosamente");

                }
                else
                {
                    negocio.agregar(pokemon);
                    MessageBox.Show("Agregado exitosamente");//y si no lo es tira la exepcion
                }
                
                //guardo localmente la imagen si la levanto
                if( archivo != null && !(textBox4.Text.ToUpper().Contains("HTTP")))
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] + archivo.SafeFileName);//explicacion mas abajo en guardar imagen
                Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());//si salta un error lo muestra
            }

        }

        private void button2Cancelar_Click(object sender, EventArgs e)//para que el boton cierre el formulario
        {
            Close();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            cargarImagen(pbxUrlImagen.Text);
        }

        private void btnCargarImagen_Click(object sender, EventArgs e)//para cargar un archivo imagen o lo que sea
        {
            archivo = new OpenFileDialog();//genera ventana de dialogo para introducir archivo
            archivo.Filter = "jpg|*.jpg;|png|*.png";//filtro
            if(archivo.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = archivo.FileName;//guarda la ruta del archivo
                cargarImagen(archivo.FileName);//muestra la imagen
                //guardar imagen
               //File.Copy(archivo.FileName, ConfigurationManager.AppSettings["images-folder"] +  archivo.SafeFileName);//pide origen y destino, en este caso usamos una configuracion en App.config, poniendo una key y la direccion de la carpeta, despues se pone la Referencia como configuracion agregar, y se pone el using Sytem.configuration , para poder usar el ConfigurationManager.AppSettings con la key que elegimos

            }
        }
    }
}
//https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRV-mL3a52076N-0-7QPLTecAe5AiFDTzsXfQ&usqp=CAU