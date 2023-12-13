Imports System.Data.SqlClient
Public Class ConexionBD
    Implements IDbConnection
    Public reconectar As Boolean = True
    Friend WithEvents _sqlConnection As SqlClient.SqlConnection
    ''Public Property Servidor As String
    ''    Get
    ''        Return _servidor
    ''    End Get
    ''    Set(ByVal value As String)
    ''        _sqlConnection = New SqlClient.SqlConnection(My.Settings.DespachoMCConnectionString)

    ''        If _sqlConnection.State <> ConnectionState.Open Then
    ''            _sqlConnection.Open()
    ''        End If

    ''        _servidor = value
    ''    End Set
    ''End Property
    ''Private _servidor As String
    ''Public Sub New(SedeServidor As String)
    ''    Me.Servidor = SedeServidor
    ''End Sub
    Public Sub New()
        _sqlConnection = New SqlClient.SqlConnection(My.Settings.DespachoMCConnectionString)
    End Sub
    Public Function Consulta(ByVal sqlString As String) As DataTable
        Dim tblAux As New DataTable
        Try
            Dim daAux As New SqlDataAdapter(sqlString, _sqlConnection)
            daAux.Fill(tblAux)
            daAux = Nothing
            Return tblAux
        Catch ex As Exception
            'Stop
        End Try
    End Function
    Public Function ConsultaConNulo(ByVal sqlstring As String) As DataTable
        Dim tblAux As New DataTable
        Dim daAux As New SqlDataAdapter(sqlstring, _sqlConnection)
        daAux.Fill(tblAux)
        tblAux.Rows.InsertAt(tblAux.NewRow, 0)
        daAux = Nothing
        Return tblAux
    End Function
    Private Sub New(ByVal interno As Boolean)
        If interno Then
            '_sqlConnection = New SqlClient.SqlConnection(My.Settings.LoginConnectionString)
            _sqlConnection = New SqlClient.SqlConnection(My.Settings.DespachoMCConnectionString)
            'Else
            '    _sqlConnection = New SqlClient.SqlConnection(My.Settings.ConnectionStringExterna)
        End If
    End Sub
    'Private Sub New(ByVal ConnectionString As String)
    '    _sqlConnection = New SqlClient.SqlConnection(ConnectionString)
    'End Sub
    Public Function Escalar(ByVal sqlString As String) As Object
        Dim cmdAux As New SqlCommand(sqlString, _sqlConnection)
        Return cmdAux.ExecuteScalar()
    End Function

    ''' <summary>
    ''' Devuelve el un objeto datatable con el command pasado
    ''' </summary>
    ''' <param name="pSql">Obligatorio: objeto Sqlcommand completo del que queremos obtener los datos</param>
    ''' <returns>Objeto datatable</returns>
    ''' <remarks></remarks>></remarks>
    Public Function DameDatatableCommand(pCmd As SqlCommand) As DataTable
        Dim vDev As New DataTable
        Try

            pCmd.Connection = _sqlConnection
            Dim da As New SqlDataAdapter(pCmd)
            da.Fill(vDev)

        Catch ex As Exception

        End Try
        Return vDev
    End Function
    Public Function BeginTransaction() As System.Data.IDbTransaction Implements System.Data.IDbConnection.BeginTransaction
        Return _sqlConnection.BeginTransaction()
    End Function

    Public Function BeginTransaction(ByVal il As System.Data.IsolationLevel) As System.Data.IDbTransaction Implements System.Data.IDbConnection.BeginTransaction
        Return _sqlConnection.BeginTransaction(il)
    End Function

    Public Sub ChangeDatabase(ByVal databaseName As String) Implements System.Data.IDbConnection.ChangeDatabase
        _sqlConnection.ChangeDatabase(databaseName)
    End Sub

    Public Sub Close() Implements System.Data.IDbConnection.Close
        _sqlConnection.Close()
    End Sub

    Public Property ConnectionString() As String Implements System.Data.IDbConnection.ConnectionString
        Get
            Return _sqlConnection.ConnectionString
        End Get
        Set(ByVal value As String)
            _sqlConnection.ConnectionString = value
        End Set
    End Property

    Public ReadOnly Property ConnectionTimeout() As Integer Implements System.Data.IDbConnection.ConnectionTimeout
        Get
            Return _sqlConnection.ConnectionTimeout
        End Get
    End Property

    Public Function CreateCommand() As System.Data.IDbCommand Implements System.Data.IDbConnection.CreateCommand
        Return _sqlConnection.CreateCommand()
    End Function

    Public ReadOnly Property Database() As String Implements System.Data.IDbConnection.Database
        Get
            Return _sqlConnection.Database()
        End Get
    End Property

    Public Sub Open() Implements System.Data.IDbConnection.Open
        Try
            _sqlConnection.Open()
        Catch ex As SqlException

        End Try
    End Sub

    Public ReadOnly Property State() As System.Data.ConnectionState Implements System.Data.IDbConnection.State
        Get
            Return _sqlConnection.State()
        End Get
    End Property

    Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
            End If
            _sqlConnection = Nothing

        End If
        Me.disposedValue = True
    End Sub
    Private Sub reconectar_event(ByVal sender As Object, ByVal e As System.Data.StateChangeEventArgs) Handles _sqlConnection.StateChange
        If reconectar Then
            If e.CurrentState = ConnectionState.Closed Then
                Do
                    _sqlConnection.Open()

                Loop Until _sqlConnection.State = ConnectionState.Open

            End If
        End If
    End Sub

#Region " IDisposable Support "
    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

End Class
