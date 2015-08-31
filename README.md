# Tease-AI
Tease AI is adult-oriented software that aims to create an interactive tease and denial experience by emulating an online chat session with a domme. 

# Bitbucket note - I haven't pushed a new build in a while because I was waiting to finish Risky Pick. All the work I've done in the meantime has grown so massive that I'm scared of losing it, so I'm going to go ahead and push this build through. Risky Pick is functional, but does not include the script necessary to make it run will still needs some work, so if you do compile this, don't press "play" in there for now  

# Changelog - Patch 45

Added new game Risky Pick

Added Tease AI icon to icon tray

Daily Login bonus message now appears as a taskbar notification rather than a pop-up

Daily login bonus now randomly gives 5, 10, 25, 50 or 100 tokens. Higher amounts have a harder percent chance to get

Added Context menu to Tease AI icon

 Games -> One click access to Slots, Match Game, Risky Pick, Exchange and Collection
 Milovana -> Quick links to Open Beta thread, Bug Report Thread, Webteases and Forum through user's default browser
 Exit -> Terminate the program 
 
Reset feature greatly improved, should be much more stable

Improved handling of animated gifs that appear in the main picture window

Improved Image handling across the board to cut down on GDI errors and reduce memory usage as much as possible

Card Images set in Apps->Games tab can now be dragged from local or online images. In either case, a resized image of that card will be created in [root]\Images\Cards, which the program will use for those card images to ensure that each card is the exact size needed by the picture box, and not wasting memory by scaling down a larger image

Fixed bug that caused program to crash when switching to Match Game tab in Games window


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
