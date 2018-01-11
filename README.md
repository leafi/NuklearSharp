# NuklearSharp

This is a set of bindings for https://github.com/vurtun/nuklear written in C# for the .NET framework.

It relies on https://github.com/mellinoe/nativelibraryloader (imported via NuGet) for .NET Core-related reasons.

## ->NuklearDotNet

Straight P/Invoke? An actually working sample application?! Yeah, it looks like somebody took my code and got further than I have so far.

Check out their work at https://github.com/cartman300/NuklearDotNet! It looks pretty awesome to me. I am going to steal parts of it back. Fnar.

## About NuklearSharp

The bindings are low-level. Pointers abound. I tried to write something not wrong, rather than something pleasant to use.

There aren't any samples or anything. I'll probably get some up eventually.

These bindings haven't been directly tested yet, but I have at least got the sizes of all the enums and structs from the C header verifiably correct (see .c generator in Utilities.cs).

The library *should* work on both x86 and x64 architectures, and across runtimes, but only x64 on .NET Core 2.0 on Mac OS X has been compiled so far.

See the nuklear/ for the checked-in copy of Nuklear, and the define flags used.

**LICENSE: Dual-licensed under MIT and The Unlicense. Your choice.**

Contributions extremely welcome. I will check in binaries for nuklear on Windows x86 & x64 and Linux x64 eventually. (Just OSX x64 right now.)

