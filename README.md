# ColorSaw3DDemo
Demo of the IOS game ColorSaw3D for Flamingo Games by Hakan Ogan Alpar

Using Unity 2020.1.6f

About the Game
  The game uses touch controls, and moves the objects on a grid. The grid is easily editable within the editor and the changes are seen instantly with an editor script. Curretly the touch controls have a 1 to 1 ratio with the gameobjects but thats also easily configurable from the editor. In the game, when the objects to destroy are not connected to the objects to keep alive, they should die instantly without the need for a collision with an obstacle. I accomplished this by running a BFS within my collections and checking for connectivity. 

Creating a Level
  To create a new level is really simple. Just create a new scene, put a "level basis" prefab on the scene, from that object you can decide on the size of the map and lighting and post processing. Player characther (The objects the player moves) are called "collection" and there can be multiple collections in a single level. Level completes when all the collections are cleared. To modify the collection all you have to do is store "DestroyForWinObjects" under the "Destroy" child of the collection and "KeepAliveForWin" objects under the "KeepAlive" child of the collection. This helps modify the collection to have any shape easily. 
  There are also obstacles within the game. There are 2 builtin obstacles in the Prefabs folder but again creating new ones are really easy. All you need to do is create a Collider object and assign "Obstacle on Trigger" script to it, an audio source, an audio clip and put it into the "Obstacle object". In addition to this, if you already have the shape that you want to work with, modifying the speed, direction, size are also really easy. Each obstacle has a start and end waypoint, in addition to public parameters "move speed" and "rotation speed". These make the level creation really simple.
