Namespace Renderers.ColorTables
    Public Class Office2007BlueColorTable
        Implements IOffice2007ColorTable

        Public Overridable ReadOnly Property GripColorBottom() As System.Drawing.Color Implements IOffice2007ColorTable.GripColorBottom
            Get
                Return Color.FromArgb(179, 212, 255)
            End Get
        End Property

        Public Overridable ReadOnly Property GripColorTop() As System.Drawing.Color Implements IOffice2007ColorTable.GripColorTop
            Get
                Return Color.FromArgb(227, 239, 255)
            End Get
        End Property

        Public Overridable ReadOnly Property GripTopLineColor() As System.Drawing.Color Implements IOffice2007ColorTable.GripTopLineColor
            Get
                Return Me.LineColor
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringButtonBottom1() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringButtonBottom1
            Get
                Return Color.FromArgb(255, 232, 166)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringButtonBottom2() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringButtonBottom2
            Get
                Return Color.FromArgb(255, 230, 159)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringButtonTop1() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringButtonTop1
            Get
                Return Color.FromArgb(255, 254, 228)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringButtonTop2() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringButtonTop2
            Get
                Return Color.FromArgb(255, 215, 103)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringSelectedButtonBottom1() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringSelectedButtonBottom1
            Get
                Return Color.FromArgb(255, 172, 66)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringSelectedButtonBottom2() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringSelectedButtonBottom2
            Get
                Return Color.FromArgb(254, 211, 101)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringSelectedButtonTop1() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringSelectedButtonTop1
            Get
                Return Color.FromArgb(255, 189, 105)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringSelectedButtonTop2() As System.Drawing.Color Implements IOffice2007ColorTable.HoveringSelectedButtonTop2
            Get
                Return Color.FromArgb(251, 140, 60)
            End Get
        End Property

        Public Overridable ReadOnly Property LineColor() As System.Drawing.Color Implements IOffice2007ColorTable.LineColor
            Get
                Return Color.FromArgb(101, 147, 207)
            End Get
        End Property

        Public Overridable ReadOnly Property PassiveButtonBottom1() As System.Drawing.Color Implements IOffice2007ColorTable.PassiveButtonBottom1
            Get
                Return Color.FromArgb(196, 221, 255)
            End Get
        End Property

        Public Overridable ReadOnly Property PassiveButtonBottom2() As System.Drawing.Color Implements IOffice2007ColorTable.PassiveButtonBottom2
            Get
                Return Color.FromArgb(193, 219, 255)
            End Get
        End Property

        Public Overridable ReadOnly Property PassiveButtonTop1() As System.Drawing.Color Implements IOffice2007ColorTable.PassiveButtonTop1
            Get
                Return Color.FromArgb(227, 239, 255)
            End Get
        End Property

        Public Overridable ReadOnly Property PassiveButtonTop2() As System.Drawing.Color Implements IOffice2007ColorTable.PassiveButtonTop2
            Get
                Return Color.FromArgb(173, 209, 255)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedButtonBottom1() As System.Drawing.Color Implements IOffice2007ColorTable.SelectedButtonBottom1
            Get
                Return Color.FromArgb(255, 187, 109)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedButtonBottom2() As System.Drawing.Color Implements IOffice2007ColorTable.SelectedButtonBottom2
            Get
                Return Color.FromArgb(254, 225, 123)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedButtonTop1() As System.Drawing.Color Implements IOffice2007ColorTable.SelectedButtonTop1
            Get
                Return Color.FromArgb(255, 217, 170)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedButtonTop2() As System.Drawing.Color Implements IOffice2007ColorTable.SelectedButtonTop2
            Get
                Return Color.FromArgb(255, 171, 63)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedTextColor() As System.Drawing.Color Implements IOffice2007ColorTable.SelectedTextColor
            Get
                Return Color.Black
            End Get
        End Property

        Public Overridable ReadOnly Property TextColor() As System.Drawing.Color Implements IOffice2007ColorTable.TextColor
            Get
                Return Color.FromArgb(32, 77, 137)
            End Get
        End Property

    End Class
End Namespace