
                '      .'
           |   '|    .'
          . \_/  \_.',
    ..,_.' _____    (
     `.   |  __ \   '..o    o    o    o    o    o    o    o    o    o    o    o   o
       :  | |__) | ,' ___    _ __     ___    ___    _ __   _ __     _____  __   __
   ._-'   |  ___/ /  / _ \  | '_ \   / __/  / _ \  | '__| | '_ \   |  ___| \ \ / /
     `.   | |     ( | (_) | | |_) | | (_   | (_) | | |    | | | |  | |_     \ V /
     ,'   |_|    _`. \___/  | .__/   \___\  \___/  |_|    |_| |_|  |  _|     ) (
    ,.'"\  _.._ (  `'       |_|                                    | |      / ' \
   :'   | /    `' o    o    o    o    o    o    o    o    o    o   |_|     /_/ \_\
 ,"     ',
'       '
                                                    PopcornFX Realtime VFX Solution


    This program is the property of Persistant Studios SARL.

    PopcornFX
        http://www.popcornfx.com
        http://www.facebook.com/3D.PopcornFX
        http://www.twitter.com/popcornfx

================================================================================

PopcornFX is a 3D realtime VFX middleware for PC Windows/Linux/MacOSX, PS4, XBox
One, PS3, XBox 360, PS Vita, Wii-U, Android and iOS.
 - High performance and flexibility with powerful scripting system.
 - Designed for the video game industry.
 - Easy to integrate, efficient authoring, ready to run.
 - Highly optimized for each target platform.

PopcornFX's Unity Plugin is a simple integration of the PopcornFX runtime
libraries into Unity's rendering pipeline using Unity's native plugin interface.
Due to the public API limitations, some features cannot be integrated in Unity
yet.

The plugin requires Unity Pro.

Contact us at contact@popcornfx.com
For bug reports/support, use support@popcornfx.com

================================================================================

Popcorn Unity Plugin v2.2

    Supported platforms :
        - Win (D3D9, D3D11, OpenGL)
        - Mac OSX
        - Android (with NEON support)
        - iOS

================================================================================

HOW TO ?!?

    To add stunning FX to your Unity scene, proceed as follow :

        0. (If importing from the unitypackage file)
        In Unity, import the plugin package under Assets > Import Package >
        Custom Package then locate the plugin unitypackage file. Make sure you
        import everything.

        1. Create a new fx pack at your Unity project's root folder, name it
        anything but "PackFx".

        2. In your newly created pack's settings, make sure to set a new baking
        platform (PROTIP: name it Unity), set
	    "[UnityProjectRoot]/Assets/StreamingAssets/PackFx" for the target path.

        3. Make sure to set the axis system to "Axis_LeftHand_Y_Up" in the
        general settings.

        4. Make some awesome effects. Go crazy!

        5. Bake the effects you want to test in your Unity scenes, make sure you
        check the "Bake dependencies" checkbox. This should bake and copy all the
        required resources in the PackFx folder in the StreamingAssets, which is
        used by PopcornFX's runtime.

        6. In your scene, add a PKFxFX component to the GameObject you want an fx
        on, drag and drop a pkfx file in the "FX" slot.

        7. Attach the PKFxRenderingPlugin component to all your cameras you want
        effects in. Make sure to tick "Has postFx" if your cam also has image
        effects to prevent axis flipping.

        8. Hit run. You should now have effects in your camera's viewport.

    For a better rendering, make sure to set the color profile to linear in your
    project's player settings (see
    http://docs.unity3d.com/Manual/LinearLighting.html).

DEPLOYMENT :

        1. Make sure your baked PackFx is up-to-date.

    /!\ For android deployment :

            1.b In the "Assets" Menu, click "Android Deployment>Create PKFx
            Packs's Index". This will create the necessary index and hashes to
            copy the pack from the application package to the device's
            filesystem.

        2. Build your game and run it!

    /!\ For iOS deployment :

            2.b In Xcode, go to your project's "Build Phases" tab, under "Link
            Binary With Libraries", add an item and select "libc++.dylib".
            Your app should then compile and link correctly.

================================================================================

CHANGELOG

    v2.2
        - Fixed audio sampling on MacosX
        - Fixed DX11 LOD bias
        - OSX binaries now Universal (x86 and x86_64)
        - Soft animation blending now supported in GL/DX9/DX11
        - Fixed DX11 depth texture update bug (soft particles and distortion)
        - Fixed component.camera api deprecation for Unity 5
        - Drag'n'drop .pkfx files on FX components instead of the unconvenient
          list

    v2.1
        - Proper color space detection (sRGB/gamma correction)
        - Distortions blur pass (Blue channel)
        - Fixed distortions bug
        - Massive renames to comply with naming convention
          /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\
          /!\/!\/!\ THIS WILL BREAK MANY PREEXISTING FX COMPONENT!    /!\/!\/!\
          /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\
        - DX11 bugfixes, proper distortions and soft particles
        - Fixed mobile crash on some sampling functions
        - Masked event ids to prevent interfering with other native plugins
        - Fixed bug where additive meshes were never culled
	    - Fixed lost devices in DX9
	    - Fixed depth/distortion FOV bug
	    - Fixed distortion viewport bug
	    - Windows x32/x64 support.

    v2.0
        - Distortions!
        - Mobile depth-related rendering features (soft particles, distortion).

        - PackFX hierarchy : effects are now accessible at any pack subdirectory
        - Packs must now be baked in the StreamingAssets directory.
          /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\
          /!\/!\/!\ THIS WILL BREAK ANY PREEXISTING FX COMPONENT!     /!\/!\/!\
          /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\   /!\

    v1.08
        - Refactoring of the PKFxManager static class to account for iOS' static
        libraries limitation.

================================================================================

Known bugs.

    - Integer attributes may not display in the editor and break the FX
    component's attributes view.

    - VelocityCapsuleAligned billboarders produce visual glitches on Android.
