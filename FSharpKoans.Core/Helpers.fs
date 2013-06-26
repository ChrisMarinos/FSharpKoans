[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers

open System
open NUnit.Framework

let __ = "FILL ME IN"

type FILL_ME_IN =
    class end

type FILL_IN_THE_EXCEPTION() =
    inherit Exception()

type TupleWrapper(innerTuple) =
    member this.InnerTuple = innerTuple
    override this.ToString() = sprintf "%A" innerTuple
    override this.Equals that =
        match that with
        | :? TupleWrapper -> this.InnerTuple = (that :?> TupleWrapper).InnerTuple
        | _ -> false

let prepareAssertParam (param:obj) =
    if param <> null && FSharpType.IsTuple (param.GetType()) then
        new TupleWrapper(param) :> obj
    else 
        param

let AssertEquality (x:'a) (y:'b) = 
    Assert.AreEqual( prepareAssertParam x, 
                     prepareAssertParam y)   

let AssertInequality (x:'a) (y:'b) = 
    Assert.AreNotEqual( prepareAssertParam x,
                        prepareAssertParam y)

let AssertWithMessage x message = Assert.IsTrue(x, message)


let AssertThrows<'a when 'a :> exn> action = Assert.Throws<'a>(fun () -> action())

let Assert x = Assert.IsTrue(x)
