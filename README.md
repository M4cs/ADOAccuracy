# ADOAccuracy
Display Current Accuracy in Game | Mod for A Dance Of Fire and Ice | **Requires UnityModManager**

<p align="center">
  <img src="https://i.imgur.com/t2Uz3JI.png">
</p>

## Installation

### First you need UnityModManager, if you already have it, skip to step 3 below!

1. Download UnityModManager [Here](https://www.nexusmods.com/site/mods/21) (Click on Mirrors)
2. Unzip UnityModManager anywhere on your desktop
3. Inside the UnityModManager folder, open UnityModManagerConfig.xml
4. At the bottom of the file **above the \</Config>**, add this:

```xml
	<GameInfo Name="A Dance of Fire and Ice">
		<Folder>ADOFAI</Folder>
		<ModsDirectory>Mods</ModsDirectory>
		<ModInfo>Info.json</ModInfo>
		<GameExe>A Dance of Fire and Ice.exe</GameExe>
		<EntryPoint>[UnityEngine.UIModule.dll]UnityEngine.Canvas.cctor:Before</EntryPoint>
		<StartingPoint>[Assembly-CSharp.dll]ADOBase.SetupLevelEventsInfo:Before</StartingPoint>
		<UIStartingPoint>[Assembly-CSharp.dll]ADOBase.SetupLevelEventsInfo:After</UIStartingPoint>
	</GameInfo>
```
5. Open UnityModManager.exe
6. In the Game Dropdown, select A Dance of Fire and Ice
7. **Select Assembly instead of DoorstopProxy for Installation Method**
8. Click Install
9. Go to Mods tab
10. Drag and Drop the ADOAccuracy.zip from [Releases]() into the area that says "Drop Zip Files Here"
11. Launch the Game and Press Ctrl + 8 to open the Settings Menu!

## Usage

The mod will automatically be displayed when you start a level. You can start a level, press Escape and then Left Control + 8 to open the Settings menu in order to move it around.
