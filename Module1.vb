'Created by Junnajir j. Giminsil
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Drawing

Imports System
Imports System.IO


Module Module1
    Public myConn As New OleDbConnection
    Public myCmd As New OleDbCommand
    Public myDR As OleDbDataReader
    Public frUpdate As Boolean 'Holding for Updating entry
    Public gCONNECT As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\databaseBAR.mdb;"
    Public gAtim As String
    Public GFILEdestination As String
    Public gID_NUM As String
    Public gBaran As Integer
    Public gSEIRA As String
    Public GeRGAZ As String
    Public gPass As String = "12345678"

    Public gBardia As Long
    Public gFilePelaton As String ' = Split(lineexcel, ";")(0)
    Public gFileEidon As String  ' = Split(lineexcel, ";")(1)
    Public SQLDT As DataTable
    Public gUser As Integer ' τον user τον καταλαβαίνει από το tablet
    Public gIsAdmin As Integer ' einai o dieythintis
    Public G_ADMIN_PW As String

    Public gPrinter1 As String
    Public gPrinter2 As String
    Public gPrinter3 As String






    'Module Module1
    Dim WithEvents pd As PrintDocument = New PrintDocument

    Public Sub typono()



        

        'pd.PrinterSettings.PrinterName = "Generic / Text Only"
        pd.Print()

    End Sub

    Public Function nNull(ByVal nChar As String) As String
        nNull = Replace(nChar, ",", ".")




    End Function










    'event handler
    Private Sub pdpp(ByVal sender As Object, ByVal ev As PrintPageEventArgs) Handles pd.PrintPage

        If File.Exists("C:\MERCVB\EGGTIM.TXT") Then
        Else

            Exit Sub
        End If




        Dim MS As Long = 0
        Using sr As StreamReader = New StreamReader("C:\MERCVB\EGGTIM2.TXT", System.Text.Encoding.Default)
            Dim line, CC As String
            Do
                line = sr.ReadLine()  'seira me header
                'Me.text = line

                MS = MS + 20
                ev.Graphics.DrawString(line, New Font("Arial Greek", 20), Brushes.Black, 40, MS)
            Loop Until line Is Nothing
            sr.Close()
        End Using





        'ev.Graphics.DrawString("Hello", New Font("Arial", 20), Brushes.Black, 20, 20)
        'ev.Graphics.DrawString("=============1=Hello", New Font("Arial", 20), Brushes.Black, 20, 40)
    End Sub

    Public Function to437(ByVal SQL As String) As String
        Dim s928, s437, s As String, k As Integer
        'metatrepei eggrafo apo 928 -> 437
        s928 = "ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ-αβγδεζηθικλμνξοπρστυφχψω-ςάέήίόύώ"
        s437 = "ABGDEZH8IKLMNXOPRSTYFXCO€‚ƒ„…†‡‰‹‘’•–—-™› ΅Ά£¤¥¦§¨©«¬­®―ΰ-αβγεζηι" ' saehioyv
        '        s437 = "€‚ƒ„…†‡‰‹‘’•–—-™› ΅Ά£¤¥¦§¨©«¬­®―ΰ-αβγεζηι" ' saehioyv
        '  saehioyv

        For k = 1 To Len(SQL)
            s = Mid(SQL, k, 1)
            't = InStr(s928, s)
            If Asc(s) > 190 Then
                If Asc(s) <= 209 Then
                    Mid(SQL, k, 1) = Chr(Asc(s) - 65)
                Else
                    Mid(SQL, k, 1) = Chr(Asc(s) - 66)
                End If

            End If
        Next




        'For k = 1 To Len(SQL)
        '    s = Mid(SQL, k, 1)
        '    t = InStr(s928, s)
        '    If t > 0 Then
        '        Mid(SQL, k, 1) = Mid$(s437, t, 1)
        '    End If
        'Next


        to437 = SQL

    End Function






    'End Module







    'Public Function IsConnected1(ByVal strQry As String, ByVal ver As Boolean)
    '    Try

    '        If myConn.State = ConnectionState.Open Then myConn.Close()
    '        myConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\databasebAR.mdb;"
    '        myConn.Open()

    '        myCmd.CommandText = strQry
    '        myCmd.Connection = myConn

    '        If ver = False Then
    '            myDR = myCmd.ExecuteReader() 'For reading query
    '        Else
    '            myCmd.ExecuteNonQuery() 'For updating query
    '        End If

    '    Catch ex As Exception
    '        ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Function

    'Public Function IsConnected(ByVal strQry As String, ByVal ver As Boolean, ByRef PIN As OleDbDataReader)
    '    Try

    '        If myConn.State = ConnectionState.Open Then myConn.Close()
    '        myConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\databasebAR.mdb;"
    '        myConn.Open()

    '        myCmd.CommandText = strQry
    '        myCmd.Connection = myConn

    '        If ver = False Then
    '            PIN = myCmd.ExecuteReader() 'For reading query
    '        Else
    '            myCmd.ExecuteNonQuery() 'For updating query
    '        End If

    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Function



    Public Function openWifiSQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

        Dim fobjcon As SqlConnection, fobjcmd As New SqlCommand
        Dim c As String = gCONNECT ' "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        'Dim FDS As New System.Data.DataSet
        Dim FDA As New SqlDataAdapter

        Try
            fobjcon = New SqlConnection(c)


            fobjcmd = New SqlCommand(sql, fobjcon)
            fobjcmd.Connection.Open()
            FDA.SelectCommand = fobjcmd
            FDS.Clear()
            FDA.Fill(FDS)
            openWifiSQL = FDS.Tables.Count
            fobjcon.Close()
        Catch ex As Exception
            MsgBox("Can't load Web page" & vbCrLf & ex.Message)
            openWifiSQL = -1
        End Try



    End Function


    'IsConnected("update ARITMISI set ARITMISI=ARITMISI+1 WHERE ID=1", True)

    '        IsConnected("Insert into TIM (KPE,ATIM,HME) values('" & _
    '                        LV.SelectedItems(0).SubItems(5).Text & "','" & _
    '                        gAtim & "','" & _
    '                       Format(Now, "dd/MM/yyyy") & "')", True)


    '        IsConnected("SELECT * FROM TIM WHERE ATIM='" + gAtim + "'", False)
    '        myDR.Read()
    '        gID_NUM = myDR("ID_NUM")

    Public Function IsConnected(ByVal strQry As String, ByVal ver As Boolean)
        'ΔΟΥΛΕΥΕΙ ΜΟΝΟ ΤΗΝ FORM2 POY EINAI ΕΦΕΔΡΙΚΗ ΦΟΡΜΑ


        Try

            If myConn.State = ConnectionState.Open Then myConn.Close()
            myConn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;"
            myConn.Open()

            myCmd.CommandText = strQry
            myCmd.Connection = myConn

            If ver = False Then
                myDR = myCmd.ExecuteReader() 'For reading query
            Else
                myCmd.ExecuteNonQuery() 'For updating query
            End If

        Catch ex As Exception
            ' MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Function

    Public Sub LOAD_file(ByVal query As String, ByVal lv As ListView, ByVal sthles As Integer)

        Dim j As Integer = sthles - 2



        Dim PINAK As OleDbDataReader
        Dim myConn2 As New OleDbConnection
        Dim myCmd2 As New OleDbCommand
        Dim strQry2 As String
        Dim n As Integer



        Dim SQL As String


        'If myConn2.State = ConnectionState.Open Then myConn2.Close()

        'myConn2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\databaseBAR.mdb;"
        'myConn2.Open()

        'myCmd2.CommandText = query  ' "Select TOP 20 ID,KOD,EPO,DIE,EPA,THL,TYP,PEK,XRE from PEL " + synt + " ORDER BY EPO" 'strQry2
        'myCmd2.Connection = myConn2


        'PINAK = myCmd2.ExecuteReader() 'For reading query



        '' ''Dim c As String
        '' ''c = "Select top 10000 ID,KOD,EPO,DIE,AFM,PEK,EPA   from PEL " + synt + " ORDER BY EPO"
        '' ''IsConnected(c, False)

        '' '' MHNYMA.Text = f_mess_pel


        '' ''For n = 1 To 9
        '' ''    LV.Columns(n - 1).Width = Split(F_PLATH_PEL, ";")(n - 1) 'Split(line, ";")(0)
        '' ''Next
        n = 0

        Dim DT As New DataTable
        ExecuteSQLQuery(query, DT)





        lv.Items.Clear()
        Dim MTYP As String
        If DT.Rows.Count > 0 Then
            'While (PINAK.Read())
            For n = 0 To DT.Rows.Count - 1
                'n = n + 1
                'If IsDBNull(PINAK("TYP")) = True Then
                '    MTYP = ""
                'Else
                '    MTYP = Format(PINAK("TYP"), "#####0.00")
                'End If
                With lv.Items.Add(DT(n)(0))
                    For k As Integer = 0 To j
                        .SubItems.Add(IIf(IsDBNull(DT(n)(k + 1)), "", DT(n)(k + 1)))
                    Next

                End With
            Next ' End While
        End If
        lv.Columns(1).Width = 0




    End Sub








    Public Sub FILLlistBox(ByVal sql As String, ByVal cb As ListBox)
        Dim conn As OleDbConnection = New OleDbConnection(gCONNECT)
        cb.Items.Clear()
        Try
            conn.Open()
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader
            While rdr.Read
                cb.Items.Add(rdr(0).ToString & " ; " & rdr(1).ToString)
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub



    Public Sub FILLComboBox(ByVal sql As String, ByVal cb As ComboBox)
        Dim conn As OleDbConnection = New OleDbConnection(gCONNECT)
        cb.Items.Clear()
        Try
            conn.Open()
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            Dim rdr As OleDbDataReader = cmd.ExecuteReader
            While rdr.Read
                cb.Items.Add(rdr(0).ToString & " ; " & rdr(1).ToString)
            End While
            rdr.Close()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub




    Public Sub ExecuteSQLQuery(ByVal SQLQuery As String, ByRef SQLDT As DataTable)
        'αν χρησιμοποιώ  byref  tote prepei να δηλωθεί   
        'Dim DTI As New DataTable


        Try

            If InStr(gCONNECT, "MDB") > 0 Then
                Dim sqlCon As New OleDbConnection(gCONNECT)

                Dim sqlDA As New OleDbDataAdapter(SQLQuery, sqlCon)

                Dim sqlCB As New OleDbCommandBuilder(sqlDA)

                SQLDT.Reset() ' refresh 
                sqlDA.Fill(SQLDT)

                ' sqlDA.Fill(sqlDaTaSet, "PEL")
            Else

                Dim sqlCon As New SqlConnection(gCONNECT)

                Dim sqlDA As New SqlDataAdapter(SQLQuery, sqlCon)

                Dim sqlCB As New SqlCommandBuilder(sqlDA)

                SQLDT.Reset() ' refresh 
                sqlDA.Fill(SQLDT)



            End If



        Catch 'ex As Exception
            'MsgBox("Error: " & ex.ToString)
            'If Err.Number = 5 Then
            '    MsgBox("Invalid Database, Configure TCP/IP", MsgBoxStyle.Exclamation, "Sales and Inventory")
            'Else
            '    MsgBox("Error : " & ex.Message)
            'End If
            'MsgBox("Error No. " & Err.Number & " Invalid database or no database found !! Adjust settings first", MsgBoxStyle.Critical, "Sales And Inventory")
            MsgBox(Err.Description + Chr(13) + SQLQuery)
        End Try
        'Return sqlDT
    End Sub



    ' Create a new ListView control.
    ' Private listView1 As New ListView()

    'Private Sub frmListViewImage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Call CreateMyListView()
    'End Sub
    Public Sub CreateMyListView(ByVal FORMA As Form, ByVal listView1 As ListView)
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
        Dim Items As New List(Of ListViewItem)
        Dim RancomClass As New Random()
        For i As Integer = 0 To 11
            '// Text and Images index
            Dim item As New ListViewItem("ΤΡΑΠΕΖΙ " & i + 1, RancomClass.Next(0, 10) Mod 2)
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
        FORMA.Controls.Add(listView1)
        '// start event handling at any time during program execution.
        ' AddHandler listView1.Click, AddressOf listView1_Click

    End Sub 'CreateMyListView

    'Private Sub listView1_Click(ByVal sender As System.Object, ByVal e As EventArgs)
    '    MsgBox(listView1.SelectedItems.Item(0).Text)
    'End Sub

    ' / --------------------------------------------------------------------------------
    ' / Get my project path
    ' / AppPath = C:\My Project\bin\debug
    ' / Replace "\bin\debug" with "\"
    ' / Return : C:\My Project\
    Function MyPath(ByVal AppPath As String) As String
        '/ MessageBox.Show(AppPath);
        AppPath = AppPath.ToLower()
        '/ Return Value
        MyPath = AppPath.Replace("\bin\debug", "\").Replace("\release\debug", "\")
        If Microsoft.VisualBasic.Right(MyPath, 1) <> "\" Then MyPath = MyPath & "\"
    End Function



    Public Function checkServer() As Boolean
        Dim c As String
        '  gMHNAS = Format(Now, "yyyymm")
        '  gMHNAS = InputBox("ΜΗΝΑΣ ΕΡΓΑΣΙΑΣ ", "", gMHNAS)

        c = Application.StartupPath & "\Config.ini"
        Dim gConSQL As String

        Dim tmpstr As String = ""
        Dim c2() As String
        ' c2(1) = ""
        Dim c3 As String
        Try

            FileOpen(1, c, OpenMode.Input, OpenAccess.Read, OpenShare.Default)
            c3 = ""
            Input(1, tmpstr)
            Input(1, c3)
            FileClose(1)
            tmpstr = tmpstr + c3 'Server=DELLAGAKIS\SQL17,51403;Database=BARELL;UID=sa;pwd=12345678;

            If Split(tmpstr, ";")(4) = "" Then
                'network
                gCONNECT = "Provider=SQLOLEDB.1;Persist Security Info=True;" & _
                           "Data Source=" & Split(tmpstr, ";")(1) & _
                           ";Initial Catalog=" & Trim(Split(tmpstr, ";")(5)) & _
                           ";User Id=" & Split(tmpstr, ";")(2) & _
                           ";Password=" & Split(tmpstr, ";")(3)
                ' gConSQL = "Server=" & Split(tmpstr, ":")(1) & ";Database=" & Split(tmpstr, ":")(5) & ";User Id=" & Split(tmpstr, ":")(2) & ";Password=" & Split(tmpstr, ":")(3)
                'Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;
                'Password=myPassword;
            Else
                'local
                'MsgBox(Split(tmpStr, ":")(1))
                gCONNECT = "Provider=SQLOLEDB;Server=" & Split(tmpstr, ":")(1) & _
                           ";Database=MERCURY; Trusted_Connection=yes;"

                gConSQL = "Data Source=" & Split(tmpstr, ":")(1) & ";Integrated Security=True;database=MERCURY"
                'cnString = "Data Source=localhost\SQLEXPRESS;Integrated Security=True;database=YGEIA"


                '
            End If

            Dim sqlCon As New OleDbConnection
            sqlCon.ConnectionString = gCONNECT
            sqlCon.Open()
            checkServer = True
            sqlCon.Close()

            Dim GDB As New ADODB.Connection
            GDB.Open(gCONNECT)
            GDB.Close()

        Catch ex As Exception
            checkServer = False
            MsgBox("εξοδος λογω μη σύνδεσης με βάση δεδομένων. Ελέγξτε το config.ini")
            'End
        End Try
    End Function





End Module