Public Class MCCommand
    Implements IDbCommand
    Friend _miCommand As SqlClient.SqlCommand

    Public Sub Cancel() Implements System.Data.IDbCommand.Cancel
        _miCommand.Cancel()
    End Sub
    Public Property CommandText() As String Implements System.Data.IDbCommand.CommandText
        Get
            Return _miCommand.CommandText
        End Get
        Set(ByVal value As String)
            _miCommand.CommandText = value
        End Set
    End Property
    Public Property CommandTimeout() As Integer Implements System.Data.IDbCommand.CommandTimeout
        Get
            Return _miCommand.CommandTimeout
        End Get
        Set(ByVal value As Integer)
            _miCommand.CommandTimeout = value
        End Set
    End Property
    Public Property CommandType() As System.Data.CommandType Implements System.Data.IDbCommand.CommandType
        Get
            Return _miCommand.CommandType
        End Get
        Set(ByVal value As System.Data.CommandType)
            _miCommand.CommandType = value
        End Set
    End Property
    Private Property Connection() As System.Data.IDbConnection Implements System.Data.IDbCommand.Connection
        Get
            Return _miCommand.Connection
        End Get
        Set(ByVal value As System.Data.IDbConnection)
            _miCommand.Connection = CType(value, SqlClient.SqlConnection)
        End Set
    End Property
    Public Function CreateParameter() As System.Data.IDbDataParameter Implements System.Data.IDbCommand.CreateParameter
        Return _miCommand.CreateParameter()
    End Function
    Public Function ExecuteNonQuery() As Integer Implements System.Data.IDbCommand.ExecuteNonQuery

        Return _miCommand.ExecuteNonQuery()
    End Function
    Public Function ExecuteReader() As System.Data.IDataReader Implements System.Data.IDbCommand.ExecuteReader
        Return _miCommand.ExecuteReader()
    End Function
    Public Function ExecuteReader(ByVal behavior As System.Data.CommandBehavior) As System.Data.IDataReader Implements System.Data.IDbCommand.ExecuteReader
        Return _miCommand.ExecuteReader(behavior)
    End Function
    Public Function ExecuteScalar() As Object Implements System.Data.IDbCommand.ExecuteScalar
        Return _miCommand.ExecuteScalar()
    End Function
    Public ReadOnly Property Parameters() As System.Data.IDataParameterCollection Implements System.Data.IDbCommand.Parameters
        Get
            Return _miCommand.Parameters
        End Get
    End Property
    Public ReadOnly Property Parametros() As System.Data.SqlClient.SqlParameterCollection
        Get
            Return _miCommand.Parameters
        End Get
    End Property
    Public Sub Prepare() Implements System.Data.IDbCommand.Prepare
        _miCommand.Prepare()
    End Sub
    Public Property Transaction() As System.Data.IDbTransaction Implements System.Data.IDbCommand.Transaction
        Get
            Return _miCommand.Transaction
        End Get
        Set(ByVal value As System.Data.IDbTransaction)
            _miCommand.Transaction = CType(value, SqlClient.SqlTransaction)
        End Set
    End Property
    Public Property UpdatedRowSource() As System.Data.UpdateRowSource Implements System.Data.IDbCommand.UpdatedRowSource
        Get
            Return _miCommand.UpdatedRowSource
        End Get
        Set(ByVal value As System.Data.UpdateRowSource)
            _miCommand.UpdatedRowSource = value
        End Set
    End Property
    Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then

            End If
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Public Sub New()
        _miCommand = New SqlClient.SqlCommand()

        If IsNothing(My.Application.conexionMC) Then
            My.Application.conexionMC = New ConexionBD()

            If My.Application.conexionMC.State <> ConnectionState.Open Then
                My.Application.conexionMC.Open()
            End If
        End If

        _miCommand.Connection = My.Application.conexionMC._sqlConnection
    End Sub
    Public Sub New(ByVal ConexionBD As ConexionBD)
        _miCommand = New SqlClient.SqlCommand()
        _miCommand.Connection = ConexionBD._sqlConnection
    End Sub
    Public Sub New(ByVal cmdText As String)
        _miCommand = New SqlClient.SqlCommand(cmdText)

        If IsNothing(My.Application.conexionMC) Then
            My.Application.conexionMC = New ConexionBD()

            If My.Application.conexionMC.State <> ConnectionState.Open Then
                My.Application.conexionMC.Open()
            End If
        End If

        _miCommand.Connection = My.Application.conexionMC._sqlConnection
    End Sub
    Public Sub New(ByVal cmdText As String, ByVal transaction As SqlClient.SqlTransaction)
        _miCommand = New SqlClient.SqlCommand(cmdText, My.Application.conexionMC._sqlConnection, transaction)
    End Sub
End Class
