using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; //esta referencia es para poder conectar con la base de datos
using nmExcel = Microsoft.Office.Interop.Excel; //esta referencia es para poder crear el archivo de excell
using System.Net.Mail; // esta es la directiva que se utiliza para mandar email
using System.Net; 

namespace proyecto_DR_roque
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            //boton dar de alta Empleados
            string nombre, departamento;
            int clave, salario;


            clave = int.Parse(txtclave.Text);
            salario = int.Parse(txtsalario.Text);


            nombre = txtnombre.Text;
            departamento = txtdepartamento.Text;


            string cc = @"provider=Microsoft.Ace.Oledb.12.0; " + @"data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb";

            OleDbConnection cn = new OleDbConnection(cc);
            cn.Open();

            string consulta = string.Format("INSERT INTO empleados " +
                                            "(clave, nombre, departamento, salario) " +
                                            " VALUES ( {0}, '{1}' , '{2}', {3})",
                                            clave, nombre, departamento, salario);

            OleDbCommand comando = new OleDbCommand(consulta, cn);
            comando.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show(" los datos de los Empleados han sido guardados ");
            txtclave.Clear();
            txtnombre.Clear();
            txtdepartamento.Clear();
            txtsalario.Clear();

            txtclave.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {


            //boton para mandar a excel
            nmExcel.Application ExcelApp = new nmExcel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);
            ExcelApp.Columns.ColumnWidth = 12;
            for (int i = 0; i < dgvlista.Rows.Count; i++)
            {
                DataGridViewRow Fila = dgvlista.Rows[i];
                for (int j = 0; j < Fila.Cells.Count; j++)
                {
                    ExcelApp.Cells[i + 1, j + 1] = Fila.Cells[j].Value;
                }
            }


            // ---------- cuadro de dialogo para Guardar

            SaveFileDialog CuadroDialogo = new SaveFileDialog();
            CuadroDialogo.DefaultExt = "xls";
            CuadroDialogo.Filter = "xls file(*.xls)|*.xls";
            CuadroDialogo.AddExtension = true;
            CuadroDialogo.RestoreDirectory = true;
            CuadroDialogo.Title = "Guardar";
            CuadroDialogo.InitialDirectory = @"c:\";
            if (CuadroDialogo.ShowDialog() == DialogResult.OK)
            {
                ExcelApp.ActiveWorkbook.SaveCopyAs(CuadroDialogo.FileName);
                ExcelApp.ActiveWorkbook.Saved = true;
                CuadroDialogo.Dispose();
                CuadroDialogo = null;
                ExcelApp.Quit();
            }
            else
            {
                MessageBox.Show("No se pudo guardar Datos .. ");
            }

        }



        private void button3_Click(object sender, EventArgs e)
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
                dgvlista.DataSource = dt;
                dgvlista.AutoResizeColumns();
            }

            else
            { //no hay empleados para mostrar
                MessageBox.Show("no hay empleados para mostrar");
            }
            //cerrar la conexion
            cn.Close();


        }



        private void button6_Click(object sender, EventArgs e)
        {
            //boton limpiar 
            dgvlista.DataSource = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //boton de salir
            DialogResult r;
            r = MessageBox.Show("seguro que quiere salirse del sistema ?",
                                 "confirmacion de salida",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                MessageBox.Show("gracias por usar el sistema ", "Adios");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("permanece en el sistema");
            }
        }



        private void button8_Click_1(object sender, EventArgs e)
        {
            // boton eliminar
            if (dgvlista.CurrentCell == null)
            {
                MessageBox.Show("debe seleccionar un Empleado para borrar");
                return;

            }

            string cc = @"Provider=Microsoft.Ace.Oledb.12.0;" +
                    @"Data source = C:\Users\calebDK\Desktop\proyectoroque1.accdb";

            OleDbConnection cn = new OleDbConnection(cc);
            cn.Open();
            int renglon = dgvlista.CurrentCell.RowIndex;
            int id = (int)dgvlista[0, renglon].Value;

            string sql = "DELETE FROM EMPLEADOS WHERE id = " + id;
            OleDbCommand comando = new OleDbCommand(sql, cn);
            comando.ExecuteNonQuery();


            MessageBox.Show("borrado exitosamente", "Exito");
            dgvlista.DataSource = null;
            cn.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //ir a la ventana 2
            this.Hide();
            Form2 ventana2 = new Form2();

            ventana2.ShowDialog();
            this.Show();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //boton limpiar 
            dgvlista.DataSource = null; 
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            
           


        }

        private void button9_Click(object sender, EventArgs e)
        {
            MailMessage _correo = new MailMessage();
            _correo.From = new MailAddress(txtenviador.Text);

            _correo.To.Add(txtpara.Text);
            _correo.Subject=txtasunto.Text;
            _correo.Body = txtcontenido.Text;
            _correo.IsBodyHtml = false;

            _correo.Priority = MailPriority.Normal;


            SmtpClient smtp = new SmtpClient();

            smtp.Credentials = new NetworkCredential(txtenviador.Text, txtcontrasena.Text);

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(_correo);
                MessageBox.Show("correo enviado", "enviado");
            }
            catch
            {
                MessageBox.Show("no se pudo enviar el correo", "error");

            }
            _correo.Dispose();


        }

       

    }
}
    
    
    

  
    


       
    
    

