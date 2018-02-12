# Functional Koans - F# #

The goal of these is to teach you functional programming in general, and F# in specific, through testing.

## Quick Start ##

1. If you're using Visual Studio (or VS Code), you'll need to install the [NUnit 3 Test Adaptor Extension](https://marketplace.visualstudio.com/items?itemName=NUnitDevelopers.NUnit3TestAdapter).  If you're running Xamarin, you need to be able to run NUnit tests (but, to my everlasting shame, I have not worked with such a setup, and cannot offer advice!).  I'm using VS2015, but everything should work with VS2012 upwards &mdash; if not, please let me know.
2. Clone this repository.
3. Open & build the solution.  This should download and install FsUnit and dependencies (via [NuGet](http://nuget.org/)) for you as well.
4. ![Group by class](GroupByClass.png?raw=true)

   Open up the test explorer and set it to group by class.
5. ![Test Explorer, VS2015](ExplorerScreenshot.jpg?raw=true)

   Now run all the tests.

Oh no!  The tests are all failing!  Start with the first test (you should be able to double-click on it), fix it, move on to the next :smile:.  It will help to read all the comments in a file.  Each test has something to teach you (I hope!).

## Acknowledgements

This repo was originally forked from Chris Marinos' original [F# Koans](https://github.com/ChrisMarinos/FSharpKoans) (which was, in turn, inspired by EdgeCase's fantastic [Ruby koans](http://github.com/edgecase/ruby_koans)).  There isn't a lot of Chris's code left &mdash; much like [Theseus' ship](https://en.wikipedia.org/wiki/Ship_of_Theseus), the vast majority of the "planks" have been replaced! &mdash; but this project would probably never have begun had it not been for his work.

## Contributions

Contributions, corrections, and better ways of teaching through testing are most welcome!  And, of course, bug reports are just as welcome.  The usual way of doing these things via GitHub applies :smile:.
