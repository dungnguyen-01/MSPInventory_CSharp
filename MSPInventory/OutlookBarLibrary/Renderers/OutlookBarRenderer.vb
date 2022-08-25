Imports OutlookBarLibrary.Renderers.ColorTables
Imports OutlookBarLibrary.Controls

Namespace Renderers

    Public MustInherit Class OutlookBarRenderer

        Protected OutlookBar As OutlookBar

        Public Sub SetOwner(ByVal owner As OutlookBar)
            Me.OutlookBar = owner
        End Sub

        'Properties
        MustOverride ReadOnly Property Font() As Font
        MustOverride ReadOnly Property ButtonHeight() As Integer
        MustOverride ReadOnly Property SmallButtonWidth() As Integer
        MustOverride ReadOnly Property GripIcon() As Icon
        MustOverride ReadOnly Property DropdownIcon() As Icon
        MustOverride ReadOnly Property SmallButtonContainerLeftMargin() As Integer
        MustOverride ReadOnly Property GripHeight() As Integer

        'Methods
        MustOverride Sub DrawGripRectangle(ByVal g As Graphics)
        MustOverride Sub DrawButton(ByVal g As Graphics, ByVal item As OutlookBarItem, Optional ByVal isLargeLast As Boolean = False)
        MustOverride Sub DrawDropdownRectangle(ByVal g As Graphics)
        MustOverride Sub DrawBottomLine(ByVal g As Graphics)
        MustOverride Sub DrawSmallButtonContainer(ByVal g As Graphics, ByVal rect As Rectangle)

    End Class
End Namespace