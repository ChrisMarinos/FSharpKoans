module KoansRunner.Test.RunningKoans

open FSharpKoans.Core
open NUnit.Framework

type FailureContainer() =
    [<Koan>]
    static member FailureKoan() =
        Assert.Fail("expected failure")
        
type SuccessContainer() =
    [<Koan>]
    static member SuccessKoan() =
        "FTW!"

type SomeSuccesses() =
    [<Koan>]
    static member One() =
        "YAY"
    
    [<Koan>]
    static member Two() =
        "WOOT"
        
type MixedBag() =
    [<Koan>]
    static member One() =
        Assert.Fail("Game over")
    
    [<Koan>]
    static member Two() =
        "OH YEAH!"
        
[<Test>]
let ``A failing koan returns its exception`` () =
    let result = 
        typeof<FailureContainer>
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
        typeof<FailureContainer>
        |> KoanContainer.runKoans
        |> Seq.head
        
    Assert.AreEqual("FailureKoan failed.", result.Message)

[<Test>]
let ``A successful koans returns a success message`` () =
    let result =
        typeof<SuccessContainer>
        |> KoanContainer.runKoans
        |> Seq.head
        
    Assert.AreEqual("SuccessKoan passed", result.Message)
    
[<Test>]
let ``The outcome of all successful koans is returned`` () =
    let result =
        typeof<SomeSuccesses>
        |> KoanContainer.runKoans
        |> Seq.map (fun x -> x.Message)
        |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)
    
    let expected =
        "One passed" + System.Environment.NewLine +
        "Two passed"
        
    Assert.AreEqual(expected, result)
    
[<Test>]
//might want to change this behavior
let ``Failed Koans don't stop the enumeration`` () =
    let result =
        typeof<MixedBag>
        |> KoanContainer.runKoans
        |> Seq.map (fun x -> x.Message)
        |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)
        
        
    let expected =
        "One failed." + System.Environment.NewLine +
        "Two passed"
        
    Assert.AreEqual(expected, result)
