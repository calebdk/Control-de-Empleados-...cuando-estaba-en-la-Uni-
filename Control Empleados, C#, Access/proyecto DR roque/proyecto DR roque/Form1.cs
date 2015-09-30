using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb; //esta referencia es para poder conectar con la base de datos
using nmExcel = Microsoft.Office.Interop.Excel; //esta referencia es para poder crear el archivo de excell
using System.Net.Mail; // esta es la directiva que se utiliza para mandar email
using System.Net; // directiva para email
using System.IO;// adjuntar archivos mail




namespace proyecto_DR_roque
{
    public partial class main : Form
    {
        imprimir dgvlistaprinter;
     
         private bool adj = false;
            private string archivo;
    
        public main()
        {
            InitializeComponent();
        }

        void button1_Click(object sender, EventArgs e)
        {
            //boton dar de alta Empleados
            try
            {
                string nombre, departamento;
                int clave, salario;


                clave = int.Parse(txtclave.Text);
                salario = int.Parse(txtsalario.Text);


                nombre = txtnombre.Text;
                departamento = txtdepartamento.Text;



                string cc = "provider = Microsoft.Ace.Oledb.12.0; data source = " + Application.StartupPath + @"\proyectoroque1.accdb";


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
            catch(Exception)
            {

                MessageBox.Show("Debe de introducir datos de empleado", "Error");
            }
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

           string cc = "provider = Microsoft.Ace.Oledb.12.0; data source = " + Application.StartupPath + @"\proyectoroque1.accdb";
                        
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
            try
            {
                if (dgvlista.CurrentCell == null)
                {
                    MessageBox.Show("debe seleccionar un Empleado para borrar");
                    return;

                }

                string cc = "provider = Microsoft.Ace.Oledb.12.0; data source = " + Application.StartupPath + @"\proyectoroque1.accdb";

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
            catch {
                MessageBox.Show("Debe seleccionar un Empleado para borrar", "Error");
            }
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

        private void button9_Click(object sender, EventArgs e)
        {
            // este es el codigo para mandar correos electronicos
            try
            {
                MailMessage _correo = new MailMessage();
                _correo.From = new MailAddress(txtde.Text);

                _correo.To.Add(txtpara.Text);

                _correo.Subject = txtasunto.Text;
                _correo.Body = txtcontenido.Text;
                _correo.IsBodyHtml = false;
                _correo.Priority = MailPriority.Normal;


                if (adj == true)
                {
                    Attachment _attachement = new Attachment(@archivo);
                    _correo.Attachments.Add(_attachement);
                    adj = false;
                }



                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential(txtde.Text, txtcontraseña.Text);

                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;


                try
                {
                    smtp.Send(_correo);
                    MessageBox.Show("correo enviado");
                }

                catch
                {
                    MessageBox.Show("error al enviar el correo");

                }
                _correo.Dispose();
            }
            catch
            {
                MessageBox.Show("Deve tener datos de correo ingresados", "Error");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             adj = true;
            OpenFileDialog _file = new OpenFileDialog();
            _file.Title = "seleccione el archivo";
            _file.InitialDirectory = @"c:\";
            _file.Filter = "All files(*.*)|*.*";
            _file.FilterIndex = 1;
            _file.ShowDialog();
            archivo = _file.FileName;



        }

        private void Form1_Load(object sender, EventArgs e)
        {


            //conexion
            string cc = "provider = Microsoft.Ace.Oledb.12.0; data source = " +
                Application.StartupPath + @"\proyectoroque1.accdb";

            DataSet ds = new DataSet();

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM empleados", cc);

            try
            {
                da.Fill(ds, "dt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("A ocurrido un Error: " + ex.ToString(), Application.ProductName + " - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // administracion de los estilos del datagridview

            dgvlista.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 9, FontStyle.Bold, GraphicsUnit.Point);
            dgvlista.ColumnHeadersDefaultCellStyle.BackColor = SystemColors.ControlDark;
            dgvlista.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvlista.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvlista.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Regular, GraphicsUnit.Point);
            dgvlista.DefaultCellStyle.BackColor = Color.Empty;
            dgvlista.AlternatingRowsDefaultCellStyle.BackColor = SystemColors.ControlLight;
            dgvlista.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvlista.GridColor = SystemColors.ControlDarkDark;

            // generar el datagridcontrol

            dgvlista.DataSource = ds;
            dgvlista.DataMember = "dt";

            // camabir las columnas a la derecga          
           dgvlista.Columns[dgvlista.Columns.Count - 1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ajustar las columnas en el documento

           dgvlista.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);


        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (SetupThePrinting())
            {
                PrintPreviewDialog MyPrintPreviewDialog = new PrintPreviewDialog();
                MyPrintPreviewDialog.Document = mydocumento;
                MyPrintPreviewDialog.ShowDialog();
            }


        }

        private void button11_Click(object sender, EventArgs e)
        {

            //boton visualizar impresion
            if (SetupThePrinting())
                mydocumento.Print();

        }

        private void imprimir_PrintPage(object sender, PrintPageEventArgs e)
        {
            //boton mandar imprimir el datagridview
            bool more = dgvlistaprinter.DrawDataGridView(e.Graphics);
            if (more == true)
                e.HasMorePages = true;

        }
        private bool SetupThePrinting()

            //con este codigo generamos un documento virtual
        {
            PrintDialog MyPrintDialog = new PrintDialog();
            MyPrintDialog.AllowCurrentPage = false;
            MyPrintDialog.AllowPrintToFile = false;
            MyPrintDialog.AllowSelection = false;
            MyPrintDialog.AllowSomePages = false;
            MyPrintDialog.PrintToFile = false;
            MyPrintDialog.ShowHelp = false;
            MyPrintDialog.ShowNetwork = false;

            if (MyPrintDialog.ShowDialog() != DialogResult.OK)
                return false;

            mydocumento.DocumentName = "reporte de empleados";
            mydocumento.PrinterSettings = MyPrintDialog.PrinterSettings;
            mydocumento.DefaultPageSettings = MyPrintDialog.PrinterSettings.DefaultPageSettings;
            mydocumento.DefaultPageSettings.Margins = new Margins(40, 40, 40, 40);


            //codigo para imprimir o visualizar

            if (MessageBox.Show("quiere el reporte en el centro de la pagina?", "Administrador de pagina - centrado de pagina", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                dgvlistaprinter = new imprimir (dgvlista, mydocumento, true, true, "Empleados", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);
            else
                dgvlistaprinter = new imprimir (dgvlista, mydocumento, false, true, "Empleados", new Font("Tahoma", 18, FontStyle.Bold, GraphicsUnit.Point), Color.Black, true);

            return true;
        }
        

        

       


        
       

    }
}
    
    
    

  
    


       
    
    

