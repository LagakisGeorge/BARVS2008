Imports System.Windows.Forms
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Public Class MDIParent1

    Dim vv As New Printer



    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub MDIParent1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ADDITPARAGG.MdiParent = Me
        ARXEIA0.MdiParent = Me
        arxeia.MdiParent = Me
        paragkentr.MdiParent = Me

        paragkentr.Show()
       
        


    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        utilities.Show()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ''ALTER TABLE PARAGG ADD PRINTER INT NOT NULL DEFAULT 1
        Dim dt5 As New DataTable
        'ΤΥΠΩΝΩ ΤΟ ΠΡΩΤΟ ΤΡΑΠΕΖΙ ΠΟΥ ΗΡΘΕ ΓΙΑ ΕΚΤΥΠΩΣΗ
        ExecuteSQLQuery(" SELECT TOP 1 ISNULL(TRAPEZI,'0') FROM  PARAGGPDA  WHERE ISNULL(ENERGOSTYPOMENO,0)=0", dt5)
        Dim TR As String = Replace(dt5(0)(0), "'", "`")
        If TR = "0" Then
            Exit Sub
        End If


        '  SELECT TOP (1000) [ONO]
        ',[KATEILHMENO]
        ',[SYNOLO]
        ',[NUM1]
        ',[NUM2]
        ',[CH1]
        ',[CH2]
        ',[IDPARAGG]
        ',[ID]
        ExecuteSQLQuery("SELECT ISNULL(IDPARAGG,0) FROM TABLES ", dt5)
        Dim mIDPARAGG As String = dt5(0)(0).ToString

        If dt5(0)(0) = 0 Then
            ExecuteSQLQuery("INSERT INTO PARAGGMASTER (TRAPEZI,HME) VALUES ('" + TR + "',GETDATE())", dt5)
            ExecuteSQLQuery("SELECT MAX(ISNULL(IDPARAGG,0) FROM PARAGGMASTER ", dt5)
            mIDPARAGG = dt5(0)(0).ToString

            ExecuteSQLQuery("UPDATE TABLES SET IDPARAGG=" + mIDPARAGG + " WHERE ONO='" + TR + "'", dt5)

        Else

        End If
        ',[ID]


        'ΙΝΣΕΡΤ ΙΝΤΟ PARAGG
        Dim SQL As String
        SQL = "insert into PARAGG (TRAPEZI , IDPARAGG , POSO , TIMH , ONO , PROSUETA , CH1 , NUM1 , NUM2 , ENERGOS , PRINTER ) "
        SQL = SQL + " SELECT   TRAPEZI , " + mIDPARAGG + " , POSO , TIMH , ONO , PROSUETA , CH1SXOLIA , NUM1PLIROMENO , NUM2 , ENERGOSTYPOMENO , PRINTER  "
        SQL = SQL + " FROM  PARAGGPDA  WHERE ISNULL(ENERGOSTYPOMENO,0)=0  AND TRAPEZI='" + TR + "'"
        ExecuteSQLQuery(SQL, dt5)



        ExecuteSQLQuery("UPDATE PARAGGPDA SET IDPARAGG=" + mIDPARAGG + "    WHERE ISNULL(ENERGOSTYPOMENO,0)=0 AND TRAPEZI='" + TR + "'", dt5)
        PRINTPARAGG(mIDPARAGG)

        'ΤΟ ΙΔΙΟ ΤΡΑΠΕΖΙ ΤΟ ΣΗΜΕΙΩΝΩ ENERGOSTYPOMENO=1
        ExecuteSQLQuery("UPDATE PARAGGPDA SET ENERGOSTYPOMENO=1    WHERE ISNULL(ENERGOSTYPOMENO,0)=0 AND TRAPEZI='" + TR + "'", dt5)



    End Sub
    Private Sub PRINTPARAGG(ByVal MIDPARAGG As String)
        Dim pri(3) As Printer



        For Each x In Printers

            If InStr(x.DeviceName, gPrinter1) > 0 Then
                pri(1) = x
            End If

            If InStr(x.DeviceName, gPrinter2) > 0 Then
                pri(2) = x
            End If

            If InStr(x.DeviceName, gPrinter3) > 0 Then
                pri(3) = x
            End If


        Next
        ' vv.DeviceName = "CITIZEN CT-S851II"

        For EKTYPOTIS As Integer = 1 To 3


            Dim DT8 As New DataTable
            ExecuteSQLQuery("SELECT   TRAPEZI , IDPARAGG , POSO , TIMH , ONO , PROSUETA , CH1SXOLIA , NUM1PLIROMENO , NUM2 , ENERGOSTYPOMENO , PRINTER  FROM  PARAGGPDA  WHERE IDPARAGG=" + MIDPARAGG + " AND ISNULL(ENERGOSTYPOMENO,0)=0 AND PRINTER=" + Str(EKTYPOTIS), DT8)
            If DT8.Rows.Count > 0 Then

                Dim pp As Integer
                pp = EKTYPOTIS



                pri(pp).FontSize = 14
                pri(pp).FontBold = True
                Dim p_Trapezi As String = "000"

                If Val(p_Trapezi) > 900 Then
                    pri(pp).Print("*** ΠΑΚΕΤΟ ***")
                    pri(pp).Print(" ΠΑΚΕΤΟ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))

                Else
                    pri(pp).Print("ΤΡΑΠΕΖΙ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))
                End If
                pri(pp).Print("===========")

                Dim c2 As String = ""
                For K As Integer = 0 To DT8.Rows.Count - 1
                    'pp = DT8(K)("PRINTER")


                    Dim MDATE As String
                    If InStr(gCONNECT, "MDB") > 0 Then
                        MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
                    Else
                        MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
                    End If





                    Dim SQL As String = ""

                    'TYPVNV TO EIDOS

                    If nNull(DT8.Rows(K)("POSO")) > 1 Then
                        pri(pp).Print(DT8.Rows(K)("POSO").ToString + " X ")
                    End If

                    If nNull(DT8.Rows(K)("TIMH")) < 0 Then
                        pri(pp).Print("******* ΑΚΥΡΩΣΗ **********")
                    End If


                    pri(pp).Print(DT8.Rows(K)("ono"))





                    Dim parts As String() = c2.Split(New Char() {","c})

                    ' Loop through result strings with For Each.
                    Dim part As String
                    For Each part In parts
                        'Console.WriteLine(part)
                        pri(pp).Print("*" + part)
                    Next


                    'If Len(Trim(ListParagg.Items(K).SubItems(4).Text)) > 0 Then
                    '    vv.Print("*" + Trim(ListParagg.Items(K).SubItems(4).Text))
                    'End If

                    pri(pp).Print("-------------")



                Next K

                pri(pp).EndDoc()
            End If


        Next EKTYPOTIS




    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ' NEAPARAGG.ShowDialog()
        'Dim F As New tables
        'F.MdiParent = Me

        'F.Show()
        'F = Nothing




        Dim per = "Τραπέζια"
        Dim kod = "00"
        Dim frm As New tables   ' form2 
        Dim PAGE As New TabPage
        Dim N As Integer = TabControl1.TabPages.Count
        PAGE.Text = per ' "Αναλώσιμα  ."
        frm.TopLevel = False
        frm.Visible = True
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        TabControl1.TabPages.Add(PAGE)
        TabControl1.TabPages(N).Controls.Add(frm)
        TabControl1.SelectTab(N)


















    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        
        Dim isnea As Integer
        isnea = 0

        If gBardia = 0 Then
            'BARDIES.MdiParent = MDIParent1

            Dim per = "Βάρδιες"
            Dim kod = "00"
            Dim frm As New BARDIES   ' form2 
            Dim PAGE As New TabPage
            Dim N As Integer = TabControl1.TabPages.Count
            PAGE.Text = per ' "Αναλώσιμα  ."
            frm.TopLevel = False
            frm.Visible = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill
            TabControl1.TabPages.Add(PAGE)
            TabControl1.TabPages(N).Controls.Add(frm)
            TabControl1.SelectTab(N)





            ' BARDIES.ShowDialog()


            isnea = 1


        Else
            Dim DT As New DataTable
            ExecuteSQLQuery("SELECT Sum(isnull(CASH,0)) AS CASH ,  Sum(isnull(PIS1,0)) AS PIS1 , Sum(isnull(PIS2,0)) AS PIS2 ,  Sum(isnull(KERA,0)) AS KERA  FROM PARAGGMASTER WHERE  IDBARDIA=" + Str(gBardia), DT)
            Dim MM As String = ""
            Dim CASH(5) As String
            Dim CASHTOT As Single = 0
            MsgBox("Μετρ: " + DT(0)("CASH").ToString + Chr(13) + "Πιστ: " + DT(0)("pis1").ToString + Chr(13) + "Εκπτ: " + DT(0)("PIS2").ToString + Chr(13) + "Κερασμ: " + DT(0)("KERA").ToString)

           

            Dim dt1 As New DataTable
            ExecuteSQLQuery("select count(*) FROM TABLES WHERE KATEILHMENO=1 AND NUM1=" + Str(gUser), dt1)
            If dt1(0)(0) > 0 Then
                MsgBox("ΥΠΑΡΧΟΥΝ " + Str(dt1(0)(0)) + " TRAPEZIA ANOIXTA")
            End If


            'ΕΛΕΓΧΩ ΑΝ ΕΧΕΙ ΑΝΟΙΧΤΑ ΤΡΑΠΕΖΙΑ




            Dim DT2 As New DataTable

            Dim ANS As Integer = MsgBox(MM, MsgBoxStyle.YesNo, "ΚΛΕΙΣΙΜΟ ΒΑΡΔΙΑΣ")
            '
            If ANS = MsgBoxResult.Yes Then
                paragkentr.TYPONO_BARDIA(gBardia)      
                ExecuteSQLQuery("UPDATE BARDIA SET CASHTOT=" + Replace(Format(CASHTOT, "####.00"), ",", ".") + ", CLOSEH='" + Format(Now, "hh:mm") + "', ISOPEN=0 WHERE ID=" + Str(gBardia), DT2)
                For K = 1 To 5
                    If CASH(K) = Nothing Then
                    Else
                        If Val(CASH(K)) > 0 Then
                            ExecuteSQLQuery("UPDATE BARDIA SET CASH" + Format(K, "0") + "=" + CASH(K) + " WHERE ID=" + Str(gBardia), DT2)
                        End If

                    End If
                Next
            End If

        End If
        paragkentr.CHECK_BARDIA()
        If isnea = 1 Then
            ' End
        End If

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click

        Dim per = "Αρχεία-"
        Dim kod = "00"
        Dim frm As New ARXEIA0   ' form2 
        Dim PAGE As New TabPage
        Dim N As Integer = TabControl1.TabPages.Count
        PAGE.Text = "Αρχεία" ' "Αναλώσιμα  ."


        frm.TopLevel = False
        frm.Visible = True
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill


        'If N = 0 Then
        '    TabControl1.TabPages.Add(PAGE)
        '    N = N + 1
        'End If

        TabControl1.TabPages.Add(PAGE)
        TabControl1.TabPages(N).Controls.Add(frm)
        TabControl1.SelectTab(N)









        'ARXEIA0.MdiParent = Me

        'ARXEIA0.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click


        Dim CCC As String = InputBox("ΔΩΣΕ KΩΔΙΚΟ ΔΙΕΥΘΥΝΤΗ ")
        If CCC = G_ADMIN_PW Then

            Dim per = "Τυπώνω"
            Dim kod = "00"
            Dim frm As New BARDIAOLDPRINT   ' form2 
            Dim PAGE As New TabPage
            Dim N As Integer = TabControl1.TabPages.Count
            PAGE.Text = "Τυπώνω" ' "Αναλώσιμα  ."


            frm.TopLevel = False
            frm.Visible = True
            frm.FormBorderStyle = FormBorderStyle.None
            frm.Dock = DockStyle.Fill

            TabControl1.TabPages.Add(PAGE)
            TabControl1.TabPages(N).Controls.Add(frm)
            TabControl1.SelectTab(N)



           ' BARDIAOLDPRINT.MdiParent = Me

            ' BARDIAOLDPRINT.Show()
        End If
    End Sub

    Private Sub cmdCustomerOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCustomerOrder.Click
        Dim CCC As String = InputBox("ΔΩΣΕ KΩΔΙΚΟ ΔΙΕΥΘΥΝΤΗ ")
        If CCC = G_ADMIN_PW Then

            Dim dt As New DataTable
            Dim PW, pw2 As String
            PW = InputBox("ΔΩΣΕ ΝΕΟ ΚΩΔΙΚΟ", "")
            pw2 = InputBox("ΕΠΑΝΑΛΑΒΕΤΕ ΤΟΝ ΝΕΟ ΚΩΔΙΚΟ", "")


            If PW = pw2 Then
                ExecuteSQLQuery("UPDATE LOGGING SET QUERY='" + PW + "' WHERE ID=1", dt)
                G_ADMIN_PW = PW
                MsgBox("OK")
            Else
                MsgBox("Ο Κωδικός δεν άλλαξε")
            End If
        End If
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim per = "Εκτυπωτές"
        Dim kod = "00"
        Dim frm As New Form7  ' form2 
        Dim PAGE As New TabPage
        Dim N As Integer = TabControl1.TabPages.Count
        PAGE.Text = "Εκτυπωτές-" ' "Αναλώσιμα  ."


        frm.TopLevel = False
        frm.Visible = True
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill

        TabControl1.TabPages.Add(PAGE)
        TabControl1.TabPages(N).Controls.Add(frm)
        TabControl1.SelectTab(N)
    End Sub
End Class
