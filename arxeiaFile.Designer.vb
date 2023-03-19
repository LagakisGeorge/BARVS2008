<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class arxeia
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.nea = New System.Windows.Forms.Button
        Me.SAVE = New System.Windows.Forms.Button
        Me.delete = New System.Windows.Forms.Button
        Me.edit = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.ono = New FocusedTextBox.FocusedTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ltimh = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.timh = New FocusedTextBox.FocusedTextBox
        Me.tPROSUETA = New FocusedTextBox.FocusedTextBox
        Me.lPicture = New System.Windows.Forms.Label
        Me.tPicture = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.num2 = New System.Windows.Forms.TextBox
        Me.ckathg = New FocusedTextBox.FocusedTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.ektypoths = New System.Windows.Forms.TextBox
        Me.XAR1 = New System.Windows.Forms.TextBox
        Me.XAR2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.KOD = New System.Windows.Forms.TextBox
        Me.lv = New System.Windows.Forms.ListView
        Me.ColumnHeader14 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader15 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader16 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader17 = New System.Windows.Forms.ColumnHeader
        Me.PROSUETA = New System.Windows.Forms.ListView
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.Button2 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Button3 = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 5
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button1, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.nea, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.SAVE, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.delete, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.edit, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(19, 391)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(657, 70)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button1.Location = New System.Drawing.Point(527, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(127, 64)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "ΕΞΟΔΟΣ"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'nea
        '
        Me.nea.Dock = System.Windows.Forms.DockStyle.Fill
        Me.nea.Location = New System.Drawing.Point(3, 3)
        Me.nea.Name = "nea"
        Me.nea.Size = New System.Drawing.Size(125, 64)
        Me.nea.TabIndex = 10
        Me.nea.Text = "Νέα Εγγραφή"
        Me.nea.UseVisualStyleBackColor = True
        '
        'SAVE
        '
        Me.SAVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.SAVE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SAVE.Enabled = False
        Me.SAVE.Location = New System.Drawing.Point(396, 3)
        Me.SAVE.Name = "SAVE"
        Me.SAVE.Size = New System.Drawing.Size(125, 64)
        Me.SAVE.TabIndex = 8
        Me.SAVE.Text = "Καταχώρηση"
        Me.SAVE.UseVisualStyleBackColor = False
        '
        'delete
        '
        Me.delete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.delete.Dock = System.Windows.Forms.DockStyle.Fill
        Me.delete.Location = New System.Drawing.Point(265, 3)
        Me.delete.Name = "delete"
        Me.delete.Size = New System.Drawing.Size(125, 64)
        Me.delete.TabIndex = 6
        Me.delete.Text = "Διαγραφή"
        Me.delete.UseVisualStyleBackColor = False
        '
        'edit
        '
        Me.edit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.edit.Enabled = False
        Me.edit.Location = New System.Drawing.Point(134, 3)
        Me.edit.Name = "edit"
        Me.edit.Size = New System.Drawing.Size(125, 64)
        Me.edit.TabIndex = 11
        Me.edit.Text = "Διόρθωση"
        Me.edit.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.85215!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.05882!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.96979!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ono, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ltimh, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.timh, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.tPROSUETA, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lPicture, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.tPicture, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.num2, 1, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.ckathg, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ektypoths, 3, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(22, 214)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(629, 171)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'ono
        '
        Me.ono.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ono.Enabled = False
        Me.ono.EnterFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ono.LeaveFocusColor = System.Drawing.Color.Empty
        Me.ono.Location = New System.Drawing.Point(109, 3)
        Me.ono.Mandatory = False
        Me.ono.MandatoryColor = System.Drawing.Color.Empty
        Me.ono.Name = "ono"
        Me.ono.Size = New System.Drawing.Size(290, 20)
        Me.ono.TabIndex = 55
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 30)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Ονομα"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Κατηγορία"
        '
        'ltimh
        '
        Me.ltimh.AutoSize = True
        Me.ltimh.Location = New System.Drawing.Point(3, 30)
        Me.ltimh.Name = "ltimh"
        Me.ltimh.Size = New System.Drawing.Size(28, 13)
        Me.ltimh.TabIndex = 2
        Me.ltimh.Text = "Τιμή"
        Me.ltimh.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Πρόσθετα"
        '
        'timh
        '
        Me.timh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.timh.Enabled = False
        Me.timh.EnterFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.timh.LeaveFocusColor = System.Drawing.Color.Empty
        Me.timh.Location = New System.Drawing.Point(109, 33)
        Me.timh.Mandatory = False
        Me.timh.MandatoryColor = System.Drawing.Color.Empty
        Me.timh.Name = "timh"
        Me.timh.Size = New System.Drawing.Size(290, 20)
        Me.timh.TabIndex = 56
        '
        'tPROSUETA
        '
        Me.tPROSUETA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tPROSUETA.Enabled = False
        Me.tPROSUETA.EnterFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tPROSUETA.LeaveFocusColor = System.Drawing.Color.Empty
        Me.tPROSUETA.Location = New System.Drawing.Point(109, 93)
        Me.tPROSUETA.Mandatory = False
        Me.tPROSUETA.MandatoryColor = System.Drawing.Color.Empty
        Me.tPROSUETA.Name = "tPROSUETA"
        Me.tPROSUETA.Size = New System.Drawing.Size(290, 20)
        Me.tPROSUETA.TabIndex = 58
        '
        'lPicture
        '
        Me.lPicture.AutoSize = True
        Me.lPicture.Location = New System.Drawing.Point(3, 120)
        Me.lPicture.Name = "lPicture"
        Me.lPicture.Size = New System.Drawing.Size(95, 13)
        Me.lPicture.TabIndex = 59
        Me.lPicture.Text = "Φωτογραφία κλικ"
        Me.lPicture.Visible = False
        '
        'tPicture
        '
        Me.tPicture.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tPicture.Location = New System.Drawing.Point(109, 123)
        Me.tPicture.Name = "tPicture"
        Me.tPicture.Size = New System.Drawing.Size(290, 20)
        Me.tPicture.TabIndex = 60
        Me.tPicture.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 150)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 61
        Me.Label5.Text = "Τιμή Πακέτου"
        '
        'num2
        '
        Me.num2.Location = New System.Drawing.Point(109, 153)
        Me.num2.Name = "num2"
        Me.num2.Size = New System.Drawing.Size(290, 20)
        Me.num2.TabIndex = 62
        '
        'ckathg
        '
        Me.ckathg.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckathg.Enabled = False
        Me.ckathg.EnterFocusColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ckathg.LeaveFocusColor = System.Drawing.Color.Empty
        Me.ckathg.Location = New System.Drawing.Point(109, 63)
        Me.ckathg.Mandatory = False
        Me.ckathg.MandatoryColor = System.Drawing.Color.Empty
        Me.ckathg.Name = "ckathg"
        Me.ckathg.Size = New System.Drawing.Size(290, 20)
        Me.ckathg.TabIndex = 57
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(405, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 63
        Me.Label7.Text = "Εκτυπωτής"
        '
        'ektypoths
        '
        Me.ektypoths.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ektypoths.Location = New System.Drawing.Point(474, 63)
        Me.ektypoths.Name = "ektypoths"
        Me.ektypoths.Size = New System.Drawing.Size(152, 20)
        Me.ektypoths.TabIndex = 64
        '
        'XAR1
        '
        Me.XAR1.Location = New System.Drawing.Point(266, 490)
        Me.XAR1.Name = "XAR1"
        Me.XAR1.Size = New System.Drawing.Size(511, 20)
        Me.XAR1.TabIndex = 7
        Me.XAR1.Visible = False
        '
        'XAR2
        '
        Me.XAR2.Location = New System.Drawing.Point(165, 495)
        Me.XAR2.Name = "XAR2"
        Me.XAR2.Size = New System.Drawing.Size(511, 20)
        Me.XAR2.TabIndex = 8
        Me.XAR2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 518)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Κωδικός"
        Me.Label1.Visible = False
        '
        'KOD
        '
        Me.KOD.Location = New System.Drawing.Point(140, 521)
        Me.KOD.Name = "KOD"
        Me.KOD.Size = New System.Drawing.Size(511, 20)
        Me.KOD.TabIndex = 4
        Me.KOD.Visible = False
        '
        'lv
        '
        Me.lv.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lv.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lv.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17})
        Me.lv.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lv.FullRowSelect = True
        Me.lv.GridLines = True
        Me.lv.Location = New System.Drawing.Point(22, 33)
        Me.lv.Name = "lv"
        Me.lv.Size = New System.Drawing.Size(657, 175)
        Me.lv.TabIndex = 53
        Me.lv.UseCompatibleStateImageBehavior = False
        Me.lv.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader14
        '
        Me.ColumnHeader14.Text = ".."
        Me.ColumnHeader14.Width = 80
        '
        'ColumnHeader15
        '
        Me.ColumnHeader15.Text = ".."
        Me.ColumnHeader15.Width = 133
        '
        'ColumnHeader16
        '
        Me.ColumnHeader16.Text = ".."
        Me.ColumnHeader16.Width = 163
        '
        'ColumnHeader17
        '
        Me.ColumnHeader17.Text = ".."
        Me.ColumnHeader17.Width = 179
        '
        'PROSUETA
        '
        Me.PROSUETA.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
        Me.PROSUETA.Location = New System.Drawing.Point(682, 4)
        Me.PROSUETA.Name = "PROSUETA"
        Me.PROSUETA.Size = New System.Drawing.Size(167, 478)
        Me.PROSUETA.TabIndex = 54
        Me.PROSUETA.UseCompatibleStateImageBehavior = False
        Me.PROSUETA.View = System.Windows.Forms.View.Details
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(655, 337)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(17, 19)
        Me.Button2.TabIndex = 56
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(116, 4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(195, 20)
        Me.TextBox1.TabIndex = 57
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Αναζήτηση"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(855, 31)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(173, 41)
        Me.Button3.TabIndex = 59
        Me.Button3.Text = "Ελεγχος Λαθών"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'arxeia
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 662)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PROSUETA)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.XAR1)
        Me.Controls.Add(Me.lv)
        Me.Controls.Add(Me.XAR2)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.KOD)
        Me.Name = "arxeia"
        Me.Text = "Form6"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents delete As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ltimh As System.Windows.Forms.Label
    Friend WithEvents KOD As System.Windows.Forms.TextBox
    Friend WithEvents XAR1 As System.Windows.Forms.TextBox
    Friend WithEvents XAR2 As System.Windows.Forms.TextBox
    Friend WithEvents SAVE As System.Windows.Forms.Button
    Private WithEvents lv As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PROSUETA As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nea As System.Windows.Forms.Button
    Friend WithEvents edit As System.Windows.Forms.Button
    Friend WithEvents ono As FocusedTextBox.FocusedTextBox
    Friend WithEvents timh As FocusedTextBox.FocusedTextBox
    Friend WithEvents ckathg As FocusedTextBox.FocusedTextBox
    Friend WithEvents tPROSUETA As FocusedTextBox.FocusedTextBox
    Friend WithEvents lPicture As System.Windows.Forms.Label
    Friend WithEvents tPicture As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents num2 As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ektypoths As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
