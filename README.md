# CheckPoints system for Unity 3D
This checkpoints system allows you to create multiple control points around the scene and save the position of the player each time that he touch one of them. When player die (or when you want) you can decide to begin from the last activated checkpoint.

## How to use

##### Create the Checkpoint prefab
You have to create a game object that represents the checkpoint. This object can be any kind of game object containing the next settings:

- The tag must be called "Checkpoint".
- It must have a collider component (with the "IsTrigger" option activated) that represents the action area of the checkpoint.
- It must have assigned the script "[CheckPoint.cs](https://github.com/santiandrade/Unity-CheckPoints/blob/master/Assets/Scripts/CheckPoint.cs)" as component.
- Optionally you can create some animations to represent the activated/deactivated states of the checkpoint. This animations must be activated with a boolean variable called "Active" in the Mecanim system of Unity.

Once we create the checkpoint object, we can store it as a prefab (you can find a prefab called "Checkpoint" as example in this project) and use it around your scene.

##### Call to the "CheckPoint.GetActiveCheckPointPosition()" function
Now you can to call to the static function "CheckPoint.GetActiveCheckPointPosition()" from any place of your code to get the position of the last activated checkpoint object (for example you can use it when your player die).

## This project
You will find a fully functional example made with Unity 2019. Enjoy!
