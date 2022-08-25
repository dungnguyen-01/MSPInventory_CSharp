

Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class NavigationPaneOptionsForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.GroupBox1 = New System.Windows.Forms.GroupBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.CancelButton = New System.Windows.Forms.Button
            Me.OKButton = New System.Windows.Forms.Button
            Me.UpButton = New System.Windows.Forms.Button
            Me.DownButton = New System.Windows.Forms.Button
            Me.ResetButton = New System.Windows.Forms.Button
            Me.ItemList = New System.Windows.Forms.CheckedListBox
            Me.SuspendLayout()
            '
            'GroupBox1
            '
            Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.GroupBox1.Location = New System.Drawing.Point(83, 15)
            Me.GroupBox1.Name = "GroupBox1"
            Me.GroupBox1.Size = New System.Drawing.Size(222, 2)
            Me.GroupBox1.TabIndex = 0
            Me.GroupBox1.TabStop = False
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(5, 9)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(136, 13)
            Me.Label1.TabIndex = 1
            Me.Label1.Text = "Display buttons in this order"
            '
            'CancelButton
            '
            Me.CancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.CancelButton.Location = New System.Drawing.Point(230, 179)
            Me.CancelButton.Name = "CancelButton"
            Me.CancelButton.Size = New System.Drawing.Size(75, 23)
            Me.CancelButton.TabIndex = 2
            Me.CancelButton.Text = "Cancel"
            Me.CancelButton.UseVisualStyleBackColor = True
            '
            'OKButton
            '
            Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OKButton.Location = New System.Drawing.Point(149, 179)
            Me.OKButton.Name = "OKButton"
            Me.OKButton.Size = New System.Drawing.Size(75, 23)
            Me.OKButton.TabIndex = 3
            Me.OKButton.Text = "OK"
            Me.OKButton.UseVisualStyleBackColor = True
            '
            'UpButton
            '
            Me.UpButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.UpButton.Enabled = False
            Me.UpButton.Location = New System.Drawing.Point(230, 34)
            Me.UpButton.Name = "UpButton"
            Me.UpButton.Size = New System.Drawing.Size(75, 23)
            Me.UpButton.TabIndex = 4
            Me.UpButton.Text = "Move Up"
            Me.UpButton.UseVisualStyleBackColor = True
            '
            'DownButton
            '
            Me.DownButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.DownButton.Enabled = False
            Me.DownButton.Location = New System.Drawing.Point(230, 63)
            Me.DownButton.Name = "DownButton"
            Me.DownButton.Size = New System.Drawing.Size(75, 23)
            Me.DownButton.TabIndex = 5
            Me.DownButton.Text = "Move Down"
            Me.DownButton.UseVisualStyleBackColor = True
            '
            'ResetButton
            '
            Me.ResetButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ResetButton.Location = New System.Drawing.Point(230, 135)
            Me.ResetButton.Name = "ResetButton"
            Me.ResetButton.Size = New System.Drawing.Size(75, 23)
            Me.ResetButton.TabIndex = 6
            Me.ResetButton.Text = "Reset"
            Me.ResetButton.UseVisualStyleBackColor = True
            '
            'ItemList
            '
            Me.ItemList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ItemList.Location = New System.Drawing.Point(12, 34)
            Me.ItemList.Name = "ItemList"
            Me.ItemList.ScrollAlwaysVisible = True
            Me.ItemList.Size = New System.Drawing.Size(212, 124)
            Me.ItemList.TabIndex = 7
            '
            'NavigationPaneOptionsForm
            '
            Me.AcceptButton = Me.OKButton
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(317, 214)
            Me.Controls.Add(Me.ItemList)
            Me.Controls.Add(Me.ResetButton)
            Me.Controls.Add(Me.DownButton)
            Me.Controls.Add(Me.UpButton)
            Me.Controls.Add(Me.OKButton)
            Me.Controls.Add(Me.CancelButton)
            Me.Controls.Add(Me.Label1)
            Me.Controls.Add(Me.GroupBox1)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "NavigationPaneOptionsForm"
            Me.Text = "Navigation Pane Options"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents CancelButton As System.Windows.Forms.Button
        Friend WithEvents OKButton As System.Windows.Forms.Button
        Friend WithEvents UpButton As System.Windows.Forms.Button
        Friend WithEvents DownButton As System.Windows.Forms.Button
        Friend WithEvents ResetButton As System.Windows.Forms.Button
        Friend WithEvents ItemList As System.Windows.Forms.CheckedListBox
    End Class
End Namespace