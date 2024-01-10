Hi ![](https://user-images.githubusercontent.com/18350557/176309783-0785949b-9127-417c-8b55-ab5a4333674e.gif) please follow the steps for it to work
==============================================================================================================================================================

Create a new 2D Unity project.

Create a new empty GameObject called "Canvas" in the scene.

Attach a SpriteRenderer component to the "Canvas" GameObject and assign a sprite as the background.

Create a new empty GameObject called "PaintBrush" in the scene.

Attach a SpriteRenderer component to the "PaintBrush" GameObject and assign a small circular sprite. Adjust the size and color as desired.

Create an empty GameObject called "GameManager" and attach the "PaintingGame" script to it.

Set the "Paint Brush Prefab" field in the "PaintingGame" script to the "PaintBrush" GameObject.

Now, you can run the game, and the paintbrush will follow the movement of the mouse. Left-click to start painting, release the mouse button to stop painting, and press the "Delete" key to delete the paint on the canvas. Adjust the script and add more features as needed for your game.

=============================================================================

To play music that the user pasted into an input box, you can use Unity's InputField UI element to get the path or URL of the music file. Then, you can use an AudioSource component to play the music. Here's a simple script to get you started:

Create a new empty GameObject in your Unity scene.

Add an InputField UI element to the GameObject (you can find it under UI > InputField).

Attach an AudioSource component to the GameObject.

Attach the "MusicPlayer" script to the GameObject with the InputField and AudioSource.
Now, when you run the game, users can paste the music file path or URL into the InputField, and the music will play using the AudioSource. Note that this script uses UnityWebRequest to load audio from a URL. If you want to load local files, you may need to adjust the code accordingly. Also, ensure that you have the necessary permissions to access the audio file, especially when dealing with web URLs.

============================================================================
Create the Menu UI
Create Canvas and UI Components:

In Unity's Hierarchy panel, right-click and select UI -> Canvas.
Inside the Canvas, right-click and select UI -> Panel. This will serve as the main panel for the menu.
Create three buttons within the panel: one for saving, one for continuing, and one for quitting.
Set Button Labels:

Change the text on the buttons to "Save", "Continue", and "Quit".

Implement the Menu Script

Attach this script to an empty GameObject in your scene.

Attach the MenuController Script:

Drag the GameObject with the PaintingGame script attached to the paintingGame field in the MenuController script.
Link UI Buttons to MenuController:

In the Unity Editor, select each UI button in the Canvas.
In the Inspector, find the "On Click ()" section in the Button component.
Drag the GameObject with the MenuController script attached into the object field.
Choose the MenuController function for each button: SaveCanvas, ContinueGame, and QuitGame.
Now, when you press the Escape key, the menu will appear, allowing you to save, continue, or quit the game. Adjust the menu layout, appearance, and button functions as needed for your project.
