namespace FSharpKoans
open NUnit.Framework

(*
    In a functional language, functions are used for almost everything.

    In "mainstream" object-orientation (e.g. C# or Java), you would make
    objects and methods and inheritance and all of that jazz to structure your
    program's logic.  Every method must be in an object, and we create
    objects and call methods to make things happen.

    In functional programming, we do all of this with functions.  It is normal
    to make very small functions, and then combine them in various ways to
    achieve a goal.  There are operators in the language to make this easier,
    and these operators (of course!) are merely functions themselves, just like
    (+), (*), (-), and so on.
*)

module ``17: Combining functions`` =

    (*
        The pipe operator takes:
        - an input 'a
        - a function 'a -> 'b
        ...and applies the function to the input.  It is defined as:

            let (|>) x f = f x

        We often use the pipe operator to make code more readable.
    *)

    [<Test>]
    let ``01 |>, the 'pipe' operator`` () =
        let add5 a = a + 5
        let double a = a * 2
        3 |> add5 |> double |> should equal __  // <-- start with three, add 5, then double. Readable, isn't it?
        3 |> double |> add5 |> should equal __
        6 |> add5 |> add5 |> should equal __
        8 |> double |> double |> add5 |> should equal __

    [<Test>]
    let ``02 The output type of one pipe must be the input type to the next`` () =
        let toString (x : int) = string x
        let toInt (x : float) = int x
        toInt |> should be ofType<FILL_ME_IN>
        toString |> should be ofType<FILL_ME_IN>
        3.14 |> __ |> __ |> should equal "3"

    (*
        The backwards-pipe operator takes:
        - a function 'a -> 'b
        - an input 'a
        ...and applies the function to the input.  It is defined as:

            let (<|) f x = f x

        Due to the precedence of operators in the language, it's
        sometimes slightly more readable to use <| instead of brackets.
        But this is often a matter of taste and aesthetics, and <| is not
        used nearly as much as |> is.
    *)

    [<Test>]
    let ``03 <|, the lesser-used (but still useful) backwards pipe`` () =
        let a x =
            x = 4
        not (a 4) |> should equal false
        (__ __ a 4) |> should equal false // <-- put <| in one of the spaces to fill in

    (*
        The compose operator takes:
        - a function 'a -> 'b
        - a function 'b -> 'c
        ...and returns a function 'a -> 'c .  In other words, it "joins" the first and second
        functions to make a new function.  Composing functions is a very powerful
        technique: you can think of it as snapping together Lego blocks to create
        something new.  Functional programmers often make small functions that they
        will compose into larger ones later on.

        The compose operator can be defined as:

        let (>>) a b = fun input -> b (a input)
    *)

    [<Test>]
    let ``04 >>, the 'compose' operator`` () =
        let add5 a = a + 5
        let double a = a * 2
        let i = add5 >> double
        let j = double >> add5
        let k = double >> double >> double
        let l = j >> i
        i 3 |> should equal __
        j 3 |> should equal __
        k 3 |> should equal __
        l 3 |> should equal __

    [<Test>]
    let ``05 >>, the compose operator, creates new functions by "joining" old ones`` () =
        let joinTerms x = String.concat " + " x
        let stringify xs =
            match xs with
            | [] -> ["??"]
            | _ -> List.map string xs
        let appendEquals s = s + " = ??"
        let f = __ // <-- This is a one-line answer which uses >>
        f [3;5;7;3] |> should equal "3 + 5 + 7 + 3 = ??"
        f [2;4;6] |> should equal "2 + 4 + 6 = ??"
        f [] |> should equal "?? = ??"
