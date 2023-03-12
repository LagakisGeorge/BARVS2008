Public Class BARDIAOLDPRINT

    Private Sub BARDIAOLDPRINT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DT As New DataTable
        ExecuteSQLQuery("SELECT TOP 100 ID,HME,IDERGAZ FROM BARDIA ORDER BY HME DESC", DT)
        ListBox1.Items.Add("ID ΒΑΡΔΙΑΣ ΗΜΕΡΟΜΗΝΙΑ ID ERGAZ")
        For K = 0 To DT.Rows.Count - 1
            ListBox1.Items.Add(Mid(DT(K)("ID").ToString + "      ", 1, 6) + ";" + Mid(DT(K)("HME").ToString + "             ", 1, 16) + " " + DT(K)("IDERGAZ").ToString)
        Next

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim C As String
        C = ListBox1.SelectedItem.ToString
        If CheckBox1.Checked Then
            bardiaSeOthoni(C.Split(";")(0))
        Else

            paragkentr.TYPONO_BARDIA(C.Split(";")(0))
        End If
    End Sub

    Sub bardiaSeOthoni(ByVal bardia As String)
        Dim DT2 As New DataTable
        ExecuteSQLQuery("select *,(SELECT EPO FROM ERGAZ WHERE ID=BARDIA.IDERGAZ) AS ONOMA FROM BARDIA WHERE ID=" + Str(Bardia), DT2)
        GeRGAZ = DT2(0)("ONOMA").ToString

        ListBox2.Items.Clear()

        ExecuteSQLQuery("select TRAPEZI,AJIA,ISNULL(CASH,0) AS CASH,ISNULL(PIS1,0) AS PIS1,ISNULL(PIS2,0) AS PIS2,ISNULL(KERA,0) AS KERA,TROPOS,CH1,CH2,ID FROM PARAGGMASTER WHERE IDBARDIA=" + Str(bardia) + " ORDER BY TROPOS,TRAPEZI,CH1", DT2)


        Dim m As String
        If DT2.Rows.Count > 0 Then
            m = DT2(0)("TROPOS").ToString
        Else
            m = ""
        End If
        Dim m2 As String = m

        Dim s As Single = 0
        ListBox2.Items.Add(GeRGAZ + "  //  " + Format(Now, "dd/MM/yyyy  hh:mm") + " " + Str(bardia))
        Dim s1, s2, s3, s4 As Single
        s1 = 0 : s2 = 0 : s3 = 0 : s4 = 0
        Dim k As Integer
        For k = 0 To DT2.Rows.Count - 1


            ListBox2.Items.Add(DT2(k)("TRAPEZI").ToString + " / " + Format(If(IsDBNull(DT2(k)("AJIA")), 0, DT2(k)("AJIA")), "###0.00") + " / " + DT2(k)("TROPOS").ToString + " /  " + DT2(k)("CH1").ToString + " /  " + DT2(k)("CH2").ToString + ";" + DT2(k)("ID").ToString + ";=>")

            ListBox2.Items.Add("Μετρ: " + DT2(k)("CASH").ToString + "Πιστ1: " + DT2(k)("pis1").ToString + "Πιστ2: " + DT2(k)("PIS2").ToString + "Κερασμ: " + DT2(k)("KERA").ToString)
            s1 = s1 + DT2(k)("CASH")
            s2 = s2 + DT2(k)("pis1")
            s3 = s3 + DT2(k)("PIS2")
            s4 = s4 + DT2(k)("KERA")
            ListBox2.Items.Add(" ")
        Next
        ListBox2.Items.Add("ΣΥΝΟΛΑ-----------------------")
        ListBox2.Items.Add("Μετρ: " + s1.ToString + "Πιστ1: " + s2.ToString + "Πιστ2: " + s3.ToString + "Κερασμ: " + s4.ToString)
        ListBox2.Items.Add("=====================")



    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox2.SelectedIndexChanged
        Dim C As String
        C = ListBox2.SelectedItem.ToString

        Dim IDPARAGG As String
        Try
            IDPARAGG = C.Split(";")(1)
        Catch ex As Exception
            Exit Sub
        End Try




        ListBox3.Items.Clear()

        Dim DT2 As New DataTable
        ExecuteSQLQuery("select ISNULL(ONO,'') AS ONO,ISNULL(POSO,0) AS POSO,ISNULL(TIMH,0) AS TIMH,ISNULL(POSO*TIMH,0) AS AXIA FROM PARAGG WHERE IDPARAGG=" + IDPARAGG, DT2)
        Dim S As Single = 0
        For k = 0 To DT2.Rows.Count - 1
            Dim poso, timh, axia As String
            poso = Microsoft.VisualBasic.Strings.Right(Space(7) + Format(DT2(k)("POSO"), "###0.00"), 7)
            timh = Microsoft.VisualBasic.Strings.Right(Space(7) + Format(DT2(k)("TIMH"), "###0.00"), 7)
            axia = Microsoft.VisualBasic.Strings.Right(Space(7) + Format(DT2(k)("AXIA"), "###0.00"), 7)
            Dim ono As String
            ono = Mid(DT2(k)("ONO").ToString + Space(25), 1, 20)

            ListBox3.Items.Add(ono + "  " + poso + "   " + timh + "   " + axia)
            S = S + DT2(k)("AXIA")
        Next
        ListBox3.Items.Add("--------------------")
        ListBox3.Items.Add("Σύνολο " + Format(S, "###0.00"))

    End Sub
End Class