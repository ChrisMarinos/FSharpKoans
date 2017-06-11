[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers

open System
open Expecto

let inline __<'T> : 'T = Expect.isTrue false "Seek wisdom by filling in the __"; Unchecked.defaultof<'T>

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

let inline AssertWithMessage x message = Expect.isTrue x message

let inline AssertEquality (x:'T) (y:'T) = Expect.equal x y "should be equal"

let inline AssertInequality (x:'T) (y:'T) = Expect.notEqual x y "should not be equal"

let inline AssertThrows<'a when 'a :> exn> action =
    let exnName = (typeof<'a>).Name
    Expect.throwsT<'a> action (sprintf "should throw exception of type %s" exnName)

let inline Assert x = Expect.isTrue x "should be true"
