<div align="center">

# 🌈 Color-Goggles

![](https://img.shields.io/badge/requires-igfxDHLib.dll-ff69b4.svg) ![](https://img.shields.io/badge/saturation-+320%25-green.svg) ![GitHub All Releases](https://img.shields.io/github/downloads/daniele-salvagni/color-goggles/total?color=%232d91e3)

Saturation manager (up to **320%**) for Intel™ and Dual-Graphics laptops. - http://dan.salvagni.io/s/color-goggles/  
</div>

<p align="center">
<img src="https://user-images.githubusercontent.com/6751621/34745778-e9e03b98-f591-11e7-98e8-0c47e67e45f6.png">
</p>

ColorGoggles is an extremely lightweight application that automatically manages your digital saturation when playing games to enhance visibility.
This application is absolutely Vac safe, many professional players are known to tweak their digital saturation.
This is an alternative to VibranceGUI for people with Intel HD Graphics or dual-graphics laptops.

## ⚡ Installation ![Important](https://user-images.githubusercontent.com/6751621/33405314-0f6189ca-d568-11e7-966c-d4e0d89d6f50.png)

- Download and extract the .zip
- Open `C:\Windows\System32` and use the Search function to find a file named `igfxDHLib.dll`
- Copy `igfxDHLib.dll` in the same folder as `Color-Goggles.exe`

You have to do this because there are multiple versions of `igfxDHLib.dll` (they are all marked as `1.0.0.0` but are different), so I cannot embed the interop types in the .exe nor give you my DLL as it wouldn't work in most cases.

**IMPORTANT:** If you are using the new Intel DCH Drivers and cannot find the DLL, follow these steps: https://github.com/daniele-salvagni/color-goggles/issues/16#issuecomment-513561967


### 📄 Usage

- Add the process name (.exe) of the games you want to play
- Check "Remove limits" to unlock saturations up to 320%
- Configure at will
- Have fun!


### 📥 Download

You can always find the latest release on the website: https://dan.salvagni.io/s/color-goggles/  

---------------

<sub>The saturation is changed using Intel's `igfxDHLib.dll` which is undocumented, there are no public APIs so I had to reverse engineer the *Intel HD Graphics Control Panel* and then proceed mostly by trial and error. Please report any issues you may encounter.<sub>
