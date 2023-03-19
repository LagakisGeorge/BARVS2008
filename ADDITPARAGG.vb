Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6




Public Class ADDITPARAGG

    Dim categ_images(100)
    Dim categ_names(100)


    Private FFILE As String = "C:\MERCVB\PARAGG.TXT"

    Dim vv As New Printer

    Private LISTVIEW1 As New ListView
    Private EIDHVIEW As New ListView
    Private A_EIDH(200, 2) As String
    Structure EIDOS
        Dim ID As Integer
        Dim TIMH As Single
        Dim ONOMA As String
        Dim PROSU As String
        Dim paketo As Single
    End Structure

    Dim EIDOS_LIST(200) As EIDOS

    Private mSTHLH As String


    Public Property p_Trapezi() As String
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


    Private m_IDPARAGG As String
    Public Property p_IDPARAGG() As Long
        Get
            Return m_IDPARAGG
        End Get
        Set(ByVal Value As Long)
            ' If Value < 1 Or Value > 12 Then
            ' Error processing for invalid value. 
            'Else
            m_IDPARAGG = Value
            'End If
        End Set
    End Property






    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub



    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frUpdate = False
        Me.Dispose()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err
        KATHG.Visible = False
        EIDH.Visible = False

        CreateMyListView1()
        'CreateEIDHListView()
        ' EIDHVIEW.Bounds = EIDH.Bounds
        ' Add the ListView to the control collection.
        Me.Controls.Add(EIDHVIEW)
        '// start event handling at any time during program execution.
        AddHandler EIDHVIEW.Click, AddressOf EIDHView_Click


        ListParagg.Columns(0).Text = "ΟΝΟΜΑ"
        ListParagg.Columns(1).Text = "ΠΟΣΟΤΗΤΑ"
        ListParagg.Columns(2).Text = "ΤΙΜΗ"
        ListParagg.Columns(0).Width = 200
        ' HDH_YPARXOYSA
        ' HDH_YPARXOYSA.HideSelection = True
        ' HDH_YPARXOYSA.FullRowSelect = True
        HDH_YPARXOYSA.CheckBoxes = True
        'HDH_YPARXOYSA.OwnerDraw = True



        Dim DTT As New DataTable
        ExecuteSQLQuery("SELECT * FROM PARAGG WHERE IDPARAGG=" + Str(p_IDPARAGG), DTT) 'ENERGOS=1 AND TRAPEZI='" + p_Trapezi + "'"
        Dim SYN As Single
        Dim X As Integer = 0
        HDH_YPARXOYSA.Columns(2).TextAlign = HorizontalAlignment.Right
        HDH_YPARXOYSA.Columns(3).TextAlign = HorizontalAlignment.Right
        For X = 0 To DTT.Rows.Count - 1
            Dim lvi As New ListViewItem(DTT(X)("ONO").ToString + ";" + Str(DTT(X)("ID")))
            lvi.SubItems.Add(DTT(X)("POSO").ToString)
            'lvi.SubItems.Add(DTT(X)("PROSUETA").ToString)
            lvi.SubItems.Add(DTT(X)("TIMH").ToString)
            lvi.SubItems.Add(Format(DTT(X)("POSO") * DTT(X)("TIMH"), "###0.00"))
            lvi.SubItems.Add(DTT(X)("ID").ToString)


            SYN = SYN + DTT(X)("POSO") * DTT(X)("TIMH")

            HDH_YPARXOYSA.Items.Add(lvi)
        Next
        HDH_YPARXOYSA.Columns(3).Text = Format(SYN, "###0.00") '+ " συνολο"
        'Dim lvi3 As New ListViewItem("")
        'HDH_YPARXOYSA.Items.Add(lvi3)

        'Dim lvi2 As New ListViewItem("Σύνολο")
        'lvi2.SubItems.Add("")
        'lvi2.SubItems.Add("")
        ''lvi2.SubItems.Add("")
        'lvi2.SubItems.Add(Format(SYN, "###0.00"))
        'HDH_YPARXOYSA.Items.Add(lvi2)


        HDH_YPARXOYSA.Columns(0).Width = 200

        HDH_YPARXOYSA.Columns(0).Text = "ΟΝΟΜΑ"
        HDH_YPARXOYSA.Columns(1).Text = "ΠΟΣΟΤΗΤΑ"
        HDH_YPARXOYSA.Columns(2).Text = "ΤΙΜΗ"










        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proc As New System.Diagnostics.Process()
    End Sub

    Private Sub ClickButton(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles B1.Click, _
  B2.Click, B3.Click, B4.Click, B5.Click, B6.Click, _
          B7.Click, B8.Click, B9.Click, B0.Click, Button1.Click, Button2.Click

        Dim btn As Button
        btn = CType(sender, Button)


        Dim D As String = btn.Text
        Dim F As String
        F = OTONH.Text






        If Mid(D, 1, 1) = "<" Then
            If Len(F) > 1 Then
                F = Mid(F, 1, Len(F) - 1)
            Else
                F = ""
            End If

        Else

            If D = "." Then
                If InStr(F, ".") > 0 Then D = ""
            End If

            F = F + D


        End If




        OTONH.Text = F




        'Dim i As Integer = Val(Mid(btn.Name, InStr(btn.Name, "_") + 1, 2))
        'Dim pos As Single = 1

    End Sub













    Private Sub listView1_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        ' MsgBox(listView1.SelectedItems.Item(0).Text)
        'CKATHG.Text = LISTVIEW1.SelectedItems.Item(0).Text
        '' EIDHVIEW = Nothing
        '' EIDHVIEW = New ListView

        'CreateEIDHListView()

        ' MsgBox(listView1.SelectedItems.Item(0).Text)
        CKATHG.Text = LISTVIEW1.SelectedItems.Item(0).Text.Split(";")(1)
        ' EIDHVIEW = Nothing
        ' EIDHVIEW = New ListView


        Dim mIcon As String = "default.png"

        For K As Integer = 0 To 100
            If CKATHG.Text = categ_names(K) Then
                mIcon = categ_images(K)
                Exit For
            End If
        Next







        For K As Integer = 0 To LISTVIEW1.Items.Count - 1
            LISTVIEW1.Items(K).BackColor = Color.White 'Then
        Next

        LISTVIEW1.SelectedItems(0).BackColor = Color.Red





        CreateEIDHListView(mIcon)


    End Sub



    Sub CreateMyListView1()

        LISTVIEW1.Bounds = KATHG.Bounds ' New Rectangle(New Point(10, 10), New Size(380, 400))
        LISTVIEW1.Items.Clear()

        'CreateMyListView()
        'AddHandler listView1.Click, AddressOf listView1_Click


        'listView1.Bounds = New Rectangle(New Point(10, 10), New Size(420, 400))

        ' Set the view to show details.
        With LISTVIEW1
            ' Set ListView view mode to show Large Icons
            .View = View.SmallIcon
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

        LISTVIEW1.Columns.Add("Column 1", -2, HorizontalAlignment.Left)
        LISTVIEW1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        LISTVIEW1.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
        ' / --------------------------------------------------------------------------------
        ' / @Run Time



        Dim DTT As New DataTable
        ExecuteSQLQuery("select ONO+';'+STR(ID) AS ONO, ID ,PICTURE FROM KATHG", DTT)







        Dim Items As New List(Of ListViewItem)
        Dim RancomClass As New Random()
        For i As Integer = 0 To DTT.Rows.Count - 1
            '// Text and Images index
            ' Dim N1 As Integer = DTT(i)("KATEILHMENO")
            Dim item As New ListViewItem(DTT(i)(0).ToString, i) ' RancomClass.Next(0, 10) Mod 2)
            Items.Add(item)
        Next
        LISTVIEW1.Items.AddRange(Items.ToArray)

        ' Create ImageList objects.
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(40, 40)  '40
        Dim strPath As String = MyPath(Application.StartupPath)
        'Try
        For i As Integer = 0 To DTT.Rows.Count - 1
            Try
                imgList.Images.Add(Bitmap.FromFile(DTT(i)("PICTURE").ToString))
                categ_images(i) = DTT(i)("PICTURE").ToString
            Catch ex As Exception
                imgList.Images.Add(Bitmap.FromFile("default.png"))
                categ_images(i) = "default.png"

            End Try
            categ_names(i) = DTT(i)("ono").ToString
        Next
        'Catch ex As Exception

        'End Try


        ' Initialize the ImageList objects with bitmaps.
        'imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        'imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        'Assign the ImageList objects to the ListView.
        LISTVIEW1.SmallImageList = imgList

        ' Add the ListView to the control collection.
        Me.Controls.Add(LISTVIEW1)
        '// start event handling at any time during program execution.
        AddHandler LISTVIEW1.Click, AddressOf listView1_Click













        'LISTVIEW1.Bounds = KATHG.Bounds ' New Rectangle(New Point(10, 10), New Size(380, 400))
        'LISTVIEW1.Items.Clear()

        ''CreateMyListView()
        ''AddHandler listView1.Click, AddressOf listView1_Click


        ''listView1.Bounds = New Rectangle(New Point(10, 10), New Size(420, 400))

        '' Set the view to show details.
        'With LISTVIEW1
        '    ' Set ListView view mode to show Large Icons
        '    .View = View.SmallIcon
        '    .Cursor = Cursors.Hand
        '    .Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
        'End With

        '' / --------------------------------------------------------------------------------
        '' / BASIC THINKING ... Static ListView control
        '' Create items and sets of subitems for each item.
        ''Dim item1 As New ListViewItem("Table 1", 0)
        ''Dim item2 As New ListViewItem("Table 2", 1)
        ''Dim item3 As New ListViewItem("Table 3", 0)
        ''Dim item4 As New ListViewItem("Table 4", 0)
        ''Dim item5 As New ListViewItem("Table 5", 1)
        ''Dim item6 As New ListViewItem("Table 6", 1)
        ''Dim item7 As New ListViewItem("Table 7", 0)
        ''Add the items to the ListView.
        ''listView1.Items.AddRange(New ListViewItem() {item1, item2, item3, item4, item5, item6, item7})
        '' / --------------------------------------------------------------------------------

        'LISTVIEW1.Columns.Add("Column 1", -2, HorizontalAlignment.Left)
        'LISTVIEW1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        'LISTVIEW1.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
        '' / --------------------------------------------------------------------------------
        '' / @Run Time



        'Dim DTT As New DataTable
        'ExecuteSQLQuery("select ONO, ID,PICTURE FROM KATHG", DTT)







        'Dim Items As New List(Of ListViewItem)
        'Dim RancomClass As New Random()
        'For i As Integer = 0 To DTT.Rows.Count - 1
        '    '// Text and Images index
        '    ' Dim N1 As Integer = DTT(i)("KATEILHMENO")
        '    Dim item As New ListViewItem(DTT(i)(0).ToString, i) ' RancomClass.Next(0, 10) Mod 2)
        '    Items.Add(item)
        'Next
        'LISTVIEW1.Items.AddRange(Items.ToArray)

        '' Create ImageList objects.
        'Dim imgList As New ImageList()
        'imgList.ImageSize = New Size(64, 64)
        'Dim strPath As String = MyPath(Application.StartupPath)


        '' Initialize the ImageList objects with bitmaps.
        ''imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        ''imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        ''imgList.Images.Add(Bitmap.FromFile(strPath & "png\ΜΟΥΣΑΚΑΣ.jpg"))

        ''For i As Integer = 0 To DTT.Rows.Count - 1
        ''    If IsDBNull(DTT(i)("PICTURE")) Then
        ''        imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        ''    Else
        ''        If Len(DTT(i)("PICTURE").ToString) < 2 Then
        ''            imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        ''        Else
        ''            Try
        ''                imgList.Images.Add(Bitmap.FromFile(DTT(i)("PICTURE").ToString))
        ''            Catch ex As Exception
        ''                imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        ''            End Try

        ''        End If
        ''    End If

        ''Next

        'For i As Integer = 0 To DTT.Rows.Count - 1
        '    Try
        '        imgList.Images.Add(Bitmap.FromFile(DTT(i)("PICTURE").ToString))
        '        categ_images(i) = DTT(i)("PICTURE").ToString
        '    Catch ex As Exception
        '        imgList.Images.Add(Bitmap.FromFile("default.png"))
        '        categ_images(i) = "default.png"

        '    End Try
        '    categ_names(i) = DTT(i)("ono").ToString
        'Next


        ''Assign the ImageList objects to the ListView.
        'LISTVIEW1.LargeImageList = imgList

        '' Add the ListView to the control collection.
        'Me.Controls.Add(LISTVIEW1)
        ''// start event handling at any time during program execution.
        'AddHandler LISTVIEW1.Click, AddressOf listView1_Click

    End Sub 'CreateMyListView


    Sub CreateEIDHListView(ByVal micon As String)
        'Dim EIDHVIEW As New ListView
        EIDHVIEW.Bounds = EIDH.Bounds ' New Rectangle(New Point(10, 10), New Size(380, 400))
        EIDHVIEW.Items.Clear()

        'CreateMyListView()
        'AddHandler EIDHVIEW.Click, AddressOf EIDHVIEW_Click


        'EIDHVIEW.Bounds = New Rectangle(New Point(10, 10), New Size(420, 400))

        ' Set the view to show details.
        With EIDHVIEW
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
        'EIDHVIEW.Items.AddRange(New ListViewItem() {item1, item2, item3, item4, item5, item6, item7})
        ' / --------------------------------------------------------------------------------

        EIDHVIEW.Columns.Add("Column 1", -2, HorizontalAlignment.Left)
        EIDHVIEW.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        EIDHVIEW.Columns.Add("Column 3", -2, HorizontalAlignment.Left)
        EIDHVIEW.Columns.Add("Column 4", -2, HorizontalAlignment.Left)
        ' / --------------------------------------------------------------------------------
        ' / @Run Time



        Dim DTT As New DataTable
        ExecuteSQLQuery("select ONO, ID,TIMH,CH2,ISNULL(PICTURE,'') AS PICTURE,ISNULL(NUM2,0) AS NUM2 FROM EIDH WHERE KATHG = " + Trim(CKATHG.Text), DTT)




        A_EIDH.Initialize()



        Dim Items As New List(Of ListViewItem)
        Dim RancomClass As New Random()
        For i As Integer = 0 To DTT.Rows.Count - 1
            '// Text and Images index
            ''test
            'Dim str(2) As String
            'str(0) = DTT(i)(0).ToString  '"Rob Machy"
            'str(1) = "Rob2 Machy"
            'str(2) = "Rob2 Machy"
            'Dim itm2 As ListViewItem
            'itm2 = New ListViewItem(Str)
            'EIDHVIEW.Items.AddRange(itm2, 0)
            EIDOS_LIST(i).ID = DTT(i)("ID")
            EIDOS_LIST(i).TIMH = DTT(i)("TIMH")
            EIDOS_LIST(i).ONOMA = DTT(i)("ONO").ToString
            EIDOS_LIST(i).PROSU = (DTT(i)("CH2").ToString)
            EIDOS_LIST(i).paketo = DTT(i)("num2")
            ' Dim N1 As Integer = DTT(i)("KATEILHMENO")
            Dim item As New ListViewItem(DTT(i)(0).ToString, i) ' RancomClass.Next(0, 10) Mod 2)
            Items.Add(item)
        Next
        EIDHVIEW.Items.AddRange(Items.ToArray)

        ' Create ImageList objects.
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(64, 64)
        Dim strPath As String = MyPath(Application.StartupPath)
        For i As Integer = 0 To DTT.Rows.Count - 1
            If IsDBNull(DTT(i)("PICTURE")) Then
                imgList.Images.Add(Bitmap.FromFile(micon))
            Else
                If Len(DTT(i)("PICTURE").ToString) < 2 Then
                    imgList.Images.Add(Bitmap.FromFile(micon))
                Else
                    Try
                        imgList.Images.Add(Bitmap.FromFile(DTT(i)("PICTURE").ToString))
                    Catch ex As Exception
                        imgList.Images.Add(Bitmap.FromFile(micon))
                    End Try

                End If
            End If

        Next


        '' Initialize the ImageList objects with bitmaps.
        'imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        'imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        'Assign the ImageList objects to the ListView.
        EIDHVIEW.LargeImageList = imgList

        '' Add the ListView to the control collection.
        'Me.Controls.Add(EIDHVIEW)
        ''// start event handling at any time during program execution.
        'AddHandler EIDHVIEW.Click, AddressOf EIDHVIEW_Click

    End Sub 'CreateMyListView

    Private Sub EIDHView_Click(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim index As Integer = EIDHVIEW.SelectedIndices(0)

        '  EIDHVIEW.SelectedItems(0).BackColor = Color.White
        '  Else

        delete_button.Enabled = False

        EIDHVIEW.SelectedItems(0).BackColor = Color.Red
        OK_PROSU.Focus()
        '  End If



        Dim strI(5) As String

        Dim itm As ListViewItem

        strI(0) = EIDOS_LIST(index).ONOMA    'EIDHVIEW.SelectedItems.Item(0).Text '"Rob Machy"
        strI(1) = "1" 'Business Manager"  POSOTHTA
        If Val(p_Trapezi) > 900 Then
            strI(2) = EIDOS_LIST(index).paketo.ToString
        Else
            strI(2) = EIDOS_LIST(index).TIMH.ToString   ' "1" ' i.ToString
        End If

        strI(3) = "" 'EIDOS_LIST(index).ID.ToString

        strI(4) = "." 'DateTime.Now.AddHours(i).ToString("hh:mmTongue Tieds")
        strI(5) = "."

        itm = New ListViewItem(strI)

        ' PROSUETA.Items.Insert(0, itm)

        ListParagg.Items.Insert(0, itm)

        '===========================================================================

        'Dim Items As New List(Of ListViewItem)
        'Dim RancomClass As New Random()
        'For i As Integer = 0 To DTT.Rows.Count - 1
        '    '// Text and Images index
        '    ' Dim N1 As Integer = DTT(i)("KATEILHMENO")
        '    Dim item As New ListViewItem(DTT(i)(0).ToString, i) ' RancomClass.Next(0, 10) Mod 2)
        '    Items.Add(item)
        'Next
        'LISTVIEW1.Items.AddRange(Items.ToArray)

        Dim cPros As String = EIDOS_LIST(index).PROSU
        Dim result() As String = Split(cPros, ",")




        '===================================== PROSU 2 =========================================
        ' Create ImageList objects.
        PROSU2.Items.Clear()

        With PROSU2
            .View = View.LargeIcon
            .Cursor = Cursors.Hand
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
        End With
        PROSU2.Columns.Add("Column 1", -2, HorizontalAlignment.Left)
        PROSU2.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        ' / --------------------------------------------------------------------------------

        Dim Items As New List(Of ListViewItem)



        ' PROSU2V.Bounds = PROSU2.Bounds
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(40, 40)
        Dim strPath As String = MyPath(Application.StartupPath)
        Dim DTT2 As New DataTable
        'ExecuteSQLQuery("SELECT * FROM XAR1", DTT2)

        If Len(Trim(cPros)) = 0 Then
            cPros = "9999" ' ΓΙΑ  ΝΑ ΜΗΝ ΚΡΑΣΑΡΕΙ
        Else
            cPros = cPros
        End If


        If Mid(cPros, Len(cPros), 1) = "," Then
            cPros = Mid(cPros, 1, Len(cPros) - 1)
        End If
        ExecuteSQLQuery("SELECT * FROM XAR1 where ID IN (" + cPros + ")", DTT2)

        'Try
        For i As Integer = 0 To DTT2.Rows.Count - 1
            imgList.Images.Add(Bitmap.FromFile("default.png"))
            '   For K11 As Integer = 0 To result.Length - 1
            'If result(K11) = DTT2(i)("ID").ToString Then
            Try
                ' imgList.Images.Add(Bitmap.FromFile("default.png"))
                'imgList.Images.Add(Bitmap.FromFile(DTT2(i)("PICTURE").ToString))

                Dim item As New ListViewItem(DTT2(i)("ONO").ToString, i) ' RancomClass.Next(0, 10) Mod 2)
                Items.Add(item)


                'Dim newItem = New ListViewItem("Item Name", ImageList1.Images.IndexOfKey("Key"))
                'LISTVIEW1.Items.Add(newItm)



            Catch ex As Exception

            End Try
            'End If
            'Next
        Next
        PROSU2.Items.AddRange(Items.ToArray)

        PROSU2.LargeImageList = imgList

        TREXON_EIDOS.Text = EIDOS_LIST(index).ONOMA
        EIDHVIEW.Enabled = False

        bale1.Enabled = False
        bgale1.Enabled = False




        ' Me.Controls.Add(PROSU2V)
        '// start event handling at any time during program execution.
        ' AddHandler PROSU2V.Click, AddressOf PROSU2V_Click
        'Catch ex As Exception

        'End Try


        ' Initialize the ImageList objects with bitmaps.
        'imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        'imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        'Assign the ImageList objects to the ListView.
        ' LISTVIEW1.LargeImageList = imgList

        ' Add the ListView to the control collection.
        '  Me.Controls.Add(LISTVIEW1)
        '// start event handling at any time during program execution.
        '  AddHandler LISTVIEW1.Click, AddressOf listView1_Click



        '===================================================== σχεδιαζω τα προσθετα

        'PROSUETA.HideSelection = True
        'PROSUETA.FullRowSelect = True
        'PROSUETA.CheckBoxes = True
        'PROSUETA.OwnerDraw = True
        'PROSUETA.Items.Clear()
        '' PROSUETA.SmallImageList = ImgList 'Set the ListView`s SmallImageList to the ImgList
        'Dim DTT As New DataTable
        'ExecuteSQLQuery("SELECT * FROM XAR1", DTT)
        ''This code is just to add a few test items to the listview
        ''  Dim dif() As String = {"Too Difficult", "Relatively Easy", "Extremely Easy", "Relatively Easy"}

        'For x As Integer = 0 To DTT.Rows.Count - 1
        '    For K11 As Integer = 0 To result.Length - 1
        '        If result(K11) = DTT(x)("ID").ToString Then

        '            Dim lvi As New ListViewItem(DTT(x)("ONO").ToString)
        '            lvi.SubItems.Add(DTT(x)("ID").ToString)
        '            'lvi.SubItems.Add("Number")
        '            'lvi.SubItems.Add(dif(x))
        '            PROSUETA.Items.Add(lvi)
        '        End If
        '    Next
        '    'If InStr(cPros, DTT(x)("ID").ToString + ",") > 0 Then
        '    '    'lvi.Checked = True
        '    'End If
        'Next
        'PROSUETA.Columns(0).Width = 200
        ''================================================================

























        '' MsgBox(PROSUETA.SelectedItems.Item(0).Text)
        ''CKATHG.Text = PROSUETA.SelectedItems.Item(0).Text
        ''ListParagg.Items.Add(EIDHVIEW.SelectedItems.Item(0).Text)
        ''Dim i As Integer = EIDHVIEW.SelectedIndex
        'Dim index As Integer = EIDHVIEW.SelectedIndices(0)

        'Dim strI(4) As String

        'Dim itm As ListViewItem

        'strI(0) = EIDOS_LIST(index).ONOMA    'EIDHVIEW.SelectedItems.Item(0).Text '"Rob Machy"
        'strI(1) = "1" 'Business Manager"  POSOTHTA
        'strI(2) = EIDOS_LIST(index).TIMH.ToString   ' "1" ' i.ToString
        'strI(3) = EIDOS_LIST(index).ID.ToString

        'strI(4) = "." 'DateTime.Now.AddHours(i).ToString("hh:mmTongue Tieds")

        'itm = New ListViewItem(strI)

        '' PROSUETA.Items.Insert(0, itm)

        'ListParagg.Items.Insert(0, itm)





        ''=======================================================
        'Dim cPros As String = EIDOS_LIST(index).PROSU
        'PROSUETA.HideSelection = True
        'PROSUETA.FullRowSelect = True
        'PROSUETA.CheckBoxes = True
        'PROSUETA.OwnerDraw = True
        'PROSUETA.Items.Clear()

        '' PROSUETA.SmallImageList = ImgList 'Set the ListView`s SmallImageList to the ImgList
        'Dim DTT As New DataTable
        'ExecuteSQLQuery("SELECT * FROM XAR1", DTT)
        ''This code is just to add a few test items to the listview
        ''  Dim dif() As String = {"Too Difficult", "Relatively Easy", "Extremely Easy", "Relatively Easy"}



        'Dim result() As String = Split(cPros, ",")
        'For x As Integer = 0 To DTT.Rows.Count - 1
        '    For K11 As Integer = 0 To result.Length - 1
        '        If result(K11) = DTT(x)("ID").ToString Then

        '            Dim lvi As New ListViewItem(DTT(x)("ONO").ToString)
        '            lvi.SubItems.Add(DTT(x)("ID").ToString)
        '            'lvi.SubItems.Add("Number")
        '            'lvi.SubItems.Add(dif(x))
        '            PROSUETA.Items.Add(lvi)



        '        End If
        '    Next


        '    'If InStr(cPros, DTT(x)("ID").ToString + ",") > 0 Then
        '    '    'lvi.Checked = True


        '    'End If

        'Next



















        'For x As Integer = 0 To DTT.Rows.Count - 1
        '    Dim lvi As New ListViewItem(DTT(x)("ONO").ToString)
        '    If InStr(cPros, DTT(x)("ID").ToString + ",") > 0 Then
        '        lvi.SubItems.Add(DTT(x)("ID").ToString)
        '        'lvi.SubItems.Add("Number")
        '        'lvi.SubItems.Add(dif(x))
        '        PROSUETA.Items.Add(lvi)
        '    End If

        'Next
        '  PROSUETA.Columns(0).Width = 200
    End Sub



    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles delete_button.Click

        If ListParagg.Items.Count = 0 Then
            Exit Sub
        End If

        If ListParagg.SelectedItems.Count > 0 Then
            ListParagg.Items.Remove(ListParagg.SelectedItems.Item(0))
        End If


    End Sub




    Private Sub PROSUETA_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs)
        e.DrawDefault = True
    End Sub

    'Private Sub PROSUETA_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs)
    '    Using txtbrsh As New SolidBrush(e.SubItem.ForeColor)
    '        If PROSUETA.SelectedIndices.Contains(e.ItemIndex) And PROSUETA.Focused Then
    '            e.Graphics.FillRectangle(New SolidBrush(Color.FromKnownColor(KnownColor.Highlight)), e.Bounds)
    '            txtbrsh.Color = Color.White
    '        End If
    '        ' If e.Item.SubItems(3) Is e.SubItem Then
    '        'e.DrawDefault = False
    '        'Using sf As New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap, .Trimming = StringTrimming.EllipsisCharacter}
    '        '    If e.SubItem.Text = "Extremely Easy" Then
    '        '        e.Graphics.DrawImage(ImgList.Images(0), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height)
    '        '    End If
    '        '    Dim rb As New Rectangle(e.Bounds.X + e.Bounds.Height, e.Bounds.Y, e.Bounds.Width - e.Bounds.Height, e.Bounds.Height)
    '        '    e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, txtbrsh, rb, sf)
    '        'End Using
    '        ' Else
    '        e.DrawDefault = True
    '        'End If
    '    End Using
    'End Sub



















    Private Sub SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE.Click
        If HDH_YPARXOYSA.Visible = False Then
            CREATE_NEA_PARAGGELIA()
            Exit Sub
        End If

        Dim DT As New DataTable
        'ExecuteSQLQuery("SELECT ARITMISI FROM ARITMISI", DT)
        'Dim N As Integer = DT(0)(0) + 1
        'ExecuteSQLQuery("UPDATE ARITMISI SET ARITMISI=ARITMISI+1", DT)


        ' = "Posiflex"

        If ListParagg.Items.Count = 0 Then

            Me.Close()
            Exit Sub

        End If





        vv.FontSize = 14
        vv.FontBold = True


        If Val(p_Trapezi) > 900 Then
            vv.Print("*** ΠΑΚΕΤΟ ***")
            vv.Print(" ΠΑΚΕΤΟ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))

        Else
            vv.Print("ΤΡΑΠΕΖΙ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))
        End If
        vv.Print("===========")



        Dim c2 As String = ""
        For K As Integer = 0 To ListParagg.Items.Count - 1


            Dim MDATE As String
            If InStr(gCONNECT, "MDB") > 0 Then
                MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
            Else
                MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
            End If

            ' ExecuteSQLQuery("INSERT INTO PARAGGMASTER (TRAPEZI,HME,IDBARDIA,CH1) VALUES ('" + p_Trapezi + "'," + MDATE + "," + Str(gBardia) + ",'" + Format(Now(), "hh:mm") + "' )", DT)
            'ExecuteSQLQuery("UPDATE PARAGGMASTER SET CH2='" + Format(Now(), "hh:mm") + "',AJIA=" + SS + ",TROPOS=" + F.LoginName + " WHERE ID=" + p_IDPARAGG, DT)


            ''ΠΑΕΙ ΝΑ ΚΑΝΕΙ ΑΚΥΡΩΣΗ--
            ''ΠΡΕΠΕΙ ΝΑ ΒΕΒΑΙΩΘΩ ΟΤΙ ΥΠΑΡΧΕΙ ΝΑ ΤΟ ΑΚΥΡΩΣΩ
            'If nNull(ListParagg.Items(K).SubItems(1).Text) < 0 Then
            '    ExecuteSQLQuery("SELECT SUM(POSO) FROM PARAGG WHERE IDPARAGG=" + Str(p_IDPARAGG) + "AND ONO='" + ListParagg.Items(K).SubItems(0).Text + "'", DT)
            '    vv.Print("******* ΑΚΥΡΩΣΗ **********")
            'End If





            Dim SQL As String = ""
            SQL = "INSERT INTO PARAGG "
            SQL = SQL + "(IDPARAGG,TRAPEZI,KOD,POSO,TIMH,HME,ONO,PROSUETA) VALUES "
            SQL = SQL + "(" + Str(p_IDPARAGG) + ",'" + p_Trapezi + "','" + ListParagg.Items(K).SubItems(3).Text + "'," ' TABLE,KOD
            SQL = SQL + Replace(ListParagg.Items(K).SubItems(1).Text, ",", ".") + "," + Replace(ListParagg.Items(K).SubItems(2).Text, ",", ".") + "," + MDATE + ","  'POSO , TIMH , HME
            SQL = SQL + "'" + ListParagg.Items(K).SubItems(0).Text + "','" + ListParagg.Items(K).SubItems(4).Text + "')" ' ONO , PROSUETA
            ExecuteSQLQuery(SQL, DT)
            'TYPVNV TO EIDOS

            If nNull(ListParagg.Items(K).SubItems(1).Text) > 1 Then
                vv.Print(ListParagg.Items(K).SubItems(1).Text + " X ")
            End If

            If nNull(ListParagg.Items(K).SubItems(1).Text) < 0 Then
                vv.Print("******* ΑΚΥΡΩΣΗ **********")
            End If


            vv.Print(ListParagg.Items(K).SubItems(0).Text)
            c2 = ListParagg.Items(K).SubItems(3).Text
            'vv.Print(Split(C2, ",")(0))


            If Len(c2) > 1 Then
                c2 = Mid(c2, 1, Len(c2) - 1)  ' ΝΑ ΦΑΩ ΤΟ ΤΕΛΕΥΤΑΙΟ ,  1,2,3, => 1,2,3
            End If


            ' Split the string on the backslash character.
            Dim parts As String() = c2.Split(New Char() {","c})

            ' Loop through result strings with For Each.
            Dim part As String
            For Each part In parts
                'Console.WriteLine(part)
                vv.Print("*" + part)
            Next


            If Len(Trim(ListParagg.Items(K).SubItems(4).Text)) > 0 Then
                vv.Print("*" + Trim(ListParagg.Items(K).SubItems(4).Text))
            End If

            vv.Print("-------------")



        Next

        ListParagg.Items.Clear()


        '' ΕΠΙΣΤΡΟΦΕΣ
        'For K As Integer = 0 To HDH_YPARXOYSA.Items.Count - 1
        '    If HDH_YPARXOYSA.Items(K).Checked = True Then
        '        Dim SQL As String = ""
        '        SQL = "DELETE FROM PARAGG WHERE ID=" + HDH_YPARXOYSA.Items(K).SubItems(4).Text
        '        ExecuteSQLQuery(SQL, DT)
        '        'TYPVNV TO EIDOS EPISTROFH
        '        vv.Print("******* ΑΚΥΡΩΣΗ **********")

        '        vv.Print(HDH_YPARXOYSA.Items(K).SubItems(0).Text)

        '    End If
        'Next


        vv.EndDoc()



        '   ExecuteSQLQuery("UPDATE TABLES SET KATEILHMENO=1,IDPARAGG=" + Str(N) + " WHERE ONO='" + p_Trapezi + "'", DT)



        ' ExecuteSQLQuery("UPDATE TABLES SET KATEILHMENO=1 WHERE ONO='" + p_Trapezi + "'", DT)

        Me.Close()




        'ExecuteSQLQuery(SQL, DT)
        '  ExecuteSQLQuery("INSERT INTO PARAGG (HME) VALUES (#01/18/2018#)", DT)

    End Sub
    Sub CREATE_NEA_PARAGGELIA()



        If ListParagg.Items.Count = 0 Then
            Me.Close()
            Exit Sub

        End If






        Dim DT As New DataTable

        Dim printer As New myPrinter
        printer.ektypvths = "Posiflex"
        Dim MDATE As String
        If InStr(gCONNECT, "MDB") > 0 Then
            MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
        Else
            MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
        End If

        ExecuteSQLQuery("INSERT INTO PARAGGMASTER (TRAPEZI,HME,IDBARDIA,CH1) VALUES ('" + p_Trapezi + "'," + MDATE + "," + Str(gBardia) + ",'" + Format(Now(), "hh:mm") + "' )", DT)
        'ExecuteSQLQuery("UPDATE PARAGGMASTER SET CH2='" + Format(Now(), "hh:mm") + "',AJIA=" + SS + ",TROPOS=" + F.LoginName + " WHERE ID=" + p_IDPARAGG, DT)

        ExecuteSQLQuery("SELECT MAX(ID) FROM PARAGGMASTER", DT)
        Dim N As Integer = DT(0)(0)
        Dim pr As String = ""



        'Dim FFILE As String = "C:\MERCVB\PARAGG.TXT"
        If File.Exists(FFILE) Then
            Kill(FFILE)
        End If


        Dim sw As StreamWriter = New StreamWriter(FFILE)
        'sw.WriteLine("1,4    kod")
        'sw.WriteLine("6,20   per")
        'sw.WriteLine("40,20  die")
        'sw.WriteLine("65,16   epa")
        'sw.WriteLine("81,10   afm")

        'sw.WriteLine("118,15   doy")

        'sw.WriteLine("110,8   typ")

        'sw.WriteLine("132,12   DEH")
        'sw.Close()
        ''End Using

        vv.FontSize = 14
        vv.FontBold = True

        '    vv.Print("ΤΡΑΠΕΖΙ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))



        If Val(p_Trapezi) > 900 Then
            vv.Print("*** ΠΑΚΕΤΟ ***")
            vv.Print(" ΠΑΚΕΤΟ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))

        Else
            vv.Print("ΤΡΑΠΕΖΙ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))
        End If








        vv.Print("===========")


        Dim C2 As String = ""
        Dim NC2 As Integer

        For K As Integer = 0 To ListParagg.Items.Count - 1

            Dim SQL As String = ""
            SQL = "INSERT INTO PARAGG "
            SQL = SQL + "(IDPARAGG,TRAPEZI,KOD,POSO,TIMH,HME,ONO,PROSUETA) VALUES "
            SQL = SQL + "(" + Str(N) + ",'" + p_Trapezi + "','" + ListParagg.Items(K).SubItems(3).Text + "'," ' TABLE,KOD
            SQL = SQL + nNull(ListParagg.Items(K).SubItems(1).Text) + "," + nNull(ListParagg.Items(K).SubItems(2).Text) + "," + MDATE + ","  'POSO , TIMH , HME
            SQL = SQL + "'" + ListParagg.Items(K).SubItems(0).Text + "','" + ListParagg.Items(K).SubItems(4).Text + "')" ' ONO , PROSUETA
            ExecuteSQLQuery(SQL, DT)


            If Len(C2) > 1 Then
                C2 = Mid(C2, 1, Len(C2) - 1)  ' ΝΑ ΦΑΩ ΤΟ ΤΕΛΕΥΤΑΙΟ ,  1,2,3, => 1,2,3
            End If

            If nNull(ListParagg.Items(K).SubItems(1).Text) > 1 Then
                vv.Print(ListParagg.Items(K).SubItems(1).Text + " X ")
            End If

            vv.Print(ListParagg.Items(K).SubItems(0).Text)
            C2 = ListParagg.Items(K).SubItems(3).Text
            'vv.Print(Split(C2, ",")(0))


            ' Split the string on the backslash character.



            Dim parts As String() = C2.Split(New Char() {","c})

            ' Loop through result strings with For Each.






            Dim part As String
            For Each part In parts
                'Console.WriteLine(part)
                vv.Print("*" + part)
            Next

            If Len(Trim(ListParagg.Items(K).SubItems(4).Text)) > 0 Then
                vv.Print("*" + Trim(ListParagg.Items(K).SubItems(4).Text))
            End If

            vv.Print("-------------")


            ' sw.WriteLine(ListParagg.Items(K).SubItems(0).Text)

            ' sw.WriteLine(ListParagg.Items(K).SubItems(4).Text)

        Next
        sw.Close()

        vv.EndDoc()


        'typono()
        ' printer.prt("JJNHJHH")
        ListParagg.Items.Clear()

        ExecuteSQLQuery("UPDATE TABLES SET KATEILHMENO=1,IDPARAGG=" + Str(N) + " WHERE ONO='" + p_Trapezi + "'", DT)


        Me.Close()






    End Sub

    'Private Sub EPILOGH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EPILOGH.Click
    '    'προσθετα
    '    Dim S As String = ""
    '    For K As Integer = 0 To PROSUETA.Items.Count - 1
    '        If PROSUETA.Items(K).Checked = True Then
    '            S = S + PROSUETA.Items(K).SubItems(0).Text + ","
    '        End If





    '    Next


    '    'ξανατυπωνω την 1η σειρα
    '    Dim strI(4) As String

    '    Dim itm As ListViewItem

    '    strI(0) = ListParagg.Items(0).SubItems(0).Text     'EIDHVIEW.SelectedItems.Item(0).Text '"Rob Machy"
    '    strI(1) = ListParagg.Items(0).SubItems(1).Text '"1" 'Business Manager"  POSOTHTA
    '    strI(2) = ListParagg.Items(0).SubItems(2).Text ' EIDOS_LIST(index).TIMH.ToString   ' "1" ' i.ToString
    '    strI(3) = S ' ListParagg.Items(0).SubItems(3).Text    'EIDOS_LIST(index).ID.ToString

    '    strI(4) = ListParagg.Items(0).SubItems(4).Text   '"." 'DateTime.Now.AddHours(i).ToString("hh:mmTongue Tieds")

    '    itm = New ListViewItem(strI)

    '    ' PROSUETA.Items.Insert(0, itm)


    '    'σβηνω την σειρά για να την ξανατυπωσω παρακατω
    '    'If ListParagg.SelectedItems.Count > 0 Then
    '    ListParagg.Items.Remove(ListParagg.Items(0))
    '    'End If

    '    'την  προσθετω
    '    ListParagg.Items.Insert(0, itm)


    '    '  ListParagg.Items(0).SubItems(4).Text = S

    '    ' ListParagg.Refresh()

    'End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


        'If HDH_YPARXOYSA.SelectedItems.Count > 0 Then
        '    Dim c As String
        '    Dim n As Integer = HDH_YPARXOYSA.SelectedIndices(0)
        '    HDH_YPARXOYSA.Items(n).BackColor = Color.Beige

        '    ' ListParagg.Items.Add(c)


        '    'c = HDH_YPARXOYSA.Items(n).SubItems(0).ToString
        '    'ListParagg.Items.SubItems(0) = c

        'End If



        'Dim Items As New List(Of ListViewItem)
        'Dim RancomClass As New Random()
        'For i As Integer = 0 To DTT.Rows.Count - 1
        '    '// Text and Images index
        '    ''test
        '    'Dim str(2) As String
        '    'str(0) = DTT(i)(0).ToString  '"Rob Machy"
        '    'str(1) = "Rob2 Machy"
        '    'str(2) = "Rob2 Machy"
        '    'Dim itm2 As ListViewItem
        '    'itm2 = New ListViewItem(Str)
        '    'EIDHVIEW.Items.AddRange(itm2, 0)
        '    EIDOS_LIST(i).ID = DTT(i)("ID")
        '    EIDOS_LIST(i).TIMH = DTT(i)("TIMH")
        '    EIDOS_LIST(i).ONOMA = DTT(i)("ONO")


        '    ' Dim N1 As Integer = DTT(i)("KATEILHMENO")
        '    Dim item As New ListViewItem(DTT(i)(0).ToString, 0) ' RancomClass.Next(0, 10) Mod 2)
        '    Items.Add(item)
        'Next
        'EIDHVIEW.Items.AddRange(Items.ToArray)









    End Sub

    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PAYMENT.Click
        Dim DT As New DataTable
        ' MESSAGEBOXADD.PatchMsgBox(New String() {"ΜΕΤΡΗΤΑ", "ΠΙΣΤΩΤΙΚΗ", "ΚΕΡΑΣΜΕΝΑ"})
        ' Dim ANS As Integer = MsgBox("gack", MsgBoxStyle.YesNoCancel) ' 6,7,2






        'ExecuteSQLQuery("SELECT SUM(POSO*TIMH) FROM PARAGG WHERE IDPARAGG=" + Str(p_IDPARAGG), DT)
        'Dim SS As String = Replace(DT(0)(0).ToString, ",", ".")

        ExecuteSQLQuery("SELECT  str(round(SUM(POSO*TIMH),2),6,2 ) FROM PARAGG WHERE   IDPARAGG=" + Str(p_IDPARAGG), DT)


        Dim SS As String = Replace(DT(0)(0).ToString, ",", ".")

        Dim CX As String = InputBox("Εκπτωση", "Συνολο " + SS, "")
        If Len(CX) = 0 Then
            CX = "0"
        End If

        SS = Str(Val(Replace(DT(0)(0), ",", ".")) - Val(Replace(CX, ",", ".")))


        Dim F As New DialogBoxForm
        F.Button1.Text = "ΜΕΤΡΗΤΑ"
        F.Button2.Text = "ΠΙΣΤΩΤΙΚΗ 1"
        F.Button3.Visible = False '   Text = "ΠΙΣΤΩΤΙ"
        F.Button4.Text = "ΚΕΡΑΣΜΕΝΑ"
        If F.ShowDialog() = Windows.Forms.DialogResult.OK Then






            If Val(Replace(CX, ",", ".")) > 0 Then
                ExecuteSQLQuery("UPDATE  PARAGGMASTER SET PIS2=isnull(PIS2,0)+" + Replace(CX, ",", ".") + " WHERE ID=" + Str(p_IDPARAGG), DT)

            End If



            If SS = Nothing Then
                SS = "0"
            End If

            If F.LoginName = 1 Then
                ExecuteSQLQuery("UPDATE  PARAGGMASTER SET CASH=isnull(CASH,0)+" + SS + " WHERE ID=" + Str(p_IDPARAGG), DT)
            ElseIf F.LoginName = 2 Then
                ExecuteSQLQuery("UPDATE  PARAGGMASTER SET PIS1=isnull(PIS1,0)+" + SS + " WHERE ID=" + Str(p_IDPARAGG), DT)
                'ElseIf F.LoginName = 3 Then
                '   ExecuteSQLQuery("UPDATE  PARAGGMASTER SET PIS2=isnull(PIS2,0)+" + SS + " WHERE ID=" + Str(p_IDPARAGG), DT)
            ElseIf F.LoginName = 4 Then
                ExecuteSQLQuery("UPDATE  PARAGGMASTER SET KERA=isnull(KERA,0)+" + SS + " WHERE ID=" + Str(p_IDPARAGG), DT)
            End If

            'ExecuteSQLQuery("UPDATE PARAGGMASTER SET CH2='" + Format(Now(), "hh:mm") + "',AJIA=" + Str(SS) + ",TROPOS=" + F.LoginName + " WHERE ID=" + Str(p_IDPARAGG), DT)

            ExecuteSQLQuery("UPDATE PARAGGMASTER SET CH2='" + Format(Now(), "hh:mm") + "',AJIA=CASH+PIS1+PIS2+KERA,TROPOS=" + F.LoginName + " WHERE ID=" + Str(p_IDPARAGG), DT)
            ExecuteSQLQuery("UPDATE TABLES SET KATEILHMENO=0,IDPARAGG=0 WHERE ONO='" + p_Trapezi + "'", DT)








            ' ExecuteSQLQuery("delete from PARAGG WHERE IDPARAGG=0 ", DT)
            Me.Close()



        Else

        End If



        ''
    End Sub

    Public Sub ShowDialogBox()
        'Dim F As New DialogBoxForm
        'F.Button1.Text = "ΜΕΤΡΗΤΑ"
        'F.Button2.Text = "ΠΙΣΤΩΤΙΚΗ 1"
        'F.Button3.Text = "ΠΙΣΤΩΤΙΚΗ 2"
        'F.Button4.Text = "ΚΕΡΑΣΜΕΝΑ"
        'If F.ShowDialog() = Windows.Forms.DialogResult.OK Then


        'Else

        'End If

        'dialog.LoginName = "JDMurray"
        'dialog.LoginPassword = String.Empty

        'If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
        '    Debug.WriteLine("Login Name: " & dialog.LoginName)
        '    Debug.WriteLine("Password: " & dialog.LoginPassword)
        'Else
        '    Debug.WriteLine("Login Name: ΑΚΥΡΟ") '& dialog.LoginName)
        '    ' User clicked the Cancel button
        'End If
    End Sub

    Private Sub HDH_YPARXOYSA_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HDH_YPARXOYSA.MouseClick
        Dim A As Integer
        Try
            Dialog1.p_IDPARAGG = p_IDPARAGG
            Dialog1.Text = HDH_YPARXOYSA.SelectedItems(0).Text
            Dialog1.Text = Dialog1.Text + "              ;" + Str(HDH_YPARXOYSA.SelectedItems(0).Index) + ";" + Str(p_IDPARAGG) + ";" + Replace(HDH_YPARXOYSA.SelectedItems(0).SubItems.Item(3).Text, ",", ".")
            Dialog1.p_AXIA = Replace(HDH_YPARXOYSA.SelectedItems(0).SubItems.Item(3).Text, ",", ".")
            Dialog1.ShowDialog()


        Catch ex As Exception
            A = 1
        End Try











    End Sub


    Private Sub HDH_YPARXOYSA_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HDH_YPARXOYSA.SelectedIndexChanged

    End Sub

    Private Sub typono_logar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles typono_logar.Click
        vv.FontSize = 10
        vv.FontBold = True
        vv.FontName = "COURIER"
        vv.Print("ΤΡΑΠΕΖΙ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))
        vv.Print("===========")



        Dim DT As New DataTable
        Dim DD As String

        ExecuteSQLQuery("SELECT ONO,POSO,TIMH,POSO*TIMH AS AJ FROM PARAGG WHERE IDPARAGG=" + Str(p_IDPARAGG), DT)

        If DT.Rows.Count > 0 Then

            Dim SS As String = Replace(DT(0)(0).ToString, ",", ".")
            Dim SU As Single = 0
            Dim MPOSO As String
            Dim MTIMH As String
            Dim majia As String


            For K As Integer = 0 To DT.Rows.Count - 1
                'vv.Print(DT(K)("ONO").ToString)
                'vv.ScaleX(200, , )
                MPOSO = Format(DT(K)("POSO"), "##")
                If Len(MPOSO) < 2 Then
                    MPOSO = " " + MPOSO
                End If


                MTIMH = Format(DT(K)("TIMH"), "##0.00")
                If Len(MTIMH) = 4 Then
                    MTIMH = "  " + MTIMH
                ElseIf Len(MTIMH) = 5 Then
                    MTIMH = " " + MTIMH
                ElseIf Len(MTIMH) = 6 Then
                    MTIMH = MTIMH
                End If

                majia = Format(DT(K)("aj"), "##0.00")
                If Len(majia) = 4 Then
                    majia = "  " + majia
                ElseIf Len(majia) = 5 Then
                    majia = " " + majia
                ElseIf Len(majia) = 6 Then
                    majia = majia
                End If





                DD = Mid(DT(K)("ONO").ToString + "                 ", 1, 15) + MPOSO + "X" + MTIMH + "=" + majia
                'DD = Mid(DT(K)("POSO").ToString + " X " + DT(K)("TIMH").ToString + "=                 ", 1, 24) + Space(10) + Format(DT(K)("AJ"), "####0.00")

                vv.Print()
                vv.Print(DD)
                SU = SU + DT(K)("AJ")
            Next
            vv.Print("===========")

            majia = Format(SU, "###0.00")
            If Len(majia) = 4 Then
                majia = "  " + majia
            ElseIf Len(majia) = 5 Then
                majia = " " + majia
            ElseIf Len(majia) = 6 Then
                majia = majia
            End If

            vv.Print("Σύνολο :" + Space(17) + majia)


            vv.EndDoc()

        End If





    End Sub

    Private Sub EIDH_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EIDH.SelectedIndexChanged

    End Sub

    Private Sub OK_PROSU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_PROSU.Click
        delete_button.Enabled = True
        bale1.Enabled = True
        bgale1.Enabled = True

        '=========================================
        'προσθετα
        Dim S As String = ""
        For K As Integer = 0 To PROSU2.Items.Count - 1
            If PROSU2.Items(K).BackColor = Color.Red Then
                S = S + PROSU2.Items(K).SubItems(0).Text + ","
            End If
        Next


        'ξανατυπωνω την 1η σειρα
        Dim strI(5) As String

        Dim itm As ListViewItem




        'EIDHVIEW.SelectedItems.Item(0).Text '"Rob Machy"

        If ListParagg.Items.Count = 0 Then
            Exit Sub
        End If
        strI(0) = ListParagg.Items(0).SubItems(0).Text

        strI(1) = ListParagg.Items(0).SubItems(1).Text '"1" 'Business Manager"  POSOTHTA
        strI(2) = ListParagg.Items(0).SubItems(2).Text ' EIDOS_LIST(index).TIMH.ToString   ' "1" ' i.ToString
        strI(3) = S ' ListParagg.Items(0).SubItems(3).Text    'EIDOS_LIST(index).ID.ToString

        strI(4) = CSXOLIA.Text '  ListParagg.Items(0).SubItems(4).Text   '"." 'DateTime.Now.AddHours(i).ToString("hh:mmTongue Tieds")
        strI(5) = ""   ' ListParagg.Items(0).SubItems(5).Text
        itm = New ListViewItem(strI)

        ' PROSUETA.Items.Insert(0, itm)


        'σβηνω την σειρά για να την ξανατυπωσω παρακατω
        'If ListParagg.SelectedItems.Count > 0 Then
        ListParagg.Items.Remove(ListParagg.Items(0))
        'End If

        'την  προσθετω
        ListParagg.Items.Insert(0, itm)


        ' PROSU2.Items.Clear()

        For K As Integer = 0 To PROSU2.Items.Count - 1
            PROSU2.Items(K).BackColor = Color.White 'Then
            '      S = S + PROSU2.Items(K).SubItems(0).Text + ","
            ' End If
        Next

        'EIDHVIEW
        For K As Integer = 0 To EIDHVIEW.Items.Count - 1
            EIDHVIEW.Items(K).BackColor = Color.White 'Then
        Next
        CSXOLIA.BackColor = Color.White
        CSXOLIA.Text = ""

        EIDHVIEW.Enabled = True
        'KATHG.Enabled = True
        trexon_eidos.Text = ""




    End Sub


    Private Sub CSXOLIA_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles CSXOLIA.GotFocus
        CSXOLIA.BackColor = Color.Yellow
        Try
            Process.Start("C:\DEBUG\tabtip.EXE")
        Catch ex As Exception

        End Try

        ' Shell("C:\DEBUG\tabtip.EXE", AppWinStyle.NormalFocus)
    End Sub

    Private Sub PROSU2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PROSU2.Click



        '  PROSU2.SelectedItems(0).Text = "/////" + PROSU2.SelectedItems(0).Text
        If PROSU2.SelectedItems(0).BackColor = Color.Red Then
            PROSU2.SelectedItems(0).BackColor = Color.White
        Else
            PROSU2.SelectedItems(0).BackColor = Color.Red
        End If

        OK_PROSU.Focus()











    End Sub




    Private Sub bale1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bale1.Click

        If ListParagg.Items.Count = 0 Then
            Exit Sub
        End If



        'ξανατυπωνω την 1η σειρα
        Dim strI(5) As String

        Dim itm As ListViewItem

        strI(0) = ListParagg.Items(0).SubItems(0).Text     'EIDHVIEW.SelectedItems.Item(0).Text '"Rob Machy"
        strI(1) = LTrim(Str(1 + Val(ListParagg.Items(0).SubItems(1).Text))) '"1" 'Business Manager"  POSOTHTA
        strI(2) = ListParagg.Items(0).SubItems(2).Text ' EIDOS_LIST(index).TIMH.ToString   ' "1" ' i.ToString
        strI(3) = ListParagg.Items(0).SubItems(3).Text ' ListParagg.Items(0).SubItems(3).Text    'EIDOS_LIST(index).ID.ToString

        strI(4) = ListParagg.Items(0).SubItems(4).Text ' ListParagg.Items(0).SubItems(4).Text   '"." 'DateTime.Now.AddHours(i).ToString("hh:mmTongue Tieds")
        strI(5) = "" ' CSXOLIA.Text   ' ListParagg.Items(0).SubItems(5).Text
        itm = New ListViewItem(strI)

        ' PROSUETA.Items.Insert(0, itm)


        'σβηνω την σειρά για να την ξανατυπωσω παρακατω
        'If ListParagg.SelectedItems.Count > 0 Then
        ListParagg.Items.Remove(ListParagg.Items(0))
        'End If

        'την  προσθετω
        ListParagg.Items.Insert(0, itm)

    End Sub

    Private Sub bgale1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bgale1.Click

        If ListParagg.Items.Count = 0 Then
            Exit Sub
        End If

        'ΕΑΝ ΕΙΝΑΙ ΚΑΙΝΟΥΡΙΑ ΠΑΡΑΓΓΕΛΙΑ ΔΕΝ ΜΠΟΡΕΙ ΝΑ ΠΑΕΙ ΣΤΑ ΑΡΝΗΤΙΚΑ
        If p_IDPARAGG = 0 Then
            If nNull(ListParagg.Items(0).SubItems(1).Text) = 0 Then
                Exit Sub
            End If


        End If






        'ξανατυπωνω την 1η σειρα

        Dim DT As New DataTable

        If Val(ListParagg.Items(0).SubItems(1).Text) <= 0 Then
            ''ΠΑΕΙ ΝΑ ΚΑΝΕΙ ΑΚΥΡΩΣΗ--
            ''ΠΡΕΠΕΙ ΝΑ ΒΕΒΑΙΩΘΩ ΟΤΙ ΥΠΑΡΧΕΙ ΝΑ ΤΟ ΑΚΥΡΩΣΩ
            If nNull(ListParagg.Items(0).SubItems(1).Text) <= 0 Then
                ExecuteSQLQuery("SELECT SUM(POSO) FROM PARAGG WHERE IDPARAGG=" + Str(p_IDPARAGG) + "AND ONO='" + ListParagg.Items(0).SubItems(0).Text + "'", DT)
                If IsDBNull(DT(0)(0)) Then
                    Exit Sub
                End If

                ' EAN AYTO POY GRAFEI + 1 ΠΟΥ ΘΕΛΕΙ ΝΑ ΚΑΤΕΒΑΣΕΙ ΠΡΕΠΕΙ ΝΑ ΥΠΑΡΧΕΙ 
                If 1 + (-Val(ListParagg.Items(0).SubItems(1).Text)) <= DT(0)(0) Then
                    'OK ΠΡΟΧΩΡΑΕΙ Η ΑΚΥΡΩΣΗ
                Else
                    Exit Sub
                End If
            End If
        End If







        Dim strI(5) As String

        Dim itm As ListViewItem

        strI(0) = ListParagg.Items(0).SubItems(0).Text     'EIDHVIEW.SelectedItems.Item(0).Text '"Rob Machy"

        strI(1) = LTrim(Str(Val(ListParagg.Items(0).SubItems(1).Text) - 1)) '"1" 'Business Manager"  POSOTHTA
        strI(2) = ListParagg.Items(0).SubItems(2).Text ' EIDOS_LIST(index).TIMH.ToString   ' "1" ' i.ToString
        strI(3) = ListParagg.Items(0).SubItems(3).Text ' ListParagg.Items(0).SubItems(3).Text    'EIDOS_LIST(index).ID.ToString

        strI(4) = ListParagg.Items(0).SubItems(4).Text ' ListParagg.Items(0).SubItems(4).Text   '"." 'DateTime.Now.AddHours(i).ToString("hh:mmTongue Tieds")
        strI(5) = "" ' CSXOLIA.Text   ' ListParagg.Items(0).SubItems(5).Text
        itm = New ListViewItem(strI)

        ' PROSUETA.Items.Insert(0, itm)


        'σβηνω την σειρά για να την ξανατυπωσω παρακατω
        'If ListParagg.SelectedItems.Count > 0 Then
        ListParagg.Items.Remove(ListParagg.Items(0))
        'End If

        'την  προσθετω
        ListParagg.Items.Insert(0, itm)



    End Sub

    Private Sub ADDITPARAGG_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        LISTVIEW1.Bounds = KATHG.Bounds
        EIDHVIEW.Bounds = EIDH.Bounds ' New Rectangle(New Point(10, 10), New Size(380, 400))
    End Sub

    Private Sub CSXOLIA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CSXOLIA.TextChanged

    End Sub

    Private Sub KATHG_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KATHG.SelectedIndexChanged

    End Sub
End Class