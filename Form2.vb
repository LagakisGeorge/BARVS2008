Imports System.Data.SqlClient

Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Imports System
Imports System.IO

'Imports System.Windows.Forms
Imports System.Drawing.Printing
Imports System.Drawing

'Module Module1

Imports System.Net.NetworkInformation






Public Class Form2
    Dim WithEvents pd As PrintDocument = New PrintDocument
    'Visual Basic 
    Dim sortColumn As Integer = -1
    Dim f_mess_pel As String
    Dim f_mess_eid As String
    Dim F_PLATH_PEL As String
    Dim F_PLATH_EID As String


    Private Sub Form2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick

        IsConnected("SELECT * FROM ARITMISI WHERE ID=1 ", False)
        myDR.Read()

        'If myDR.RecordsAffected = 0 Then
        '    MsgBox("ΔΕΝ ΚΑΤΑΧΩΡΗΘΗΚΕ")
        '    gID_NUM = 0
        '    Exit Sub

        Dim b As String

        b = IIf(IsDBNull(myDR("ARITMISI")), "1", Str(myDR("ARITMISI")))



        Dim c As String = InputBox("δωσε αρίθμηση παραγγελιών", , b)

        IsConnected("update ARITMISI set ARITMISI=" + c + " WHERE ID=1", True)
        ' Dim proc As New System.Diagnostics.Process()
        ' proc = Process.Start("NOTEPAD.EXE   ", "")
    End Sub


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' FileCopy("C:\MERCVB\EGGTIM2.TXT + C:\MERCVB\DD.TXT", "C:\MERCVB\ATR.TXT")




        '        Using writer As New StreamWriter("newFile.txt")

        '            For Each tempFile As String In myFiles

        '                Using reader As New StreamReader(tempFile)

        '                    While Not reader.EndOfStream

        '                        writer.WriteLine(reader.ReadLine())
        '                    End While
        '                End Using
        '            Next
        '        End Using
        'The above code creates a StreamWriter to the new file. Then it loops through the files in the directory, and for each file it creates a StreamReader. Then it reads each line of the file (until EndOfStream is true) and writes it to the new file.

        'I used Using statements to ensure the writer and reader are properly disposed of.









        Dim line As String
        Dim line2 As String
        Dim lineexcel As String
        Using sr As StreamReader = New StreamReader("config.ini", System.Text.Encoding.Default)
            line = sr.ReadLine()
            f_mess_pel = sr.ReadLine()
            f_mess_eid = sr.ReadLine()
            F_PLATH_PEL = sr.ReadLine()
            F_PLATH_EID = sr.ReadLine()

            'εδω εχω τις ιδιαιτερότητες του πελάτη
            line2 = sr.ReadLine()   ' 6Η  SEIRA
            lineexcel = sr.ReadLine

        End Using


        'ConString = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        gconnect = "Server=" + Split(line, ";")(0) + ";Database=" + Split(line, ";")(1) + ";uid=" + Split(line, ";")(2) + ";pwd=" + Split(line, ";")(3) + ";"

        If line2 = Nothing Then ' ΣΥΜΒΑΤΟΤΗΤΑ ΜΕ ΠΑΛΙΑ
            If File.Exists("C:\MERCVB\BARAN.TXT") Then
                gBaran = 1
            Else
                gBaran = 0
            End If
            gBaran = 93 '  29  ΟΚΟ   ΜΙΧΑΙΛΙΔΙΣ=93
        Else
            gBaran = Val(Split(line2, ";")(0))   '29 = οκο   93=μιχαηλιδης
            gSEIRA = Split(line2, ";")(1) 'σειρα soft1 που θα αποθηκεύεται π.χ. 7021
            GFILEdestination = Split(line2, ";")(2)  ' που θα το αποθηκευσει το eggtim2.txt Π.Χ. "\\REMOTEPC\"
        End If

        gFilePelaton = Split(lineexcel, ";")(0)
        gFileEidon = Split(lineexcel, ";")(1)
        GFILEdestination = Split(lineexcel, ";")(2)


        'If File.Exists("C:\MERCVB\MHNYMA.TXT") Then
        'Else
        '    MsgBox("ΔΕΝ ΥΠΑΡΧΕΙ ΤΟ ΑΡΧΕΙΟ C:\MERCVB\MHNYMA.TXT")
        '    Exit Sub
        'End If
        'Using sr As StreamReader = New StreamReader("C:\MERCVB\EID.CSV", System.Text.Encoding.Default)
        '    line = sr.ReadLine()

        LV2.Items.Clear()

        LV2.Columns(0).Text = "Α/Α"
        LV2.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        LV2.Columns(2).Text = "ONOMA"
        LV2.Columns(3).Text = "ΠΟΣΟΤΗΤΑ"
        LV2.Columns(4).Text = "TIMH"
        LV2.Columns(5).Text = "ΑΞΙΑ"
        'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"




        Me.TextBox1.Text = "Αναζήτηση"
        Me.TextBox1.ForeColor = Color.SlateGray


        Call Loader()

        Me.Show()


    End Sub
    Private Sub Loader()
        If gBaran = 1 Then
            LOAD_PEL("")
            Exit Sub
        End If
        LOAD_PEL("")
        Exit Sub


        Dim PINAK As OleDbDataReader
        Dim myConn2 As New OleDbConnection
        Dim myCmd2 As New OleDbCommand
        Dim strQry2 As String



        Dim SQL As String


        If myConn2.State = ConnectionState.Open Then myConn2.Close()

        myConn2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;"
        myConn2.Open()

        myCmd2.CommandText = "Select TOP 20 ID,KOD,EPO,DIE,EPA,THL,TYP,PEK from PEL " 'strQry2
        myCmd2.Connection = myConn2


        PINAK = myCmd2.ExecuteReader() 'For reading query








        ' PELATES
        ' IsConnected("Select ID,KOD,EPO,DIE,EPA,THL,TYP from PEL", False)
        Dim N As Long = 0

        LV.Items.Clear()
        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΕΠΩΝΥΜΙΑ"
        LV.Columns(2).Text = "ΕΠΑΓΓΕΛΜΑ"
        LV.Columns(3).Text = "ΥΠΟΛΟΙΠΟ"
        LV.Columns(3).TextAlign = HorizontalAlignment.Right
        LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"
        LV.Columns(5).Text = "ΚΩΔΙΚΟΣ"
        LV.Columns(6).Text = "ΔΙΕΥΘΥΝΣΗ"
        LV.Columns(7).Text = "ΖΩΝΗ"

        Dim MTYP As String
        While (PINAK.Read())
            N = N + 1
            If IsDBNull(PINAK("TYP")) = True Then
                MTYP = ""
            Else
                MTYP = Format(PINAK("TYP"), "#####0.00")
            End If
            With LV.Items.Add(PINAK(0))
                .SubItems.Add(IIf(IsDBNull(PINAK("EPO")), "", PINAK("EPO")))
                .SubItems.Add(IIf(IsDBNull(PINAK("EPA")), "", PINAK("EPA")))
                .SubItems.Add(MTYP)
                .SubItems.Add(IIf(IsDBNull(PINAK("THL")), "", PINAK("THL")))
                .SubItems.Add(IIf(IsDBNull(PINAK("KOD")), "", PINAK("KOD")))

                .SubItems.Add(IIf(IsDBNull(PINAK("DIE")), "", PINAK("DIE")))
                .SubItems.Add(IIf(IsDBNull(PINAK("PEK")), "", PINAK("PEK")))

            End With
        End While
        ToolStripStatusLabel1.Text = "   Πελάτες " + Str(N)

    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEOEIDOS.Click
        'Call login()

        ' IsConnected("DELETE FROM EGGTIM ", True)
        TextBox4.Text = ""
        If LV.SelectedItems.Count = 0 Then
            MsgBox("ΔΙΑΛΕΞΤΕ ΕΊΔΟΣ")
            Exit Sub
        Else
            ' GroupBox1.Text = LV.SelectedItems(0).SubItems(1).Text
        End If
        If gBaran = 1 Or gBaran = 93 Or gBaran = 29 Then
        Else
            If LV2.Items.Count > 21 Then
                MsgBox("Κλείστε την Παραγγελια.(22 είδη)")
            End If

        End If




        paragkentr.Text = "Νέα Εγγραφή"
        frUpdate = True
        paragkentr.ShowDialog()
        ' Form3.TextBox4.Focus()




    End Sub
    Private Sub login()
        Dim rep As Integer

        If NEOEIDOS.Text = "Login" Then
            Form1.ShowDialog()
        Else

            rep = MsgBox("Are you sure you want to logout and switch user?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, "Confirmation")
            If rep = vbOK Then

                NEOEIDOS.Text = "Login"
                Form1.Text = "Click close to quit"
                Form1.ShowDialog()

            End If
        End If
    End Sub
    Private Sub ButtonAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAdd.Click
        'Call addNew()
        If ButtonAdd.Text = "Νέα Παραγγελία" Then


            LV2.Items.Clear()
            LV.Columns(0).Text = "ID" '0
            LV2.Columns(1).Text = "ΚΩΔΙΚΟΣ" '1
            LV2.Columns(2).Text = "ΠΕΡΙΓΡΑΦΗ"  '2
            LV2.Columns(3).Text = "ΠΟΣΟΤΗΤΑ"
            LV2.Columns(4).Text = "ΤΙΜΗ"
            'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"



            'Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text
            If LV.SelectedItems.Count = 0 Then
                MsgBox("Διαλέξτε Πελάτη")
                Exit Sub
            Else
                GroupBox1.Text = LV.SelectedItems(0).SubItems(5).Text + ";" + LV.SelectedItems(0).SubItems(1).Text
                PEK.Text = LV.SelectedItems(0).SubItems(7).Text
                mekptosi.Text = LV.SelectedItems(0).SubItems(8).Text
            End If
            '
            IsConnected("SELECT * FROM ARITMISI WHERE ID=1 ", False)
            myDR.Read()

            'If myDR.RecordsAffected = 0 Then
            '    MsgBox("ΔΕΝ ΚΑΤΑΧΩΡΗΘΗΚΕ")
            '    gID_NUM = 0
            '    Exit Sub

            'End If
            gAtim = "a" + Format(IIf(IsDBNull(myDR("ARITMISI")), 1, myDR("ARITMISI") + 1), "000000")
            IsConnected("update ARITMISI set ARITMISI=ARITMISI+1 WHERE ID=1", True)

            IsConnected("Insert into TIM (KPE,ATIM,HME) values('" & _
                            LV.SelectedItems(0).SubItems(5).Text & "','" & _
                            gAtim & "','" & _
                           Format(Now, "dd/MM/yyyy") & "')", True)


            IsConnected("SELECT * FROM TIM WHERE ATIM='" + gAtim + "'", False)
            myDR.Read()
            gID_NUM = myDR("ID_NUM")

            LOAD_EIDH(" where ONO='ΣΣΣ' ")
            NEOEIDOS.Enabled = True

            ButtonAdd.Text = "Κλείσιμο Παραγγελίας"

        Else
            NEOEIDOS.Enabled = False
            sxolia.Text = ""
            Loader()
            ButtonAdd.Text = "Νέα Παραγγελία"
        End If













    End Sub
    Private Sub addNew()
        frUpdate = False
        paragkentr.ShowDialog()
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Refresh()
    End Sub
    Private Sub Refresh()
        ' PELATES
        IsConnected("Select ID,KOD,EPO,DIE,EPA,THL from PEL", False)


        LV.Items.Clear()
        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΕΠΩΝΥΜΙΑ"
        LV.Columns(2).Text = "ΕΠΑΓΓΕΛΜΑ"
        LV.Columns(3).Text = "ΔΙΕΥΘΥΝΣΗ"
        LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"

        While (myDR.Read())

            With LV.Items.Add(myDR(0))
                .SubItems.Add(myDR("EPO"))
                .SubItems.Add(IIf(IsDBNull(myDR("EPA")), "", myDR("EPA")))
                .SubItems.Add(IIf(IsDBNull(myDR("DIE")), "", myDR("DIE")))
                .SubItems.Add(IIf(IsDBNull(myDR("THL")), "", myDR("THL")))

            End With


        End While





        ' IsConnected("Select * from PEL", False)
        ' Call Loader()
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        Me.TextBox1.Text = ""
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        IsConnected("Select * from tblPersonal Where ID like '" & Me.TextBox1.Text & _
                    "%' or firstname like '" & Me.TextBox1.Text & "%' or lastname like '" & Me.TextBox1.Text & "%';", False)
        Call Loader()
    End Sub
    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Editable()
    End Sub
    Private Sub Editable()
        If frUpdate = True Then
            paragkentr.Text = "Edit entry"
            frUpdate = True
            paragkentr.ShowDialog()
        Else
            MsgBox("Please select item to edit!", MsgBoxStyle.Exclamation, "Information")
        End If
    End Sub
    Private Sub Delete()
        On Error GoTo err

        If LV2.SelectedItems.Count > 0 Then

            Dim rep As Integer
            rep = MsgBox("Να Διαγραφεί ο κωδικός " & LV2.SelectedItems(0).SubItems(1).Text & "?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
            If rep = vbYes Then
                IsConnected("Delete from EGGTIM Where ID=" & LV2.SelectedItems(0).SubItems(0).Text & " ", True)
                ' IsConnected("Select * from tblPersonal", False)
                LOAD_EGGTIM()
            Else
                frUpdate = False
            End If
        Else
            MsgBox("Διαλέξτε την σειρά που θέλετε να διαγράψετε.", MsgBoxStyle.Exclamation, "Information")
        End If
        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub
    Private Sub LV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LV.Click
        'ΣΤΗΛΕΣ ΠΟΥ ΤΣΙΜΠΑΩ ΓΙΑ FORM3 // TIMOLOGHSH
        'SubItems(0) ID ΕΙΔΟΥΣ
        '.SubItems(1)  ΚΩΔΙΚΟΣ
        '.SubItems(3)  ΕΚΠΤΩΣΗ
        '.SubItems(2) ΠΕΡΙΓΡΑΦΗ ΕΙΔΟΥΣ
        'SubItems(8)  TIMH  7
        'SubItems(3)  KANONIKH TIMH
        'SubItems(7)  ΦΠΑ
        'SubItems(9)  ΥΠΟΛΟΙΠΟ
        'SubItems(6)  ΜΟΝ ΜΕΤ
        'With LV.Items.Add(myDR(0))
        '    .SubItems.Add(myDR("KOD")) 1
        '    .SubItems.Add(IIf(IsDBNull(myDR("ONO")), "", myDR("ONO"))) '2
        '    .SubItems.Add(IIf(IsDBNull(myDR("LTI")), "", myDR("LTI"))) 3
        '    .SubItems.Add(IIf(IsDBNull(myDR("XTI")), "", myDR("XTI"))) 4
        '    .SubItems.Add(IIf(IsDBNull(myDR("KERD")), "", myDR("KERD"))) 5
        '    .SubItems.Add(IIf(IsDBNull(myDR("mon")), "", myDR("mon"))) 6
        '    .SubItems.Add(IIf(IsDBNull(myDR("FPA")), "", myDR("FPA"))) 7
        '    .SubItems.Add(IIf(IsDBNull(myDR("G07")), "", myDR("G07"))) 8
        '    .SubItems.Add(IIf(IsDBNull(myDR("POS")), "", myDR("POS"))) 9
        '    '.SubItems.Add(myDR("MON"))
        '                               LV.Columns(10).Text = "ΕΦΚ"
        '                               LV.Columns(11).Text = "ΣΥΣΚ"
        'End With

        If ButtonAdd.Text = "Νέα Παραγγελία" Then
            'ΟΚ  'den dialexe akoma pelath
        Else
            frUpdate = True
            ' Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text ' ΙD
            paragkentr.OTONH.Text = LV.SelectedItems(0).SubItems(1).Text ' ΚΩΔΙΚΟΣ
            ' Form3.PERIGRAFH.Text = LV.SelectedItems(0).SubItems(2).Text ' ΠΕΡΙΓΡΑΦΗ

            'τιμη μοναδος
            ' If Val(PEK.Text) = 7 Then
            'Form3.TIMH.Text = Replace(LV.SelectedItems(0).SubItems(8).Text, ",", ".") 'TIMH  7
            'Else
            ' Form3.TIMH.Text = LV.SelectedItems(0).SubItems(3).Text  'KANONIKH TIMH
            'End If



            Dim msysk As String, mefk As String
            'τιμη μοναδος
            Dim mTim As String, m7 As String, mx As String
            Dim m1 As String
            Dim m2 As String
            Dim m3 As String
            Dim m4 As String
            Dim m5 As String
            Dim m6 As String

            '--------------------------------------------------------------------------------------
            If gBaran = 93 Then  'mixailidis
                msysk = LV.SelectedItems(0).SubItems(11).Text 'SYSKEYASIA
                mefk = Replace(LV.SelectedItems(0).SubItems(10).Text, ",", ".") 'EFK
                paragkentr.SYSKEYASIA.Text = msysk
                paragkentr.efk.Text = mefk '* msysk


                mx = Val(Replace(LV.SelectedItems(0).SubItems(3).Text, ",", "."))


                mx = (mx + Val((mefk))) * Val(msysk)
                ' m7 = (m7 + Val((mefk))) * Val(msysk)



                m1 = Val(Replace(LV.SelectedItems(0).SubItems(12).Text, ",", "."))
                m2 = Val(Replace(LV.SelectedItems(0).SubItems(13).Text, ",", "."))
                m3 = Val(Replace(LV.SelectedItems(0).SubItems(14).Text, ",", "."))
                m4 = Val(Replace(LV.SelectedItems(0).SubItems(15).Text, ",", "."))
                m5 = Val(Replace(LV.SelectedItems(0).SubItems(16).Text, ",", "."))
                m6 = Val(Replace(LV.SelectedItems(0).SubItems(17).Text, ",", "."))
                m7 = Val(Replace(LV.SelectedItems(0).SubItems(8).Text, ",", "."))






                'If Val(PEK.Text) = 7 Then
                '    Form3.TIMH.Text = (m7 + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m7
                'ElseIf Val(PEK.Text) = 1 Then
                '    Form3.TIMH.Text = (m1 + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m1
                'ElseIf Val(PEK.Text) = 2 Then
                '    Form3.TIMH.Text = (m2 + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m2
                'ElseIf Val(PEK.Text) = 3 Then
                '    Form3.TIMH.Text = (m3 + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m3
                'ElseIf Val(PEK.Text) = 4 Then
                '    Form3.TIMH.Text = (m4 + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m4
                'ElseIf Val(PEK.Text) = 5 Then
                '    Form3.TIMH.Text = (m5 + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m5

                'ElseIf Val(PEK.Text) = 6 Then
                '    Form3.TIMH.Text = (mx + Val((mefk))) * Val(msysk) 'TIMH  7
                '    PROTYPO.KauTimh.Text = m6

                'Else
                '    Form3.TIMH.Text = mx '  (mx + Val((mefk))) * Val(msysk)
                '    ' Form3.TIMH.Text = mx  'KANONIKH TIMH 
                '    Form3.ekpt.Text = mekptosi.Text
                '    PROTYPO.KauTimh.Text = mx
                'End If


            End If



            ' Form3.Label7.Text = LV.SelectedItems(0).SubItems(6).Text ' ΜΟΝ ΜΕΤ
            paragkentr.fpa.Text = LV.SelectedItems(0).SubItems(7).Text  'ΦΠΑ

            'ΥΠΟΛΟΙΠΟ ΑΠΟΘΗΚΗΣ 
            ' Form3.apoth.Text = LV.SelectedItems(0).SubItems(9).Text 'ΥΠΟΛ.ΑΠΟΘΗΚΗΣ







        End If

        'Form3.DateTimePicker1.Value = LV.SelectedItems(0).SubItems(4).Text
        'Form3.TextBox5.Text = LV.SelectedItems(0).SubItems(5).Text

    End Sub
    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Delete()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call Editable()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Refresh()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Call Delete()
    End Sub
    Private Sub mnuNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call addNew()
    End Sub

    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call login()
    End Sub

    Private Sub mnuEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Editable()
    End Sub

    Private Sub mnuDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call Delete()
    End Sub

    Private Sub LV_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles LV.ColumnClick
        'Me.LV.ListViewItemSorter = New ListViewItemComparer(e.Column)
        ' Call the sort method to manually sort.
        'LV.Sort()


        ' Determine whether the column is the same as the last column clicked.
        If e.Column <> sortColumn Then
            ' Set the sort column to the new column.
            sortColumn = e.Column
            ' Set the sort order to ascending by default.
            LV.Sorting = SortOrder.Ascending
        Else
            ' Determine what the last sort order was and change it.
            If LV.Sorting = SortOrder.Ascending Then
                LV.Sorting = SortOrder.Descending
            Else
                LV.Sorting = SortOrder.Ascending
            End If
        End If
        ' Call the sort method to manually sort.
        LV.Sort()
        ' Set the ListViewItemSorter property to a new ListViewItemComparer
        ' object.
        LV.ListViewItemSorter = New ListViewItemComparer(e.Column, _
                                                         LV.Sorting)



    End Sub

    Private Sub LV_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles LV.MouseClick

    End Sub

    Private Sub LV_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV.SelectedIndexChanged

        If ButtonAdd.Text = "Νέα Παραγγελία" Then
            'ΟΚ
        Else
            Exit Sub

        End If





        'Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text
        If LV.SelectedItems.Count = 0 Then
            ' MsgBox("Διαλέξτε Πελάτη")
            Exit Sub
        Else
            ' GroupBox1.Text = LV.SelectedItems(0).SubItems(1).Text
        End If
        '



        IsConnected("Select KOD,HME,ATIM,XREOSI,PISTOSI  from EGG WHERE KOD='" + LV.SelectedItems(0).SubItems(5).Text + "' ORDER BY HME ", False)  ' WHERE ATIM='22'

        ' Call Loader()
        LV2.Items.Clear()




        LV2.Columns(0).Text = "ΚΩΔΙΚΟΣ"
        LV2.Columns(1).Text = "HMEP"
        LV2.Columns(2).Text = "ΠΑΡ/ΚΟ"
        LV2.Columns(2).Width = 100
        LV2.Columns(3).Text = "ΧΡΕΩΣΗ"
        LV2.Columns(3).Width = 100
        LV2.Columns(3).TextAlign = HorizontalAlignment.Right
        LV2.Columns(4).Text = "ΠΙΣΤΩΣΗ"
        LV2.Columns(4).Width = 100
        LV2.Columns(4).TextAlign = HorizontalAlignment.Right




        While (myDR.Read())

            With LV2.Items.Add(myDR(0))
                '.SubItems.Add(myDR("KOD"))
                .SubItems.Add(IIf(IsDBNull(myDR("HME")), "", myDR("HME")))
                .SubItems.Add(IIf(IsDBNull(myDR("ATIM")), "", myDR("ATIM")))
                .SubItems.Add(IIf(IsDBNull(myDR("XREOSI")), "", Format(myDR("XREOSI"), "#####0.00")))
                .SubItems.Add(IIf(IsDBNull(myDR("PISTOSI")), "", Format(myDR("PISTOSI"), "#####0.00")))

            End With


        End While
        LV2.Refresh()



        's not actually easy/possible to scroll the list view. You need to tell the item to make sure it's visible.
        'ΔΕΙΧΝΩ ΤΗΝ ΤΕΛΕΥΤΑΙΑ ΕΓΓΡΑΦΗ
        Dim LAST As ListViewItem

        If LV2.Items.Count > 0 Then
            LAST = LV2.Items(LV2.Items.Count - 1)
            LAST.EnsureVisible()

        End If





    End Sub

    Private Sub mnuAboutme_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'τραβαει τις εγγραφές από wifi record by record (for-next)


        Dim k As Long, KL As Long
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet

        k = openWifiSQL("select  * from EID order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString
        Dim mKod As String
        Dim mepo As String
        Dim mLti5 As String









        If k > 0 Then
            KL = IsConnected("DELETE from EID", True)

            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mepo = Replace(Trim(FDS.Tables(0).Rows(k).Item("ONO").ToString), "'", "''")
                mLti5 = Replace(Trim(FDS.Tables(0).Rows(k).Item("lti").ToString), ",", ".")

                'SEIRA = Space(100)
                KL = IsConnected("INSERT INTO EID (KOD,ONO,LTI) VALUES ('" + mKod + "','" + mepo + "'," + mLti5 + ")", True)
                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(k, "#####")
                End If
                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

            Next k
            MsgBox("OK " + Str(k) + " ΕΙΔΗ")
        End If


        '======================================================================
        k = openWifiSQL("select  * from PEL order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString

        Dim mEPA As String
        Dim mDIE As String
        Dim MTYP As String
        If k > 0 Then
            KL = IsConnected("DELETE from PEL", True)

            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mepo = Replace(Trim(FDS.Tables(0).Rows(k).Item("EPO").ToString), "'", "''")
                mLti5 = Replace(Trim(FDS.Tables(0).Rows(k).Item("lti").ToString), ",", ".")
                mDIE = Replace(Trim(FDS.Tables(0).Rows(k).Item("DIE").ToString), ",", ".")
                mEPA = Trim(FDS.Tables(0).Rows(k).Item("EPA").ToString)
                MTYP = Replace(Trim(FDS.Tables(0).Rows(k).Item("TYP").ToString), ",", ".")
                'SEIRA = Space(100)
                KL = IsConnected("INSERT INTO PEL (KOD,EPO,DIE,EPA,TYP) VALUES ('" + mKod + "','" + mepo + "','" + mDIE + "','" + mEPA + "'," + MTYP + ")", True)
                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(k, "#####")
                End If
                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

            Next k
            MsgBox("OK " + Str(k) + " πελατες")
        End If

        '======================================================================
        k = openWifiSQL("select * from EGG order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString

        Dim mATIM As String
        'Dim mDIE As String
        Dim MXR As String
        Dim MPIS As String
        Dim MHME As String

        If k > 0 Then
            KL = IsConnected("DELETE from EGG", True)

            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mATIM = Trim(FDS.Tables(0).Rows(k).Item("ATIM").ToString)
                MHME = FDS.Tables(0).Rows(k).Item("HME").ToString
                MXR = Replace(Trim(FDS.Tables(0).Rows(k).Item("XREOSI").ToString), ",", ".")
                MPIS = Replace(Trim(FDS.Tables(0).Rows(k).Item("PISTOSI").ToString), ",", ".")
                'SEIRA = Space(100)
                KL = IsConnected("INSERT INTO EGG (KOD,ATIM,HME,XREOSI,PISTOSI) VALUES ('" + mKod + "','" + mATIM + "','" + MHME + "'," + MXR + "," + MPIS + ")", True)
                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(k, "#####")
                End If
                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

            Next k
            MsgBox("OK " + Str(k) + " KINHΣEIΣ")
        End If









    End Sub


    'Public Function openWifiSQL(ByVal sql As String, ByRef FDS As System.Data.DataSet) As Long

    '    Dim fobjcon As SqlConnection, fobjcmd As New SqlCommand
    '    Dim c As String = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
    '    'Dim FDS As New System.Data.DataSet
    '    Dim FDA As New SqlDataAdapter

    '    Try
    '        fobjcon = New SqlConnection(c)


    '        fobjcmd = New SqlCommand(sql, fobjcon)
    '        fobjcmd.Connection.Open()
    '        FDA.SelectCommand = fobjcmd
    '        FDS.Clear()
    '        FDA.Fill(FDS)
    '        openWifiSQL = FDS.Tables.Count
    '        fobjcon.Close()
    '    Catch ex As Exception
    '        MsgBox("Can't load Web page" & vbCrLf & ex.Message)
    '        openWifiSQL = -1
    '    End Try



    'End Function





    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        LOAD_EIDH("")



    End Sub
    Sub LOAD_EGGTIM()

        IsConnected("Select ID,KODE,ONOMA,POSO,TIMM,KAU_AJIA,KOLA,FPA  from EGGTIM WHERE ID_NUM=" + Str(gID_NUM), False)  ' WHERE ATIM='22'
        ' Call Loader()
        LV2.Items.Clear()



        LV.Columns(0).Text = "ID"
        LV2.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        LV2.Columns(2).Text = "ΠΕΡΙΓΡΑΦΗ"
        LV2.Columns(3).Text = "ΠΟΣΟΤΗΤΑ"
        LV2.Columns(4).Text = "ΤΙΜΗ"
        LV2.Columns(5).Text = "ΑΞΙΑ"
        LV2.Columns(6).Text = "ΑΠΟΘ.ΠΕΛ"


        Dim AX As Single = 0



        While (myDR.Read())

            With LV2.Items.Add(myDR(0))
                .SubItems.Add(myDR("KODE"))
                .SubItems.Add(IIf(IsDBNull(myDR("ONOMA")), "", myDR("ONOMA")))
                .SubItems.Add(IIf(IsDBNull(myDR("POSO")), "", myDR("POSO")))
                .SubItems.Add(IIf(IsDBNull(myDR("TIMM")), "", myDR("TIMM")))

                .SubItems.Add(IIf(IsDBNull(myDR("KAU_AJIA")), "", myDR("KAU_AJIA")))
                .SubItems.Add(IIf(IsDBNull(myDR("KOLA")), "", myDR("KOLA")))




                If myDR("FPA") = 1224 Or myDR("FPA") = 2 Or myDR("FPA") = 6 Then
                    AX = AX + myDR("KAU_AJIA") * 1.24
                ElseIf myDR("FPA") = 1130 Or myDR("FPA") = 1 Then
                    AX = AX + myDR("KAU_AJIA") * 1.13
                ElseIf myDR("FPA") = 1000 Or myDR("FPA") = 5 Then
                    AX = AX + myDR("KAU_AJIA") * 1
                Else
                    AX = AX + myDR("KAU_AJIA")

                End If
            End With


        End While
        LV2.Refresh()
        AXIA.Text = AX
        'ΔΕΙΧΝΩ ΤΗΝ ΤΕΛΕΥΤΑΙΑ ΕΓΓΡΑΦΗ
        Dim LAST As ListViewItem

        If LV2.Items.Count > 0 Then
            LAST = LV2.Items(LV2.Items.Count - 1)
            LAST.EnsureVisible()

        End If




    End Sub


    Public Function SameLetters(ByVal ST As String) As String

        'ΓΙΑ ΝΑ ΨΑΧΝΕΙ ΚΑΙ ΜΕ ΤΟ Α ΤΟ ΛΑΤΙΝΙΚΟ ΚΑΙ ΜΕ ΤΟ Α ΤΟ ΕΛΛΗΝΙΚΟ
        'ΔΙΝΩ ΕΝΑ ΣΤΡΙΝΚ Π.Χ. 'ΜΟ' ΚΑΙ ΜΟΥ ΕΠΙΣΤΡΕΦΕΙ '[ΜΜ][ΟΟ]' ΓΙΑ
        ' ΝΑ ΜΟΥ ΒΡΙΣΚΕΙ ΚΑΙ ΤΟ "MO BITEL"   KAI TO  "ΜΟ ΧΩΡΙΔΗΣ"
        '<EhHeader>


        '</EhHeader>
        Dim l As Integer, k As Integer

        Dim s As String

        Dim N As Integer

        Dim C As String



120:    ST = Replace(ST, "'", "~")

        If Len(ST) > 1 Then
122:        '   ST = Replace(ST, "*", "%")
        End If

130:    l = Len(ST)
140:    s = ""

150:    For k = 1 To l
160:        C = mID$(ST, k, 1)
170:        N = InStr("ABCDEFGHIJKLMNOPQRSTUYVWZX-ΑΒΓΔΕΖΗΘΙΚΛΜΝΞΟΠΡΣΤΥΦΧΨΩ", C)

            If N = 0 Then
                s = s + C
            ElseIf N > 0 Then

                Select Case C

                    Case "R"
                        s = s + "[RΡρr]"

                    Case "U"
                        s = s + "[UΘθu]"

                    Case "S"
                        s = s + "[SΣσςs]"

                    Case "D"
                        s = s + "[DΔdδ]"

                    Case "F"
                        s = s + "[FΦφf]"

                    Case "G"
                        s = s + "[GΓgγ]"

                    Case "J"
                        s = s + "[JΞξj]"

                    Case "L"
                        s = s + "[LΛlλ]"

                    Case "C"
                        s = s + "[CΨcψ]"

                    Case "V"
                        s = s + "[VΩωv]"



                    Case "E"
                        s = s + "[EΕεeέΈ]"
                    Case "T"
                        s = s + "[TΤtτ]"
                    Case "Y"
                        s = s + "[YΥyυ]"

                    Case "O"
                        s = s + "[OΟoοόΌ]"
                    Case "P"    'ΞΕΝΟ
                        s = s + "[pPπΠ]"

                    Case "Α"    ' ELLINIKO
                        s = s + "[αΑaA]"
                    Case "Β"    ' ELLINIKO
                        s = s + "[ΒβBb]"
                    Case "Γ"
                        s = s + "[GΓgγ]"
                    Case "Δ"    ' ELLINIKO
                        s = s + "[ΔδdD]"
                    Case "Ε"    ' ELLINIKO
                        s = s + "[ΕεeE]"
                    Case "Ζ"    ' ELLINIKO
                        s = s + "[ΖζZz]"
                    Case "Η"    ' ELLINIKO
                        s = s + "[ΗηHh]"
                    Case "Θ"    ' ELLINIKO
                        s = s + "[ΘθuU]"
                    Case "Ι"    ' ELLINIKO
                        s = s + "[IiΙι]"
                    Case "Κ"    ' ELLINIKO
                        s = s + "[ΚκKk]"
                    Case "Λ"    ' ELLINIKO
                        s = s + "[ΛλLl]"
                    Case "Μ"    ' ELLINIKO
                        s = s + "[MmΜμ]"
                    Case "Ν"    ' ELLINIKO
                        s = s + "[ΝνNn]"
                    Case "Ξ"    ' ELLINIKO
                        s = s + "[ΞξJj]"
                    Case "Ο"    ' ELLINIKO
                        s = s + "[ΟοoO]"
                    Case "Π"    ' ELLINIKO
                        s = s + "[ΠπPp]"
                    Case "Ρ"    ' ELLINIKO
                        s = s + "[RrΡρ]"
                    Case "Σ"    ' ELLINIKO
                        s = s + "[ΣσsS]"
                    Case "Τ"    ' ELLINIKO
                        s = s + "[ΤτTt]"
                    Case "Υ"    ' ELLINIKO
                        s = s + "[ΥυyY]"
                    Case "Φ"    ' ELLINIKO
                        s = s + "[ΦφfF]"
                    Case "Χ"    ' ELLINIKO
                        s = s + "[ΧχXx]"
                    Case "Ψ"    ' ELLINIKO
                        s = s + "[ΨψCc]"

                    Case "Ω" ' ELLINIKO
                        s = s + "[ΩωvV]"
                    Case Else
                        s = s + C





                End Select

            End If

        Next

970:    SameLetters = s

        '<EhFooter>
        Exit Function



    End Function





    Sub LOAD_EIDH(ByVal synt As String)
        If Len(synt) < 2 Then
            synt = ""

        End If
        Dim c As String

        c = "Select top 10000 ID,KOD,ONO,LTI,XTI,ROUND(POS_KERD,1) AS KERD,MON,FPA,G07,POS,LTI_SYNOD,SYSKEYASIA,G01,G02,G03,G04,G05,G06  from EID " + synt + " order BY ONO "
        IsConnected(c, False)
        ' Call Loader()
        LV.Items.Clear()

        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        LV.Columns(2).Text = "ONOMA"
        LV.Columns(3).Text = "XONDR.TIMH"
        LV.Columns(4).Text = "TIMH ΑΓΟΡΑΣ"
        LV.Columns(4).TextAlign = HorizontalAlignment.Right
        LV.Columns(4).Width = 300


        LV.Columns(5).Text = "ΠΟΣ.% ΚΕΡΔ"
        'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"
        LV.Columns(6).Text = "MON.MET"
        LV.Columns(7).Text = "ΦΠΑ"
        MHNYMA.Text = f_mess_eid

        LV.Columns(8).Text = "TIM 7"
        LV.Columns(9).Text = "ΥΠΟΛ"


        LV.Columns(10).Text = "ΕΦΚ"
        LV.Columns(11).Text = "ΣΥΣΚ"


        LV.Columns(12).Text = "TIM 1"
        LV.Columns(13).Text = "TIM 2"
        LV.Columns(14).Text = "TIM 3"
        LV.Columns(15).Text = "TIM 4"
        LV.Columns(16).Text = "TIM 5"
        LV.Columns(17).Text = "TIM 6"


        Dim N As Integer
        For N = 1 To 9
            LV.Columns(N - 1).Width = Split(F_PLATH_EID, ";")(N - 1) 'Split(line, ";")(0)
        Next




        ' If myDR.RecordsAffected = 0 Then Exit Sub

        While (myDR.Read())

            With LV.Items.Add(myDR(0))
                .SubItems.Add(myDR("KOD"))
                .SubItems.Add(IIf(IsDBNull(myDR("ONO")), "", myDR("ONO"))) '
                .SubItems.Add(IIf(IsDBNull(myDR("LTI")), "", myDR("LTI")))
                .SubItems.Add(IIf(IsDBNull(myDR("XTI")), "", myDR("XTI")))
                .SubItems.Add(IIf(IsDBNull(myDR("KERD")), "", myDR("KERD")))
                .SubItems.Add(IIf(IsDBNull(myDR("mon")), "", myDR("mon")))
                .SubItems.Add(IIf(IsDBNull(myDR("FPA")), "", myDR("FPA")))
                .SubItems.Add(IIf(IsDBNull(myDR("G07")), "", myDR("G07")))
                .SubItems.Add(IIf(IsDBNull(myDR("POS")), "", myDR("POS")))

                .SubItems.Add(IIf(IsDBNull(myDR("LTI_SYNOD")), "", myDR("LTI_SYNOD")))
                .SubItems.Add(IIf(IsDBNull(myDR("SYSKEYASIA")), "", myDR("SYSKEYASIA")))
                .SubItems.Add(IIf(IsDBNull(myDR("G01")), "", myDR("G01")))
                .SubItems.Add(IIf(IsDBNull(myDR("G02")), "", myDR("G02")))
                .SubItems.Add(IIf(IsDBNull(myDR("G03")), "", myDR("G03")))
                .SubItems.Add(IIf(IsDBNull(myDR("G04")), "", myDR("G04")))
                .SubItems.Add(IIf(IsDBNull(myDR("G05")), "", myDR("G05")))
                .SubItems.Add(IIf(IsDBNull(myDR("G06")), "", myDR("G06")))


                '.SubItems.Add(myDR("MON"))

            End With


        End While

    End Sub
    Sub LOAD_PEL(ByVal synt As String)
        If Len(synt) < 2 Then
            synt = ""
            If gBaran = 1 Then

                synt = " WHERE  AEG=" + Str(Weekday(Now))
                DatePart(DateInterval.Day, Now)


            End If

        End If




        Dim PINAK As OleDbDataReader
        Dim myConn2 As New OleDbConnection
        Dim myCmd2 As New OleDbCommand
        Dim strQry2 As String
        Dim n As Integer



        Dim SQL As String


        If myConn2.State = ConnectionState.Open Then myConn2.Close()

        myConn2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;"
        myConn2.Open()

        myCmd2.CommandText = "Select TOP 20 ID,KOD,EPO,DIE,EPA,THL,TYP,PEK,XRE from PEL " + synt + " ORDER BY EPO" 'strQry2
        myCmd2.Connection = myConn2


        PINAK = myCmd2.ExecuteReader() 'For reading query



        'Dim c As String
        'c = "Select top 10000 ID,KOD,EPO,DIE,AFM,PEK,EPA   from PEL " + synt + " ORDER BY EPO"
        'IsConnected(c, False)

        MHNYMA.Text = f_mess_pel

        LV.Items.Clear()
        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΕΠΩΝΥΜΙΑ"
        LV.Columns(2).Text = "ΕΠΑΓΓΕΛΜΑ"
        LV.Columns(3).Text = "ΥΠΟΛΟΙΠΟ"
        LV.Columns(3).TextAlign = HorizontalAlignment.Right
        LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"
        LV.Columns(5).Text = "ΚΩΔΙΚΟΣ"
        LV.Columns(6).Text = "ΔΙΕΥΘΥΝΣΗ"
        LV.Columns(7).Text = "ΖΩΝΗ"
        LV.Columns(8).Text = "ΠΟΣΟΣΤΟ ΕΚΠΤ"
        For n = 1 To 9
            LV.Columns(n - 1).Width = Split(F_PLATH_PEL, ";")(n - 1) 'Split(line, ";")(0)
        Next
        n = 0
        Dim MTYP As String
        While (PINAK.Read())
            N = N + 1
            If IsDBNull(PINAK("TYP")) = True Then
                MTYP = ""
            Else
                MTYP = Format(PINAK("TYP"), "#####0.00")
            End If
            With LV.Items.Add(PINAK(0))
                .SubItems.Add(IIf(IsDBNull(PINAK("EPO")), "", PINAK("EPO")))
                .SubItems.Add(IIf(IsDBNull(PINAK("EPA")), "", PINAK("EPA")))
                .SubItems.Add(MTYP)
                .SubItems.Add(IIf(IsDBNull(PINAK("THL")), "", PINAK("THL")))
                .SubItems.Add(IIf(IsDBNull(PINAK("KOD")), "", PINAK("KOD")))

                .SubItems.Add(IIf(IsDBNull(PINAK("DIE")), "", PINAK("DIE")))
                .SubItems.Add(IIf(IsDBNull(PINAK("PEK")), "", PINAK("PEK")))
                .SubItems.Add(IIf(IsDBNull(PINAK("XRE")), "", PINAK("XRE")))
            End With
        End While



































        '' Call Loader()
        'LV.Items.Clear()

        'LV.Columns(0).Text = "Α/Α"
        'LV.Columns(0).Width = 5
        'LV.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        'LV.Columns(1).Width = 5
        'LV.Columns(2).Text = "ONOMA"
        'LV.Columns(2).Width = 400
        'LV.Columns(3).Text = "ΔΙΕΥΘΥΝΣΗ"
        'LV.Columns(3).Width = 400
        'LV.Columns(4).Text = "Α.Φ.Μ."
        'LV.Columns(3).TextAlign = HorizontalAlignment.Left


        'Dim N As Integer
        'For N = 1 To 7
        '    LV.Columns(N - 1).Width = Split(F_PLATH_PEL, ";")(N) 'Split(line, ";")(0)
        'Next




        'While (myDR.Read())

        '    With LV.Items.Add(myDR(0))
        '        .SubItems.Add(myDR("KOD"))
        '        .SubItems.Add(IIf(IsDBNull(myDR("EPO")), "", myDR("EPO")))
        '        .SubItems.Add(IIf(IsDBNull(myDR("DIE")), "", myDR("DIE")))
        '        .SubItems.Add(IIf(IsDBNull(myDR("AFM")), "", myDR("AFM")))
        '        .SubItems.Add(myDR("KOD"))
        '        ' .SubItems.Add(IIf(IsDBNull(myDR("KERD")), "", myDR("KERD")))

        '    End With


        'End While

    End Sub

    Private Sub ToolStrip1_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LOAD_EGGTIM()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TOPC.Click

        If gBaran = 1 Or gBaran = 93 Or gBaran = 29 Then
            If gBaran = 1 Then

                TO_EXCELVAR()
            Else
                TO_CSV()
            End If


            Exit Sub
        End If



        ' ================   TO PC ------------------------------------------------
        Dim k As Long, KL As Long
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet

        k = openWifiSQL("select TOP 1  * from EID order by KOD", FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString
        Dim mKod As String
        Dim mepo As String
        Dim mLti5 As String


        Dim PINAK As OleDbDataReader
        Dim myConn2 As New OleDbConnection
        Dim myCmd2 As New OleDbCommand
        Dim strQry2 As String



        Dim SQL As String


        If myConn2.State = ConnectionState.Open Then myConn2.Close()

        myConn2.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;"
        myConn2.Open()

        myCmd2.CommandText = "Select *  from TIM " 'strQry2
        myCmd2.Connection = myConn2


        PINAK = myCmd2.ExecuteReader() 'For reading query








        'IsConnected("Select *  from TIM ", False, PINAK)
        Dim Synt As String
        Dim mKPE As String
        Dim mHME As String
        Dim mID_num As String

        ' k = openWifiSQL("Begin Transaction t1;", FDS)

        Dim Temp_Atim As String, Real_Atim As String



        While (PINAK.Read())

            Temp_Atim = "*" + PINAK("ATIM")

            Real_Atim = PINAK("ATIM")

            Synt = " ATIM='" + Real_Atim + "' AND HME='" + Format(PINAK("HME"), "MM/dd/yyyy") + "';"
            k = openWifiSQL("select * from TIM WHERE " + Synt, FDS)


            If FDS.Tables(0).Rows.Count = 0 Then  ' ΕΑΝ ΔΕΝ ΥΠΑΡΧΕΙ ΤΟΤΕ ΤΟ ΠΡΟΣΘΕΤΕΙ


                SQL = "INSERT INTO TIM (EIDOS,ATIM,KPE,HME,KLEIDI) VALUES ('e','"
                SQL = SQL + Temp_Atim + "','" + PINAK("KPE") + "','" + Format(PINAK("HME"), "MM/dd/yyyy") + "','" + Temp_Atim + "');"
                k = openWifiSQL(SQL, FDS)

                Synt = " ATIM='" + Temp_Atim + "' AND HME='" + Format(PINAK("HME"), "MM/dd/yyyy") + "';"
                k = openWifiSQL("select * from TIM WHERE " + Synt, FDS)

                mID_num = FDS.Tables(0)(0)("ID_NUM").ToString
                mKPE = PINAK("KPE")  ' FDS.Tables(0)(0)("KPE").ToString
                mHME = Format(FDS.Tables(0)(0)("HME"), "dd/MM/yyyy")



                'If FDS.Tables(0).Rows.Count > 0 Then
                IsConnected("UPDATE EGGTIM SET PELKOD='" + mKPE + "', HME='" + mHME + "',ID_NUM=" + mId_num + " WHERE  ATIM='" + PINAK("ATIM") + "'", True)


                '///////////////////////////////////////////////////////////////////////////////
                IsConnected("Select *  from EGGTIM WHERE ID_NUM = " + mID_num, False)
                Dim MMON As String
                Dim mSxolia As String = ""
                While (myDR.Read())
                    'k = openWifiSQL("select TOP 1  * from EID where KOD='" + myDR("KODE") + "'", FDS)

                    'If IsDBNull(FDS.Tables(0).Rows(k).Item("MON")) Then
                    '    MMON = "..."
                    'Else
                    '    MMON = FDS.Tables(0).Rows(k).Item("MON").ToString()
                    'End If


                    SQL = "INSERT INTO EGGTIM (HME,KODE,ID_NUM,EIDOS,APOT,FPA,ONOMA,ATIM,POSO,TIMM) VALUES ('" + Format(myDR("HME"), "MM/dd/yyyy") + "','" + myDR("KODE") + "'," + Str(myDR("ID_NUM")) + ",'e',1," + Str(myDR("FPA")) + ",'" + myDR("ONOMA") + "','"
                    SQL = SQL + myDR("ATIM") + "'," + Replace(Str(myDR("POSO")), ",", ".") + "," + Replace(Format(myDR("TIMM"), "##0.00"), ",", ".") + ");"
                    k = openWifiSQL(SQL, FDS)
                    If IsDBNull(myDR("proeleysh")) Then
                    Else
                        mSxolia = myDR("proeleysh")
                    End If

                End While

                k = openWifiSQL("update TIM SET PARAT='" + mSxolia + "',ATIM='" + Real_Atim + "' WHERE ID_NUM=" + mID_num, FDS)

                TO_CSV2(mID_num)


                Dim sCommand As String

                ' Shell("notepad /P C:\MERCVB\EGGTIM2.TXT ", AppWinStyle.Hide)
                'Shell("cmd.exe  /a /c TYPE c:\mercvb\eggtim2.txt   >   c:\mercvb\eggtim3.txt ", AppWinStyle.Hide)

                ' PrintDocument1.Print()
                'typono()
                ' Kill("C:\MERCVB\EGGTIM2.TXT")

                ' PrintDocument1.Print()


                'End If
            End If
        End While



        ' k = openWifiSQL("Commit Transaction t1;", FDS)
        ' Gdb.CommitTrans
        'Gdb.Execute("UPDATE  TIM SET AJ2=" + Replace(Str(Round(NNUL(R6!fpa2), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ3=" + Replace(Str(Round(NNUL(R6!fpa3), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ4=" + Replace(Str(Round(NNUL(R6!fpa4), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ5=" + Replace(Str(Round(NNUL(R6!FPA5), 2)), ",", ".") + " WHERE ID_NUM=" + Str(ID_NUM(KN)))
        'Gdb.Execute("UPDATE  TIM SET AJ1=AJ1-AJ2-AJ3-AJ4-AJ5 WHERE ID_NUM=" + Str(ID_NUM(KN)))


        '   IsConnected("Select *  from EGGTIM ", False)

        '  While (myDR.Read())
        'SQL = "INSERT INTO EGGTIM (HME,KODE,ID_NUM,EIDOS,APOT,FPA,ONOMA,ATIM,POSO,TIMM) VALUES ('" + Format(myDR("HME"), "MM/dd/yyyy") + "','" + myDR("KODE") + "'," + Str(myDR("ID_NUM")) + ",'e',1,2,'" + myDR("ONOMA") + "','"
        'SQL = SQL + myDR("ATIM") + "'," + Replace(Str(myDR("POSO")), ",", ".") + "," + Replace(Format(myDR("TIMM"), "##0.00"), ",", ".") + ")"
        'k = openWifiSQL(SQL, FDS)
        'End While






        MsgBox("ok")







    End Sub





    Sub LOADMIX() ' 


        Dim ans As Integer

        'ans = MsgBox("Να διαγραφεί τρέχων κατάλογος; Είσαι σίγουρος;", MsgBoxStyle.YesNo)
        'If ans = vbNo Then
        ' Exit Sub
        ' End If





        DB_LOAD_EIDH()
        DB_LOADpel()
    End Sub

    Sub DB_LOAD_EIDH()
        Dim MCompany As String   ' GIA OKO 1001 GIA MIX

        Dim SQL As String
        Dim ans As Integer
        Dim mono_times As Integer

        ans = MsgBox("Ενημερώνω τα είδη;", MsgBoxStyle.YesNo)
        If ans = vbNo Then
            Exit Sub
        End If



        mono_times = MsgBox("Ενημερώνω μόνο Xονδ.Tιμή,Ποσότητα" + Chr(13) + "και νέα είδη;", MsgBoxStyle.YesNo)
       







        If gBaran = 29 Then  ' OKO
            MCompany = "10"
            SQL = "SELECT  code AS KOD,name AS ONO,pricew as LTI,pricer as timlianikis,pricew01,pricew02,pricew03,pricew04,pricew05,pricew06,pricew07,vat,"
            SQL = SQL + "(SELECT TOP 1  QTY1 FROM   MTRDATA WHERE MTRL=M.MTRL  ORDER BY  SALLPDATE DESC ) AS YPOL ,"
            SQL = SQL + " '' AS EGGYODOSIA"
            SQL = SQL + " FROM  mtrl  M   "
            SQL = SQL + " WHERE SODTYPE=51  and COMPANY=" + MCompany + "  ORDER BY NAME"
        Else  'ΜΙΧΑΗΛΙΔΗΣ
            MCompany = "1001"
            SQL = "SELECT  code AS KOD,name AS ONO,pricew as LTI,pricer as timlianikis,pricew01,pricew02,pricew03,pricew04,pricew05,pricew06,pricew07,vat,"
            SQL = SQL + "(SELECT TOP 1  QTY1 FROM   MTRDATA WHERE MTRL=M.MTRL  ORDER BY  SALLPDATE DESC ) AS YPOL ,"
            SQL = SQL + "(SELECT TOP 1 B.CODE  FROM CCCEGIODOSIA A LEFT OUTER JOIN MTRL B ON A.MTRL1=B.MTRL WHERE A.MTRL=M.MTRL    ) AS EGGYODOSIA"
            SQL = SQL + " FROM  mtrl  M   LEFT JOIN CCCEGIODOSIA E   ON M.MTRL=E.MTRL "
            SQL = SQL + " WHERE SODTYPE=51 AND M.COMPANY=" + MCompany + " ORDER BY NAME"
        End If


        Dim SQLMIX As String
        '= "SELECT top 120 code AS KOD,name AS ONO,pricew as LTI,pricer as timlianikis,pricew01,pricew02,pricew03,pricew04,pricew05,pricew06,pricew07,vat,"
        '   SQLMIX = SQLMIX + "(SELECT TOP 1  QTY1 FROM   MTRDATA WHERE MTRL=MTRL.MTRL  ORDER BY  SALLPDATE DESC ) AS YPOL FROM  MTRL    WHERE SODTYPE=51    "


        'τραβαει τις εγγραφές από wifi record by record (for-next)


        Dim k As Long, KL As Long
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet

        Dim FDSFOROS As New System.Data.DataSet

        ' SQL = "select top 10 * from MTRDATA"  'DEBUG SBHSTO META
        k = openWifiSQL(SQL, FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString   '19650 real onoma 
        Dim mKod As String
        Dim mepo As String
        Dim mLti5 As String
        Dim MKODSYNOD As String
        Dim mTIM7 As String
        Dim mTIM1, mTIM2, mTIM3, mTIM4, mTIM5, mTIM6 As String
        Dim MPOSO As String


        Dim SQL2 As String
        Dim MFPA As String
        Dim pl As Long = FDS.Tables(0).Rows.Count

        Dim SQLFOROS As String = "SELECT  A.MU21 AS SYSKEYASIA,A.EXPVAL1 AS LTI_SYNOD,A.COMPANY,A.SODTYPE,A.LOCKID,A.MTRL,A.CODE,A.NAME"
        SQLFOROS = SQLFOROS + " FROM (((((((MTRL A LEFT OUTER JOIN MTRL B ON A.RELITEM=B.MTRL) LEFT OUTER JOIN MTRL C ON A.MTRRPLCODE=C.MTRL) LEFT OUTER JOIN TRDR D ON A.MTRCUS=D.TRDR) LEFT OUTER JOIN TRDR E ON A.MTRSUP=E.TRDR) LEFT OUTER JOIN TRDBRANCH F ON A.MTRSUPBRANCH=F.TRDBRANCH) LEFT OUTER JOIN CDIM G ON A.COMPANY=G.COMPANY AND A.CDIM1=G.CDIM) LEFT OUTER JOIN CDIM H ON A.COMPANY=H.COMPANY AND A.CDIM2=H.CDIM) LEFT OUTER JOIN CDIM I ON A.COMPANY=I.COMPANY AND A.CDIM3=I.CDIM "
        SQLFOROS = SQLFOROS + "WHERE A.SODTYPE=51 AND A.CODE='"    ' 100000'"

        Dim KF As Long
        Dim MLTI_SYNOD As String
        Dim MSYSKEYASIA As String


        If k > 0 Then
            If mono_times = vbNo Then
                KL = IsConnected("DELETE from EID", True)
            End If

            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mepo = Replace(Trim(FDS.Tables(0).Rows(k).Item("ONO").ToString), "'", "''")
                MKODSYNOD = Trim(FDS.Tables(0).Rows(k).Item("EGGYODOSIA").ToString)
                mLti5 = Replace(Trim(FDS.Tables(0).Rows(k).Item("lti").ToString), ",", ".")
                If Val(mLti5) = 0 Then
                    mLti5 = "0"
                End If


                'ΒΡΙΣΚΩ ΤΟΝ ΕΙΔΙΚΟ ΦΟΡΟ ΚΑΤΑΝΆΛΩΣΗς ΚΑΙ ΤΗΝ ΣΥΣΚΕΥΑΣΙΑ
                KF = openWifiSQL(SQLFOROS + mKod + "'", FDSFOROS)
                MLTI_SYNOD = Replace(FDSFOROS.Tables(0).Rows(0).Item("LTI_SYNOD").ToString, ",", ".")
                MSYSKEYASIA = Replace(FDSFOROS.Tables(0).Rows(0).Item("SYSKEYASIA").ToString, ",", ".")
                If MLTI_SYNOD = Nothing Then
                    MLTI_SYNOD = "0"
                End If
                If MSYSKEYASIA = Nothing Then
                    MSYSKEYASIA = "1"
                End If




                mTIM1 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew01").ToString), ",", ".")
                If Val(mTIM1) = 0 Then
                    mTIM1 = "0"
                End If


                mTIM2 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew02").ToString), ",", ".")
                If Val(mTIM2) = 0 Then
                    mTIM2 = "0"
                End If



                mTIM3 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew03").ToString), ",", ".")
                If Val(mTIM3) = 0 Then
                    mTIM3 = "0"
                End If




                mTIM4 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew04").ToString), ",", ".")
                If Val(mTIM4) = 0 Then
                    mTIM4 = "0"
                End If





                mTIM5 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew05").ToString), ",", ".")
                If Val(mTIM5) = 0 Then
                    mTIM5 = "0"
                End If


                mTIM6 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew06").ToString), ",", ".")
                If Val(mTIM6) = 0 Then
                    mTIM6 = "0"
                End If




                mTIM7 = Replace(Trim(FDS.Tables(0).Rows(k).Item("pricew07").ToString), ",", ".")
                If Val(mTIM7) = 0 Then
                    mTIM7 = "0"
                End If

                MPOSO = Replace(Trim(FDS.Tables(0).Rows(k).Item("YPOL").ToString), ",", ".")
                If Val(MPOSO) = 0 Then
                    MPOSO = "0"
                End If

                MFPA = Replace(Trim(FDS.Tables(0).Rows(k).Item("vat").ToString), ",", ".")


                'SEIRA = Space(100)

                





                SQL2 = "INSERT INTO EID (KOD,KODSYNOD,ONO,FPA,LTI,G01,G02,G03,G04,G05,G06,G07,POS,SYSKEYASIA,LTI_SYNOD) VALUES ('"
                SQL2 = SQL2 + mKod + "','" + MKODSYNOD + "','" + mepo + "'," + MFPA + "," + mLti5
                SQL2 = SQL2 + "," + mTIM1
                SQL2 = SQL2 + "," + mTIM2
                SQL2 = SQL2 + "," + mTIM3
                SQL2 = SQL2 + "," + mTIM4
                SQL2 = SQL2 + "," + mTIM5
                SQL2 = SQL2 + "," + mTIM6
                SQL2 = SQL2 + "," + mTIM7
                SQL2 = SQL2 + "," + MPOSO
                SQL2 = SQL2 + "," + MSYSKEYASIA
                SQL2 = SQL2 + "," + MLTI_SYNOD + ")"


                If mono_times = vbYes Then
                    KL = IsConnected("select * from EID WHERE KOD='" + mKod + "'", False)
                    Dim YPARXEI_EIDOS As Integer = 0
                    While (myDR.Read())
                        YPARXEI_EIDOS = 1
                        KL = IsConnected("UPDATE EID SET LTI=" + mLti5 + ",POSO=" + MPOSO + " WHERE KOD='" + mKod + "'", True)

                    End While
                    If YPARXEI_EIDOS = 0 Then
                        KL = IsConnected(SQL2, True)
                    End If

                Else
                    KL = IsConnected(SQL2, True)
                End If





                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = Format(k, "#####") + " / " + Format(pl, "#####")
                End If
                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)
                If k > 560 Then
                    '  Exit For
                End If
            Next k
            Me.Text = "OK " + Str(k) + " ΕΙΔΗ"
        End If
    End Sub
    Sub DB_LOADpel()
        Dim pl As Long
        Dim mKod As String
        Dim mepo As String
        Dim MCompany As String

        Dim ans As Integer
        ans = MsgBox("Μόνο τα υπόλοιπα;", MsgBoxStyle.YesNo)

        If gBaran = 29 Then  ' OKO
            MCompany = "10"
        Else  'MIXAILIDIS
            MCompany = "1001"
        End If



        Dim k As Long, KL As Long
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet
        '======================================================================
        Dim sqlpel = "SELECT ( SELECT FLD01 AS POSOSTO10 FROM PRCRDATA   WHERE COMPANY=1001 AND SODTYPE=13 AND SOTYPE=1 AND PRCRULE=3 AND DIM1=P.TRDBUSINESS ) AS EKPTOSI,P.PRCPOLICY AS ISEKPTOSI,  P.CODE AS KOD,ROUND(T.LBAL,2)  AS YPOLOIPO, P.NAME,AFM,ADDRESS,PRCCATEGORY AS ZONHTIMON,TRDBUSINESS AS EMPORKATHG,P.* FROM TRDFINDATA T INNER JOIN TRDR P ON T.TRDR=P.TRDR  WHERE  SODTYPE=13 AND P.COMPANY=" + MCompany + "  ORDER BY DEBDATEV DESC"
        k = openWifiSQL(sqlpel, FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If
        'Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString
        'ΑΠΟ ΤΟ TRDR : TRDBUSINESS=> 40 EMPORKATHG =KOD EKPTOSHS,
        'PRCPOLICY =20 ΣΗΜΑΙΝΕΙ ΕΚΠΤΩΣΗ  ALLOIOS ZONH TIMON
        '
        'SELECT A.DIM1 AS KATHG40,A.FLD01 AS POSOSTO10 FROM PRCRDATA 
        ' A WHERE A.COMPANY=1001 AND A.SODTYPE=13 AND A.SOTYPE=1 AND A.PRCRULE=3 
        ' DIKO MOY :   AND A.DIM1=40
        '( SELECT FLD01 AS POSOSTO10 FROM PRCRDATA   WHERE COMPANY=1001 AND SODTYPE=13 AND SOTYPE=1 AND PRCRULE=3 AND DIM1=P.TRDBUSINESS ) AS EKPTOSI





        Dim mEPA As String
        Dim mDIE As String
        Dim MTYP As String
        Dim MPEK As String
        Dim MXRE_EKPTOSI As String


        pl = FDS.Tables(0).Rows.Count

        If k > 0 Then
            KL = IsConnected("DELETE from PEL", True)

            ' ΕΙΔΗ ΠΕΛΑΤΟΥ
            ' If gBaran = 29 Then
            If ans = vbNo Then
                KL = IsConnected("DELETE from EIDHPEL", True)
            End If

            'End If




            For k = 0 To FDS.Tables(0).Rows.Count - 1
                mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
                mepo = Replace(Trim(FDS.Tables(0).Rows(k).Item("name").ToString), "'", "''")
                ' mLti5 = "0" ' Replace(Trim(FDS.Tables(0).Rows(k).Item("lti").ToString), ",", ".")
                mDIE = Replace(Trim(FDS.Tables(0).Rows(k).Item("address").ToString), "'", "''")
                mEPA = Replace(Trim(FDS.Tables(0).Rows(k).Item("EMPORKATHG").ToString), "'", "''")
                MTYP = Replace(Trim(FDS.Tables(0).Rows(k).Item("YPOLOIPO").ToString), ",", ".")
                MPEK = Replace(Trim(FDS.Tables(0).Rows(k).Item("ZONHTIMON").ToString), ",", ".")

                If IsDBNull(FDS.Tables(0).Rows(k).Item("EKPTOSI")) Then
                    MXRE_EKPTOSI = "0"
                Else
                    MXRE_EKPTOSI = Replace(Trim(FDS.Tables(0).Rows(k).Item("EKPTOSI").ToString), ",", ".")
                End If


                If Val(MPEK) = 0 Then
                    MPEK = "0"
                End If

                'SEIRA = Space(100)
                KL = IsConnected("INSERT INTO PEL (KOD,EPO,DIE,EPA,TYP,PEK,XRE) VALUES ('" + mKod + "','" + mepo + "','" + mDIE + "','" + mEPA + "'," + MTYP + "," + MPEK + "," + MXRE_EKPTOSI + ")", True)
                If k Mod 10 = 0 Then
                    Application.DoEvents()
                    'Me.Text = Format(k, "#####")
                    Me.Text = Format(k, "#####") + " / " + Format(pl, "#####")
                End If
                Dim company As String = "10" '  "1001" ' gia mixailidi kai 10 gia oko 

                If gBaran = 93 Then
                    company = "1001"
                End If





                ' ΕΙΔΗ ΠΕΛΑΤΟΥ
                'If gBaran = 29 Then
                If ans = vbNo Then
                    eidh_pel(FDS.Tables(0).Rows(k).Item("trdr").ToString, mKod, company)
                End If

                ' End If




                'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

            Next k
            MsgBox("OK " + Str(k) + " πελατες")
        End If
        Exit Sub
        ''======================================================================
        'k = openWifiSQL("select * from EGG order by KOD", FDS)
        'If k < 0 Then
        '    MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
        '    Exit Sub
        'End If
        ''Button5.Text = FDS.Tables(0).Rows(k).Item("ONO").ToString

        'Dim mATIM As String
        ''Dim mDIE As String
        'Dim MXR As String
        'Dim MPIS As String
        'Dim MHME As String

        'If k > 0 Then
        '    KL = IsConnected("DELETE from EGG", True)

        '    For k = 0 To FDS.Tables(0).Rows.Count - 1
        '        mKod = Trim(FDS.Tables(0).Rows(k).Item("KOD").ToString)
        '        mATIM = Trim(FDS.Tables(0).Rows(k).Item("ATIM").ToString)
        '        MHME = FDS.Tables(0).Rows(k).Item("HME").ToString
        '        MXR = Replace(Trim(FDS.Tables(0).Rows(k).Item("XREOSI").ToString), ",", ".")
        '        MPIS = Replace(Trim(FDS.Tables(0).Rows(k).Item("PISTOSI").ToString), ",", ".")
        '        'SEIRA = Space(100)
        '        KL = IsConnected("INSERT INTO EGG (KOD,ATIM,HME,XREOSI,PISTOSI) VALUES ('" + mKod + "','" + mATIM + "','" + MHME + "'," + MXR + "," + MPIS + ")", True)
        '        If k Mod 10 = 0 Then
        '            Application.DoEvents()
        '            Me.Text = Format(k, "#####")
        '        End If
        '        'ListBox1.Items.Add(FDS.Tables(0).Rows(k).Item("EPO").ToString)

        '    Next k
        '    MsgBox("OK " + Str(k) + " KINHΣEIΣ")
        'End If





    End Sub

    Sub eidh_pel(ByVal trdr As String, ByVal KODPEL As String, ByVal company As String)
        Dim FDS As New System.Data.DataSet
        Dim FDS2 As New System.Data.DataSet
        Dim sql As String, k As Integer, kl As Integer
        Dim d1 As String = Format(DateAdd("d", -360, Now), "yyyyMMdd")
        Dim d2 As String = Format(Now, "yyyyMMdd")
        sql = " SELECT  M.MTRL,M.CODE    ,M.NAME       ,M.MTRUNIT1       ,ISNULL(S.SQTY,0) AS QTY       ,ISNULL(S.SVAL,0) AS VAL       ,ISNULL(R.QTYOPEN,0) AS QTYOPEN       ,ISNULL(R.VALOPEN,0) AS VALOPEN       ,M.MTRCATEGORY       ,M.MTRGROUP FROM(SELECT 	 F.SOSOURCE              ,M1.MTRL              ,F.COMPANY              ,(CASE WHEN F.SODTYPE=13 THEN SUM(ISNULL(M1.QTY1,0)*ISNULL(T.FLG09,0))                     WHEN F.SODTYPE=12 THEN SUM(ISNULL(M1.QTY1,0)*ISNULL(T.FLG07,0))                END) AS SQTY              ,(CASE WHEN F.SODTYPE=13 THEN SUM(ISNULL(M2.LTRNVAL,0)*ISNULL(T.FLG10,0))                     WHEN F.SODTYPE=12 THEN SUM(ISNULL(M2.LTRNVAL,0)*ISNULL(T.FLG08,0))                END) AS SVAL      FROM FINDOC F      LEFT JOIN MTRLINES 	M1 	ON M1.FINDOC	=F.FINDOC                             AND M1.COMPANY	=F.COMPANY      LEFT JOIN MTRTRN 	  M2	ON M2.FINDOC	=M1.FINDOC                         		 AND M2.MTRTRN	=M1.MTRLINES                         		 AND M2.FINDOC	=M1.FINDOC 		                         AND M2.COMPANY	=M1.COMPANY      LEFT JOIN TPRMS		   T	ON T.TPRMS	  =M2.TPRMS 		                         AND T.SODTYPE	=M2.SODTYPE 		                         AND T.COMPANY	=M2.COMPANY      WHERE F.ISCANCEL<>1        AND F.SOSOURCE = ((F.SODTYPE*100)+51)        AND F.COMPANY  =" + company + "   AND F.SODTYPE  = 13       AND F.TRDR     = " + trdr + "  AND  F.TRNDATE>='" + d1 + "' AND  F.TRNDATE<'" + d2 + "'      GROUP BY F.COMPANY,M1.MTRL,F.SOSOURCE, F.SODTYPE      ) S LEFT OUTER JOIN     (SELECT  F.SOSOURCE             ,F.SOREDIR             ,M3.MTRL             ,SUM(ISNULL(M3.QTY1,0)-(ISNULL(M3.QTY1COV,0)+ISNULL(M3.QTY1CANC,0))) AS QTYOPEN             ,SUM((ISNULL(M3.QTY1,0)-(ISNULL(M3.QTY1COV,0)+ISNULL(M3.QTY1CANC,0)))*(M3.LINEVAL/M3.QTY1)) AS VALOPEN      FROM FINDOC F      LEFT JOIN FPRMS P     ON F.COMPANY   = P.COMPANY                           AND F.SOSOURCE  = P.SOSOURCE                           AND F.FPRMS     = P.FPRMS  AND P.TFPRMS     = 201    AND P.RESTMODE  IS NOT NULL      LEFT JOIN MTRLINES M3 ON F.FINDOC    = M3.FINDOC                           AND M3.PENDING  <> 0      WHERE F.COMPANY  = " + company + "  AND F.SODTYPE  = 13        AND F.TRDR     =" + trdr + " AND  F.TRNDATE>='" + d1 + "' AND  F.TRNDATE<'" + d2 + "'         AND F.ISCANCEL = 0        AND F.ORIGIN  <> 6        AND F.SOSOURCE = ((F.SODTYPE*100)+51)      GROUP BY M3.MTRL,F.SOSOURCE, F.SOREDIR      ) R ON S.MTRL=R.MTRL LEFT JOIN MTRL M ON M.MTRL=S.MTRL                 AND M.COMPANY=S.COMPANY WHERE (SQTY<>0    OR SVAL<>0    OR QTYOPEN<>0    OR VALOPEN<>0)"

        k = openWifiSQL(sql, FDS)
        If k < 0 Then
            MsgBox("ΑΔΥΝΑΤΗ Η ΣΥΝΔΕΣΗ. ΔΟΚΙΜΑΣΤΕ ΜΕ ΚΑΛΩΔΙΟ")
            Exit Sub
        End If

        Dim mkod As String, mEPA As String
        Dim mDIE As String
        Dim MPOSO As String
        Dim MAJIA As String
        Dim KN As Long
        Dim teltimh As String

        'Dim kl As Integer
        Dim idEIDOYS As String
        If k > 0 Then
            For k = 0 To FDS.Tables(0).Rows.Count - 1



                mkod = Trim(FDS.Tables(0).Rows(k).Item("CODE").ToString)
                MPOSO = Trim(FDS.Tables(0).Rows(k).Item("QTY").ToString)
                MAJIA = Trim(FDS.Tables(0).Rows(k).Item("VAL").ToString)
                idEIDOYS = Trim(FDS.Tables(0).Rows(k).Item("MTRL").ToString)

                'ΒΡΙΣΚΩ ΚΑΙ ΤΗΝ ΤΕΛΕΥΤΑΙΑ ΤΙΜΗ ΤΟΥ ΠΕΛΑΤΗ KODPEL(ID->TRDR ERXETAI SAN PARAMETROS STHN PROCEDURE)
                'ΤΟ ΕΙΔΟΣ ΕΙΝΑΙ ΜΕ ΤΟ idEIDOYS <- MTRL 
                sql = "SELECT CASE WHEN M.QTY1<>0 THEN M.LINEVAL/M.QTY1 ELSE M.PRICE1 END  FROM  FINDOC F LEFT OUTER JOIN MTRLINES M ON F.FINDOC=M.FINDOC "
                sql = sql + " WHERE F.COMPANY=" + company + " AND F.SOSOURCE=1351 AND M.MTRL=" + idEIDOYS + " AND F.TRDR=" + trdr + " AND EXISTS(SELECT 1 FROM MTRLINES MF WHERE MF.FINDOC=F.FINDOC AND MF.MTRL=" + idEIDOYS + ") AND "
                sql = sql + " F.TRNDATE=(SELECT MAX(N.TRNDATE) FROM FINDOC N            WHERE N.SOSOURCE=1351 AND N.TRDR=" + trdr + " AND N.COMPANY=" + company + " AND EXISTS(SELECT 1 FROM MTRLINES MF WHERE MF.FINDOC=N.FINDOC AND MF.MTRL=" + idEIDOYS + ") )"
                KN = openWifiSQL(sql, FDS2)
                If IsDBNull(FDS2.Tables(0).Rows(0).Item(0)) Then
                    teltimh = "0"
                Else
                    teltimh = Replace(FDS2.Tables(0).Rows(0).Item(0).ToString, ",", ".")
                End If
                'SEIRA = Space(100)
                kl = IsConnected("INSERT INTO EIDHPEL (KODPEL,KODE,POSO,AJIA,TELTIMH) VALUES ('" + KODPEL + "','" + mkod + "'," + Replace(MPOSO, ",", ".") + "," + Replace(MAJIA, ",", ".") + "," + teltimh + ")", True)
            Next
        End If

    End Sub
    Sub load_PELexcel()
        'OpenFileDialog1.ShowDialog()
        If Not File.Exists(gFilePelaton) Then
            MsgBox("ΔΕΝ ΒΡΙΣΚΩ ΤΟ ΑΡΧΕΙΟ ΠΕΛΑΤΩΝ " + Chr(13) + gFilePelaton)
            Exit Sub

        End If


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Open(gFilePelaton) 'openfiledialog1.FileName)
        xlWorkSheet = xlWorkBook.Worksheets(1)
        'display the cells value B2
        '    MsgBox(xlWorkSheet.Cells(6, 1).value)
        'edit the cell with new value


        'xlWorkSheet.Cells(7, 2) = onomaProion
        'xlWorkSheet.Cells(8, 1) = "ΠΟΣΟΤΗΤΑ: " + Str(minTem)
        'xlWorkSheet.Cells(15, 1) = TELBARCODE
        Dim line, CC As String
        CC = ""
        Dim MKOD, MONO, MLTI As String


        Dim N As Long
        Dim SQL As String

        ' Κωδικός Είδους	Περιγραφή	Μονάδα Μέτρησης Α	Τιμές	Κατηγορία
        '07.001	ΜΠΟΥΤΙ ΚΟΤΑΣ ΧΥΜ ΟΛΑΝΔΙΑΣ. ΚΤΨ	Κιλά	1,45	1
        '07.002	ΜΠΟΥΤΙ ΚΟΤΑΣ ΤΥΠ ΚΑΡΑΓΙΑ.ΕΛΛΗΝ. ΚΤΨ	Κιλά	3,15	1
        'IsDBNull(myDR("ONO")), "", myDR("ONO"))
        Dim nf As String = 0
        Dim Mdie As String
        Dim Mafm As String
        Dim MTYP As String

        IsConnected("DELETE FROM PEL", True)


        '  IsConnected("DELETE FROM EID", True)
        line = ""  'sr.ReadLine()  'seira me header
        ListBox1.Items.Add("ΔΕΝ ΕΝΗΜΕΡΩΘΗΚΑΝ:")
        N = 0
        Do

            N = N + 1
            If N > xlWorkSheet.UsedRange.Rows.Count Then
                If xlWorkSheet.Cells(N, 2).VALUE = Nothing Then
                    Exit Do
                End If
            End If





            'line = sr.ReadLine()
            If xlWorkSheet.Cells(N, 1).value Is Nothing Then
            Else

                Try

                    MKOD = xlWorkSheet.Cells(N, 1).VALUE.ToString
                    If N Mod 10 = 0 Then
                        Application.DoEvents()
                    End If
                    MONO = Replace(xlWorkSheet.Cells(N, 2).VALue.ToString, "'", "`")
                    Mafm = xlWorkSheet.Cells(N, 3).VALUE  ' Replace(Split(line, ";")(4), ",", ".")

                    Mdie = Replace(xlWorkSheet.Cells(N, 4).VALue.ToString, "'", "`")
                    

                    MTYP = xlWorkSheet.Cells(N, 6).VALUE
                    MTYP = Replace(MTYP, ",", ".")

                    IsConnected("SELECT *  FROM PEL WHERE KOD='" + MKOD + "'", False)
                    'myDR.Read()
                    Dim YPARXEI As Integer = 0
                    While myDR.Read()
                        If IsDBNull(myDR("EPO")) Then
                            IsConnected("UPDATE PEL SET ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                        Else
                            If myDR("EPO") = MONO Then
                            Else
                                IsConnected("UPDATE PEL SET EPO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If
                        End If

                        If IsDBNull(myDR("DIE")) Then
                            IsConnected("UPDATE EID SET DIE='" + Mdie + "' WHERE KOD='" + MKOD + "'", True)
                        Else
                            If myDR("DIE") = Mdie Then
                            Else
                                IsConnected("UPDATE EID SET DIE='" + Mdie + "' WHERE KOD='" + MKOD + "'", True)
                            End If
                        End If


                        If IsDBNull(myDR("AFM")) Then
                            IsConnected("UPDATE EID SET AFM='" + Mafm + "' WHERE KOD='" + MKOD + "'", True)
                        Else
                            If myDR("AFM") = Mafm Then
                            Else
                                IsConnected("UPDATE EID SET AFM='" + Mafm + "' WHERE KOD='" + MKOD + "'", True)
                            End If
                        End If


                        If IsDBNull(myDR("TYP")) Then
                            IsConnected("UPDATE EID SET AEG=" + MTYP + " WHERE KOD='" + MKOD + "'", True)
                        Else
                            If myDR("TYP") = MTYP Then
                            Else
                                IsConnected("UPDATE EID SET AEG=" + MTYP + " WHERE KOD='" + MKOD + "'", True)
                            End If
                        End If





                        YPARXEI = 1
                        Exit While

                    End While

                    If YPARXEI = 0 Then
                        'IsDBNull(myDR("ONO")), "", myDR("ONO"))
                        'IsConnected("UPDATE PEL SET AEG=" + MAEG + "' WHERE KOD='" + MKOD + "'", True)
                        SQL = "INSERT INTO PEL (KOD,EPO,AEG,AFM,DIE) VALUES ('" + MKOD + "','" + MONO + "'," + MTYP + ",'" + Mafm + "','" + Mdie + "' ); "
                        'SQL = "INSERT INTO EID (KOD,ONO,AEG,LTI,MON) VALUES ('" + MKOD + "','" + MONO + "'," + MAEG + "," + MLTI + ",'" + MMON + "' ); "
                        IsConnected(SQL, True)

                    End If



                Catch ex As Exception
                    nf = nf + 1
                    ListBox1.Items.Add(Str(nf) + MKOD + " " + MONO)
                End Try
            End If
            N = N + 1
            If N Mod 1 = 0 Then
                Application.DoEvents()
                Me.Text = "πελατες " + Format(N, "#####") + " MH ENHMΕΡΩΜΕΝOI " + Str(nf)
            End If
        Loop Until line Is Nothing
        '  sr.Close()


        xlWorkBook.Close()
        xlApp.Quit()



    End Sub

    Sub load_EIDexcel()


        ' OpenFileDialog1.ShowDialog()
        If Not File.Exists(gFileEidon) Then
            MsgBox("ΔΕΝ ΒΡΙΣΚΩ ΤΟ ΑΡΧΕΙΟ EIΔΩΝ" + gFileEidon)
            Exit Sub

        End If


        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet

        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Open(gFileEidon)   'OpenFileDialog1.FileName)
        xlWorkSheet = xlWorkBook.Worksheets(1)
        'display the cells value B2
        '    MsgBox(xlWorkSheet.Cells(6, 1).value)
        'edit the cell with new value


        'xlWorkSheet.Cells(7, 2) = onomaProion
        'xlWorkSheet.Cells(8, 1) = "ΠΟΣΟΤΗΤΑ: " + Str(minTem)
        'xlWorkSheet.Cells(15, 1) = TELBARCODE
        Dim line, CC As String
        CC = ""
        Dim MKOD, MONO, MLTI As String
        IsConnected("DELETE FROM EID", True)

        Dim N As Long
        Dim SQL As String

        ' Κωδικός Είδους	Περιγραφή	Μονάδα Μέτρησης Α	Τιμές	Κατηγορία
        '07.001	ΜΠΟΥΤΙ ΚΟΤΑΣ ΧΥΜ ΟΛΑΝΔΙΑΣ. ΚΤΨ	Κιλά	1,45	1
        '07.002	ΜΠΟΥΤΙ ΚΟΤΑΣ ΤΥΠ ΚΑΡΑΓΙΑ.ΕΛΛΗΝ. ΚΤΨ	Κιλά	3,15	1
        'IsDBNull(myDR("ONO")), "", myDR("ONO"))
        Dim nf As String = 0
        Dim MMON As String
        Dim MAEG As String

        '  IsConnected("DELETE FROM EID", True)
        line = ""  'sr.ReadLine()  'seira me header
        ListBox1.Items.Add("ΔΕΝ ΕΝΗΜΕΡΩΘΗΚΑΝ:")
        N = 0
        Do

            N = N + 1
            If N > xlWorkSheet.UsedRange.Rows.Count Then
                If xlWorkSheet.Cells(N, 2).VALUE = Nothing Then
                    Exit Do
                End If
            End If





            'line = sr.ReadLine()
            If xlWorkSheet.Cells(N, 1).value Is Nothing Then
            Else

                Try

                    MKOD = xlWorkSheet.Cells(N, 1).VALUE.ToString
                    If N Mod 10 = 0 Then
                        Application.DoEvents()
                    End If
                    MONO = Replace(xlWorkSheet.Cells(N, 2).VALue.ToString, "'", "`")
                    MAEG = Replace(xlWorkSheet.Cells(N, 5).VALue.ToString, "'", "`") ' Replace(Split(line, ";")(5), ",", ".")

                    MLTI = xlWorkSheet.Cells(N, 4).VALUE
                    MLTI = Replace(MLTI, ",", ".")
                    If Val(MLTI) = 0 Then
                        MLTI = "0"
                    End If

                    MMON = xlWorkSheet.Cells(N, 3).VALUE

                    IsConnected("SELECT *  FROM EID WHERE KOD='" + MKOD + "'", False)
                    Dim YPARXEI As Integer = 0
                    'myDR.Read()
                    If myDR.HasRows Then
                        While myDR.Read()
                            If myDR("ONO") = MONO Then
                            Else
                                IsConnected("UPDATE EID SET LTI=" + MLTI + ",AEG=" + MAEG + ",ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("LTI") = MLTI Then
                            Else
                                IsConnected("UPDATE EID SET LTI=" + MLTI + ",AEG=" + MAEG + ",ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("AEG") = MAEG Then
                            Else
                                IsConnected("UPDATE EID SET LTI=" + MLTI + ",AEG=" + MAEG + ",ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If






                            YPARXEI = 1
                            Exit While

                        End While
                    End If


                    If YPARXEI = 0 Then
                        'IsDBNull(myDR("ONO")), "", myDR("ONO"))

                        SQL = "INSERT INTO EID (KOD,ONO,AEG,LTI,MON) VALUES ('" + MKOD + "','" + MONO + "'," + MAEG + "," + MLTI + ",'" + MMON + "' ); "
                        IsConnected(SQL, True)

                    End If



                Catch ex As Exception
                    nf = nf + 1
                    ListBox1.Items.Add(Str(nf) + MKOD + " " + MONO)
                End Try
            End If
            N = N + 1
            If N Mod 1 = 0 Then
                Application.DoEvents()
                Me.Text = "ΕΙΔΗ " + Format(N, "#####") + " MH ENHMΕΡΩΜΕΝΑ " + Str(nf)
            End If
        Loop Until line Is Nothing
        '  sr.Close()




































        xlWorkBook.Close()
        xlApp.Quit()



    End Sub



    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        If gBaran = 93 Then
            LOADMIX() 'ΜΙΧΑΗΛΙΔΗς
            Exit Sub

        End If


        If gBaran = 1 Then
            ' LOAD_CSV()
            Dim ans As Integer
            Dim ans2 As Integer
            ans = MsgBox("ΦΟΡΤΩΝΩ ΕΙΔΗ", MsgBoxStyle.YesNo)
            ans2 = MsgBox("ΦΟΡΤΩΝΩ ΠΕΛΑΤΕΣ", MsgBoxStyle.YesNo)

            If ans = vbYes Then
                load_EIDexcel()
            End If


            If ans2 = vbYes Then
                load_PELexcel()
            End If




            Exit Sub
        End If

        If gBaran = 29 Then
            LOADMIX() 'oko clean
            Exit Sub

        End If

        EXPORT_TO_ACCESS("Select  PELKOD AS KODPEL, KODE,SUM(POSO) AS POSO,SUM(POSO*TIMM*(100-EKPT)/100) AS AJIA,MAX(TIMM) AS TELTIMH FROM EGGTIM where EIDOS='e' GROUP BY PELKOD,KODE", "Select  KODPEL,KODE,POSO,AJIA,TELTIMH FROM EIDHPEL", "EIDHPEL")



        ProgressBar1.Value = 10
        Application.DoEvents()
        Me.Text = "1"
        'and KOD IN (SELECT KOD FROM EGG where EIDOS='e')
        EXPORT_TO_ACCESS("Select KOD, EPO, TYP,EPA,DIE,THL  From PEL WHERE EIDOS='e' ", "Select KOD, EPO, TYP,EPA,DIE,THL  From PEL", "PEL")

        Application.DoEvents()
        Me.Text = "συνδεση ΟΚ"


        ProgressBar1.Value = 40
        EXPORT_TO_ACCESS("Select KOD, ONO, LTI,XTI,POS_KERD,FPA  From EID", "Select KOD, ONO, LTI,XTI,POS_KERD,FPA  From EID", "EID")
        Application.DoEvents()
        ProgressBar1.Value = 75
        Application.DoEvents()

        EXPORT_TO_ACCESS("Select  KOD, ATIM, HME, XREOSI, PISTOSI FROM EGG where EIDOS='e'", "Select  KOD, ATIM, HME, XREOSI, PISTOSI FROM EGG", "EGG")

        ProgressBar1.Value = 100

        IsConnected("update EGG SET XREOSI=0 WHERE XREOSI IS NULL ", False)
        IsConnected("update EGG SET PISTOSI=0 WHERE PISTOSI IS NULL ", False)
        Loader()



        



        'kl = IsConnected("INSERT INTO EIDHPEL (KODPEL,KODE,POSO,AJIA,TELTIMH) VALUES ('" + KODPEL + "','" + mkod + "'," + Replace(MPOSO, ",", ".") + "," + Replace(MAJIA, ",", ".") + "," + teltimh + ")", True)









        MsgBox("οκ")












    End Sub


    Sub EXPORT_TO_ACCESS(ByVal SQLSOURCE As String, ByVal SQLDESTINATION As String, ByVal DELTABLE As String)

        Dim dt As New DataTable()


        'Get Data into DataTable from Sql Server database    
        Using cnn As New SqlConnection(gCONNECT) ' "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Common;Data Source=localhost")
            Try
                cnn.Open()

            Catch ex As Exception
                MsgBox("αδυνατη η σύνδεση")
                Exit Sub
            End Try

            Dim cmdSelect As SqlCommand = New SqlCommand(SQLSOURCE)
            cmdSelect.Connection = cnn
            Dim ad As New SqlDataAdapter(cmdSelect)
            ad.AcceptChangesDuringFill = False
            ad.Fill(dt)
        End Using

        'Insert Data from DataTable into Access database
        ' "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;"
        Using cnn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\database.mdb;")  'Provider=Microsoft.ACE.OLEDB.12.0;Data Source=database1.accdb;Persist Security Info=False")
            Dim cmdSelect As OleDbCommand = New OleDbCommand(SQLDESTINATION)
            cmdSelect.Connection = cnn
            IsConnected("DELETE FROM " + DELTABLE, False)
            Dim ad As New OleDbDataAdapter(cmdSelect)
            Dim cmdBuilder As New OleDbCommandBuilder(ad)
            Dim cmd As OleDbCommand = cmdBuilder.GetInsertCommand()
            cmd.Connection = cnn
            ad.InsertCommand = cmd
            ad.Update(dt)
        End Using



    End Sub



    Private Sub B7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B7.Click
        TYPOSE("7")
    End Sub

    Sub TYPOSE(ByVal D As String)

        Dim F As String
        F = ""
        'If TextBox4.BackColor = Color.Yellow Then

        If sxolia.BackColor = Color.Yellow Then
            F = sxolia.Text
        Else
            F = TextBox4.Text
        End If

        'End If
        'If TextBox3.BackColor = Color.Yellow Then
        '    F = TextBox3.Text
        'End If

        If D = "<" Then
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


        If sxolia.BackColor = Color.Yellow Then
            sxolia.Text = F
        Else
            TextBox4.Text = F
        End If





        ' If TextBox4.BackColor = Color.Yellow Then
        'TextBox4.Text = F
        ' End If
        'If TextBox3.BackColor = Color.Yellow Then
        '    TextBox3.Text = F
        'End If







    End Sub






    Private Sub B8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B8.Click
        TYPOSE("8")
    End Sub

    Private Sub B9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B9.Click
        TYPOSE("9")
    End Sub

    Private Sub B4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B4.Click
        TYPOSE("4")
    End Sub

    Private Sub B5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B5.Click
        TYPOSE("5")
    End Sub

    Private Sub B6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B6.Click
        TYPOSE("6")
    End Sub

    Private Sub B1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B1.Click
        TYPOSE("1")
    End Sub

    Private Sub B2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B2.Click
        TYPOSE("2")
    End Sub

    Private Sub B3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B3.Click
        TYPOSE("3")
    End Sub

    Private Sub B0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B0.Click
        TYPOSE("0")
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        TYPOSE("-")
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TYPOSE(".")
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim g As String
        g = SameLetters(TextBox4.Text)
        g = Replace(g, "*", "%")
        If ButtonAdd.Text = "Νέα Παραγγελία" Then
            If gBaran <> 1 Then
                LOAD_PEL(" where EPO LIKE '" + g + "%' OR KOD LIKE '" + TextBox4.Text + "%' ")
            Else

                If Val(g) > 0 Then
                    LOAD_PEL(" where AEG= " + TextBox4.Text)
                Else
                    LOAD_PEL(" where EPO LIKE '" + g + "%' OR KOD LIKE '" + TextBox4.Text + "%' ")
                End If
            End If


        Else
            If gBaran <> 1 Then
                LOAD_EIDH(" where ONO LIKE '" + g + "%' OR KOD LIKE '" + TextBox4.Text + "%' ")
            Else
                If Val(g) > 0 Then
                    LOAD_EIDH(" where AEG= " + TextBox4.Text)
                Else
                    LOAD_EIDH(" where ONO LIKE '" + g + "%' OR KOD LIKE '" + TextBox4.Text + "%' ")
                End If
            End If

        End If
        TextBox4.Text = ""
    End Sub

    Private Sub Button6_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TYPOSE("<")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        'Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text
        If LV.SelectedItems.Count = 0 Then
            ' MsgBox("Διαλέξτε Πελάτη")
            Exit Sub
        Else
            ' GroupBox1.Text = LV.SelectedItems(0).SubItems(1).Text
        End If
        '


        If Button8.Text = "Τελ.Παραγγελιες" Then
            GroupBox1.Text = LV.SelectedItems(0).SubItems(5).Text + ";" + LV.SelectedItems(0).SubItems(2).Text
            lvEggtim.Visible = True
            lvEggtim.Items.Clear()
            Button8.Text = "Επαναφορά"

        Else
            lvEggtim.Visible = False
            Button8.Text = "Τελ.Παραγγελιες"
        End If




        IsConnected("Select HME,ATIM,ID_NUM  from TIM WHERE KPE='" + LV.SelectedItems(0).SubItems(5).Text + "' ORDER BY HME ", False)  ' WHERE ATIM='22'

        ' Call Loader()
        LV2.Items.Clear()

        ' LV2.Columns(0).Text = "ΚΩΔΙΚΟΣ"
        LV2.Columns(0).Text = "HMEP"
        LV2.Columns(1).Text = "ΠΑΡ/ΚΟ"


        While (myDR.Read())

            With LV2.Items.Add(myDR(0))
                .SubItems.Add(IIf(IsDBNull(myDR("ATIM")), "", myDR("ATIM")))
                .SubItems.Add(IIf(IsDBNull(myDR("ID_NUM")), "", myDR("ID_NUM").ToString))

            End With


        End While
        LV2.Refresh()
        '--------------------------------------------------------------------------------------------
    End Sub

    Private Sub LV2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LV2.SelectedIndexChanged

        If lvEggtim.Visible = True Then
            ';OK
        Else
            Exit Sub
        End If







        'Form3.TextID.Text = LV.SelectedItems(0).SubItems(0).Text
        If LV2.SelectedItems.Count = 0 Then
            ' MsgBox("Διαλέξτε Πελάτη")
            Exit Sub
        Else
            ' GroupBox1.Text = LV.SelectedItems(0).SubItems(1).Text
        End If
        '
        IsConnected("Select ATIM,ONOMA,POSO,TIMM,ID_NUM,KOLA  from EGGTIM WHERE ATIM like '%" + LV2.SelectedItems(0).SubItems(1).Text + "%' ORDER BY ONOMA ", False)  ' WHERE ATIM='22'

        ' Call Loader()
        lvEggtim.Items.Clear()




        ' LV2.Columns(0).Text = "ΚΩΔΙΚΟΣ"
        lvEggtim.Columns(1).Text = "ONOMA"
        lvEggtim.Columns(0).Text = "ΠΑΡ/ΚΟ"
        lvEggtim.Columns(1).Width = 300
        lvEggtim.Columns(2).Text = "ΠΟΣΟΤΗΤΑ"
        lvEggtim.Columns(3).Text = "ΤΙΜΗ"
        lvEggtim.Columns(4).Text = "ΑΠΟΘ.ΠΕΛ"
        'lvEggtim.Columns(3).Width = 100
        'lvEggtim.Columns(3).TextAlign = HorizontalAlignment.Right
        'lvEggtim.Columns(4).Text = "ΠΙΣΤΩΣΗ"
        'lvEggtim.Columns(4).Width = 100
        'lvEggtim.Columns(4).TextAlign = HorizontalAlignment.Right




        While (myDR.Read())

            With lvEggtim.Items.Add(myDR(0))
                '.SubItems.Add(myDR("KOD"))
                '.SubItems.Add(IIf(IsDBNull(myDR("HME")), "", myDR("HME")))
                .SubItems.Add(IIf(IsDBNull(myDR("ONOMA")), "", myDR("ONOMA")))
                .SubItems.Add(IIf(IsDBNull(myDR("POSO")), "", Format(myDR("POSO"), "#####0.00")))
                .SubItems.Add(IIf(IsDBNull(myDR("timm")), "", Format(myDR("timm"), "#####0.00")))
                .SubItems.Add(IIf(IsDBNull(myDR("KOLA")), "", Format(myDR("KOLA"), "#####0")))

            End With


        End While
        lvEggtim.Refresh()





    End Sub


    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



        'Dim SEIRA As String = Space(200)
        'Dim sw As StreamWriter
        'Dim COUNTER As Long


        'If Not File.Exists("c:\MERCVB\EGGTIM2.TXT") Then
        '    sw = New StreamWriter("c:\MERCVB\EGGTIM2.TXT")
        '    sw.WriteLine("  ")
        'Else
        '    sw = File.CreateText("c:\MERCVB\EGGTIM2.TXT")
        'End If
        'Dim K As Long






        '' DataGrid1.DataSource = DS.Tables(0)
        'Dim atim, kode, poso, KPE As String
        'Dim TIMM As String, onoma As String

        'IsConnected("Select * from EGGTIM ", False)


        'While (myDR.Read())
        '    KPE = IIf(IsDBNull(myDR("PELKOD")), "", myDR("PELKOD"))
        '    atim = myDR("ATIM")
        '    kode = myDR("KODE")
        '    onoma = myDR("ONOMA")
        '    poso = myDR("POSO")
        '    TIMM = myDR("TIMM")

        '    sw.WriteLine(KPE + ";" + atim + ";" + kode + ";" + poso + ";" + TIMM + ";" + ";" + KPE)

        '    K = K + 1

        'End While









        'sw.Close()

        'MsgBox("ok")









        ''Dim filename As String = "c:\mercvb\ektyp4.xlsx"
        ''Dim row, column As Integer
        ''Dim sheetname As String = "Φύλλο1"






        ''Dim xlApp As Excel.Application
        ''Dim xlWorkBook As Excel.Workbook
        ''Dim xl As Excel.Worksheet



        ''IsConnected("Select * from EGGTIM ", False)




        ''xlApp = New Excel.ApplicationClass
        ''xlWorkBook = xlApp.Workbooks.Add   'Open(filename)

        ' '' WS(k).Name = Str(k) + jt.Rows(k)("name")    
        ''xlApp.Visible = False
        ''xl = xlWorkBook.Worksheets(1)
        ''Dim K, C As Integer
        ''Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        ''K = 1
        ''While (myDR.Read())

        ''    'Sql = "INSERT INTO EGGTIM (HME,KODE,ID_NUM,EIDOS,APOT,FPA,ONOMA,ATIM,POSO,TIMM) VALUES ('" + Format(myDR("HME"), "MM/dd/yyyy") + "','" + myDR("KODE") + "'," + Str(myDR("ID_NUM")) + ",'e',1,2,'" + myDR("ONOMA") + "','"
        ''    'Sql = Sql + myDR("ATIM") + "'," + Replace(Str(myDR("POSO")), ",", ".") + "," + Replace(Format(myDR("TIMM"), "##0.00"), ",", ".") + ")"

        ''    'For C = 1 To sqlDT.Columns.Count

        ''    xl.Cells(K, 1) = myDR("PELKOD")
        ''    xl.Cells(K, 2) = myDR("ATIM")
        ''    xl.Cells(K, 3) = myDR("KODE")
        ''    xl.Cells(K, 4) = myDR("ONOMA")
        ''    xl.Cells(K, 5) = myDR("POSO")
        ''    xl.Cells(K, 6) = myDR("TIMM")
        ''    K = K + 1

        ''End While


        ' '' Next
        ''xlApp.Visible = True
        ''Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub

    Sub TO_CSV2(ByVal DDD As String) 'IDNUM
        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        Dim COUNTER As Long


        If Not File.Exists("c:\MERCVB\EGGTIM2.TXT") Then
            sw = New StreamWriter("c:\MERCVB\EGGTIM2.TXT", False, System.Text.Encoding.Default)

            ' sw.WriteLine("  ")
        Else
            sw = File.CreateText("c:\MERCVB\EGGTIM2.TXT")
        End If
        Dim K As Long






        ' DataGrid1.DataSource = DS.Tables(0)
        Dim atim, kode, poso, KPE As String
        Dim TIMM As String, onoma As String

        IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where ID_NUM=" + DDD + " ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD

        Dim MEPO As String
        Dim MMON As String

        Dim MONO As String
        Dim MEPO_ALL As String = "99999999"
        While (myDR.Read())
            KPE = IIf(IsDBNull(myDR("PELKOD")), "", myDR("PELKOD"))
            MEPO = myDR("EPO")
            If MEPO_ALL = MEPO Then
                MEPO = ""
            Else
                sw.WriteLine(KPE + ";" + MEPO + ";" + atim)
                sw.WriteLine("--------------------------------------------------")
                sw.WriteLine("ΚΩΔΙΚΟΣ             ΠΕΡΙΓΡΑΦΗ             ΠΟΣΟΤΗΤΑ")

                ' TO IDIO
            End If
            MEPO_ALL = myDR("EPO")



            If IsDBNull(myDR("MONA")) Then
                MMON = ""
            Else
                MMON = myDR("MONA")
            End If


            MONO = myDR("ONOMA")
            atim = myDR("ATIM")
            kode = Mid(myDR("KODE") + Space(20), 1, 15)
            onoma = Mid(myDR("ONOMA") + "...............................", 1, 30)  ' myDR("ONOMA")
            poso = Str(myDR("POSO"))
            poso = Space(10 - Len(poso)) + poso
            TIMM = Str(myDR("TIMM"))
            TIMM = Space(10 - Len(poso)) + TIMM

            sw.WriteLine(kode + "" + onoma + "" + poso + "" + "" + MMON)

            K = K + 1

        End While









        sw.Close()

    End Sub

    Sub TO_EXCELVAR()
        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        Dim COUNTER As Long
        Dim G_EGGTIM2 As String = "c:\MERCVB\EGGTIM2.XLS"


        If File.Exists(G_EGGTIM2) Then
            Kill(G_EGGTIM2)
        End If

        'Dim fs As New FileStream("c:\MERCVB\EGGTIM2.TXT", FileMode.CreateNew, FileAccess.Write)
        '' sw = New StreamWriter(fs, System.Text.Encoding.Default)
        'If gBaran = 1 Then
        '    sw = New StreamWriter(fs, System.Text.Encoding.UTF8)
        'Else
        '    sw = New StreamWriter(fs, System.Text.Encoding.Default)
        'End If

        'sw.WriteLine("  ")
        'Else

        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xl As Excel.Worksheet
        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add   'Open(filename)
        xlApp.Visible = False
        xl = xlWorkBook.Worksheets(1)






        'Dim fs As New FileStream("c:\MERCVB\EGGTIM2.TXT", FileMode.CreateNew, FileAccess.Write)
        'sw = New StreamWriter(fs, System.Text.Encoding.Default)
        'sw = File.CreateText("c:\MERCVB\EGGTIM2.TXT")
        'End If




        Dim K As Long


        Dim ans As Integer
        ans = MsgBox("μονο τις νεες", MsgBoxStyle.YesNo)




        ' DataGrid1.DataSource = DS.Tables(0)
        Dim atim, kode, poso, KPE As String
        Dim TIMM As String, onoma As String

        'IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where MONTH(HME)=" + Str(Month(Now)) + " AND DAY(HME)=" + Format(Now, "dd") + " ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
        If ans = vbYes Then

            If gBaran = 1 Then
                IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where MONTH(HME)=" + Str(Month(Now)) + " AND DAY(HME)=" + Format(Now, "dd") + " ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
            Else
                IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where E.XRE IS NULL ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
            End If

        Else
            IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD  ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
        End If

        Dim MEPO As String
        Dim fpa As String
        Dim MMON As String
        Dim EKPT As String
        Dim SXOLIA As String
        Dim MHME As String
        Dim MONO As String

        Dim analposo As String

        Dim MEPO_ALL As String = "99999999"
        'Dim n As Integer = 0
        While (myDR.Read())
            KPE = IIf(IsDBNull(myDR("PELKOD")), "", myDR("PELKOD"))
            MEPO = myDR("EPO")
            If MEPO_ALL = MEPO Then
                MEPO = ""
            Else
                ' TO IDIO
            End If
            MEPO_ALL = myDR("EPO")

            Me.Text = MEPO_ALL

            If IsDBNull(myDR("MONA")) Then
                MMON = ""
            Else
                MMON = myDR("MONA")
            End If

            If IsDBNull(myDR("fpa")) Then
                fpa = "1224"
            Else

                If myDR("fpa") = 24 Then
                    fpa = "1224"
                ElseIf myDR("fpa") = 13 Then
                    fpa = "1130"
                ElseIf myDR("fpa") = 0 Then
                    fpa = "1000"
                Else
                    fpa = myDR("fpa").ToString
                End If




            End If





            ' MONO = myDR("ONOMA")
            atim = myDR("ATIM")
            kode = myDR("KODE")
            Me.Text = kode

            ' onoma = myDR("ONOMA")
            poso = myDR("POSO")
            TIMM = Replace(myDR("TIMM").ToString, ",", ".")
            '   EKPT = myDR("EKPT")
            Me.Text = kode

            If IsDBNull(myDR("PROELEYSH")) Then
                SXOLIA = ""
            Else
                SXOLIA = myDR("PROELEYSH")
            End If

            If IsDBNull(myDR("ONOMA")) Then
                MONO = ""
            Else
                MONO = myDR("ONOMA")
            End If

            If IsDBNull(myDR("EKPT")) Then
                EKPT = "0"
            Else
                EKPT = myDR("EKPT").ToString
            End If

            MHME = Format(myDR("HME"), "dd/MM/yyyy")

            Dim KAI As String

            If gBaran = 93 Then
                'KAI = ","
                'If Val(fpa) = 1000 Then ' kena
                '    sw.WriteLine(gSEIRA + KAI + Mid(atim, 2, 6) + KAI + MHME + KAI + KPE + KAI + "1" + KAI + kode + KAI + poso + KAI + TIMM + KAI + fpa + KAI + "1" + KAI + EKPT + KAI + SXOLIA + poso)
                'Else

                '    If IsDBNull(myDR("kerdos")) Then
                '        analposo = myDR("POSO")
                '    Else
                '        analposo = myDR("POSO") * myDR("kerdos")
                '    End If
                '    TIMM = Replace(myDR("prood").ToString, ",", ".")  ' καθαρη τιμη χωρισ εφκα και συσκευασια δηλ.τιμη φιαλης χωρις ΕΦΚΑ
                '    sw.WriteLine(gSEIRA + KAI + Mid(atim, 2, 6) + KAI + MHME + KAI + KPE + KAI + "1" + KAI + kode + KAI + analposo + KAI + TIMM + KAI + fpa + KAI + "1" + KAI + EKPT + KAI + SXOLIA + KAI + poso)
                'End If



            ElseIf gBaran = 29 Then
                'KAI = ";"
                'sw.WriteLine(gSEIRA + KAI + Mid(atim, 2, 6) + KAI + KAI + poso + KAI + TIMM + KAI + KAI + KPE + KAI + kode + KAI + MHME + KAI + EKPT + KAI + SXOLIA)
            Else
                'sw.WriteLine(KPE + ";" + MEPO + ";" + atim + ";" + kode + ";" + MONO + ";" + poso + ";" + TIMM + ";" + ";" + MMON)

                xl.Cells(K + 1, 1) = MEPO
                xl.Cells(K + 1, 2) = MONO
                xl.Cells(K + 1, 3) = poso
                xl.Cells(K + 1, 4) = MMON
                xl.Cells(K + 1, 4) = TIMM









            End If
            '

            K = K + 1

        End While
        xl.Columns.AutoFit()


        xlWorkBook.SaveAs(G_EGGTIM2)
        xlWorkBook.Close()
        xlApp.Quit()







        ' sw.Close()
        If K = 0 Then
            MsgBox("ΔΕΝ ΥΠΑΡΧΟΥΝ ΠΑΡΑΓΓΕΛΙΕΣ ΓΙΑ ΑΠΟΣΤΟΛΗ")
            Exit Sub
        End If
        MsgBox("ok")


        Dim mnow As String = Format(Now, "HH-mm-ss")
        Dim mfile As String = GFILEdestination + mnow + ".xlsx"



        FileCopy(G_EGGTIM2, mfile)
        If File.Exists(mfile) Then  'AFOY TO ΕΓΡΑΨΕ ΤΟΤΕ ΣΒΗΝΩ ΤΟ ΑΡΧΕΙΟ
            IsConnected("UPDATE EGGTIM SET XRE=1 WHERE XRE IS NULL", True)
        Else
            MsgBox("ΔΕΝ ΑΠΕΣΤΑΛΗΣΑΝ ΟΙ ΠΑΡΑΓΓΕΛΙΕΣ")
        End If




    End Sub


    Sub TO_CSV()
        Dim SEIRA As String = Space(200)
        Dim sw As StreamWriter
        Dim COUNTER As Long


        If File.Exists("c:\MERCVB\EGGTIM2.TXT") Then
            Kill("c:\MERCVB\EGGTIM2.TXT")
        End If

        Dim fs As New FileStream("c:\MERCVB\EGGTIM2.TXT", FileMode.CreateNew, FileAccess.Write)
        ' sw = New StreamWriter(fs, System.Text.Encoding.Default)
        If gBaran = 1 Then
            sw = New StreamWriter(fs, System.Text.Encoding.UTF8)
        Else
            sw = New StreamWriter(fs, System.Text.Encoding.Default)
        End If

        sw.WriteLine("  ")
        'Else

        'Dim fs As New FileStream("c:\MERCVB\EGGTIM2.TXT", FileMode.CreateNew, FileAccess.Write)
        'sw = New StreamWriter(fs, System.Text.Encoding.Default)
        'sw = File.CreateText("c:\MERCVB\EGGTIM2.TXT")
        'End If




        Dim K As Long


        Dim ans As Integer
        ans = MsgBox("μονο τις νεες", MsgBoxStyle.YesNo)




        ' DataGrid1.DataSource = DS.Tables(0)
        Dim atim, kode, poso, KPE As String
        Dim TIMM As String, onoma As String

        'IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where MONTH(HME)=" + Str(Month(Now)) + " AND DAY(HME)=" + Format(Now, "dd") + " ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
        If ans = vbYes Then

            If gBaran = 1 Then
                IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where MONTH(HME)=" + Str(Month(Now)) + " AND DAY(HME)=" + Format(Now, "dd") + " ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
            Else
                IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD where E.XRE IS NULL ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
            End If

        Else
            IsConnected("Select * from EGGTIM E INNER JOIN PEL P ON E.PELKOD=P.KOD  ORDER BY ATIM ", False)  'INNER JOIN EID D ON E.KODE=D.KOD
        End If

        Dim MEPO As String
        Dim fpa As String
        Dim MMON As String
        Dim EKPT As String
        Dim SXOLIA As String
        Dim MHME As String
        Dim MONO As String

        Dim analposo As String

        Dim MEPO_ALL As String = "99999999"
        While (myDR.Read())
            KPE = IIf(IsDBNull(myDR("PELKOD")), "", myDR("PELKOD"))
            MEPO = myDR("EPO")
            If MEPO_ALL = MEPO Then
                MEPO = ""
            Else
                ' TO IDIO
            End If
            MEPO_ALL = myDR("EPO")

            Me.Text = MEPO_ALL

            If IsDBNull(myDR("MONA")) Then
                MMON = ""
            Else
                MMON = myDR("MONA")
            End If

            If IsDBNull(myDR("fpa")) Then
                fpa = "1224"
            Else

                If myDR("fpa") = 24 Then
                    fpa = "1224"
                ElseIf myDR("fpa") = 13 Then
                    fpa = "1130"
                ElseIf myDR("fpa") = 0 Then
                    fpa = "1000"
                Else
                    fpa = myDR("fpa").ToString
                End If




            End If





            ' MONO = myDR("ONOMA")
            atim = myDR("ATIM")
            kode = myDR("KODE")
            Me.Text = kode

            ' onoma = myDR("ONOMA")
            poso = myDR("POSO")
            If gBaran = 29 Then
                poso = Replace(myDR("POSO").ToString, ".", ",")
                TIMM = Replace(myDR("TIMM").ToString, ".", ",")
            Else
                TIMM = Replace(myDR("TIMM").ToString, ",", ".")
            End If



            '   EKPT = myDR("EKPT")
            Me.Text = kode

            If IsDBNull(myDR("PROELEYSH")) Then
                SXOLIA = ""
            Else
                SXOLIA = myDR("PROELEYSH")
            End If

            If IsDBNull(myDR("ONOMA")) Then
                MONO = ""
            Else
                MONO = myDR("ONOMA")
            End If

            If IsDBNull(myDR("EKPT")) Then
                EKPT = "0"
            Else
                EKPT = myDR("EKPT").ToString
            End If

            MHME = Format(myDR("HME"), "dd/MM/yyyy")

            Dim KAI As String

            If gBaran = 93 Then

                '7021,2032,5/2/2017,01-001,1,4212003,36,1.35,1224,1,10
                '7021,2032,5/2/2017,01-001,1,200022,2,6,1000,1,0
                '7021,2032,5/2/2017,01-001,1,105000,5,0.66,1130,1,10
                '7021,3055,5/2/2017,ΔΡ-194,1,4212003,24,1.35,1224,1,10
                '7021,3055,5/2/2017,ΔΡ-194,1,200022,12,6,1000,1,0
                '7021,3055,5/2/2017,ΔΡ-194,1,105000,15,0.66,1130,1,10

                KAI = ","

                If Val(fpa) = 1000 Then ' kena
                    sw.WriteLine(gSEIRA + KAI + Mid(atim, 2, 6) + KAI + MHME + KAI + KPE + KAI + "1" + KAI + kode + KAI + poso + KAI + TIMM + KAI + fpa + KAI + "1" + KAI + EKPT + KAI + SXOLIA + poso)
                    ' sw.WriteLine(Mid(KPE + Space(10), 1, 10) + Mid(atim + Space(10), 1, 10) + Mid(kode + Space(10), 1, 10) + Mid(poso + Space(10), 1, 10) + Mid(TIMM + Space(10), 1, 10) + Mid(EKPT + Space(10), 1, 10) + MHME)
                Else

                    If IsDBNull(myDR("kerdos")) Then
                        analposo = myDR("POSO")
                    Else
                        analposo = myDR("POSO") * myDR("kerdos")
                    End If

                    TIMM = Replace(myDR("prood").ToString, ",", ".")  ' καθαρη τιμη χωρισ εφκα και συσκευασια δηλ.τιμη φιαλης χωρις ΕΦΚΑ
                    sw.WriteLine(gSEIRA + KAI + Mid(atim, 2, 6) + KAI + MHME + KAI + KPE + KAI + "1" + KAI + kode + KAI + analposo + KAI + TIMM + KAI + fpa + KAI + "1" + KAI + EKPT + KAI + SXOLIA + KAI + poso)
                End If



            ElseIf gBaran = 29 Then
                KAI = ";"
                sw.WriteLine(gSEIRA + KAI + Mid(atim, 2, 6) + KAI + KAI + poso + KAI + TIMM + KAI + KAI + KPE + KAI + kode + KAI + MHME + KAI + EKPT + KAI + SXOLIA)

                ' sw.WriteLine(gSEIRA + ";" + Mid(atim, 2, 6) + ";;" + poso + ";" + TIMM + ";;" + KPE + ";" + kode + ";" + MHME + ";" + EKPT + ";" + SXOLIA)
            Else
                sw.WriteLine(KPE + ";" + MEPO + ";" + atim + ";" + kode + ";" + MONO + ";" + poso + ";" + TIMM + ";" + ";" + MMON)
            End If
            '

            K = K + 1

        End While









        sw.Close()
        If K = 0 Then
            MsgBox("ΔΕΝ ΥΠΑΡΧΟΥΝ ΠΑΡΑΓΓΕΛΙΕΣ ΓΙΑ ΑΠΟΣΤΟΛΗ")
            Exit Sub
        End If
        MsgBox("ok")


        Dim mnow As String = Format(Now, "HH-mm-ss")
        Dim mfile As String = GFILEdestination + mnow + ".TXT"



        FileCopy("c:\MERCVB\EGGTIM2.TXT", mfile)
        If File.Exists(mfile) Then  'AFOY TO ΕΓΡΑΨΕ ΤΟΤΕ ΣΒΗΝΩ ΤΟ ΑΡΧΕΙΟ
            IsConnected("UPDATE EGGTIM SET XRE=1 WHERE XRE IS NULL", True)





        Else
            MsgBox("ΔΕΝ ΑΠΕΣΤΑΛΗΣΑΝ ΟΙ ΠΑΡΑΓΓΕΛΙΕΣ")
        End If


        'Dim filename As String = "c:\mercvb\ektyp4.xlsx"
        'Dim row, column As Integer
        'Dim sheetname As String = "Φύλλο1"






        'Dim xlApp As Excel.Application
        'Dim xlWorkBook As Excel.Workbook
        'Dim xl As Excel.Worksheet



        'IsConnected("Select * from EGGTIM ", False)




        'xlApp = New Excel.ApplicationClass
        'xlWorkBook = xlApp.Workbooks.Add   'Open(filename)

        '' WS(k).Name = Str(k) + jt.Rows(k)("name")    
        'xlApp.Visible = False
        'xl = xlWorkBook.Worksheets(1)
        'Dim K, C As Integer
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'K = 1
        'While (myDR.Read())

        '    'Sql = "INSERT INTO EGGTIM (HME,KODE,ID_NUM,EIDOS,APOT,FPA,ONOMA,ATIM,POSO,TIMM) VALUES ('" + Format(myDR("HME"), "MM/dd/yyyy") + "','" + myDR("KODE") + "'," + Str(myDR("ID_NUM")) + ",'e',1,2,'" + myDR("ONOMA") + "','"
        '    'Sql = Sql + myDR("ATIM") + "'," + Replace(Str(myDR("POSO")), ",", ".") + "," + Replace(Format(myDR("TIMM"), "##0.00"), ",", ".") + ")"

        '    'For C = 1 To sqlDT.Columns.Count

        '    xl.Cells(K, 1) = myDR("PELKOD")
        '    xl.Cells(K, 2) = myDR("ATIM")
        '    xl.Cells(K, 3) = myDR("KODE")
        '    xl.Cells(K, 4) = myDR("ONOMA")
        '    xl.Cells(K, 5) = myDR("POSO")
        '    xl.Cells(K, 6) = myDR("TIMM")
        '    K = K + 1

        'End While


        '' Next
        'xlApp.Visible = True
        'Me.Cursor = System.Windows.Forms.Cursors.Arrow
    End Sub
    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click

        Dim rep As Integer
        rep = MsgBox("Να Διαγραφούν όλες οι παραγγελίες ?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Confirmation")
        If rep = vbYes Then
            IsConnected("Delete from EGGTIM  ", True)
            IsConnected("Delete from TIM  ", True)
            ' IsConnected("Select * from tblPersonal", False)
            ' LOAD_EGGTIM()
            MsgBox("ok διαγράφηκαν")
        End If

    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LOAD_CSV()

        '    If File.Exists("C:\MERCVB\EID.CSV") Then
        '    Else
        '        MsgBox("ΔΕΝ ΥΠΑΡΧΕΙ ΤΟ ΑΡΧΕΙΟ C:\MERCVB\EID.CSV")
        '        Exit Sub
        '    End If





        '    Using sr As StreamReader = New StreamReader("C:\MERCVB\EID.CSV", System.Text.Encoding.Default)
        '        Dim line, CC As String
        '        CC = ""
        '        Dim MKOD, MONO, MLTI As String


        '        Dim N As Long
        '        Dim SQL As String

        '        ' Κωδικός Είδους	Περιγραφή	Μονάδα Μέτρησης Α	Τιμές	Κατηγορία
        '        '07.001	ΜΠΟΥΤΙ ΚΟΤΑΣ ΧΥΜ ΟΛΑΝΔΙΑΣ. ΚΤΨ	Κιλά	1,45	1
        '        '07.002	ΜΠΟΥΤΙ ΚΟΤΑΣ ΤΥΠ ΚΑΡΑΓΙΑ.ΕΛΛΗΝ. ΚΤΨ	Κιλά	3,15	1

        '        Dim MMON As String
        '        Dim MAEG As String
        '        IsConnected("DELETE FROM EID", True)
        '        line = sr.ReadLine()  'seira me header
        '        Do
        '            line = sr.ReadLine()
        '            If line Is Nothing Then
        '            Else

        '                Try

        '                    MKOD = Mid(Split(line, ";")(0), 1, 30)
        '                    If Len(Split(line, ";")(0)) > 30 Then

        '                        Application.DoEvents()
        '                    End If
        '                    MAEG = Replace(Split(line, ";")(4), ",", ".")
        '                    MONO = Mid(Replace(Split(line, ";")(1), "'", "`"), 1, 40)
        '                    MLTI = Replace(Split(line, ";")(3), ",", ".")
        '                    If Val(MLTI) = 0 Then
        '                        MLTI = "0"
        '                    End If


        '                    MMON = Split(line, ";")(2)
        '                    SQL = "INSERT INTO EID (KOD,ONO,AEG,LTI,MON) VALUES ('" + MKOD + "','" + MONO + "'," + MAEG + "," + MLTI + ",'" + MMON + "' ); "
        '                    IsConnected(SQL, True)
        '                Catch ex As Exception
        '                    'ListBox1.Items.Add(CC & ex.Message)
        '                End Try
        '            End If
        '            N = N + 1
        '            If N Mod 10 = 0 Then
        '                Application.DoEvents()
        '                Me.Text = "ΕΙΔΗ " + Format(N, "#####")
        '            End If
        '        Loop Until line Is Nothing
        '        sr.Close()

        '        MsgBox("OK")

        '    End Using



        '    'Συντομογ	Όνομα	Α.Φ.Μ.	Οδός	kvdikos	kathg
        '    '000594	ΧΑΡΙΣΚΟΣ ΙΩΑΝΝΗΣ	052566632	Δ.ΚΑΡΑΟΛΗ	ΔΕΥΤΕΡΑ	2
        '    '000812	ΤΣΙΑΠΑΛΗ ΓΕΩΡΓΙΑ	121939029	ΖΑΦΕΙΡΗ	ΔΕΥΤΕΡΑ	2

        '    Using sr As StreamReader = New StreamReader("C:\MERCVB\PEL.CSV", System.Text.Encoding.Default)
        '        Dim line, CC As String
        '        CC = ""
        '        Dim MKOD, MONO, MLTI As String


        '        Dim N As Long
        '        Dim SQL As String



        '        Dim MDIE As String
        '        Dim MAEG As String
        '        Dim MAFM As String

        '        IsConnected("DELETE FROM PEL", True)
        '        line = sr.ReadLine()  'seira me header
        '        Do
        '            line = sr.ReadLine()
        '            If line Is Nothing Then
        '            Else

        '                Try

        '                    MKOD = Mid(Split(line, ";")(0), 1, 30)
        '                    If Len(Split(line, ";")(0)) > 30 Then

        '                        Application.DoEvents()
        '                    End If
        '                    MAEG = Replace(Split(line, ";")(5), ",", ".")
        '                    MONO = Mid(Replace(Split(line, ";")(1), "'", "`"), 1, 40)

        '                    MAFM = Split(line, ";")(2)

        '                    MDIE = Split(line, ";")(3)
        '                    SQL = "INSERT INTO PEL (KOD,EPO,AEG,AFM,DIE) VALUES ('" + MKOD + "','" + MONO + "'," + MAEG + ",'" + MAFM + "','" + MDIE + "' ); "
        '                    IsConnected(SQL, True)
        '                Catch ex As Exception
        '                    'ListBox1.Items.Add(CC & ex.Message)
        '                End Try
        '            End If
        '            N = N + 1
        '            If N Mod 10 = 0 Then
        '                Application.DoEvents()
        '                Me.Text = "ΠΕΛΑΤΕΣ " + Format(N, "#####")
        '            End If
        '        Loop Until line Is Nothing
        '        sr.Close()

        '        MsgBox("OK")

        '    End Using



    End Sub

    Sub LOAD_CSV()

        If File.Exists("C:\MERCVB\EID.CSV") Then
        Else
            MsgBox("ΔΕΝ ΥΠΑΡΧΕΙ ΤΟ ΑΡΧΕΙΟ C:\MERCVB\EID.CSV")
            Exit Sub
        End If





        Using sr As StreamReader = New StreamReader("C:\MERCVB\EID.CSV", System.Text.Encoding.Default)
            Dim line, CC As String
            CC = ""
            Dim MKOD, MONO, MLTI As String


            Dim N As Long
            Dim SQL As String

            ' Κωδικός Είδους	Περιγραφή	Μονάδα Μέτρησης Α	Τιμές	Κατηγορία
            '07.001	ΜΠΟΥΤΙ ΚΟΤΑΣ ΧΥΜ ΟΛΑΝΔΙΑΣ. ΚΤΨ	Κιλά	1,45	1
            '07.002	ΜΠΟΥΤΙ ΚΟΤΑΣ ΤΥΠ ΚΑΡΑΓΙΑ.ΕΛΛΗΝ. ΚΤΨ	Κιλά	3,15	1
            'IsDBNull(myDR("ONO")), "", myDR("ONO"))
            Dim nf As String = 0
            Dim MMON As String
            Dim MAEG As String

            '  IsConnected("DELETE FROM EID", True)
            line = sr.ReadLine()  'seira me header
            ListBox1.Items.Add("ΔΕΝ ΕΝΗΜΕΡΩΘΗΚΑΝ:")

            Do
                line = sr.ReadLine()
                If line Is Nothing Then
                Else

                    Try

                        MKOD = Mid(Split(line, ";")(0), 1, 30)
                        If Len(Split(line, ";")(0)) > 30 Then

                            Application.DoEvents()
                        End If
                        MAEG = Replace(Split(line, ";")(4), ",", ".")
                        MONO = Mid(Replace(Split(line, ";")(1), "'", "`"), 1, 40)
                        MLTI = Replace(Split(line, ";")(3), ",", ".")
                        If Val(MLTI) = 0 Then
                            MLTI = "0"
                        End If


                        MMON = Split(line, ";")(2)
                        IsConnected("SELECT *  FROM EID WHERE KOD='" + MKOD + "'", False)
                        'myDR.Read()
                        Dim YPARXEI As Integer = 0
                        While myDR.Read()
                            If myDR("ONO") = MONO Then
                            Else
                                IsConnected("UPDATE EID SET LTI=" + MLTI + ",AEG=" + MAEG + ",ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("LTI") = MLTI Then
                            Else
                                IsConnected("UPDATE EID SET LTI=" + MLTI + ",AEG=" + MAEG + ",ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("AEG") = MAEG Then
                            Else
                                IsConnected("UPDATE EID SET LTI=" + MLTI + ",AEG=" + MAEG + ",ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If






                            YPARXEI = 1
                            Exit While

                        End While

                        If YPARXEI = 0 Then
                            'IsDBNull(myDR("ONO")), "", myDR("ONO"))

                            SQL = "INSERT INTO EID (KOD,ONO,AEG,LTI,MON) VALUES ('" + MKOD + "','" + MONO + "'," + MAEG + "," + MLTI + ",'" + MMON + "' ); "
                            IsConnected(SQL, True)

                        End If



                    Catch ex As Exception
                        nf = nf + 1
                        ListBox1.Items.Add(Str(nf) + MKOD + " " + MONO)
                    End Try
                End If
                N = N + 1
                If N Mod 1 = 0 Then
                    Application.DoEvents()
                    Me.Text = "ΕΙΔΗ " + Format(N, "#####")
                End If
            Loop Until line Is Nothing
            sr.Close()

            MsgBox("OK")

        End Using



        'Συντομογ	Όνομα	Α.Φ.Μ.	Οδός	kvdikos	kathg
        '000594	ΧΑΡΙΣΚΟΣ ΙΩΑΝΝΗΣ	052566632	Δ.ΚΑΡΑΟΛΗ	ΔΕΥΤΕΡΑ	2
        '000812	ΤΣΙΑΠΑΛΗ ΓΕΩΡΓΙΑ	121939029	ΖΑΦΕΙΡΗ	ΔΕΥΤΕΡΑ	2

        Using sr As StreamReader = New StreamReader("C:\MERCVB\PEL.CSV", System.Text.Encoding.Default)
            Dim line, CC As String
            CC = ""
            Dim MKOD, MONO, MLTI As String


            Dim N As Long
            Dim SQL As String



            Dim MDIE As String
            Dim MAEG As String
            Dim MAFM As String

            'IsConnected("DELETE FROM PEL", True)
            line = sr.ReadLine()  'seira me header
            Do
                line = sr.ReadLine()
                If line Is Nothing Then
                Else

                    Try

                        MKOD = Mid(Split(line, ";")(0), 1, 30)
                        If Len(Split(line, ";")(0)) > 30 Then

                            Application.DoEvents()
                        End If
                        MAEG = Replace(Split(line, ";")(5), ",", ".")
                        MONO = Mid(Replace(Split(line, ";")(1), "'", "`"), 1, 40)

                        MAFM = Split(line, ";")(2)

                        MDIE = Replace(Split(line, ";")(3), "'", "`") 'Split(line, ";")(3)


                        IsConnected("SELECT *  FROM PEL WHERE KOD='" + MKOD + "'", False)
                        'myDR.Read()
                        Dim YPARXEI As Integer = 0
                        While myDR.Read()
                            If myDR("ONO") = MONO Then
                            Else
                                IsConnected("UPDATE PEL SET ONO='" + MONO + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("DIE") = MDIE Then
                            Else
                                IsConnected("UPDATE PEL SET DIE='" + MDIE + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("AFM") = MAFM Then
                            Else
                                IsConnected("UPDATE PEL SET AFM='" + MAFM + "' WHERE KOD='" + MKOD + "'", True)
                            End If

                            If myDR("AEG") = MAEG Then
                            Else
                                IsConnected("UPDATE PEL SET AEG=" + MAEG + "' WHERE KOD='" + MKOD + "'", True)
                            End If




                            YPARXEI = 1
                            Exit While

                        End While

                        If YPARXEI = 0 Then
                            'IsDBNull(myDR("ONO")), "", myDR("ONO"))


                            SQL = "INSERT INTO PEL (KOD,EPO,AEG,AFM,DIE) VALUES ('" + MKOD + "','" + MONO + "'," + MAEG + ",'" + MAFM + "','" + MDIE + "' ); "
                            IsConnected(SQL, True)
                        End If

                    Catch ex As Exception
                        'ListBox1.Items.Add(CC & ex.Message)
                    End Try
                End If
                N = N + 1
                If N Mod 10 = 0 Then
                    Application.DoEvents()
                    Me.Text = "ΠΕΛΑΤΕΣ " + Format(N, "#####")
                End If
            Loop Until line Is Nothing
            sr.Close()

            MsgBox("OK")

        End Using


    End Sub







    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        gID_NUM = LV2.SelectedItems(0).SubItems(2).Text
        gAtim = LV2.SelectedItems(0).SubItems(1).Text
        LOAD_EGGTIM()
        lvEggtim.Visible = False
        LOAD_EIDH("")
        ButtonAdd.Text = "Κλείσιμο Παραγγελίας"
        NEOEIDOS.Enabled = True

    End Sub
    ' Dim WithEvents pd As PrintDocument = New PrintDocument
    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        '    pd.PrinterSettings.PrinterName = "Generic / Text Only"
        '   pd.Print()
        ' typono()
        PrintDocument1.Print()



    End Sub

    Private Sub Button11_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        TYPOSE("Α")
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TYPOSE("Β")
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        TYPOSE("Γ")
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        TYPOSE("Δ")
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        TYPOSE("Ε")
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        TYPOSE("Ζ")
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        TYPOSE("Η")
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        TYPOSE("Θ")
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        TYPOSE("Ι")
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        TYPOSE("Κ")
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        TYPOSE("Λ")
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        TYPOSE("Μ")
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        TYPOSE("Ν")
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        TYPOSE("Ξ")
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TYPOSE("Ο")
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        TYPOSE("Π")
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        TYPOSE("Ρ")
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        TYPOSE("Σ")
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        TYPOSE("Τ")
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        TYPOSE("Υ")
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        TYPOSE("Φ")
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        TYPOSE("Χ")
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        TYPOSE("Ψ")
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        TYPOSE("Ω")
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim PFONT As Font
        PFONT = New Font("Arial Greek", 20)
        ' e.Graphics.DrawString("καλημερα", PFONT, Brushes.Black, 0, 0)



        If File.Exists("C:\MERCVB\EGGTIM2.TXT") Then
        Else

            Exit Sub
        End If




        Dim MS As Long = 0
        Using sr As StreamReader = New StreamReader("C:\MERCVB\EGGTIM2.TXT", System.Text.Encoding.Default)
            Dim line, CC As String
            Do
                line = sr.ReadLine()  'seira me header
                Me.Text = line
                Button35.Text = Me.Text

                MS = MS + 20
                e.Graphics.DrawString(Button35.Text, PFONT, Brushes.Black, 40, MS)
            Loop Until line Is Nothing
            sr.Close()
        End Using





    End Sub



    Private Sub EidhPel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EidhPel.Click
        'ΑΝ ΔΕΝ ΕΧΕΙ ΔΙΑΛΕΞΕΙ ΠΕΛΑΤΗ ΒΓΕΣ ΕΞΩ
        If ButtonAdd.Text = "Νέα Παραγγελία" Then
            Exit Sub
        End If

        Dim PEL As String = Split(GroupBox1.Text, ";")(0)

        '    kl = IsConnected("INSERT INTO EIDHPEL (KODPEL,KODE,POSO,AJIA,TELTIMH)

        Dim c As String

        If gBaran = 93 Then
            LOAD_EIDH(" inner JOIN EIDHPEL  ON EID.KOD=EIDHPEL.KODE  WHERE  EIDHPEL.KODPEL='" + PEL + "'  ")
            Exit Sub
            'c = "Select top 10000 ID,KOD,ONO,LTI,XTI,ROUND(POS_KERD,1) AS KERD,MON,FPA,G07,POS,LTI_SYNOD,SYSKEYASIA,G01,G02,G03,G04,G05,G06  from EID  inner JOIN EIDHPEL  ON EID.KOD=EIDHPEL.KODE  WHERE  EIDHPEL.KODPEL='" + PEL + "'  order BY ONO "
        ElseIf gBaran = 1 Then
            IsConnected("DROP TABLE EIDHPEL", True)

            'c = "Select top 10000 EID.ID,KOD,ONO,LTI AS TELTIMH,XTI,ROUND(POS_KERD,1) AS KERD,MON,EID.FPA,EID.ID AS ID2,KOD AS KOD2 from EID  inner JOIN EGGTIM  ON EID.KOD=EGGTIM.KODE  WHERE  EGGTIM.PELKOD='" + PEL + "'  order BY ONO "
            c = "Select  PELKOD AS KODPEL, KODE,SUM(POSO) AS POSO,SUM(POSO*TIMM*(100-EKPT)/100) AS AJIA,MAX(TIMM) AS TELTIMH into EIDHPEL FROM EGGTIM  GROUP BY PELKOD,KODE"
            IsConnected(c, True)
            c = "Select top 10000 ID,KOD,EID.ONO,LTI,XTI,ROUND(POS_KERD,1) AS KERD,EID.MON,EID.FPA,G07,EID.POS,POSO,AJIA,TELTIMH  from EID  inner JOIN EIDHPEL  ON EID.KOD=EIDHPEL.KODE  WHERE  EIDHPEL.KODPEL='" + PEL + "'  order BY ONO "

        Else
            c = "Select top 10000 ID,KOD,EID.ONO,LTI,XTI,ROUND(POS_KERD,1) AS KERD,EID.MON,EID.FPA,G07,EID.POS,POSO,AJIA,TELTIMH  from EID  inner JOIN EIDHPEL  ON EID.KOD=EIDHPEL.KODE  WHERE  EIDHPEL.KODPEL='" + PEL + "'  order BY ONO "
        End If



        IsConnected(c, False)
        ' Call Loader()
        LV.Items.Clear()

        LV.Columns(0).Text = "Α/Α"
        LV.Columns(1).Text = "ΚΩΔΙΚΟΣ"
        LV.Columns(2).Text = "ONOMA"
        LV.Columns(3).Text = "XONDR.TIMH"
        LV.Columns(4).Text = "ΑΓΟΡΕΣ ΠΟΣ"
        LV.Columns(4).TextAlign = HorizontalAlignment.Right
        LV.Columns(4).Width = 300


        LV.Columns(5).Text = "ΑΞΙΑ"
        'LV.Columns(4).Text = "ΤΗΛΕΦΩΝΟ"
        LV.Columns(6).Text = "MON.MET"
        LV.Columns(7).Text = "ΦΠΑ"
        MHNYMA.Text = f_mess_eid

        LV.Columns(8).Text = "TIM 7"
        LV.Columns(9).Text = "ΥΠΟΛ"


        LV.Columns(10).Text = "ΕΦΚ"
        LV.Columns(11).Text = "ΣΥΣΚ"

        Dim N As Integer
        For N = 1 To 9
            LV.Columns(N - 1).Width = Split(F_PLATH_EID, ";")(N - 1) 'Split(line, ";")(0)
        Next




        ' If myDR.RecordsAffected = 0 Then Exit Sub

        While (myDR.Read())

            With LV.Items.Add(myDR(0))
                .SubItems.Add(myDR("KOD"))
                .SubItems.Add(IIf(IsDBNull(myDR("ONO")), "", myDR("ONO")))
                .SubItems.Add(IIf(IsDBNull(myDR("TELTIMH")), "", myDR("TELTIMH")))
                .SubItems.Add(IIf(IsDBNull(myDR("POSO")), "", myDR("POSO")))
                .SubItems.Add(IIf(IsDBNull(myDR("AJIA")), "", myDR("AJIA")))
                .SubItems.Add(IIf(IsDBNull(myDR("mon")), "", myDR("mon")))
                .SubItems.Add(IIf(IsDBNull(myDR("FPA")), "", myDR("FPA")))
                .SubItems.Add(IIf(IsDBNull(myDR("G07")), "", myDR("G07")))
                .SubItems.Add(IIf(IsDBNull(myDR("POS")), "", myDR("POS")))
                '.SubItems.Add(myDR("MON"))

                '  .SubItems.Add(IIf(IsDBNull(myDR("LTI_SYNOD")), "", myDR("LTI_SYNOD")))
                '  .SubItems.Add(IIf(IsDBNull(myDR("SYSKEYASIA")), "", myDR("SYSKEYASIA")))


            End With


        End While


    End Sub



    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        TYPOSE("*")
    End Sub

    Private Sub sxolia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles sxolia.Click
        If sxolia.BackColor = Color.Yellow Then
            sxolia.BackColor = Color.White
        Else
            sxolia.BackColor = Color.Yellow
        End If
    End Sub

    Private Sub sxolia_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles sxolia.GotFocus

    End Sub

    Private Sub sxolia_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles sxolia.TextChanged

    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        TYPOSE(" ")
    End Sub

    Private Sub TextBox4_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBox4.MouseClick
        sxolia.BackColor = Color.LightGray
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

    End Sub
End Class



'Visual Basic 
' Implements the manual sorting of items by columns.
Class ListViewItemComparer
    Implements IComparer
    Private col As Integer
    Private order As SortOrder

    Public Sub New()
        col = 0
        order = SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer, ByVal order As SortOrder)
        col = column
        Me.order = order
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer _
                        Implements System.Collections.IComparer.Compare
        Dim returnVal As Integer = -1
        Try
            returnVal = [String].Compare(CType(x,  _
                            ListViewItem).SubItems(col).Text, _
                            CType(y, ListViewItem).SubItems(col).Text)
            ' Determine whether the sort order is descending.
            If order = SortOrder.Descending Then
                ' Invert the value returned by String.Compare.
                returnVal *= -1
            End If

            Return returnVal
        Catch


        End Try

    End Function





    ' Sub pr2()

   
    '  End Sub

    'event handler
    'Private Sub pdpp(ByVal sender As Object, ByVal ev As PrintPageEventArgs) Handles pd.PrintPage
    '   ev.Graphics.DrawString("Hello", New Font("Arial", 20), Brushes.Black, 20, 20)
    ' End Sub

    'End Module


















End Class
