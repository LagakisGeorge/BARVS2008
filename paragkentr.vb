
Imports Microsoft.VisualBasic.PowerPacks.Printing.Compatibility.VB6
Imports System.IO

Public Class paragkentr
    Dim vv As New Printer


    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Dispose()
    End Sub



    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frUpdate = False
        Me.Dispose()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err
        Dim m_mess_pel As String
        Dim m_user As String
        gIsAdmin = 0
        Me.Show()

        Using sr As StreamReader = New StreamReader("config.ini", System.Text.Encoding.Default)
            'line = sr.ReadLine()
            m_mess_pel = sr.ReadLine()
            m_user = sr.ReadLine()
            gPass = sr.ReadLine()
            'f_mess_eid = sr.ReadLine()
            'F_PLATH_PEL = sr.ReadLine()
            'F_PLATH_EID = sr.ReadLine()

            ''εδω εχω τις ιδιαιτερότητες του πελάτη
            'line2 = sr.ReadLine()   ' 6Η  SEIRA
            'lineexcel = sr.ReadLine

        End Using


        'ConString = "Server=HPPC\SQL12;Database=MERCURY;UID=sa;pwd=12345678;"
        gCONNECT = m_mess_pel   ' "Server=" + Split(line, ";")(0) + ";Database=" + Split(line, ";")(1) + ";uid=" + Split(line, ";")(2) + ";pwd=" + Split(line, ";")(3) + ";"
        gUser = Val(m_user)


        Me.Text = "Σερβιτόρος : " + m_user





        CHECK_BARDIA()


        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub

    Sub CHECK_BARDIA()
        Dim DT As New DataTable
        ExecuteSQLQuery("SELECT MAX(ID) FROM BARDIA where NUM1=" + Str(gUser), DT)

        Dim MDATE As String
        If InStr(gCONNECT, "MDB") > 0 Then
            MDATE = "#" + Format(Now, "dd/MM/yyyy") + "#"
        Else
            MDATE = "'" + Format(Now, "MM/dd/yyyy") + "'"
        End If


        Dim DT2 As New DataTable



        If DT.Rows.Count = 0 Or IsDBNull(DT(0)(0)) Then
            ExecuteSQLQuery("INSERT INTO BARDIA (OPENH,ISOPEN,HME,IDERGAZ,NUM1) VALUES ('" + Format(Now, "hh:mm") + "',0," + MDATE + "," + Str(0) + "," + Str(gUser) + ")", DT2)
            End
        Else
            Dim N As Long = DT(0)(0)
            ExecuteSQLQuery("SELECT * FROM BARDIA WHERE ID= " + Str(N), DT)
            If DT(0)("ISOPEN") = 1 Then
                gBardia = N
                MHNYMA.Text = "ΒΑΡΔΙΑ ΑΝΟΙΧΤΗ ΑΠΟ " + DT(0)("OPENH").ToString
                bardia.Text = "ΚΛΕΙΣΙΜΟ ΒΑΡΔΙΑΣ"
                bNeaParaggelia.Enabled = True
                MHNYMA.BackColor = Color.Green

            Else
                MHNYMA.Text = "ΑΝΟΙΞΤΕ ΒΑΡΔΙΑ  "
                bardia.Text = "ΑΝΟΙΓΜΑ ΒΑΡΔΙΑΣ"
                bNeaParaggelia.Enabled = False

                MHNYMA.BackColor = Color.Red
                gBardia = 0
            End If
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proc As New System.Diagnostics.Process()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B7.Click
        TYPOSE("7")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B6.Click
        TYPOSE("6")
    End Sub

    Sub TYPOSE(ByVal D As String)

        Dim F As String
        F = OTONH.Text





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


        OTONH.Text = F

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

    Private Sub B8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B8.Click
        TYPOSE("8")
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


    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' TIMH.BackColor = Color.White
    End Sub


    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TYPOSE("<")
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TYPOSE(".")
    End Sub


    Private Sub apoth_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' apoth.BackColor = Color.White
    End Sub

    Private Sub apoth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub


    Private Sub ekpt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '  ekpt.BackColor = Color.White
    End Sub



    Private Sub POSOTHTA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        '  POSOTHTA.BackColor = Color.White
    End Sub



    Private Sub Tem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Tem.BackColor = Color.White
    End Sub




    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bNeaParaggelia.Click
        ' NEAPARAGG.ShowDialog()
        Dim F As New tables
        F.MdiParent = MDIParent1

        F.Show()
        F = Nothing


    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form4.Show()

    End Sub

    Private Sub arxeio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles arxeio.Click
        ARXEIA0.MdiParent = MDIParent1

        ARXEIA0.Show()

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bardia.Click
        ' On Error GoTo err
        'Dim DT As New DataTable
        'ExecuteSQLQuery("SELECT MAX(ID) FROM BARDIA", DT)
        'If DT.Rows.Count = 0 Then

        'Else
        '    Dim N As Long = DT(0)(0)
        '    ExecuteSQLQuery("SELECT * FROM BARDIA WHERE ID= " + Str(N), DT)
        '    If DT(0)("ISOPEN") = 1 Then
        '        gBardia = N
        '        MHNYMA.Text = "ΒΑΡΔΙΑ ΑΝΟΙΧΤΗ ΑΠΟ " + DT(0)("OPENH").ToString
        '    Else
        '        gBardia = 0
        '        MHNYMA.Text = "ΑΝΟΙΞΤΕ ΒΑΡΔΙΑ  "
        '        MHNYMA.BackColor = Color.Red
        '    End If
        'End If
        If gBardia = 0 Then
            BARDIES.MdiParent = MDIParent1
            BARDIES.Show()



        Else
            Dim DT As New DataTable
            ExecuteSQLQuery("SELECT Sum(isnull(CASH,0)) AS CASH ,  Sum(isnull(PIS1,0)) AS PIS1 , Sum(isnull(PIS2,0)) AS PIS2 ,  Sum(isnull(KERA,0)) AS KERA  FROM PARAGGMASTER WHERE  IDBARDIA=" + Str(gBardia), DT)
            Dim MM As String = ""
            Dim CASH(5) As String
            Dim CASHTOT As Single = 0
            MsgBox("Μετρ: " + DT(0)("CASH").ToString + "Πιστ1: " + DT(0)("pis1").ToString + "Πιστ2: " + DT(0)("PIS2").ToString + "Κερασμ: " + DT(0)("KERA").ToString)

            'For K As Integer = 0 To DT.Rows.Count - 1
            '    If IsDBNull(DT(K)(0)) Or IsDBNull(DT(K)(1)) Then
            '    Else
            '        Dim tropos As String = ""
            '        If DT(K)(1) = 1 Then
            '            tropos = "μετρητα"
            '        End If
            '        If DT(K)(1) = 2 Then
            '            tropos = "Καρτα 1"
            '        End If
            '        If DT(K)(1) = 3 Then
            '            tropos = "Καρτα 2"
            '        End If
            '        If DT(K)(1) = 4 Then
            '            tropos = "Κερασμενα "
            '        End If



            '        MM = MM + tropos + " => " + Format(DT(K)(0), "####0.00") + Chr(13)
            '        If DT(K)(1) < 5 Then
            '            CASH(DT(K)(1)) = DT(K)(0).ToString
            '            CASHTOT = CASHTOT + DT(K)(0)
            '        End If
            '    End If

            'Next

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
                TYPONO_BARDIA(gBardia)
                'Dim DT2 As New DataTable
                '    ExecuteSQLQuery("select *,(SELECT EPO FROM ERGAZ WHERE ID=BARDIA.IDERGAZ) AS ONOMA FROM BARDIA WHERE ID=" + Str(gBardia), DT2)
                '    GeRGAZ = DT2(0)("ONOMA").ToString



                '    ExecuteSQLQuery("select TRAPEZI,AJIA,CASH,PIS1,PIS2,KERA,TROPOS,CH1,CH2 FROM PARAGGMASTER WHERE IDBARDIA=" + Str(gBardia) + " ORDER BY TROPOS,TRAPEZI,CH1", DT2)

                '    vv.FontSize = 10
                '    vv.FontBold = True
                '    Dim m As String
                '    If DT2.Rows.Count > 0 Then
                '        m = DT2(0)("TROPOS").ToString
                '    Else
                '        m = ""
                '    End If
                '    Dim m2 As String = m

                '    Dim s As Single = 0
                '    vv.Print(GeRGAZ + "  //  " + Format(Now, "dd/MM/yyyy  hh:mm"))

                '    For K = 0 To DT2.Rows.Count - 1
                '        '    m = DT2(K)("TROPOS").ToString

                '        '    If m = m2 Then
                '        '        s = s + If(IsDBNull(DT2(K)("AJIA")), 0, DT2(K)("AJIA"))
                '        '    Else


                '        '        Dim tropos2 As String = ""
                '        '        If m2 = "1" Then
                '        '            tropos2 = "μετρητα"
                '        '        End If
                '        '        If m2 = "2" Then
                '        '            tropos2 = "Καρτα 1"
                '        '        End If
                '        '        If m2 = "3" Then
                '        '            tropos2 = "Καρτα 2"
                '        '        End If
                '        '        If m2 = "4" Then
                '        '            tropos2 = "Κερασμενα "
                '        '        End If



                '        '        vv.Print("=====================")
                '        '        vv.Print("Σύνολο " + m2 + " ....." + Format(s, "###0.00"))
                '        '        vv.Print("Σύνολο " + tropos2 + " ....." + Format(s, "###0.00"))
                '        '        s = 0
                '        '        s = s + If(IsDBNull(DT2(K)("AJIA")), 0, DT2(K)("AJIA"))
                '        '        m2 = m
                '        '    End If

                '        vv.Print(DT2(K)("TRAPEZI").ToString + " / " + Format(If(IsDBNull(DT2(K)("AJIA")), 0, DT2(K)("AJIA")), "###0.00") + " / " + DT2(K)("TROPOS").ToString + " /  " + DT2(K)("CH1").ToString + " /  " + DT2(K)("CH2").ToString)
                '        vv.Print("Μετρ: " + DT2(0)("CASH").ToString + "Πιστ1: " + DT2(0)("pis1").ToString + "Πιστ2: " + DT2(0)("PIS2").ToString + "Κερασμ: " + DT2(0)("KERA").ToString)



                '    Next
                '    vv.Print("ΣΥΝΟΛΑ-----------------------")
                '    vv.Print("Μετρ: " + DT2(0)("CASH").ToString + "Πιστ1: " + DT2(0)("pis1").ToString + "Πιστ2: " + DT2(0)("PIS2").ToString + "Κερασμ: " + DT2(0)("KERA").ToString)
                '    vv.Print("=====================")




                '    vv.Print(".")
                '    vv.Print(".")
                '    vv.Print("")
                '    vv.Print("")
                '    vv.Print("")

                '    vv.Print(".")
                '    vv.Print("")
                '    vv.Print("")
                '    vv.Print("")
                '    vv.Print("")

                '    vv.EndDoc()

                '    ' Exit Sub



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
        CHECK_BARDIA()


    End Sub

    Public Sub TYPONO_BARDIA(ByVal Bardia)
        Dim DT2 As New DataTable
        ExecuteSQLQuery("select *,(SELECT EPO FROM ERGAZ WHERE ID=BARDIA.IDERGAZ) AS ONOMA FROM BARDIA WHERE ID=" + Str(Bardia), DT2)
        GeRGAZ = DT2(0)("ONOMA").ToString



        ExecuteSQLQuery("select TRAPEZI,AJIA,ISNULL(CASH,0) AS CASH,ISNULL(PIS1,0) AS PIS1,ISNULL(PIS2,0) AS PIS2,ISNULL(KERA,0) AS KERA,TROPOS,CH1,CH2 FROM PARAGGMASTER WHERE IDBARDIA=" + Str(Bardia) + " ORDER BY TROPOS,TRAPEZI,CH1", DT2)

        vv.FontSize = 10
        vv.FontBold = True
        Dim m As String
        If DT2.Rows.Count > 0 Then
            m = DT2(0)("TROPOS").ToString
        Else
            m = ""
        End If
        Dim m2 As String = m

        Dim s As Single = 0
        vv.Print(GeRGAZ + "  //  " + Format(Now, "dd/MM/yyyy  hh:mm") + " " + Str(Bardia))
        Dim s1, s2, s3, s4 As Single
        s1 = 0 : s2 = 0 : s3 = 0 : s4 = 0
        Dim k As Integer
        For k = 0 To DT2.Rows.Count - 1


            vv.Print(DT2(k)("TRAPEZI").ToString + " / " + Format(If(IsDBNull(DT2(k)("AJIA")), 0, DT2(k)("AJIA")), "###0.00") + " / " + DT2(k)("TROPOS").ToString + " /  " + DT2(k)("CH1").ToString + " /  " + DT2(k)("CH2").ToString)
            vv.Print("Μετρ: " + DT2(k)("CASH").ToString + "Πιστ1: " + DT2(k)("pis1").ToString + "Πιστ2: " + DT2(k)("PIS2").ToString + "Κερασμ: " + DT2(k)("KERA").ToString)
            s1 = s1 + DT2(k)("CASH")
            s2 = s2 + DT2(k)("pis1")
            s3 = s3 + DT2(k)("PIS2")
            s4 = s4 + DT2(k)("KERA")


        Next
        vv.Print("ΣΥΝΟΛΑ-----------------------")
        vv.Print("Μετρ: " + s1.ToString + "Πιστ1: " + s2.ToString + "Πιστ2: " + s3.ToString + "Κερασμ: " + s4.ToString)
        vv.Print("=====================")




        vv.Print(".")
        vv.Print(".")
        vv.Print("")
        vv.Print("")
        vv.Print("")

        vv.Print(".")
        vv.Print("")
        vv.Print("")
        vv.Print("")
        vv.Print("")

        vv.EndDoc()

        ' Exit Sub


    End Sub







    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        BARDIAOLDPRINT.MdiParent = MDIParent1

        BARDIAOLDPRINT.Show()
    End Sub

    Private Sub MHNYMA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MHNYMA.Click

    End Sub
End Class