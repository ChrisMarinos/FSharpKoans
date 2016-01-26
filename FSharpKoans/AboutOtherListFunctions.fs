namespace FSharpKoans
open NUnit.Framework

(*
Some more 'commonly-used' F# List functions.  After going through length,
rev, map, filter, and fold, you should be good enough to develop your
own versions of these without the need for 'intro' versions.

You can find the full list of functions at https://msdn.microsoft.com/en-us/library/ee353738.aspx

After completing this file, you should understand that the List functions
provided to you by F# are convenient things that, with a bit of thought,
you could implement for yourself anyway.  The library functions may
be more optimised than versions that you come up with, but there's
no *semantic* difference between them.
*)

module ``19: Other list functions`` =
    // List.exists
    [<Test>]
    let ``01 exists: finding whether any matching item exists`` () =
        let exists (f : 'a -> bool) (xs : 'a list) : bool =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee370309.aspx
        exists ((=) 4) [7;6;5;4;5] |> should equal true
        exists (fun x -> String.length x < 4) ["true"; "false"] |> should equal false
        exists (fun _ -> true) [] |> should equal false

    // List.partition
    [<Test>]
    let ``02 partition: splitting a list based on a criterion`` () =
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
    let ``03 init: creating a list based on a size and a function`` () =
        let init (n : int) (f : int -> 'a) : 'a list =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee370497.aspx
        init 10 (fun x -> x*2) |> should equal [0;2;4;6;8;10;12;14;16;18]
        init 4 (sprintf "(%d)") |> should equal ["(0)";"(1)";"(2)";"(3)"]

    // List.tryFind
    [<Test>]
    let ``04 tryFind: find the first matching element, if any`` () =
        let tryFind (p : 'a -> bool) (xs : 'a list) : 'a option =
            __ // Does this: https://msdn.microsoft.com/en-us/library/ee353506.aspx
        tryFind (fun x -> x<=45) [100;85;25;55;6] |> should equal (Some 25)
        tryFind (fun x -> x>450) [100;85;25;55;6] |> should equal None

    // List.tryPick
    [<Test>]
    let ``05 tryPick: find the first matching element, if any, and transform it`` () =
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
    let ``06 choose: find all matching elements, and transform them`` () =
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
    let ``07 mapi: like map, but passes along an item index as well`` () =
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

(*
    Some other useful ones:

    - List.collect
    - List.min
    - List.sort
    - List.max
    - List.minBy
    - List.maxBy
    - List.tryFindIndex

    Documentation is available online from MSDN, which is where most of the links in this file
   take you.  Read up on some of them: they can be powerful tools in your FP toolbox!
*)