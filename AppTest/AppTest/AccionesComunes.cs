using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace AppTest
{
    class AccionesComunes
    {
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "¡ ¡ AVISO ! !", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void LlenarCombo(string consulta, ComboBox combo, string Id, string Nombre)
        {
            /*
             for (int i = 0; i < dt.Rows.Count; i++)
             {
                 combo.Items.Add(dt.Rows[i].ItemArray[0].ToString());
             }*/
            combo.ValueMember = Id;
            combo.DisplayMember = Nombre;
            DataTable dt=new DataTable();


            //TAREA
            //Agregar metodo estatico a la clase previamente creada que permita agregar 
            //un elemento TODOS con id 0 a cualquier combo y mostrar funcionamiento en 
            //formulario existente

            dt = Conexion.EjecutaSeleccion(consulta);
            dt.Rows.Add(0, "Todos");
            DataView data = new DataView(dt);
            data.Sort = "Id ASC";
            dt = data.ToTable();


            if (dt == null)
            {
                return;
            }
            //combo.Items.Clear();
            combo.DataSource = dt;
        }
        
        public static void LlenarDataGrid (string consulta, DataGridView data)
        { 
            DataTable dt = new DataTable();
            dt = Conexion.EjecutaSeleccion (consulta);
            data.DataSource = dt;
        }
       
        public static void LlenarList(string consulta, ListView list)
        {
            DataTable dt = new DataTable();
            dt = Conexion.EjecutaSeleccion(consulta);
            ListViewItem lista = new ListViewItem();

            for (int d=0; d< dt.Columns.Count; d++)
            {
                list.Columns.Add(dt.Columns[d].ColumnName);
            }

            for (int i=0; i < dt.Rows.Count; i++)
            {
                for (int j=0; j < dt.Columns.Count; j++)
                {
                    if (j == 0)
                    {
                    lista = list.Items.Add(dt.Rows[i][j].ToString());
                    }
                    else
                    {
                        lista.SubItems.Add(dt.Rows[i][j].ToString());
                    }

                }
                
            }

        }
    }
}
