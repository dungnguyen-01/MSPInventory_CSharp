Imports OutlookBarLibrary.Controls

Namespace Forms
    Public Class NavigationPaneOptionsForm

        Private _OriginalItems As List(Of OutlookBarItem)
        Private _Items As Control.ControlCollection

        Public Sub New(ByVal items As Control.ControlCollection)
            Me.InitializeComponent()

            _Items = items
            _OriginalItems = New List(Of OutlookBarItem)
            For Each item As OutlookBarItem In items
                _OriginalItems.Add(item)
            Next

            Me.FillItemList()
            If Me.ItemList.Items.Count > 0 Then Me.ItemList.SelectedIndex = 0
        End Sub

        Private Sub FillItemList()
            Me.ItemList.Items.Clear()
            For Each item As OutlookBarItem In _Items
                If item.Allowed Then
                    Me.ItemList.Items.Add(item, item.ButtonVisible)
                End If
            Next
        End Sub

        Private Sub UpButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpButton.Click
            Dim newIndex As Integer = Me.ItemList.SelectedIndex - 1
            _Items.SetChildIndex(DirectCast(Me.ItemList.SelectedItem, OutlookBarItem), newIndex)
            Me.FillItemList()
            Me.ItemList.SelectedIndex = newIndex
        End Sub

        Private Sub DownButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownButton.Click
            Dim newIndex As Integer = Me.ItemList.SelectedIndex + 1
            _Items.SetChildIndex(DirectCast(Me.ItemList.SelectedItem, OutlookBarItem), newIndex)
            Me.FillItemList()
            Me.ItemList.SelectedIndex = newIndex
        End Sub

        Private Sub ResetButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetButton.Click
            _Items.Clear()
            For Each item As OutlookBarItem In _OriginalItems
                _Items.Add(item)
            Next
            Me.FillItemList()
        End Sub

        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
            For i As Integer = 0 To Me.ItemList.Items.Count - 1
                DirectCast(_Items(i), OutlookBarItem).ButtonVisible = Me.ItemList.CheckedIndices.Contains(i)
            Next

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End Sub

        Private Sub CancelButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CancelButton.Click
            _Items.Clear()
            For Each item As OutlookBarItem In _OriginalItems
                _Items.Add(item)
            Next

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
        End Sub

        Private Sub ItemList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemList.SelectedIndexChanged
            Me.UpButton.Enabled = (Me.ItemList.SelectedIndex <> 0)
            Me.DownButton.Enabled = (Me.ItemList.SelectedIndex <> Me.ItemList.Items.Count - 1)
            If Me.ItemList.Items.Count = 1 Then
                Me.UpButton.Enabled = False
                Me.DownButton.Enabled = False
            End If
        End Sub

        Private Sub ItemList_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles ItemList.ItemCheck
            Dim item = TryCast(Me.ItemList.Items(e.Index), OutlookBarItem)
            If item IsNot Nothing Then
                item.ButtonVisible = (e.NewValue = CheckState.Checked)
            End If
        End Sub

    End Class
End Namespace