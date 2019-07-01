# Quick Start

[TOC]

1. Import the **Delight unity package** to your project. It will create two folders in your project:

   `Content/` - your project's content

   `Delight/` - framework source and content

   

2. Right-click in your project hierarchy or select Assets from the top menu, and choose: 

   `Create -> Delight Scene`. 

   Press enter to create the scene **NewScene**. Open the newly created **NewScene.xml** and add the Label element:

   ```xml
   <NewScene xmlns="Delight" 
            xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
            xsi:schemaLocation="Delight ../Delight.xsd">
     
       <Label Text="Awesome!" />
   
   </NewScene>
   ```

   

3. The Unity scene **NewScene.unity** is created in the same folder. Open the scene and run it.

Congratulations, you've created your first scene in Delight :)

