This is a set of bindings for https://github.com/vurtun/nuklear written in C# for the .NET framework.

It relies on https://github.com/mellinoe/nativelibraryloader (imported via NuGet) for .NET Core-related reasons.

**Also, consider checking out https://github.com/cartman300/NuklearDotNet ** (which is based on this project, but the author has gotten further than I have. They've got a sample application working! And it's clean P/Invoke. But I'll keep doing my thing here.')

The bindings are low-level. Pointers abound. I tried to write something not wrong, rather than something pleasant to use.

There aren't any samples or anything. I've only just finished writing this.

It hasn't been tested yet, but I have at least got the sizes of all the enums and structs from the C header verifiably correct.

It *should* work on both x86 and x64 architectures, and across runtimes, but only x64 on .NET Core 2.0 on Mac OS X has been used so far.

See the nuklear/ for the checked-in copy of Nuklear, and the define flags used.

**LICENSE: Dual-licensed under MIT and The Unlicense. Your choice.**

Contributions extremely welcome. I'll at least check in binaries for nuklear on Windows x86 & x64 and Linux x64 at some point. (Just OSX x64 right now.)

