namespace FSharpKoans

open Expecto

[<AutoOpen>]
module Asserts =

  let inline __<'a> = Unchecked.defaultof<'a>

  let inline AssertEquality actual expected =
    Expect.equal actual expected "should be equal"

  let inline AssertInequality actual expected =
    Expect.notEqual actual expected "should not be equal"

  let inline AssertThrows<'a> f = Expect.throws f (sprintf "should throw exception of type %s" typeof<'a>.Name)

  type FILL_ME_IN () = class end
  exception FILL_IN_THE_EXCEPTION