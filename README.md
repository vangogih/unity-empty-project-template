Unity empty project template (UEPT)
===

This is an empty project which provides a clear, low-cognitive complexity structure of Assets folders

<!-- TOC -->
* [Unity empty project template (UEPT)](#unity-empty-project-template--uept-)
  * [Problem](#problem)
  * [Solution](#solution)
  * [Installation](#installation)
    * [Dependencies](#dependencies)
    * [Example](#example)
    * [TODO](#todo)
  * [Folders purpose](#folders-purpose)
    * [Root](#root)
    * [Assets/_Project](#assets-_-project)
    * [Assets/_Project/Develop/CompanyName/ProjectName](#assets-_-projectdevelopcompanynameprojectname)
  * [Predefined scripts](#predefined-scripts)
  * [Predefined scenes structure](#predefined-scenes-structure)
  * [Contribute](#contribute)
  * [Licence](#licence)
<!-- TOC -->

## Problem

There are no project structure conventions and recommendations from Unity. It means that every package, external SDK, or Asset Store asset can be organized differently.

Every imported asset creates its folder (or folders). Your project folders mixed up with imported plugins folders thereby clogging up the project hierarchy.
And after some time developing the project you have to spend more and more time finding your folder in the hierarchy.
The structural cognitive complexity of the project becomes tremendously high. As a result, you have to spend more time finding the assets and then fixing the problem or creating the feature.

## Solution

Create the universal empty project which will help you to setup your project in the right way. By separating assets to:
- Your assets
- Imported assets
- Departments assets

The way to do that:
1. Separate your content into the special folder "_Project". The underscore symbol moves that folder to the top of the Project tab in the hierarchy.
2. Separate content by department folder. Art, Develop, GameDesign
3. Put all external resources like server-side code, configs, build configurations, and editor third-party assets outside unity folder. To the root of the repo hierarchy

Instead:
```
+-- Assets
|   +-- AirTest (external asset)
|   +-- Animators (your folder)
|   +-- AppsFlyer (external asset)
|   +-- Audio (your folder)
|   +-- Demigiant (external asset)
|   +-- Editor (your folder)
|   +-- Effects (your folder)
|   +-- ExternalDependencyManager (external asset)
|   +-- Facebook (external asset)
|   +-- Firebase (external asset)
|   +-- Plugins (combination of your and imported assets)
|   +-- Prefabs (your folder)
|   +-- Resources (combination of your and imported assets)
|   +-- Scripts (your folder)
|   +-- Shaders (your folder)
|   +-- Streaming Assets
```

It Looks quite messy, isn't it? And just try to imagine what it's like to work with it every day.

And the way to streamline that mess:
```
+-- Assets
|   +-- _Project (your project folder with all YOUR assets)
|       +-- Art
|       +-- Prefabs
|       +-- Shaders
|       +-- Develop
|           +-- %company_name%
|               +-- %project_name%
|                   +-- Editor
|                   +-- Runtime
|                   +-- Tests
|       +-- Plugins
|       +-- Prefabs
|       +-- Resources
|   +-- AirTest (external asset)
|   +-- AppsFlyer (external asset)
|   +-- Demigiant (external asset)
|   +-- ExternalDependencyManager (external asset)
|   +-- Facebook (external asset)
|   +-- Firebase (external asset)
|   +-- Plugins (ONLY external assets files)
|   +-- Resources (ONLY external assets files)
```

And when you need to know only one thing: the "_Project" folder contains all my assets. That's it. No more paint and brainfuck while looking for the required folder.

## Installation
1. Clone the repo.
2. Rename the UEPT prefix to your project abbreviation. It has to be less than 5 symbols. But it's up to you.
3. Open the UEPT.Unity project via Unity Hub.
4. Rename the "CompanyName" folder in `_Assets/Develop/` to your company name. Or remove that folder if you won't import code from other companies' projects.
5. Pick the folders which you will use in your project. Others can be deleted.
6. In a similar way, rename all *.asmdef files.
7. Rename `COMPANYNAME_PROD` define.
8. Check and remove the example code. See also: [Predefined scripts](#predefined-scripts).
9. Remove the .git folder in the root
10. Enjoy!

### Dependencies
- [VContainer](https://github.com/hadashiA/VContainer) - imported to the template via Package Manager
- [UniTask](https://github.com/Cysharp/UniTask) - imported to the template via Package Manager

### Example
Just run the `0.Bootstrap` scene and check the logs

Or you can check an [example](https://github.com/vangogih/UEPT.Example) project.

### TODO
Create a setup wizard to automate steps 4-9

## Folders purpose

An optional folder means it can be deleted. The folders without it should be left as it is. You organize it as you want ¯\_(ツ)_/¯

### Root
- `UEPT.Backend` - optional folder with the backend side of the project. I don't insist on containing the backend part within the client part. You have to decide it personally.
- `UEPT.Build` - optional folder with CI/CD scripts to build Unity project or backend.
- `UEPT.ExternalConfigs` - optional folder to collect client/backend external configuration. CSV, Excel, JSON files.
- `UEPT.ThirdParty` - optional folder for all binary folders which client/backend can use. Example: Unity Content Delivery binaries.
- `UEPT.Unity` - unity project folder.

### Assets/_Project
- `Art` - art department folder where you can collect all 3D models, sprites, animations, terrains, shaders, etc.
- `Develop` - development department folder where you can collect all ScriptableObjects (Configs folder), and scripts (inside CompanyName/ProjectName folders).

### Assets/_Project/Develop/CompanyName/ProjectName
- `Editor` - editor scripts that won't be included in the platform build.
- `Runtime` - production code.
- `Shared` - optional folder with shared. Classes which use on the client and backend side.
- `Backend` - optional folder with client's transport layer. Can't contain Unity engine references. Can be used to mock the client side.
- `Tests`
  - `EditMode` - optional folder with edit mode scripts.
  - `PlayMode` - optional folder with play mode scripts.

## Predefined scripts

You can delete all these scrips, or change them as you want. There are:

- `*Scope` - realization of Register/Resolve/Release pattern. In the template, I use VContainer to define all dependencies.
- `*Flow` - initialization.
- `LoadingService` - helper service. Run `LoadUnit`s where `LoadUnit` is the unit of initialization.
- `Logging` - helpers for logging.
  - `TagLog` - helper class that logs all stuff.
    If you compile with `COMPANYNAME_PROD` define (must be renamed) all debug logs and their string allocations will be deleted from the build.
  - `Log` - a static class which you must be used instead of `UnityEngine.Debug`.
  - `BuilderLogPool` - `StringBuilder` decorator which allows you to reuse pre-allocated builders to create long strings to log.
- `SceneManager` - virtual a helper class for scene switching.

## Predefined scenes structure

- `0.Bootstrap` - set up project dependencies and services.
- `1.Loading` - GDPR, authorization, login, content downloading, etc.
- `2.Meta` - optional meta part of the application. UI, IapShop, saga map, achievements, heroes progressing, etc.
- `3.Core` - a core part of the application. The reusable part of the application is where users spend most of their time.
- `4.Empty` - optional empty scene to clean up all loaded resources in the previous scene.

## Contribute

Don't hesitate to suggest you vision of the project structure. Just create an issue or pull request.

## Licence
This library is under the MIT License.
