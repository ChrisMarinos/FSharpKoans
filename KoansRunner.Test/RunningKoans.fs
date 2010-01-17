module KoansRunner.Test.RunningKoans
open FSharpKoans.Core
open NUnit.Framework

type FailureContainer() =
    [<Koan>]
    member this.FailureKoan() =
        Assert.Fail("expected failure")
        
type SuccessContainer() =
    [<Koan>]
    member this.SuccessKoan() =
        "FTW!"

type SomeSuccesses() =
    [<Koan>]
    member this.One() =
        "YAY"
    
    [<Koan>]
    member this.Two() =
        "WOOT"
        
type MixedBag() =
    [<Koan>]
    member this.One() =
        Assert.Fail("Game over")
    
    [<Koan>]
    member this.Two() =
        "OH YEAH!"
        
[<Test>]
let ``A failing koan returns its exception`` () =
    let result = 
        new FailureContainer()
        |> KoanContainer.runKoans
        |> Seq.head
        
    let ex = 
        match result with
        | Failure (_, ex) -> ex
        | _ -> null
    
    Assert.AreEqual("expected failure", ex.Message)
    
[<Test>]
let ``A failing koan returns a failure message`` () =
    let result = 
        new FailureContainer()
        |> KoanContainer.runKoans
        |> Seq.head
        
    Assert.AreEqual("FailureKoan has damaged your karma.", result.Message)

[<Test>]
let ``A successful koans returns a success message`` () =
    let result =
        new SuccessContainer()
        |> KoanContainer.runKoans
        |> Seq.head
        
    Assert.AreEqual("SuccessKoan has expanded your awareness.", result.Message)
    
[<Test>]
let ``The outcome of all successful koans is returned`` () =
    let result =
        new SomeSuccesses()
        |> KoanContainer.runKoans
        |> Seq.map (fun x -> x.Message)
        |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)
    
    let expected =
        "One has expanded your awareness." + System.Environment.NewLine +
        "Two has expanded your awareness."
        
    Assert.AreEqual(expected, result)
    
[<Test>]
//might want to change this behavior
let ``Failed Koans don't stop the enumeration`` () =
    let result =
        new MixedBag()
        |> KoanContainer.runKoans
        |> Seq.map (fun x -> x.Message)
        |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)
        
        
    let expected =
        "One has damaged your karma." + System.Environment.NewLine +
        "Two has expanded your awareness."
        
    Assert.AreEqual(expected, result)