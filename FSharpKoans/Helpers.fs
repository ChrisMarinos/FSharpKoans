[<AutoOpenAttribute>]
module FSharpKoans.Helpers

open System
open NUnit.Framework
open FsUnit

// No, no.  This isn't the file you're looking for.
// You should be starting on the next file, AboutAsserts.fs.

// This file contains the Black Magic that makes everything else work.
// After you've finished the rest of the file, feel free to come
// back here and look.  Figure out what some of the keywords

let __ = "FILL ME IN"
let inline ___<'a> : ^a = Unchecked.defaultof<'a>
let inline ____<'a> : ^a list = []
let [<Literal>] FILL__ME_IN = "FILL ME IN"
let [<Literal>] FILL_ME__IN = 1234

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

let equal = equal
let be = be
let inline ofExactType<'a> = ofExactType<'a>
let ``me`` =
   System.Reflection.Assembly.GetExecutingAssembly().FullName
let inline should f x y =
   try
      should f x y
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
      failwithf "Line %d in \"%s\" (file: %s) doesn't work. What's wrong, I wonder?" lineno methodname file