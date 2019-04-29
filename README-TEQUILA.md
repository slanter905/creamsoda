Tequila
=======

Tequila is a general purpose patcher that can keep software up to date and launch it.

It was originally created for Titan Icon, a project that required relocating existing software into a different folder before patching it. In its current state, it's trivial to modify it for use with other software.

The initial commit still has some hard-coded links for Titan Icon. The manifest URL has been left in for use as pseudo-documentation on what's expected from the XML file.

Features
=======

Contained in a single executable: users only need to download one file and run it; it will find the existing installation, relocate itself to it, and create a desktop shortcut.

Patches itself: Tequila will compare its own MD5 sum to the one in the manifest file, update itself if needed, and restart.

Multiple download links: each file in the manifest can have any number of source URLs. Tequila will pick one randomly, and attempt another if the first one fails; it will only error out after trying all the links.

Multiple launch profiles: it can be used to launch the same executable with different parameters, or different executables.

Developer-only profiles: certain launch profiles will be hidden from the launch list unless Tequila is started with -dev.

Bypasses User Account Control: it will relocate an existing installation to Local App Data, to avoid problems with UAC and VirtualStore.

Command Line Options
=======

-noselfpatch: do not attempt to patch itself.

-md5: generates an MD5 sum of itself and copies it to the clipboard, for use it with self patching.

-dev: display the devlaunch profiles.

-nomove: do not relocate Tequila to the install folder.

