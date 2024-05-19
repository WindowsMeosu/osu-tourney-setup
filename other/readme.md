C++ port of the main source code (converted from C# using code conversion websites). Unless you have a pretty good reason, PR changes should not be made here. This exists mainly for those who do not want to install .NET Framework which is a neccessity to run .NET applications. Since most people already have .NET and/or .NET Framework installed (i assume, considering how annoying microsoft is with ~~forcing~~ "advertising" their own products to people) this likely will be almost never used but it's here just in case. If you don't want to compile (or if you don't have a C++ compiler) you can find a binary at Releases. 


Since the API used is Win32, it should be both compatible with x32 (i.e mingw32) and x64 (i.e mingw64) compilers.
\
My compiler of choice is msys64-mingw64.

Compile with ```-lShlwapi```