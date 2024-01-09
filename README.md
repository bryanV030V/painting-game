Hi ![](https://user-images.githubusercontent.com/18350557/176309783-0785949b-9127-417c-8b55-ab5a4333674e.gif)
=========================================================================================================================================

Create a new 2D Unity project.

Create a new empty GameObject called "Canvas" in the scene.

Attach a SpriteRenderer component to the "Canvas" GameObject and assign a sprite as the background.

Create a new empty GameObject called "PaintBrush" in the scene.

Attach a SpriteRenderer component to the "PaintBrush" GameObject and assign a small circular sprite. Adjust the size and color as desired.

Create an empty GameObject called "GameManager" and attach the "PaintingGame" script to it.

Set the "Paint Brush Prefab" field in the "PaintingGame" script to the "PaintBrush" GameObject.

Now, you can run the game, and the paintbrush will follow the movement of the mouse. Left-click to start painting, release the mouse button to stop painting, and press the "Delete" key to delete the paint on the canvas. Adjust the script and add more features as needed for your game.
