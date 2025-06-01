using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Dominio;
using System.Data.Odbc;
using System.Configuration;
using System.IO;


namespace ADO_POKEMONS_EJEMPLO
{
    public partial class frmNuevoPokemon : Form
    {
        Pokemon pokemon = null;
        OpenFileDialog archivo = null;
        
        public frmNuevoPokemon()
        {
            InitializeComponent();
        }

        public frmNuevoPokemon(Pokemon pokemon) 
        {
            InitializeComponent();
            this.pokemon = pokemon;
            Text = "Modificar pokemon";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                if (pokemon == null)
                    pokemon = new Pokemon();

                pokemon.Numero = int.Parse(txtNumero.Text);
                pokemon.Nombre = txtNombre.Text;
                pokemon.Descripcion = txtDescripcion.Text;
                pokemon.Tipo = (Elemento)cboTipo.SelectedItem;
                pokemon.Debilidad = (Elemento)cboDebilidad.SelectedItem;
                pokemon.UrlImagen = txtUrlImagenAlta.Text;


                if (pokemon.Id == 0)
                { 
                    negocio.agregar(pokemon);
                    MessageBox.Show("Pokemon agregado correctamente.");
                }
                else
                {
                    negocio.modificar(pokemon);
                    MessageBox.Show("Pokemon modificado correctamente");
                }

                if (archivo != null && !(txtUrlImagenAlta.Text.ToLower().Contains("htpp")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["PokeApp"] + archivo.SafeFileName);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }         
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void frmNuevoPokemon_Load(object sender, EventArgs e)
        {
            ElementoNegocio elementoNegocio = new ElementoNegocio();
            
            try
            {                
                cboTipo.DataSource = elementoNegocio.listar();
                cboTipo.ValueMember = "Id";
                cboTipo.DisplayMember = "Descripcion";
                cboDebilidad.DataSource = elementoNegocio.listar();
                cboDebilidad.ValueMember = "Id";
                cboDebilidad.DisplayMember = "Descripcion";
                

                if (pokemon != null) 
                {
                    txtNumero.Text = pokemon.Numero.ToString();
                    txtNombre.Text = pokemon.Nombre;
                    txtDescripcion.Text = pokemon.Descripcion;
                    txtUrlImagenAlta.Text = pokemon.UrlImagen;
                    cboTipo.SelectedValue = pokemon.Tipo.Id;
                    cboDebilidad.SelectedValue = pokemon.Debilidad.Id;

                    cargarImagen(pokemon.UrlImagen);
                }
                    
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
           
        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagenAlta.Text);  
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAlta.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxAlta.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }

        }

        private void btnAgregarImagenLocal_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "Jpg Image|*.jpg";

            if (archivo.ShowDialog() == DialogResult.OK) 
            {
                txtUrlImagenAlta.Text = archivo.FileName;
                cargarImagen(archivo.FileName);        
            }           

        }
    }   
}
            
            


       
