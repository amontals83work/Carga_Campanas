Imports System.Data.SqlClient
Imports Microsoft.Office.Interop

Public Class Form1
    Private mc As New MCCommand
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCartera.DataSource = My.Application.conexionMC.ConsultaConNulo("select idCliente,Nombre from clientes where idcliente in (41,81,83,84,85,86,87,88) order by Nombre")
        cboCartera.DisplayMember = "nombre"
        cboCartera.ValueMember = "idcliente"
    End Sub

    Private Sub btnFichero_Click(sender As Object, e As EventArgs) Handles btnFichero.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtFichero.Text = OpenFileDialog1.FileName
        Else
            MessageBox.Show("Debe seleccionar un fichero para cargar los expedientes")
            Exit Sub
        End If
    End Sub

    Private Sub cboCartera_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboCartera.SelectionChangeCommitted
        If Not IsDBNull(cboCartera.SelectedValue) Then
            cboCampaña.DataSource = My.Application.conexionMC.ConsultaConNulo("select id,NombreInterno from CampanasLlamadas where Vigente=1 and IdCliente=" + cboCartera.SelectedValue.ToString + " and ficherocarga=1")
            cboCampaña.DisplayMember = "NombreInterno"
            cboCampaña.ValueMember = "id"
        Else
            cboCampaña.DataSource = Nothing
        End If
    End Sub

    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        CargarLista(cboCampaña.SelectedValue)
    End Sub

    Private Sub CargarLista(ByVal id As Integer)
        Dim ds As System.Data.DataSet
        Dim dt As DataTable
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        Dim MyConnection As System.Data.OleDb.OleDbConnection

        MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtFichero.Text.Trim + ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";")

        Dim hoja As String = nhoja()

        'Cogemos el nombre de la hoja 1 del Excel.
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" + hoja + "$]", MyConnection)

        ds = New System.Data.DataSet()
        MyCommand.Fill(ds)
        MyConnection.Close()

        dt = ds.Tables(0)

        Dim idexpediente As Integer = 0

        Select Case id
            'TDX
            Case 4066
                For Each fila As DataRow In dt.Rows
                    mc.CommandText = "select idexpediente from expedientes where expediente='" + fila("expediente") + "' or refcliente='" + fila("expediente") + "'"
                    idexpediente = mc.ExecuteScalar()

                    If idexpediente <> 0 Then
                        mc.CommandText = "insert into TempPruebaCampaña(idexpediente)values(" + idexpediente.ToString + ")"
                        mc.ExecuteNonQuery()
                    End If
                Next
                'AXACTOR
            Case 4023, 4067, 4107
                mc.CommandText = "insert into TempPruebaCampaña(idexpediente)values(" + idexpediente.ToString + ")"
                mc.ExecuteNonQuery()
                'ARBORKNOT
            Case 4051, 4075, 4083, 4095, 4096, 4103
                'NASSAU
            Case 4105
        End Select
    End Sub

    Private Function nhoja() As String
        Dim hoja As String
        Dim xlsApp = New Excel.Application()
        xlsApp.Workbooks.Open(txtFichero.Text.Trim)

        hoja = xlsApp.Sheets(1).Name

        xlsApp.DisplayAlerts = False
        xlsApp.Workbooks.Close()
        xlsApp.DisplayAlerts = True

        xlsApp.Quit()
        xlsApp = Nothing

        Return hoja
    End Function

    Private Sub cboCartera_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCartera.SelectedIndexChanged

    End Sub
End Class
