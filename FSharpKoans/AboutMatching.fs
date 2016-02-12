namespace FSharpKoans
open NUnit.Framework

(*
What's a match expression?  It's a construct that uses the power of patterns
to conditionally execute code.  The first pattern (going from top to bottom) that
matches causes the associated code to be executed.  All non-matching patterns,
and any patterns after the first matching pattern, are ignored.  If no pattern
matches, then you get a MatchFailureException at runtime and you turn into a
Sad Panda.
*)

module ``03: Match expressions`` = 
    [<Test>]
    let ``01 Basic match expression`` () =
        match 8000 with
        | FILL_ME__IN -> "Insufficient power-level"
        ()

    [<Test>]
    let ``02 Match expressions are expressions, not statements`` () =
        let result =
            match 9001 with
            | FILL_ME__IN -> // <-- use a variable pattern here!
                match __ + 1000 with
                | 10001 -> "Hah! It's a palindromic number!"
                | x -> "Some number."
            | x -> "I should have matched the other expression."
        result |> should equal "Hah! It's a palindromic number!"

    [<Test>]
    let ``03 Shadowing in match expressions`` () =
        let x = 213
        let y = 19
        match x with
        | 100 -> ()
        | 19 -> ()
        | y ->
            y |> should equal __
            x |> should equal __
        y |> should equal __
        x |> should equal __

    [<Test>]
    let ``04 Match order in match expressions`` () =
        let x = 213
        let y = 19
        let z =
            match x with
            | 100 -> "Kite"
            | 19 -> "Smite"
            | 213 -> "Bite"
            | y -> "Light"
        let a = 
            match x with
            | 100 -> "Kite"
            | 19 -> "Smite"
            | y -> "Trite"
            | 213 -> "Light"
        x |> should equal __
        y |> should equal __
        z |> should equal __
        a |> should equal __
