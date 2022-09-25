using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  int registros = 0;
            // Conexion.EjecutaConsulta(textBox1.Text);
            // AccionesComunes.Mensaje(""+registros);
            AccionesComunes.LlenarCombo(textBox1.Text,comboBox1, "Id","Nombre");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
              AccionesComunes.LlenarDataGrid(textBox1.Text, dataGridView1);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AccionesComunes.LlenarList(textBox1.Text, listView1);
        }
    }
}
