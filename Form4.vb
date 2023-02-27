Imports System.IO

Public Class Form4

    'Create a new imagelist and set the image size to the size you want.
    Private ImgList As New ImageList With {.ImageSize = New Size(24, 24)}

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '  ImgList.Images.Add(My.Resources.BluePlus) 'Add the Image to the ImageList




        'our files img
        'Dim files As String() = New String() {}
        'files = Directory.GetFiles("C:/Camera/ΦΑΓΗΤΑ")


        'Dim fileNAME(300) As String


        'Dim N As Integer = 0


        'For Each f In files
        '    ImgList.Images.Add(Image.FromFile(f))
        'Next







        ListView1.HideSelection = True
        ListView1.FullRowSelect = True
        ListView1.CheckBoxes = True
        ListView1.OwnerDraw = True
        ' ListView1.SmallImageList = ImgList 'Set the ListView`s SmallImageList to the ImgList

        'This code is just to add a few test items to the listview
        Dim dif() As String = {"Too Difficult", "Relatively Easy", "Extremely Easy", "Relatively Easy"}
        For x As Integer = 0 To 3
            Dim lvi As New ListViewItem("Bracelet " & x.ToString)
            lvi.SubItems.Add("Number")
            lvi.SubItems.Add("Number")
            lvi.SubItems.Add(dif(x))
            ListView1.Items.Add(lvi)
        Next
    End Sub

    Private Sub ListView1_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles ListView1.DrawColumnHeader
        e.DrawDefault = True
    End Sub

    Private Sub ListView1_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles ListView1.DrawSubItem
        Using txtbrsh As New SolidBrush(e.SubItem.ForeColor)
            If ListView1.SelectedIndices.Contains(e.ItemIndex) And ListView1.Focused Then
                e.Graphics.FillRectangle(New SolidBrush(Color.FromKnownColor(KnownColor.Highlight)), e.Bounds)
                txtbrsh.Color = Color.White
            End If
            If e.Item.SubItems(3) Is e.SubItem Then
                'e.DrawDefault = False
                'Using sf As New StringFormat With {.Alignment = StringAlignment.Near, .LineAlignment = StringAlignment.Center, .FormatFlags = StringFormatFlags.NoWrap, .Trimming = StringTrimming.EllipsisCharacter}
                '    If e.SubItem.Text = "Extremely Easy" Then
                '        e.Graphics.DrawImage(ImgList.Images(0), e.Bounds.X, e.Bounds.Y, e.Bounds.Height, e.Bounds.Height)
                '    End If
                '    Dim rb As New Rectangle(e.Bounds.X + e.Bounds.Height, e.Bounds.Y, e.Bounds.Width - e.Bounds.Height, e.Bounds.Height)
                '    e.Graphics.DrawString(e.SubItem.Text, e.SubItem.Font, txtbrsh, rb, sf)
                'End Using
            Else
                e.DrawDefault = True
            End If
        End Using
    End Sub

    'Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    'End Sub

    'Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    Label1.Text = ""
    '    ''"This is my first program in vb.net " & vbCrLf & _
    '    '              "if you have some concern just see my " & vbCrLf & _
    '    '              "account in facebook or email me at " & vbCrLf & _
    '    '              "jgiminsil@yahoo.com" & vbCrLf & _
    '    '              "_____________________________" & vbCrLf & _
    '    '              "This program show you how to code easier" & vbCrLf & _
    '    '              "you learn on this program on how to edit," & vbCrLf & _
    '    '              "add,delete and search, don't forget to vote" & vbCrLf & _
    '    '              "or leave a comment;-)"

    'End Sub





End Class