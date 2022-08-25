Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing.Design

Namespace Controls

    <Designer(GetType(Designers.OutlookBarDesigner))> _
    <DefaultEvent("SelectedItemChanged")> _
    Public Class OutlookBar

        Public Sub New()
            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            _Office2003BlueRenderer = New Renderers.Office2003Renderer
            _Office2007BlueRenderer = New Renderers.Office2007Renderer
            Me.RendererPreset = RendererPresets.Office2003Blue

            _ToolTip = New ToolTip
        End Sub

#Region " Events "

        Public Event SelectedItemChanged As EventHandler

#End Region

#Region " Enumerations "

        ' Represents the state of a button
        Friend Enum OutlookBarButtonStates
            Passive
            Hovering
            Selected
        End Enum

        Public Enum RendererPresets
            Office2003Blue
            Office2007Blue
            Custom
        End Enum

#End Region

#Region " Private Fields "

        Private _Office2003BlueRenderer As Renderers.Office2003Renderer
        Private _Office2007BlueRenderer As Renderers.Office2007Renderer

        Private _ToolTip As ToolTip
        Private _ContextMenuStrip As ContextMenuStrip
        Friend _LeftClickedButton As OutlookBarItem
        Friend _RightClickedButton As OutlookBarItem
        Friend _HoveringButton As OutlookBarItem
        Private _IsResizing As Boolean
        Friend _DropdownHovering As Boolean
        Private _CanGrow As Boolean
        Private _CanShrink As Boolean
        Private _MaxLargeButtonCount As Integer
        Private _MaxSmallButtonCount As Integer

#End Region

#Region " Properties "

        ''' <summary>
        ''' Gets the collection of OutlookBarItems in this OutlookBar.
        ''' </summary>
        ''' <returns>The collection of OutlookBarItems in this OutlookBar.</returns>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <Editor(GetType(OutlookBarItemCollectionEditor), GetType(UITypeEditor))> _
        Public ReadOnly Property Items() As Control.ControlCollection
            Get
                Return Me.ContentPanel.Controls
            End Get
        End Property

        ''' <summary>
        ''' Gets the panel that holds the content panels to which you can add controls.
        ''' </summary>
        ''' <returns>The panel that holds the content panels to which you can add controls.</returns>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <Browsable(False)> _
        Public ReadOnly Property ContentPanel() As Panel
            Get
                Return pnlContent
            End Get
        End Property

        ''' <summary>
        ''' Gets the panel that holds the buttons.
        ''' </summary>
        ''' <returns>The panel that holds the buttons.</returns>
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        <Browsable(False)> _
        Public ReadOnly Property ButtonsPanel() As BufferedPanel
            Get
                Return pnlButtons
            End Get
        End Property

        Private _Renderer As Renderers.OutlookBarRenderer
        ''' <summary>
        ''' Gets or sets the OutlookBarRenderer used to draw this OutlookBar.
        ''' </summary>
        ''' <returns>The OutlookBarRenderer used to draw this OutlookBar.</returns>
        <Browsable(False)> _
        Public Property Renderer() As Renderers.OutlookBarRenderer
            Get
                ' Never return nothing, but return the 2003 renderer instead
                If _Renderer Is Nothing Then
                    _Renderer = New Renderers.Office2003Renderer
                End If
                Return _Renderer
            End Get
            Set(ByVal value As Renderers.OutlookBarRenderer)
                _Renderer = value

                If _Renderer Is _Office2003BlueRenderer Then
                    _RendererPreset = RendererPresets.Office2003Blue
                ElseIf _Renderer Is _Office2007BlueRenderer Then
                    _RendererPreset = RendererPresets.Office2007Blue
                Else
                    _RendererPreset = RendererPresets.Custom
                End If

                ' Set the owner of the Renderer now so the user doesn't have to take care of that
                _Renderer.SetOwner(Me)
                Me.ButtonsPanel.Invalidate()
            End Set
        End Property

        Private _RendererPreset As RendererPresets
        ''' <summary>
        ''' Gets or sets the preset used for the Renderer.
        ''' </summary>
        ''' <returns>The preset used for the Renderer.</returns>
        Public Property RendererPreset() As RendererPresets
            Get
                Return _RendererPreset
            End Get
            Set(ByVal value As RendererPresets)
                Select Case value
                    Case RendererPresets.Office2003Blue
                        _RendererPreset = value
                        Me.Renderer = _Office2003BlueRenderer
                    Case RendererPresets.Office2007Blue
                        _RendererPreset = value
                        Me.Renderer = _Office2007BlueRenderer
                    Case RendererPresets.Custom
                        If Me.DesignMode Then
                            Throw New Exception("RendererPreset cannot be set to Custom during DesignMode. " & _
                                                "Instead, assign an OutlookBarRenderer to the Renderer property at runtime.")
                        End If
                End Select
            End Set
        End Property

        Private _ContextMenuStripRenderer As ToolStripRenderer
        ''' <summary>
        ''' Gets or sets the ToolStripRenderer used to draw the ContextMenuStrip of the buttons dropdown.
        ''' </summary>
        ''' <returns>The ToolStripRenderer used to draw the ContextMenuStrip of the buttons dropdown.</returns>
        <Browsable(False)> _
        Public Property ContextMenuStripRenderer() As ToolStripRenderer
            Get
                If _ContextMenuStripRenderer Is Nothing Then
                    _ContextMenuStripRenderer = New ToolStripProfessionalRenderer
                End If
                Return _ContextMenuStripRenderer
            End Get
            Set(ByVal value As ToolStripRenderer)
                _ContextMenuStripRenderer = value
            End Set
        End Property

        Private _SelectedItem As OutlookBarItem
        ''' <summary>
        ''' Gets or sets the selected OutlookBarItem.
        ''' </summary>
        ''' <returns>The selected OutlookBarItem.</returns>
        <Browsable(False)> _
        Public Property SelectedItem() As OutlookBarItem
            Get
                Return _SelectedItem
            End Get
            Set(ByVal value As OutlookBarItem)
                _SelectedItem = value

                ' Handle the hiding and showing of panels
                Me.OnSelectedItemChanged()
            End Set
        End Property

        Public Overrides Property MinimumSize() As System.Drawing.Size
            Get
                Return New Drawing.Size(50, Me.GetBottomContainerRectangle.Height + Me.GetGripRectangle.Height)
            End Get
            Set(ByVal value As System.Drawing.Size)
                '...
            End Set
        End Property

#End Region

#Region " Events "

        Private Sub pnlButtons_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlButtons.MouseClick
            _RightClickedButton = Nothing

            Dim item = Me.GetItemFromPoint(e.Location)
            If item IsNot Nothing Then
                If e.Button = Windows.Forms.MouseButtons.Left Then
                    Me.SelectedItem = item
                ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                    _RightClickedButton = item
                End If
                Me.ButtonsPanel.Invalidate()
            Else
                If Me.GetDropDownRectangle.Contains(e.Location) Then
                    Me.ShowContextMenu()
                End If
            End If
        End Sub

        Private Sub pnlButtons_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlButtons.MouseDown
            _IsResizing = Me.GetGripRectangle.Contains(e.Location)
        End Sub

        Private Sub pnlButtons_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pnlButtons.MouseLeave
            If _RightClickedButton Is Nothing Then
                _HoveringButton = Nothing
                _DropdownHovering = False
                Me.Cursor = Cursors.Default
                Me.ButtonsPanel.Invalidate()
            End If
        End Sub

        Private Sub pnlButtons_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlButtons.MouseMove
            _HoveringButton = Nothing
            _DropdownHovering = False

            Dim item As OutlookBarItem = Me.GetItemFromPoint(e.Location)

            If _IsResizing Then
                If e.Y < -Me.Renderer.ButtonHeight Then
                    If _CanGrow Then
                        Me.ButtonsPanel.Height += Me.Renderer.ButtonHeight
                    Else
                        Exit Sub
                    End If
                ElseIf e.Y > Me.Renderer.ButtonHeight Then
                    If _CanShrink Then
                        Me.ButtonsPanel.Height -= Me.Renderer.ButtonHeight
                    Else
                        Exit Sub
                    End If
                End If
            Else
                If Me.GetGripRectangle.Contains(e.Location) Then
                    Me.ButtonsPanel.Cursor = Cursors.SizeNS
                ElseIf Me.GetDropDownRectangle.Contains(e.Location) Then
                    Me.ButtonsPanel.Cursor = Cursors.Hand
                    _DropdownHovering = True
                    Me.ButtonsPanel.Invalidate()

                    ' Adjust tooltip
                    If _ToolTip.Tag Is Nothing _
                    OrElse Not _ToolTip.Tag.Equals("Configure") Then
                        _ToolTip.Active = True
                        _ToolTip.SetToolTip(Me.ButtonsPanel, "Configure buttons")
                        _ToolTip.Tag = "Configure"
                    End If

                ElseIf item IsNot Nothing Then

                    Me.ButtonsPanel.Cursor = Cursors.Hand
                    _HoveringButton = item
                    Me.ButtonsPanel.Invalidate()

                    ' Adjust tooltip
                    If Not item.IsLarge Then
                        If _ToolTip.Tag Is Nothing _
                        OrElse Not _ToolTip.Tag.Equals(item) Then
                            _ToolTip.Active = True
                            _ToolTip.SetToolTip(Me.ButtonsPanel, item.ButtonText)
                            _ToolTip.Tag = item
                        End If
                    Else
                        _ToolTip.Active = False
                    End If

                Else
                    Me.ButtonsPanel.Cursor = Cursors.Default
                End If
            End If
        End Sub

        Private Sub pnlButtons_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pnlButtons.MouseUp
            _IsResizing = False
            _LeftClickedButton = Nothing
            Me.ButtonsPanel.Cursor = Cursors.Default
        End Sub

#Region " Painting "

        Private Sub pnlButtons_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlButtons.Paint
            _MaxLargeButtonCount = CInt(Math.Floor((Me.ButtonsPanel.Height - Me.GetBottomContainerRectangle.Height - Me.GetGripRectangle.Height) / Me.Renderer.ButtonHeight))
            If Me.CountVisible < _MaxLargeButtonCount Then
                _MaxLargeButtonCount = Me.CountVisible
            End If

            _CanShrink = (_MaxLargeButtonCount <> 0)
            _CanGrow = (_MaxLargeButtonCount < Me.CountVisible)

            Dim h As Integer = _MaxLargeButtonCount * Me.Renderer.ButtonHeight
            h += Me.GetGripRectangle.Height + Me.GetBottomContainerRectangle.Height
            Me.ButtonsPanel.Height = h

            'Paint resizing grip
            Me.Renderer.DrawGripRectangle(e.Graphics)

            'Paint Large Buttons
            Dim largeItem As OutlookBarItem
            Dim SyncLargeButtons As Integer
            Dim iLarge As Integer
            For iLarge = 0 To Me.Items.Count - 1
                largeItem = DirectCast(Me.Items(iLarge), OutlookBarItem)

                If largeItem.ButtonVisible Then
                    Dim rec As New Drawing.Rectangle(0, (SyncLargeButtons * Me.Renderer.ButtonHeight) + Me.GetGripRectangle.Height, Me.Width, Me.Renderer.ButtonHeight)
                    largeItem.ButtonBounds = rec
                    largeItem.IsLarge = True

                    Me.Renderer.DrawButton(e.Graphics, largeItem, (_MaxLargeButtonCount <> SyncLargeButtons))

                    If SyncLargeButtons = _MaxLargeButtonCount Then Exit For
                    SyncLargeButtons += 1
                End If
            Next

            'Paint Small Buttons...
            _MaxSmallButtonCount = CInt(Math.Floor((Me.Width - Me.GetDropDownRectangle.Width - Me.Renderer.SmallButtonContainerLeftMargin) / Me.Renderer.SmallButtonWidth))
            If (Me.CountVisible - _MaxLargeButtonCount) <= 0 Then
                _MaxSmallButtonCount = 0
            End If
            If _MaxSmallButtonCount > (Me.CountVisible - _MaxLargeButtonCount) Then
                _MaxSmallButtonCount = (Me.CountVisible - _MaxLargeButtonCount)
            End If

            Dim StartX As Integer = Me.Width - Me.GetDropDownRectangle.Width - (_MaxSmallButtonCount * Me.Renderer.SmallButtonWidth)
            Dim smallItem As OutlookBarItem
            Dim SyncSmallButtons As Integer
            Dim iSmall As Integer
            For iSmall = iLarge To Me.Items.Count - 1
                smallItem = DirectCast(Me.Items(iSmall), OutlookBarItem)

                If SyncSmallButtons = _MaxSmallButtonCount Then Exit For
                If smallItem.ButtonVisible Then
                    Dim rect As New Rectangle(StartX + (SyncSmallButtons * Me.Renderer.SmallButtonWidth), Me.GetBottomContainerRectangle.Y, Me.Renderer.SmallButtonWidth, Me.GetBottomContainerRectangle.Height)
                    smallItem.ButtonBounds = rect
                    smallItem.IsLarge = False
                    Me.Renderer.DrawButton(e.Graphics, smallItem)
                    SyncSmallButtons += 1
                End If
            Next

            For i As Integer = iSmall To Me.CountVisible - 1
                DirectCast(Me.Items(i), OutlookBarItem).ButtonBounds = Nothing
            Next

            'Draw Empty Space...
            Dim bottomRect As Rectangle = Me.GetEmptyBottomContainerRectangle
            Me.Renderer.DrawSmallButtonContainer(e.Graphics, bottomRect)

            Me.Renderer.DrawGripRectangle(e.Graphics)
            Me.Renderer.DrawDropdownRectangle(e.Graphics)
            Me.Renderer.DrawBottomLine(e.Graphics)
        End Sub

#End Region

#End Region

#Region " Methods "

        Private Function CountVisible() As Integer
            Dim i As Integer = 0
            Dim item As OutlookBarItem
            For Each c As Control In Me.Items
                item = TryCast(c, OutlookBarItem)
                If item IsNot Nothing Then
                    If item.ButtonVisible Then i += 1
                End If
            Next
            Return i
        End Function

        ' Returns the item whose Button contains the specified point
        Private Function GetItemFromPoint(ByVal p As Point) As OutlookBarItem
            Dim item As OutlookBarItem
            For Each c As Control In Me.Items
                item = TryCast(c, OutlookBarItem)
                If item IsNot Nothing Then
                    If item.ButtonBounds.Contains(p) Then
                        Return item
                    End If
                End If
            Next
            Return Nothing
        End Function

        Protected Overridable Sub OnSelectedItemChanged()
            Static oldSelection As OutlookBarItem = Nothing
            If oldSelection IsNot Nothing Then
                oldSelection.Visible = False
            End If
            If Me.SelectedItem IsNot Nothing Then
                ' Hide every item except the selected item
                ' we cannot bring it to front because that would mess up the order of the buttons too
                For Each item As Control In Me.Items
                    item.Visible = (item Is Me.SelectedItem)
                Next
            End If

            Dim changed As Boolean
            If Me.SelectedItem Is Nothing Then
                changed = (oldSelection IsNot Nothing)
            Else
                changed = Not (Me.SelectedItem.Equals(oldSelection))
            End If

            If changed AndAlso Me.Created Then
                RaiseEvent SelectedItemChanged(Me, EventArgs.Empty)
            End If
        End Sub

#Region " Context menu "

        Private Sub ShowContextMenu()
            _ContextMenuStrip = New ContextMenuStrip
            _ContextMenuStrip.Renderer = Me.ContextMenuStripRenderer
            Dim moreButtonsItem As New ToolStripMenuItem("Show &More Buttons", My.Resources.up_arrow, AddressOf ShowMoreButtons)
            Dim fewerButtonsItem As New ToolStripMenuItem("Show Fe&wer Buttons", My.Resources.down_arrow, AddressOf ShowFewerButtons)
            Dim navPaneItem As New ToolStripMenuItem("Na&vigation Pane Options...", Nothing, AddressOf NavigationPaneOptions)
            Dim addRemoveItem As New ToolStripMenuItem("&Add or Remove Buttons", Nothing)

            ' Add a menu item for every allowed button in the Add/Remove Buttons dropdown
            ' and count the items without a button (when not enough space)
            Dim countHidden As Integer = 0
            Dim mnuItem As ToolStripMenuItem
            For Each item As OutlookBarItem In Me.Items
                If item.Allowed Then
                    mnuItem = New ToolStripMenuItem(item.ButtonText, item.Image, AddressOf ToggleVisible)
                    mnuItem.CheckOnClick = True
                    mnuItem.Checked = item.ButtonVisible
                    mnuItem.Tag = item
                    addRemoveItem.DropDownItems.Add(mnuItem)
                End If
                If item.ButtonVisible Then
                    If item.ButtonBounds = Nothing Then countHidden += 1
                End If
            Next

            _ContextMenuStrip.Items.Add(moreButtonsItem)
            _ContextMenuStrip.Items.Add(fewerButtonsItem)
            _ContextMenuStrip.Items.Add(navPaneItem)
            _ContextMenuStrip.Items.Add(addRemoveItem)

            If _MaxLargeButtonCount >= Me.CountVisible Then moreButtonsItem.Enabled = False
            If _MaxLargeButtonCount = 0 Then fewerButtonsItem.Enabled = False

            ' Add the hidden items to the bottom, after a separator
            If countHidden > 0 Then _ContextMenuStrip.Items.Add(New ToolStripSeparator)
            For Each item As OutlookBarItem In Me.Items
                If item.ButtonVisible AndAlso item.ButtonBounds = Nothing Then
                    mnuItem = New ToolStripMenuItem(item.ButtonText, item.Image, AddressOf MenuClicked)
                    mnuItem.Tag = item
                    mnuItem.CheckOnClick = True
                    If Me.SelectedItem IsNot Nothing _
                    AndAlso Me.SelectedItem.Equals(item) Then
                        mnuItem.Checked = True
                    End If
                    _ContextMenuStrip.Items.Add(mnuItem)
                End If
            Next

            _ContextMenuStrip.Show(Me, New Point(Me.ButtonsPanel.Width, _
                                                 Me.Height - CInt(Me.Renderer.ButtonHeight / 2)))
        End Sub

        Private Sub ShowMoreButtons(ByVal sender As Object, ByVal e As EventArgs)
            Me.ButtonsPanel.Height += Me.Renderer.ButtonHeight
        End Sub

        Private Sub ShowFewerButtons(ByVal sender As Object, ByVal e As EventArgs)
            Me.ButtonsPanel.Height -= Me.Renderer.ButtonHeight
        End Sub

        Private Sub NavigationPaneOptions(ByVal sender As Object, ByVal e As EventArgs)
            _RightClickedButton = Nothing
            _HoveringButton = Nothing
            Me.ButtonsPanel.Invalidate()

            Using f As New Forms.NavigationPaneOptionsForm(Me.Items)
                If f.ShowDialog() = DialogResult.OK Then
                    Me.ButtonsPanel.Invalidate()
                End If
            End Using
        End Sub

        Private Sub ToggleVisible(ByVal sender As Object, ByVal e As EventArgs)
            Dim mnuItem = DirectCast(sender, ToolStripMenuItem)
            Dim item = TryCast(mnuItem.Tag, OutlookBarItem)
            If item IsNot Nothing Then
                item.ButtonVisible = Not item.ButtonVisible
                Me.Invalidate()
            End If
        End Sub

        Private Sub MenuClicked(ByVal sender As Object, ByVal e As EventArgs)
            Dim mnuItem = DirectCast(sender, ToolStripMenuItem)
            Dim item = TryCast(mnuItem.Tag, OutlookBarItem)
            If item IsNot Nothing Then
                _SelectedItem = item
                RaiseEvent SelectedItemChanged(Me, EventArgs.Empty)
            End If
        End Sub

#End Region

#Region " Renderer dependent values "

        ' Gets the rectangle that makes up the small button bottom container
        Friend Function GetBottomContainerRectangle() As Rectangle
            Return New Rectangle(0, _
                                 Me.ButtonsPanel.Height - Me.Renderer.ButtonHeight, _
                                 Me.Width, _
                                 Me.Renderer.ButtonHeight)
        End Function

        ' Gets the rectangle that makes up the small button bottom container, except the small buttons themselves
        Friend Function GetEmptyBottomContainerRectangle() As Rectangle
            Dim rect As Rectangle = Me.GetBottomContainerRectangle
            rect.Width = Me.Width - (_MaxSmallButtonCount * Me.Renderer.SmallButtonWidth) - Me.GetDropDownRectangle.Width
            Return rect
        End Function

        ' Gets the rectangle that makes up the dropdown button on the right
        Friend Function GetDropDownRectangle() As Rectangle
            GetDropDownRectangle = New Rectangle(Me.Width - Me.Renderer.SmallButtonWidth, _
                                                 Me.ButtonsPanel.Height - Me.Renderer.ButtonHeight, _
                                                 Me.Renderer.SmallButtonWidth, _
                                                 Me.Renderer.ButtonHeight)
        End Function

        ' Gets the rectangle that makes up the grip bar
        Friend Function GetGripRectangle() As Rectangle
            Dim Height As Integer = Me.Renderer.GripHeight
            Return New Rectangle(0, 0, Me.Width, Height)
        End Function

#End Region

#End Region

#Region " Nested Classes "

        Friend Class OutlookBarItemCollectionEditor
            Inherits CollectionEditor

            Public Sub New(ByVal type As Type)
                MyBase.New(type)
            End Sub

            Protected Overrides Function CreateCollectionItemType() As System.Type
                Return GetType(OutlookBarItem)
            End Function

            Protected Overrides Function CreateInstance(ByVal itemType As System.Type) As Object
                If itemType Is GetType(OutlookBarItem) Then
                    ' Use the IDesignerHost service to create a new component
                    ' This way it's editable during design-time
                    Dim designerHost = DirectCast(Me.GetService(GetType(IDesignerHost)), IDesignerHost)
                    Dim panel = DirectCast(designerHost.CreateComponent(GetType(OutlookBarItem)), OutlookBarItem)
                    Dim bar = DirectCast(Me.Context.Instance, OutlookBar)

                    ' Also set some properties
                    panel.Owner = bar
                    panel.ButtonText = panel.Name
                    panel.Dock = DockStyle.Fill

                    Return panel
                End If

                Return MyBase.CreateInstance(itemType)
            End Function

        End Class


#End Region

    End Class
End Namespace