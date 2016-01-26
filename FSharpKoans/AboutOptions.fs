namespace FSharpKoans
open NUnit.Framework

(*
In F#, we tend to use options instead of exceptions for error-handling.

The Option type is a built-in discriminated union that is defined as follows:

type Option<'a> =
| Some of 'a
| None

There are many built-in functions which return an Option.
*)

module ``18: Exploring your options`` =
   (*
      The next function takes in a name and extracts the surname.
      But not all people have surnames!
         
      So, sometimes there is no surname.  But that's completely
      legitimate and understandable: it's not an error, so we
      shouldn't be throwing an exception about it.  We should
      reserve exceptions for actual errors.

      Instead, if someone has a surname, then we return a Some
      value.  Otherwise, we return a None value.  This allows us to
         - Avoid using exceptions for no reason
         - Express the domain that we're modelling more accurately
         - Avoid returning null or "special" values which could be
            misinterpreted later on and/or cause crashes.
   *)
    let getSurname (x:string) =
        match x.Trim().LastIndexOf ' ' with
        | -1 -> None
        | n -> Some x.[n+1..]
    // why not just return -1 instead of None?  Well, -1 is a valid value
    // in the problem domain.  A programmer must remember to check
    // for the -1 value, and if this check is forgotten, then the program
    // will have a bug.  None and Some are *disjoint* values which
    // cannot be mistaken for each other, and they therefore make the
    // success and failure cases explicit.

    [<Test>]
    let ``01 Basic Option example`` () =
        getSurname "Taylor Swift" |> should equal __
        getSurname "Eminem" |> should equal __

    // the System.Int32.TryParse, System.Double.TryParse, etc functions return
    // a tuple of bool * XYZ, where XYZ is the converted value.
    [<Test>]
    let ``02 Parsing a string safely`` () =
        let parse s =
            match System.Int32.TryParse s with
            | _ -> __ // <-- fill in the match cases
        parse "25" |> should equal 25
        parse "48" |> should equal 48
        parse "wut" |> should equal None

    [<Test>]
    let ``03 Remapping Option values`` () =
      let f n =
         match getSurname n with
         | _ -> __ // <-- write good match cases
      f "Anubis" |> should equal "[no surname]"
      f "Niccolo Machiavelli" |> should equal "Machiavelli"
      f "Mara Jade" |> should equal "Jade"
      f "Khazad-Dum" |> should equal "[no surname]"