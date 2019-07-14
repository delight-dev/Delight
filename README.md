# Delight

Delight is an open source component-oriented framework for Unity, mainly centered around creating user-interface components that can easily be extended, combined and shared using a text based declarative design language (similar to HTML). 

[![Gitter](https://badges.gitter.im/DelightChat/community.svg)](https://gitter.im/DelightChat/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge) 

Get the latest API-docs, tutorials, extras and news at [https://delight-dev.github.io/](https://delight-dev.github.io/)


## Quick Start

1. Import the [Delight unity package](https://assetstore.unity.com/packages/slug/150494) into your Unity project. 



2. Create a new scene by right-clicking in your project hierarchy and choosing: 

   `Create -> Delight Scene`. 

   Press enter and open the newly created `NewScene.xml`  XML file and edit it so it contains the following content:


   ```xml
   <NewScene xmlns="Delight" 
             xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
             xsi:schemaLocation="Delight ../Delight.xsd">
     
       <Label Text="Awesome!" />
   
   </NewScene>
   ```
  


3. Open the Unity scene `NewScene.unity` that has been created in the same folder and run it.

Congratulations, you've created your first scene in Delight :). 

![](https://delight-dev.github.io/Tutorials/awesome.png)

Check out the [Tutorials](https://delight-dev.github.io/Tutorials/Tutorials) and get started creating some awesome UI components.


## Contributing

You're welcome to contribute to the project. For minor contributions, such as bugfixes, open a pull request. If your contribution is larger, such as new views or features, consider opening an issue first to engage the community. If you want to contribute to the website check out the [Delight website GitHub](https://github.com/delight-dev/delight-dev.github.io). 


## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details. 
