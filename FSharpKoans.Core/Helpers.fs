[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers
open System.CodeDom
open NUnit.Framework

let __ = "FILL ME IN"

type FILL_ME_IN =
    class end

let AssertWithMessage x message = Assert.IsTrue(x, message)

let AssertEquality (x:'a) (y:'b) = Assert.AreEqual(x,y)   

let AssertInequality (x:'a) (y:'b) = Assert.AreNotEqual(x,y)

let Assert x = Assert.IsTrue(x)