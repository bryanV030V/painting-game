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

====================================================================================================

To play music that the user pasted into an input box, you can use Unity's InputField UI element to get the path or URL of the music file. Then, you can use an AudioSource component to play the music. Here's a simple script to get you started:

Create a new empty GameObject in your Unity scene.

Add an InputField UI element to the GameObject (you can find it under UI > InputField).

Attach an AudioSource component to the GameObject.

Attach the "MusicPlayer" script to the GameObject with the InputField and AudioSource.
Now, when you run the game, users can paste the music file path or URL into the InputField, and the music will play using the AudioSource. Note that this script uses UnityWebRequest to load audio from a URL. If you want to load local files, you may need to adjust the code accordingly. Also, ensure that you have the necessary permissions to access the audio file, especially when dealing with web URLs.
