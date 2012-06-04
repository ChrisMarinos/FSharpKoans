[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers
open System
open NUnit.Framework

let __ = "FILL ME IN"

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

let AssertWithMessage x message = Assert.IsTrue(x, message)

let AssertEquality (x:'a) (y:'b) = Assert.AreEqual(x,y)   

let AssertInequality (x:'a) (y:'b) = Assert.AreNotEqual(x,y)

let AssertThrows<'a when 'a :> exn> action = Assert.Throws<'a>(fun () -> action())

let Assert x = Assert.IsTrue(x)
