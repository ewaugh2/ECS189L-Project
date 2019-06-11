# Game Basic Information #

**Owners**

- Ehtesham sttar (@esttar)
- Emil Aliyev (@EmilAliyev)
- Enrique Waugh (@ewaugh2)
- Fernando Pieressa (@FernandoPieressa)
- Filippo Soldati (@sfilippo)

## Summary ##

GZG, Generic Zombie Game, is a top down 2D shooter in which you need to collect point by killing zombies and eventually other players, while trying to survive endless waves of zombies whose size increase with time.

## Gameplay explanation ##

In GZG, you are a soldier facing waves of zombies which gets bigger and bigger as time goes by.
Zombies have a chance of dropping extra ammo and health when killed.

### Controls

Controls binding can be set for each player from the main menu settings.
By default, Player 1 moves with **arrows** and shoots with **spacebar**, Player 2 moves with **WASD** and shoots with **Q**, Player 3 uses **IJKL** + **U** to shoot, Player 4 uses **TFGH** + **R** to shoot.

### Game modes

GZG offers two distinct game modes depending on the number of players:

#### 1 Player

When playing alone, the game ends when the player gets killed by zombies and the goal is simply to maximize the score: each killed zombies grants 5 points.

#### 2-4 Players

When playing with multiple players, the game is a PvP that ends when there's only one person standing. The winner is the player with the highest score.
Other than points granted by zombies, hitting a player grants 10 points and killing one grants 100.
100 points are also subtracted to any player that dies.

# Main Roles #

## User Interface

*Main Menu* - The main menu of the game had as objective the possibility for the user to start setting up the game and giving the story/credits of the game. While in this interface, its possible to choose how many players will play the game, along with the key bindings for the players controllers. Also this menu was the one that showed the final score of each player once the game ended. The information transfer between the main menu and game scene was with the use of static classes, that where updated before changing scenes.

*Map* - The map of the game was created with 3 main gameObjects, this where: **1)Spawn portals** that worked as spawners for the zombies. By accessing the coordinates of this portals the game logician could have the different spots to spawn randomly. **2)Background** worked as a gameObject that was behind all other gameobjects of the game and had the visual sprite chosen. **3)Walls** worked with a small square as main structure, that had properties of colision and physics to stop the player and zombies from leaving them. This main structure then was used to create bigger gameObject walls that represented a specific line of walls of the game.

*Split Screen* - To improve the game of multiple players, we decided that the game should be possible to play with split screen, up to 4 players in total. In the case of 3 players, half screen would go to one player and the other two would share the other half. Depending on how many players the user selected to play, the set up of each camera was selected accordingly to be able to add multiple player screens to the game.

*Player Ui* - Utilizing the observer pattern, each of the players in the game was linked with a player ui, that had as objective showing the user the current health, score and ammo to each player. Every time the player changed one of this attributes, the player ui gameobject had to update to show the correct values.

## Movement/Physics

As the main game takes place in a top-down 2d world, w removed gravity from the game from the 2D Physics. The movement is implemented using the Command pattern, although to avoid having too many classes I've chosen to use static methods to instantiate the required movement commands.

Movement changes the speed of the player directly.

Movement for the zombies is substantially different.
I replicated the 2D map in 3D and placed it below the current map. Walls are made unwalkable and the ground is baked using Unity's NavMesh Surface component. Then, I added a NavMesh agent to the zombies and added a simple scritp to make the zombies (or more precisely the cubes in the 3D world) chase the closest player to their location.

The 2D sprites of the zombies update their location (except Z) and rotation to match the one of the cube they are linked to. I was satisfied with the result as the zombies move in a smart and logic way even when there's many of them on map, but I was not satisfied in the way I had to replicate the 3D map below the 2D one, as this approach was very manual and requires to manually change the 3D map too if any change is introduced in the 2D one.

It's a very small task but I also implemented cameras for the players, although they had to be modified afterwards by Fernando for the split screen and UI placement.

## Animation and Visuals

## Input

The default input configuration consist in a series of key bindings for four players that can be seen in the Settings at the main menu. The keybindings can be altered to customize each command to improve the game experience.

They can adopt any keycode that can be detected by the computer, that includes keyboard, controller and touchscreen (in theory). They also can be altered between consecutive games (there is no need to restart unity).

To achieve this we used some features of the unity interface to bind the buttons to certain functions that will use coroutines to wait for a key insertion to attach the key to the player command.

This information was all stored in the Input Manager, a singleton that was in charge of keeping track the keybindings.

## Game Logic

Due to the lack of time of the student in charge of game logic, to obtain the best game possible this part was done by different collaborators

### Fernando Pieressa

*Addition of player animations* - The animations created by Ehthesham where activated and implemented in the game by me as part of the game ui. This includes moving animations for player and zombies, and shooting animation of player.

*Player and zombie damage* - The damage taken by shooting the player or being attacked by a zombie was implemented by colission detection of the different gameobjects. This also consider the damage and killing of zombies withing the game.

*Score* - The update of score was possible by 3 ways in the game: by shooting and killing zombies (5 score), by killing players (100 score), and by dying (-100 score).

*Item pickup and correct spawn* - Fixed the spawn of items to be changed from always dropping after a zombie kill to just 10% change of appearing after kill. Also, made it possible for the player to pick up the items and recieve its effect, that are getting +10 ammo or getting full health.

### Filippo Soldati
Just helped Enrique and Fernando with some parts of the development, mostly with the goal to catch up faster.
Worked with Fernandos on zombies getting shot and dealing damage to the player correctly.

### Enrique Waugh
- Created the base for the shooting command.
- Keep track of bullet count and show that in the UI.
- Helped with player number coordination. This had to be resetted every time the game ended. Also this had relation with input management.
-

### Emil Aliyev

I created a GameManager singleton that is instantiated when the game begins. I had the GameManager set up spawners for players, zombies and items.

I set up the item spawner as a singleton. It has a spawnItem() function that takes a position as a parameter to spawn an ammo item and to spawn a health item(but will not spawn both at the same time). This function is called when a zombie dies, creating a chance to spawn an item at the position in which the zombie died.

I had the GameManager attach the ZombieSpawner script to each portal at the start of the game. Every 10 seconds, the ZombieSpawner spawns a zombie at the position of the attached portal. Every 60 seconds, the number of zombies spawned at each portal increases by 1.

# Sub-Roles

## Audio

All Audio assets can be found in Assets/Resources/Audio. All audio assets were free assets downloaded from the Unity Store.

Assets/Resources/Audio/Main Menu/Music/Title Screen Theme - https://assetstore.unity.com/packages/audio/music/ancient-era-music-free-pack-146823

I implemented the title screen theme song by adding an Audio Source component to the Canvas object, and placing the Title Screen Theme in the AudioClip field. I had the theme Play on Awake and Loop.

## Gameplay Testing

## Narrative Design

The narrative is presented simply as a text behind the History button at the main menu. It presents a quick explanation about why the players are in the position that they are and suggest the objective of the game.

## Press Kit and Trailer


https://www.indiegogo.com/project/preview/36d4cf57#/

I decided to showcase the game using indiegogo to lunch a fundraising campaign. The trailer was made using a free preset for Adobe After Effects and doesn't show the game play accurately, I mostly tried to make the trailer itself feel epic as I didn't think the content of the game itself was "strong" enough.

Screenshots show various gameplay scenarios, with emphasis on both the PvP and survival components of the split screen mode.


## Game Feel

*Shooting* - To make the game harder and make it feel more of a challenge, changed the way the shooting worked, by limiting the range of the bullet, removing the ricochet of the bullet and by reducing the fire time between bullets, this way the player have to decide better when and where to shoot

*Color health* - To improve the feeling of the danger of being with low health, made that depending on how low the health of the player is, the color of the healthbar will change from a bright green to red

*Blood* - To be able to visualize when the player had been shot and see the effects on map of killing zombies, added a blood splash animation when the player has been damage by either other players or zombies, and also killing zombies leave a mark of blood for 5 seconds in the floor where they died
