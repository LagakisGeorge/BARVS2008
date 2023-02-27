Public Class Form3

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        If frUpdate = True Then
            Dim pelKOD As String = Split(Form2.GroupBox1.Text, ";")(0)

            If Val(KauTimh.Text) = 0 Then
                KauTimh.Text = "0"
            End If


            If Len(Trim(TIMH.Text)) = 0 Then
                TIMH.Text = "0"
            End If
            If Val(apoth.Text) = 0 Then
                apoth.Text = "0"
            End If

            If Val(fpa.Text) = 0 Then
                fpa.Text = 24
            End If

            If Val(POSOTHTA.Text) + Val(Tem.Text) = 0 Then
                MsgBox("ΔΕΝ ΒΑΛΑΤΕ ΠΟΣΟΤΗΤΑ")
                Exit Sub
            End If
            Dim mEKPT As String = ekpt.Text
            If Val(mEKPT) = 0 Then
                mEKPT = "0"
            End If

            Dim msyskeyasia As String
            If Val(SYSKEYASIA.Text) = 0 Then
                msyskeyasia = "1"
            Else
                msyskeyasia = SYSKEYASIA.Text
            End If

            Dim mposo As String

            If Val(Tem.Text) > 0 Then
                mposo = Str(Val(Me.POSOTHTA.Text) + Val(Tem.Text) / Val(msyskeyasia))

            Else
                mposo = Me.POSOTHTA.Text
            End If

            mposo = Replace(mposo, ",", ".")


            Dim CC As String = "Insert into EGGTIM (HME,ATIM,ID_NUM,KODE,ONOMA,POSO,TIMM,KAU_AJIA,PELKOD,MONA,FPA,KOLA,EKPT,PROELEYSH,PROOD,KERDOS) values('" + Format(Now, "dd/MM/yyyy") + "','" & _
                         gAtim & "'," & _
                          Str(gID_NUM) & ",'" & _
                        Me.TextBox1.Text & "','" & _
                        Replace(Me.PERIGRAFH.Text, "'", "`") & "'," & _
                        Replace(mposo, ",", ".") & "," & _
                        Replace(Me.TIMH.Text, ",", ".") & "," & _
                       Replace(Me.AXIA.Text, ",", ".") & "," & _
                       "'" + pelKOD + "','" + Label7.Text + "'," + fpa.Text + "," + apoth.Text + "," + mEKPT + ",'" + Form2.sxolia.Text + "'," + Replace(KauTimh.Text, ",", ".") + "," + msyskeyasia + ")"

            IsConnected(CC, True)


            'ΕΛΕΓΧΟΣ ΕΓΓΥΟΔΟΣΙΑΣ=====================================================================
            'PROOD = ΕΦΚ POY PREPEI NA AFAIREITAI STHN EJAGVGH SE ASCII

            If gBaran = 93 Then ' MIXAILIDIS
                IsConnected("Select KODSYNOD from EID WHERE KOD='" + Me.TextBox1.Text + "'", False)

                If myDR.Read = True Then
                    If IsDBNull(myDR.GetValue(0).ToString) Then
                    Else
                        Dim GG As String = myDR.GetValue(0).ToString
                        IsConnected("Select LTI,ONO from EID WHERE KOD='" + GG + "'", False)

                        If myDR.Read = True Then
                            Dim FGF As String = myDR.GetValue(0).ToString
                            Dim axkenon As String = Replace(Str(myDR.GetValue(0) * Val(POSOTHTA.Text)), ",", ".")

                            CC = "Insert into EGGTIM (HME,ATIM,ID_NUM,KODE,ONOMA,POSO,TIMM,KAU_AJIA,PELKOD,MONA,FPA,KOLA,PROOD) values('" + Format(Now, "dd/MM/yyyy") + "','" & _
                                 gAtim & "'," & _
                                  Str(gID_NUM) & ",'" & _
                                GG & "','" & _
                                myDR.GetValue(1).ToString & "'," & _
                                Replace(mposo, ",", ".") & "," & _
                                Replace(FGF, ",", ".") & "," & _
                               axkenon & "," & _
                               "'" + pelKOD + "','" + Label7.Text + "',1000," + apoth.Text + "," + Replace(KauTimh.Text, ",", ".") + ")"

                            IsConnected(CC, True)
                        End If


                    End If
                Else
                    ' Me.TextID.Text = 1
                End If
            End If





            Form2.LOAD_EGGTIM()
            Me.Close()

        Else

            MsgBox("Successfully updated!", MsgBoxStyle.Information, "Information")

        End If

    End Sub


    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frUpdate = False
        Me.Dispose()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err
        ' Call LoadID()
        If gBaran = 93 Then
            Label4.Text = "Κιβώτια"
        Else
            Label4.Text = "Ποσότητα"
        End If





        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub
    Private Sub LoadID()
        If frUpdate = False Then

            TextBox1.Text = ""
            PERIGRAFH.Text = ""
            TIMH.Text = ""
            AXIA.Text = ""

            'IsConnected("Select count(ID) from tblpersonal", False)

            'If myDR.Read = True Then
            '    Me.TextID.Text = myDR.GetValue(0) + 1
            'Else
            '    Me.TextID.Text = 1
            'End If
            POSOTHTA.Focus()
        End If
    End Sub

    Private Sub TextBox4_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSOTHTA.GotFocus
        olaLeyka()
        POSOTHTA.BackColor = Color.Yellow
        'TIMH.BackColor = Color.White
        'apoth.BackColor = Color.White
        'ekpt.BackColor = Color.White
        POSOTHTA.Select(0, POSOTHTA.Text.Length)
    End Sub

    

    'Private Sub POSOTHTAss()
    'End Sub
    Sub CALC_AXIA()


        Dim msyskeyasia As Single
        If Val(SYSKEYASIA.Text) = 0 Then
            msyskeyasia = "1"
        Else
            msyskeyasia = SYSKEYASIA.Text
        End If


        Dim mp As Single = Val(Me.POSOTHTA.Text) + Val(Tem.Text) / Val(msyskeyasia)
        Dim mt As Single = Val(Replace(TIMH.Text, ",", "."))
        'Dim mp As Single = Val(Replace(POSOTHTA.Text, ",", "."))
        Dim mefk As Single = Val(Replace(efk.Text, ",", "."))
        Dim mEKPT As Single = Val(Replace(ekpt.Text, ",", "."))
        AXIA.Text = Math.Round((mt * mp) - ((mt - Val(SYSKEYASIA.Text) * mefk) * mp) * (mEKPT) / 100, 2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim proc As New System.Diagnostics.Process()

        ' proc = Process.Start("c:\mercvb\tabtip.exe", "")

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B7.Click
        TYPOSE("7")
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles B6.Click
        TYPOSE("6")
    End Sub

    Sub TYPOSE(ByVal D As String)

        Dim F As String
        F = ""
        If POSOTHTA.BackColor = Color.Yellow Then
            F = POSOTHTA.Text
        End If
        If TIMH.BackColor = Color.Yellow Then
            F = TIMH.Text
        End If
        If apoth.BackColor = Color.Yellow Then
            F = apoth.Text
        End If

        If ekpt.BackColor = Color.Yellow Then
            F = ekpt.Text
        End If

        If Tem.BackColor = Color.Yellow Then
            F = Tem.Text
        End If





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


        If POSOTHTA.BackColor = Color.Yellow Then
            POSOTHTA.Text = F
        End If
        If TIMH.BackColor = Color.Yellow Then
            TIMH.Text = F
        End If
        If apoth.BackColor = Color.Yellow Then
            apoth.Text = F
        End If
        If ekpt.BackColor = Color.Yellow Then
            ekpt.Text = F
        End If

        If Tem.BackColor = Color.Yellow Then
            Tem.Text = F
        End If



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

    Private Sub TextBox3_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIMH.GotFocus

        olaLeyka()
        TIMH.BackColor = Color.Yellow
        'POSOTHTA.BackColor = Color.White
        'ekpt.BackColor = Color.White
        'apoth.BackColor = Color.White
        'Tem.BackColor = Color.White
        TIMH.Select(0, TIMH.Text.Length)
    End Sub

    Private Sub TextBox3_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TIMH.LostFocus
        ' TIMH.BackColor = Color.White
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TIMH.TextChanged
        'AXIA.Text = Val(Replace(TIMH.Text, ",", ".")) * Val(Replace(POSOTHTA.Text, ",", "."))
        CALC_AXIA()

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        TYPOSE("<")
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TYPOSE(".")
    End Sub

    Private Sub apoth_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles apoth.GotFocus
        olaLeyka()
        apoth.BackColor = Color.Yellow
        'POSOTHTA.BackColor = Color.White

        'ekpt.BackColor = Color.White
        apoth.Select(0, apoth.Text.Length)
    End Sub

    Private Sub apoth_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles apoth.LostFocus
        ' apoth.BackColor = Color.White
    End Sub

    Private Sub apoth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles apoth.TextChanged

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ekpt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ekpt.GotFocus
        olaLeyka()
        ekpt.BackColor = Color.Yellow
        'POSOTHTA.BackColor = Color.White
        'apoth.BackColor = Color.White
        'TIMH.BackColor = Color.White
        ekpt.Select(0, ekpt.Text.Length)




    End Sub

    Private Sub ekpt_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ekpt.LostFocus
        '  ekpt.BackColor = Color.White
    End Sub


    Private Sub ekpt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ekpt.TextChanged
        CALC_AXIA()
    End Sub

    Private Sub POSOTHTA_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles POSOTHTA.LostFocus
        '  POSOTHTA.BackColor = Color.White
    End Sub

    Private Sub POSOTHTA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSOTHTA.TextChanged
        CALC_AXIA()

    End Sub

    Private Sub Tem_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tem.GotFocus

        'an den exei syskeyasia na mhn mpainei sta temaxia
        If Val(SYSKEYASIA.Text) = 0 Then
        Else
            olaLeyka()
            Tem.BackColor = Color.Yellow
            Tem.Select(0, Tem.Text.Length)
        End If

    End Sub

    Private Sub Tem_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tem.LostFocus
        ' Tem.BackColor = Color.White
    End Sub

    Private Sub Tem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tem.TextChanged
        CALC_AXIA()
    End Sub

    Sub olaLeyka()
        ekpt.BackColor = Color.White
        POSOTHTA.BackColor = Color.White
        apoth.BackColor = Color.White
        TIMH.BackColor = Color.White
        Tem.BackColor = Color.White
    End Sub


End Class