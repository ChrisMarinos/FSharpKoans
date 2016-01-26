namespace FSharpKoans
open NUnit.Framework

(*
    A function maps a single input to a single output.  Functions in the vast
    majority of functional languages (and an increasing number of non-functional
    languages!) are *first-class*.  This means that they can be used in every
    context that a variable can be used in.  You'll see them passed around as
    arguments and returned from functions, for example.

    When it comes right down to it, that's the essence of computation:
    taking inputs and mapping them to outputs in line with some logic.
    Unsurprisingly, functions are used everywhere in functional programming!
    In fact, in some other functional languages, things like if-statements are
    just functions rather than keywords.
*)

module ``08: Putting the Function into Functional Programming`` = 
    [<Test>]
    let ``A function takes one input and produces one output`` () =
        (fun a -> a + 100) __ |> should equal 2097

    [<Test>]
    let ``The input to a function is a pattern (Part 1)`` () =
        (fun 7 -> 9) __ |> should equal 9

    [<Test>]
    let ``The input to a function is a pattern (Part 2)`` () =
        (fun (t,u) -> u, t) __ |> should equal (9, 0)

    [<Test>]
    let ``The input to a function is a pattern (Part 3)`` () =
        // remember our record types from AboutRecords.fs ?
        (fun { Author=k } -> "Author is " + k) __ |> should equal "Author is Plato"

    [<Test>]
    let ``A function can be bound to a name (Part 1)`` () =
        let one_third = fun ka -> ka / 3
        __ 21 |> should equal 7

    [<Test>]
    let ``A function can be bound to a name (Part 2)`` () =
        let pinky bleh = bleh / 3 // The syntax has changed from Part 1, but the meaning is the same
        __ 21 |> should equal 7

    [<Test>]
    let ``A function can span multiple lines (Part 1)`` () =
        (fun zorro ->
            let k = "swash"
            let b = "buckle"
            zorro + " likes to " + k + b
        ) "Zorro the pirate" |> should equal __

    [<Test>]
    let ``A function can span multiple lines (Part 2)`` () =
        let jorus who =
            let p = 5
            who * p
        jorus 12 |> should equal __

    [<Test>]
    let ``A function can span multiple lines (Part 2, expanded syntax)`` () =
        // This is exactly the same as the previous test; the syntax is just more explicit.
        // Does the syntax make what's going on more clear?
        let jorus =
            fun who ->
                let p = 5 in
                    who * p
        in
            jorus 12 |> should equal __

    [<Test>]
    let ``A function can return a function (Part 1)`` () =
        let i = fun love -> fun hate -> love - hate
        let j = i 10
        let k = j 9
        k |> should equal __

    [<Test>]
    let ``A function can return a function (Part 2)`` () =
        let funky a b = a + b
        let j = funky 10
        let k = j 9
        k |> should equal __

    [<Test>]
    let ``You can write a function as a one-liner (Part 1)`` () =
        (fun ___ -> fun ___ -> __ - __) 10 9 |> should equal 1

    [<Test>]
    let ``You can write a function as a one-liner (Part 2)`` () =
        (fun _____ ____ -> __ - __) 10 9 |> should equal 1

    [<Test>]
    let ``'Multiple-argument' functions are one-input, one-output in disguise`` () =
      let i j k = j * k
      let j = __ 4
      let k = __ 12
      k |> should equal 48

    [<Test>]
    let ``A function is executed when it is called, NOT when it is defined or referenced (Part 1)`` () =
        let f a =
            failwith "An exception will be thrown as soon as this is executed."
            a + 2
        __ |> should be ofType<int -> int>

    [<Test;ExpectedException(typeof<System.Exception>)>]
    let ``A function is executed when it is called, NOT when it is defined or referenced (Part 2)`` () =
        let f a =
            failwith "An exception will be thrown as soon as this is executed."
            a + 2
        FILL__ME_IN |> should equal 10

    [<Test>]
    let ``Partially specifying arguments (Part 1)`` () =
        // this shows you how you can partially specify particular arguments to
        // reuse functionality.  This technique is exceptionally flexible and often
        // seen in functional code, so you should try to understand it fully.
        let f animal noise = animal + " says " + noise
        let kittehs = __ "cat"
        __ "nyan" |> should equal "cat says nyan"

    [<Test>]
    let ``Partially specifying arguments (Part 2)`` () =
        // as above, but what do you do when the arguments aren't in the order
        // that you want them to be in?
        let f animal noise = animal + " says " + noise
        let howl k = __ // <- multiple words on this line.  You MUST use `f`.
        howl "dire wolf" |> should equal "dire wolf says slash/crunch/snap"
        howl "direr wolf" |> should equal "direr wolf says slash/crunch/snap"

    [<Test>]
    let ``Partially specifying arguments (Part 3)`` () =
        // Extending a bit more, what do you do when you want to apply a function,
        // but modify the result before you give it back?
        let f animal noise = animal + " says " + noise
        let cows = __ // <-- multiple words on this line, or you may want to make this a multi-line thing.  You MUST use `f`.
        cows "moo" |> should equal "cow says moo, de gozaru"
        cows "MOOooOO" |> should equal "cow says MOOooOO, de gozaru"

    [<Test>]
    let ``Aliasing a function`` () =
        let f x = x + 2
        let y = f
        y 20 |> should equal ___

    [<Test>]
    let ``Getting closure`` () =
        let calculate initial final = // note the number of inputs.
            let middle = (final - initial) / 2
            fun t -> t-middle, t+middle
        // note the number of inputs provided below.  Do you see why I can do this?
        calculate 10 20 5 |> should equal __
        calculate 0 600 250 |> should equal __

    [<Test>]
    let ``Using a value defined in an inner scope`` () =
        // this is very similar to the previous test.
        let g t =
            let result =
                match t%2 with
                | 0 -> 10
                | 1 -> 65
            fun x -> result - x
        g 5 8 |> should equal __
        g 8 5 |> should equal __
        // PS. I hope this one brought you some closure.

    [<Test>]
    let ``Shadowing and functions`` () =
        let a = 25
        let f () = a + 10
        let a = 99
        a |> should equal __
        f () |> should equal __

    (*
        The `rec` keyword exposes the function identifier for use inside the function.
        And that's literally all that it does - it has no other purpose whatsoever.
    *)

    [<Test>]
    let ``'rec' exposes the name of the function for use inside the function`` () =
        let rec isValid dino =
            match dino with
            | [] -> "All valid."
            | "Thesaurus"::_ -> "A thesaurus isn't a dinosaur!"
            | _::rest -> isValid rest
        isValid ["Stegosaurus"; "Bambiraptor"] |> should equal __
        isValid ["Triceratops"; "Thesaurus"; "Tyrannosaurus Rex"] |> should equal __

    [<Test>]
    let ``Nesting functions`` () =
        let hailstone x =
            let triple x = x * 3
            let addOne x = x + 1
            addOne (triple x) // see AboutCombiningFunctions.fs to see a better way of doing this
        hailstone 5 |> should equal __

    [<Test>]
    let ``Functions have types`` () =
        let a x y = x + y
        let b a b c d e = sprintf "%d %f %s %c %b" a b c d e
        a |> should be ofType<FILL_ME_IN>
        b |> should be ofType<FILL_ME_IN>
        b 14 -8.7 |> should be ofType<FILL_ME_IN>


    [<Test>]
    let ``Passing a function as a parameter`` () =
    (*
        A function which accepts a function as input is called a "higher-order"
        function.

        If you think that passing a function as a parameter is a bit "weird",
        then I'd challenge you to answer this question: why SHOULDN'T you
        be able to pass a function as a parameter?
        
        If you can't come up with a reason, then perhaps the problem lies more
        with your current views about how programming "should" be, and not
        with the feature of higher-order functions :).
    *)
        let myIf cond =
            match cond 23 with
            | true -> "Black"
            | false -> "White"
        let check x =
            x % 2 <> 0 && x % 3 <> 0 && x % 5 <> 0 && x % 7 <> 0 && x % 11 <> 0
        myIf (fun x -> x%2 = 0) |> should equal __
        myIf (fun x -> x<35) |> should equal __
        myIf (fun x -> x+2 = 0) |> should equal __
        myIf (fun x -> x+2 = 21 || x-2 = 21) |> should equal __
        myIf check |> should equal __

    [<Test>]
    let ``Type annotations for function types`` () =
        let a (x:FILL_ME_IN) (y:FILL_ME_IN) = x + y
        let b (x:FILL_ME_IN) (y:FILL_ME_IN) = x + y
        a |> should be ofType<string -> string -> string>
        b |> should be ofType<float -> float -> float>
        a __ __ |> should equal "skipping"
        b __ __ |> should equal 1.02

    [<Test>]
    let ``We can use a type annotation for a function's output`` () =
        let k a b : FILL_ME_IN = a * b
        k __ __ |> should equal 15.0 

    (*
        Sometimes you want to force type-resolution to occur at a call-site.
        In a functional language that isn't strongly-typed, this isn't an issue.
        Because F# is strongly-typed, it can be an issue.
    *)

    // see: https://msdn.microsoft.com/en-us/library/dd548047.aspx
    [<Test>]
    let ``The 'inline' keyword forces type-resolution at callsite`` () =
        let (*REPLACE_THIS_COMMENT_WITH_KEYWORD*) a x y = x + y
        a 6 7 |> should equal 13 // expected: an int
        a __ __ |> should equal 1.2 // expected: a float
        a __ __ |> should equal "beebop" // expected: a string

   (*
       Did you know that operators like +, -, =, >, and so on, are actually
       functions in disguise?
   *)

    [<Test>]
    let ``Operators are functions in disguise`` () =
        (+) 5 8 |> should equal __
        (-) 3 5 |> should equal __
        (/) 12 4 |> should equal __
        (=) 93.1 93.12 |> should equal __
        (<) "hey" "jude" |> should equal __
        // ... and other operators: >, <=, >=, <>, %, ...
