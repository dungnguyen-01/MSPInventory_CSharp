Namespace Renderers.ColorTables
    Public Interface IOffice2003ColorTable

        ReadOnly Property HoveringSelectedButtonTop() As Color
        ReadOnly Property HoveringSelectedButtonBottom() As Color
        ReadOnly Property HoveringButtonTop() As Color
        ReadOnly Property HoveringButtonBottom() As Color
        ReadOnly Property SelectedButtonTop() As Color
        ReadOnly Property SelectedButtonBottom() As Color
        ReadOnly Property PassiveButtonTop() As Color
        ReadOnly Property PassiveButtonBottom() As Color
        ReadOnly Property LineColor() As Color
        ReadOnly Property TextColor() As Color
        ReadOnly Property SelectedTextColor() As Color
        ReadOnly Property GripColorTop() As Color
        ReadOnly Property GripColorBottom() As Color
        ReadOnly Property GripTopLineColor() As Color

    End Interface
End Namespace