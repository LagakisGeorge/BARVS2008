<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BARDIES
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.CKATHG = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'CKATHG
        '
        Me.CKATHG.AutoSize = True
        Me.CKATHG.Location = New System.Drawing.Point(52, 10)
        Me.CKATHG.Name = "CKATHG"
        Me.CKATHG.Size = New System.Drawing.Size(13, 13)
        Me.CKATHG.TabIndex = 0
        Me.CKATHG.Text = ".."
        '
        'BARDIES
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 490)
        Me.Controls.Add(Me.CKATHG)
        Me.Name = "BARDIES"
        Me.Text = "Form6"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CKATHG As System.Windows.Forms.Label
End Class
