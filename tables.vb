Public Class tables
    Private listview1 As New ListView
    Private KATEIL(100) As Integer
    Private IDPARAGG(100) As Integer
    ' Private FIRSTIME As Integer = 0


    Private mSTHLH As Integer


    Public Property FIRSTIME() As Integer
        Get
            Return mSTHLH
        End Get
        Set(ByVal Value As Integer)
            ' If Value < 1 Or Value > 12 Then
            ' Error processing for invalid value. 
            'Else
            mSTHLH = Value
            'End If
        End Set
    End Property







    Private Sub tables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateMyListView()
        '  ExecuteSQLQuery("select 






    End Sub

    Private Sub listView1_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        ' MsgBox(listView1.SelectedItems.Item(0).Text)

        If listview1.SelectedIndices.Count = 0 Then
            Exit Sub
        End If


        Dim index As Integer = listview1.SelectedIndices(0)
        'If FIRSTIME = 0 Then
        'FIRSTIME = 1 
        ckathg.Text = Trim(Mid(listview1.SelectedItems.Item(0).Text, 1, 4))
        If KATEIL(index) = 0 Then
            'neaPARAGG.p_Trapezi = ckathg.Text

            'neaPARAGG.b_trapezi.Text = "Tραπ." + ckathg.Text

            'neaPARAGG.ShowDialog()
            ADDITPARAGG.p_Trapezi = ckathg.Text
            ADDITPARAGG.b_trapezi.Text = "Tραπ." + ckathg.Text
            ADDITPARAGG.p_IDPARAGG = IDPARAGG(index)
            ADDITPARAGG.HDH_YPARXOYSA.Visible = False
            ADDITPARAGG.typono_logar.Visible = False
            ADDITPARAGG.PAYMENT.Visible = False



            ADDITPARAGG.ShowDialog()

        Else
            ADDITPARAGG.p_Trapezi = ckathg.Text
            ADDITPARAGG.b_trapezi.Text = "Tραπ." + ckathg.Text
            ADDITPARAGG.p_IDPARAGG = IDPARAGG(index)
            ADDITPARAGG.ShowDialog()
            Dialog1.p_IDPARAGG = IDPARAGG(index)
            ' Me.Close()
            ' Me.Hide()

        End If
        CreateMyListView()
        ' End If


    End Sub



    Public Sub CreateMyListView()
        listview1.Bounds = New Rectangle(New Point(22, 12), New Size(781, 531))
        listview1.Bounds = ListView2.Bounds

        listView1.Items.Clear()

        'CreateMyListView()
        'AddHandler listView1.Click, AddressOf listView1_Click


        'listView1.Bounds = New Rectangle(New Point(10, 10), New Size(420, 400))

        ' Set the view to show details.
        With listView1
            ' Set ListView view mode to show Large Icons
            .View = View.LargeIcon
            .Cursor = Cursors.Hand
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
        End With

        ' / --------------------------------------------------------------------------------
        ' / BASIC THINKING ... Static ListView control
        ' Create items and sets of subitems for each item.
        'Dim item1 As New ListViewItem("Table 1", 0)
        'Dim item2 As New ListViewItem("Table 2", 1)
        'Dim item3 As New ListViewItem("Table 3", 0)
        'Dim item4 As New ListViewItem("Table 4", 0)
        'Dim item5 As New ListViewItem("Table 5", 1)
        'Dim item6 As New ListViewItem("Table 6", 1)
        'Dim item7 As New ListViewItem("Table 7", 0)
        'Add the items to the ListView.
        'listView1.Items.AddRange(New ListViewItem() {item1, item2, item3, item4, item5, item6, item7})
        ' / --------------------------------------------------------------------------------

        listView1.Columns.Add("Column 1", -2, HorizontalAlignment.Left)
        listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        ' / --------------------------------------------------------------------------------
        ' / @Run Time



        Dim DTT As New DataTable
        ExecuteSQLQuery("select ONO, ID,isnull(KATEILHMENO,0) as KATEILHMENO ,isnull(SYNOLO,0) as SYNOLO,ISNULL(IDPARAGG,0) AS IDPARAGG ,(SELECT SUM(POSO*TIMH) FROM PARAGG WHERE IDPARAGG=TABLES.IDPARAGG) as TREX FROM TABLES WHERE NUM1=" + Str(gUser) + " ORDER BY ONO", DTT)


        ' ExecuteSQLQuery("SELECT ONO,POSO,TIMH,POSO*TIMH AS AJ FROM PARAGG WHERE IDPARAGG=" + Str(p_IDPARAGG), DT)




        Dim Items As New List(Of ListViewItem)
        Dim RancomClass As New Random()
        For i As Integer = 0 To DTT.Rows.Count - 1
            '// Text and Images index
            Dim N1 As Integer = DTT(i)("KATEILHMENO")
            KATEIL(i) = N1
            IDPARAGG(i) = DTT(i)("IDPARAGG")
            Dim TREX_LOGAR As String
            If nNull(DTT(i)("TREX").ToString) > 0 Then
                TREX_LOGAR = "   >" + DTT(i)("TREX").ToString + "€"
            Else
                TREX_LOGAR = "" 'DTT(i)("TREX").ToString
            End If
            Dim item As New ListViewItem(DTT(i)("ONO").ToString + TREX_LOGAR, N1) ' RancomClass.Next(0, 10) Mod 2)
            Items.Add(item)
        Next
        listView1.Items.AddRange(Items.ToArray)

        ' Create ImageList objects.
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(64, 64)
        Dim strPath As String = MyPath(Application.StartupPath)


        ' Initialize the ImageList objects with bitmaps.
        imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        'Assign the ImageList objects to the ListView.
        listView1.LargeImageList = imgList

        ' Add the ListView to the control collection.
        Me.Controls.Add(listView1)
        '// start event handling at any time during program execution.
        AddHandler listView1.Click, AddressOf listView1_Click

    End Sub 'CreateMyListView



    Private Sub ListView2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView2.SelectedIndexChanged

    End Sub

    Private Sub exodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exodos.Click
        Me.Close()
        Dim n As Integer = MDIParent1.TabControl1.TabIndex
        MDIParent1.TabControl1.TabPages.Remove(MDIParent1.TabControl1.SelectedTab)
        Dim l = MDIParent1.TabControl1.TabPages.Count
        MDIParent1.TabControl1.SelectTab(l - 1)



    End Sub

    Private Sub tables_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub
End Class