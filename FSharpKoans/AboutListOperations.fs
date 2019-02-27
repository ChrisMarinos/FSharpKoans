namespace FSharpKoans
open NUnit.Framework

(*
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
*)

module ``14: List operations are so easy, you could make them yourself!`` =

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

    [<Test>]
    let ``03 Reversing a list, the hard way`` () =
        let rev (xs : 'a list) : 'a list =
            __ // write a function to reverse a list here.
        rev [9;8;7] |> should equal [7;8;9]
        rev [] |> should equal []
        rev [0] |> should equal [0]
        rev [9;3;4;1;6;5;4] |> should equal [4;5;6;1;4;3;9]

    // Hint: https://msdn.microsoft.com/en-us/library/ee340277.aspx
    [<Test>]
    let ``04 Reversing a list, the easy way`` () =
        __ [9;8;7] |> should equal [7;8;9]
        __ [] |> should equal []
        __ [0] |> should equal [0]
        __ [9;8;5;8;45] |> should equal [45;8;5;8;9]

    [<Test>]
    let ``05 Fixed-function mapping, the hard way (part 1).`` () =
        let map (xs : int list) : int list =
            __ // write a function which adds 1 to each element
        map [1; 2; 3; 4] |> should equal [2; 3; 4; 5]
        map [9; 8; 7; 6] |> should equal [10; 9; 8; 7]
        map [15; 2; 7] |> should equal [16; 3; 8]
        map [215] |> should equal [216]
        map [] |> should equal []

    [<Test>]
    let ``06 Fixed-function mapping, the hard way (part 2).`` () =
        let map (xs : int list) : int list =
            __ // write a function which doubles each element
        map [1; 2; 3; 4] |> should equal [2; 4; 6; 8]
        map [9; 8; 7; 6] |> should equal [18; 16; 14; 12]
        map [15; 2; 7] |> should equal [30; 4; 14]
        map [215] |> should equal [430]
        map [] |> should equal []

   (*
      Well, that was repetitive!  The only thing that really changed
      between the functions was a single line.  How boring.

      Perhaps we could reduce the boilerplace if we just specified
      the transforming function, and left the rest of the structure
      intact?
   *)

    [<Test>]
    let ``07 Specified-function mapping, the hard way`` () =
        let map (f : 'a -> 'b) (xs : 'a list) : 'b list =
            __ // write a map which applies f to each element
        map (fun x -> x+1) [9;8;7] |> should equal [10;9;8]
        map ((*) 2) [9;8;7] |> should equal [18;16;14]
        map (fun x -> sprintf "%.2f wut?" x)  [9.3; 1.22] |> should equal ["9.30 wut?"; "1.22 wut?"]

    // Hint: https://msdn.microsoft.com/en-us/library/ee370378.aspx
    [<Test>]
    let ``08 Specified-function mapping, the easy way`` () =
        __ (fun x -> x+1) [9;8;7] |> should equal [10;9;8]
        __ ((*) 2) [9;8;7] |> should equal [18;16;14]
        __ (fun x -> sprintf "%.2f wut?" x)  [9.3; 1.22] |> should equal ["9.30 wut?"; "1.22 wut?"]

    [<Test>]
    let ``09 Specified-function filtering, the hard way`` () =
        let filter (f : 'a -> bool) (xs : 'a list) : 'a list =
            __ // write a function which filters based on the specified criteria
        filter (fun x -> x > 19) [9; 5; 23; 66; 4] |> should equal [23; 66]
        filter (fun x -> String.length x = 4) ["moo"; "woof"; "yip"; "nyan"; "meow"]
        |> should equal ["woof"; "nyan"; "meow"]
        filter (fun (a,b) -> a*b >= 14) [9,3; 4,2; 4,5] |> should equal [9,3; 4,5]

    // Hint: https://msdn.microsoft.com/en-us/library/ee370294.aspx
    [<Test>]
    let ``10 Specified-function filtering, the easy way`` () =
        __ (fun x -> x > 19) [9; 5; 23; 66; 4] |> should equal [23; 66]
        __ (fun x -> String.length x = 4) ["moo"; "woof"; "yip"; "nyan"; "meow"]
        |> should equal ["woof"; "nyan"; "meow"]
        __ (fun (a,b) -> a*b >= 14) [9,3; 4,2; 4,5] |> should equal [9,3; 4,5]

    [<Test>]
    let ``11 Fixed-function filtering, the hard way`` () =
        let filter (xs : int list) : int list =
            __ // write a function to filter for odd elements only.
        filter [1; 2; 3; 4] |> should equal [1; 3]
        filter [10; 9; 8; 7] |> should equal [9; 7]
        filter [15; 2; 7] |> should equal [15; 7]
        filter [215] |> should equal [215]
        filter [216] |> should equal []
        filter [2;4;6;8;10] |> should equal []
        filter [1;3;5;7;9] |> should equal [1;3;5;7;9]
        filter [] |> should equal []

   // once again, this would be a heck of a lot more flexible if we
   // were able to filter using different criteria!
   //
   // ... you can make a function to do that, right? ^_^.

    [<Test>]
    let ``12 Specified-function filtering, the hard way`` () =
        let filter (f : 'a -> bool) (xs : 'a list) : 'a list =
            __ // write a function which filters based on the specified criteria
        filter (fun x -> x > 19) [9; 5; 23; 66; 4] |> should equal [23; 66]
        filter (fun x -> String.length x = 4) ["moo"; "woof"; "yip"; "nyan"; "meow"]
        |> should equal ["woof"; "nyan"; "meow"]
        filter (fun (a,b) -> a*b >= 14) [9,3; 4,2; 4,5] |> should equal [9,3; 4,5]

    // Hint: https://msdn.microsoft.com/en-us/library/ee370294.aspx
    [<Test>]
    let ``13 Specified-function filtering, the easy way`` () =
        __ (fun x -> x > 19) [9; 5; 23; 66; 4] |> should equal [23; 66]
        __ (fun x -> String.length x = 4) ["moo"; "woof"; "yip"; "nyan"; "meow"]
        |> should equal ["woof"; "nyan"; "meow"]
        __ (fun (a,b) -> a*b >= 14) [9,3; 4,2; 4,5] |> should equal [9,3; 4,5]

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

    [<Test>]
    let ``14 A fold which sums a list`` () =
        let fold initialState xs =
            __ // write a function to do what's described above
        fold 0 [1; 2; 3; 4] |> should equal 10
        fold 100 [2;4;6;8] |> should equal 120

    [<Test>]
    let ``15 A fold which multiplies a list`` () =
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
    let ``16 Folding, the hard way`` () =
        let fold (f : 'a -> 'b -> 'a) (initialState : 'a) (xs : 'b list) : 'a =
            __  // write a function to do a fold.
        fold (+) 0 [1;2;3;4] |> should equal 10
        fold (*) 2 [1;2;3;4] |> should equal 48
        fold (fun state item -> sprintf "%s %s" state item) "items:" ["dog"; "cat"; "bat"; "rat"]
        |> should equal "items: dog cat bat rat"
        fold (fun state item -> state + float item + 0.5) 0.8 [1;3;5;7] |> should equal 18.8

    // Hint: https://msdn.microsoft.com/en-us/library/ee353894.aspx
    [<Test>]
    let ``17 Folding, the easy way`` () =
        __ (+) 0 [1;2;3;4] |> should equal 10
        __ (*) 2 [1;2;3;4] |> should equal 48
        __ (fun state item -> sprintf "%s %s" state item) "items:" ["dog"; "cat"; "bat"; "rat"]
        |> should equal "items: dog cat bat rat"
        __ (fun state item -> state + float item + 0.5) 0.8 [1;3;5;7] |> should equal 18.8

    // List.exists
    [<Test>]
    let ``18 exists: finding whether any matching item exists`` () =
        let exists (f : 'a -> bool) (xs : 'a list) : bool =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee370309.aspx
        exists ((=) 4) [7;6;5;4;5] |> should equal true
        exists (fun x -> String.length x < 4) ["true"; "false"] |> should equal false
        exists (fun _ -> true) [] |> should equal false

    // List.partition
    [<Test>]
    let ``19 partition: splitting a list based on a criterion`` () =
        let partition (f : 'a -> bool) (xs : 'a list) : ('a list) * ('a list) =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee353782.aspx
        let a, b = partition (fun x -> x%2=0) [1;2;3;4;5;6;7;8;9;10]
        a |> should equal [2;4;6;8;10]
        b |> should equal [1;3;5;7;9]
        let c, d = partition (fun x -> String.length x < 4) ["woof"; "yip"; "moo"; "nyan"; "arf"]
        c |> should equal ["yip"; "moo"; "arf"]
        d |> should equal ["woof"; "nyan"]
        let e, f = partition (fun _ -> false) [9.2; 7.3; 11.8]
        e |> should equal []
        f |> should equal [9.2; 7.3; 11.8]

    // List.init
    [<Test>]
    let ``20 init: creating a list based on a size and a function`` () =
        let init (n : int) (f : int -> 'a) : 'a list =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee370497.aspx
        init 10 (fun x -> x*2) |> should equal [0;2;4;6;8;10;12;14;16;18]
        init 4 (sprintf "(%d)") |> should equal ["(0)";"(1)";"(2)";"(3)"]

    // List.tryFind
    [<Test>]
    let ``21 tryFind: find the first matching element, if any`` () =
        let tryFind (p : 'a -> bool) (xs : 'a list) : 'a option =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee353506.aspx
        tryFind (fun x -> x<=45) [100;85;25;55;6] |> should equal (Some 25)
        tryFind (fun x -> x>450) [100;85;25;55;6] |> should equal None

    // List.tryPick
    [<Test>]
    let ``22 tryPick: find the first matching element, if any, and transform it`` () =
        let tryPick (p : 'a -> 'b option) (xs : 'a list) : 'b option =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee353814.aspx
        let f x =
            match x<=45 with
            | true -> Some(x*2)
            | _ -> None
        tryPick f [100;85;25;55;6] |> should equal (Some 50)
        let g x =
            match String.length x with
            | 1 | 3 | 5 | 7 | 9 -> Some <| String.concat "-" [x;x;x]
            | 0 | 2 | 4 | 6 | 8 -> Some "Yo!"
            | _ -> None
        tryPick g ["billabong!!"; "in the house!"; "yolo!"; "wut!"] |> should equal (Some "yolo!-yolo!-yolo!")
        tryPick g ["qwerty"; "khazad-dum"] |> should equal (Some "Yo!")
        tryPick g ["And the winner is..."] |> should equal None

    (*
        There are also the functions List.pick and List.find, which do what
        the .tryPick and .tryFind variants do -- but when .tryPick and .tryFind
        would give back None, .pick and .find will throw an exception.  So
        you should only use them when you're absolutely sure that they
        can't fail!
    *)

    // List.choose
    [<Test>]
    let ``23 choose: find all matching elements, and transform them`` () =
        // Think about this: why does the signature of `choose` have to be like this?
        // - why can't it take an 'a->'b, instead of an 'a->'b option ?
        // - why does it return a 'b list, and not a 'b list option ?
        let choose (p : 'a -> 'b option) (xs : 'a list) : 'b list =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee353456.aspx
        let f x =
            match x<=45 with
            | true -> Some(x*2)
            | _ -> None
        choose f [100;85;25;55;6] |> should equal [50;12]
        let g x =
            match String.length x with
            | 1 | 3 | 5 | 7 | 9 -> Some <| String.concat "-" [x;x;x]
            | 0 | 2 | 4 | 6 | 8 -> Some "Yo!"
            | _ -> None
        choose g ["billabong!!"; "in the house!"; "yolo!"; "wut!"] |> should equal ["yolo!-yolo!-yolo!"; "Yo!"]
        choose g ["qwerty"; "khazad-dum"] |> should equal ["Yo!"]
        choose g ["And the winner is..."] |> should equal []

    [<Test>]
    let ``24 mapi: like map, but passes along an item index as well`` () =
        let mapi (f : int -> 'a -> 'b) (xs : 'a list) : 'b list =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee353425.aspx
        mapi (fun i x -> -i, x+1) [9;8;7;6] |> should equal [0,10; -1,9; -2,8; -3,7]
        let hailstone i t =
            match i%2 with
            | 0 -> t/2
            | _ -> t*3+1
        mapi hailstone [9;8;7;6] |> should equal [4;25;3;19]
        mapi (fun i x -> sprintf "%03d. %s" (i+1) x)  ["2B"; "R02B"; "R2D2?"]
        |> should equal ["001. 2B"; "002. R02B"; "003. R2D2?"]
