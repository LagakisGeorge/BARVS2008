Public Class TRAPEZIAANASERVITORO

    Private Sub TRAPEZIAANASERVITORO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DTT2 As New DataTable
        ExecuteSQLQuery("SELECT * FROM ERGAZ ", DTT2) 'where NUM1=0 OR NUM1=" + u
        'This code is just to add a few test items to the listview

        For K As Integer = 0 To DTT2.Rows.Count - 1
            ListBox1.Items.Add(Str(DTT2.Rows(K)("ID")) + "-" + DTT2.Rows(K)("ONO"))
        Next

    End Sub

  


    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
       





    End Sub


    ' Private Sub serv_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)


    ' End Sub



    Sub SHOW_TRAPEZIA(ByVal TRAP As String)



        'Dim n1 As String
        'Dim n2 As String
        Dim u As String
        ' u = InputBox("Αριθμός Tablet/User ", "Αριθμός Tablet/User ")
        'n1 = InputBox("Από Τραπέζι :", " Από Τραπέζι :")
        'n2 = InputBox("Εως Τραπέζι : ", "Εως Τραπέζι :")

        'Dim DT As New DataTable
        'Dim Sql As String
        'If InStr(gCONNECT, "MDB") > 0 Then
        '    Sql = "UPDATE TABLES SET NUM1=" + u + " WHERE  VAL(ONO)  >=" + n1 + " AND VAL(ONO )<=" + n2
        'Else
        '    Sql = "UPDATE TABLES SET NUM1=" + u + " WHERE  CAST(ONO AS INT)  >=" + n1 + " AND CAST(ONO AS INT)<=" + n2
        'End If


        ' ExecuteSQLQuery(Sql, DT)

        ' If 1 = 1 Then
        ListView1.CheckBoxes = True
        ' ListView1.OwnerDraw = True
        ListView1.Items.Clear()

        ' ListView1.SmallImageList = ImgList 'Set the ListView`s SmallImageList to the ImgList
        Dim DTT2 As New DataTable
        ExecuteSQLQuery("SELECT ISNULL(NUM1,0) AS NUM1,ID,ONO FROM TABLES ", DTT2) 'where NUM1=0 OR NUM1=" + u
        'This code is just to add a few test items to the listview
        '  Dim dif() As String = {"Too Difficult", "Relatively Easy", "Extremely Easy", "Relatively Easy"}
        'Dim result() As String = Split(tPROSUETA.Text, ",")

        For x As Integer = 0 To DTT2.Rows.Count - 1

            Dim lvi As New ListViewItem(DTT2(x)("ONO").ToString)
            lvi.SubItems.Add(DTT2(x)("ID").ToString)
            If DTT2(x)("NUM1") = Val(TRAP) Then
                lvi.Checked = True
            Else
                lvi.Checked = False
            End If

            'lvi.SubItems.Add("Number")
            'lvi.SubItems.Add(dif(x))
            ' For K11 As Integer = 0 To result.Length - 1
            'If result(K11) = DTT2(x)("ID").ToString Then
            'lvi.Checked = True
            'End If
            ListView1.Items.Add(lvi)
        Next






        ' ListView1.Items.Add(lvi)
        ' Next
        ListView1.Columns(0).Width = 200
        ' End If




    End Sub





    Private Sub serv_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles serv.TextChanged
        If Len(serv.Text) = 0 Then
            Exit Sub
        End If
        Dim DT As New DataTable
        ExecuteSQLQuery("SELECT * FROM ERGAZ WHERE ID=" + serv.Text, DT)
        If DT.Rows.Count = 0 Then
            MsgBox("ΔΕΝ ΥΠΑΡΧΕΙ ΤΕΤΟΙΟΣ ΣΕΡΒΙΤΟΡΟΣ")
            ListView1.Items.Clear()
        Else
            SHOW_TRAPEZIA(serv.Text)
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim A As Integer
        A = ListBox1.SelectedIndex
        serv.Text = A
        Dim DT As New DataTable
        ExecuteSQLQuery("SELECT * FROM ERGAZ WHERE ID=" + serv.Text, DT)
        If DT.Rows.Count = 0 Then
            MsgBox("ΔΕΝ ΥΠΑΡΧΕΙ ΤΕΤΟΙΟΣ ΣΕΡΒΙΤΟΡΟΣ")
            ListView1.Items.Clear()
        Else
            SHOW_TRAPEZIA(serv.Text)
        End If





    End Sub

    
    Private Sub Button8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim SQLDT As New DataTable

        'προσθετα
        Dim S As String = ""
        For K As Integer = 0 To ListView1.Items.Count - 1
            If ListView1.Items(K).Checked = True Then
                'Dim LVI As ListViewItem(DTT2(x)("ONO").ToString
                '   ExecuteSQLQuery ("UPDATE TABLES SET NUM1=" + serv.Text + " WHERE  ONO  ='" +  + "'"            'Sql = "UPDATE TABLES SET NUM1=" + u + " WHERE  CAST(ONO AS INT)  >=" + n1 + " AND CAST(ONO AS INT)<=" + n2
                S = ListView1.Items(K).SubItems(0).Text
                ExecuteSQLQuery("UPDATE TABLES SET NUM1=" + serv.Text + " WHERE  ONO  ='" + S + "'", SQLDT)
            End If
        Next
        MsgBox("OK")
        ' PROSUETA.Items(K).SubItems(1).Text

        'Dim DT As New DataTable
        'Dim Sql As String
        'If InStr(gCONNECT, "MDB") > 0 Then
        '    Sql = "UPDATE TABLES SET NUM1=" + serv.Text + " WHERE  ONO  ='" + table.Text + "'"
        'Else

        '    Sql = "UPDATE TABLES SET NUM1=" + serv.Text + " WHERE  ONO  ='" + table.Text + "'"            'Sql = "UPDATE TABLES SET NUM1=" + u + " WHERE  CAST(ONO AS INT)  >=" + n1 + " AND CAST(ONO AS INT)<=" + n2
        'End If


        'ExecuteSQLQuery(Sql, DT)


    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()

    End Sub
End Class