namespace FSharpKoans
open NUnit.Framework

(*
Consider a simple program:

    let answer = 4 + 5
    answer + 2

The value on the right (i.e. 9) is BOUND to the pattern on the left.  The pattern
on the left happens to be an identifier.  On any subsequent line, we can use the
identifier `answer` and the value 9 will be substituted for it.  The result of the
program is therefore 11.  In reality, what we are saying is

    let answer = 4 + 5 in
        answer + 2

(that's valid F#, by the way).  Can you see that, explicitly, we are binding the value 9
to the identifier `answer`, to be used in the expression `answer + 2`?

Now, let's make this a bit more general:

    let first = 4
    let second = 5
    let answer = first + second
    answer + 2

What are we actually saying here?  We are saying:

    let first = 4 in
        let second = 5 in
            let answer = first + second in
                answer + 2

Contemplate how this "chain" of substitution works until you think that
you see what's going on.

Now, a newbie functional programmer might be tempted to write something
like this in a function:

    let first = 4
    let second = 5
    let answer = first + second

...but that doesn't compile!  What's going on?!  Well, expand it a bit, and you'll
see that it actually means:

    let first = 4 in
        let second = 5 in
            let answer = first + second in

There's no expression that actually ends the chain.  And because there's no
expression that ends the chain, there's nothing to substitute all of these
values into.  Without an expression, there's no point in all of these bindings,
and the F# compiler will refuse to accept nonsensical code.
*)

module ``02: About Binding`` = 

    // this should look like code that you're familiar with, perhaps from C#.
    [<Test>]
    let ``01 Basic 'let' binding`` () = 
        let x = 50
        x |> should equal __

    [<Test>]
    let ``02 Equivalent basic 'let' binding`` () = // this is exactly equivalent to the previous binding.
        let x = 50 in // note that the syntax is more explicit about what's really going on!
            x |> should equal __

    [<Test>]
    let ``03 Nest your 'let' statements as deeply as you'd like`` () =
        let a =
            let b =
                let c =
                    let d = 63
                    d
                c + 1
            b + 7
        a |> should equal ___

(*
    Identifiers are *referentially transparent*: the value bound to an identifier never changes.
    However, identifiers may be *shadowed*.  The best way to explain this is with an example.

        let quex = 10
        let quex = 19
        let quex = 5 + quex
        let quex = "Something"

    In this example, the identifier `quex` is bound four times.

    The first `quex` identifier is bound to the value 10.  On the next line, the `quex`
    identifier is bound to the value 19.  This does NOT CHANGE the value of the first
    `quex` identifier.  The first `quex` identifier continues to exist, and continues to
    have the value `19`.  However, subsequent lines that use the value `quex` will use
    the most-recently-bound `quex`: we say that the first binding of `quex` has been
    *shadowed* by the second binding.  So the third binding of `quex` is has the value
    24.  Lastly, the identifier `quex` is bound to "Something".

    "Well," you may be thinking, "there are fancy words here, but it's basically the
    same effect as changing a value, so I'll just think about it as changing a value."
    Later on, when we do match expressions and functions and other basic things
    like that, the distinction becomes very important.  If you get into the wrong way
    of thinking about it now, you'll really mess yourself up later on.    
*)

    [<Test>]
    let ``04 Shadowing`` () =
        let a = 21
        let b =
            let a = 8
            3 + a
        let c = a + 4
        let a = a + a
        a |> should equal __
        b |> should equal __
        c |> should equal __

    (*
        The next test demonstrates *type inference*.
        
        Not all functional languages are typed.  The first (and, arguably, the most powerful)
        functional language was Lisp, and Lisp isn't strongly typed.  Typing is something that tends
        to work very well with functional programming, but isn't something that is essential to
        functional programming.  In the case of F#, typing often stops you from making "silly" errors.

        F# uses type inference extensively.  Type inference means that it tries to work out
        (or "infer") what type a particular name is by looking at code around it.  A readable, if
        simplified, explanation of how this works can be found at:
        http://fsharpforfunandprofit.com/posts/type-inference/
    *)
   
    [<Test>]
    let ``05 The type of symbols in variable patterns are inferred`` () = 
        let x = 50
        let y = "a string"
        let z = -4.23
        let a = false
        let b = 't'
        x |> should be ofType<int>
        y |> should be ofType<FILL_ME_IN>
        z |> should be ofType<FILL_ME_IN>
        a |> should be ofType<FILL_ME_IN>
        b |> should be ofType<FILL_ME_IN>
   
   (*
    What's a pattern?  A pattern is something that expresses the SHAPE of data.  Data may
    match the shape, or it may not match the shape.  IF AND ONLY IF it matches the shape, then
    any identifiers in the pattern are bound.

    When you understand this, you will understand almost everything there is to know about
    patterns :).
   *)

    [<Test>]
    let ``06 Constant patterns succeed if both sides match`` () =
        let 900 = __
        let "Can't win all the time" = __
        () // eh? what's this funny thing? It's called "unit", and you'll learn more about it in AboutUnit.fs later on.

    [<Test>]
    let ``07 Constant patterns fail if the sides don't match exactly`` () =
        (fun () ->
            let "FILL ME IN" = FILL__ME_IN
            ()
        ) |> should throw typeof<MatchFailureException>