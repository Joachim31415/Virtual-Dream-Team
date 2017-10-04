# HFUnityLibrary
Shared library used for Happy Finish Unity projects

## How to use?
### Shared
Open a CMD console as administrator and run this command inside `Assets/` folder

	mklink /d "./HFUnityLibrary" "Path/To/This/Repo/In/Your/Machine"
### Local
Just copy and paste what you need! no `.unitypackage` available yet 

## Scripts

### Mobile
- `DragControls.cs`: attach this script to the Camera system to enable the Drag Controls

### Project
- `AudioManager.cs`:
Singleton - Handler for audio source component

- `InputManager.cs`:
Singleton - Handler for input, is managing the input for Windows, Oculus Controller and Oculus Remote, and GearVR, you can also suscribe to events from this class

- `PlatformManager.cs`:
Singleton - The platform selector:
		None,
        Windows,
        MacOS,
        Cardboard,
        Screen,
        GearVR,
        Oculus,
        Vive

### Standard
- `Billboard.cs`:
- `FollowPosition.cs`: a position follower
- `FollowRotation.cs` : a rotation follower

### Tools
- `VRMouseEmulatorBehahior.cs`: emulate gaze pointer by mouse movement. INSTRUCTIONS: 1) deactivate GazeGestureVR 2) instance an empty GameObject with this script as component 3) add the main camera as target.

### UI
- `CircleTransition.cs`: TODO
- `ColorTransition.cs`: TODO
- `Hotspot.cs`: `Hotspot` class visible on click or timer-based
- `HotspotInfo.cs`: TODO
- `TestHotspot.cs`: testing hotspot, to be substituted by unit tests

### VR
- `GazeGestureVR.cs`:
An implementation of the BaseInputModule that uses the player's gaze as a raycast generator.  To use, attach to the scene's EventSystem object. Set the Canvas object's Render Mode to World Space. To work with 3D objects, add a PhysicsRaycaster to the gazing camera, and add a component that implements one of the Event interfaces (EventTrigger will work nicely). The objects must have colliders too.
 - `ResetCameraRotation.cs`:
 
## Shaders
- `GeneratedWireframe.shader`: a wireframe effect. It accepts `Line Color`, `Background Color` and Line Width` as properties.
- `RimLighting.shader`: a rim lighting effect. It accepts `Texture`, `Main Color`, `Rim Color` and `Rim Power` as properties.
- `RimLightingWithAlpha.shader`: a rim ligthing effect with alpha channel. Same properties as above plus `Alpha`.

## Prefabs

### BaseProject
- `InputManager.prefab`:
- `PlatformManager.prefab`:
- `UIManager.prefab`:
