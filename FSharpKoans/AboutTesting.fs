// a namespace CAN contain type definitions, but CANNOT contain bindings.
// What's a "binding"?  You'll see in AboutBindings.fs.
namespace FSharpKoans
// The "open" directive allows you to access a namespace or module without
// qualifying that access.  So if you wrote "open System", you'd be able to
// write "Console.WriteLine" instead of "System.Console.WriteLine".
// There's more about this in AboutModules.fs, later.
open NUnit.Framework

(*
Each of the tests teaches you something about functional programming and/or F# basics.
By the time you're done, you should have a basic understanding of how features
fit together and are used.  It's highly recommended to read all the comments.

In each test, you will see things like __ or FILL_ME_IN .
ONLY change those things, and you'll do fine :).

For some tests, you can just substitute possible things until the test passes.  But that won't
teach you anything!  So try to understand what you're doing, or what the test is trying to
show you, before you begin it.  That way, you will get the maximum amount of benefit from
these exercises.  And if you have just fiddled to make it pass, try to figure out why that
particular thing worked, and other things didn't.
*)

// A module can hold type definitions AND bindings.
module ``01: About Testing`` = 
    (*
        The two tests below also demonstrate how scoping in F# works.
        Multiple lines in the same block must start on the NEXT line and be indented to the same level.
        If the block consists of a single line, it can (usually) be put on the same line.

        Names are scoped to be accessible within the block that they are a part of, and
        (if the `rec` keyword is used) any sub-blocks.

        The following example shows you how NOT to do it:
    *)

    //[<Test>]
    //let ``My whitespace is messed up!`` () = (1 + 1) |> should equal __
        //(2 + 4) |> should equal __

    (*
        If you uncomment that example, you'll see that it won't compile.  That's
        because it uses MULTIPLE lines, but tries to put the first line of the block on the SAME line,
        and indent the rest of the lines of the block.  DON'T DO THIS!
    *)

    [<Test>]
    let ``01 How this works`` () = // In F#, any sequence of characters between `` marks can be identifiers.  ``This is a long method name`` is way better than ThisIsALongMethodName !
        let expected_value = 1 + 1
        let actual_value = __ //start by changing this line
        actual_value |> should equal expected_value
   
    // Easy, right? Now try one more.
    [<Test>]
    let ``02 Fill in the values`` () = (1 + 1) |> should equal __
