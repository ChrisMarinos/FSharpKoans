[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers

open System
open NUnit.Framework

let inline __<'T> : 'T = failwith "Seek wisdom by filling in the __"

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

let AssertWithMessage (x : bool) message = Assert.IsTrue(x, message)

let inline AssertEquality (x:'T) (y:'T) =
    match box y with
    | :? System.Type as t when t = typeof<FILL_ME_IN> -> failwith "Seek wisdom by correcting the type FILL_ME_IN"
    | :? System.Type as t when t = typeof<FILL_IN_THE_EXCEPTION> -> failwith "Seek wisdom by correcting the type FILL_IN_THE_EXCEPTION"
    | _ -> Assert.AreEqual(x,y)

let AssertInequality (x:'T) (y:'T) = Assert.AreNotEqual(x,y)

let AssertThrows<'a when 'a :> exn> action = Assert.Throws<'a>(fun () -> action())

let Assert (x : bool) = Assert.IsTrue(x)
