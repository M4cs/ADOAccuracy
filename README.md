# ADOAccuracy
Display Score, Accuracy, and Percentage Complete | **Requires UnityModManager**

<p align="left"><img src="https://i.imgur.com/UgW4vFg.png" width="624" height="351"></p><p align="right"><img src="https://media.discordapp.net/attachments/583339735645421568/783433051023474708/unknown.png?width=1248&height=702" width="624" height="351"></p>

<p align="center"><b>Preview</b></p>

## Installation

## Video Tutorial https://youtu.be/zBbKLVHvWKI

## Modding/Support Discord: https://discord.gg/67pdbVbEWx

### First you need UnityModManager UPDATE IT as the game was added Dec. 1st 2020

1. Download the newest UnityModManager [Here](https://www.nexusmods.com/site/mods/21) (Click on Mirrors)
2. Unzip UnityModManager anywhere on your desktop
3. **If you are on the BETA, as of Dec. 1st 2020, you will need to modify your UnityModManagerConfig.xml file inside the folder of UnityModManager!**
  - First, search for `[Assembly-CSharp.dll]ADOBase.SetupLevelEventsInfo` in the file. **If this does not show up, you don't need to change anything!**
  - Replace all occurances of that line with this line: `[Assembly-CSharp.dll]ADOStartup.Startup`.
4. Open UnityModManager.exe
5. Under the **Install Tab**, in the **Game Dropdown**, select A Dance of Fire and Ice.
6. Click button next to the **Folder** label. Here you will select the game installation path. Should be something like `steamapps/common/A Dance of Fire and Ice`.
7. Select **Assembly** for the installation method.
8. Press **Install**.
9. Click on the **Mods** tab.
9. Drag the `ADOAccuracy-x.x.x.zip` file you can download from [Releases here](https://github.com/M4cs/ADOAccuracy/releases) onto the area that says **Drop zip files here**.
10. Launch the game!

## Usage

Open a level and the text will display.

**It's easiest to press escape at the start of the level to edit your settings.**

**Press CTRL + 8 to open the settings menu**

**You can press CTRL + 7 to hide the ADOAccuracy text at anytime.**

### THE TEXT DOES NOT DISPLAY IF YOU ARE NOT INSIDE OF A LEVEL

## Troubleshooting

Having issues? Read below to see how you can figure out a fix.

**First, press CTRL+F10 to open the ModManager screen. Click on the Logs tab and then Open Detailed Logs at the bottom.**

1) Inside of the file that opens, does it say somewhere `[ERROR] Method 'SetupLevelEventsInfo' not found`? You are on the beta and you need to follow the steps above again.

2) Does it not say that? Copy and paste the text inside the file and upload to https://psty.io. Send me the log on Discord @ macs#0420
