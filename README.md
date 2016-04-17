# Tease-AI
Tease AI is adult-oriented software that aims to create an interactive tease and denial experience by emulating an online chat session with a domme. 


# Changelog - Patch 52

Fixed bug where @ShowBoobsImage would return a butt image

The program no longer displays a messagebox when a #Keyword cannot be located. Now the #Keyword is highlighted in red in the chat window without any interruptions

Fixed bug where Glitter Contacts did not appear correctly during Multiple Edges they initiated


Fixes added from Community Members:

	Stefaf: Bugfix StackOverflowException
		Added functionallity to prevent Timers from triggering oneself over and over again, while the TickEventHandler is running long procedures. 

    Stefaf: Bugfix image list not found (1885 Note: The code here is above my expertise, but it appears to fix crashes that would occur when Tease AI cannot locate Url Files, DislikedImageURLS or LikedImageURLS) 




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
