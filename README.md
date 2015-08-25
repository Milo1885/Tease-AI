# Tease-AI
Tease AI is adult-oriented software that aims to create an interactive tease and denial experience by emulating an online chat session with a domme. 

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
