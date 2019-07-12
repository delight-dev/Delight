# Quick Start

1. Import the [Delight unity package](link-to-package.html) into your Unity project. It will create two folders:

   `Content/` - your project's content

   `Delight/` - framework source and content

   

2. Create a new scene by right-clicking in your project hierarchy and choosing: 

   `Create -> Delight Scene`. 

   Press enter to create the scene `NewScene`. Open the newly created `NewScene.xml`  XML file and edit it so it contains the following content:

   *NewScene.xml*

   ```xml
   <NewScene xmlns="Delight" 
            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
            xsi:schemaLocation="Delight ../Delight.xsd">
     
       <Label Text="Awesome!" />
   
   </NewScene>
   ```

   

3. Open the Unity scene `NewScene.unity` that has been created in the same folder and run it.

Congratulations, you've created your first scene in Delight :). 

![](awesome.png)

For more information check out the [documentation](Docs.html). A good start would be checking [Creating a Main Menu](Creating a Main Menu.html) for a practical introduction and [Basic Overview](Basic Overview.html).

