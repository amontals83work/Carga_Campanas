using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;

namespace EjemploCarga_Csharp
{
    public partial class Form1 : Form
    {
        ConexionDB conn = new ConexionDB();
        MCCommand mcComm = new MCCommand();
        private OpenFileDialog openFileDialog;
        int count = 0;
        

        public Form1()
        {
            InitializeComponent();
            openFileDialog = new OpenFileDialog();
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboCartera.DataSource = conn.Select("SELECT idCliente, Descripcion FROM clientes WHERE idcliente IN (41, 81, 83, 84, 85, 86, 87, 88, 89) ORDER BY Nombre");
            cboCartera.DisplayMember = "Descripcion";
            cboCartera.ValueMember = "idCliente";
        }

        private void btnFichero_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFichero.Text = openFileDialog.FileName;
            }
            else
            {
                MessageBox.Show("Debe seleccionar un fichero para cargar los expedientes");
                return;
            }
        }

        private void cboCartera_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!Convert.IsDBNull(cboCartera.SelectedValue))
            {
                cboCampaña.DataSource = conn.Select("SELECT id, NombreInterno FROM CampanasLlamadas WHERE Vigente=1 AND IdCliente=" + cboCartera.SelectedValue.ToString() + " AND ficherocarga=1");
                cboCampaña.DisplayMember = "NombreInterno";
                cboCampaña.ValueMember = "Id";
            }
            else
            {
                cboCampaña.DataSource = null;
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            CargarLista(Convert.ToInt32(cboCampaña.SelectedValue));
        }

        private void CargarLista(int id)
        {
             string hoja = nHoja();

            OleDbConnection oleConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFichero.Text.Trim() + ";Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1';");
            OleDbDataAdapter oleAdapter = new OleDbDataAdapter("SELECT * FROM [" + hoja + "$]", oleConnection);

            DataSet ds = new DataSet();
            oleAdapter.Fill(ds);
            oleConnection.Close();

            DataTable dt = ds.Tables[0];
            ConexionDB.AbrirConexion();

            string tabla = "";
            string campo = "";

            switch (id)
            {
                case 4023://AXACAMPANACOMODIN
                    {
                        tabla = "AXACAMPANACOMODIN";
                        campo = "Idclienteald";
                        Inserciones_AXACTOR(dt, tabla, campo);
                        break;
                    }
                case 4067://AXACAMPANACOMODIN2
                    {
                        tabla = "AXACAMPANACOMODIN2";
                        campo = "Idclienteald";
                        Inserciones_AXACTOR(dt, tabla, campo);
                        break;
                    }
                case 4107://AXACAMPANACONTACTO
                    {
                        tabla = "AXACAMPANACONTACTO";
                        campo = "Idclienteald";
                        Inserciones_AXACTOR(dt, tabla, campo);
                        break;
                    }
                case 4051://TEIDECAMPANACOMODIN -
                    {
                        tabla = "TEIDECAMPANACOMODIN";
                        campo = "ref";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4066://TDXCAMPANACOMODIN
                    {
                        tabla = "TDXCAMPANACOMODIN"; 
                        campo = "idexpediente";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4075://BENKICAMPANACOMODIN -
                    {
                        tabla = "BENKICAMPANACOMODIN";
                        campo = "EXPEDIENTE";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4083://TEIDECAMPANASINAP -
                    {
                        tabla = "TEIDECAMPANASINAP";
                        campo = "ref";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4095://CRISALIDACAMPANACOMODIN -
                    {
                        tabla = "CRISALIDACAMPANACOMODIN"; 
                        campo = "EXPEDIENTE";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4096://FINTYACAMPANACOMODIN -
                    {
                        tabla = "FINTYACAMPANACOMODIN";
                        campo = "REFERENCIA";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4103://ARBORKNOTGLOBALIN - 
                    {
                        tabla = "ARBORKNOTGLOBALIN";
                        campo = "EXPEDIENTE";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4105://NASSAUCAMPANACOMODIN
                    {
                        tabla = "NASSAUCAMPANACOMODIN";
                        campo = "CONTRATO";
                        Inserciones_NASSAU(dt, tabla, campo);
                        break;
                    }
                case 4114://teidecampanasinap_1 - 
                    {
                        tabla = "teidecampanasinap_1";
                        campo = "ref";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4115://teidecampanasinap_2 - 
                    {
                        tabla = "teidecampanasinap_2";
                        campo = "ref";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                case 4128://PagantisCampanaComodin
                    {
                        tabla = "PagantisCampanaComodin";
                        campo = "IdExpediente";
                        Inserciones_ARBORKNOT_TDX(dt, tabla, campo);
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Campaña no contemplada");
                        break;
                    }
            }
            ConexionDB.CerrarConexion();
        }

        private void Inserciones_ARBORKNOT_TDX(DataTable dt,  string tabla, string campo)
        {
            BorrarRegistrosAntiguos(tabla);

            foreach (DataRow fila in dt.Rows)
            {
                string expediente = "";

                if (dt.Columns.Contains("Expediente")) expediente = fila["Expediente"].ToString();
                else if (dt.Columns.Contains("REFCLIENTE")) expediente = fila["REFCLIENTE"].ToString();            

                if (!string.IsNullOrEmpty(expediente))
                {
                    if (dt.Columns.Contains("Expediente")) mcComm.CommandText = "SELECT idExpediente FROM Expedientes WHERE Expediente=@expediente OR RefCliente=@expediente";
                    else if (dt.Columns.Contains("REFCLIENTE")) mcComm.CommandText = "SELECT idExpediente FROM Expedientes WHERE cast(Expediente as varchar)=@expediente OR RefCliente=@expediente";                
                    mcComm.command.Parameters.AddWithValue("@expediente", expediente);
                }

                int result = Convert.ToInt32(mcComm.ExecuteScalar());
                if (result != null)
                {
                    mcComm.command.CommandText = "INSERT INTO " + tabla + " (" + campo + ") VALUES (@value)";
                    mcComm.command.Parameters.Clear();
                    mcComm.command.Parameters.AddWithValue("@value", result);
                    mcComm.ExecuteNonQuery();
                }
                count++;
            }
            MessageBox.Show("Carga de campaña finalizada con " + count + " expedientes.");
        }

        private void Inserciones_AXACTOR(DataTable dt, string tabla, string campo)
        {
            BorrarRegistrosAntiguos(tabla);

            foreach (DataRow fila in dt.Rows)
            {
                string expediente = fila["Idclienteald"].ToString();

                mcComm.command.CommandText = "INSERT INTO " + tabla + " (" + campo + ") VALUES (@value)";
                mcComm.command.Parameters.Clear();
                mcComm.command.Parameters.AddWithValue("@value", expediente);
                mcComm.ExecuteNonQuery();                
                count++;
            }
            MessageBox.Show("Carga de campaña finalizada con " + count + " expedientes.");
        }
        
        private void Inserciones_NASSAU(DataTable dt, string tabla, string campo)
        {
            BorrarRegistrosAntiguos(tabla);

            foreach (DataRow fila in dt.Rows)
            {
                string expediente = fila["Case ID"].ToString();
                mcComm.CommandText = "SELECT CodigoParticipante FROM NASSTITULARES WHERE Contrato=@expediente";
                mcComm.command.Parameters.AddWithValue("@expediente", expediente);

                string result = mcComm.ExecuteScalar().ToString();
                if (result != null)
                {
                    mcComm.command.CommandText = "INSERT INTO " + tabla + " (" + campo + ") VALUES (@value)";
                    mcComm.command.Parameters.Clear();
                    mcComm.command.Parameters.AddWithValue("@value", result);
                    mcComm.ExecuteNonQuery();
                }
                count++;
            }
            MessageBox.Show("Carga de campaña finalizada con " + count + " expedientes.");
        }
        
        private void BorrarRegistrosAntiguos(string tabla)
        {
            mcComm.command.Connection = conn.ObtenerConexion();
            mcComm.command.CommandText = "DELETE FROM " + tabla + "";
            mcComm.ExecuteNonQuery();

            Thread messageThread = new Thread(MuestraMensaje);
            messageThread.Start();
        }

        private static void MuestraMensaje()
        {
            MessageBox.Show("Cargando la nueva campaña.\nEste proceso puede tardar varios minutos.");
        }

        private string nHoja()
        {
            string hoja;
            var xlsApp = new Excel.Application();
            xlsApp.Workbooks.Open(txtFichero.Text.Trim());

            hoja = xlsApp.Sheets[1].Name;

            xlsApp.DisplayAlerts = false;
            xlsApp.Workbooks.Close();
            xlsApp.DisplayAlerts = true;

            xlsApp.Quit();
            xlsApp = null;

            return hoja;
        }
    }
}