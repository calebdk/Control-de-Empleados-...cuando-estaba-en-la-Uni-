using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace proyecto_DR_roque
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {




            this.Close();
            Form2 ventana2 = new Form2();

            ventana2.ShowDialog();
          

           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 ventana1 = new Form1();

            ventana1.ShowDialog();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cc = @"provider=Microsoft.Ace.Oledb.12.0; " + @"data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb";

            OleDbConnection cn = new OleDbConnection(cc);
            cn.Open();

            if (rbtmostrar.Checked)
            {
                DataTable tabla;
                OleDbDataAdapter datosAdapter;
              OleDbCommand comandoSQL;

                try
                {
                    tabla = new DataTable();

                    datosAdapter = new OleDbDataAdapter(txtsql.Text, cc);
                    comandoSQL = new OleDbCommand ();

                    datosAdapter.Fill(tabla);

                    dgvlista3.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al mostrar los datos de la tabla [" +
                        "] de MySQL: " + 
                        ex.Message, "Error ejecutar SQL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (rbtconsulta.Checked)
            {
                try
                {
                    int numeroRegistrosAfectados = 0;

               OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = txtsql.Text;
                    cmd.Prepare();                
                    numeroRegistrosAfectados = cmd.ExecuteNonQuery();
                    MessageBox.Show("Consulta de modificación de datos " +
                        "ejecutada, número de registros afectados: " +
                        Convert.ToString(numeroRegistrosAfectados) + ".", 
                        "Consulta SQL ejecutada correctamente",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error ejecutar consulta de " +
                        "modificación de datos: " +
                        ex.Message, "Error ejecutar SQL",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton limpiar 
            dgvlista3.DataSource = null; 
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

       
        }
    }

