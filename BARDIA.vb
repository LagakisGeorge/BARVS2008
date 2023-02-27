Public Class BARDIES

    Private listview1 As New ListView
    Private KATEIL(100) As Integer
    Private IDPARAGG(100) As Integer

    Private Sub tables_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CreateMyListView()
    End Sub

    Private Sub listView1_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        ' MsgBox(listView1.SelectedItems.Item(0).Text)
        ckathg.Text = listview1.SelectedItems.Item(0).Text



        Dim index As Integer = listview1.SelectedIndices(0)

        ' On Error GoTo err
        Dim DT As New DataTable

        Dim MDATE As String
        If InStr(gCONNECT, "MDB") > 0 Then
            MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
        Else
            MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
        End If





        Try
            ExecuteSQLQuery("INSERT INTO BARDIA (OPENH,ISOPEN,HME,IDERGAZ,NUM1) VALUES ('" + Format(Now, "hh:mm") + "',1," + MDATE + "," + Str(IDPARAGG(index)) + "," + Str(gUser) + ")", DT)
            ExecuteSQLQuery("SELECT MAX(ID) FROM BARDIA WHERE NUM1=" + Str(gUser), DT)

        Catch ex As Exception
            gBardia = 0
            MsgBox("ΔΕΝ ΕΓΙΝΕ ΑΝΟΙΓΜΑ ΒΑΡΔΙΑΣ")
        End Try

        gBardia = DT(0)(0)
        GeRGAZ = CKATHG.Text


        Me.Close()

        'If DT.Rows.Count = 0 Then

        'Else
        '    Dim N As Long = DT(0)(0)
        '    ExecuteSQLQuery("SELECT * FROM BARDIA WHERE ID= " + Str(N), DT)
        '    If DT(0)("ISOPEN") = 1 Then
        '        gBardia = N
        '        MHNYMA.Text = "ΒΑΡΔΙΑ ΑΝΟΙΧΤΗ ΑΠΟ " + DT(0)("OPENH").ToString
        '    Else
        '        gBardia = 0
        '        MHNYMA.Text = "ΑΝΟΙΞΤΕ ΒΑΡΔΙΑ  "
        '        MHNYMA.BackColor = Color.Red
        '    End If
        'End If




        'If KATEIL(index) = 0 Then
        '    neaPARAGG.p_Trapezi = ckathg.Text

        '    neaPARAGG.b_trapezi.Text = "Tραπ." + ckathg.Text

        '    neaPARAGG.ShowDialog()
        'Else
        '    ADDITPARAGG.p_Trapezi = ckathg.Text
        '    ADDITPARAGG.b_trapezi.Text = "Tραπ." + ckathg.Text
        '    ADDITPARAGG.p_IDPARAGG = IDPARAGG(index)


        '    ADDITPARAGG.ShowDialog()
        'End If



    End Sub



    Sub CreateMyListView()
        listview1.Bounds = New Rectangle(New Point(10, 10), New Size(380, 400))
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
        ExecuteSQLQuery("select EPO,ID FROM ERGAZ", DTT)







        Dim Items As New List(Of ListViewItem)
        Dim RancomClass As New Random()
        For i As Integer = 0 To DTT.Rows.Count - 1
            '// Text and Images index
            ' Dim N1 As Integer = DTT(i)("KATEILHMENO")
            'KATEIL(i) = N1
            IDPARAGG(i) = DTT(i)("ID")
            Dim item As New ListViewItem(DTT(i)(0).ToString, 0) ' RancomClass.Next(0, 10) Mod 2)
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class