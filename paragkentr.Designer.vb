<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class paragkentr
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(paragkentr))
        Me.bNeaParaggelia = New System.Windows.Forms.Button
        Me.arxeio = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.bardia = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.MHNYMA = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bNeaParaggelia
        '
        Me.bNeaParaggelia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bNeaParaggelia.Location = New System.Drawing.Point(3, 3)
        Me.bNeaParaggelia.Name = "bNeaParaggelia"
        Me.bNeaParaggelia.Size = New System.Drawing.Size(419, 41)
        Me.bNeaParaggelia.TabIndex = 3
        Me.bNeaParaggelia.Text = "NEA ΠΑΡΑΓΓΕΛΙΑ"
        Me.bNeaParaggelia.UseVisualStyleBackColor = True
        '
        'arxeio
        '
        Me.arxeio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.arxeio.Location = New System.Drawing.Point(3, 97)
        Me.arxeio.Name = "arxeio"
        Me.arxeio.Size = New System.Drawing.Size(419, 41)
        Me.arxeio.TabIndex = 5
        Me.arxeio.Text = "Αρχεία Ειδών,Κατηγοριών,Πρόσθετων,Τραπεζιών"
        Me.arxeio.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.bNeaParaggelia, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.bardia, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.arxeio, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Button3, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Button1, 0, 4)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(5, 246)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(425, 237)
        Me.TableLayoutPanel2.TabIndex = 6
        '
        'bardia
        '
        Me.bardia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.bardia.Location = New System.Drawing.Point(3, 50)
        Me.bardia.Name = "bardia"
        Me.bardia.Size = New System.Drawing.Size(419, 41)
        Me.bardia.TabIndex = 6
        Me.bardia.Text = "ΒΑΡΔΙΑ"
        Me.bardia.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Button3.Location = New System.Drawing.Point(3, 144)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(419, 41)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Τυπώνω παλιότερη βάρδια"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MHNYMA
        '
        Me.MHNYMA.Location = New System.Drawing.Point(7, 4)
        Me.MHNYMA.Name = "MHNYMA"
        Me.MHNYMA.Size = New System.Drawing.Size(424, 28)
        Me.MHNYMA.TabIndex = 7
        '
        'PictureBox1
        '
        Me.PictureBox1.InitialImage = CType(resources.GetObject("PictureBox1.InitialImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(5, 35)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(427, 205)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(3, 191)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(419, 43)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Αλλαγή Κωδικού"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'paragkentr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 568)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MHNYMA)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "paragkentr"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "New"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents bNeaParaggelia As System.Windows.Forms.Button
    Friend WithEvents arxeio As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents bardia As System.Windows.Forms.Button
    Friend WithEvents MHNYMA As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
