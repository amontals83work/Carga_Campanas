Imports System.Management
Imports AsterNET.Manager
Namespace My

    ' Los siguientes eventos est�n disponibles para MyApplication:
    ' 
    ' Inicio: se desencadena cuando se inicia la aplicaci�n, antes de que se cree el formulario de inicio.
    ' Apagado: generado despu�s de cerrar todos los formularios de la aplicaci�n. Este evento no se genera si la aplicaci�n termina de forma an�mala.
    ' UnhandledException: generado si la aplicaci�n detecta una excepci�n no controlada.
    ' StartupNextInstance: se desencadena cuando se inicia una aplicaci�n de instancia �nica y la aplicaci�n ya est� activa. 
    ' NetworkAvailabilityChanged: se desencadena cuando la conexi�n de red est� conectada o desconectada.
    Partial Friend Class MyApplication
        Dim _conexionMc As ConexionBD
        Public Property conexionMC As ConexionBD
            Get
                Return _conexionMc
            End Get
            Set(ByVal value As ConexionBD)
                _conexionMc = value
            End Set
        End Property
        Public EsInterno As Boolean
    End Class

End Namespace

