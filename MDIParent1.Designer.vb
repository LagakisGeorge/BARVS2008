<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIParent1
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIParent1))
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.FileMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelSales = New System.Windows.Forms.Panel
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.excelanal = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.cmdSTATISTICS = New System.Windows.Forms.LinkLabel
        Me.cmdSalesReceipt = New System.Windows.Forms.Button
        Me.cmdCustomerOrder = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdLock = New System.Windows.Forms.Button
        Me.lbltime = New System.Windows.Forms.Label
        Me.lbltoday = New System.Windows.Forms.Label
        Me.lblUser = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.TabControl1 = New jgiminsil.TabControlEx
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.MenuStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.PanelSales.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileMenu})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1264, 27)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'FileMenu
        '
        Me.FileMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ToolStripSeparator3, Me.ToolStripSeparator4, Me.PrintToolStripMenuItem, Me.ToolStripSeparator5, Me.ExitToolStripMenuItem})
        Me.FileMenu.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.FileMenu.Name = "FileMenu"
        Me.FileMenu.Size = New System.Drawing.Size(65, 23)
        Me.FileMenu.Text = "&Αρχεία"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Image = CType(resources.GetObject("NewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(206, 24)
        Me.NewToolStripMenuItem.Text = "&Παράμετροι"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(203, 6)
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(203, 6)
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Image = CType(resources.GetObject("PrintToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PrintToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(206, 24)
        Me.PrintToolStripMenuItem.Text = "&Εκτυπωτές"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(203, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(206, 24)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 751)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1264, 24)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(47, 19)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'PanelSales
        '
        Me.PanelSales.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelSales.Controls.Add(Me.Button9)
        Me.PanelSales.Controls.Add(Me.Button7)
        Me.PanelSales.Controls.Add(Me.Button5)
        Me.PanelSales.Controls.Add(Me.Button6)
        Me.PanelSales.Controls.Add(Me.Button4)
        Me.PanelSales.Controls.Add(Me.excelanal)
        Me.PanelSales.Controls.Add(Me.Button3)
        Me.PanelSales.Controls.Add(Me.Button2)
        Me.PanelSales.Controls.Add(Me.cmdSTATISTICS)
        Me.PanelSales.Controls.Add(Me.cmdSalesReceipt)
        Me.PanelSales.Controls.Add(Me.cmdCustomerOrder)
        Me.PanelSales.Location = New System.Drawing.Point(0, 124)
        Me.PanelSales.Name = "PanelSales"
        Me.PanelSales.Size = New System.Drawing.Size(186, 552)
        Me.PanelSales.TabIndex = 31
        '
        'Button9
        '
        Me.Button9.Enabled = False
        Me.Button9.Location = New System.Drawing.Point(3, 58)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(163, 21)
        Me.Button9.TabIndex = 41
        Me.Button9.UseVisualStyleBackColor = True
        Me.Button9.Visible = False
        '
        'Button7
        '
        Me.Button7.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.BackColor = System.Drawing.Color.White
        Me.Button7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.ImageKey = "print_64.png"
        Me.Button7.Location = New System.Drawing.Point(3, 20)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(165, 32)
        Me.Button7.TabIndex = 39
        Me.Button7.Text = "Νέα Παραγγελία"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.White
        Me.Button5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.ImageKey = "document_pencil_32.png"
        Me.Button5.Location = New System.Drawing.Point(0, 175)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(166, 27)
        Me.Button5.TabIndex = 37
        Me.Button5.Text = "Αρχεία"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.White
        Me.Button6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.ImageKey = "billing.png"
        Me.Button6.Location = New System.Drawing.Point(1, 241)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(166, 27)
        Me.Button6.TabIndex = 38
        Me.Button6.Text = "Βάρδια"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(-1, 376)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(167, 25)
        Me.Button4.TabIndex = 36
        Me.Button4.Text = "Database Explorer"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'excelanal
        '
        Me.excelanal.BackColor = System.Drawing.Color.White
        Me.excelanal.Enabled = False
        Me.excelanal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.excelanal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.excelanal.ImageKey = "billing.png"
        Me.excelanal.Location = New System.Drawing.Point(1, 281)
        Me.excelanal.Name = "excelanal"
        Me.excelanal.Size = New System.Drawing.Size(166, 27)
        Me.excelanal.TabIndex = 30
        Me.excelanal.Text = "Εισαγωγή από Excel"
        Me.excelanal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.excelanal.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.White
        Me.Button3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.ImageKey = "buy_32.png"
        Me.Button3.Location = New System.Drawing.Point(0, 142)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(166, 27)
        Me.Button3.TabIndex = 35
        Me.Button3.Text = "Τυπώνω παλιότερη βάρδια"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Enabled = False
        Me.Button2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageKey = "buy_32.png"
        Me.Button2.Location = New System.Drawing.Point(1, 102)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(166, 27)
        Me.Button2.TabIndex = 34
        Me.Button2.UseVisualStyleBackColor = False
        Me.Button2.Visible = False
        '
        'cmdSTATISTICS
        '
        Me.cmdSTATISTICS.AutoSize = True
        Me.cmdSTATISTICS.Enabled = False
        Me.cmdSTATISTICS.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSTATISTICS.Location = New System.Drawing.Point(1, 323)
        Me.cmdSTATISTICS.Name = "cmdSTATISTICS"
        Me.cmdSTATISTICS.Size = New System.Drawing.Size(179, 19)
        Me.cmdSTATISTICS.TabIndex = 32
        Me.cmdSTATISTICS.TabStop = True
        Me.cmdSTATISTICS.Text = "Στατιστικά/Εκτυπώσεις"
        '
        'cmdSalesReceipt
        '
        Me.cmdSalesReceipt.BackColor = System.Drawing.Color.White
        Me.cmdSalesReceipt.Enabled = False
        Me.cmdSalesReceipt.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalesReceipt.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmdSalesReceipt.ImageKey = "cubes.ico"
        Me.cmdSalesReceipt.Location = New System.Drawing.Point(-3, 407)
        Me.cmdSalesReceipt.Name = "cmdSalesReceipt"
        Me.cmdSalesReceipt.Size = New System.Drawing.Size(168, 30)
        Me.cmdSalesReceipt.TabIndex = 31
        Me.cmdSalesReceipt.Text = "   .."
        Me.cmdSalesReceipt.UseVisualStyleBackColor = False
        Me.cmdSalesReceipt.Visible = False
        '
        'cmdCustomerOrder
        '
        Me.cmdCustomerOrder.BackColor = System.Drawing.Color.White
        Me.cmdCustomerOrder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCustomerOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCustomerOrder.ImageKey = "buy_32.png"
        Me.cmdCustomerOrder.Location = New System.Drawing.Point(1, 208)
        Me.cmdCustomerOrder.Name = "cmdCustomerOrder"
        Me.cmdCustomerOrder.Size = New System.Drawing.Size(166, 27)
        Me.cmdCustomerOrder.TabIndex = 29
        Me.cmdCustomerOrder.Text = "Αλλαγή Κωδικού"
        Me.cmdCustomerOrder.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.cmdLock)
        Me.Panel1.Controls.Add(Me.lbltime)
        Me.Panel1.Controls.Add(Me.lbltoday)
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(0, 27)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(186, 91)
        Me.Panel1.TabIndex = 30
        '
        'cmdLock
        '
        Me.cmdLock.BackColor = System.Drawing.Color.White
        Me.cmdLock.Enabled = False
        Me.cmdLock.ImageKey = "lock_48.png"
        Me.cmdLock.Location = New System.Drawing.Point(131, 53)
        Me.cmdLock.Name = "cmdLock"
        Me.cmdLock.Size = New System.Drawing.Size(43, 38)
        Me.cmdLock.TabIndex = 51
        Me.cmdLock.UseVisualStyleBackColor = False
        '
        'lbltime
        '
        Me.lbltime.AutoSize = True
        Me.lbltime.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltime.ForeColor = System.Drawing.Color.Red
        Me.lbltime.Location = New System.Drawing.Point(57, 74)
        Me.lbltime.Name = "lbltime"
        Me.lbltime.Size = New System.Drawing.Size(0, 16)
        Me.lbltime.TabIndex = 8
        '
        'lbltoday
        '
        Me.lbltoday.AutoSize = True
        Me.lbltoday.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltoday.Location = New System.Drawing.Point(58, 60)
        Me.lbltoday.Name = "lbltoday"
        Me.lbltoday.Size = New System.Drawing.Size(0, 16)
        Me.lbltoday.TabIndex = 7
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(57, 45)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(0, 16)
        Me.lblUser.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Clock :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Today is :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Welcome :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.Highlight
        Me.Label2.Location = New System.Drawing.Point(68, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 17)
        Me.Label2.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(21, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(311, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Production Inventory and Traceability P.I.T."
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(38, 34)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(180, 27)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(943, 693)
        Me.TabControl1.TabIndex = 35
        '
        'TabPage1
        '
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(935, 667)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'MDIParent1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1264, 775)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelSales)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIParent1"
        Me.Text = "MDIParent1"
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.PanelSales.ResumeLayout(False)
        Me.PanelSales.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PanelSales As System.Windows.Forms.Panel
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents excelanal As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdSTATISTICS As System.Windows.Forms.LinkLabel
    Friend WithEvents cmdSalesReceipt As System.Windows.Forms.Button
    Friend WithEvents cmdCustomerOrder As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdLock As System.Windows.Forms.Button
    Friend WithEvents lbltime As System.Windows.Forms.Label
    Friend WithEvents lbltoday As System.Windows.Forms.Label
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TabControl1 As jgiminsil.TabControlEx
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage

End Class
