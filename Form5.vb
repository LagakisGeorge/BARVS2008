Imports System.IO

Public Class Form5

    Private Sub Form3_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'SET LISTVIEW PROPERTIES
        ListView1.View = View.Details
        ListView1.FullRowSelect = True

        'CONSTRUCT COLUMNS
        ListView1.Columns.Add("Name", 250)






        Me.ListView2.HideSelection = True
        Me.ListView2.MultiSelect = False
        'Dim M As New ListViewItem
        'Dim DD(3) As String



        ListView2.Items.Add("Michael carrick", 0)
        ListView2.Items.Add("Michael2 carrick", 0)

    End Sub


    'Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Me.ListView2.HideSelection = True
    '    Me.ListView2.MultiSelect = False
    'End Sub

    Private Sub ListView2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListView2.MouseDown
        Dim lvi As ListViewItem = Me.ListView2.GetItemAt(e.X, e.Y)
        If Not lvi Is Nothing Then
            lvi.Checked = Not lvi.Checked
            If lvi.Checked Then
                lvi.BackColor = Color.Blue : lvi.ForeColor = Color.White
            Else
                lvi.BackColor = Color.White : lvi.ForeColor = Color.Black
            End If

        End If
    End Sub






    Private Sub populate()
        Dim imgs As ImageList = New ImageList()
        imgs.ImageSize = New Size(100, 100)

        'our files img
        Dim files As String() = New String() {}
        files = Directory.GetFiles("C:/Camera/ΦΑΓΗΤΑ")


        Dim fileNAME(300) As String


        Dim N As Integer = 0

        Try
            For Each f In files
                imgs.Images.Add(Image.FromFile(f))


                fileNAME(N) = f.ToString()
                N = N + 1
            Next

        Catch ex As Exception

        End Try

        ListView1.SmallImageList = imgs
        For K As Integer = 0 To N - 1
            ListView1.Items.Add(fileNAME(K), K)
        Next

        Exit SUB


        ListView1.Items.Add("Michael carrick", 0)
        ListView1.Items.Add("Diego Costa", 1)

        ListView1.Items.Add("Eden Hazard", 3)
        ListView1.Items.Add("Anders Herera", 4)
        ListView1.Items.Add("Oscar", 5)
        ListView1.Items.Add("Aaron Ramsey", 6)

    End Sub

    Private Sub populateBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles populateBtn.Click
        populate()

    End Sub

    Private Sub clearBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles clearBtn.Click
        ListView1.Items.Clear()
    End Sub

    Private Sub ListView1_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListView1.MouseClick
        MessageBox.Show(ListView1.SelectedItems(0).SubItems(0).Text)

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'This form has a blank ListView named "listview3"
        With ListView3
            .Dock = DockStyle.Fill
            .View = View.Details
            .GridLines = True
            .Columns.Add("First Column")
            .Columns.Item(0).Width = .Width
            .MultiSelect = True
        End With

        'Add some fake items to it
        For i As Integer = 0 To 10
            Dim objLvi As New ListViewItem
            With objLvi
                .Text = "item " & i
            End With
            ListView3.Items.Add(objLvi)
        Next

        'What items do you want to select?
        Dim intToSelect As New List(Of Integer)
        With intToSelect
            .Add(1)
            .Add(3)
            .Add(5)
            .Add(7)
            .Add(9)
        End With

        'Select those items
        For Each intItem As Integer In intToSelect
            ListView3.Items.Item(intItem).Selected = True
        Next
        ListView3.Select()
    End Sub

    
End Class