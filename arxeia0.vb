Public Class ARXEIA0
    'Dim test As New CustomForm("workflow")

    

    'Private Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
    '    MsgBox(test.GrantAccess)
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles kathg.Click
        'arxeia.p_Table = "KATHG"
        'arxeia.ShowDialog()

        Dim F As New arxeia

        F.p_Table = "KATHG"
        F.Show()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eidh.Click

        Dim F As New arxeia

        F.p_Table = "EIDH"
        F.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles prosueta.Click

        Dim F As New arxeia

        F.p_Table = "XAR1"
        F.Show()




    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trapezia.Click
        Dim F As New arxeia

        F.p_Table = "TABLES"
        F.Show()




    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles servitoros.Click
        Dim F As New arxeia

        F.p_Table = "ERGAZ"
        F.Show()

    End Sub



    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim A As Integer
        Dim DT As New DataTable

        A = MsgBox("ΝΑ ΔΙΑΓΡΑΦΟΥΝ ΟΛΕΣ ΟΙ ΠΑΡΑΓΓΕΛΙΕΣ ΤΟΥ ΑΡΧΕΙΟΥ", MsgBoxStyle.YesNo)
        If A = vbYes Then
            Dim CCC As String = InputBox("ΔΩΣΕ KΩΔΙΚΟ ΔΙΕΥΘΥΝΤΗ ")

            If CCC = "3921" Then
                ExecuteSQLQuery("DELETE FROM PARAGG", DT)
                ExecuteSQLQuery("DELETE FROM PARAGGMASTER", DT)
                ExecuteSQLQuery("UPDATE TABLES SET KATEILHMENO=0,IDPARAGG=0", DT)
            End If


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

    

    Private Sub trapezia_servitoros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trapezia_servitoros.Click
        Dim F As New TRAPEZIAANASERVITORO

        'F.p_Table = "ERGAZ"
        F.Show()

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim CCC As String = InputBox("ΔΩΣΕ KΩΔΙΚΟ ΔΙΕΥΘΥΝΤΗ ")

        If CCC = "3921" Then
            gIsAdmin = 1
            Dim CC1 As String = InputBox("ΔΩΣΕ αριθμο σερβιτόρου ")
            gUser = Val(CC1)


        End If
    End Sub
End Class



