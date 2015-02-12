[<AutoOpenAttribute>]
module FSharpKoans.Helpers

open System
open NUnit.Framework

let __ = "FILL ME IN"
let ___ = 1234
let [<Literal>] FILL__ME_IN = "FILL ME IN"
let [<Literal>] FILL_ME__IN = 1234
let inline ____<'a> : ^a list = []

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

let AssertThrows<'a when 'a :> exn> action = Assert.Throws<'a>(fun () -> action())