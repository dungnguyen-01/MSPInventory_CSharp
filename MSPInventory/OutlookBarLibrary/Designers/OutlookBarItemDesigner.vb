Imports System.Windows.Forms.Design
Imports System.ComponentModel.Design
Imports OutlookBarLibrary.Controls

Namespace Designers

    Public Class OutlookBarItemDesigner
        Inherits ParentControlDesigner

        Public ReadOnly Property Item() As OutlookBarItem
            Get
                Return DirectCast(Me.Control, OutlookBarItem)
            End Get
        End Property

        ' We don't ever want the user to move these panels
        Public Overrides ReadOnly Property SelectionRules() As System.Windows.Forms.Design.SelectionRules
            Get
                Return Windows.Forms.Design.SelectionRules.Locked
            End Get
        End Property

        Private _ActionLists As DesignerActionListCollection
        Public Overrides ReadOnly Property ActionLists() As DesignerActionListCollection
            Get
                If _ActionLists Is Nothing Then
                    _ActionLists = New DesignerActionListCollection()
                    _ActionLists.Add(New OutlookBarItemActionList(Me.Item, Me))
                End If
                Return _ActionLists
            End Get
        End Property

        Friend Class OutlookBarItemActionList
            Inherits DesignerActionList

            Private _Item As OutlookBarItem
            Private _Designer As OutlookBarItemDesigner
            Private _DesignerActionService As DesignerActionUIService

            Private _SelectionService As ISelectionService
            Public ReadOnly Property SelectionService() As ISelectionService
                Get
                    If _SelectionService Is Nothing Then
                        _SelectionService = DirectCast(Me.GetService(GetType(ISelectionService)), ISelectionService)
                    End If
                    Return _SelectionService
                End Get
            End Property

            Public Sub New(ByVal item As OutlookBarItem, ByVal itemDesigner As OutlookBarItemDesigner)
                MyBase.New(item)

                _Item = item
                _Designer = itemDesigner
                _DesignerActionService = DirectCast(Me.GetService(GetType(DesignerActionUIService)), DesignerActionUIService)
            End Sub

            Private Sub SelectBar()
                Me.SelectionService.SetSelectedComponents(New System.ComponentModel.Component() {_Item.Owner}, SelectionTypes.Auto)
                _DesignerActionService.HideUI(_Item)
            End Sub

            Public Overrides Function GetSortedActionItems() As DesignerActionItemCollection
                Dim items As New DesignerActionItemCollection
                items.Add(New DesignerActionMethodItem(Me, "SelectBar", "Select Parent", String.Empty, "Selects the parent OutlookBar.", True))
                Return items
            End Function

        End Class
    End Class

End Namespace