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
using YamlDotNet.Core;

namespace PokedexJesusPonce
{
    public partial class VentanaPrincipal : Form
    {

        Conexion miConexion = new Conexion();
        DataTable misPokemons = new DataTable();
        int idActual = 1;//guarda el id del pokemon que se esta viendo
        bool p = false;
        int i = 0;
        public VentanaPrincipal()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (idActual == 1)
            {
                idActual = 151;
            }
            else
            {
                idActual--;
            }
            muestraDatos();

        }
    
        private Image convierteBlobAImagen(byte[] img)
        {
            MemoryStream ms = new System.IO.MemoryStream(img);
            return (Image.FromStream(ms));
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (idActual == 151)
            {
                idActual = 1;
            }
            else
            {
                idActual++;
            }
            muestraDatos();
        }
        private void muestraDatos()
        {
            if (!p)
            {
                i = 0;
                misPokemons = miConexion.getPokemonPorId(idActual);
                nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
                label1.Text = misPokemons.Rows[0]["descripcion"].ToString();
                label2.Text = misPokemons.Rows[0]["posEvolucion"].ToString();
                label3.Text = misPokemons.Rows[0]["habitat"].ToString();
                label4.Text = misPokemons.Rows[0]["tipo1"].ToString();
                label5.Text = misPokemons.Rows[0]["tipo2"].ToString();
                pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            }
            else if (p)
            {
                 misPokemons = miConexion.getPokemonPorId(idActual);
                 nombrePokemon.Text = misPokemons.Rows[0]["nombre"].ToString();
                label1.Text = misPokemons.Rows[0]["descripcion"].ToString();
                label3.Text = misPokemons.Rows[0]["habitat"].ToString();
                label4.Text = misPokemons.Rows[0]["tipo1"].ToString();
                label5.Text = misPokemons.Rows[0]["tipo2"].ToString();
                label2.Text = misPokemons.Rows[0]["posEvolucion"].ToString();
                pictureBox1.Image = convierteBlobAImagen((byte[])misPokemons.Rows[0]["imagen"]);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                if (idActual < 151 && !p)
                {
                    idActual++;
                }
                else if (i < 0 && p)
                {
                    i++;
                    idActual = int.Parse(misPokemons.Rows[i]["id"].ToString());
                }
                muestraDatos();
            }
        }

        
    }
    }
    

