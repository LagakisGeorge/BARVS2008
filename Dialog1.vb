Imports System.Windows.Forms

Public Class Dialog1



    Private m_IDPARAGG As String
    Public Property p_IDPARAGG() As Long
        Get
            Return m_IDPARAGG
        End Get
        Set(ByVal Value As Long)
            ' If Value < 1 Or Value > 12 Then
            ' Error processing for invalid value. 
            'Else
            m_IDPARAGG = Value
            'End If
        End Set
    End Property

    Private m_AXIA As String
    Public Property p_AXIA() As String
        Get
            Return m_AXIA
        End Get
        Set(ByVal Value As String)
            ' If Value < 1 Or Value > 12 Then
            ' Error processing for invalid value. 
            'Else
            m_AXIA = Value
            'End If
        End Set
    End Property








    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASH.Click
        CHECK(1)
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        CHECK(5)
    End Sub
    Sub CHECK(ByVal I As Integer)

        'Dim DT As New DataTable
        'ExecuteSQLQuery("SELECT  ISNULL(ENERGOS,0) AS TYP FROM PARAGG WHERE   ID=" + Str(p_IDPARAGG), DT)

        If I = 5 Then 'AKYRON   DIAGRAFH  DEN MPOROYN NA DIAGRAFOYN GIATI EINAI TYPOMENA
            Me.Close()
            'If DT(0)(0) = "1" Then
            '    MsgBox("αδυνατη η διαγραφή. ΕΙΝΑΙ ΤΥΠΩΜΕΝΟ", MsgBoxStyle.OkOnly)
            '    Me.Close()
            'End If
        End If

        Dim CC As String = Me.Text
        Dim CC1 As String = ""
        CC1 = CC.Split(";")(1)   ' ID PARAGG
        Dim ITEMINDEX As String = CC.Split(";")(2) ' Str(HDH_YPARXOYSA.SelectedItems(0).Index)
        Dim DT2 As New DataTable
        ExecuteSQLQuery("UPDATE  PARAGG SET ONO='**" + LTrim(Str(I)) + "-'+ONO , NUM1=" + LTrim(Str(I)) + " WHERE ID=" + CC1, DT2)


        If I = 1 Then
            ExecuteSQLQuery("UPDATE  PARAGGMASTER SET CASH=ISNULL(CASH,0)+" + p_AXIA + " WHERE ID=" + Str(p_IDPARAGG), DT2)
        ElseIf I = 2 Then
            ExecuteSQLQuery("UPDATE  PARAGGMASTER SET PIS1=ISNULL(PIS1,0)+" + p_AXIA + " WHERE ID=" + Str(p_IDPARAGG), DT2)
        ElseIf I = 3 Then
            ExecuteSQLQuery("UPDATE  PARAGGMASTER SET PIS2=ISNULL(PIS2,0)+" + p_AXIA + " WHERE ID=" + Str(p_IDPARAGG), DT2)
        ElseIf I = 4 Then
            ExecuteSQLQuery("UPDATE  PARAGGMASTER SET KERA=ISNULL(KERA,0)+" + p_AXIA + " WHERE ID=" + Str(p_IDPARAGG), DT2)
        End If

        ADDITPARAGG.HDH_YPARXOYSA.SelectedItems(0).Text = "**" + LTrim(Str(I)) + "-" + ADDITPARAGG.HDH_YPARXOYSA.SelectedItems(0).Text

        Me.Close()
      















    End Sub

    Private Sub PIS1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIS1.Click
        CHECK(2)
    End Sub

    Private Sub PIS2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PIS2.Click
        CHECK(3)
    End Sub

    Private Sub KERA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KERA.Click
        CHECK(4)
    End Sub
End Class
