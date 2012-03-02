module KoansRunner.Test.KoanResults
open FSharpKoans.Core
open NUnit.Framework

[<Test>]
let ``map lets you project a message when success``() =
    let result = Success "sample message"

    let mappedResult = 
        result
        |> KoanResult.map (fun x -> x + " expanded")

    Assert.AreEqual(Success "sample message expanded", mappedResult)

[<Test>]
let ``map lets you project a message when failure``() =
    let ex = new System.Exception("abcd")
    let result = Failure ("sample message", ex)

    let mappedResult = 
        result
        |> KoanResult.map (fun x -> x + " expanded")

    Assert.AreEqual(Failure ("sample message expanded", ex), mappedResult)