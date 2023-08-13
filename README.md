Unity empty project template (UEPT)
===

This is an empty project which provide clear, low-cognitive complexity structure of Assets folders

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
<!-- TOC -->

## Problem

There are no project structure conventions and recomendations from Unity. It means that every package, external SDK or Asset Store assets can be organized differently.

Every imported asset creates their own folder (or folders). Your project folders mixed up with imported plugins folders thereby clogging up the project hierarchy. 
And after some time of developing the project you have to spend more and more time to find your own folder in hierarchy. 
The structural cognitive complexity of the prject becomes tromediously high. As the result you have to spend more time to find the assets then fix the problem or create the feature.

## Solution

Create the universal empty project which will help you to setup your project in the right way. By separating assets to:
- Your assets
- Imported assets
- Departments assets

The way to do that:
1. Separate your content to special folder "_Project". The undercore symbol move that folder to the top of the Project tab in hierarchy.
2. Separate content by departments folder. Art, Develop, GameDesign
3. Put all external resources like: server-side code, configs, build configurations, editor third party assets outside unity folder. To the root of repo hierarchy

Instead:
```
Assets
  |-- AirTest (external asset)
  |-- Animators (your folder)
  |-- AppsFlyer (external asset)
  |-- Audio (your folder)
  |-- Demigiant (external asset)
  |-- Editor (your folder)
  |-- Effects (your folder)
  |-- ExternalDependencyManager (external asset)
  |-- Facebook (external asset)
  |-- Firebase (external asset)
  |-- Plugins (combination of your and imported assets)
  |-- Prefabs (your folder)
  |-- Resources (combination of your and imported assets)
  |-- Scripts (your folder)
  |-- Shaders (your folder)
  |-- Streaming Assets
```

It Looks quite messy, isn't it? And just try to imagine what it's like to work with it every day. 

And the way to streamline that mess:
```
Assets
  |-- _Project (your project folder with all YOUR assets)
    |-- Art
      |-- Prefabs
      |-- Shaders
    |-- Develop
      |-- %company_name%
        |-- %project_name%
          |-- Editor
          |-- Runtime
          |-- Tests
    |-- Plugins
    |-- Prefabs
    |-- Resources
  |-- AirTest (external asset)
  |-- AppsFlyer (external asset)
  |-- Demigiant (external asset)
  |-- ExternalDependencyManager (external asset)
  |-- Facebook (external asset)
  |-- Firebase (external asset)
  |-- Plugins (ONLY external assets files)
  |-- Resources (ONLY external assets files)
```

And when you need to now only one thing: "_Project" folder contains all my assets. That's it. No more paint and brainfuck while looking for required folder.

## Installation
1. Clone the repo
2. Rename UEPT prefix to your project abbreviate. It has to be less then 5 symbols. But it's up to you.
3. Open the UEPT.Unity project via Unity Hub.
4. Rename "CompanyName" folder in '_Assets/Develop/` to your company name. Or remove that folder if you won't import code from other company's projects.
5. Pick the folders which you will use in your project. Others can be deleted.
6. In similar way, rename all asmdef files
7. Rename `COMPANYNAME_PROD` define
8. Check and remove example code. See also: Predefined scripts

### Dependencies
- [VContainer](https://github.com/hadashiA/VContainer) - imported to the template via Package Manager
- [UniTask](https://github.com/Cysharp/UniTask) - imported to the template via Package Manager

### Example
Just run the `0.Bootstrap` scene and check the logs

### TODO 
Create setup wizard to automate steps 4-9

## Folders purpose

Optional folder means it can be deleted. The folders without it should be left as it is. You organize it as you want ¯\_(ツ)_/¯

### Root
- `UEPT.Backend` - optional folder with backend side of the project. I don't insist on containing backend part within client part. You have to decide it personaly.
- `UEPT.Build` - optional folder with CI/CD scripts to build Unity project or backend.
- `UEPT.ExternalConfigs` - optional folder to collect client/backend external configuration. csv, excel, json files.
- `UEPT.ThirdParty` - optional folder for all binary folder which client/backend can use. Example: Unity Content Delivery binaries
- `UEPT.Unity` - unity project folder

### Assets/_Project
- `Art` - art department folder where you can collect all 3D models, sprites, animations, terrains, shaders and etc.
- `Develop` - development department folder where you can collect all ScriptableObjects (Configs folder), scripts (inside CompanyName/ProjectName folders)

### Assets/_Project/Develop/CompanyName/ProjectName
- `Editor` - editor scripts which won't be included in platform build
- `Runtime` - production code
- `Shared` - optional folder with shared. Classes which use on client and backend side.
- `Backend` - optional folder with client's transport layer. Can't contain unity engine references. Can by used to mock the client side.
- `Tests`
  - `EditMode` - optional folder with edit mode scripts
  - `PlayMode` - optional folder with play mode scripts

## Predefined scripts

You can delete all this scrips, or change it as you want. They are 

- `*Scope` - realisation of Register/Resolve/Release pattern. In template I use VContainer to define all dependencies
- `*Flow` - initialization.
- `LoadingService` - helper service. Run `LoadUnit`s where `LoadUnit` is unit of initialization
- `Logging` - helpers for logging
  - `TagLog` - helper class which logs all stuff
If you compile with `COMPANYNAME_PROD` define (must be renamed) all debug logs and their string allocations will be deleted from the build.
  - `Log` - static class which you must be used instead of `UnityEngine.Debug`.
  - `BuilderLogPool` - `StringBuilder` decorator which allows you to reuse pre-allocated builders to create looong strings to log
- `SceneManager` - virtial a helper class for scenes switching

## Predefined scenes structure

- `0.Bootstrap` - setup project dependencies and services.
- `1.Loading` - GDPR, authorization, login, content downloading and etc.
- `2.Meta` - optional meta part of the application. UI, IapShop, saga map, archivements, heroes progressing and etc.
- `3.Core` - Core part of the application. The reusable part of the application where users spend the most of the time.

## Contribute

Don't hesitate to suggest you vision of project structure. Just create an issue or pull request.
