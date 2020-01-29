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

### Running with Docker

To launch in watch mode using docker run the following command;

`$ ./docker.sh`

### Prerequisites

The F# Koans needs [.Net Core 2.0](https://www.microsoft.com/net/download/core) or [.Net Core 3.0](https://www.microsoft.com/net/download/core) to be built and run,
make sure that you have installed it before building the project.

Additionally, the project provides [Visual Studio Code](https://code.visualstudio.com/) configuration for running.
To be able to run F# projects in Visual Studio Code, the
[Ionide plugin](https://marketplace.visualstudio.com/items?itemName=Ionide.Ionide-fsharp) should be also installed.

### Running the Koans from the command line (.Net Core)

1. To build the Koans, run `dotnet build` command in the project root.

2. To run the Koans, run `dotnet run -p FSharpKoans/FSharpKoans.fsproj --framework netcoreapp2.0` or `dotnet run -p FSharpKoans/FSharpKoans.fsproj --framework netcoreapp3.0` command in the project root
or `dotnet run --framework netcoreapp2.0` or `dotnet run --framework netcoreapp3.0` in `FSharpKoans` project directory.

### Running the Koans in Visual Studio Code

1. Open the project directory in Visual Studio Code with Ionide-fharp plugin installed
and press F5 to build and launch the Koans (require some time to build the project before launch).

### Using dotnet-watch

You can also use [dotnet-watch](https://github.com/aspnet/Docs/blob/master/aspnetcore/tutorials/dotnet-watch.md) to have your changes reloaded automatically.
To do so, navigate into `FSharpKoans` directory and run `dotnet watch run --framework netcoreapp2.0` or `dotnet watch run --framework netcoreapp3.0`.
Now, after you change the project code, it will be automatically reloaded and tests rerun.
