(*
 _____  _____  _____ ______  _ 
/  ___||_   _||  _  || ___ \| |
\ `--.   | |  | | | || |_/ /| |
 `--. \  | |  | | | ||  __/ | |
/\__/ /  | |  \ \_/ /| |    |_|
\____/   \_/   \___/ \_|    (_)
                               
No, no.  This isn't the file you're looking for.
You should be starting on the next file, AboutTesting.fs.

This file contains the Black Magic that makes everything else work.
After you've finished the rest of the file, feel free to come
back here and look.  Figure out what some of the keywords do :).
*)

















[<AutoOpenAttribute>]
module FSharpKoans.Helpers

open System
open NUnit.Framework
open FsUnit

// note to self: this is a helpful regex: let ``.*``[^(]+=

(*
== Things That I Now Know About NUnit ==

NUnit's test adapter is horrible about name-mangling.
If a test ends with a bracket ), or a bracket ) and then whitespace,
it refuses to find the location of the test.  Why?  'cos NUnit.
So that's why we have method names ending with ")." instead.

And ordering tests is apparently far beyond its capabilities... :-/
*)

let inline __<'a> : ^a = Unchecked.defaultof<'a>
let inline ___<'a> : ^a list = []
let [<Literal>] FILL__ME_IN = "FILL ME IN"
let [<Literal>] FILL_ME__IN = 1234

type FILL_ME_IN =
    static member (+) (a : FILL_ME_IN, b : FILL_ME_IN) = failwith "+ failed"
    static member (*) (a : FILL_ME_IN, b : FILL_ME_IN) = failwith "* failed"

module String =
    let FILL_ME_IN _ = ()
    let FILL__ME_IN _ _ = ()
type String with
    member __.FILL_ME_IN = ()

let equal = equal
let inline be<'a> = id<'a>
let inline ofType<'a> =
    {
        new Constraints.Constraint () with
            override __.Matches (x:obj) =
                match x with
                | :? 'a -> true
                | _ -> instanceOfType<'a>.Matches x
            override __.WriteDescriptionTo w =
                instanceOfType<'a>.WriteDescriptionTo w
    }
let ``me`` =
    System.Reflection.Assembly.GetExecutingAssembly().FullName
let inline should (f : 'a -> #Constraints.Constraint) x (y : obj) =
    let c = f x
    let y =
        match y with
        | :? (unit -> unit) -> box (TestDelegate(y :?> unit -> unit))
        | _ -> y
    try
        Assert.That(y, c)
    with
    | ex ->
        // ok, let's pull out the line number.  We'll need to
        // shove our way up the stack (SLOOOW) to do this reliably!
        let trace = System.Diagnostics.StackTrace(ex, true);
        let sf =
            trace.GetFrames ()
            |> Array.filter (fun sf ->
                sf.GetMethod().DeclaringType.Assembly.FullName = ``me``
            ) |> Seq.last
        let lineno = sf.GetFileLineNumber()
        let methodname = sf.GetMethod().Name
        let file =
            sf.GetFileName()
            |> System.IO.Path.GetFileName
        failwithf "There's a problem somewhere around line %d in \"%s\" (file: %s). What's wrong, I wonder?" lineno methodname file