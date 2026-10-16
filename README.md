# Assembly-CSharp (ACS unofficial)

Decompiled source of the game's `Assembly-CSharp.dll`, the main Unity script assembly, it holds the game logic code.

The project is set up so it can be edited and rebuilt into a new DLL.

## What's inside

- Gameplay: players, AI, animation state machines, skills, weapons, items and inventory
- UI views (built on LibUniSWF)
- Networking (Photon)
- Achievements, guilds and other game services

## Building

- Open `Assembly-CSharp.sln` in Visual Studio, Rider or MonoDevelop
- Target framework: .NET 3.5 (Unity)
- Reference the game's own DLLs: `UnityEngine`, `Assembly-CSharp-firstpass`, `Assembly-UnityScript-firstpass`, `LibUniSWF` and `Photon3Unity3D`
- Replace the original `Assembly-CSharp.dll` in the game's `Managed` folder with the built one

## Contributions disclaimer

AI-assisted contributions will not be accepted unless the contributor fully understands what they are trying to integrate, if you can't explain your changes and why they work, they will be rejected.

## Notes

This is an unofficial, community project, class and namespace names that were obfuscated (e.g. `ns0`) are left as decompiled.
