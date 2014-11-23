# Functional Koans - F# #

Inspired by EdgeCase's fantastic [Ruby koans](http://github.com/edgecase/ruby_koans),
the goal of the F# koans is to teach you F# through testing.

When you first run the koans, you'll be presented with a runtime error and a
stack trace indicating where the error occured. Your goal is to make the
error go away. As you fix each error, you should learn something about
the F# language and functional programming in general.

Your journey towards F# enlightenment starts in the AboutAsserts.fs file. These
koans will be very simple, so don't overthink them! As you progress through
more koans, more and more F# syntax will be introduced which will allow
you to solve more complicated problems and use more advanced techniques.


### Getting Started

The F# Koans currently target Visual Studio 2010. The koans
should also work with Visual Studio 2008, Visual Studio 11+, command line Mono, MonoDevelop, and Xamarin Studio.

*NOTE: [NuGet](http://nuget.org/) is required to properly resolve dependencies.*

### Running the Koans in Visual Studio

1. Open the Visual Studio project, right click on the "FSharpKoans" project in the solution explorer 
   and select "Set as StartUp Project".

2. Turn off User-unhandled Exceptions. Go to Debug|Exceptions and uncheck the User-unhandled box 
   from the Common Language Runtime Exceptions item.

You can now run the Koans by selecting Debug|Start Debugging (defaults to f5).

### Running the Koans from the command line (Mono)

The following instructions will run the Koans without the need for Visual Studio, MonoDevelop, etc. 
The only requirements are [Mono](http://www.mono-project.com/download/), [FSharp](http://fsharp.org), and [NuGet](http://nuget.org/nuget.exe).

1. In a terminal, navigate to the root of the __FSharpKoans__ solution directory.

2. Restore all NuGet packages (replace _/Path/To/NuGet_ with the appropriate directory for your 
   environment): 
   ```
   mono /Path/To/NuGet/nuget.exe restore FSharpKoans.sln
   ```
 
3. Build the solution: 
   ```
   xbuild FSharpKoans.sln
   ```

You can now run the Koans (the following assumes your output path is _bin/Debug_): 
```
mono FSharpKoans/bin/Debug/FSharpKoans.exe
```
