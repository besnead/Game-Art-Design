# All of Ember's contributed Scripts
## RespawnController
### Steps to use:
1. Attach to your Player object.
2. Create a new object to serve as your "respawn void", make it a trigger and give it the tag "RespawnTrigger".
3. Slap that object wherever you wish, however, typically placed somewhere underneath your map so that they aren't falling endlessly.
4. Next, create a new object with a RigidBody to serve as your respawn save point, and give it the tag "RespawnPoint".
5. Whenever you step on the RespawnPoint, and fall into the trigger, it should now take you back to wherever you saved with the RespawnPoint.
6. Repeat Step 4 for however many respawn points you may wish.

## SpeedBoostScript
### Steps to use:
#### WARNING: If your speed variable isn't public, this script may not be able to access it and do it's job.
1. Add the More Effective Coroutines package to your assets from this link: https://assetstore.unity.com/packages/tools/animation/more-effective-coroutines-free-54975 (Make sure you're signed into the same account you signed into Unity with.)
2. Add the package to your UnityProject by going to Window -> Package Manager -> Click on More Effective Coroutines -> Install
3. Ensure that the Player Controller script with the speed float is named "PlayerController", and the speed float is named "speed"!
4. Now, once that's all said and done, go ahead and attach this script to your Player object.
5. Go into the inspector for your Player object, and set the Player variable in the inspector to your player GameObject.
5. Next, create a new Object, make it a trigger, give it the "SpeedBoost" trigger, and place it where you wish.
6. Now, you should be able to run into the speed-boost, and it'll make you faster!


#Embah's Tips n' Tricks
##Autocomplete with Unity
1. Navigate to your OneDrive where your Unity is stored
2. Go to the base directory where you can see a .sln
3. Right click on it and hit "Create Shortcut"
4. Copy that shortcut, slap it on your desktop, and run it.
5. Autocomplete, wooo!!!!