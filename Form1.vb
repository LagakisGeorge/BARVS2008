Public Class Form1
    Dim vrfy As Boolean
    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If vrfy = False Then
            End
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        PB.Value = PB.Value + 20
        lblper.Text = PB.Value & "%"
        If PB.Value = 100 Then
            Timer1.Enabled = False
            vrfy = True
            'Form2.NEOEIDOS.Text = "Logout"
            Me.Dispose()
        End If
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ''MsgBox(System.Reflection.Assembly.GetExecutingAssembly.Location())

        'Call IsConnected("Select * from tbllogin where Username='" & Me.TextBox1.Text & "' and Password='" & Me.TextBox2.Text & "'", False)

        'If myDR.Read = True Then
        '    Timer1.Enabled = True
        '    PB.Visible = True
        '    lblper.Visible = True
        'Else
        '    MsgBox("Access denied!", MsgBoxStyle.Critical, "Error")
        '    TextBox1.Text = ""
        '    TextBox2.Text = ""
        '    TextBox1.Focus()
        'End If

    End Sub
End Class
