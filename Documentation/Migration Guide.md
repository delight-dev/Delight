# Migration Guide

[TOC]

## Introduction

This document describes how to migrate from MarkLight to Delight and highlights new features and differences between them. 

## Overview

### Setup

1. Open the Delight window.

![Open Delight Window](C:\Projects\GitProjects\Delight\Documentation\Migration Guide\DelightWindow.png)

2. Attach it for easy access.

![](C:\Projects\GitProjects\Delight\Documentation\Migration Guide\DelightWindow2.png)

**Rebuild all** - generates code for all views as well as for assets and configuration. Used when when views, configuration or assets has been changed while the editor was closed, or if all the code needs to be regenerated because of errors after getting latest from source control. Note that if you change, e.g. a view XML while the editor is open the necessary code is automatically generated.

The checkbox *Build Asset Bundles* need to be checked if you've moved assets while the editor was closed and want all the asset bundles and asset code to be rebuilt.

### Folder Structure

`Delight/` contains the framework source code, assets and standard views. `Content/` is where your project's views and assets will be residing:

![](C:\Projects\GitProjects\Delight\Documentation\Migration Guide\DelightFolder2.png)

- `Content/Assets` contains the assets (sprites, fonts, etc) used in your views.
- `Content/Models` contains your bindable data-model (C# classes) automatically generated from a schema file (or manually created). It's a new feature that you may use to more easily bind to your model objects (globally accessed and decoupled from your UI).
- `Content/Styles` contains your styling/theming XML files.
- `Content/Views` contains your views. Note that both XML and generated code / custom code-behind logic, resides in the same place in Delight.
- `Content/Config.txt` allows you to configure the Delight framework, e.g. set build target and server uri for asset bundles.

### Views

The views in the `Content/Views` folder and each view consist of three files (or two if you don't have any custom logic). So a view *MyView* can look like this.

*MyView.xml*:

```xml
<MyView Test="t:MyType">
    <Label Id="MyLabel" Text="Hello" />
</MyView>
```

This is your view XML file that the code is generated from. 



*MyView_g.cs* (generated):

```csharp
public partial class MyView : UIView
{ 
    public readonly static DependencyProperty<MyType> TestProperty = new DependencyProperty<MyType>("Test");
    public MyType Test
    {
        get { return TestProperty.GetValue(this); }
        set { TestProperty.SetValue(this, value); }
    }
    
    // ... etc.
}
```

Generated automatically when MyView.xml changes or *Reload All* button is pressed in the Delight window.



*MyView.cs* (custom logic):

```csharp
public partial class MyView
{
    protected override void AfterLoad()
    {
        base.AfterLoad();
        
        // do stuff when the view has been loaded
        Debug.Log("Test = " + Test);
        Debug.Log("MyLabel.Text = " + MyLabel.Text);
    }
}
```

Since it's a partial class you have access to the generated code, and can e.g. work with the Test property directly. So the main difference at this point is that all properties are defined in the XML as shown and you access  values directly and don't need to go through a `.Value` property. References to views in the XML (Label in this case) are also automatically generated.

### Assets

All assets (fonts, sprites, etc) that are to be accessed by the framework need to reside in the `Plugins/Content/Assets`folder. 

![](C:\Projects\GitProjects\Delight\Documentation\Migration Guide\AssetsFolder.png)

Assets in the `Assets/Resources` folder will be included in the build. The other assets will be put in asset bundles with the same name of the sub-folder the asset resides in. So the above content creates two asset bundles *Bundle1* and *Bundle2*. 

Once the assets are in place the framework generates the code and bundles automatically.  You can access your assets in your view XML:

```xml
<Image Sprite="BigSprite" />
```

Note that only the filename without extension needs to be specified (and on a side-note the default behavior of images is now to adjust their size and type to the sprite so you don't need to specify those). XML intellisense now also auto-completes assets you have in your project.

You can also access your sprite in code:

```csharp
MyImage.Sprite = Assets.Sprites.BigSprite;
```

Assets and bundles will be loaded/unloaded asynchronously on-demand as views that reference them are loaded/unloaded. This is transparent to the developer and handled by the framework. 

### 

## Migrating a View

Here are the step to migrate views from MarkLight to Delight. This example shows the steps required to migrate the view **SearchView** that resided in the main ViewManager view. 

1. Copy the XML SearchView.xml to `Content/Views/SearchView.xml`

2. Make the following changes in the XML:

   - Remove any Id, xmlns and LoadOnDemand attribute on the root element.

   - Add xmlns, xmlns:xsi and xsi:schemaLocation attributes to enable XML intellisense: 

     ```xml
     <SearchView xmlns="Delight" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="Delight ../Delight.xsd">
     ```

   - Comment all the content inside the root element of the XML (or remove it), we'll uncomment/add it after step 3.

   - Switch to unity editor and it will process the XML and create `SearchView_g.cs` which is the code generated for the view, containing constructors, data templates and dependency properties.

3. Create a new file called SearchView.cs with the following content:

   ```C#
   using Assets.MarkUX.ViewModels;
   
   namespace Delight
   {
       public partial class SearchView
       {
       }
   }
   ```

   - Copy the namespaces from the old SearchView.cs file to the new SearchView.cs file. 

   - Copy the content of the old SearchView class to the new SearchView class.

   - If the old view is a partial view, you need to copy any other part of the partial views that exist. E.g. PlayerProfileView was a partial view and another part resided in PlayerProfileEquipments.cs -  the file was copied to the views folder and the namespace in the file was changed to Delight. The steps below need to be done in both files. 

   - You'll most likely receive a few compilation errors at this point. Common errors:

     `xyz does not contain a definition for 'Value'`  - occurs because Delight accesses values directly, so remove ".Value"

   - Rename any ObservableList to BindableCollection. And make the below changes to the presentation class used in the list. 

   - Rename the namespace of any presentation classes used to: `Rivality.Models` and have the presentation class inherit from BindableObject:

     ```c#
     using Delight;
     
     namespace Rivality.Models
     {
     	public class SearchItemPresentation : BindableObject
     	{
     		public Guid UId;
     		public string Name;
     		// ...
     ```

     Resolve any resulting compilation errors of type `The type or namespace name 'SearchItemPresentation' could not be found` by adding the namespace Rivality.Models to those files.
     
     If there are any assets, e.g. sprites, referenced in the presentation class, you need to create an equivalent Delight wrapper version: 
     
     ```c#
     	public class SearchItemPresentation : BindableObject
     	{
     		public Sprite Sprite; // TODO <- only here for backwards compatibility, removed when all views are migrated to Delight
     		public SpriteAsset SpriteAsset; 
     ```

4. Now it's time to add/uncomment the XML in the root element in SearchView.xml. 

   - Rename any BackgroundImage to BackgroundSprite in the XML. 

   - Assets are referenced by the asset name without "?" prefix. So `<Image Sprite="?SomeAsset">` becomes `<Image Sprite="SomeAsset">`. The XML intellisense auto-completes asset names and should warn if the asset name isn't accurate. Also sometimes two assets have the same name, then you need to further specify the bundle (same name as the sub-folder) it resides in, e.g: `<Image Sprite="AllianceProfile/WarRoom" />`. 

   - Remove all equal signs from binding, so `{=Property}` becomes `{Property}`. This because all bindings are now one-way by default except for checkbox and slider values, and input-field text, which are two-way by default. If you for some reason need to override the default behavior the prefix "=" sets the binding to be two-way and "-" sets the binding to be one-way. 

   - Search for List and VirtualizedList and change `<VirtualizedList Items="{MyItems}">` to `<List Items="{myItem in MyItems}" IsVirtualized="True">`, *myItem* is the item variable and you can name it anything you want (only make sure the name is unique if you have nested lists). Then change all bindings to Item from e.g. `<Label Text="{#=Item.PlayerName}>"` to `<Label Text="{myItem.PlayerName}">`. 

   - Rename VirtualizedListItem to ListItem. And remove any IsTemplate="true" from ListItem. 

   - Binding to the Id property is no longer allowed (search the XML for `Id="{` to find it). You can pass it along the data as a parameter to the action handler. So you can change: `<Button Id="{tab.Id}" Click="SwitchTabClick">` to `<Button Click="SwitchTabClick(tab.Id)">`  and change the code-behind to take the string Id as a parameter `public void SwitchTabClick(string tabId)`. Note if you can pass item data directly which might be preferable.

   - Switch to editor and new code will be generated. You'll likely receive many compilation errors at this point.

   - Note that XML parse errors now show up in ConsolePro under the Delight tab, and by double-clicking on the log entry you'll be taken to the line in the XML where the error was found. 

   - In the code, remove references to views like `public Group TabPanel;`  This will remove errors like:

     `The type 'SearchView' already contains a definition for 'xyz'`

     ``Ambiguity between 'SearchView.xyz' and 'SearchView.xyz'`

     These are references to views that now are generated automatically. Simply remove them from the SearchView class.

   - Convert dependency fields to dependency properties. This will remove errors like:

     `Cannot implicitly convert type 'bool' to 'MarkLight._bool'`

     You do this by removing the dependency field, e.g. `public _Color AlliancesTabColor;` and declaring the dependency property it in the root element of the SearchView.xml:

     ```xml
     <SearchView AlliancesTabColor="t:Color">
     ```

     This tells the framework to generate the dependency property AlliancesTabColor of the type Color (note that the type shouldn't start with underscore anymore as it's no longer a dependency field). 

     Fix any resulting errors like: `xyz does not contain a definition for 'Value'` by removing `.Value`

   - Generic list such as `ObservableList<SearchItemPresentation>` are renamed to BindableCollection and generic parameters are specified using `[type]` instead of `<type>` because of XML restrictions. Example:

     ```xml
     <SearchView SearchResults="t:BindableCollection[SearchItemPresentation]">
     ```

     Assets properties bound to the presentation class, that was renamed in Step 3, need to be renamed in the XML: 

     ```xml
     <Image Sprite="{searchResult.SpriteAsset}" /> 
     <!-- changed from Sprite="{#Item.Sprite}" -->
     ```

   - Sprites or other assets that are dynamically loaded through RivalityAssetBundleManager in code like `RivalityAssetBundleManager.Instance.GetSprite("LevelOwn")` can now be accessed directly through the `Assets.Sprites` data provider that is generated dynamically, e.g. the LevelOwn sprite can be accessed through `Assets.Sprites.LevelOwn` the type is `SpriteAsset` which is the Delight wrapper for Sprites and handles the on-demand loading/unloading of the asset. Similar objects are created for all other asset types used in the framework, e.g. MaterialAssets reside within `Assets.Materials`, fonts in `Assets.Fonts`, etc.

   - See `AllianceManager.Instance.GetFlagSpriteAsset()` for an example on how to get assets based on dynamic asset ID, e.g. `Assets.Sprites[flagName]`

   - If there are any virtualized list click handlers, rename the parameter VirtualizedItemSelectionActionData to  ItemSelectionActionData. If you haven't done it you'll get the following exception when clicking on list items: `ArgumentException: Object of type 'Delight.List' cannot be converted to type 'MarkLight.Views.UI.VirtualizedItemSelectionActionData'.`

5. Open `Content/Views/MainViewManager.xml` (the corresponding view manager for Delight) and add the SearchView with Id. 

```xml
<ViewSwitcher Id="Switcher" ShowFirstByDefault="False">
    ...
    <SearchView Id="SearchView" />
    ...
</ViewSwitcher>
```

6. Edit ViewManager.cs (1680) in CheckIfDelightView() and add a switch case for the view that has been migrated. Edit MainViewManager.cs (493 & 682) inside the methods GetViewFromViewType() and GetTypeFromViewType(), uncomment the switch case for the view you migrated. Now the new view can can be opened after next step.

7. Run the scene and if you check the "Enable Delight" checkbox, the new view will be opened when the old one used to open. Use this to compare between the old and new and verify that everything looks and behaves the same. Due to the differences between the versions it's likely there will be issues that needs to be fixed.

   ![Open Delight Window](C:\Projects\GitProjects\Delight\Documentation\Migration Guide\DelightCheckbox.png)



## Change Log

- View UserInterface replaced by UICanvas
- ViewSwitcher property SwitchToDefault renamed to ShowFirstByDefault
- Localization dictionary renamed to Loc, {@Loc.123}, however {@Localization.123} still works. 
- Bindings are now one-way by default, the "=" prefix now denotes two-way bindings.
- Integration with Console Pro so XML included in stack-trace and double-clicking on log takes you to the line in the XML file.
- Better intellisense in XML, auto-complete added for styles and assets.
- Assets (sprites, fonts, etc.) now specified without path and extension in XML: `<Label FontMaterial="Fonts/EN_RobotoCondensed_Bold_Shadow.mat" />` becomes `<Label FontMaterial="EN_RobotoCondensed_Bold_Shadow" />` 
- SortIndex now an attached property, so if you want to change a child views sort index in a group, you change, e.g. `<Region SortIndex="{IsTabVisible}">` to `<Region Group.SortIndex="{IsTabVisible}">`



## TODO

- Create docs for Assets, Views, Models, On-demand loading, etc.
- Create docs for API
- Create quick-start guide #1, #2, #3
- Create guide for Config.txt 
- Create guide for enabling Editor Console Pro integration
- Create guide for value converters