Public Class arxeia
    Dim fid As Long
    Dim F_EPANALAMBANOMENES As Integer = -1
    Dim oxiPat As System.Drawing.Color = Color.LightGray
    Dim Pat As System.Drawing.Color = Color.Yellow
    Private listView1 As New ListView()
    Private mSTHLH As String


    Public Property p_Table() As String
        Get
            Return mSTHLH
        End Get
        Set(ByVal Value As String)
            ' If Value < 1 Or Value > 12 Then
            ' Error processing for invalid value. 
            'Else
            mSTHLH = Value
            'End If
        End Set
    End Property

    'Private Sub kathgoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lv.Items.Clear()
    '    'lv.Columns(0).Text = "Κωδικός"
    '    lv.Columns(0).Text = "Ονομα"
    '    lv.Columns(1).Text = "ID"
    '    lv.Columns(0).Width = 700

    '    lv.Columns(2).Text = ""   ' Κωδικός"
    '    lv.Columns(3).Text = ""
    '    lv.Columns(4).Text = ""
    '    lv.Columns(5).Text = ""



    '    ltimh.Visible = False

    '    TIMH.Visible = False
    '    XAR1.Visible = False
    '    XAR2.Visible = False

    '    LOAD_file("SELECT ONO,ID FROM KATHG", lv, 2)
    'End Sub

   


    Private Sub SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE.Click

        If lv.SelectedItems.Count = 0 Then
            fid = 0
        Else
            fid = lv.SelectedItems(0).SubItems(1).Text()
        End If

        If nea.Enabled = False Then 'fid = 0 Then  ' NEA EGGRAFH
            Dim dtt As New DataTable
            If p_Table = "KATHG" Then
                ExecuteSQLQuery("insert into KATHG (ONO,PICTURE) VALUES ( '" + ono.Text + "','" + tPicture.Text + "')", dtt)
            End If
            If p_Table = "EIDH" Then
                Dim MKATHG As String = Split(CKATHG.Text, ";")(1)
                Dim mt As String = Replace(timh.Text, ",", ".")
                Dim mt2 As String = Replace(num2.Text, ",", ".")

                If Len(mt) = 0 Then
                    mt = "0"
                End If

                If Len(mt2) = 0 Then
                    mt2 = "0"
                End If


                'προσθετα
                Dim S As String = ""
                For K As Integer = 0 To PROSUETA.Items.Count - 1
                    If PROSUETA.Items(K).Checked = True Then
                        S = S + PROSUETA.Items(K).SubItems(1).Text + ","
                    End If
                Next






                ExecuteSQLQuery("insert into EIDH (ONO,TIMH,NUM2,KATHG,CH1,CH2,PICTURE) VALUES ('" + ono.Text + "'," + mt + "," + mt2 + "," + MKATHG + ",'" + ckathg.Text + "','" + S + "','" + tPicture.Text + "')", dtt)
                Me.Text = "Αποθηκεύτηκε " + ono.Text

            End If
            If p_Table = "XAR1" Then
                ExecuteSQLQuery("insert into XAR1 (ONO) VALUES ('" + ONO.Text + "')", dtt)
            End If

            If p_Table = "ERGAZ" Then
                ExecuteSQLQuery("insert into ERGAZ (EPO) VALUES ('" + ONO.Text + "')", dtt)
            End If


            If p_Table = "TABLES" Then
                ExecuteSQLQuery("insert into TABLES (ONO) VALUES ('" + ONO.Text + "')", dtt)
            End If

            nea.Enabled = True

        Else ' ΔΙΟΡΘΩΣΗ
            Dim dtt As New DataTable
            If p_Table = "KATHG" Then
                ExecuteSQLQuery("UPDATE KATHG SET ONO='" + ono.Text + "' WHERE ID=" + KOD.Text, dtt)
                ExecuteSQLQuery("UPDATE KATHG SET PICTURE='" + tPicture.Text + "' WHERE ID=" + KOD.Text, dtt)
                ExecuteSQLQuery("UPDATE KATHG SET CH1='" + timh.Text + "' WHERE ID=" + KOD.Text, dtt)
                ExecuteSQLQuery("UPDATE KATHG SET CH2='" + ckathg.Text + "' WHERE ID=" + KOD.Text, dtt)
            End If
            If p_Table = "EIDH" Then
                Dim MKATHG As String

                If InStr(CKATHG.Text, ";") = 0 Then
                    MKATHG = "0"
                Else
                    MKATHG = Split(CKATHG.Text, ";")(1)
                End If

                ExecuteSQLQuery("UPDATE EIDH SET CH1='" + ckathg.Text + "',ONO='" + ono.Text + "', TIMH=" + Replace(timh.Text, ",", ".") + ",KATHG=" + MKATHG + ",NUM2=" + Replace(num2.Text, ",", ".") + "  WHERE ID=" + KOD.Text, dtt)


                ExecuteSQLQuery("UPDATE EIDH SET PICTURE='" + tPicture.Text + "'  WHERE ID=" + KOD.Text, dtt)
                'προσθετα
                Dim S As String = ""
                For K As Integer = 0 To PROSUETA.Items.Count - 1
                    If PROSUETA.Items(K).Checked = True Then
                        S = S + PROSUETA.Items(K).SubItems(1).Text + ","
                    End If
                Next
                'ΕΝΗΜΕΡΩΝΩ ΤΑ ΠΡΟΟΣΘΕΤΑ
                ExecuteSQLQuery("UPDATE EIDH SET CH2='" + S + "'  WHERE ID=" + KOD.Text, dtt)




            End If
            If p_Table = "XAR1" Then
                ExecuteSQLQuery("UPDATE XAR1 SET ONO='" + ONO.Text + "' WHERE ID=" + KOD.Text, dtt)
            End If


            If p_Table = "ERGAZ" Then
                ExecuteSQLQuery("UPDATE ERGAZ SET EPO='" + ONO.Text + "' WHERE ID=" + KOD.Text, dtt)
            End If


            If p_Table = "TABLES" Then
                ExecuteSQLQuery("SELECT * FROM TABLES  WHERE ID=" + KOD.Text, dtt)
                Dim N1 As Integer = dtt(0)("KATEILHMENO")
                If N1 = 1 Then
                    MsgBox("Το τραπέζι είναι ανοιχτό." + Chr(13) + "Αδύνατη η μεταβολή")

                Else
                    ExecuteSQLQuery("UPDATE TABLES SET ONO='" + ono.Text + "' WHERE ID=" + KOD.Text, dtt)
                End If


            End If


        End If
        SAVE.Enabled = False
        delete.Enabled = True

        If F_EPANALAMBANOMENES = 1 Then

        Else
            KOD.Text = "0"
            ono.Text = ""
            timh.Text = ""
            num2.Text = ""
            XAR1.Text = ""
            XAR2.Text = ""
            tPROSUETA.Text = ""
            ckathg.Text = ""
        End If






        edit.Enabled = False




            ' LOAD_file("SELECT ONO,ID FROM " + p_Table, lv, 2)
        LIST_SHOW(0)

    End Sub

    Sub LIST_SHOW(ByVal categ As Long)
        If p_Table = "EIDH" Then
            If categ > 0 Then
                LOAD_file("SELECT ONO,ID,TIMH,NUM2,CH1 FROM " + p_Table + " where KATHG=" + Str(categ) + "  order by ONO", lv, 4)
            Else
                LOAD_file("SELECT ONO,ID,TIMH,NUM2,CH1 FROM " + p_Table + " where ONO LIKE '%" + TextBox1.Text + "%' order by ONO", lv, 4)
            End If
            'LOAD_file("SELECT ONO,ID,TIMH,NUM2,CH1 FROM " + p_Table + " where ONO LIKE '%" + TextBox1.Text + "%' order by ONO", lv, 4)
        ElseIf p_Table = "KATHG" Then
            LOAD_file("SELECT ONO,ID,CH1,CH2 FROM " + p_Table + " where ONO LIKE '%" + TextBox1.Text + "%'", lv, 2)
        ElseIf p_Table = "ERGAZ" Then
            LOAD_file("SELECT EPO,ID,TIMH,CKATHG FROM " + p_Table + " where EPO LIKE '%" + TextBox1.Text + "%'", lv, 2)
        Else
            LOAD_file("SELECT ONO,ID FROM " + p_Table + " where ONO LIKE '%" + TextBox1.Text + "%' ", lv, 2)
        End If
    End Sub



    Private Sub XARAKT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lv.Items.Clear()
        'lv.Columns(0).Text = "Κωδικός"
        lv.Columns(0).Text = "Ονομα"
        lv.Columns(1).Text = "ID"
        lv.Columns(0).Width = 900

        lv.Columns(2).Text = "ΤΙΜΗ"
        lv.Columns(3).Text = "ΚΑΤΗΓΟΡΙΑ"
        lv.Columns(4).Text = ""
        lv.Columns(5).Text = ""


        ltimh.Visible = False

        timh.Visible = False
        num2.Visible = False
        XAR1.Visible = False
        XAR2.Visible = False
        LIST_SHOW(0)
        ' LOAD_file("SELECT ONO,ID FROM XAR1", lv, 2)
    End Sub

    Private Sub extra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lv.Items.Clear()

        lv.Columns(0).Text = "Ονομα"
        lv.Columns(1).Text = "ID"
        lv.Columns(0).Width = 700

        lv.Columns(2).Text = ""  'Κωδικός"
        lv.Columns(3).Text = ""
        lv.Columns(4).Text = ""
        lv.Columns(5).Text = ""


        ltimh.Visible = False

        timh.Visible = False
        num2.Visible = False
        XAR1.Visible = False
        XAR2.Visible = False

        LIST_SHOW(0)
        ' LOAD_file("SELECT ONO,ID FROM XAR2", lv, 2)
    End Sub

    Private Sub eidos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lv.Items.Clear()

        lv.Columns(0).Text = "Ονομα"
        lv.Columns(1).Text = "ID"
        lv.Columns(0).Width = 700

        lv.Columns(2).Text = ""  ' Κωδικός"
        lv.Columns(3).Text = ""
        lv.Columns(4).Text = ""
        lv.Columns(5).Text = ""





        'LOAD_file("SELECT ONO,ID FROM EIDH", lv, 2)
        LIST_SHOW(0)
        ltimh.Visible = True

        timh.Visible = True
        num2.Visible = True

        XAR1.Visible = True
        XAR2.Visible = True
        'FILLlistBox("select ONO+SPACE(200) AS ONOMA, ID  FROM KATHG ", ckathg)
        'IsConnected1("select ONO+SPACE(200) + ';' + Str(ID)  FROM KATHG ", False)
        ' Dim K As Integer = 0
        ' While (myDR.Read())
        ' K = K + 1
        ' CKATHG.Items.Add(myDR(K - 1))
        ' End While



       

















    End Sub

    Private Sub lv_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lv.MouseClick
        '  fid = lv.SelectedItems(0).SubItems(1).Text()


        If lv.SelectedItems.Count > 0 Then
            fid = lv.SelectedItems(0).SubItems(1).Text()
            editING()
            edit.Enabled = True
        End If
        ''
    End Sub

    

    Private Sub editING()

        Dim table As String = ""


        Dim DTT As New DataTable


        If p_Table = "KATHG" Then
            fid = lv.SelectedItems(0).SubItems(1).Text()

            ExecuteSQLQuery("select * from " + p_Table + " WHERE ID=" + Str(fid), DTT)
            If DTT.Rows.Count > 0 Then
                ONO.Text = DTT(0)("ono").ToString
                KOD.Text = fid
                timh.Text = DTT(0)("CH1").ToString
                ckathg.Text = DTT(0)("CH2").ToString


                If IsDBNull(DTT(0)("PICTURE")) Then
                    tPicture.Text = ""
                Else
                    tPicture.Text = DTT(0)("PICTURE").ToString
                End If





                ' tPicture.Text = DTT(0)("PICTURE").ToString
            End If
        End If


        If p_Table = "ERGAZ" Then

            fid = lv.SelectedItems(0).SubItems(1).Text()

            ExecuteSQLQuery("select * from " + p_Table + " WHERE ID=" + Str(fid), DTT)
            If DTT.Rows.Count > 0 Then
                ono.Text = DTT(0)("epo").ToString
                KOD.Text = fid
            End If


        End If


        If p_Table = "TABLES" Then

            fid = lv.SelectedItems(0).SubItems(1).Text()

            ExecuteSQLQuery("select * from " + p_Table + " WHERE ID=" + Str(fid), DTT)
            If DTT.Rows.Count > 0 Then
                ono.Text = DTT(0)("ONO").ToString
                KOD.Text = fid
            End If



        End If


        If p_Table = "EIDH" Then
            fid = lv.SelectedItems(0).SubItems(1).Text()
            table = "EIDH"
            ExecuteSQLQuery("select ONO,ISNULL(TIMH,0) AS TIMH,ISNULL(NUM2,0) AS NUM2,ISNULL(KATHG,0) AS KATHG,ISNULL(CH1,'') AS CH1,ISNULL(CH2,'') AS CH2,ISNULL(PICTURE,'') AS PICTURE from " + p_Table + " WHERE ID=" + Str(fid), DTT)


            If DTT.Rows.Count > 0 Then
                ONO.Text = DTT(0)("ono").ToString
                KOD.Text = fid

                If IsDBNull(DTT(0)("TIMH")) Then

                Else
                    TIMH.Text = DTT(0)("TIMH")
                End If

                If IsDBNull(DTT(0)("NUM2")) Then

                Else
                    num2.Text = DTT(0)("NUM2")
                End If





                If IsDBNull(DTT(0)("KATHG")) Then

                Else
                    ckathg.Text = DTT(0)("kathg")
                End If


                If IsDBNull(DTT(0)("PICTURE")) Then
                    tPicture.Text = ""
                Else
                    tPicture.Text = DTT(0)("PICTURE").ToString
                End If





                If IsDBNull(DTT(0)("CH2")) Then

                Else
                    tPROSUETA.Text = DTT(0)("CH2")
                End If
                tPROSUETA.Visible = True




            End If



        End If
        If p_Table = "XAR1" Then
            fid = lv.SelectedItems(0).SubItems(1).Text()
            table = "XAR1"
            ExecuteSQLQuery("select * from " + table + " WHERE ID=" + Str(fid), DTT)



            If DTT.Rows.Count > 0 Then
                ONO.Text = DTT(0)("ono").ToString
                KOD.Text = fid
            End If



        End If

       
        If p_Table = "" Then
            Exit Sub
        End If


        If p_Table = "EIDH" Then

            '=======================================================
            ' PROSUETA.HideSelection = True
            'PROSUETA.FullRowSelect = True
            PROSUETA.CheckBoxes = True
            ' PROSUETA.OwnerDraw = True
            PROSUETA.Items.Clear()

            ' PROSUETA.SmallImageList = ImgList 'Set the ListView`s SmallImageList to the ImgList
            Dim DTT2 As New DataTable
            ExecuteSQLQuery("SELECT * FROM XAR1", DTT2)
            'This code is just to add a few test items to the listview
            '  Dim dif() As String = {"Too Difficult", "Relatively Easy", "Extremely Easy", "Relatively Easy"}
            Dim result() As String = Split(tPROSUETA.Text, ",")

            For x As Integer = 0 To DTT2.Rows.Count - 1

                Dim lvi As New ListViewItem(DTT2(x)("ONO").ToString)
                lvi.SubItems.Add(DTT2(x)("ID").ToString)
                'lvi.SubItems.Add("Number")
                'lvi.SubItems.Add(dif(x))
                For K11 As Integer = 0 To result.Length - 1
                    If result(K11) = DTT2(x)("ID").ToString Then
                        lvi.Checked = True
                    End If
                Next






                PROSUETA.Items.Add(lvi)
            Next
            PROSUETA.Columns(0).Width = 200
        End If
    End Sub

    Private Sub insert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'KOD.Text = "0"
        'ONO.Text = ""
        'TIMH.Text = ""
        'XAR1.Text = ""
        'XAR2.Text = ""
    End Sub

    Private Sub arxeia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If p_Table = "EIDH" Then
            ' LOAD_file("SELECT ONO,ID,TIMH,CH1 FROM " + p_Table, lv, 2)
           
            CreateMyListView()
            timh.Visible = True
            num2.Visible = True
            ltimh.Visible = True
            tPicture.Visible = True
            lPicture.Visible = True


        Else

            timh.Visible = False
            num2.Visible = False
            ltimh.Visible = False
            CKATHG.Visible = False
            tPROSUETA.Visible = False
            ltimh.Visible = False
            Label3.Visible = False
            Label4.Visible = False
            If p_Table = "KATHG" Then
                tPicture.Visible = True
                lPicture.Visible = True

                timh.Visible = True

                ltimh.Visible = True
                ltimh.Text = "ΣΕΙΡΑ ΕΜΦΑΝΙΣΗΣ"

                Label3.Visible = True

                Label3.Text = "ΕΚΤΥΠΩΤΗΣ 1-3"
                ckathg.Visible = True

            End If

            'LOAD_file("SELECT ONO,ID FROM " + p_Table, lv, 2)
        End If
        lv.Columns(0).Text = "Ονομα"
        lv.Columns(0).Width = 300
        lv.Columns(1).Text = "ID"
        LIST_SHOW(0)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub

    Private Sub delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delete.Click

        If lv.SelectedItems.Count = 0 Then
            fid = 0
            Exit Sub
        Else
            fid = lv.SelectedItems(0).SubItems(1).Text()
        End If



        fid = lv.SelectedItems(0).SubItems(1).Text()
        Dim DTT As New DataTable

        If p_Table = "TABLES" Then
            ExecuteSQLQuery("SELECT * FROM TABLES  WHERE ID=" + KOD.Text, DTT)
            Dim N1 As Integer = DTT(0)("KATEILHMENO")
            If N1 = 1 Then
                MsgBox("Το τραπέζι είναι ανοιχτό." + Chr(13) + "Αδύνατη η ΔΙΑΓΡΑΦΗ")
                Exit Sub

            End If

        End If





        ExecuteSQLQuery("DELETE  from " + p_Table + " WHERE ID=" + Str(fid), DTT)
        LIST_SHOW(0)
        ono.Text = ""
        timh.Text = ""
        num2.Text = ""
        ckathg.Text = ""
        tPROSUETA.Text = ""

        'LOAD_file("SELECT ONO,ID FROM " + p_Table, lv, 2)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Create a new ListView control.

    End Sub


    Private Sub listView1_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        ' MsgBox(listView1.SelectedItems.Item(0).Text)
        ckathg.Text = listView1.SelectedItems.Item(0).Text
        LIST_SHOW(Val(Split(ckathg.Text, ";")(1)))

    End Sub



    Sub CreateMyListView()
        listView1.Bounds = New Rectangle(New Point(10, 480), New Size(380, 400))
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
        ExecuteSQLQuery("select ONO+SPACE(2)+';'+str(ID) AS ONOMA, ID,PICTURE FROM KATHG order by ID ", DTT)







        Dim Items As New List(Of ListViewItem)
        ' Dim RancomClass As New Random()






        For i As Integer = 0 To DTT.Rows.Count - 1
            '// Text and Images index
            Dim item As New ListViewItem(DTT(i)(0).ToString, i) 'RancomClass.Next(0, 10) Mod 2)
            Items.Add(item)
        Next
        listView1.Items.AddRange(Items.ToArray)

        ' help
        ' Add the items to the ListView.
        ' listView1.Items.AddRange(New ListViewItem() {item1, item2, item3})


        ' Create ImageList objects.
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(64, 64)
        Dim strPath As String = MyPath(Application.StartupPath)


        ' Initialize the ImageList objects with bitmaps.
        ' imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        ' imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        Try
            For i As Integer = 0 To DTT.Rows.Count - 1
                imgList.Images.Add(Bitmap.FromFile(DTT(i)("PICTURE").ToString))
            Next
        Catch ex As Exception

        End Try





        'Assign the ImageList objects to the ListView.
        listView1.LargeImageList = imgList

        ' Add the ListView to the control collection.
        Me.Controls.Add(listView1)
        '// start event handling at any time during program execution.
        AddHandler listView1.Click, AddressOf listView1_Click

    End Sub 'CreateMyListView

    Private Sub nea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nea.Click

        nea.Enabled = False
        ono.Enabled = True
        timh.Enabled = True
        num2.Enabled = True
        ono.Focus()
        edit.Enabled = False
        delete.Enabled = False
        SAVE.Enabled = True


        ckathg.Enabled = True


        If p_Table = "EIDH" Then
            If F_EPANALAMBANOMENES = -1 Then
                Dim ANS As Integer = MsgBox("επαναλαμβανόμενα είδη;", MsgBoxStyle.YesNo)
                If ANS = MsgBoxResult.Yes Then
                    F_EPANALAMBANOMENES = 1
                Else
                    F_EPANALAMBANOMENES = 0
                End If
            End If

            If F_EPANALAMBANOMENES = 0 Then

                KOD.Text = "0"
                ono.Text = ""
                timh.Text = ""
                num2.Text = ""
                XAR1.Text = ""
                XAR2.Text = ""
                tPROSUETA.Text = ""
                ckathg.Text = ""





            End If

            '=======================================================
            ' PROSUETA.HideSelection = True
            'PROSUETA.FullRowSelect = True
            PROSUETA.CheckBoxes = True
            ' PROSUETA.OwnerDraw = True
            PROSUETA.Items.Clear()

            ' PROSUETA.SmallImageList = ImgList 'Set the ListView`s SmallImageList to the ImgList
            Dim DTT2 As New DataTable
            ExecuteSQLQuery("SELECT * FROM XAR1", DTT2)
            'This code is just to add a few test items to the listview
            '  Dim dif() As String = {"Too Difficult", "Relatively Easy", "Extremely Easy", "Relatively Easy"}

            For x As Integer = 0 To DTT2.Rows.Count - 1

                Dim lvi As New ListViewItem(DTT2(x)("ONO").ToString)
                lvi.SubItems.Add(DTT2(x)("ID").ToString)
                'lvi.SubItems.Add("Number")
                'lvi.SubItems.Add(dif(x))
                If InStr(tPROSUETA.Text, DTT2(x)("ID").ToString + ",") > 0 Then
                    lvi.Checked = True
                End If
                PROSUETA.Items.Add(lvi)
            Next
            PROSUETA.Columns(0).Width = 200


        Else
            KOD.Text = "0"
            ono.Text = ""
            timh.Text = ""
            num2.Text = ""
            XAR1.Text = ""
            XAR2.Text = ""
            tPROSUETA.Text = ""
            ckathg.Text = ""
            'nea.Enabled = False
            'ono.Enabled = True
            'timh.Enabled = True
            'num2.Enabled = True
            'ono.Focus()
            'edit.Enabled = False
            'delete.Enabled = False
            'SAVE.Enabled = True


            'ckathg.Enabled = True

        End If


    End Sub

    Private Sub edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles edit.Click
        'nea.Enabled = False
        ono.Enabled = True
        timh.Enabled = True
        num2.Enabled = True
        ono.Focus()


        ckathg.Enabled = True
        SAVE.Enabled = True


    End Sub

    Private Sub lv_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv.SelectedIndexChanged

    End Sub

    Private Sub lPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lPicture.Click

    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OpenFileDialog1.ShowDialog()
        tPicture.Text = OpenFileDialog1.FileName

    End Sub

    Private Sub ono_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ono.GotFocus
        '------------------------
        Try
            Process.Start("C:\DEBUG\tabtip.EXE")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ono_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ono.TextChanged

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ' Dim dtt As New DataTable

        ' ExecuteSQLQuery("select * from " + p_Table + " WHERE ID=" + Str(fid), dtt)
        LIST_SHOW(0)
    End Sub
End Class