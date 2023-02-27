<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class tables
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
        Me.ckathg = New System.Windows.Forms.TextBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.ListView2 = New System.Windows.Forms.ListView
        Me.exodos = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'ckathg
        '
        Me.ckathg.Location = New System.Drawing.Point(566, 3)
        Me.ckathg.Name = "ckathg"
        Me.ckathg.Size = New System.Drawing.Size(183, 20)
        Me.ckathg.TabIndex = 0
        Me.ckathg.Visible = False
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(2, 411)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(747, 147)
        Me.ListBox1.TabIndex = 1
        '
        'ListView2
        '
        Me.ListView2.Location = New System.Drawing.Point(2, 3)
        Me.ListView2.Name = "ListView2"
        Me.ListView2.Size = New System.Drawing.Size(747, 402)
        Me.ListView2.TabIndex = 2
        Me.ListView2.UseCompatibleStateImageBehavior = False
        Me.ListView2.Visible = False
        '
        'exodos
        '
        Me.exodos.Location = New System.Drawing.Point(755, 339)
        Me.exodos.Name = "exodos"
        Me.exodos.Size = New System.Drawing.Size(103, 66)
        Me.exodos.TabIndex = 3
        Me.exodos.Text = "Εξοδος"
        Me.exodos.UseVisualStyleBackColor = True
        '
        'tables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(858, 580)
        Me.Controls.Add(Me.exodos)
        Me.Controls.Add(Me.ListView2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ckathg)
        Me.MinimizeBox = False
        Me.Name = "tables"
        Me.Text = "Form7"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ckathg As System.Windows.Forms.TextBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents ListView2 As System.Windows.Forms.ListView
    Friend WithEvents exodos As System.Windows.Forms.Button
End Class
