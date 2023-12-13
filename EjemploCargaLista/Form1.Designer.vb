<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCartera = New System.Windows.Forms.ComboBox()
        Me.cboCampaña = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFichero = New System.Windows.Forms.TextBox()
        Me.btnFichero = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cartera"
        '
        'cboCartera
        '
        Me.cboCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCartera.FormattingEnabled = True
        Me.cboCartera.Location = New System.Drawing.Point(109, 15)
        Me.cboCartera.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCartera.Name = "cboCartera"
        Me.cboCartera.Size = New System.Drawing.Size(289, 24)
        Me.cboCartera.TabIndex = 1
        '
        'cboCampaña
        '
        Me.cboCampaña.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCampaña.FormattingEnabled = True
        Me.cboCampaña.Location = New System.Drawing.Point(109, 48)
        Me.cboCampaña.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboCampaña.Name = "cboCampaña"
        Me.cboCampaña.Size = New System.Drawing.Size(289, 24)
        Me.cboCampaña.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 17)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Campaña"
        '
        'txtFichero
        '
        Me.txtFichero.Location = New System.Drawing.Point(109, 81)
        Me.txtFichero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtFichero.Name = "txtFichero"
        Me.txtFichero.Size = New System.Drawing.Size(243, 22)
        Me.txtFichero.TabIndex = 4
        '
        'btnFichero
        '
        Me.btnFichero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFichero.Location = New System.Drawing.Point(361, 80)
        Me.btnFichero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnFichero.Name = "btnFichero"
        Me.btnFichero.Size = New System.Drawing.Size(39, 28)
        Me.btnFichero.TabIndex = 5
        Me.btnFichero.Text = "..."
        Me.btnFichero.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 85)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Fichero"
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(300, 129)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(100, 28)
        Me.btnCargar.TabIndex = 7
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 171)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnFichero)
        Me.Controls.Add(Me.txtFichero)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCampaña)
        Me.Controls.Add(Me.cboCartera)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Cargar Campaña"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cboCartera As ComboBox
    Friend WithEvents cboCampaña As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFichero As TextBox
    Friend WithEvents btnFichero As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCargar As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
