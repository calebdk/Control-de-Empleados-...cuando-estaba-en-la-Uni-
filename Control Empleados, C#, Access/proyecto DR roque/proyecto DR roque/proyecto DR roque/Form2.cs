using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using nmExcel = Microsoft.Office.Interop.Excel;




namespace proyecto_DR_roque
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            // AL cargar la forma

            string cc = "provider=Microsoft.Ace.oledb.12.0;" +
                        @" data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb";


            string consulta = "SELECT * FROM EMPLEADOS ORDER BY id";
            OleDbDataAdapter da = new OleDbDataAdapter(consulta, cc);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbempleado.DataSource = dt;
            cmbempleado.DisplayMember = "nombre";
            cmbempleado.ValueMember = "id";
            cmbempleado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbempleado.SelectedIndex = -1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //boton buscar
            string cc = @"Provider=Microsoft.Ace.Oledb.12.0;" +
                       @"Data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb";
            OleDbConnection cn = new OleDbConnection(cc);
            cn.Open();

            //configurar la consulta sql
            string consulta = txtbuscar.Text.Replace("*", "%");
            string sql = string.Format("select * from empleados where nombre like '{0}'", consulta);


            OleDbCommand comando = new OleDbCommand(sql, cn);

            //ejecutando la consulta en la bd y atrapando el resultado en dr

            OleDbDataReader dr = comando.ExecuteReader();




            //revisar si hay registros para mostrar

            if (dr.HasRows == true)
            { //si hay datos para mostrar
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvlista2.DataSource = dt;
                dgvlista2.AutoResizeColumns();
            }
            else
            { //no hay datos para mostrar
                MessageBox.Show("no hay Empleados para mostrar");
            }
            //cerrar la conexion
            cn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //boton listar
            string cc = @"Provider=Microsoft.Ace.Oledb.12.0;" +
                       @"Data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb";
            OleDbConnection cn = new OleDbConnection(cc);
            cn.Open();

            //configurar la consulta sql
            string comando = "select * from empleados Order by id";
            OleDbCommand com = new OleDbCommand(comando, cn);
            //ejecutando la consulta en la bd y atrapando el resultado en dr
            OleDbDataReader dr = com.ExecuteReader();
            //revisar si hay registros para mostrar
            if (dr.HasRows == true)
            { //si hay datos para mostrar
                DataTable dt = new DataTable();
                dt.Load(dr);
                dgvlista2.DataSource = dt;
                dgvlista2.AutoResizeColumns();
            }
            else
            { //no hay empleados para mostrar
                MessageBox.Show("no hay empleados para mostrar");
            }
            //cerrar la conexion
            cn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //boton limpiar 
            dgvlista2.DataSource = null; 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 ventana1 = new Form1();

            ventana1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Comenzar Modificaciones

            if (cmbempleado.SelectedIndex == -1)
            {

                MessageBox.Show(" Debe seleccionar un empleado");
                return;

            }

            groupBox1.Enabled = false;
            groupBox2.Enabled = true;

            OleDbConnection conexion = new OleDbConnection();
            conexion.ConnectionString = "provider=MICROSOFT.ACE.OLEDB.12.0;" +
                                         @" data source=  C:\Users\calebDK\Desktop\proyectoroque1.accdb";

            conexion.Open();

            string consulta;
            consulta = "SELECT * FROM empleados WHERE id = " +
                       cmbempleado.SelectedValue;

            OleDbCommand comando = new OleDbCommand(consulta, conexion);

            OleDbDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                txtclave1.Text = lector["clave"].ToString();
                txtnombre1.Text = lector["nombre"].ToString();
                txtdepartamento1.Text = lector["departamento"].ToString();
                txtsalario1.Text = lector["salario"].ToString();


            }

            else
            {

                MessageBox.Show("No hay datos para ese empleado");

            }



        }

        private void button6_Click(object sender, EventArgs e)
        {

            //boton guardar cambios
            OleDbConnection conexion = new OleDbConnection();
            conexion.ConnectionString = "provider=MICROSOFT.ACE.OLEDB.12.0;" +
                @"data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb"; 
            conexion.Open();

            string consulta = string.Format("UPDATE empleados set clave = {0} , nombre = '{1}' , departamento ='{2}' , salario = {3}   WHERE id = {4}", txtclave1.Text, txtnombre1.Text, txtdepartamento1.Text, txtsalario1.Text, cmbempleado.SelectedValue);
            OleDbCommand comando = new OleDbCommand(consulta, conexion);
            comando.ExecuteNonQuery();
            MessageBox.Show("Los datos del Empleado fueron actualizados ");
            conexion.Close();

            btncancelar_Click(null, null);
            Form2_Load(null, null);
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ventana3 = new Form3();

            ventana3.ShowDialog();
            this.Show();
        }

        private void cmbempleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
    }
}
