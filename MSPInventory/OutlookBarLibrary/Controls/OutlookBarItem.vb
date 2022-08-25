Imports System.ComponentModel

Namespace Controls

    ''' <summary>
    ''' Represents an item in the OutlookBar, consisting of a panel to add controls to and a button.
    ''' </summary>
    <Designer(GetType(Designers.OutlookBarItemDesigner))> _
    <ToolboxItem(False)> _
    Public Class OutlookBarItem
        Inherits Panel

        Private _Owner As OutlookBar
        Private ABC As String

        Public Sub New()
            Me.Dock = DockStyle.Fill
        End Sub

        Friend Property Owner() As OutlookBar
            Get
                Return _Owner
            End Get
            Set(ByVal value As OutlookBar)
                _Owner = value
            End Set
        End Property

#Region " Properties "

        Private _ButtonText As String
        ''' <summary>
        ''' Gets or sets the text displayed on the button.
        ''' </summary>
        ''' <returns>The text displayed on the button.</returns>
        <Browsable(True)> _
        <Category("Button Properties")> _
        Public Property ButtonText() As String
            Get
                Return _ButtonText
            End Get
            Set(ByVal value As String)
                _ButtonText = value
            End Set
        End Property

        Private _ButtonVisible As Boolean = True
        ''' <summary>
        ''' Gets or sets whether the button is visible or hidden.
        ''' </summary>
        ''' <returns>True if the button is visible, False otherwise.</returns>
        <Category("Button Properties")> _
        Public Property ButtonVisible() As Boolean
            Get
                Return _ButtonVisible
            End Get
            Set(ByVal value As Boolean)
                _ButtonVisible = value
                If Not value Then
                    Me.ButtonBounds = Nothing
                End If
            End Set
        End Property

        Private _Allowed As Boolean = True
        ''' <summary>
        ''' Gets or sets whether the button is hidden by the user during runtime.
        ''' </summary>
        ''' <returns>True if the button is hidden by the user during runtime, False otherwise.</returns>
        <Browsable(False)> _
        Public Property Allowed() As Boolean
            Get
                Return _Allowed
            End Get
            Set(ByVal value As Boolean)
                _Allowed = value
                If Not value Then
                    Me.ButtonVisible = False
                End If
            End Set
        End Property

        Private _Selected As Boolean
        ''' <summary>
        ''' Gets or sets whether the button is selected.
        ''' </summary>
        ''' <returns>True if the button is selected, False otherwise.</returns>
        <Browsable(False)> _
        Public Property Selected() As Boolean
            Get
                Return _Selected
            End Get
            Set(ByVal value As Boolean)
                _Selected = value
                If _Owner IsNot Nothing Then
                    If value Then
                        _Owner.SelectedItem = Me
                    Else
                        _Owner.SelectedItem = Nothing
                    End If
                End If
            End Set
        End Property

        Private _ButtonBounds As Rectangle
        ''' <summary>
        ''' Gets or sets the bounds of the button.
        ''' </summary>
        ''' <returns>The bounds of the button.</returns>
        <Browsable(False)> _
        Public Property ButtonBounds() As Rectangle
            Get
                Return _ButtonBounds
            End Get
            Set(ByVal value As Rectangle)
                _ButtonBounds = value
            End Set
        End Property

        Private _Image As Image = My.Resources.DefaultIcon.ToBitmap
        ''' <summary>
        ''' Gets or sets the image displayed on the button.
        ''' </summary>
        ''' <returns>The image displayed on the button.</returns>
        <Category("Button Properties")> _
        Public Property Image() As Image
            Get
                If _Image Is Nothing Then
                    Return My.Resources.DefaultIcon.ToBitmap
                Else
                    Return _Image
                End If
            End Get
            Set(ByVal value As Image)
                _Image = value
            End Set
        End Property

        Private _IsLarge As Boolean
        ''' <summary>
        ''' Gets or sets whether the button is a large button or in the small buttons container.
        ''' </summary>
        ''' <returns>True if the button is a large button, False if the button is in the small buttons container.</returns>
        <Browsable(False)> _
        Public Property IsLarge() As Boolean
            Get
                Return _IsLarge
            End Get
            Set(ByVal value As Boolean)
                _IsLarge = value
            End Set
        End Property

        ' This makes sure the panels are always docked
        Public Overloads Property Dock() As System.Windows.Forms.DockStyle
            Get
                Return DockStyle.Fill
            End Get
            Set(ByVal value As System.Windows.Forms.DockStyle)
                MyBase.Dock = DockStyle.Fill
            End Set
        End Property

        Public Overrides Property Text() As String
            Get
                Return Me.ButtonText
            End Get
            Set(ByVal value As String)
                Me.ButtonText = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me.ButtonText
        End Function

#End Region

    End Class
End Namespace