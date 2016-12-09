# Tease-AI
Tease AI is adult-oriented software that aims to create an interactive tease and denial experience by emulating an online chat session with a domme. 

# Todo:

Stefaf: Integration of Class myDirectory: Status ongoing.
	Testrun to sort Lists like Win-Explorer: initialized in v0.54.5.1
	
# Changelog - Patch 54.6.0

* Added Features:
	* Added new sorting method to sort file lists like the Windows file Explorer does.
	* PoundClean reworked to support system keywords as parameters inside vocabulary files. In order to prevent infinite loops, the maximum allowed depth is limited to 5 times. Tip: take a look at the logfile to see how it's working.
	* All Contacts and Domme are able to use @DommeTag(). Usage: @Contact2 Your text to display @DommeTag(Face, NotFeet)
	* Added nested @CallReturn()-support.

* Removed Features:
	* @DommeTag() doesn't alternate the given tags to return a result. (stefaf) The idea was worth a try. 
		
* Bugfixes:
	* After using an ImageCommand the slideshow was locked.
	* Filtering code was unable to handle parametrized command filters and image commands.
	* The slideshow folder check method forced to include slideshow subdirectories, even if the directory was valid. 
	* Vitalsub didn't read calorie items from file at startup.
	* MouseOver LblDomImagedir caused an unhandled exception.
	* RiskyPick Images haven't been updated.
	* Custom text tags (#TagGarment, #TagUnderwear etc.) for images fixed. Note: The new code will set data for the current displayed image and not leftover data from filtering, as in the old code. Make sure to set that data for your Images!
	* Multiple choice gotos inside MiniScripts caused the calling script to resume at the goto position of the MiniScript.

* Miscellaneous:
	* GUI-Rework Settings Glitter-Tab -> Databindings Complete.
	* Optimized performance of @ShowTaggedImage code.
	* Enhanced logging: It is now possible to customize the logging without the need to recompile. Simply open up Tease-AI.exe.config using a text editor and edit the switch values as described in the file - keep in mind to backup the file before. ;-) Added rollover function, if the log file is bigger as 2 MB. Instead of deleting the complete file, now only the top entries are deleted.
	* Chastity, Glitter and Taunt-files reworked to increase fault tolerance and correct line grouping. 2c588ffed4f03f17813d3e5bd290a3351b9bb8b2. It tries with a 45% chance to pick a 1-line-taunt. Otherwise it picks randomly from all available taunt sizes.

### Known Issues:
* Using a background image slows down GDI+ a lot.
* @BookmarkModule 
	* causes a script freeze at EOF, when taunts are interrupted. (Occured in Debug->Run Script)
	* seem to break if a miniscript (and maybe others) is called during the taunt.
	* Modes are not restored on returning.
* @CallReturn doesn't restore any of the modes. (@YesMode, @NoMode etc.)

	
# Changelog - Patch 54.5.0	

WIP - DataBinding Overhaul

Added Features: 

	Check Box to lock orgasm chances after tease starts. by OxiKlein
	Download online-image progress bar added.
	Video Folders are now checked on startup. The user is asked to search for missing folders.
	Image Folders are now checked on startup. The user is asked to search for missing folders or if a folder is empty.
	Games are now locked until all card images are set.
	Card images are now checked on startup.
	@Flag() support for multiple logical "AND" connected parameters added. Usage: @Flag(Flag1, Flag2, Flag3) => All of 'em or line is excluded.  by Daragorn
	@NotFlag() support for multiple logical "AND" connected parameters added. Usage: @NotFlag(Flag1, Flag2, Flag3) => None of 'em or line is excluded. by Daragorn
	Slideshow Settings(Random, NewFolder if last image, Range Settings, Subfolders) apply now also on Contact Images.
	Added a new debug window. It is now possible to view and manipulate all session variables (At least simple DataTypes) on Runtime.
	Now all filters have to be in Front of a @NullResponse or Chat Text. This is used to identify double used Filter/Command-statements.
	Added full screen mode.
    Bottom Chatbox is now accessible, when MaximizeMediaWindow is activated, unless Sidechat is activated.
    Restoring window state on start up supports now multi monitor systems and maximized windows.
    Added option to deactivate the sidepanel.


Bugfixes:

	@ImageTag()-Command displays now tagged images. Up to 3 Tags are allowed.
	Resolved an infinite loop, when TauntEdging was started.
	Goto was unable to jump to the first line of a file, when a question was asked.
	Card images were saved in different sizes, when using drag-drop or file dialog.
	@DommeLevel1-5 didn't filter correct in vocabulary files.
	@Chance##()-Command now gets cleaned from the line correctly.
	@FollowUp##()-Command now gets cleaned from the line correctly, also stopped the followup message from still partially showing in "failure" cases.
	Recent slideshow folders are now really checked on start-up and missing folders removed.
	Dom Mood settings were ignored.
	Fixed issue where a domme images was displayed, when a contact was responding.
	Fixed issue, where slideshows continued after @SlideshowOff. Now the CustomSlideshow-Timer checks if he is supposed to be running.
	Fixed command @GotoSlideshow. Now you can jump to a specific line based on the current slideshow-image.
	Program now attempts to separate filters from a line, fixing issues where Commands could incorrectly get interpreted as Filters.
	Fixed issue of loading CheckedListBox-States when swapping Personalities. Now there should be no need to delete StartLCheckist.cld EndCheckList.cld, LinkCheckedList.cld and EndCheckedList.cld anymore. Swapping personalities, editing, removing and renaming scriptfiles on runtime is possible.

Miscellaneous:

	Removed several unused variables.
	SettingsForm VideoSettings GUI reworked.
	SettingsForm ImageSettings GUI reworked.
	SettingsForm Apps-Games GUI reworked.
	Suspending/Resuming/Resetting Session reworked.
		Now all necessary data is stored into a single binary *.save file. This includes all Variables, Flags, Slideshows, TimerStates and regular Data. By Holding down the control key while clicking suspend or resume the user is asked for a custom file to save to or load from.
	Reworked Code to Display Images.
	Added a ToolstripItem in Debug menu, to start Timer1, if he is stopped. This could probably fix some or eventually all "Script-Freeze-Crashs". But this has to be tested. So if your Session freezes goto: Debug->Timers->Start Timer 1. Please let us know, if it worked.
	Reworked custom Slideshow. The slideshow will pick now random images from random genres (Only the ones defined in @Slideshow().). This way an unbalanced amount of images doesn't matter any more. All genres have the same chances, even if they are outnumbered by a million times. There is also a check if the last image was of the same genre. If that's the case, it will randomly use the same genre or tries to pick another one. 
	Reworked Main UI



# Changelog - Patch 54.4.0

Added Command @ChatImage[] - Displays a local image in the chat text itself, as opposed to the main picture window. Image locations specified in brackets are relative to [Tease AI Root Folder]\Images\, much like @ShowImage[]. For example:

     @ChatImage[1885\smile.jpg] - would display the image [Tease AI Root Folder]\Images\1885\smile.jpg on the domme's current line in chat.
	 
	 You can also use commas to force the pictures dimensions, using width then height. BOTH width and height must be specified if you use this function. For example:
	 
	 @ChatImage[1885\smile.jpg, 18, 18] - would display the image [Tease AI Root Folder]\Images\1885\smile.jpg resized to 18x18 on the domme's current line in chat.


Improved @Variable[] Command Filter - @Variable[] can now use "And" and "Or" when making comparisons. For example:

     @Variable[#SessionEdges]<[3]And[#SessionCBTCock]<[3] You know, I've barely made that #Cock suffer #GeneralTime
	 @Variable[#DomMood]>[#DomMoodMax]Or[#SubCockSize]>[8] I don't know what it is, but I feel really lucky #GeneralTime #Lol
	 @Variable[#DomLevel]=[5]And[#DomApathy]=[5]And[#DomOrgasmRate]=[Never] I love knowing I'm the cruelest bitch on the planet #Grin
	 
	 (For whatever reason I came up with three examples that all use System Keywords, but stored variables work as well)
	 
	 You can use as many "And" or "Or" comparisons per @Variable[] Command Filter that you like, but you CANNOT use both "And" and "Or" in the same @Variable[] Command Filter
	 
Fixes added from Community Members:

     
    Stefaf: Fixed TargetInvocationException, when loading an image and the fallback failed.
    Stefaf: Added Additional check, if the imagepath to load is empty/NULL. This is checked and logged before the Backgroundworker starts. This way we can track the source of this error better.
    Stefaf: Stretching landscape images applies to all images loaded with the designated Backgroundworker.
    Stefaf: Fixed if .net does not create the localAppData%-directory on start-up, the setting-file duplication is suspended until the settings are automatically saved for the first time. If here an exception occurs, it will be suspended until next time.
    Stefaf: Reworked Custom MainSlideshow. Merged redundant code. The image extensions are the global ones. Added check if a folder exists. Images are now loaded using the designated Backgroundworker.
    Stefaf: Fixed Custom timed slideshow. This was stepping 2 images forward instead of one. Images are loading with the designated Backgroundworker.
    Stefaf: Fixed Combobox for Custom slideshows was overwriting inputs like Control+C and stuff like that.
    Stefaf: Fixed when the CustomSlideshow fails to load, it was recognized as valid.
    Stefaf: Reworked time usage in logs. After introducing proper versioning, there is no need to a identify the assembly-version, using the filetime. All times in logs are now local times.
    Stefaf: Fixed IndexOutOfRangeException when clicking next or previous image button at the end or start of the slideshow.

	pepsifreak: BugFix: Lines with multiple commands containing parenthesis would always return the index of the first closing bracket when searching and cause an exception.

# Changelog - Patch 54.3.0

Improved @If[] Command - @If[] can now use "And" and "Or" when making comparisons. For example:

     @If[Var_EdgeCount]>[10]And[#DommeMood]>[#DomMoodMax]Then(GotoLine)
	 @If[Var_EdgeCount]<[3]Or[Var_TotalAttempts]>[5]Then(GotoLine)
	 @If[Var_EdgeCount]>[10]And[#DommeMood]>[@DomMoodMax]And[#CBTCockCount]<[1]Then(GotoLine)
	 
	 You can use as many "And" or "Or" comparisons per @If[] Command that you like, but you CANNOT use both "And" and "Or" in the same @If[] Command

   
Fixes added from Community Members:

	Stefaf: Bugfix where user.config was saved before the actual writing. This outdated file was taken on Startup to Replace the settings. Now the file is duplicated after modifications and the File located in %LocalAppData% won't be overwritten.

	Stefaf: Bugfix where Metronome was too slow, because it was played and afterwards the delay was waited. It's played now async and stopped before playing again.
	
	Stefaf: Bugfix where the Metronome was randomly not responding to SpeedChanges when the threads got out of sync.
   
    pepsifreak:  Settings Tagging Cleanup/Update - Domme Tags and Local Tags are now a single Tagging tab, with a tab control inside of that to switch between the two. Added 4 missing domme tags.

	pepsifreak:  Add new tags to fancier domme tagger - Tag buttons have also been shrunk down, resizing was updated to use anchors, and fixed a bug I was getting that caused a blank directory to be saved.
	
# Changelog - Patch 54.0.2

The code to parse @CheckDate() in the last patch contained syntax errors. It should now work correctly according to the usage established by the Command Guide  

Legacy Command @CheckBnB reinstated by checking for available Boobs and Butt pictures rather than the defunct "Enabled BnB Games" checkbox

Fixes added from Community Members:

    Stefaf: Bugfix freezing imageDownload caused by not serverside closed connection. Now the Connection is closed on clientside, if no data is received anymore.
	 
	Stefaf: Added automated ImageAnimation disabling, when a gif is displayed and the UI-Thread is not reponding.

    Stefaf: Improvement IO.Access
    Removed all My.Settings.Save() except after loading the application. Increased My.Settings autosavetime to 60 seconds. Now the application does not create the "ösldkflkm".newcfg files that much. Settings are still saved on regular application close.
	 
	Stefaf: Metronome is now loading the wav file into a memory-stream and plays it using a Media.Soundplayer. This way the file is not loaded again after startup unless an exception occurs. If so it will try to recover 120 times with a delay of a second in between. Positive side effect: now the metronome volume is adjustable with Tease-AI application and not System-Sounds any more.

    Stefaf: BugFix: Exceptions on Closing
	
	Stefaf: Added new ToolStripMenuitem to PictureStrip, to stop the current ImageAnimation
	
	Stefaf: Reworked PictureStrip The checks now on opening what type if image is displayed and shows Informations according the Image.
    
	Stefaf: Reworked Button behaviour Dislike and Like Image. Their check-state indicate now if an image is in a certain list. If they are checked and clicked, the current image will removed from the file.
	
# Changelog - Patch 54.1

BugFix: @ShowImage[] did not allow specified relative paths beginning with "\"

BugFix: StringClean did not get cleaned up correctly when @ShowImage[] was called	
	
 
# Changelog - Patch 54

Decreased the amount of time it takes for the domme to make her first Edging taunt by 15 seconds

BugFix: "Like This Image" and "Dislike This Image" disabled the wrong menu strip items when clicked

BugFix: @CheckDate() should now work correctly

BugFix: @LockImages didn't function when Glitter Contacts were in the room. It's now also performed after all @Show... Commands. 

BugFix: The program was filtering out @ShowImage type Commands in Linear acripts when @LockImages was activated, which goes against its function. It even prevented the lines from getting displayed in the first place. Added a Boolean to GetFilter to discern between filtering List or Linear type scripts

BugFix: "Edging Ends Taunts" was still being checked after the Taunt Cycle ended if the Module didn't call @StopStroking or @Edge  

BugFix: SYS_EdgeTotal wasn't being updated when EdgeMode edges were used

Added Command @ClearChat - Clears the main chat window and Side Chat

Fixed bug where Glitter Contacts would drop the last word of their sentences when the domme was out of the room

Side Chat now functions independently of other Apps. If Side Chat was active when another app was opened, then Side Chat will return on its own once that app is closed. 

Implemented Daragorn's Timed Writing Tasks feature. Timed Writing Tasks can be activated/deactivated in the Ranges settings tab. 

Added Button to WritingTasks panel that allows the user to open Side Chat directly from that panel. Also added checkbox to display how many lines/mistakes are remaining in chat during the writing task

Added optional Boolean overload to CommandClean() that CleanTaskLines uses to process Commands that would only be useful in lines for Task letters. This allows Task letters to now process the following Commands:

     @SetFlag(), @TempFlag(), @DeleteFlag(), @SetVar[], @ShowVar[], @ChangeVar[], @RoundVar[], @DeleteVar[], @SetDate()
	 @UpdateOrgasm, @UpdateRuined, @ChastityOn, @ChastityOff, @RestrictOrgasm(), @RestrictOrgasm, @PornAllowedOff, @PornAllowedOn 
	 @DecreaseOrgasmChance, @IncreaseOrgasmChance, @DecreaseRuinChance, @IncreaseRuinChance, 
	 @AddTokens(), @RemoveTokens(), all other Token related Commands

Added "Deny" overload to @Edge() Command. This simply lets the program know that the user was just denied an orgasm. Mostly useful for coordinating with end of tease Task letters

Added @CustomMode() Command and Mode Class - You can use @CustomMode to set any keyword or phrase to a mode that will move to a GotoLine in the script when used. The current types that @CustomMode can use are Goto and Video. For example:

     @CustomMode(I'm done, Goto, Finished Task) - This would move the script to the line (Finished Task) if the user types "I'm done" (not case sensitive)
	 @CustomMode(I saw boobs, Video, Video Closed) - This would stop a video and move to the line (Video Closed) if the user types "I saw boobs" (not case sensitive)

     Only one @CustomMode() Command should be used per line, but you may have as many custom modes activated at a time that you wish. Remember that individual Modes are cleared when they resolve, and all modes are cleared when transitioning between script types. To manually clear a mode, use @CustomMode(ModeText, Normal)	 
	 

Enhanced @CustomTask() Command and added Session Tasks settings in Ranges settings tab - Session tasks (@CBT, @CBTBalls, @CBTCock and @CustomTask()) no longer run for a random number of times. The number of times tasks run is now determined by the new settings in the Ranges settings tab for Session Tasks. For Custom Tasks, you may specify a specific amount of times to run the task using a comma. For example:

     @CustomTask(Spanking, 5) - This would run the Custom Task "Spanking" 5 times. This number includes the first instruction taken from "_First.txt
 
Fixed bug where Responses would get locked to [After Tease] lines if the domme continued a session after the orgasm decision

Fixed bug where Playlists did not move on to Link scripts after running Modules

Task overhaul tweaks

Major Tasks overhaul:

     Tasks should now function as originally intended
	 
	 Multiple uses of the same #Keyword will now produce different results
	 
	 Tasks are now filtered through the new routine which should greatly improve stability
	 
	 Task-related #Keywords should no longer return 0 as a value
	 
	 @RandomText() and @RT() can now be used in Task lines
	 
	 @SetFlag(), @TempFlag() and @DeleteFlag() can now be used in Task lines

     "Domme is sending you a file" window now displays correctly when Lazy Sub AV is active
	 
	 @Morning, @Afternoon and @Night Command Filters now filter more accurately relative to user's Daily Wake Up Time
  
     Task-related Ranges added to Ranges tab, corresponding to the following #KeyWords: #TaskStrokes, #TaskStrokingTime, #TaskEdges, #TaskHoldTheEdgeTime, #TaskCBTTime
	 
	 
New #Keywords added: #EdgeHold, #LongHold, #ExtremeHold

     Returns a random value based on the user's Sub settings, and automatically displays it as an amount of time in seconds, minutes and/or hours. 
	 
New #Keywords added: 
	#BlogImageCount
	#ButtImageCount
	#ButtsImageCount
	#BoobImageCount
	#BoobsImageCount
	 

Tease AI will now move to the next script type in the cycle if the current script has run out of lines

Added @Month() and @Day() to GetFilter(), I left them out by accident

Added Command @DeleteImage: This will remove the current image from all local Sources. (File system, URL-Files, LikedList, DislikedList, LocalImageTagList). But it won't delete an image located in the Domme- or Contacts-Image directory or one of it's subdirectories.

HandleScripts now uses GetFilter() the same way FilterList() does, code is much cleaner now

Added @LockVideo and @UnlockVideo Commands - @LockVideo will prevent Tease AI from switching back to the image window when a video ends. This is useful for times when you want to play multiple videos in a row for whatever reason without the domme slideshow popping up in between. @UnlockVideo will deactivate this mode and switch back to the image window when used.

Fixed bug where @SubOld and @SubYoung were not getting filtered correctly

Fixes added from Community Members:

    Stefaf: Bugfix ErrorImage was shown randomly if one of all imagegenres had no images.
	 
    Stefaf: Bugfix ContectMenu MainImageBox did not activate or deactivate the MenuItems correct.
	 
    Stefaf: Improvement: Remove from URL-File option in ContextMenu MainPicturebox removes a ImageUrl from all URL-Files.

	Stefaf: Function txt2List(String) was not able to deal path = "" or path = nothing. Improved Error handling and logging.
	
	Stefaf: Added Offline-Mode-Support to the ImageDataContainer-Class and fixed some minor bugs in it.
	
	Stefaf: All lists retrieved with functions in Class myDirectory are now sorted alphabetically.
	
	Stefaf: Added Feature: User-Settings are now saved in: "App-Directory\System\Settings\"
		[spoiler]The Local user.setting-file is duplicated on saving into the application-subdirectory.
		 On start-up this duplicated file is used to replace the user.config file in the 
		 %localAppData%-directory. For safely importing Setting-files from other versions 
		 there is also an import-function included. This function will ask you to select a file to 
		 import and restarts the application to process the import and data-upgrade.
		 To start the import go to Settings->General tab.
		[/spoiler]
	
	Stefaf: Commands @PornAllowedOff and @PornAllowedOn where not replaced correct in Domme Output.
	
	Stefaf: ImageCount-Keywords didn't count Images in URL-Files and none did neither react to OfflineMode nor @PornAllowedOff.
	
	Stefaf: #LocalImageCount didn't count local Butt and Boob Images.
	
	Stefaf: ImageDataContainer was searching Sub-folders instead of top level only and vice versa.
	
	Stefaf: GetGoto() was not able to jump to the first line of a script.
	
	Stefaf: ErrorImage has been shown randomly if one of all image-genres had no images.
	
	Stefaf: ContextMenu of MainImageBox did not activate or deactivate the MenuItems correct.
	
	Stefaf: Improvement: Remove from URL-File option in ContextMenu MainPicturebox now removes a ImageUrl from all URL-Files.
	
	Daragorn: BugFix: "Edging Ends Taunts" state wasn't reinitialized when Tease AI was reset
	
	Daragorn: Clean-up of 1885's implementation of Daragorn's original Timed Writing code
	
	Daragorn: BugFix: Some aspects of the program didn't pause when Settings Menu was open and "Pause Program When Settings Menu is Visible" wasn't checked
	
	Daragorn; BugFix: When Glitter contacts were present and an image was shown as part of a response, the image would immediately get replaced by a picture of the domme or contact
	
	Stefaf: BugFix and Cause... Remote Images where stored to the RootDirectory, if Save Blog Images From Session was deactivated. 
	
	Stefaf: Bugfix: @DeleteLocalImage was sometimes deleting the wrong image. It also removes the file from LikedList, DislikedList and  LocalImageTagList now.  But it won't delete an image located in the Domme- or Contacts-Image directory or one of it's subdirectories.
	
	Stefaf: Bugfix & Rework : @ShowImage[]
		[spoiler]- Added Logging. If an Error Occurs it is written to the logs. 
		- Fixed GetFile in Directory with filter.
		- Added new filter * -> This will give a result, from all available Image-Extensions.
		[/spoiler]
		
	Stefaf - Bugfix: BBnB is working now. (@TnAFastSlides, @TnASlowSlides, @TnASlides, @CheckTnA)
	
	Stefaf - Improvement: Added Logging if a custom vocabularyFile is missing. Now this will create a new Error-Log-Entry.
	
	Stefaf - Improvement: Removing an URL from an URL-File in SettingsWindow took way too long. Now it's faster.
	
	Stefaf - Imporvement: @ShowLocalImage() Now the ImageDataContainer-Class is used. It doesn't try to get an single image from a single random genre any more. Instead it tries to get a single image from all given genres.

	Stefaf - Improvement: Added logging at several points.
	
	Stefaf - Bugfix: 404 caused the Script to stop. Errors during ImageLoading will create now a LogEntry.
	
	Stefaf - Added Support for relative filepaths when using GenreImage-UrlFiles. Files outside the "Images\System\Url Files"-directory are neither included on Rebuild nor Refresh! But they are included in DeleteCommands.
The PropertyNames containing the URL-FilePaths have been renamed, in order to enhance readability. Those settings have to be reapplied. This will also prevent the use of wrong Url-Files, when the settings were imported.

	Stefaf - Improvement: Changed the way how UserSettings are stored. Now every(!) time a setting has changed, the settingsfile will be saved after a delay of one second(to keep disk traffic low).
	
	Stefaf - Improvement: Changed Labels for ImageURL-Files to readonly Textboxes. the Settings are now applied via DataBinding. Same on the ImageUrl-Checkboxes.
	
	

	
Conclusion List:
	
	[list]
	
	[*]#BlogImageCount	 -> 	Added: returns amount of Images
	
	[*]#BlowjobImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#BoobImageCount	 -> 	Added: returns amount of Images
	
	[*]#BoobsImageCount	 -> 	Added: returns amount of Images
	
	[*]#ButtImageCount	 -> 	Added: returns amount of Images
	
	[*]#ButtsImageCount	 -> 	Added: returns amount of Images
	
	[*]#CaptionsImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#DislikedImageCount	 -> 	Reworked: Reacts now to OfflineMode
	
	[*]#EdgeHold	 -> 	Added: Returns a random value based on the user's Sub settings
	
	[*]#ExtremeHold	 -> 	Added: Returns a random value based on the user's Sub settings
	
	[*]#FemdomImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#GayImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#GeneralImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#HardcoreImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#HentaiImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#LesbianImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#LezdomImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#LikedImageCount	 -> 	Reworked: Reacts now to OfflineMode
	
	[*]#LocalImageCount	 -> 	Added: returns amount of Images
	
	[*]#LongHold	 -> 	Added: Returns a random value based on the user's Sub settings
	
	[*]#MaledomImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#SoftcoreImageCount	 -> 	Reworked: Reacts now to URL-Files and OfflineMode
	
	[*]#TaskCBTTime	 -> 	Ranges added to Ranges tab
	
	[*]#TaskEdges	 -> 	Ranges added to Ranges tab
	
	[*]#TaskHoldTheEdgeTime	 -> 	Ranges added to Ranges tab
	
	[*]#TaskStrokes	 -> 	Ranges added to Ranges tab
	
	[*]#TaskStrokingTime	 -> 	Ranges added to Ranges tab
	
	[*]@AddTokens()	 -> 	usable in Tasks now
	
	[*]@Afternoon	 -> 	 better filtered to user's daily WakupTime
	
	[*]@CBT	 -> 	 no longer run for a random number of times in Tasks
	
	[*]@CBTBalls	 -> 	 no longer run for a random number of times in Tasks
	
	[*]@CBTCock	 -> 	 no longer run for a random number of times in Tasks
	
	[*]@ChangeVar[]	 -> 	usable in Tasks now
	
	[*]@ChastityOff	 -> 	usable in Tasks now
	
	[*]@ChastityOn	 -> 	usable in Tasks now
	
	[*]@CheckTnA	 -> 	Reworked and fixed.
	
	[*]@ClearChat	 -> 	New: Clears the main chat window and Side Chat
	
	[*]@CurrentImage	 -> 	Reworked
	
	[*]@CustomMode()	 -> 	New with  Available modes: Goto, Video
	
	[*]@CustomTask()	 -> 	Enhanced, added settings in Ranges-Tab
	
	[*]@Day()	 -> 	Filters now correct
	
	[*]@DecreaseOrgasmChance	 -> 	usable in Tasks now
	
	[*]@DecreaseRuinChance	 -> 	usable in Tasks now
	
	[*]@DeleteFlag()	 -> 	usable in Tasks now
	
	[*]@DeleteImage	 -> 	New: to remove URL-Links and Local Files from all Local Sources. Deletes no Domme or Contact files
	
	[*]@DeleteLocalImage	 -> 	Reworked. Removes now Links in LoacalImageTags.txt, LikedImage.txt, DislikedImages.txt. Deletes no Domme or Contact files
	
	[*]@DeleteVar[]	 -> 	usable in Tasks now
	
	[*]@Edge	 -> 	
	
	[*]@Edge()	 -> 	
	
	[*]@IncreaseOrgasmChance	 -> 	usable in Tasks now
	
	[*]@IncreaseRuinChance	 -> 	usable in Tasks now
	
	[*]@LockImages	 -> 	Fixed with Contacts, is performed after showing an image.
	
	[*]@LockVideo	 -> 	Added: will prevent Tease AI from switching back to the image window
	
	[*]@Month()	 -> 	Filters now correct
	
	[*]@Morning	 -> 	is better filtered to user's daily WakupTime
	
	[*]@NewBlogImage	 -> 	Reworked: does the same as @ShowBlogImage
	
	[*]@Night	 -> 	is better filtered to user's daily WakupTime
	
	[*]@PornAllowedOff	 -> 	Fixed: was not replaced correct in output.
	
	[*]@PornAllowedOn	 -> 	Fixed: was not replaced correct in output.
	
	[*]@RandomText()	 -> 	usable in Tasks now
	
	[*]@RemoveTokens()	 -> 	usable in Tasks now
	
	[*]@RestrictOrgasm	 -> 	usable in Tasks now
	
	[*]@RestrictOrgasm()	 -> 	usable in Tasks now
	
	[*]@RoundVar[]	 -> 	usable in Tasks now
	
	[*]@RT()	 -> 	usable in Tasks now
	
	[*]@SetDate()	 -> 	usable in Tasks now
	
	[*]@SetFlag()	 -> 	usable in Tasks now
	
	[*]@SetVar[]	 -> 	usable in Tasks now
	
	[*]@ShowBlogImage	 -> 	Reworked: Reacts now to OfflineMode
	
	[*]@ShowBlowjobImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowBoobImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowBoobsImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowButtImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowButtsImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowCaptionsImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowDislikedImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowFemdomImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowGayImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowGeneralImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowHardcoreImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowHentaiImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowImage[	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowImage[]	 -> 	Reworked: New Filter * for all available imagefiles, added logging
	
	[*]@ShowLesbianImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowLezdomImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowLikedImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowLocalImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowLocalImage(	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowLocalImage()	 -> 	Reworked: Won't show up an Errorimage anymore
	
	[*]@ShowMaledomImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowSoftcoreImage	 -> 	Reworked: uses OfflineMode, Displays Local and Remote Images syncronized with text
	
	[*]@ShowVar[]	 -> 	usable in Tasks now
	
	[*]@Slideshow()	 -> 	Reworked: uses OfflineMode, URL-Files, Displays Local and Remote Images syncronized with text
	
	[*]@StopStroking	 -> 	
	
	[*]@StopTnA	 -> 	Reworked and fixed.
	
	[*]@SubOld	 -> 	Filters now correct
	
	[*]@SubYoung	 -> 	Filters now correct
	
	[*]@TempFlag()	 -> 	usable in Tasks now
	
	[*]@TnAFastSlides	 -> 	Reworked and fixed.
	
	[*]@TnASlides	 -> 	Reworked and fixed.
	
	[*]@TnASlowSlides	 -> 	Reworked and fixed.
	
	[*]@UnlockVideo	 -> 	deactivates @LockVideo and shows the image window
	
	[*]@UpdateOrgasm	 -> 	usable in Tasks now
	
	[*]@UpdateRuined	 -> 	usable in Tasks now
	
	[/list]


	
# Changelog - Patch 53

Added check for empty string in MyDirectory Class

Removed extraneous GotoLine checks in GetGoto() and GetGotoChat()

New Temporary FilterList Sub - The old one has been renamed to FilterListBak. I did as much work as I could ()before passing out for the night) to get this back on par with the original FilterList while actually working like it's supposed to on multi-line taunts. This is a WIP of a temporary solution, but it should be no worse than the original FilterList. It should be better 

Added Command @ShowLocalImage() - Since genre image Commands such as @ShowLesbianImage, @ShowFemdomImage etc can now reference Local or URL Files, @ShowLocalImage() has been created to allow you to specify genre images in Local files only. You can use a comma to create a list to randomly choose from, or use not to show any Local image but the genres specified. For example:

     @ShowLocalImage(lesbian) - Show a local lesbian image
	 @ShowLocalImage(hentai, captions) - Show either a local hentai or captions image
	 @ShowLocalImage(not, captions) - Show any local image that is not a captions image
	 @ShowLocalImage(gay, maledom, not) - Show any local image that is not a gay or maledom image
	 


Fixes added from Community Members:

    Stefaf: Improvement ImageLoading 

    pepsifreak: SplitterDistance setting now resets if too big

	Stefaf: Bugfix: The Custom Slideshow randomly caused an IllegalCrossThreadCall, when the Slideshow was still running while the Domme is writing a Response.

	Stefaf: Bugfix: UI-didn't resize on maximizing the window.
	
	Stefaf: Bugfix: DommeTagApp wasn't working properly. It was randomly showing and setting the wrong Tags for the wrong image.
	
	Stefaf: Bugfix/Addon: Only CH-Videos did load .flv Files. Now all Video-genres can load .flv-Files.
	
	Stefaf: Bugfix: Hold the Edge Taunts returned "TeaseAI did not return a Hold the Edge Taunt" <--- Sorry guys and gals, that was my fault. (stefaf) 

	Stefaf: BugFix: @DommeTag() Didn't return the right picture, if the Task-Line contained a Keyword.
	 
	 
# Changelog - Patch 52

Fixed bug that caused Tease AI to delete "-" when it parsed lines, potentially messing up scripts

CheckGenreImage() bugfix - URL File checks were checking to see if Directory.Exists instead of File.Exists

Major Image Settings overhaul

     URL Files and Genre Images are now on two separate tabs
	 
	 Genre Images can now be set to URL Files as well as Local Directories for use with Commands like @ShowHardcoreImage, @ShowLesbianImage, etc
	 
	 URL List size greatly expanded
	 
	 Added preview window that shows a random image from a URL File whenever it is selected in the URL File List
	 
	 Added buttons to select all or none of the URL Files in the list
	 
	 
Session Images now save correctly when images have been pre-loaded

	 
	 
	 
Added @DecideOrgasm() Command - This Command will make the domme decide if and how the user can have an orgasm based on their domme settings. This works the same way as @DecideOrgasm. When @DecideOrgasm is used, the domme decides if the user will cum, ruin or be denied based on her domme settings. Depending on what she decides, @DecideOrgasm will either go to (Orgasm Allow), (Orgasm Ruin) or (Orgasm Deny). 

@DecideOrgasm() allows you to set the GotoLines for allowed, ruined and denied orgasms (specified in that order - Allowed GotoLine first, Ruined GotoLine second and Denied GotoLine third). For example:

     @DecideOrgasm(Allowed to Cum, Made to Ruin, Denied Orgasm) - In this case, if the domme has decided the user can cum, the script will move to (Allowed to Cum). If she decides to ruin, it will move to (Made to Ruin). And it will move to (Denied Orgasm) is she decides to deny. From there the next @Edge-related Command will end with an orgasm, ruined or denial depending on the domme's decision. 
	 
@DecideOrgasm() is extremely useful if you want to have more than one orgasm decision per script. This lets you set orgasm decision paths with different tones, such as having different reactions to the orgasm result based on the domme's mood

Added @Edge() Command - The @Edge() Command is used to indicate the user has been told by the domme to edge, just like @Edge currently does. However, @Edge() allows you to put any combination of the following modifiers in parentheses for different results when the user indicates they are on the edge:

     Hold - User will be told to hold it
	 NoHold - User will be told to stop stroking
	 Orgasm - User will be told to cum
	 Ruin - User will be told to ruin
	 RuinTaunts - Enables @RuinTaunt Command Filter (used in Edge.txt and HoldTheEdge.txt) for lines that taunt the user about the orgasm they're about to ruin
	 LongHold - User will be made to hold a long edge
	 ExtremeHold - User will be made to hold an extreme edge
	 HoldTaunts - Enables @LongHold or @ExtremeHold Taunts (used in Edge.txt and HoldTheEdge.txt) for lines that taunt the user about how long the edge they're about to hold/holding is going to be
	 
	 These Modifiers may be used in any combination:
	 
	 @Edge(Orgasm, NoHold) - User will be told to cum when they reach the edge
	 @Edge(Ruin, Hold) - User will be told to hold an edge, and afterwards told to ruin their orgasms
	 @Edge(Orgasm, LongHold, HoldTaunts) - User will be told to hold a long edge then allowed to cum; @LongHold Taunts will be active
	 
	 The program will disregard any combinations that don't make sense, such as:
	 
	 @Edge(Orgasm, Ruin) - The program disregards "Ruin" regardless of order
	 @Edge(Hold, NoHold) - The program disregards "Hold" regardless of order
	 @Edge(Hold, RuinTaunts) User will be told to hold the edge, @RuinTaunt Command Filters will not be activated as no Ruin modifier was included
	
Domme Tag methods reimplemented or enhanced in the following ways:

     "Fancy" domme tag creator brought back, under Tools on the main menu strip
	 
	 Main picture box now changes with the original domme tag creator
	 
	 Next and previous buttons added to Domme Tags App
	 
None of these are perfect solutions, but hopefully they'll mitigate the aggravation some until a better system can be developed

Fixed bug where @GoodMood(), @BadMood() and @NeutralMood() were being treated like Command Filters

Miniscripts can now be called from within Miniscripts. Should be able to stack these indefinitely Inception style. When any Miniscript ends, it will return to the point where the first MiniScript was called. 

Added @Month() Command Filter - will only display a line if the current month (represented by a number) matches what's in parentheses. You may enter as many options as you want. You may also use "Not" as a modifier. For example:

	@Month(11) - Will only display if the current month is November
	@Month(6, 7, 8) - Will only display if the current month is June, July or August
	@Month(Not, 4) - Will only display if the current month is not April
	@Month(4, 5, Not) - Will only display if the current month is not April or May
	
Added @Day() Command Filter - will only display a line if the current day of the month(1-31) matches what's in parentheses. You may enter as many options as you want. You may also use "Not" as a modifier. For example:

	@Day(15) - Will only display if it is he 15th
	@Day(1, 2, 3) - Will only display if it is the 1st, 2nd, or 3rd
	@Day(Not, 31) - Will only display if it is not the 31st
	@Day(1, 2, Not) - Will only display if it is not the 1st or 2nd
	
	
Together, @Month() and @Day() replace the Command Filters for @ValentinesDay, @ChristmasEve, @ChristmasDay, @NewYearsEve and @NewYearsDay (THese are now legacy Commands and will continue to function). Combining @MOnth() and @Day() allows you to accommodate any event without the need for a specific Command Filter for each one. For example

     @Month(12) @Day(25) Merry Christmas!
     @Month(10) @Day(31) Happy Halloween!
     @Month(5) @Day(4) May the Fourth be with you!
     @Crazy @Month(7) @Day(20) Did you know this is the anniversary of when they faked the moon landing? O.o @PlayAudio[X-Files_Theme.mp3]


Fixed bug that was making Taunt Cycles last slightly longer than they should have

Note - Here's the AI Box to go with the Edging Ends Taunts feature I just added:

Edit: That didn't work :(

Added "Edging Ends Taunts" setting to Ranges tab. This allows you to set the percentage chance that the domme will move to a module if you say you are on the edge. If you edge and the check fails, the domme will not let you stop or move into the next module until the set Stroke Time runs out - Requires 2 new vocabulary files - #SYS_TauntEdging.txt (Domme tells you that you can't stop yet) and #SYS_TauntEdgingAsked (Domme says she already told you what she wants for this Taunt cycle)

Added "Load New Slideshow When Finished" option to Slideshow Settings in General Settings tab. If this box is checked, Tease AI will load a new domme slideshow once it reaches the end of the current one through Tease or Timed progression.

Lines with @FollowUpXX() should now display correctly

Fixed bug where @ShowBoobsImage would return a butt image

The program no longer displays a messagebox when a #Keyword cannot be located. Now the #Keyword is highlighted in red in the chat window without any interruptions

Fixed bug where Glitter Contacts did not appear correctly during Multiple Edges they initiated


Fixes added from Community Members:
		
	Stefaf: Bugfix: @ShowBoobsImage() didn't work with local files.
	
    Stefaf: Bugfix: Error during CensorshipsSucks, if the window is not maximized

    Stefaf: BugFix: URL-File Exiting on 404 without writing the gathered data

    Stefaf: BugFix: Exception on selecting ScriptTabs
	
	Stefaf: Various Code Cleanup

	Stefaf: Bugfix StackOverflowException
		Added functionallity to prevent Timers from triggering oneself over and over again, while the TickEventHandler is running long procedures. 

    Stefaf: Bugfix image list not found (1885 Note: The code here is above my expertise, but it appears to fix crashes that would occur when Tease AI cannot locate Url Files, DislikedImageURLS or LikedImageURLS) 
	
	pepsifreak: Fixed end continue scripts
	     The first line would get cut off so you wouldn't actually know what to do
		 
	Stefaf: Stops Metronome during RLGL
         Now the Metronome will be stopped during Red light. Simplified Eventhandler RLGLTimer_Tick, for better maintainability	




# Changelog - Patch 51


@RandomText() Can now be used multiple times per line

Added @YesMode() Command - 

     @YesMode() allows you perform a specific action if the user enters one of their "Yes" words while YesMode is active. There are two ways to use @YesMode()
	 
	 @YesMode(Goto, GotoLine)
	 @YesMode(Video, GotoLine)
	 
	 Goto mode will go to the specified GotoLine if the user enters a Yes phrase
	 Video mode will stop a currently playing video if the user enters a Yes phrase and go to the specified GotoLine. If the video ends or is stopped first, the Video mode will be cleared and the script will move to the next line as usual

	 You can clear YesMode with @YesMode(Normal)  

Added @NoMode() Command - 

     @YesMode() allows you perform a specific action if the user enters one of their "No" words while YesMode is active. There are two ways to use @NoMode()
	 
	 @NoMode(Goto, GotoLine)
	 @NoMode(Video, GotoLine)
	 
	 Goto mode will go to the specified GotoLine if the user enters a No phrase
	 Video mode will stop a currently playing video if the user enters a No phrase and go to the specified GotoLine. If the video ends or is stopped first, the Video mode will be cleared and the script will move to the next line as usual

	 You can clear NoMode with @NoMode(Normal)  
	 
Added @CameMode() Command - 

     @CameMode() allows you perform a specific action if the user says one of the exact following expressions while CameMode is active: "Came", "I Came", "Just Came" or "I just came". Case doesn't matter, but Came mode will only pick up those four exact phrases. So "I just came" would activate it, "But I just came yesterday" would not. There are three ways to use @CameMode()
	 
	 @CameMode(Goto, GotoLine)
	 @CameMode(Video, GotoLine)
	 @CameMode(Message, MessageText)
	 
	 Goto mode will go to the specified GotoLine if the user enters one of the above phrases
	 Video mode will stop a currently playing video if the user enters one of the above phrases and go to the specified GotoLine. If the video ends or is stopped first, the Video mode will be cleared and the script will move to the next line as usual
	 Message mode will have the program process one of the above "I came" phrases as whatever text is specified as MessageText

	 You can clear CameMode with @CameMode(Normal)  	

Added @RuinedMode() Command - 

     @RuinedMode() allows you perform a specific action if the user says one of the exact following expressions while RuinedMode is active: "Ruined", "I Ruined", "Ruined it" or "I ruined it". Case doesn't matter, but Ruined mode will only pick up those four exact phrases. So "I ruined" would activate it, "I think I ruined my carpet" would not. There are three ways to use @RuinedMode()
	 
	 @RuinedMode(Goto, GotoLine)
	 @RuinedMode(Video, GotoLine)
	 @RuinedMode(Message, MessageText)
	 
	 Goto mode will go to the specified GotoLine if the user enters one of the above phrases
	 Video mode will stop a currently playing video if the user enters one of the above phrases and go to the specified GotoLine. If the video ends or is stopped first, the Video mode will be cleared and the script will move to the next line as usual
	 Message mode will have the program process one of the above "Ruined" phrases as whatever text is specified as MessageText

	 You can clear RuinedMode with @RuinedMode(Normal)  	 

Added Offline Mode to System States settings in the Misc tab. If you're using Tease AI without an internet connection, Offline Mode will automatically convert @ShowBlogImage Commands to @ShowLocalImage, as well as removing @ShowButtImage and @ShowBoobsImage Commands if they are set to URL Files. Toggling Tease AI to Offline Mode when you have no connectivity will help mitigate delays and crashes.
	

Fixed problems with @MultipleEdges() Command. I had  a couple of typos in the @MultipleEdges() Command Clean that was screwing up the whole thing. The scripts were also still progressing after each edge when they should not have been. Should be fixed now. Metronome should now react correctly to each edge as well

Fixed bug where wildcards were not returning correct file counts when using @PlayAudio[] or @PlayVideo[]

@ShowImage[] should now work with "\" or "/"

Added @Cup() Command Filter - will only display a line if the domme's cup size matches what's in parentheses. You may enter as many cup options as you want. You may also use "Not" as a modifier. For example:

	@Cup(C) - Will only display if the domme is a C cup
	@Cup(A, B) - Will only display if the domme is an A or B cup
	@Cup(Not, A) - Will only display if the domme is not an A Cup
	@Cup(DD, DDD+, Not) - Will only display if the domme is not a DD or DDD+ cup
	
	@Cup() replaces the Command Filters @ACup, @BCup, @CCup, @DCup, @DDCup and @DDD+Cup. These are now legacy commands which will continue to function. 

	
Added @AllowsOrgasm() Command Filter - will only display a line if the domme's "Allows Orgasms" settings matches what's in parentheses. You may enter as many options as you want. You may also use "Not" as a modifier. For example:

	@AllowsOrgasm(Never) - Will only display if the domme never allows orgasm
	@AllowsOrgasm(Often, Sometimes) - Will only display if the domme often or sometimes allows orgasm
	@AllowsOrgasm(Not, Always) - Will only display if the domme does not always allow orgasm
	@AllowsOrgasm(Always, Never, Not) - Will only display if the domme does not always allow orgasm and does not never allow orgasm
	
	@AllowsOrgasm() replaces the Command Filters @AlwaysAllowsOrgasm, @OftenAllowsOrgasm, @SometimesAllowsOrgasm, @RarelyAllowsOrgasm, @NeverAllowsOrgasm, @NotAlwaysAllowsOrgasm and @NotNeverAllowsOrgasm. These are now legacy commands which will continue to function.	
	
	
Added @RuinsOrgasm() Command Filter - will only display a line if the domme's "Ruins Orgasms" settings matches what's in parentheses. You may enter as many options as you want. You may also use "Not" as a modifier. For example:

	@RuinsOrgasm(Never) - Will only display if the domme never ruins orgasm
	@RuinsOrgasm(Often, Sometimes) - Will only display if the domme often or sometimes ruins orgasm
	@RuinsOrgasm(Not, Always) - Will only display if the domme does not always ruin orgasms
	@RuinsOrgasm(Always, Never, Not) - Will only display if the domme does not always ruin orgasms and does not never ruin orgasms
	
	@RuinsOrgasm() replaces the Command Filters @AlwaysRuinsOrgasm, @OftenRuinsOrgasm, @SometimesRuinsOrgasm, @RarelyRuinsOrgasm, @NeverRuinsOrgasm, @NotAlwaysRuinsOrgasm and @NotNeverRuinsOrgasm. These are now legacy commands which will continue to function.		
	
Added @DommeLevel() Command Filter - will only display a line if the domme's Level matches what's in parentheses. You may enter as many options as you want. You may also use "Not" as a modifier. For example:

	@DommeLevel(5) - Will only display if the domme's Level is 5
	@DommeLevel(4, 5) - Will only display if the domme's Level is 4 or 5
	@DommeLevel(Not, 1) - Will only display if the domme's Level is not 1
	@DommeLevel(1, 2, Not) - Will only display if the domme's Level is not 1 or 2
	
	@DommeLevel() replaces the Command Filters @DommeLevel1, @DommeLevel2, @DommeLevel3, @DommeLevel4 and @DommeLevel5. These are now legacy commands which will continue to function.	

Added @ApathyLevel() Command Filter - will only display a line if the domme's Level matches what's in parentheses. You may enter as many options as you want. You may also use "Not" as a modifier. For example:

	@ApathyLevel(5) - Will only display if the domme's Apathy is 5
	@ApathyLevel(4, 5) - Will only display if the domme's Apathy is 4 or 5
	@ApathyLevel(Not, 1) - Will only display if the domme's Apathy is not 1
	@ApathyLevel(1, 2, Not) - Will only display if the domme's Apathy is not 1 or 2
	
	@ApathyLevel() replaces the Command Filters @ApathyLevel1, @ApathyLevel2, @ApathyLevel3, @ApathyLevel4 and @ApathyLevel5. These are now legacy commands which will continue to function.	
	
Fixes added from Community Members:



	Stefaf: Settings window no longer appears on startup
	
	Stefaf: URL-File-Review-Fix 
	     
		 Improvements :
         - Fixed all CrossthreadCalls, wich caused the System to malfunction, with UserInteraction.
         - Removed all hard-coded Folder and File Strings.
         - Removed redundant Code.
         - If you review and download images, the image was downloaded twice.
         - The Blog-XML was downloaded with XML-Doc. After you scraped an URL, you sometimes couldn't scrape it again.
         - Deadlinks were imported again. Now Deadlinks will be removed if you open a blog with Review and on rebuilding, 
        	as long you don't cancel it. Refresh URL-File imports only new Images.
         - Adding an URL to DislikeList was only writing to file, so a disliked URL could get into File, if a blog contains it twice.

     Stefaf: @DommeTag() Overhaul 
	     
		 Reworked the Function to search a DommeImage, that is tagged with the given Domme Tags.Now it is possible to Exclude Tags from Search. The Tag-Order, case and count doesn't matter.

         You want to show a butt without feet, you can enter "Ass, NotFeet".
         You want to show a closeup face without boobs: "Face, NotBoobs, Closeup"
         This Function will return in 99% of all cases the nearest result for the given Tags. :D
         Of course you must set up your DommeTags properly.

         If there is no image found for the specified Tags, the Tags will be altered and searched again:

         The order of alternation is:
         1. Remove: Furniture, SexToy, Tattoo
         2. Remove: Closeup, Sideview
         3. Change: Naked -> GarmentCovering
         4. Change: GarmentCovering -> HalfDressed
         5. Change: HalfDressed -> FullDressed
         6. Change: HandsCovering -> GarmentCovering
         7. Remove: Excluded Tags from the BaseTags
         8-12: Same as 1-6 without Excluded tags. If there are no excluded tags this will be skipped.
         13. Change: FullDressed -> HalfDressed 
         14. Change: HalfDressed -> GarmentCovering 

         Before each step there is a check, if it could alter the result. If it won't the Step is skipped.

			 
	pepsifreak: Default mute setting to false, player now updates with the setting  
	     
		I feel it should be off by default, and since audio doesn't display the
        player, there needed to be an easy way to unmute
		 
# Changelog - Patch 50

System Files added in Patch 50
     \Vocabulary\#SYS_MultipleEdgesStart
	 \Vocabulary\#SYS_MultipleEdgesStop



@SetModule() functionality restored. When I copied the RunModuleLink Sub, I forgot to add the SetModule code back in. 

@SetModule() and @SetLink() can now jump to a specific line in the script when it is called by using a comma. For example, @SetModule(Ballbusting Tasks, Task 2) would start after the line (Tasks 2) in Ballbusting Tasks.txt when the Module begins.
	 
@ShowVar[] and #Var[] should now work correctly and can be used multiple times per line

DommeMoodMin and DommeMoodMax should now output correctly	 

@RandomText() should now work correctly	 
	 
Fixed bug that would cause OutOfMemory exceptions during Slideshows

Added @MultipleEdges() Command
   
     Syntax: @MultipleEdges(Amount, Interval) or @MultipleEdges(Amount, Interval, Chance)
     Special Instructions: Must be used in a line with any @Edge-related Command
	 
	 The @MultipleEdges Command lets you mark any @Edge Command as one that will require multiple edges before the tease will progress as usual. The interval dictates how much rest the user will have between stopping one edge and beginning the next. Think of it like a webtease instruction to edge 10 times with a 5 second break in between, for example. But when using @MultipleEdges in Tease AI, the domme instructs you through each one without having to keep track of the amount of edges or the time between each one.
	 
	 You can also specify what percentage chance the edge will turn into multiple edges. For example:
	 
	 Get to the edge @Edge @MultipleEdges(10, 5, 25)
	 
	 In this case, there would be a 25 percent chance that the user would have to edge ten times with a 5 second break in between. 
	 
	 When a user finishes the edges, the final edge will resolve according to the @Edge Command in the line. So for example, if the @Edge Command was @EdgeHold, then the user would be instructed to hold the final edge.
		

Fixed bug that prevented SessionEdges from updating when @EdgeMode edges resolved

Tease AI no longer allows script-switching countdowns to end while the domme is in the middle of a @FollowUp(). This fixes a bug where the domme's response ability would be frozen and the main picture wouldn't change. 

@PlayVideo[], @PlayAudio[] and @ShowImage[] will now check full file paths as well as their respective media folders in the Tease AI root directory. This is especially useful for showing media stored in variables based on user's prior input. (For example, "Give me the location of your favorite porn video @InputVar[FavoritePornVideo]", and then calling it later with @PlayVideo[#Var[FavoritePornVideo]])

Added @CheckFile() Command - @CheckFile() allows you to check whether a file exists on a user's computer, then go to the appropriate line in the script if it does, @CheckFile() Can be used in two ways:

@CheckFile(FileName, GotoLineIfFileExists)
@CheckFile(FileName, GotoLineIfFileExists, GotoLineIfFileDoesNotExist)

For example, @CheckFile(#Var[FavoritePornVideo], Porn File Exists) would jump to the line (Porn File Exists) if the information stored in the Variable FavoritePornVideo is a vaild file location. If it is not a valid file location, then the script would just continue to the next line as normal

You can also use this example: @CheckFile(#Var[FavoritePornVideo], Porn File Exists, Porn File Does Not Exist) - The script will still jump to the line (Porn File Exists) FavoritePornVideo is a valid location, but in this case it will jump to the line (Porn File Does Not Exist) if it is not

Individual files from your computer can now be dragged and dropped onto the text entry field in the main chat window or the side chat. This will enter the file's full path and send it as a message. This is useful for when the domme asks you to input variables such as a favorite picture

Added setting "Mute Video and Audio Played in Media Player" to General Settings tab. When this is checked, the media player will automatically mute any media file that is started or has it's state changed to playing (For example, pressing play while it's paused). The volume can still be manually adjusted during media playback if you wish. This is very useful if you want to be able to run more scripts with Videos but have privacy concerns due to noise. 

Fixed bug where TTS did not recognize user's volume settings during domme responses

Added Command @PlayVideo() - @PlayVideo() allows you to play a video for the amount of time specified in parentheses. For example, @PlayVideo(15) will play a random video for 15 seconds. When the 15 seconds are up, the video will stop and the tease will continue as normal. This is especially good to combine with @JumpVideo to create shorter, randomized clips in your tease session

Added Command @JumpVideo - If there is a video currently playing, @JumpVideo will jump to a new point in the video somewhere between 10% and 60% of its run time. If @JumpVideo is used in the same line as @PlayVideo, @PlayVideo() or @PlayVideo[], then the video will start at a random position between 10 and 60% instead of the beginning

Added Command @EdgeMode() - @EdgeMode(Goto, GotoLine) @EdgeMode(Video, GotoLine) @EdgeMode(Message, MessageText) @EdgeMode(Normal)

# Changelog - Patch 48/49


Remind about HoldEdgeMaxAmount settings when using older settings


Image Pre-Loading


Fixes added From the Unofficial Patch:

	Fixed Issue #6: Non-working @Glitter commands 
 
	Modified MetronomeTick() function decrease cpu usage to pepsifreak's code	
	
	Implemented pepsifreak's fix for broken images on reset 
	
	Implemented pepsifreak's fix for crash on session resume 
	
	Implememted pepsifreak's fix for @EdgingDecide command by changing it to @DecideEdge
	
	Half of Issue #9 fixed: @PlayAudio works again 
	
	Fixed second half of Issue #9 so that @ShowImage[] now works 
	
	Pepsifreaks's fix for error when toy suspend a session, resume it, and then suspend it again
	
	pepsifreak's tweak to chatlog saving to save during @EndTease, and a minimum size to prevent saving empty logs
	
	Pepsifreak's fix for WakeUp time saving 
	
	Pepsifreak's fix for metronome settings not saving 
	
	Pepsifreak's fix for a suspend/resume bug that would sometimes happen
	
	Pepsifreak's fix so that the Glitter contacts that make you hold an edge will be the ones to make you stop
	
	Pepsifreak's fix for not being able to start a new playlist if you started one and then reset
	
	Pepsifreak's fix for @UpdateRuined and @UpdateOrgasm don't update the counter for how many orgasms you've had - includes Locked setting checked
	
	pepsifreak's fix for needing comands like @PlayAudio, @PlayVideo, and others needing to be in a specific part of the line.
	
	pepsifreak's fix for crashing if you don't have images of a specific tag, now shows error image
	
	pepsifreak's change to allow "nested" vocabulary phrases to work with glitter text (seen in #EmoteRandom)
	
	Pepsifreak's fix for @StartTaunts problem
	
	Tasks startup fix and prevention 
	
	@CallReturn fix 
	
	Add tooltip to variable save icon
	
	Fix black box when resizing chat window when the media panel is hidden
	
	prevent edging while in chastity 
	
	CallReturn now works correctly from taunts 
	
	Fix bug with @Goto
	
	Fixed glitter text breaking when changing themes 
	
	VitalSub exercises now clear when you report them
	
	Fix ShowBoob/Butts commands 
	
	Fixed ShowImage bug where it runs twice 
	
	Fixed ShowVar breaking ShowImage
	
	Fix contact image randomizing 
	
	Added something to ClearMainPictureBox 
	
    Move module code to its own function - Also make "giving up" while stroking give you a module instead of a link
	
	Fix styling on Theme settings tab 
	
	Stop crash when contact images weren't loaded yet 
	
	GiveUp response now supports callreturn 
	
	Image code cleanup - removes blinking between images besides certain cases
	
	UI tweaks - buttons cut off on randomizer app
	 
	Prevent an error if a line ended up empty 
	
	More UI fixes - adds tooltip for contact images
	
	Add startup warning if contact image directories are incorrect 
	
	Speed up scripts slightly
	
	Move callreturn responses to vocabulary files 
	
	Randomize the type delay a little 
	
	Prevent error with the end of certain modules
	
	Daragorn's forced ending commands - Adds the following Commands: @OrgasmDeny, @OrgasmAllow, @OrgasmRuin
	
	Adds debug menu option to "refresh" the randomizer 
	
	simplified the senddailytasks progressbar - no longer eats cpu
	
	Fix the previous end fix when suspending state 
	
	Replace hardcoded honorific responses with #DomHonorific
	
	include edges with checkstrokingstate 
	
	Contacts now correct their own typos 

	Fixed issue when displaying large gifs 
	
Added @MiniScript() Command

Tease AI now keeps track of where the user left the splitter between sessions

Added Interface to main menu strip. Added or relocated the following functions to "Interface": Switch Sides, Side Chat, Lazy Sub AV, Themes, Maximize Image and Webtease Mode

Added Commands @MoodBest and @MoodWorst

Added Commands @DecreaseOrgasmChance, @IncreaseOrgasmChance, @DecreaseRuinChance and @IncreaseRuinChance

Added options to the main picture right-click menu to go to the first image of the current domme slideshow, go to the last image of the current domme slideshow, and load a new random domme slideshow from the directory set in the General Settings tab

Fixed bug where #Keywords would return a "not found" error if adjacent to a ")"

Fixed bug where Next Image and Previous Image buttons were not always unlocked when @LockImages was disabled by system events rather than the @UnlockImages Command 

Fixed major bug where the @ChanceXX Command was not processed correctly, resulting in chunks of the domme's dialogue and Commands being deleted before they could be parsed

Fixed bug where certain @Command() functions would break other @Command() functions in the same line. This includes @CheckFlag(), @SetFlag(), @TempFlag, @DeleteFlag(), @SetDate(), @CheckDate() and @DeleteVar[]

Added Command Filters @AssWorship, @BoobWorship and @PussyWorship

Added Commands @Worship() and @ClearWorship

Added Command Filters @LongHold and @ExtremeHold

Added Commands @LongHold, @LongHold(), @ExtremeHold and @ExtremeHold()

Added Sub Settings for Long Hold Min/Max and Extreme Hold Min/Max

Added Command Filters @SubWorshipping and @SubNotWorshipping

Added Commands @WorshipOn and @WorshipOff

Added Commands @FollowUp() and @FollowUpXX

Response Files will no longer include lines in the [All] category if the session has yet to enter the first Taunt Cycle, or the session has passed the orgasm decision.

Domme recognizes requests to have an orgasm through new keyphrases: "I cum", "me cum", "I have an orgasm", "me have an orgasm"

Added System Keywords #LocalImageCount, #HardcoreImageCount, #SoftcoreImageCount, #LesbianImageCount, #BlowjobImageCount, #FemdomImageCount, #LezdomImageCount, #HentaiImageCount, #GayImageCount, #MaledomImageCount, #CaptionsImageCount and #GeneralImageCount

Fixed bug with @DeleteLocalImage Command that caused the program to stop responding

Added @RestrictOrgasm() and @RestrictOrgasm Commands

"Domme is typing..." timer length is now capped at 6 seconds. This is to ensure that lines get delivered in a timely manner, even if they contain lengthy sets of Commands in the script.

Added @RandomText() Command

Added @SetModule() and @SetLink() Commands

Added @ResponseYes() and @ResponseNo() Commands

Added custom button options to Lazy Sub

Fixed bug that caused Tease AI to crash during videos when domme typed a new message

Improved Tease AI's parsing ability when matching Response Files


_______________________________________ 

Tease AI now automatically capitalizes the first character of each line (will still be overridden by Remove Capitalization option in Domme's Typing Style)

Wildcard ability added to @PlayVideo[] @PlayAudio[] and @ShowImage[] Commands

Web Sex Toy start instructions added to @Edge-related Commands

Added Volume and Rate Sliders for Text to Speech options

Replaced "Emotes Like This" with custom beginning/ending emote textboxes

Tooltip Descriptions added to URL Files tab

Tooltips added to Image path labels to show full paths

General, Domme and Sub settings now use ToolTips for descriptions.

Fixed bug that caused errors when using Goto-related Commands on the line just before an End Command

Multithreading overhaul - Displaying images to main window

Added @EdgeHeld() Command Filter

Added Timeout() Command

Added "Save Image To" option to main picture window right-click menu that let's you quickly save a blog image to one of your local image directories

@CallReturn() Command, Domme Mood Commands

Long Edge amount is now measured in minutes instead of seconds

Open From Text button in AI Box Tools has been changed to Open From Clipboard

Added option to switch left-side panels to right side of the screen

Decreased the minimum size of the Chat Window panel so that the main picture area can be made larger

Improved the way Tease AI validated scripts containing @PlayJOIVideo and @PlayCHVideo

Minor WritingTask UI fixes

Fixed bug where Writing Tasks did not launch correctly from Multiple Choice branches and Responses

Fixed bug that affected @CBTCock lines where only the lines from CBTCock_First.txt would get called

@EdgeToRuinSecret, @EdgeToRuinHoldSecret and @EdgeToRuinNoHoldSecret are no longer valid Commands. The new Commands are @EdgeToRuinNoSecret, @EdgeToRuinHoldNoSecret and @EdgeToRuinNoHoldNoSecret. It didn't make sense to me that the default state would be knowing the ruin was coming in advance, so ruin taunts are only active when a "NoSecret" @EdgeToRuin style Command is used

Tease AI no longer pulls lines that show images from List scripts when @LockImages is active

@DeleteVar[] should now work correctly

I've mainly been ripping out some guts and trying to tweak or optimize things. Too much and too minor to detail, but I've added a third attempt at creating a domme tags system and I have to say this third one is an effin winner : D


# Changelog - Patch 47

9/16 - 9/17 - Created AI Box app that allows users to create and open files that will allow them to easily share their creations from entire scripts to minor additions

Added Commands @RapidCodeOn and @RapidCodeOff, which allows the program to chew through multiple @NullResponse lines almost immediately

Added Commands @InterruptsOff and @InterruptsOn which can be used to prevent the user from Interrupting a script

Added Command @DeleteVar[] which allows you delete a variable you've created

App Window is no longer always on top. Holy fuck did that get annoying fast

9/15 1:50 pm - Fixed bug where @ShowButtImage pulled up Boob pictures instead

9/15 1:36 pm - Domme now occasionally makes and corrects typos

9/15 7:56 am - Created new Domme Tag app that's much easier to work with than the original system - Currently this is accessed through a small black button on the Apps window

9/14 4:41 pm - Gave Terms & Conditions its own form to improve the overall presentation of the program

9/14 1:09 pm - Added Command @InputVar[] - When this Command is used in Linear scripts, the domme will wait for a response from the user and save it as the variable listed in brackets. For example:

I was wondering #SubName
What's your favorite movie? @InputVar[FavoriteMovie]
Yeah, that's a good one

This will save the user's input inside a variable file called "FavoriteMovie" to [Personality]\System\Variables, similar to @SetVar[]

9/14 1:00 pm - Improved the @ShowVar[] Command - @ShowVar can now display strings as well as integers, and multiple @ShowVar[] Commands can now be used in the same line. For example:

You know something #SubName
I agree that @ShowVar[FavoriteMovie] was a pretty good movie, but @ShowVar[FavoriteBand] is terrible
Your tastes are all over the place
 
9/14 11:57 am - Added Splash Screen that displays what operations Tease AI is carrying out as it's starting up

Changed App Windows state to "Always on Top"


# Changelog - Patch 46

9/14 4:26 am Program now unlocks images automatically when the domme allows you to stop

9/14 4L20 am - Metronome now waits until Domme has told you to speed up or slow down before changing speed

9/14 2:52 am - Fixed bug where the Domme, Contact 2 and Contact 3 caused System Message loop when joining and leaving the chat room

9/14 2:37 am - Fixed bug where wishlist preview image was not being handled correctly, causing a "cannot locate image url provided" error

9/14 2:23 am - Fixed bug where the code for Hold The Edge taunts was pointing to the wrong location

09/13 10:39 am - Added 4 buttons on the App window to switch between Blue, Purple, Black and Red color schemes for Tease AI

09/13 8:09 am - Added Date and Time to UI

09/13 7:22 am - Tease AI can now be resized by the user and will scale automatically. 768, Compact and 1080 Buttons are now defunct



# Changelog - Patch 45 Hotfix

9/12 3:39 am - Fixed bug that caused "URL Formats are not supported" error when trying to view Boobs or Butts images from URL Files. 

Fixed code for clicking individual cards to set them in the Cards panel in the Apps tab. I had forgotten to finish this code before releasing Patch 45


# Changelog - Patch 45

9/11 12:29 pm - Various bugfixes and tweaks in preparation of Patch 45

9/09 12:35 pm - Finished new Glitter implementation

9/09 10:16 am - Improved Lazy Sub. Enhance the overall aesthetics as well as adding the option to set keyboard shortcuts for each of the Lazy Sub buttons

9/09 4:35 am - Added Command @Call() - This Command allows you to leave the linear script you're in and begin running another script in the location specified. 

For example, @Call(Modules\PicturesSolo_85.txt) would immediately move the domme to the first line of that script and the program would continue from there. You can specifiy any location you like, as long as it exists in the currently Personality's directories, eg @Call(Custom\My Username\Ballbreaker_1.txt)

You can also use a comma to specify a specific line to start from:

For example, @Call(Custom\My Username\Ballbreaker_1.txt, Made Domme Angry) would move to the file [Personality]\Custom\My Username\Ballbreaker_1.txt and begin from the line (Made Domme Angry). When using a comma to specify location to jump to, make sure that you do not put it in its own set of parentheses, just the location word or phrase only 

Added Command @CallRandom() - This Command allows you to leave the linear script you're in and begin running a random script from the directory specified.

For example, @CallRandom(Custom\UserName) would move to the directory [Personality]\Custom\My Username\ and randomly select a script located there. It would start at the first line of that script and move forward from there. When using @CallRandom(), you cannot use a comma to specify a specific jumping point as you can with @Call()

9/09 3:52 am - Added new parseable section for Response files, [All] [All End] - Tease AI will always add lines between [All] and [All End] and will use them regardless of what state the program is in. This can be useful for adding a few generic responses that can go with any situation, or creating Response files that just contain [All][All End] to respond to very specific words or ideas

9/09 1:39 am - Added Command @SystemMessage - When this Command is used, the "Domme is typing" will not appear. Instead the text will be output to the screen by itself in bold, blue letters. This is useful for system type messages such as "@SystemMessage #DomName has logged off"

Added Command @EmoteMessage - When this Command is used, "Domme is typing" will still appear, but the message will appear by itself in the Domme's color in italics. For example, "@EmoteMessage #DomName laughs" will output "Emma laughs", and it will be italicized to represent an emote. This is useful for creating a more chat like experience

9/08 7:10 am - Fixed bug where slot machine winnings/losses did not save correctly

9/08 5:02 am - Fixed bug where Tease AI would crash trying to pull images from Contact Image Directories that were not set

9/06 2:46 am - Fixed issue where domme would accept a user's message as the answer to a question she was in the middle of typing

9/05 5:36 am - Tease AI will no longer call Long Edge Interrupts during End scripts

9/05 3:25 am - Added Language option in Misc tab to switch Settings UI between English and German. Added German translations to General Settings provided by Ambossli. This will be a slow and steady process, but I will get translations added in various patches moving forward as I receive and are able to implement them

9/04 6:24 am - Improved function of the @Goto Command. Using a @Goto Command such as @Goto(This Line) will go to (This Line) as usual. but you can enter multiple lines separated by commas, such as @Goto(This Line, That Line, That Line Over There). In this case, the script will randomly jump to one of the lines specified, so there's an equal chance of Tease AI moving to (This Line), (That Line) or (That Line Over There).

9/03 3:02 am - Finished image handling tweaks for Patch 45

9/01 2:04 - More Risky Pick work done

Added new game Risky Pick

Added Tease AI icon to icon tray

Daily Login bonus message now appears as a taskbar notification rather than a pop-up

Daily login bonus now randomly gives 5, 10, 25, 50 or 100 tokens. Higher amounts have a harder percent chance to get

Added Context menu to Tease AI icon

 Games -> One click access to Slots, Match Game, Risky Pick, Exchange and Collection
 Milovana -> Quick links to Open Beta thread, Bug Report Thread, Webteases and Forum through user's default browser
 Exit -> Terminate the program 
 
Reset feature greatly improved, should be much more stable

Fixed issue where Tease AI would only flash blog images when called from Response files

Improved handling of animated gifs that appear in the main picture window

Improved Image handling across the board to cut down on GDI errors and reduce memory usage as much as possible

Card Images set in Apps->Games tab can now be dragged from local or online images. In either case, a resized image of that card will be created in [root]\Images\Cards, which the program will use for those card images to ensure that each card is the exact size needed by the picture box, and not wasting memory by scaling down a larger image

Fixed bug that caused program to crash when switching to Match Game tab in Games window

Removed button in the Images tab that no longer served a function


# Changelog - Patch 44

08/25 7:47 am - Added the ability to Suspend and Resume session states

08/25 11:12 pm - Fixed bug that prevented the domme's slideshow from changing during the Taunt cycle.

08/25 10:40 pm - Added ability for domme to read from a script in time with videos. When a user plays any video (it doesn't matter where the video is located or how it was called), the program checks to see if a script with the same name as the video is located in [Personality]\Video\Scripts. For example, if a use opens a video file named Shower-Lesbians.mp4, Tease AI will look for Shower-Lesbians.txt. If no script is found, the video will simply play as usual. Scripts should look something like this:

(BITBUCKET NOTE - The timestamps below should be on separate lines, I don't know why they were formatted as a single line here)

[00:00:10] I'm looking forward to this
[00:00:18] You're probably not though lol
[00:00:42] It's gonna be so fucking hot when they get in the shower
[00:01:32] Fuck, not even two minutes in and I'm already turned on #EmoteFlustered
etc

Timestamps are denoted by "hours:minutes:seconds". So when the video reaches 10 seconds, the domme will say "I'm looking forward to this", and so on. This can be used in conjunction with other instances the domme shows you videos as well. A timestamped message will not be displayed if the domme is already typing at that moment in the video. This not only applies to things she says outside of the video script, but in cases where timestamps are too close together and the domme walks over the next thing she was about to say.

08/25 7:41 pm - Added Commands @ApathyLevelUp and @ApathyLevelDown. These commands alter the domme's Apathy level for the duration of the session.

08/25 10:40 am - Added Reset button to Apps window. The Reset button is enabled once a tease session starts. When the user clicks "Reset", the program will stop and revert to its initial state before greeting the domme. 

Minor tweaks to presentation and functionality of options at the bottom of the Apps window, as well as preparation for Suspend and Resume features. 


# Changelog - Patch 43

08/25 2:07 am - Fixed bug that happened when the user asked to speed up from the slowest speed or slow down from the fastest speed. These requests should now be handled correctly.

08/25 1:40 am - Added Save and Load options in Glitter tab that allows users to create and load custom settings for Glitter.

08/23 11:20 am - Added Command @RoundVar. Syntax: @RoundVar[VarName]=[Value to round by]

For example, @RoundVar[Edges]=[5] would round the variable "Edges" to the nearest 5, and automatically set "Edges" that the new rounded value.

Added System Keywords #RandomRound5, #RandomRound10 and #RandomRound100

These work just like the current #Random Keyword, but will automatically round the result to the value specified. For example, #RandomRound10(10, 100) will only produce a result like 10, 20, 30...etc


08/22 3:14 am - Domme and Contact slideshow images now change during Multiple Choice branches and Responses.

Added error handling for when the program tries to call a Contact slideshow that has not been set in the Contact's Image Directory section in the Glitter tab. 

08/22 2:05 am - Added ToolTips to Domme, Contact1, Contact2 and Contact3 Image Directory labels. When the user hovers the mouse over these labels, the full path to whatever folder they had selected will be displayed in the tooltip. This is to give the user a way to view long paths since the available space is somewhat limited.

Added buttons to Contact1, Contact2 and Contact3 in the Glitter tab that allows the user to clear a previously set image directory.

08/22 1:24 am - Added Chastity state toggle to Misc tab in Settings menu.

08/21 11:36 pm - Added System Keywords #CBTBallsCount and #CBTCockCount. These words are replaced with an integer representing the number of times those routines have been called. These can be used in Operations as well.

08/21 4:20 am - Added ability to create Custom Tasks that work the same way as @CBTBalls and @CBTCock. User creates scripts "Filename.txt" and "Filename_First.txt" and places them in \Custom\Tasks\, and calls them from Linear scripts with @CustomTask() (e.g, @CustomTask(Filename)).
