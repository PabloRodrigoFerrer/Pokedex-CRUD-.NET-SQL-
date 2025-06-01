using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace ADO_POKEMONS_EJEMPLO
{
    public partial class fmrPincipal : Form
    {
        private List<Pokemon> listaPokemon;

        public fmrPincipal()
        {
            InitializeComponent();
        }
               

        private void Form1_Load(object sender, EventArgs e)
        {

            cargar();
            cboCampoFiltro.Items.Add("Número");
            cboCampoFiltro.Items.Add("Nombre");
            cboCampoFiltro.Items.Add("Descripcion");          
        }
               

        private void cargar() 
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                listaPokemon = negocio.listar();
                dgvPokemons.DataSource = listaPokemon;
                ocultarCols();
                cargarImagen(listaPokemon[0].UrlImagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarCols() 
        {
            try
            {
                dgvPokemons.Columns["Id"].Visible = false;
                dgvPokemons.Columns["UrlImagen"].Visible = false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void dgvPokemons_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPokemons.CurrentRow != null)
            {
                Pokemon seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pbxPokemon.Load(imagen);
            } 
            catch (Exception ex)
            { 
                pbxPokemon.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }        
        
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
           frmNuevoPokemon alta = new frmNuevoPokemon();
            alta.ShowDialog();
            cargar();
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Pokemon seleccionado;
            if (dgvPokemons.CurrentRow != null)
            {
                seleccionado = dgvPokemons.CurrentRow.DataBoundItem as Pokemon;
                frmNuevoPokemon modificar = new frmNuevoPokemon(seleccionado);
                modificar.ShowDialog();
            }
            else
                MessageBox.Show("Debe seleccionar un registro para modificar");
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click_1(object sender, EventArgs e)
        {
            eliminar(true);
        }
      
        private void eliminar(bool logico = false) 
        {
            PokemonNegocio negocio = new PokemonNegocio();

            Pokemon seleccionado;
            seleccionado = (Pokemon)dgvPokemons.CurrentRow.DataBoundItem;

            try
            {
                if (logico == false)
                {
                    DialogResult respuesta = MessageBox.Show("¿Está seguro de eliminar PERMANENTEMENTE a: " + seleccionado.Nombre + "?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.Yes)
                        negocio.eliminarFisico(seleccionado.Id);
                }
                else if (logico)
                {
                    DialogResult respuesta = MessageBox.Show("¿Desea quitar a: " + seleccionado.Nombre + " de la lista?", "Quitar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (respuesta == DialogResult.Yes)
                        negocio.eliminarLogico(seleccionado.Id);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
            cargar();
        }

        private bool validarFiltro()
        {
            if (cboCampoFiltro.SelectedIndex < 0 || cboCriterioFiltro.SelectedIndex < 0)
            {
                MessageBox.Show("Debe completar todos los campos obligatorios.");
                return false;
            }

            if (!(soloNumero(txtFiltroAvanzado.Text)) && cboCampoFiltro.Text == "Número")
            {
                MessageBox.Show("Solo debe ingresar números si el campo es número.");
                return false; 
            }
            return true;
        }
        
        private bool soloNumero (string cadena) 
        {
           foreach (char caracter in cadena) 
            {
                if (!char.IsNumber(caracter))
                {
                    return false;
                }
            }
            return true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            try
            {
                //cancelar la ejecución del evento.
                if (!validarFiltro())
                    return;                

                string campo = cboCampoFiltro.SelectedItem.ToString();
                string criterio = cboCriterioFiltro.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;

                if (filtro != "")
                    dgvPokemons.DataSource = negocio.filtrar(campo, criterio, filtro);
                else
                    dgvPokemons.DataSource = listaPokemon;

                ocultarCols();
            }
            catch (Exception ex)
            {
                MessageBox.Show("try catch");
            }            
            
        }          
       
        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Pokemon> listaFiltada;
            string filtro = txtFiltro.Text;

            if (filtro.Length >= 2)
                listaFiltada = listaPokemon.FindAll(x => x.Nombre.ToLower().Contains(filtro.ToLower()) || x.Tipo.Descripcion.ToLower().Contains(filtro.ToLower()));
            else
                listaFiltada = listaPokemon;

            dgvPokemons.DataSource = null; 
            dgvPokemons.DataSource = listaFiltada;
            ocultarCols();            
        }

        private void cboCampoFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampoFiltro.SelectedItem.ToString();

            if (opcion == "Número") 
            {   
                cboCriterioFiltro.Items.Clear();
                cboCriterioFiltro.Items.Add("Mayor o igual que");
                cboCriterioFiltro.Items.Add("Menor o igual que");
                cboCriterioFiltro.Items.Add("Igual que");
            }
            else if (opcion == "Nombre" || opcion == "Descripción") 
            {
                cboCriterioFiltro.Items.Clear();
                cboCriterioFiltro.Items.Add("Empieza con");
                cboCriterioFiltro.Items.Add("Termina con");
                cboCriterioFiltro.Items.Add("Contiene");
            }                          
        }

    }
}
