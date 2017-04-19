# ColorGoggles

Saturation manager for Intel™ and Dual-Graphics laptops. https://daniele-salvagni.github.io/color-goggles/

<p align="center">
<img src="https://cloud.githubusercontent.com/assets/6751621/25193730/5579ccfa-2538-11e7-962e-ec0850284ebf.png">
</p>

ColorGoggles is an extremely lightweight application that automatically manages your digital saturation when playing games to enhance visibility.
This application is absolutely Vac safe, many professional players are known to tweak their digitar saturation.
This is an alternative to VibranceGUI for people with Intel HD Graphics or dual-graphics laptops.

This is a very early version, it was initially not intended for public release and the code is in need of a complete refactor. Saturation is changed using Intel's `igfxDHLib.dll` which is undocumented, there are no public APIs so I had to reverse engineer the *Intel HD Graphics Control Panel* and then proceed by trial and error.
