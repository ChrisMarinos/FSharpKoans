namespace FSharpKoans
open NUnit.Framework

(*
Finding the length of a list.

Suggestion: before you do the next few files, read through and
understand this function:

let f xs =
   let rec innerF xs out =
      match xs with
      | [] -> out
      | _::rest -> innerF rest (1::out)
   innerF xs []

This is one of the idioms that you'll see (and use) again and again.

HINT: If you can't figure out what it does after reading through it and thinking about
it for a while, select it and push it down to the F# Interactive prompt using Alt+Enter.
Run it with some sample input, and see what it produces.

Never used the Interactive window before?  Now's your chance ^_^.  Read the
"Interactive Programming with F#" section at
https://msdn.microsoft.com/en-us/library/dd233175.aspx

Suggestion: You can push short pieces of code down to the F# Interactive window.
So it's great for testing out functions in isolation, without having to recompile and
re-run tests.  It's also great for trying out lines of code, identifying types, and so on.
Efficient use of this functionality can make you much, much more productive in a
short amount of time.
*)

module ``12: Finding the length of a list`` =

    (*
        Once you've learned about the Easy Way of doing something,
        go ahead and use it in subsequent tests.
    *)

    [<Test>]
    let ``01 Finding the length of a list, the hard way`` () =
        let length (xs : 'a list) : int =
            __ // write a function to find the length of a list
        length [9;8;7] |> should equal 3
        length [] |> should equal 0
        length ["Le Comte de Monte-Cristo"] |> should equal 1
        length [9;3;4;1;6;5;4] |> should equal 7

    // Hint: https://msdn.microsoft.com/en-us/library/ee340354.aspx
    [<Test>]
    let ``02 Finding the length of a list, the easy way`` () =
        __ [9;8;5;8;45] |> should equal 5
