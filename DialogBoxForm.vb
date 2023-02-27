Public Class DialogBoxForm
    Private _LoginName As String
    Private _LoginPassword As String

    Public Property LoginName() As String
        Get
            Return _LoginName
        End Get
        Set(ByVal value As String)
            _LoginName = value
        End Set
    End Property

    Public Property LoginPassword() As String
        Get
            Return _LoginPassword
        End Get
        Set(ByVal value As String)
            _LoginPassword = value
        End Set
    End Property


    Private Sub DialogBoxForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.AcceptButton = okButton
        Me.CancelButton = CancelButton
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.ShowInTaskbar = False
        Me.ShowIcon = False
        Me.StartPosition = FormStartPosition.CenterParent
    End Sub
    

    Private Sub okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' User clicked the OK button
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub


    Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        ' User clicked the Cancel button
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoginName = "1"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        LoginName = "4"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        LoginName = "3"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        LoginName = "2"
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class