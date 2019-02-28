namespace FSharpKoans
open NUnit.Framework

(*
    A function maps a single input to a single output.  Functions in functional
    languages (and an increasing number of non-functional languages!) are
    *first-class*.  This means that they can be used in every context that
    a variable can be used in.  You'll see them passed around as arguments
    and returned from functions, for example.

    When it comes right down to it, that's the essence of computation:
    taking inputs and mapping them to outputs in line with some logic.
    Unsurprisingly, functions are used everywhere in functional programming!
    In fact, in some other functional languages, things like if-statements are
    just functions rather than keywords.
*)

module ``03: Putting the Function into Functional Programming`` = 
    [<Test>]
    let ``01 A function takes one input and produces one output`` () =
        (fun a -> a + 100) __ |> should equal 2097

    [<Test>]
    let ``02 The input to a function is a pattern (Part 1).`` () =
        (fun 7 -> 9) __ |> should equal 9

    [<Test>]
    let ``03 The input to a function is a pattern (Part 2).`` () =
        (fun _ -> 75) __ |> should equal 75

    [<Test>]
    let ``04 The input to a function is a pattern (Part 3).`` () =
        (fun (2 | 3 | 5) -> "Prime") __ |> should equal "Prime"

    [<Test>]
    let ``05 A function can be bound to a name (Part 1).`` () =
        let one_third = fun ka -> ka / 3
        __ 21 |> should equal 7

    [<Test>]
    let ``06 A function can be bound to a name (Part 2).`` () =
        let pinky bleh = bleh / 3 // The syntax has changed from Part 1, but the meaning is the same
        __ 21 |> should equal 7

    [<Test>]
    let ``07 A function can span multiple lines (Part 1).`` () =
        (fun zorro ->
            let k = "swash" // notice the indentation.
            let b = "buckle" // F# is whitespace-sensitive, so it is important!
            zorro + " likes to " + k + b
        ) "Zorro the pirate" |> should equal __

    [<Test>]
    let ``08 A function can span multiple lines (Part 2).`` () =
        let jorus who =
            let p = 5
            who * p
        jorus 12 |> should equal __

    [<Test>]
    let ``09 A function can span multiple lines (Part 2, expanded syntax).`` () =
        // This is largely the same as the previous test; the syntax is just more explicit.
        // Does the syntax make what's going on more clear?
        let jorus =
            fun who ->
                let p = 3 in
                    who * p
        in
            jorus 12 |> should equal __

    // The next few are very similar.  Resist the temptation to
    // just fill out values without having any idea about what's
    // going on!  Learn the different forms of the syntax.  You
    // will have to understand and apply these in your own code.

    [<Test>]
    let ``10 A function can return a function (Part 1).`` () =
        let i = fun love -> fun hate -> love - hate
        // read the above as: fun love -> (fun hate -> (love - hate))
        let j = i 10
        let k = j 9
        k |> should equal __

    [<Test>]
    let ``11 A function can return a function (Part 2).`` () =
        let funky a b = a + b
        let j = funky 10
        let k = j 9
        k |> should equal __

    [<Test>]
    let ``12 You can write a function as a one-liner (Part 1).`` () =
        (fun ___ -> fun ___ -> __ * __) __ __ |> should equal 27

    [<Test>]
    let ``13 You can write a function as a one-liner (Part 2).`` () =
        (fun _____ ____ -> __ + __) __ __ |> should equal 17

    [<Test>]
    let ``14 'Multiple-argument' functions are one-input, one-output in disguise`` () =
      let i j k = j * k
      let j = __ 4
      let k = __ 12
      k |> should equal 48

    [<Test>]
    let ``15 A function is executed when it is called, NOT when it is defined or referenced (Part 1).`` () =
        let f a =
            failwith "An exception will be thrown as soon as this is executed."
            a + 2
        ___ |> should be ofType<int -> int>

    [<Test>]
    let ``16 A function is executed when it is called, NOT when it is defined or referenced (Part 2).`` () =
        (fun () ->
            let f a =
                failwith "An exception will be thrown as soon as this is executed."
                a + 2
            FILL_ME__IN |> should equal 1234
        ) |> should throw typeof<System.Exception>

    [<Test>]
    let ``17 Two names can be bound to the same value`` () =
        let f x = x + 2
        let y = f
        y 20 |> should equal ___


    [<Test>]
    let ``18 Shadowing and functions`` () =
        let a = 25
        let f () = a + 10
        let a = 99
        a |> should equal __
        f () |> should equal __

    [<Test>]
    let ``19 Nesting functions`` () =
        let hailstone x =
            let triple x = x * 3
            let addOne x = x + 1
            addOne (triple x)
        hailstone 5 |> should equal __

    [<Test>]
    let ``20 Functions have types`` () =
        let a x y = x + "cabbage" + y
        let b r = 50.0 / r
        a |> should be ofType<FILL_ME_IN>
        b |> should be ofType<FILL_ME_IN>


    [<Test>]
    let ``21 Passing a function as a parameter`` () =
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
        let somefunc x y = x + y x
        let square v = v * v
        somefunc 3 square |> should equal __
        somefunc 3 ((*) 7) |> should equal __
        somefunc 10 ((+) 8) |> should equal __
        somefunc 5 (fun z -> z + 22) |> should equal __

   (*
       Did you know that operators like +, -, =, >, and so on, are actually
       functions in disguise?
   *)

    [<Test>]
    let ``22 Operators are functions in disguise`` () =
        (+) 5 8 |> should equal __
        (-) 3 5 |> should equal __
        (/) 12 4 |> should equal __
        (=) 93.1 93.12 |> should equal __
        (<) "hey" "jude" |> should equal __
        // ... and other operators: >, <=, >=, <>, %, ...

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

    [<Test>]
    let ``23 |>, the 'pipe' operator`` () =
        let add5 a = a + 5
        let double a = a * 2
        3 |> add5 |> double |> should equal __  // <-- start with three, add 5, then double. Readable, isn't it?
        3 |> double |> add5 |> should equal __
        6 |> add5 |> add5 |> should equal __
        8 |> double |> double |> add5 |> should equal __

    (*
        The pipe operator takes:
        - an input 'a
        - a function 'a -> 'b
        ...and applies the function to the input.  It is defined as:

            let (|>) x f = f x

        We often use the pipe operator to make code more readable.
    *)

    [<Test>]
    let ``24 The output type of one pipe must be the input type to the next`` () =
        let a x = x * 2.5
        let b x = x = 7.5
        a |> should be ofType<FILL_ME_IN>
        b |> should be ofType<FILL_ME_IN>
        __ |> __ |> __ |> should equal true

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
    let ``25 <|, the lesser-used (but still useful) backwards pipe`` () =
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
    let ``26 >>, the 'compose' operator`` () =
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