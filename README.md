# Casual Stone (PC Version)
Add notifications to your favorite pass-time application. Parses game application logs and displays specific events to custom PC Notifications. The purpose of this app is to make the gameplay experience more efficient. If you agree with this movement, consider giving the project a star and contributing!

![compatibility](http://i.imgur.com/xpOk67f.png)
![compatibility](https://i.imgur.com/NBqIKck.png)

Here's a quick [demo](https://gfycat.com/NarrowUnlawfulCygnet) of Casual Stone in Action.

## OS X Version
Click [here](https://github.com/skonagaya/CasualStone) for Mac version.

## Download
Get the app [here](https://github.com/skonagaya/CasualStonePC/releases/download/0.2.1.0/CasualStone_0.2.1.0.zip) until I find a better way to distribute.

## Features
Notifications can be sent for the following events:
- **Game Start**: The end of queue and start of mulligan phase.
- **Turn End**: The end of a players turn.
- **Concede**: A player concedes from the current match.

Notifications can be configured to only show for Player, Opponent, or Both.

## How to Use
1. **Open the application** and an icon will appear in your system tray.
2. **Right click the system tray icon** and select Settings.
3. **(Optional) Review the notification options** on the Preferences tab, and change the looks and feel of the notifications.
4. **Navigate to the Settings tab** and make sure that the install path is configured. If the install path is missing, click browse and navigate to the install path (ex. C:\Program Files\Hearthstone)
5. **(Optional) Enter your username** in the Accounts tab. If a username is not provided, Casual Stone will not allow the selection of `Show for Player` and `Show for Opponent`. Casual Stone uses username information to distinguish events between the Player and the Opponent.
6. **Right-click on Casual Stone tray Icon** to view the selection of all events. 
7. **Hover over an event** that you want notifications for and
8. **Select the player** you want to show notifications for. For example, if you only want notifications for when your turn starts, Hover over `Start Turn >` and select `Show for Player`
9. **Play and enjoy** the card game. Alt + Tab till your heart's content.


## Tested Devices
Application has been successfully tested on:
- Windows XP
- Windows 7
- Windows 10

## Troubleshooting
Casual Stone uses the card game application's log files. If the application cannot locate the log file, notifications will fail. Make sure that logging is enabled on your Hearthstone Client. Casual Stone will automatically enable logging when the application is run. Review the these [instructions](https://github.com/jleclanche/fireplace/wiki/How-to-enable-logging) to make sure logging is enabled.

## Contact
Suggestions, issues, and comments can be submitted to swkonagaya@gmail.com

## License
MIT License. Just credit people, ya dingus.
