namespace FSharpKoans
open NUnit.Framework

(* Some pattern-matching tricks that you might find useful.

Use https://msdn.microsoft.com/en-us/library/dd547125.aspx
as a reference to help you through these.
*)

module ``09: Advanced pattern-matching`` =

    (*
        "The OR pattern is used when input data can match multiple patterns,
        and you want to execute the same code as a result. The types of both
        sides of the OR pattern must be compatible."
    *)

    [<Test>]
    let ``01 Using an OR-pattern`` () =
        let f input =
            match input with
            | "wut" | "lol" -> "yolo"
            | "sunrise"
            | "sunset" -> "transition"
            | FILL__ME_IN
            | FILL__ME_IN
            | FILL__ME_IN -> "failure"
            | _ -> "lolwut"
        f "lol" |> should equal "yolo"
        f "wut" |> should equal "yolo"
        f "Johnny Walker" |> should equal "failure"
        f "Bell's" |> should equal "failure"
        f "vodka" |> should equal "failure"

    [<Test>]
    let ``02 Identifiers bound on all branches of an OR-pattern must be the same`` () =
        let f input =
            match input with
            | 0,0 -> "Both 0"
            | ___ | ___ -> sprintf "One 0, one %d" __
            | _ -> "No 0"
        f (3,0) |> should equal "One 0, one 3"
        f (0, 4) |> should equal "One 0, one 4"
        f (9, 5) |> should equal "No 0"
        f (0, 0) |> should equal "Both 0"

    (*
        "The as-pattern is a pattern that has an as clause appended to it.
        The as clause binds the matched value to a name that can be used
        in the execution expression of a match expression, or, in the case
        where this pattern is used in a let binding, the name is added as
        a binding to the local scope."
    *)

    [<Test>]
    let ``03 Binding composed and decomposed structures using 'as'`` () =
      let f ((___, ____) as _____) =
         sprintf "%d and %d in a tuple look like %A" __ __ __
      f (0,43) |> should equal "0 and 43 in a tuple look like (0, 43)"
      f (5, 11) |> should equal "5 and 11 in a tuple look like (5, 11)"
