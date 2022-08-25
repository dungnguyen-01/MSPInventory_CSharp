Namespace Renderers.ColorTables
    Public Class Office2003BlueColorTable
        Implements IOffice2003ColorTable

        Public Overridable ReadOnly Property HoveringButtonBottom() As System.Drawing.Color Implements IOffice2003ColorTable.HoveringButtonBottom
            Get
                Return Color.FromArgb(247, 192, 91)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringButtonTop() As System.Drawing.Color Implements IOffice2003ColorTable.HoveringButtonTop
            Get
                Return Color.FromArgb(255, 255, 220)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringSelectedButtonBottom() As System.Drawing.Color Implements IOffice2003ColorTable.HoveringSelectedButtonBottom
            Get
                Return Color.FromArgb(247, 218, 124)
            End Get
        End Property

        Public Overridable ReadOnly Property HoveringSelectedButtonTop() As System.Drawing.Color Implements IOffice2003ColorTable.HoveringSelectedButtonTop
            Get
                Return Color.FromArgb(232, 127, 8)
            End Get
        End Property

        Public Overridable ReadOnly Property PassiveButtonBottom() As System.Drawing.Color Implements IOffice2003ColorTable.PassiveButtonBottom
            Get
                Return Color.FromArgb(125, 166, 223)
            End Get
        End Property

        Public Overridable ReadOnly Property PassiveButtonTop() As System.Drawing.Color Implements IOffice2003ColorTable.PassiveButtonTop
            Get
                Return Color.FromArgb(203, 225, 252)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedButtonBottom() As System.Drawing.Color Implements IOffice2003ColorTable.SelectedButtonBottom
            Get
                Return Color.FromArgb(232, 127, 8)
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedButtonTop() As System.Drawing.Color Implements IOffice2003ColorTable.SelectedButtonTop
            Get
                Return Color.FromArgb(247, 218, 124)
            End Get
        End Property

        Public Overridable ReadOnly Property LineColor() As System.Drawing.Color Implements IOffice2003ColorTable.LineColor
            Get
                Return Color.FromArgb(0, 45, 150)
            End Get
        End Property

        Public Overridable ReadOnly Property TextColor() As System.Drawing.Color Implements IOffice2003ColorTable.TextColor
            Get
                Return Color.Black
            End Get
        End Property

        Public Overridable ReadOnly Property SelectedTextColor() As System.Drawing.Color Implements IOffice2003ColorTable.SelectedTextColor
            Get
                Return Color.Black
            End Get
        End Property

        Public Overridable ReadOnly Property GripColorTop() As System.Drawing.Color Implements IOffice2003ColorTable.GripColorTop
            Get
                Return Color.FromArgb(89, 135, 214)
            End Get
        End Property

        Public Overridable ReadOnly Property GripColorBottom() As System.Drawing.Color Implements IOffice2003ColorTable.GripColorBottom
            Get
                Return Color.FromArgb(0, 45, 150)
            End Get
        End Property

        Public Overridable ReadOnly Property GripTopLineColor() As System.Drawing.Color Implements IOffice2003ColorTable.GripTopLineColor
            Get
                Return Color.Transparent
            End Get
        End Property

    End Class
End Namespace