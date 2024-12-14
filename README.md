Welcome to **Basement Show!**

A creative project / Narrative point and click adventure game. 

This is a small demo of some of the gameplay mechanics of one part of the game. 
At this point in the story, Hazel has given Eleanor a Tarot Card reading-- but Eleanor's fear of her own fate means that she panics before the reading is done, 
and the pair are thrown into a dream-like version of Eleanor's own past. They must solve a puzzle to escape the room. 

**How to Play**

Create a new project in Unity and replace its Assets folder with this one. Then, open SampleScene to play. 

Movement: WASD. 
To interact with the environment: Click the object of interest to investigate. 
To leave a pop-up: Press the escape key on your keyboard. 
To exit the game: Click the Escape button on the screen, and answer "yes" to the prompt, or press escape when no dialogue or pop-up is on screen. 

**Features:**


https://github.com/user-attachments/assets/a367c465-1a3a-426b-90c4-4b672ebc6704

- _Controllable 2D character with 4 directional sprites_

  Implemented in EleanorMovement.cs. The big challenge in this was figuring out how to make the player not go through walls-- simple on paper, but hard in execution. I ended up using an approach with RayCasting. Depending on the direction of movement, Eleanor's sprite changes
between facing up, down, left and right. 


https://github.com/user-attachments/assets/bad6988e-127c-4bf7-bd90-bf4e7e049d1e


- _Dialogue System_

  The static class DialogueHandler.cs handles all Dialogue. When objects wish to put a sequence of text on the screen,
they pass a string[] object containing the dialogue lines to the appropriate method in DialogueHandler.cs. The DialogueHandler ensures that
the panels and text appear, along with Eleanor and Hazel's profile pictures.
Funnily enough, the hardest part of implementing this had to do with my choice to have the Dialogue wait for a click to continue as a coroutine.
StartCoroutine() is a method in MonoBehaviour, from which static classes cannot inherit. Thus, in order to start the coroutine, I had Util define a non-static class which can call StartCoroutine() on behalf of other static classes through Util.StartCoroutineFromStatic().

- _Interactable Objects_
  
  All of the interactable objects have their own methods, as different objects queue different sequences of events. For example, the Window, lightswitch, and
dead plant are very simple-- they just run some text and call it a day. Others are more involved, such as the bed, diary, and letter. Those put additional pop-ups
on the screen which prevent the user from clicking on anything else in the scene.

- _Inventory_
  
  In an effort to make this game more scalable / Expandable at a later point, I made the Inventory system more robust than it had any right to be for this assignment.
  The inventory is now a static class which adds and removes the items from an underlying list. Additionally, the Inventory displays the received key in the demo on the screen. 


https://github.com/user-attachments/assets/5aa22e7d-0182-40b4-840e-ad9c9df49280

You won't want to leave!!

