namespace FSharpKoans
open NUnit.Framework

(*
A 'fold' starts from a specified state, and generates more states depending
on the elements of the list.  The last state that is generated is the one which
is returned.

Sounds complex?  Nah, it's not really ;).  Let's go through an example:
you have a list of numbers, and you want to find their sum.  Your list is
[9;4;2;7;5].  Obviously, the sum is 9+4+2+7+5 = 27.  But let's work it
out using a fold operation.

We'll start from the specified state 0.  Every time that we look at a number,
we'll add it to the state, thus generating the next state.  At the end, we'll
take the last-generated state.

State=0, Element=N/A, NextState=N/A   <- this is our initial state.  Then,
State=0, Element=9, NextState=0+9=9
State=9, Element=4, NextState=9+4=13
State=13, Element=2, NextState=13+2=15
State=15, Element=7, NextState=15+7=22
State=22, Element=5, NextState=22+5=27
... and then we run out of elements.

The very last state that was generated was 27.  So that's what we return.

When you get used to thinking in the 'pattern' of folding, you'll start to
see them everywhere.  Whenever you've got a list of things, and you're
reducing them to one value (whether summing, averaging, concatenating,
or something else), it's likely that you'll be able to use a fold.
*)

module ``16: Welcome to the functional fold`` =
    [<Test>]
    let ``01 A fold which sums a list`` () =
        let fold initialState xs =
            __ // write a function to do what's described above
        fold 0 [1; 2; 3; 4] |> should equal 10
        fold 100 [2;4;6;8] |> should equal 120

    [<Test>]
    let ``02 A fold which multiplies a list`` () =
        let fold initialState xs =
            __ // write a function to multiply the elements of a list
        fold __ [99] |> should equal 99
        fold 2 [__] |> should equal 22
        fold __ [1;3;5;7] |> should equal 105
        fold __ [2;5;3] |> should equal 0

    // you probably know the drill by now.  It'd be good to have
    // a function which does the state-generation stuff, wouldn't
    // it?

    [<Test>]
    let ``03 Folding, the hard way`` () =
        let fold (f : 'a -> 'b -> 'a) (initialState : 'a) (xs : 'b list) : 'a =
            __  // write a function to do a fold.
        fold (+) 0 [1;2;3;4] |> should equal 10
        fold (*) 2 [1;2;3;4] |> should equal 48
        fold (fun state item -> sprintf "%s %s" state item) "items:" ["dog"; "cat"; "bat"; "rat"]
        |> should equal "items: dog cat bat rat"
        fold (fun state item -> state + float item + 0.5) 0.8 [1;3;5;7] |> should equal 18.8

    // Hint: https://msdn.microsoft.com/en-us/library/ee353894.aspx
    [<Test>]
    let ``04 Folding, the easy way`` () =
        __ (+) 0 [1;2;3;4] |> should equal 10
        __ (*) 2 [1;2;3;4] |> should equal 48
        __ (fun state item -> sprintf "%s %s" state item) "items:" ["dog"; "cat"; "bat"; "rat"]
        |> should equal "items: dog cat bat rat"
        __ (fun state item -> state + float item + 0.5) 0.8 [1;3;5;7] |> should equal 18.8
