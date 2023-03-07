# Wonderseat
This prototype was based on an old Flash game called "Blobby Volley", here you can check the reference video https://youtu.be/wl2_8qKBlII?t=48. I remember myself playing that game during studies on some computer science courses when I was still a child, it was quite entertaining back in the day :)

There is no goal in current state of the prototype, you can just play it with your friend listening to music of your choice and discussing whatever you want. 
Also, prototype contains very simple difficulty balancing logic that is meant to maintain a competition without ruining player experience.

## Project structure:
You can find the assignment project inside the Assets/WonderBall folder.

### WonderBall Folder structure
 - Input - you can find the input configurations for Unity Input System
 - PhysicMaterials - physic materials for different types of physic objects in the prototype
 - Prefabs - prefabs for Players / Ball
 - Scene - Prototype scene
 - Scripts - custom code of the prototype.
 
## How to play
Open the scene Scene/FriendlyVolleyball, run it in the Editor. 
Currently prototype supports only keyboard controls.

Left player controls:
 - 'A' - move left
 - 'D' - move right
 - 'W' - jump, you can hold jump button to jump a bit higher
 - 'LeftShift' - sprint
 
Right player controls:
 - 'ArrowLeft' - move left
 - 'ArrowRight' - move right
 - 'ArrowUp' - you can hold jump button to jump a bit higher
 - 'RightShift' / 'Num0' - sprint (made 2 buttons as on my keyboard it is a bit more convenient to use Num0, but not every keyboard has numpad
 
There is also Reset button (alternatively you can press 'R' button) which resets the game state.

## Possible future plans
 - Add proper UI with game start/pause flow, player names, scoring table, etc.
 - Add additional visual recognition for several consecutive wins of the same player
 - Create proper game flow (current start / reset / scoring logic is far from good state)
 - Create view classes for Player and Ball to incapsulate view related logic there
 
## Known issues
The prototype was designed for the screen resolution of FullHD (1920 * 1080), with different resolution there might be issues with game field borders. 
