'===========================================================================================
'
'                                           MySettings
'
' This file contains functions to extend the mySettings-Object with the capabilities to
' store and load the current user.config-file to/from a designated filepath.
' 
' The Local usersetting-file is duplicated when it's altered into a subdirectory of the 
' application. 
' If no user.config is found on startup in the %LocalAppData%-dir, the duplicated file
' is copied into the directory.
' If on startup neither the original nor the duplicated file is found, a DataUpgrade
' form previous versions is tried to be perform.
'
' For safely importing Setting-files from other versions there is also an importfunction 
' included. This funciton will ask the user to select a file to import and restarts the 
' application in order to process the import and data-upgrade.
'
'
' To use those functions add a reference to System.Configuration and call StartupCheck() 
' in the my.Application.StartUp-Eventhandler.
' 
'===========================================================================================
Imports System.ComponentModel
Imports System.Configuration
Imports System.IO

Namespace My

    Partial Class MySettings



		''' <summary>
		''' Determins the path the path to store and load the user.config-file from/to.
		''' </summary>
		Private Shared BackupDir As String = Application.Info.DirectoryPath & "\System\Settings\"
#Region "-------------------------------------- Save timer ----------------------------------------------"
		''' <summary>
		''' TimerObject to delay the saving of settings-file on changing 
		''' </summary>
		Private WithEvents Savetimer As New Timer With {.Interval = 1000 * 30}
		''' <summary>
		''' Starts the saving delayed on property changing
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub Savetimer_Tick(sender As Object, e As EventArgs) Handles Savetimer.Tick
			On Error GoTo Error_All
			Save()

			If Directory.Exists(Path.GetDirectoryName(LocalAppFilePath)) _
			And fswLocalAppData.EnableRaisingEvents = False Then
				fswLocalAppData.Path = Path.GetDirectoryName(LocalAppFilePath)
				fswLocalAppData.EnableRaisingEvents = True
			End If

			Savetimer.Stop()
			Exit Sub
Error_All:
		End Sub
#End Region ' SaveTimer
		' Automated Setting File duplicating is currently deactivated, because of a threading issue
#Region "-------------------------------- AppDir FileSystemwatcher --------------------------------------"
		Dim dupeThread As Threading.Thread = Nothing
		Sub delayedDuplicate()
			Threading.Thread.Sleep(50)

			Duplicate()
		End Sub

		Private WithEvents fswLocalAppData As New FileSystemWatcher With
			{
				.EnableRaisingEvents = False,
				.IncludeSubdirectories = False
			}


		Private Sub fswLocalAppData_Changed(sender As Object, e As FileSystemEventArgs) Handles fswLocalAppData.Changed, fswLocalAppData.Renamed
			If e.FullPath <> LocalAppFilePath Then Exit Sub

			If dupeThread Is Nothing OrElse dupeThread.IsAlive = False Then
				dupeThread = New Threading.Thread(AddressOf delayedDuplicate) With {.Name = "DupeSettings", .IsBackground = True}
				dupeThread.Start()
			End If

		End Sub


#End Region


		''' =========================================================================================================
		''' <summary>
		''' Procedure to check whether to load or import a custom user.config-file. 
		''' </summary>
		Friend Shared Sub StartupCheck()
            Dim importSettingFile As String = Application.CommandLineArgs.FirstOrDefault(Function(x) x.StartsWith("ImportSettings-"))

			If importSettingFile IsNot Nothing Then
				importConfig(importSettingFile)
			Else
				loadCustomUserConfig()
			End If
		End Sub

        ''' =========================================================================================================
        ''' <summary>
        ''' Replace the user.config-file located in %LocalAppData% with the duplicated filöe.
        ''' </summary>
        Private Shared Sub loadCustomUserConfig()
            Try
				Dim configAppData As String = LocalAppFilePath()
				Dim configAppDataDir As String = Path.GetDirectoryName(configAppData)

                Dim dupeFilePath As String = GetDuplicatePath()
                Dim dupeFileDir As String = Path.GetDirectoryName(dupeFilePath)

				If Directory.Exists(configAppDataDir) And File.Exists(configAppData) Then
					' Config in %LocalAppData% older found.
					Exit Sub
				ElseIf Directory.Exists(dupeFileDir) AndAlso File.Exists(dupeFilePath) Then
					' No Config in %LocalAppData% Folder found but found backup

					'check if the directory in %LocalAppData% exits and create it if not
					If Directory.Exists(configAppDataDir) = False Then _
								Directory.CreateDirectory(configAppDataDir)

                    ' Copy the duplicated file to %LoaclAppData%-Dir.
                    File.Copy(dupeFilePath, configAppData, True)
				ElseIf Directory.Exists(configAppDataDir) = False Then
					' No settings Found, try an Upgrade if there a Version in %LocaAppDir%
					My.Settings.Upgrade()
				End If
            Catch ex As Exception
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                '                                            All Errors
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                MsgBox("Exception on loading custom-user.config." & vbCrLf & ex.Message,
                       MsgBoxStyle.Exclamation, "Load user.config")
                Log.WriteError(ex.Message, ex, "Exception on loading custom-user.config.")
            End Try
        End Sub

#Region "---------------------------------------MyBaseRelated--------------------------------------------"

		Private _loaded As Boolean = False

		Protected Overrides Sub OnSettingsLoaded(sender As Object, e As SettingsLoadedEventArgs)
			MyBase.OnSettingsLoaded(sender, e)

			_loaded = False
		End Sub

		Protected Overrides Sub OnPropertyChanged(sender As Object, e As PropertyChangedEventArgs)
			MyBase.OnPropertyChanged(sender, e)
			If Savetimer.Enabled = False And _loaded = True Then Savetimer.Start()
		End Sub

		''' =========================================================================================================
		''' <summary>
		''' Raises the SettingsSaving Event and copies afterwards the File to the 
		''' specific filepath.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Protected Overrides Sub OnSettingsSaving(sender As Object, e As CancelEventArgs)
			MyBase.OnSettingsSaving(sender, e)
		End Sub

		Shadows Sub Reset()
			fswLocalAppData.EnableRaisingEvents = False
			_loaded = False

			Dim dupeFilePath As String = GetDuplicatePath()

            If Directory.Exists(BackupDir) = True AndAlso File.Exists(dupeFilePath) Then
                File.Delete(dupeFilePath)
            End If

			MyBase.Reset()

			_loaded = True
			fswLocalAppData.EnableRaisingEvents = True
		End Sub


#End Region ' MyBaseRelated

#Region "------------------------------------ General Functions -----------------------------------------"

		''' <summary>
		''' SyncLocked Member. Do not access direct.
		''' </summary>
		Shared _LocalAppFilePath As String = ""

		Shared _LocalAppFilePathSyncLock As New Object

		''' =========================================================================================================
		''' <summary>
		''' Returns the current user.config-file path.
		''' </summary>
		''' <returns>A String representing the path to the current user.config-file.</returns>
		Private Shared ReadOnly Property LocalAppFilePath As String
			Get
				SyncLock _LocalAppFilePathSyncLock
					If _LocalAppFilePath = "" Then
						Dim roamingConfig As Configuration =
							ConfigurationManager.OpenExeConfiguration(
							ConfigurationUserLevel.PerUserRoamingAndLocal)

						_LocalAppFilePath = roamingConfig.FilePath
					End If

					Return _LocalAppFilePath
				End SyncLock
			End Get
		End Property


		Friend Shared Function GetDuplicatePath() As String

            ' get the Filepath 
            Dim SettingsFilePath As String = LocalAppFilePath
			Dim TargetPath As String = BackupDir & Application.Info.Version.ToString & "." & Path.GetFileName(SettingsFilePath)

            Return TargetPath
        End Function



		Friend Sub Duplicate()
			Try
				Dim configAppDataPath As String = LocalAppFilePath()
				Dim dupeFilePath As String = GetDuplicatePath()

                ' Check if Directory and file to copy exist.
                If Directory.Exists(Path.GetDirectoryName(configAppDataPath)) _
				AndAlso File.Exists(configAppDataPath) Then

                    ' Create Traget directoy if needed.
                    If Directory.Exists(BackupDir) = False Then _
					Directory.CreateDirectory(BackupDir)

                    ' Copy File
                    My.Computer.FileSystem.CopyFile(configAppDataPath, dupeFilePath, True)
				End If
			Catch ex As Exception
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                '                                            All Errors
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                Log.WriteError(ex.Message, ex, "Exception while duplicating user.config.")
			End Try
		End Sub

#End Region ' General functions 

#Region "---------------------------------------- Import file -------------------------------------------"

		''' =========================================================================================================
		''' <summary>
		''' Asks the user for an user-contig file to import. If a file is selected, the current application
		''' is hard-stopped and restarted with new CommandLine Args. Existing CommandLineArgs are overwritten.
		''' </summary>
		Friend Shared Sub importOnRestart()
            Try
				Dim fs As New OpenFileDialog With
				{.Filter = "config|*.config",
				.Multiselect = False,
				.Title = "Select config file to import.",
				.InitialDirectory = BackupDir}

				If fs.ShowDialog = DialogResult.OK And fs.FileName <> "" And File.Exists(fs.FileName) Then
                    ' Restart the application with new Start-parameters
                    Dim startInfo As New ProcessStartInfo()
                    startInfo.FileName = Reflection.Assembly.GetExecutingAssembly().CodeBase
                    startInfo.Arguments = "ImportSettings-""" & fs.FileName & """"

                    If MessageBox.Show("Do you want to import the setting from file: " & vbCrLf &
                                       fs.FileName & vbCrLf &
                                        "If you continue, the program will restart and load the specified config-file. " &
                                        "This will overwrite your current settings. " & vbCrLf & vbCrLf &
                                        "Would you like to continue?",
                                       "Import Settings",
                                       MessageBoxButtons.OKCancel,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) = DialogResult.OK Then

                        Process.Start(startInfo)
                        Process.GetCurrentProcess().Kill()
                    End If
                End If
            Catch ex As Win32Exception When ex.ErrorCode = -2147467259
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                '                                      Process.Start() cancelled
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                MsgBox("Import has benn cancelled.", MsgBoxStyle.Information)
            Catch ex As Exception
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                '                                            All Errors
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                Log.WriteError(ex.Message, ex, "Exception while determining the import file.")
                MsgBox("An exception occured while determining the import file: " &
                       ex.Message, MsgBoxStyle.Exclamation, "Exception occured")
            End Try
        End Sub

        ''' =========================================================================================================
        ''' <summary>
        ''' Performs an Upgrade from a given UserConfig.file.
        ''' </summary>
        ''' <param name="filepath">The File to import.</param>
        ''' <remarks>In order to perform and upgrade, a pseudo-Version-number is calculated. This
        ''' Version-number is 1 step smaller as the current version. This calculated Version-number is
        ''' used to create a new version-folder in the %LocalAppData%-Folder. If there is already
        ''' another folder with this Version Number the user has to confirm overwriting. </remarks>
        Private Shared Sub importConfig(ByVal filepath As String)
            Try
                If filepath = Nothing Then Exit Sub

                Dim fileToLoad As String = filepath.Replace("ImportSettings-", "")

                If File.Exists(fileToLoad) Then
                    '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                    '                     Calculate-Previous-Version-Start 
                    '▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼▼
                    Dim splitVersion() As String = Application.Info.Version.ToString.Split(".")
                    Dim calcVersion As New List(Of Integer)
					Dim copyRest As Boolean = False

					For i = splitVersion.Count - 1 To 0 Step -1
                        Dim currNumber As Integer = Integer.Parse(splitVersion(i))
                        Dim prevNumber As Integer = currNumber - 1

						If copyRest Then
							' Calculated a non-negative number before Copy rest
							calcVersion.Insert(0, currNumber)
						ElseIf prevNumber = -1 And i <> 0 Then
							' Number was 0 => convert to 9999 if not Major Number
							calcVersion.Insert(0, 9999)
						ElseIf prevNumber < currNumber
                            ' Number is smaller than the current Number => Copy rest of Numbers
                            copyRest = True
							calcVersion.Insert(0, prevNumber)
						Else
							Throw New ArgumentException("Unknown case while calculation previous Version.")
                        End If
                    Next

                    Dim prevVersion As New Version(String.Join(".", calcVersion))

                    If prevVersion >= Application.Info.Version Then
                        Throw New ArithmeticException("The calculated version number is not smaller than the current.")
                    End If
                    '▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲
                    '    Calculate-Previous-Version-END 
                    '▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲▲

                    ' Get directory path for the current user.config-file.
                    Dim ImportDir As String = Path.GetDirectoryName(LocalAppFilePath)

                    ' Determine the destination directory 
                    ImportDir = Path.GetDirectoryName(ImportDir) & "\" & prevVersion.ToString & "\"

                    ' Extract the filename, if something changes over time
                    Dim targetFile As String = Path.GetFileName(LocalAppFilePath)

                    ' Ask for confirmation if there is already a directory.
                    If Directory.Exists(ImportDir) Then
                        If MsgBox("There is already a directory '""" & ImportDir &
                                """ if you continue, the content in this directory " &
                                " will be overriden. " & vbCrLf &
                                "Do you wish to overwrite the content?",
                                  MsgBoxStyle.YesNo, "Overwrite Content") = MsgBoxResult.No Then
                            MsgBox("Import has been cancelled.", MsgBoxStyle.Information, "Import")
                            Exit Sub
                        End If
                    End If

                    ' Create target directory 
                    Directory.CreateDirectory(ImportDir)

                    ' Copy the file to import
                    File.Copy(fileToLoad, ImportDir & targetFile, True)

                    ' Perform a Settings-Upgrade.
                    My.Settings.Upgrade()

                    ' Delete directory and all content
                    Directory.Delete(ImportDir, True)

					MsgBox("The settings have been successfully imported", MsgBoxStyle.Information, "Import Settings")
				End If

            Catch ex As Exception
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                '                                            All Errors
                '▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨▨
                Log.WriteError(ex.Message, ex, "Import settings")
                MsgBox("An exception occured while importing settings: " & vbCrLf & ex.Message,
                       MsgBoxStyle.Exclamation, "Import settings")
            End Try
        End Sub

#End Region  ' Import file

		''' =========================================================================================================
		''' <summary>
		''' Resets a field using a databound control.
		''' </summary>
		''' <param name="cntl">The databound control, containing the databinding.</param>
		''' <param name="prop">The controls databound property to reset.</param>
		Friend Sub ResetField(ByVal cntl As Control, prop As String)
			Try
				Dim bindingField As String = cntl.DataBindings.Item(prop).BindingMemberInfo.BindingField
				My.Settings(bindingField) = My.Settings.PropertyValues(bindingField).Property.DefaultValue
			Catch ex As Exception
				Throw
			End Try
		End Sub
		''' =========================================================================================================
		''' <summary>
		''' Returns the initial value for a databound field using a databound control.
		''' </summary>
		''' <param name="cntl">The databound control, containing the databinding.</param>
		''' <param name="prop">The controls databound property.</param>
		Friend Function GetDefault(ByVal cntl As Control, prop As String) As String
			Try
				Dim bindingField As String = cntl.DataBindings.Item(prop).BindingMemberInfo.BindingField
				Return My.Settings.PropertyValues(bindingField).Property.DefaultValue
			Catch ex As Exception
				Throw
			End Try
		End Function

	End Class
End Namespace