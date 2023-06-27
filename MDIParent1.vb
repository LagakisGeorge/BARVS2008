Imports System.Windows.Forms
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6

Public Class MDIParent1

    Dim vv As New Printer


    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs) Handles NewToolStripMenuItem.Click, NewWindowToolStripMenuItem.Click
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs) Handles OpenToolStripMenuItem.Click
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles SaveAsToolStripMenuItem.Click
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

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CutToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CopyToolStripMenuItem.Click
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PasteToolStripMenuItem.Click
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ToolBarToolStripMenuItem.Click
        ' Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    End Sub

    Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles StatusBarToolStripMenuItem.Click
        Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CascadeToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileVerticalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TileHorizontalToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ArrangeIconsToolStripMenuItem.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
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

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        utilities.Show()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'ALTER TABLE PARAGG ADD PRINTER INT NOT NULL DEFAULT 1
        'Dim dt5 As New DataTable

        'Dim SQL As String
        'SQL = "insert into PARAGG (TRAPEZI , IDPARAGG , POSO , TIMH , ONO , PROSUETA , CH1 , NUM1 , NUM2 , ENERGOS , PRINTER ) SELECT   TRAPEZI , IDPARAGG , POSO , TIMH , ONO , PROSUETA , CH1SXOLIA , NUM1PLIROMENO , NUM2 , ENERGOSTYPOMENO , PRINTER  FROM  PARAGGPDA  WHERE ISNULL(ENERGOSTYPOMENO,0)=0"
        'ExecuteSQLQuery(SQL, dt5)
        'ExecuteSQLQuery("UPDATE", dt5)


    End Sub
    Private Sub PRINTPARAGG()


        'ExecuteSQLQuery(SQL, dt5)



        vv.FontSize = 14
        vv.FontBold = True
        Dim p_Trapezi As String = "000"

        If Val(p_Trapezi) > 900 Then
            vv.Print("*** ΠΑΚΕΤΟ ***")
            vv.Print(" ΠΑΚΕΤΟ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))

        Else
            vv.Print("ΤΡΑΠΕΖΙ " + p_Trapezi + "   * " + Format(Now, "hh:mm"))
        End If
        vv.Print("===========")

        Dim DT8 As New DataTable
        ExecuteSQLQuery("SELECT   TRAPEZI , IDPARAGG , POSO , TIMH , ONO , PROSUETA , CH1SXOLIA , NUM1PLIROMENO , NUM2 , ENERGOSTYPOMENO , PRINTER  FROM  PARAGGPDA  WHERE ISNULL(ENERGOSTYPOMENO,0)=0", DT8)


        Dim c2 As String = ""
        For K As Integer = 0 To DT8.Rows.Count - 1


            Dim MDATE As String
            If InStr(gCONNECT, "MDB") > 0 Then
                MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
            Else
                MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
            End If

          



            Dim SQL As String = ""

            'TYPVNV TO EIDOS

            If nNull(DT8.Rows(K)("POSO")) > 1 Then
                vv.Print(DT8.Rows(K)("POSO").ToString + " X ")
            End If

            If nNull(DT8.Rows(K)("TIMH")) < 0 Then
                vv.Print("******* ΑΚΥΡΩΣΗ **********")
            End If


            vv.Print(DT8.Rows(K)("ono"))





            Dim parts As String() = c2.Split(New Char() {","c})

            ' Loop through result strings with For Each.
            Dim part As String
            For Each part In parts
                'Console.WriteLine(part)
                vv.Print("*" + part)
            Next


            'If Len(Trim(ListParagg.Items(K).SubItems(4).Text)) > 0 Then
            '    vv.Print("*" + Trim(ListParagg.Items(K).SubItems(4).Text))
            'End If

            vv.Print("-------------")



        Next






    End Sub
End Class
