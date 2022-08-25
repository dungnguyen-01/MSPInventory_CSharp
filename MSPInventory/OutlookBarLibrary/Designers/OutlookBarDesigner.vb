Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports OutlookBarLibrary.Controls

Namespace Designers

    Public Class OutlookBarDesigner
        Inherits ControlDesigner

#Region " Properties "

        Public ReadOnly Property OutlookBar() As OutlookBar
            Get
                Return DirectCast(Me.Control, OutlookBar)
            End Get
        End Property

        Private _ActionLists As DesignerActionListCollection
        Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
            Get
                If _ActionLists Is Nothing Then
                    _ActionLists = New DesignerActionListCollection()
                    _ActionLists.Add(New OutlookBarActionList(Me.OutlookBar, Me))
                End If
                Return _ActionLists
            End Get
        End Property

        Private _SelectionService As ISelectionService
        Public ReadOnly Property SelectionService() As ISelectionService
            Get
                If _SelectionService Is Nothing Then
                    _SelectionService = DirectCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
                End If
                Return _SelectionService
            End Get
        End Property

        Private _DesignerHost As IDesignerHost
        Public ReadOnly Property DesignerHost() As IDesignerHost
            Get
                If _DesignerHost Is Nothing Then
                    _DesignerHost = DirectCast(GetService(GetType(IDesignerHost)), IDesignerHost)
                End If
                Return _DesignerHost
            End Get
        End Property

#End Region

#Region " Methods "

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)

            ' Listen for SelectedItemChanged event
            AddHandler Me.OutlookBar.SelectedItemChanged, AddressOf SelectedItemChanged
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()

            ' Stop listening for SelectedItemChanged event
            RemoveHandler Me.OutlookBar.SelectedItemChanged, AddressOf SelectedItemChanged
        End Sub

        Private Sub SelectedItemChanged(ByVal sender As Object, ByVal e As EventArgs)
            ' When the selected item has changed, also select it in the designer.
            Me.SelectionService.SetSelectedComponents(New Component() {Me.OutlookBar.SelectedItem}, SelectionTypes.Auto)
        End Sub

        Private Sub OnAddItem()
            ' Store old items for undo
            Dim oldItems = Me.OutlookBar.Items
            RaiseComponentChanging(TypeDescriptor.GetProperties(Me.OutlookBar).Item("Items"))

            Dim item = DirectCast(Me.DesignerHost.CreateComponent(GetType(OutlookBarItem)), OutlookBarItem)
            item.ButtonText = item.Name
            item.Owner = Me.OutlookBar
            item.Dock = DockStyle.Fill

            Me.OutlookBar.Items.Add(item)

            RaiseComponentChanged(TypeDescriptor.GetProperties(Me.OutlookBar).Item("Items"), oldItems, Me.OutlookBar.Items)
            Me.OutlookBar.SelectedItem = item
            Me.SelectionService.SetSelectedComponents(New IComponent() {Me.OutlookBar}, SelectionTypes.Auto)
        End Sub

        Private Sub OnRemoveItem()
            ' Store old items for undo
            Dim oldItems As Control.ControlCollection = Me.OutlookBar.Controls

            If Me.OutlookBar.SelectedItem Is Nothing Then Return

            RaiseComponentChanging(TypeDescriptor.GetProperties(Me.OutlookBar)("Items"))
            Me.DesignerHost.DestroyComponent(Me.OutlookBar.SelectedItem)
            RaiseComponentChanged(TypeDescriptor.GetProperties(Me.OutlookBar)("Items"), oldItems, Me.OutlookBar.Items)
            Me.SelectionService.SetSelectedComponents(New IComponent() {Me.OutlookBar}, SelectionTypes.Auto)
        End Sub

        Protected Overrides Function GetHitTest(ByVal point As System.Drawing.Point) As Boolean
            ' If the mouse is in the ButtonsPanel, tell the designer that we can edit that
            ' This makes the buttons react to the mouse as if during run-time.
            If Me.OutlookBar.ButtonsPanel.Bounds.Contains(Me.OutlookBar.PointToClient(point)) Then
                If Me.OutlookBar.GetEmptyBottomContainerRectangle.Contains(Me.OutlookBar.ButtonsPanel.PointToClient(point)) Then
                    ' However, if the mouse is in the empty part of the small button container,
                    ' we give the control back to the parent so it can be selected and moved
                    Return False
                Else
                    Return True
                End If
            End If
            Return MyBase.GetHitTest(point)
        End Function

#End Region

        Friend Class OutlookBarActionList
            Inherits DesignerActionList

            Private _Bar As OutlookBar
            Private _Designer As OutlookBarDesigner
            Private _DesignerActionService As DesignerActionUIService

            Public Sub New(ByVal bar As OutlookBar, ByVal barDesigner As OutlookBarDesigner)
                MyBase.New(bar)

                _Bar = bar
                _Designer = barDesigner
                _DesignerActionService = DirectCast(Me.GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
            End Sub

            Private Sub AddItem()
                _Designer.OnAddItem()
                _DesignerActionService.Refresh(_Bar)
            End Sub

            Private Sub RemoveItem()
                _Designer.OnRemoveItem()
                _DesignerActionService.Refresh(_Bar)
            End Sub

            Public Property SelectedItem() As OutlookBarItem
                Get
                    Return _Bar.SelectedItem
                End Get
                Set(ByVal value As OutlookBarItem)
                    _Bar.SelectedItem = value
                    _DesignerActionService.Refresh(_Bar)
                End Set
            End Property

            Public Property Dock() As DockStyle
                Get
                    Return _Bar.Dock
                End Get
                Set(ByVal value As DockStyle)
                    _Bar.Dock = value
                    _DesignerActionService.Refresh(_Bar)
                End Set
            End Property

            Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
                Dim items As New DesignerActionItemCollection

                items.Add(New DesignerActionHeaderItem("Items"))
                items.Add(New DesignerActionMethodItem(Me, "AddItem", "Add Item", "Items", _
                                                       "Adds a new item to this OutlookBar.", True))
                If _Bar.Items.Count > 1 Then
                    items.Add(New DesignerActionMethodItem(Me, "RemoveItem", "Remove Item", "Items", _
                                                           "Removes the selected item from this OutlookBar.", True))
                End If
                items.Add(New DesignerActionPropertyItem("SelectedItem", "Selected Item:", "Items", "Gets or sets the selected item."))
                items.Add(New DesignerActionPropertyItem("Dock", "Dock:", String.Empty, "Docks this control to a side."))

                Return items
            End Function

        End Class
    End Class
End Namespace