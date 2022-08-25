Imports OutlookBarLibrary.Renderers.ColorTables
Imports OutlookBarLibrary.Controls
Imports OutlookBarLibrary.Controls.OutlookBar
Imports System.Drawing.Drawing2D

Namespace Renderers

    Public Class Office2003Renderer
        Inherits OutlookBarRenderer

        Private Const ImageDimension_Large As Integer = 24
        Private Const ImageDimension_Small As Integer = 18

        Public Sub New()
            _ColorTable = New Office2003BlueColorTable
        End Sub

        Public Sub New(ByVal colorTable As IOffice2003ColorTable)
            _ColorTable = colorTable
        End Sub

#Region " Properties "

        Private _ColorTable As IOffice2003ColorTable
        Public ReadOnly Property ColorTable() As IOffice2003ColorTable
            Get
                Return _ColorTable
            End Get
        End Property

        Public Overrides ReadOnly Property Font() As Font
            Get
                Return New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, 0)
            End Get
        End Property

        Public Overrides ReadOnly Property ButtonHeight() As Integer
            Get
                Return 32
            End Get
        End Property

        Public Overrides ReadOnly Property SmallButtonWidth() As Integer
            Get
                Return 22
            End Get
        End Property

        Public Overrides ReadOnly Property GripIcon() As Icon
            Get
                Return My.Resources.Grip2003
            End Get
        End Property

        Public Overrides ReadOnly Property DropdownIcon() As Icon
            Get
                Return My.Resources.DropDown2003
            End Get
        End Property

        Public Overrides ReadOnly Property GripHeight() As Integer
            Get
                Return 6
            End Get
        End Property

        Public Overrides ReadOnly Property SmallButtonContainerLeftMargin() As Integer
            Get
                Return 15
            End Get
        End Property

#End Region

#Region " Drawing Methods "

        Public Overrides Sub DrawBottomLine(ByVal g As System.Drawing.Graphics)
            g.DrawLine(New Pen(Me.ColorTable.LineColor), 0, Me.OutlookBar.ButtonsPanel.Height - 1, Me.OutlookBar.ButtonsPanel.Width - 1, Me.OutlookBar.ButtonsPanel.Height - 1)
        End Sub

        Public Overrides Sub DrawButton(ByVal g As System.Drawing.Graphics, ByVal item As OutlookBarItem, Optional ByVal isLargeLast As Boolean = False)
            'Button background
            If item.Equals(Me.OutlookBar._HoveringButton) Then
                If Me.OutlookBar._LeftClickedButton Is Nothing Then
                    If item.Equals(Me.OutlookBar.SelectedItem) Then
                        Me.FillButton(g, item.ButtonBounds, OutlookBarButtonStates.Selected Or OutlookBarButtonStates.Hovering, True, item.IsLarge, item.IsLarge)
                    Else
                        Me.FillButton(g, item.ButtonBounds, OutlookBarButtonStates.Hovering, True, item.IsLarge, item.IsLarge)
                    End If
                Else
                    Me.FillButton(g, item.ButtonBounds, OutlookBarButtonStates.Selected Or OutlookBarButtonStates.Hovering, True, item.IsLarge, item.IsLarge)
                End If
            Else
                If item.Equals(Me.OutlookBar.SelectedItem) Then
                    Me.FillButton(g, item.ButtonBounds, OutlookBarButtonStates.Selected, True, item.IsLarge, item.IsLarge)
                Else
                    Me.FillButton(g, item.ButtonBounds, OutlookBarButtonStates.Passive, True, item.IsLarge, item.IsLarge)
                End If
            End If

            'Text & Icon
            Dim textColor As Color
            If item.Equals(Me.OutlookBar.SelectedItem) Then
                textColor = Me.ColorTable.TextColor
            Else
                textColor = Me.ColorTable.SelectedTextColor
            End If

            If item.IsLarge AndAlso isLargeLast Then
                g.DrawString(item.ButtonText, _
                             Me.Font, _
                             New SolidBrush(textColor), _
                             10 + ImageDimension_Large + 8, _
                             CInt(item.ButtonBounds.Y + ((Me.ButtonHeight / 2) - (Me.Font.Height / 2))) + 2)
            End If
            Dim imgRect As New Rectangle
            With imgRect
                If item.IsLarge Then
                    .Width = ImageDimension_Large
                    .Height = ImageDimension_Large
                    .X = 10
                    .Y = CInt(item.ButtonBounds.Y + Math.Floor((Me.ButtonHeight / 2) - (ImageDimension_Large / 2)))
                Else
                    .Width = ImageDimension_Small
                    .Height = ImageDimension_Small
                    .X = CInt(item.ButtonBounds.X + Math.Floor((Me.SmallButtonWidth / 2) - (ImageDimension_Small / 2)))
                    .Y = CInt(item.ButtonBounds.Y + Math.Floor((Me.ButtonHeight / 2) - (ImageDimension_Small / 2)))
                End If
            End With
            If item.IsLarge AndAlso isLargeLast = True Then g.DrawImage(item.Image, imgRect)
            If item.IsLarge = False Then g.DrawImage(item.Image, imgRect)
        End Sub

        Public Overrides Sub DrawGripRectangle(ByVal g As System.Drawing.Graphics)
            Dim rect As Rectangle = Me.OutlookBar.GetGripRectangle

            Using b As New LinearGradientBrush(rect, Me.ColorTable.GripColorTop, Me.ColorTable.GripColorBottom, LinearGradientMode.Vertical)
                g.FillRectangle(b, rect)
            End Using

            Using icon As Icon = Me.GripIcon
                Dim iconRect As New Rectangle(CInt((CInt(Me.OutlookBar.ButtonsPanel.Width) / 2) - (CInt(icon.Width / 2))), _
                                              ((CInt((rect.Height) / 2)) - CInt((icon.Height / 2))) + 1, _
                                              icon.Width, _
                                              icon.Height)
                g.DrawIcon(icon, iconRect)
                g.DrawLine(New Pen(Me.ColorTable.GripTopLineColor, 1), 0, 0, Me.OutlookBar.ButtonsPanel.Width, 0)
                g.DrawLine(New Pen(Me.ColorTable.LineColor, 1), 0, 0, 0, rect.Height)
                g.DrawLine(New Pen(Me.ColorTable.LineColor, 1), rect.Width - 1, 0, rect.Width - 1, rect.Height)
            End Using
        End Sub

        Public Overrides Sub DrawSmallButtonContainer(ByVal g As Graphics, ByVal rect As Rectangle)
            Me.FillButton(g, rect, OutlookBarButtonStates.Passive, True, True, False)
        End Sub

        Public Overrides Sub DrawDropdownRectangle(ByVal g As System.Drawing.Graphics)
            Dim rect As Rectangle = Me.OutlookBar.GetDropDownRectangle

            If Me.OutlookBar._DropdownHovering Then
                Me.FillButton(g, rect, OutlookBarButtonStates.Hovering, True, False, True)
            Else
                Me.FillButton(g, rect, OutlookBarButtonStates.Passive, True, False, True)
            End If

            Using icon As Icon = Me.DropdownIcon
                Dim RectangleIcon As New Rectangle(CInt((rect.X + ((rect.Width / 2) - (icon.Width / 2)))), _
                                                   CInt((rect.Y + (((rect.Height / 2) - (icon.Height / 2)) + 1))), _
                                                   icon.Width, _
                                                   icon.Height)
                g.DrawIcon(icon, RectangleIcon)
            End Using
        End Sub

        Private Sub FillButton(ByVal g As Graphics, _
                               ByVal rect As Rectangle, _
                               ByVal state As OutlookBarButtonStates, _
                               ByVal drawTopBorder As Boolean, _
                               ByVal drawLeftBorder As Boolean, _
                               ByVal drawRightBorder As Boolean)

            Dim topColor, bottomColor As Color
            Select Case state
                Case OutlookBarButtonStates.Hovering
                    topColor = Me.ColorTable.HoveringButtonTop
                    bottomColor = Me.ColorTable.HoveringButtonBottom
                Case OutlookBarButtonStates.Selected
                    topColor = Me.ColorTable.SelectedButtonTop
                    bottomColor = Me.ColorTable.SelectedButtonBottom
                Case OutlookBarButtonStates.Passive
                    topColor = Me.ColorTable.PassiveButtonTop
                    bottomColor = Me.ColorTable.PassiveButtonBottom
                Case OutlookBarButtonStates.Hovering Or OutlookBarButtonStates.Selected
                    topColor = Me.ColorTable.HoveringSelectedButtonTop
                    bottomColor = Me.ColorTable.HoveringSelectedButtonBottom
            End Select

            Using b As New LinearGradientBrush(rect, topColor, bottomColor, LinearGradientMode.Vertical)
                g.FillRectangle(b, rect)
            End Using

            If drawTopBorder Then g.DrawLine(New Pen(Me.ColorTable.LineColor), rect.X, rect.Y, rect.Width + rect.X, rect.Y)
            If drawLeftBorder Then g.DrawLine(New Pen(Me.ColorTable.LineColor), rect.X, rect.Y, rect.X, rect.Y + rect.Height)
            If drawRightBorder Then g.DrawLine(New Pen(Me.ColorTable.LineColor), rect.X + rect.Width - 1, rect.Y, rect.X + rect.Width - 1, rect.Y + rect.Height)
        End Sub

#End Region

    End Class
End Namespace