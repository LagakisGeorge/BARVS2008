Public Class ARXEIA0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kathg.Click
        'arxeia.p_Table = "KATHG"
        'arxeia.ShowDialog()

        Dim F As New arxeia

        F.p_Table = "KATHG"
        F.ShowDialog()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eidh.Click

        Dim F As New arxeia

        F.p_Table = "EIDH"
        F.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prosueta.Click

        Dim F As New arxeia

        F.p_Table = "XAR1"
        F.ShowDialog()




    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trapezia.Click
        Dim F As New arxeia

        F.p_Table = "TABLES"
        F.ShowDialog()




    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles servitoros.Click
        Dim F As New arxeia

        F.p_Table = "ERGAZ"
        F.ShowDialog()

    End Sub

   

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim A As Integer
        Dim DT As New DataTable

        A = MsgBox("ΝΑ ΔΙΑΓΡΑΦΟΥΝ ΟΛΕΣ ΟΙ ΠΑΡΑΓΓΕΛΙΕΣ ΤΟΥ ΑΡΧΕΙΟΥ", MsgBoxStyle.YesNo)
        If A = vbYes Then
            Dim CCC As String = InputBox("ΔΩΣΕ KΩΔΙΚΟ ΔΙΕΥΘΥΝΤΗ ")


            ExecuteSQLQuery("DELETE FROM PARAGG", DT)
            ExecuteSQLQuery("DELETE FROM PARAGGMASTER", DT)
            ExecuteSQLQuery("UPDATE TABLES SET KATEILHMENO=0,IDPARAGG=0", DT)

        End If
    End Sub

   

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()

    End Sub

    Private Sub ARXEIA0_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ListView1.Visible = False
        '  Panel1.Visible = False
        '  kathg.Visible = True
        ' eidh.Visible = True
        ' Button7.Visible = True


    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'conn = New SqlConnection(cnString)
        ''Try
        '' Open connection
        'conn.Open()

        'da = New SqlDataAdapter(SQLqry, conn)

        ''create command builder
        'Dim cb As SqlCommandBuilder = New SqlCommandBuilder(da)
        'ds.Clear()
        ''fill dataset
        'da.Fill(ds, "PEL")
        'GridView1.ClearSelection()
        'GridView1.DataSource = ds
        'GridView1.DataMember = "PEL"
    End Sub

    
    Private Sub trapezia_servitoros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trapezia_servitoros.Click
        Dim F As New TRAPEZIAANASERVITORO

        'F.p_Table = "ERGAZ"
        F.ShowDialog()

    End Sub
End Class



