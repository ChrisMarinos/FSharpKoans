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

## Getting Started

The F# Koans currently target any editor that can work with .Net Core. We suggest using Visual Studio Code with the Ionide plugin. The koans
should also work Visual Studio for Mac, Jetbrains Rider, emacs, vim, and atom.

### Running the Koans from the command line (dotnet CLI)

The following instructions will run the Koans without the need for Visual Studio, MonoDevelop, etc.
The only requirements are the [dotnet CLI](https://www.microsoft.com/net/core) and [FSharp](http://fsharp.org).

1. In a terminal, navigate to the root of the __FSharpKoans__ repo (repo_root/FSharpKoans).

1. Build the solution:
```bash
dotnet restore
dotnet build
```

You can now run the Koans:

```bash
dotnet run
```

If you prefer a more interactive experience, you can use the included `dotnet-watch` cli command to rebuild when you save a file:

```bash
dotnet watch run
```
