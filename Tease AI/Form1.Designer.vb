<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.domName = New System.Windows.Forms.TextBox()
        Me.chatBox = New System.Windows.Forms.TextBox()
        Me.mainPictureBox = New System.Windows.Forms.PictureBox()
        Me.domAvatar = New System.Windows.Forms.PictureBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CensorshipBar = New System.Windows.Forms.Panel()
        Me.LBLImageInfo = New System.Windows.Forms.Label()
        Me.DomWMP = New AxWMPLib.AxWindowsMediaPlayer()
        Me.PNLHope = New System.Windows.Forms.Panel()
        Me.MediaButton = New System.Windows.Forms.Button()
        Me.SettingsButton = New System.Windows.Forms.Button()
        Me.SaveBlogImage = New System.Windows.Forms.Button()
        Me.nextButton = New System.Windows.Forms.Button()
        Me.PNLChatBox = New System.Windows.Forms.Panel()
        Me.PNLMediaBar = New System.Windows.Forms.Panel()
        Me.ImageFolderComboBox = New System.Windows.Forms.ComboBox()
        Me.previousButton = New System.Windows.Forms.Button()
        Me.BTNLoadVideo = New System.Windows.Forms.Button()
        Me.BTNVideoControls = New System.Windows.Forms.Button()
        Me.browsefolderButton = New System.Windows.Forms.Button()
        Me.ChatText = New System.Windows.Forms.WebBrowser()
        Me.subName = New System.Windows.Forms.TextBox()
        Me.ScriptTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenScriptDialog = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.IsTypingTimer = New System.Windows.Forms.Timer(Me.components)
        Me.SendTimer = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.StrokeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StrokeTauntTimer = New System.Windows.Forms.Timer(Me.components)
        Me.DelayTimer = New System.Windows.Forms.Timer(Me.components)
        Me.CensorshipTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RLGLTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.UpdatesTimer = New System.Windows.Forms.Timer(Me.components)
        Me.GetColor = New System.Windows.Forms.ColorDialog()
        Me.sendButton = New System.Windows.Forms.Button()
        Me.AvoidTheEdge = New System.Windows.Forms.Timer(Me.components)
        Me.AvoidTheEdgeResume = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.WebImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.StrokePaceTimer = New System.Windows.Forms.Timer(Me.components)
        Me.EdgeTauntTimer = New System.Windows.Forms.Timer(Me.components)
        Me.HoldEdgeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.HoldEdgeTauntTimer = New System.Windows.Forms.Timer(Me.components)
        Me.PNLFileTransfer = New System.Windows.Forms.Panel()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.BTNFileTransferOpen = New System.Windows.Forms.Button()
        Me.BTNFIleTransferDismiss = New System.Windows.Forms.Button()
        Me.LBLFileTransfer = New System.Windows.Forms.Label()
        Me.PBFileTransfer = New System.Windows.Forms.ProgressBar()
        Me.SlideshowTimer = New System.Windows.Forms.Timer(Me.components)
        Me.EdgeCountTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StrokeTimeTotalTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TnASlides = New System.Windows.Forms.Timer(Me.components)
        Me.PNLTerms = New System.Windows.Forms.Panel()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.WaitTimer = New System.Windows.Forms.Timer(Me.components)
        Me.StupidTimer = New System.Windows.Forms.Timer(Me.components)
        Me.VideoTauntTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TeaseTimer = New System.Windows.Forms.Timer(Me.components)
        Me.RLGLTauntTimer = New System.Windows.Forms.Timer(Me.components)
        Me.AvoidTheEdgeTaunts = New System.Windows.Forms.Timer(Me.components)
        Me.subAvatar = New System.Windows.Forms.PictureBox()
        Me.PictureStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContactTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BTNShowHideApps = New System.Windows.Forms.Button()
        Me.AudibleMetronome = New System.Windows.Forms.Timer(Me.components)
        Me.StatusUpdates = New System.Windows.Forms.WebBrowser()
        Me.PNLGlitter = New System.Windows.Forms.Panel()
        Me.BWGlitter = New System.ComponentModel.BackgroundWorker()
        Me.CustomSlideshowTimer = New System.Windows.Forms.Timer(Me.components)
        Me.BWSlideshow = New System.ComponentModel.BackgroundWorker()
        Me.Contact1Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Contact2Timer = New System.Windows.Forms.Timer(Me.components)
        Me.Contact3Timer = New System.Windows.Forms.Timer(Me.components)
        Me.UpdateStageTimer = New System.Windows.Forms.Timer(Me.components)
        Me.WMPTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TeaseAINotify = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.TeaseAIMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.GamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SlotsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MatchGameToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RiskyPickToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExchangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CollectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MilovanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenBetaThreadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BugReportThreadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WebteasesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AllAndEverythingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DommeTimer = New System.Windows.Forms.Timer(Me.components)
        Me.TeaseAIClock = New System.Windows.Forms.Timer(Me.components)
        Me.LBLTime = New System.Windows.Forms.Label()
        Me.LBLDate = New System.Windows.Forms.Label()
        Me.LBLAMPM = New System.Windows.Forms.Label()
        Me.tmrResize = New System.Windows.Forms.Timer(Me.components)
        CType(Me.mainPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.domAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DomWMP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLHope.SuspendLayout()
        Me.PNLChatBox.SuspendLayout()
        Me.PNLMediaBar.SuspendLayout()
        Me.PNLFileTransfer.SuspendLayout()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PNLTerms.SuspendLayout()
        CType(Me.subAvatar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PictureStrip.SuspendLayout()
        Me.PNLGlitter.SuspendLayout()
        Me.TeaseAIMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'domName
        '
        Me.domName.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.domName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.domName.ForeColor = System.Drawing.Color.White
        Me.domName.Location = New System.Drawing.Point(10, 198)
        Me.domName.Name = "domName"
        Me.domName.Size = New System.Drawing.Size(250, 26)
        Me.domName.TabIndex = 2
        Me.domName.Text = "Domme Name"
        Me.domName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chatBox
        '
        Me.chatBox.Location = New System.Drawing.Point(3, 4)
        Me.chatBox.Name = "chatBox"
        Me.chatBox.Size = New System.Drawing.Size(768, 20)
        Me.chatBox.TabIndex = 1
        '
        'mainPictureBox
        '
        Me.mainPictureBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.mainPictureBox.BackColor = System.Drawing.Color.Black
        Me.mainPictureBox.Image = CType(resources.GetObject("mainPictureBox.Image"), System.Drawing.Image)
        Me.mainPictureBox.Location = New System.Drawing.Point(161, 0)
        Me.mainPictureBox.Name = "mainPictureBox"
        Me.mainPictureBox.Size = New System.Drawing.Size(1092, 741)
        Me.mainPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.mainPictureBox.TabIndex = 3
        Me.mainPictureBox.TabStop = False
        '
        'domAvatar
        '
        Me.domAvatar.BackColor = System.Drawing.Color.Black
        Me.domAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.domAvatar.Image = CType(resources.GetObject("domAvatar.Image"), System.Drawing.Image)
        Me.domAvatar.Location = New System.Drawing.Point(10, 12)
        Me.domAvatar.Name = "domAvatar"
        Me.domAvatar.Size = New System.Drawing.Size(250, 180)
        Me.domAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.domAvatar.TabIndex = 117
        Me.domAvatar.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.Black
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(271, 12)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.CensorshipBar)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LBLImageInfo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.mainPictureBox)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DomWMP)
        Me.SplitContainer1.Panel1MinSize = 180
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.SplitContainer1.Panel2.Controls.Add(Me.PNLHope)
        Me.SplitContainer1.Panel2.Controls.Add(Me.nextButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PNLChatBox)
        Me.SplitContainer1.Panel2.Controls.Add(Me.PNLMediaBar)
        Me.SplitContainer1.Panel2.Controls.Add(Me.previousButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BTNLoadVideo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.BTNVideoControls)
        Me.SplitContainer1.Panel2.Controls.Add(Me.browsefolderButton)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ChatText)
        Me.SplitContainer1.Panel2MinSize = 208
        Me.SplitContainer1.Size = New System.Drawing.Size(1092, 988)
        Me.SplitContainer1.SplitterDistance = 734
        Me.SplitContainer1.TabIndex = 136
        '
        'CensorshipBar
        '
        Me.CensorshipBar.BackColor = System.Drawing.Color.Black
        Me.CensorshipBar.BackgroundImage = CType(resources.GetObject("CensorshipBar.BackgroundImage"), System.Drawing.Image)
        Me.CensorshipBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CensorshipBar.Location = New System.Drawing.Point(360, 400)
        Me.CensorshipBar.Name = "CensorshipBar"
        Me.CensorshipBar.Size = New System.Drawing.Size(637, 244)
        Me.CensorshipBar.TabIndex = 94
        Me.CensorshipBar.Visible = False
        '
        'LBLImageInfo
        '
        Me.LBLImageInfo.AutoSize = True
        Me.LBLImageInfo.BackColor = System.Drawing.Color.Black
        Me.LBLImageInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLImageInfo.ForeColor = System.Drawing.Color.White
        Me.LBLImageInfo.Location = New System.Drawing.Point(0, 0)
        Me.LBLImageInfo.Name = "LBLImageInfo"
        Me.LBLImageInfo.Size = New System.Drawing.Size(0, 17)
        Me.LBLImageInfo.TabIndex = 95
        Me.LBLImageInfo.Visible = False
        '
        'DomWMP
        '
        Me.DomWMP.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.DomWMP.Enabled = True
        Me.DomWMP.Location = New System.Drawing.Point(161, 0)
        Me.DomWMP.Name = "DomWMP"
        Me.DomWMP.OcxState = CType(resources.GetObject("DomWMP.OcxState"), System.Windows.Forms.AxHost.State)
        Me.DomWMP.Size = New System.Drawing.Size(1089, 788)
        Me.DomWMP.TabIndex = 96
        Me.DomWMP.Visible = False
        '
        'PNLHope
        '
        Me.PNLHope.Controls.Add(Me.MediaButton)
        Me.PNLHope.Controls.Add(Me.SettingsButton)
        Me.PNLHope.Controls.Add(Me.SaveBlogImage)
        Me.PNLHope.Location = New System.Drawing.Point(779, 213)
        Me.PNLHope.Name = "PNLHope"
        Me.PNLHope.Size = New System.Drawing.Size(314, 35)
        Me.PNLHope.TabIndex = 781
        '
        'MediaButton
        '
        Me.MediaButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.MediaButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.MediaButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MediaButton.ForeColor = System.Drawing.Color.White
        Me.MediaButton.Location = New System.Drawing.Point(0, 0)
        Me.MediaButton.Name = "MediaButton"
        Me.MediaButton.Size = New System.Drawing.Size(112, 35)
        Me.MediaButton.TabIndex = 147
        Me.MediaButton.Text = "Hide Media Panel"
        Me.MediaButton.UseVisualStyleBackColor = False
        '
        'SettingsButton
        '
        Me.SettingsButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.SettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SettingsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SettingsButton.ForeColor = System.Drawing.Color.White
        Me.SettingsButton.Location = New System.Drawing.Point(190, 0)
        Me.SettingsButton.Name = "SettingsButton"
        Me.SettingsButton.Size = New System.Drawing.Size(123, 35)
        Me.SettingsButton.TabIndex = 19
        Me.SettingsButton.Text = "Open Settings Menu"
        Me.SettingsButton.UseVisualStyleBackColor = False
        '
        'SaveBlogImage
        '
        Me.SaveBlogImage.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.SaveBlogImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveBlogImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SaveBlogImage.ForeColor = System.Drawing.Color.White
        Me.SaveBlogImage.Location = New System.Drawing.Point(114, 0)
        Me.SaveBlogImage.Name = "SaveBlogImage"
        Me.SaveBlogImage.Size = New System.Drawing.Size(74, 35)
        Me.SaveBlogImage.TabIndex = 149
        Me.SaveBlogImage.Text = "Img <-> Vid"
        Me.SaveBlogImage.UseVisualStyleBackColor = False
        '
        'nextButton
        '
        Me.nextButton.BackColor = System.Drawing.Color.SteelBlue
        Me.nextButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.nextButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nextButton.ForeColor = System.Drawing.Color.White
        Me.nextButton.Location = New System.Drawing.Point(836, -4)
        Me.nextButton.Name = "nextButton"
        Me.nextButton.Size = New System.Drawing.Size(55, 35)
        Me.nextButton.TabIndex = 7
        Me.nextButton.Text = ">>"
        Me.nextButton.UseVisualStyleBackColor = False
        '
        'PNLChatBox
        '
        Me.PNLChatBox.Controls.Add(Me.chatBox)
        Me.PNLChatBox.Location = New System.Drawing.Point(-1, 214)
        Me.PNLChatBox.Name = "PNLChatBox"
        Me.PNLChatBox.Size = New System.Drawing.Size(777, 32)
        Me.PNLChatBox.TabIndex = 150
        '
        'PNLMediaBar
        '
        Me.PNLMediaBar.Controls.Add(Me.ImageFolderComboBox)
        Me.PNLMediaBar.Location = New System.Drawing.Point(51, -1)
        Me.PNLMediaBar.Name = "PNLMediaBar"
        Me.PNLMediaBar.Size = New System.Drawing.Size(726, 31)
        Me.PNLMediaBar.TabIndex = 97
        '
        'ImageFolderComboBox
        '
        Me.ImageFolderComboBox.BackColor = System.Drawing.Color.White
        Me.ImageFolderComboBox.ForeColor = System.Drawing.Color.Black
        Me.ImageFolderComboBox.FormattingEnabled = True
        Me.ImageFolderComboBox.Location = New System.Drawing.Point(6, 5)
        Me.ImageFolderComboBox.Name = "ImageFolderComboBox"
        Me.ImageFolderComboBox.Size = New System.Drawing.Size(716, 21)
        Me.ImageFolderComboBox.TabIndex = 8
        Me.ImageFolderComboBox.Text = "Enter Image Directory"
        '
        'previousButton
        '
        Me.previousButton.BackColor = System.Drawing.Color.SteelBlue
        Me.previousButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.previousButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.previousButton.ForeColor = System.Drawing.Color.White
        Me.previousButton.Location = New System.Drawing.Point(779, -4)
        Me.previousButton.Name = "previousButton"
        Me.previousButton.Size = New System.Drawing.Size(55, 35)
        Me.previousButton.TabIndex = 6
        Me.previousButton.Text = "<<"
        Me.previousButton.UseVisualStyleBackColor = False
        '
        'BTNLoadVideo
        '
        Me.BTNLoadVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.BTNLoadVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNLoadVideo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNLoadVideo.ForeColor = System.Drawing.Color.White
        Me.BTNLoadVideo.Location = New System.Drawing.Point(893, -4)
        Me.BTNLoadVideo.Name = "BTNLoadVideo"
        Me.BTNLoadVideo.Size = New System.Drawing.Size(74, 35)
        Me.BTNLoadVideo.TabIndex = 11
        Me.BTNLoadVideo.Text = "Load Video"
        Me.BTNLoadVideo.UseVisualStyleBackColor = False
        '
        'BTNVideoControls
        '
        Me.BTNVideoControls.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.BTNVideoControls.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNVideoControls.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNVideoControls.ForeColor = System.Drawing.Color.White
        Me.BTNVideoControls.Location = New System.Drawing.Point(969, -4)
        Me.BTNVideoControls.Name = "BTNVideoControls"
        Me.BTNVideoControls.Size = New System.Drawing.Size(119, 35)
        Me.BTNVideoControls.TabIndex = 15
        Me.BTNVideoControls.Text = "Show Video Controls"
        Me.BTNVideoControls.UseVisualStyleBackColor = False
        '
        'browsefolderButton
        '
        Me.browsefolderButton.BackColor = System.Drawing.Color.SteelBlue
        Me.browsefolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.browsefolderButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.browsefolderButton.ForeColor = System.Drawing.Color.White
        Me.browsefolderButton.Location = New System.Drawing.Point(-2, -4)
        Me.browsefolderButton.Name = "browsefolderButton"
        Me.browsefolderButton.Size = New System.Drawing.Size(53, 35)
        Me.browsefolderButton.TabIndex = 3
        Me.browsefolderButton.Text = "Browse"
        Me.browsefolderButton.UseVisualStyleBackColor = False
        '
        'ChatText
        '
        Me.ChatText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ChatText.Location = New System.Drawing.Point(0, 29)
        Me.ChatText.MinimumSize = New System.Drawing.Size(2, 20)
        Me.ChatText.Name = "ChatText"
        Me.ChatText.Size = New System.Drawing.Size(1089, 185)
        Me.ChatText.TabIndex = 1
        '
        'subName
        '
        Me.subName.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.subName.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.subName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.subName.ForeColor = System.Drawing.Color.White
        Me.subName.Location = New System.Drawing.Point(10, 977)
        Me.subName.Name = "subName"
        Me.subName.ShortcutsEnabled = False
        Me.subName.Size = New System.Drawing.Size(250, 23)
        Me.subName.TabIndex = 3
        Me.subName.Text = "Your Name"
        Me.subName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ScriptTimer
        '
        Me.ScriptTimer.Interval = 1000
        '
        'OpenScriptDialog
        '
        Me.OpenScriptDialog.Filter = "TXT Files (*.txt)|*.txt"
        Me.OpenScriptDialog.Title = "Please select a script"
        '
        'Timer1
        '
        Me.Timer1.Interval = 110
        '
        'IsTypingTimer
        '
        Me.IsTypingTimer.Interval = 110
        '
        'SendTimer
        '
        Me.SendTimer.Interval = 110
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog1"
        Me.OpenFileDialog2.Filter = "All files (*.*)|*.*"
        Me.OpenFileDialog2.Title = "Select an image file"
        '
        'StrokeTimer
        '
        Me.StrokeTimer.Interval = 1000
        '
        'StrokeTauntTimer
        '
        Me.StrokeTauntTimer.Interval = 1000
        '
        'DelayTimer
        '
        Me.DelayTimer.Interval = 1000
        '
        'CensorshipTimer
        '
        Me.CensorshipTimer.Interval = 1000
        '
        'RLGLTimer
        '
        Me.RLGLTimer.Interval = 1000
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All file" & _
    "s (*.*)|*.*"
        Me.OpenFileDialog1.Title = "Select an image file"
        '
        'UpdatesTimer
        '
        Me.UpdatesTimer.Interval = 1000
        '
        'GetColor
        '
        Me.GetColor.Color = System.Drawing.Color.SteelBlue
        '
        'sendButton
        '
        Me.sendButton.BackColor = System.Drawing.Color.SteelBlue
        Me.sendButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sendButton.ForeColor = System.Drawing.Color.White
        Me.sendButton.Location = New System.Drawing.Point(-51, 509)
        Me.sendButton.Name = "sendButton"
        Me.sendButton.Size = New System.Drawing.Size(50, 24)
        Me.sendButton.TabIndex = 147
        Me.sendButton.Text = "SEND"
        Me.sendButton.UseVisualStyleBackColor = False
        '
        'AvoidTheEdge
        '
        Me.AvoidTheEdge.Interval = 1000
        '
        'AvoidTheEdgeResume
        '
        Me.AvoidTheEdgeResume.Interval = 1000
        '
        'WebImageFileDialog
        '
        Me.WebImageFileDialog.Filter = "TXT Files (*.txt)|*.txt"
        Me.WebImageFileDialog.Title = "Please select an Image Blog URL File"
        '
        'StrokePaceTimer
        '
        Me.StrokePaceTimer.Interval = 30
        '
        'EdgeTauntTimer
        '
        Me.EdgeTauntTimer.Interval = 1000
        '
        'HoldEdgeTimer
        '
        Me.HoldEdgeTimer.Interval = 1000
        '
        'HoldEdgeTauntTimer
        '
        Me.HoldEdgeTauntTimer.Interval = 1000
        '
        'PNLFileTransfer
        '
        Me.PNLFileTransfer.BackColor = System.Drawing.Color.White
        Me.PNLFileTransfer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PNLFileTransfer.Controls.Add(Me.PictureBox11)
        Me.PNLFileTransfer.Controls.Add(Me.BTNFileTransferOpen)
        Me.PNLFileTransfer.Controls.Add(Me.BTNFIleTransferDismiss)
        Me.PNLFileTransfer.Controls.Add(Me.LBLFileTransfer)
        Me.PNLFileTransfer.Controls.Add(Me.PBFileTransfer)
        Me.PNLFileTransfer.Location = New System.Drawing.Point(10, 12)
        Me.PNLFileTransfer.Name = "PNLFileTransfer"
        Me.PNLFileTransfer.Size = New System.Drawing.Size(250, 180)
        Me.PNLFileTransfer.TabIndex = 157
        Me.PNLFileTransfer.Visible = False
        '
        'PictureBox11
        '
        Me.PictureBox11.ErrorImage = Nothing
        Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
        Me.PictureBox11.Location = New System.Drawing.Point(27, 29)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(195, 88)
        Me.PictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.PictureBox11.TabIndex = 128
        Me.PictureBox11.TabStop = False
        '
        'BTNFileTransferOpen
        '
        Me.BTNFileTransferOpen.Location = New System.Drawing.Point(27, 145)
        Me.BTNFileTransferOpen.Name = "BTNFileTransferOpen"
        Me.BTNFileTransferOpen.Size = New System.Drawing.Size(95, 23)
        Me.BTNFileTransferOpen.TabIndex = 127
        Me.BTNFileTransferOpen.Text = "Open File"
        Me.BTNFileTransferOpen.UseVisualStyleBackColor = True
        '
        'BTNFIleTransferDismiss
        '
        Me.BTNFIleTransferDismiss.Location = New System.Drawing.Point(127, 145)
        Me.BTNFIleTransferDismiss.Name = "BTNFIleTransferDismiss"
        Me.BTNFIleTransferDismiss.Size = New System.Drawing.Size(95, 23)
        Me.BTNFIleTransferDismiss.TabIndex = 126
        Me.BTNFIleTransferDismiss.Text = "Dismiss"
        Me.BTNFIleTransferDismiss.UseVisualStyleBackColor = True
        '
        'LBLFileTransfer
        '
        Me.LBLFileTransfer.Location = New System.Drawing.Point(3, 2)
        Me.LBLFileTransfer.Name = "LBLFileTransfer"
        Me.LBLFileTransfer.Size = New System.Drawing.Size(244, 24)
        Me.LBLFileTransfer.TabIndex = 125
        Me.LBLFileTransfer.Text = "Mistress Name is sending you a file!"
        Me.LBLFileTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PBFileTransfer
        '
        Me.PBFileTransfer.Location = New System.Drawing.Point(27, 123)
        Me.PBFileTransfer.Maximum = 3
        Me.PBFileTransfer.Name = "PBFileTransfer"
        Me.PBFileTransfer.Size = New System.Drawing.Size(195, 13)
        Me.PBFileTransfer.TabIndex = 0
        '
        'SlideshowTimer
        '
        Me.SlideshowTimer.Interval = 1000
        '
        'EdgeCountTimer
        '
        Me.EdgeCountTimer.Interval = 1000
        '
        'StrokeTimeTotalTimer
        '
        Me.StrokeTimeTotalTimer.Interval = 1000
        '
        'TnASlides
        '
        Me.TnASlides.Interval = 334
        '
        'PNLTerms
        '
        Me.PNLTerms.BackColor = System.Drawing.Color.LightGray
        Me.PNLTerms.Controls.Add(Me.Label86)
        Me.PNLTerms.Controls.Add(Me.Label85)
        Me.PNLTerms.Location = New System.Drawing.Point(0, 0)
        Me.PNLTerms.Name = "PNLTerms"
        Me.PNLTerms.Size = New System.Drawing.Size(1378, 1044)
        Me.PNLTerms.TabIndex = 162
        '
        'Label86
        '
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.ForeColor = System.Drawing.Color.Black
        Me.Label86.Location = New System.Drawing.Point(269, 41)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(545, 527)
        Me.Label86.TabIndex = 1
        Me.Label86.Text = resources.GetString("Label86.Text")
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label85.ForeColor = System.Drawing.Color.Black
        Me.Label85.Location = New System.Drawing.Point(269, 4)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(545, 37)
        Me.Label85.TabIndex = 0
        Me.Label85.Text = "Please read the following carefully!"
        '
        'WaitTimer
        '
        Me.WaitTimer.Interval = 1000
        '
        'StupidTimer
        '
        Me.StupidTimer.Interval = 1000
        '
        'VideoTauntTimer
        '
        Me.VideoTauntTimer.Interval = 1000
        '
        'TeaseTimer
        '
        Me.TeaseTimer.Interval = 1000
        '
        'RLGLTauntTimer
        '
        Me.RLGLTauntTimer.Interval = 1000
        '
        'AvoidTheEdgeTaunts
        '
        Me.AvoidTheEdgeTaunts.Interval = 1000
        '
        'subAvatar
        '
        Me.subAvatar.BackColor = System.Drawing.Color.Black
        Me.subAvatar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.subAvatar.Image = CType(resources.GetObject("subAvatar.Image"), System.Drawing.Image)
        Me.subAvatar.Location = New System.Drawing.Point(17, 673)
        Me.subAvatar.Name = "subAvatar"
        Me.subAvatar.Size = New System.Drawing.Size(250, 180)
        Me.subAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.subAvatar.TabIndex = 118
        Me.subAvatar.TabStop = False
        '
        'PictureStrip
        '
        Me.PictureStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem5, Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3, Me.ToolStripMenuItem4})
        Me.PictureStrip.Name = "PictureStrip"
        Me.PictureStrip.Size = New System.Drawing.Size(194, 114)
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItem5.Text = "Copy Image Location"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItem1.Text = "Save Image"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItem2.Text = "Like This Image"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItem3.Text = "Dislike This Image"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(193, 22)
        Me.ToolStripMenuItem4.Text = "Remove From URL File"
        '
        'ContactTimer
        '
        Me.ContactTimer.Interval = 1000
        '
        'BTNShowHideApps
        '
        Me.BTNShowHideApps.BackColor = System.Drawing.Color.SteelBlue
        Me.BTNShowHideApps.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNShowHideApps.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue
        Me.BTNShowHideApps.FlatAppearance.BorderSize = 0
        Me.BTNShowHideApps.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.BTNShowHideApps.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.BTNShowHideApps.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTNShowHideApps.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNShowHideApps.ForeColor = System.Drawing.Color.White
        Me.BTNShowHideApps.Location = New System.Drawing.Point(17, 639)
        Me.BTNShowHideApps.Name = "BTNShowHideApps"
        Me.BTNShowHideApps.Size = New System.Drawing.Size(250, 24)
        Me.BTNShowHideApps.TabIndex = 163
        Me.BTNShowHideApps.Text = "Hide Apps"
        Me.BTNShowHideApps.UseVisualStyleBackColor = False
        '
        'AudibleMetronome
        '
        Me.AudibleMetronome.Interval = 30
        '
        'StatusUpdates
        '
        Me.StatusUpdates.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.StatusUpdates.Location = New System.Drawing.Point(0, 0)
        Me.StatusUpdates.MinimumSize = New System.Drawing.Size(20, 20)
        Me.StatusUpdates.Name = "StatusUpdates"
        Me.StatusUpdates.Size = New System.Drawing.Size(250, 167)
        Me.StatusUpdates.TabIndex = 770
        '
        'PNLGlitter
        '
        Me.PNLGlitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PNLGlitter.Controls.Add(Me.StatusUpdates)
        Me.PNLGlitter.Location = New System.Drawing.Point(10, 296)
        Me.PNLGlitter.Name = "PNLGlitter"
        Me.PNLGlitter.Size = New System.Drawing.Size(250, 172)
        Me.PNLGlitter.TabIndex = 770
        '
        'CustomSlideshowTimer
        '
        Me.CustomSlideshowTimer.Interval = 1000
        '
        'BWSlideshow
        '
        '
        'Contact1Timer
        '
        Me.Contact1Timer.Interval = 1000
        '
        'Contact2Timer
        '
        Me.Contact2Timer.Interval = 1000
        '
        'Contact3Timer
        '
        Me.Contact3Timer.Interval = 1000
        '
        'UpdateStageTimer
        '
        Me.UpdateStageTimer.Interval = 1000
        '
        'WMPTimer
        '
        Me.WMPTimer.Interval = 1000
        '
        'TeaseAINotify
        '
        Me.TeaseAINotify.BalloonTipTitle = "Tease AI"
        Me.TeaseAINotify.ContextMenuStrip = Me.TeaseAIMenu
        Me.TeaseAINotify.Icon = CType(resources.GetObject("TeaseAINotify.Icon"), System.Drawing.Icon)
        Me.TeaseAINotify.Text = "Tease AI"
        Me.TeaseAINotify.Visible = True
        '
        'TeaseAIMenu
        '
        Me.TeaseAIMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GamesToolStripMenuItem, Me.MilovanaToolStripMenuItem, Me.ToolStripMenuItem7, Me.ExitToolStripMenuItem})
        Me.TeaseAIMenu.Name = "TeaseAIMenu"
        Me.TeaseAIMenu.Size = New System.Drawing.Size(155, 92)
        Me.TeaseAIMenu.Text = "Tease AI"
        '
        'GamesToolStripMenuItem
        '
        Me.GamesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SlotsToolStripMenuItem, Me.MatchGameToolStripMenuItem, Me.RiskyPickToolStripMenuItem, Me.ExchangeToolStripMenuItem, Me.CollectionToolStripMenuItem})
        Me.GamesToolStripMenuItem.Name = "GamesToolStripMenuItem"
        Me.GamesToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.GamesToolStripMenuItem.Text = "Games"
        '
        'SlotsToolStripMenuItem
        '
        Me.SlotsToolStripMenuItem.Name = "SlotsToolStripMenuItem"
        Me.SlotsToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.SlotsToolStripMenuItem.Text = "Slots"
        '
        'MatchGameToolStripMenuItem
        '
        Me.MatchGameToolStripMenuItem.Name = "MatchGameToolStripMenuItem"
        Me.MatchGameToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.MatchGameToolStripMenuItem.Text = "Match Game"
        '
        'RiskyPickToolStripMenuItem
        '
        Me.RiskyPickToolStripMenuItem.Name = "RiskyPickToolStripMenuItem"
        Me.RiskyPickToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.RiskyPickToolStripMenuItem.Text = "Risky Pick"
        '
        'ExchangeToolStripMenuItem
        '
        Me.ExchangeToolStripMenuItem.Name = "ExchangeToolStripMenuItem"
        Me.ExchangeToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.ExchangeToolStripMenuItem.Text = "Exchange"
        '
        'CollectionToolStripMenuItem
        '
        Me.CollectionToolStripMenuItem.Name = "CollectionToolStripMenuItem"
        Me.CollectionToolStripMenuItem.Size = New System.Drawing.Size(142, 22)
        Me.CollectionToolStripMenuItem.Text = "Collection"
        '
        'MilovanaToolStripMenuItem
        '
        Me.MilovanaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenBetaThreadToolStripMenuItem, Me.BugReportThreadToolStripMenuItem, Me.WebteasesToolStripMenuItem, Me.AllAndEverythingToolStripMenuItem})
        Me.MilovanaToolStripMenuItem.Name = "MilovanaToolStripMenuItem"
        Me.MilovanaToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.MilovanaToolStripMenuItem.Text = "Milovana"
        '
        'OpenBetaThreadToolStripMenuItem
        '
        Me.OpenBetaThreadToolStripMenuItem.Name = "OpenBetaThreadToolStripMenuItem"
        Me.OpenBetaThreadToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.OpenBetaThreadToolStripMenuItem.Text = "Open Beta Thread"
        '
        'BugReportThreadToolStripMenuItem
        '
        Me.BugReportThreadToolStripMenuItem.Name = "BugReportThreadToolStripMenuItem"
        Me.BugReportThreadToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.BugReportThreadToolStripMenuItem.Text = "Bug Report Thread"
        '
        'WebteasesToolStripMenuItem
        '
        Me.WebteasesToolStripMenuItem.Name = "WebteasesToolStripMenuItem"
        Me.WebteasesToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.WebteasesToolStripMenuItem.Text = "Webteases"
        '
        'AllAndEverythingToolStripMenuItem
        '
        Me.AllAndEverythingToolStripMenuItem.Name = "AllAndEverythingToolStripMenuItem"
        Me.AllAndEverythingToolStripMenuItem.Size = New System.Drawing.Size(173, 22)
        Me.AllAndEverythingToolStripMenuItem.Text = "Forum"
        '
        'ToolStripMenuItem7
        '
        Me.ToolStripMenuItem7.Name = "ToolStripMenuItem7"
        Me.ToolStripMenuItem7.Size = New System.Drawing.Size(154, 22)
        Me.ToolStripMenuItem7.Text = "________________"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(154, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'DommeTimer
        '
        Me.DommeTimer.Interval = 1000
        '
        'TeaseAIClock
        '
        Me.TeaseAIClock.Interval = 1000
        '
        'LBLTime
        '
        Me.LBLTime.BackColor = System.Drawing.Color.Transparent
        Me.LBLTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLTime.ForeColor = System.Drawing.Color.White
        Me.LBLTime.Location = New System.Drawing.Point(10, 232)
        Me.LBLTime.Name = "LBLTime"
        Me.LBLTime.Size = New System.Drawing.Size(250, 36)
        Me.LBLTime.TabIndex = 771
        Me.LBLTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBLDate
        '
        Me.LBLDate.BackColor = System.Drawing.Color.Transparent
        Me.LBLDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLDate.ForeColor = System.Drawing.Color.White
        Me.LBLDate.Location = New System.Drawing.Point(12, 269)
        Me.LBLDate.Name = "LBLDate"
        Me.LBLDate.Size = New System.Drawing.Size(248, 21)
        Me.LBLDate.TabIndex = 772
        Me.LBLDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LBLAMPM
        '
        Me.LBLAMPM.BackColor = System.Drawing.Color.Transparent
        Me.LBLAMPM.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBLAMPM.ForeColor = System.Drawing.Color.White
        Me.LBLAMPM.Location = New System.Drawing.Point(173, 243)
        Me.LBLAMPM.Name = "LBLAMPM"
        Me.LBLAMPM.Size = New System.Drawing.Size(40, 24)
        Me.LBLAMPM.TabIndex = 773
        Me.LBLAMPM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrResize
        '
        Me.tmrResize.Interval = 250
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1374, 1012)
        Me.Controls.Add(Me.PNLTerms)
        Me.Controls.Add(Me.LBLAMPM)
        Me.Controls.Add(Me.LBLDate)
        Me.Controls.Add(Me.LBLTime)
        Me.Controls.Add(Me.PNLGlitter)
        Me.Controls.Add(Me.PNLFileTransfer)
        Me.Controls.Add(Me.domName)
        Me.Controls.Add(Me.subAvatar)
        Me.Controls.Add(Me.domAvatar)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.subName)
        Me.Controls.Add(Me.sendButton)
        Me.Controls.Add(Me.BTNShowHideApps)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimumSize = New System.Drawing.Size(978, 734)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tease A.I. - PATCH 47"
        CType(Me.mainPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.domAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DomWMP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLHope.ResumeLayout(False)
        Me.PNLChatBox.ResumeLayout(False)
        Me.PNLChatBox.PerformLayout()
        Me.PNLMediaBar.ResumeLayout(False)
        Me.PNLFileTransfer.ResumeLayout(False)
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PNLTerms.ResumeLayout(False)
        Me.PNLTerms.PerformLayout()
        CType(Me.subAvatar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PictureStrip.ResumeLayout(False)
        Me.PNLGlitter.ResumeLayout(False)
        Me.TeaseAIMenu.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents domName As System.Windows.Forms.TextBox
    Friend WithEvents chatBox As System.Windows.Forms.TextBox
    Friend WithEvents mainPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents domAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents nextButton As System.Windows.Forms.Button
    Friend WithEvents browsefolderButton As System.Windows.Forms.Button
    Friend WithEvents previousButton As System.Windows.Forms.Button
    Friend WithEvents subName As System.Windows.Forms.TextBox
    Friend WithEvents ChatText As System.Windows.Forms.WebBrowser
    Friend WithEvents ScriptTimer As System.Windows.Forms.Timer
    Friend WithEvents OpenScriptDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents IsTypingTimer As System.Windows.Forms.Timer
    Friend WithEvents SendTimer As System.Windows.Forms.Timer
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StrokeTimer As System.Windows.Forms.Timer
    Friend WithEvents StrokeTauntTimer As System.Windows.Forms.Timer
    Friend WithEvents DelayTimer As System.Windows.Forms.Timer
    Friend WithEvents SettingsButton As System.Windows.Forms.Button
    Friend WithEvents CensorshipBar As System.Windows.Forms.Panel
    Friend WithEvents CensorshipTimer As System.Windows.Forms.Timer
    Friend WithEvents RLGLTimer As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents BTNLoadVideo As System.Windows.Forms.Button
    Friend WithEvents BTNVideoControls As System.Windows.Forms.Button
    Friend WithEvents UpdatesTimer As System.Windows.Forms.Timer
    Friend WithEvents GetColor As System.Windows.Forms.ColorDialog
    Friend WithEvents MediaButton As System.Windows.Forms.Button
    Friend WithEvents sendButton As System.Windows.Forms.Button
    Friend WithEvents AvoidTheEdge As System.Windows.Forms.Timer
    Friend WithEvents AvoidTheEdgeResume As System.Windows.Forms.Timer
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveBlogImage As System.Windows.Forms.Button
    Friend WithEvents WebImageFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StrokePaceTimer As System.Windows.Forms.Timer
    Friend WithEvents EdgeTauntTimer As System.Windows.Forms.Timer
    Friend WithEvents HoldEdgeTimer As System.Windows.Forms.Timer
    Friend WithEvents HoldEdgeTauntTimer As System.Windows.Forms.Timer
    Friend WithEvents PNLFileTransfer As System.Windows.Forms.Panel
    Friend WithEvents LBLFileTransfer As System.Windows.Forms.Label
    Friend WithEvents PBFileTransfer As System.Windows.Forms.ProgressBar
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents BTNFileTransferOpen As System.Windows.Forms.Button
    Friend WithEvents BTNFIleTransferDismiss As System.Windows.Forms.Button
    Friend WithEvents SlideshowTimer As System.Windows.Forms.Timer
    Friend WithEvents EdgeCountTimer As System.Windows.Forms.Timer
    Friend WithEvents StrokeTimeTotalTimer As System.Windows.Forms.Timer
    Friend WithEvents TnASlides As System.Windows.Forms.Timer
    Friend WithEvents PNLTerms As System.Windows.Forms.Panel
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Label85 As System.Windows.Forms.Label
    Friend WithEvents ImageFolderComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents LBLImageInfo As System.Windows.Forms.Label
    Friend WithEvents DomWMP As AxWMPLib.AxWindowsMediaPlayer
    Friend WithEvents WaitTimer As System.Windows.Forms.Timer
    Friend WithEvents StupidTimer As System.Windows.Forms.Timer
    Friend WithEvents VideoTauntTimer As System.Windows.Forms.Timer
    Friend WithEvents TeaseTimer As System.Windows.Forms.Timer
    Friend WithEvents RLGLTauntTimer As System.Windows.Forms.Timer
    Friend WithEvents AvoidTheEdgeTaunts As System.Windows.Forms.Timer
    Friend WithEvents subAvatar As System.Windows.Forms.PictureBox
    Friend WithEvents PNLChatBox As System.Windows.Forms.Panel
    Friend WithEvents PictureStrip As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContactTimer As System.Windows.Forms.Timer
    Friend WithEvents BTNShowHideApps As System.Windows.Forms.Button
    Friend WithEvents AudibleMetronome As System.Windows.Forms.Timer
    Friend WithEvents StatusUpdates As System.Windows.Forms.WebBrowser
    Friend WithEvents PNLGlitter As System.Windows.Forms.Panel
    Friend WithEvents BWGlitter As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomSlideshowTimer As System.Windows.Forms.Timer
    Friend WithEvents BWSlideshow As System.ComponentModel.BackgroundWorker
    Friend WithEvents Contact1Timer As System.Windows.Forms.Timer
    Friend WithEvents Contact2Timer As System.Windows.Forms.Timer
    Friend WithEvents Contact3Timer As System.Windows.Forms.Timer
    Friend WithEvents UpdateStageTimer As System.Windows.Forms.Timer
    Friend WithEvents WMPTimer As System.Windows.Forms.Timer
    Friend WithEvents TeaseAINotify As System.Windows.Forms.NotifyIcon
    Friend WithEvents TeaseAIMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents GamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SlotsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MatchGameToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RiskyPickToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExchangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CollectionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem7 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MilovanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenBetaThreadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BugReportThreadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WebteasesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AllAndEverythingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DommeTimer As System.Windows.Forms.Timer
    Friend WithEvents PNLMediaBar As System.Windows.Forms.Panel
    Friend WithEvents PNLHope As System.Windows.Forms.Panel
    Friend WithEvents TeaseAIClock As System.Windows.Forms.Timer
    Friend WithEvents LBLTime As System.Windows.Forms.Label
    Friend WithEvents LBLDate As System.Windows.Forms.Label
    Friend WithEvents LBLAMPM As System.Windows.Forms.Label
    Friend WithEvents tmrResize As System.Windows.Forms.Timer

End Class
