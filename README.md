# Unity empty project template (UEPT)

This is an empty project which provide clear, low-cognitive complexity structure of Assets folders

# The problem

There are no project structure conventions and recomendations from Unity. It means that every package, external SDK or Asset Store assets can be organized differently.

Every imported asset creates their own folder (or folders). Your project folders mixed up with imported plugins folders thereby clogging up the project hierarchy. 
And after some time of developing the project you have to spend more and more time to find your own folder in hierarchy. 
The structural cognitive complexity of the prject becomes tromediously high. As the result you have to spend more time to find the assets then fix the problem or create the feature.

# The solution

Create the universal empty project which will help you to start your project in the right way. By separating assets to:
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

# Installation
1. Clone the repo
2. Rename UEPT prefix to your project abbriviature. It has to be less then 5 symbols. But it's up to you.
3. Open the UEPT.Unity project via Unity Hub.
4. Rename "CompanyName" folder in '_Assets/Develop/` to your company name. Or remove that folder if you won't import code from other company's projects.
5. Pick the folders which you will use in your project. Others can be deleted.
6. In similar way, rename all asmdef files

## TODO 
Create setup wizard to automate steps 4-6
