Public Class ARXEIA0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'arxeia.p_Table = "KATHG"
        'arxeia.ShowDialog()

        Dim F As New arxeia

        F.p_Table = "KATHG"
        F.ShowDialog()



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim F As New arxeia

        F.p_Table = "EIDH"
        F.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        Dim F As New arxeia

        F.p_Table = "XAR1"
        F.ShowDialog()


       

    End Sub
End Class