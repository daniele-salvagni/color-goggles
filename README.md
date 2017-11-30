# ColorGoggles

Saturation manager for Intel™ and Dual-Graphics laptops.

<p align="center">
<img src="https://user-images.githubusercontent.com/6751621/33404619-40cd918c-d565-11e7-9d63-d0ec502b5d86.png">
</p>

ColorGoggles is an extremely lightweight application that automatically manages your digital saturation when playing games to enhance visibility.
This application is absolutely Vac safe, many professional players are known to tweak their digitar saturation.
This is an alternative to VibranceGUI for people with Intel HD Graphics or dual-graphics laptops.

### Installation instructions ![Important](https://user-images.githubusercontent.com/6751621/33405314-0f6189ca-d568-11e7-966c-d4e0d89d6f50.png)

- Download and extract the .zip
- Open `C:\Windows\System32\DriverStore\FileRepository` and do a search for a file named `igfxDHLib.dll`
- Copy `igfxDHLib.dll` in the same folder as `ColorGoggles.exe`

You have to do this because there are multiple versions of `igfxDHLib.dll` (they are all marked as `1.0.0.0` but are different), so I cannot embed the interop types in the .exe nor give you my DLL as it wouldn't work in most cases.


### Usage

- Add the process name of the game you want to add
- Configure at will
- Have fun!


### Download

You can find the latest release (.zip) here: https://github.com/daniele-salvagni/color-goggles/releases

---------------

#### Changelog

- v0.2-beta <sup>(0917)</sup>: Fix crashes for devices with different igfx versions, add UI support for high DPI displays, add new installation instructions.
- v0.1-beta <sup>(0417)</sup>: Initial release.


<sub>This is a very early version, it was initially not intended for public release and the code wouldn't mind a refactor. Saturation is changed using Intel's `igfxDHLib.dll` which is undocumented, there are no public APIs so I had to reverse engineer the *Intel HD Graphics Control Panel* and then proceed by trial and error.<sub>
