

Namespace Controls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class OutlookBar
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.pnlContent = New System.Windows.Forms.Panel
            Me.pnlButtons = New BufferedPanel
            Me.SuspendLayout()
            '
            'pnlContent
            '
            Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlContent.Location = New System.Drawing.Point(0, 0)
            Me.pnlContent.Name = "pnlContent"
            Me.pnlContent.Size = New System.Drawing.Size(201, 283)
            Me.pnlContent.TabIndex = 0
            '
            'pnlButtons
            '
            Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlButtons.Location = New System.Drawing.Point(0, 283)
            Me.pnlButtons.Name = "pnlButtons"
            Me.pnlButtons.Size = New System.Drawing.Size(201, 118)
            Me.pnlButtons.TabIndex = 0
            '
            'OutlookBar
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pnlContent)
            Me.Controls.Add(Me.pnlButtons)
            Me.Name = "OutlookBar"
            Me.Size = New System.Drawing.Size(201, 401)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pnlContent As System.Windows.Forms.Panel
        Friend WithEvents pnlButtons As BufferedPanel

    End Class
End Namespace