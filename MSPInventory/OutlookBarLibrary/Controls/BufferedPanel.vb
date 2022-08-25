Imports System.ComponentModel

Namespace Controls

    ''' <summary>
    ''' Represents a Panel with buffered painting for a smoother drawing experience. Used for the OutlookBar buttons panel.
    ''' </summary>
    <ToolboxItemAttribute(False)> _
    Public Class BufferedPanel
        Inherits Panel

        Public Sub New()
            Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
            Me.SetStyle(ControlStyles.ResizeRedraw, True)
            Me.SetStyle(ControlStyles.DoubleBuffer, True)
        End Sub

    End Class

End Namespace