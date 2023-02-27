Public Class Form3

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Dispose()
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        If frUpdate = True Then
            IsConnected("Insert into EGGTIM (HME,ATIM,ID_NUM,KODE,ONOMA,POSO,TIMM,KAU_AJIA) values('" + Format(Now, "dd/MM/yyyy") + "','" & _
                         gAtim & "'," & _
                          Str(gID_NUM) & ",'" & _
                        Me.TextBox1.Text & "','" & _
                        Me.TextBox2.Text & "'," & _
                        Replace(Me.TextBox3.Text, ",", ".") & "," & _
                        Replace(Me.TextBox4.Text, ",", ".") & "," & _
                       Replace(Me.TextBox5.Text, ",", ".") & ")", True)

            ' MsgBox("Successfully saved!", MsgBoxStyle.Information, "Information")
            Call LoadID()
            Form2.LOAD_EGGTIM()
            Me.Close()

        Else


            'IsConnected("Update tblPersonal set Firstname='" & Me.TextBox1.Text & _
            '            "',Middlename='" & Me.TextBox2.Text & _
            '            "',Lastname='" & Me.TextBox3.Text & _
            '            "',Date_of_birth='" & Me.DateTimePicker1.Value & _
            '            "',Address='" & Me.TextBox5.Text & "' where ID='" & Me.TextID.Text & "'", True)

            MsgBox("Successfully updated!", MsgBoxStyle.Information, "Information")

        End If

    End Sub


    Private Sub Form3_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frUpdate = False
        Me.Dispose()
    End Sub

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err
        Call LoadID()
        Exit Sub
err:
        MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
    End Sub
    Private Sub LoadID()
        If frUpdate = False Then

            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox5.Text = ""

            IsConnected("Select count(ID) from tblpersonal", False)

            If myDR.Read = True Then
                Me.TextID.Text = myDR.GetValue(0) + 1
            Else
                Me.TextID.Text = 1
            End If
            TextBox4.Focus()
        End If
    End Sub

    Private Sub TextBox4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox4.TextChanged

        TextBox5.Text = Val(Replace(TextBox3.Text, ",", ".")) * Val(Replace(TextBox4.Text, ",", "."))







    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim proc As New System.Diagnostics.Process()

        proc = Process.Start("c:\mercvb\tabtip.exe", "")

    End Sub
End Class