# Tease-AI
Tease AI is adult-oriented software that aims to create an interactive tease and denial experience by emulating an online chat session with a domme. 

# Changelog - Patch 48

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
