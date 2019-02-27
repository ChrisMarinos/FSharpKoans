namespace FSharpKoans
open NUnit.Framework

(*
    A tuple is an ordered group of data.  A tuple is formed using the comma operator,
    NOT brackets.  In F#, brackets are used for precedence and ordering, not to form tuples.

    The number of elements in a tuple is called its *arity*.  We can call a tuple with 2
    items a 2-tuple, a tuple with 5 elements is a 5-tuple, and so on.
*)

module ``06: Tuples`` = 
    [<Test>]
    let ``01 Creating tuples`` () = 
        let items = "apple", "dog"
        items |> should equal ("apple", __)

    [<Test>]
    let ``02 Elements of a tuple can be different types`` () =
        let stuff = "Rivet", false, 22.5
        stuff |> should equal ( __ )

    [<Test>]
    let ``03 Decompose a tuple using tuple pattern`` () =
        let aida = 2020, "cranberry", false, "wait, what?"
        let a, b, c, d = aida
        a |> should equal __
        b |> should equal __
        c |> should equal __
        d |> should equal __

    [<Test>]
    let ``04 Using a tuple in a match expression`` () =
        let result =
            match "Teresa", "pasta" with
            | name, "veggies" -> name + " likes vegetables"
            | name, "fish" -> name + " likes seafood"
            | name, "chicken" -> name + " crows about their food"
            | FILL__ME_IN, FILL__ME_IN -> __ + " loves to eat " + __
        result |> should equal "Teresa loves to eat pasta"   
   
    [<Test>]
    let ``05 The type of a tuple is the contained types separated by '*' symbols`` () =
        let a = 3, 5, "hi", 'x', 7.22
        a |> should be ofType<FILL_ME_IN>

    [<Test>]
    let ``06 Using the wildcard pattern to structurally decompose tuples`` () = 
        // A single _ is a wildcard pattern, NOT a space to fill things in.
        // Reminder: A wildcard pattern successfully matches ANYTHING.
        let name, _, _, weapon_name = "Shinji", 9103, true, "Unit 01"
        name |> should equal __
        weapon_name |> should equal __