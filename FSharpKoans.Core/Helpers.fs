[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers

open NUnit.Framework

let __ = "FILL ME IN"

let (=) x y =
    x = y.ToString()

let AssertWithMessage x message = Assert.IsTrue(x, message)

let AssertEquality (x:'a) (y:'b) = Assert.AreEqual(x,y)   

let Assert x = Assert.IsTrue(x)

