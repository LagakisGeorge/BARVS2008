<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog1
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.CASH = New System.Windows.Forms.Button
        Me.PIS1 = New System.Windows.Forms.Button
        Me.PIS2 = New System.Windows.Forms.Button
        Me.KERA = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.KERA, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.PIS2, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.PIS1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.CASH, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 0, 4)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(12, 2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(226, 314)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(3, 251)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(220, 60)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "AKYPO"
        '
        'CASH
        '
        Me.CASH.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CASH.Location = New System.Drawing.Point(3, 3)
        Me.CASH.Name = "CASH"
        Me.CASH.Size = New System.Drawing.Size(220, 56)
        Me.CASH.TabIndex = 0
        Me.CASH.Text = "ΜΕΤΡΗΤΑ"
        '
        'PIS1
        '
        Me.PIS1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PIS1.Location = New System.Drawing.Point(3, 65)
        Me.PIS1.Name = "PIS1"
        Me.PIS1.Size = New System.Drawing.Size(220, 56)
        Me.PIS1.TabIndex = 2
        Me.PIS1.Text = "ΠΙΣΤΩΤΙΚΗ 1"
        '
        'PIS2
        '
        Me.PIS2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PIS2.Location = New System.Drawing.Point(3, 127)
        Me.PIS2.Name = "PIS2"
        Me.PIS2.Size = New System.Drawing.Size(220, 56)
        Me.PIS2.TabIndex = 3
        Me.PIS2.Text = "ΠΙΣΤΩΤΙΚΗ 2"
        '
        'KERA
        '
        Me.KERA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.KERA.Location = New System.Drawing.Point(3, 189)
        Me.KERA.Name = "KERA"
        Me.KERA.Size = New System.Drawing.Size(220, 56)
        Me.KERA.TabIndex = 4
        Me.KERA.Text = "ΚΕΡΑΣΜΕΝΑ"
        '
        'Dialog1
        '
        Me.AcceptButton = Me.CASH
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(241, 321)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog1"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Dialog1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents CASH As System.Windows.Forms.Button
    Friend WithEvents KERA As System.Windows.Forms.Button
    Friend WithEvents PIS2 As System.Windows.Forms.Button
    Friend WithEvents PIS1 As System.Windows.Forms.Button

End Class
