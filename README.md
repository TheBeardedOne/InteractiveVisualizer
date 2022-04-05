## InteractiveVisualizer ##
 
- For this project I used Unity's Universal Render Pipeline and Cinemachine to create an interactive 3D visualizer application prototype

## Instructions ##

- You can find the scene "MainScene" in the Scenes folder

- Start the application as a build or in editor
- Click and hold left mouse button to rotate the camera
- Click and hold right mouse button to pan the camera up and down
- Click on the cog button in the bottom right to open the options menu(Camera inputs are not allowed while the menu is open. This is indicated by an icon next to the Cog button)
- Use the tabs at the top of the options panel to select a category
- Experiment by manipulating values. You can switch models, materials, change the lighting etc
- Click the cog button again to close the menu and regain camera controls

- The InteractiveVisualizer also works on Android devices
- Use one finger to drag and rotate the camera
- Use two fingers and drag to to pan the camera up and down
- Zooming is not functional for mobile

## Challenges & Solutions ##

- Starting the URP project was fairly straightforward. I began by creating the scene, and manually creating the entire options UI. 

- It became quickly apparent that there would be a workflow bottleneck if I had to manually add each option to the UI, then manually revisit the object whenever I wanted to change data. Lots of time would be wasted, and the entire UI would be so custom that scalability would become an issue if things needed to change. 

- It was also apparent that to create an option, you had to have the technical know-how of Unity UI. 

- So, my main focus (and challenge) became workflow optimization to speed up content creation, approachability  for designers, and improved application scalability for the future. 

- To overcome this challenge, I did a few things.

- 1. I created a scriptable object to contain option data. This vastly improved work speed, and makes it very easy to change options data. Especially for designers who won't have to dig through UI. 
- 2. I created option types, which all ultimately derive from the core OptionsScriptableObject. Example types are SliderOption and ButtonOption
- 3. The options scriptable objects are then loaded at runtime and the data is used to populate UI objects into the scene.

- By making options use scriptable object data I was able to vastly improve workflow by improving my work speed, making it VERY easy to change options data, and added scalability to the application in the form of options types.

## Options Structure ##

- Options are created using a scriptable object (To create one in the editor: Create -> VisualizerOptions -> SliderOption)
- There is the base option "OptionsScriptableObject" and 4 types underneath that. 

- SliderOption (inherits base option)
- ButtonOption (inherits base option)
- MaterialButtonOption (inherits ButtonOption)
- ModelButtonOption (inherits ButtonOption)

- Options can be assigned a name, a category (Lighting, PostEffect, etc), and a prefab (the actual UI object). Child option types will also have relevant data attached like floats for max and min value for sliders (among other things).

- Each option also has an initializing UnityEvent and activating UnityEvent for when the option is interacted with. 

## Future Possible Improvements And Notes ##

- More options and option types. A selector option type with a left and right arrow to switch between option values would be one of my first new option types. Anti-aliasing for example could use the selector option, allowing you to swap between FXAA and SMAA. 

- I also thought it would be cool to have a multi-slider option type to better handle options that are related to each other. (So a single option could handle multiple values by having multiple sliders)

- The GameOptionsManager is a class that is meant to house all the methods that power the manipulation of option values. However, it is at risk of becoming a huge mega-class. With more time, I would split this up into smaller more manageable  classes especially as the number of options grows.
