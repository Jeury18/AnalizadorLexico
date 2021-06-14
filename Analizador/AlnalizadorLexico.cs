using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizador
{
    public partial class frmPrincipal : Form
    {
        List<char> numeros = new List<char>( new char[] { '0','1','2','3','4','5','6','7','8','9'});
        List<char> letras = new List<char>(new char[] { 'A', 'B', 'C','D','E','F','G','H','I','J','K','L','M','N','Ñ','O','P','Q','R','S','T','U','V','W','X','Y','Z'});
        List<char> tiposOperadores = new List<char>(new char[] { '+', '-', '*', '/', '%', '!', '>', '<', '=', '&', '|' });
        List<char> delimitadores = new List<char>(new char[] { '(', ')', '{', '}', '[', ']'});
        List<char> espacios = new List<char>(new char[] { ' ' });
        DataTable Resultado = new DataTable();

        public frmPrincipal()
        {
            InitializeComponent();
            
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
         Resultado.Columns.Add("Token", typeof(char));
         Resultado.Columns.Add("Tipo", typeof(string));
        }      

        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            Resultado.Clear();

            List<char> cadena = richExpresion.Text.Replace(" ","").ToCharArray().ToList();

            if (cadena.Count > 0 || cadena.Count.ToString() == "")
            {
                DataRow fila;

                foreach (char caracter in cadena)
                {
                    fila = Resultado.NewRow();

                    if (numeros.Contains(caracter))
                    {
                        fila["Token"] = caracter;
                        fila["Tipo"] = "Número";
                    }
                    else if (letras.Contains(caracter.ToString().ToUpper()[0]))
                    {
                        fila["Token"] = caracter;
                        fila["Tipo"] = "Variable";
                    }
                    else if (espacios.Contains(caracter.ToString().ToUpper()[0]))
                    {
                        fila["Token"] = caracter;
                        fila["Tipo"] = "Espacio";
                    }
                    else if (tiposOperadores.Contains(caracter))
                    {
                        fila["Token"] = caracter;
                        fila["Tipo"] = "Operador";
                    }
                    else if (delimitadores.Contains(caracter))
                    {
                        fila["Token"] = caracter;
                        fila["Tipo"] = "Delimitador";
                    }
                    else
                    {
                        fila["Token"] = caracter;
                        fila["Tipo"] = "Error";
                    }

                    Resultado.Rows.Add(fila);
                }

                Resultados.DataSource = Resultado;
                Resultados.Refresh();
            }
            else
            {
                Resultados.DataSource = null;
                Resultados.Refresh();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            richExpresion.Clear();
            Resultado.Clear();
            Resultados.DataSource = null;
            Resultados.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
