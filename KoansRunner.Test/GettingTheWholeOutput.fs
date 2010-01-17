module KoansRunner.Test.GetttingTheWholeOutput
open NUnit.Framework
open FSharpKoans.Core

type ContainerOne() =
    [<Koan>]
    member this.One() =
        "FTW!"
        
    [<Koan>]
    member this.Two() =
        "FTW!"
        
    [<Koan>]
    member this.Three() =
        "FTW!"
        
type ContainerTwo() =
    [<Koan>]
    member this.Four() =
        "FTW!"
    
    [<Koan>]
    member this.Five() =
        Assert.Fail("Expected")
        

    [<Koan>]
    member this.Six() =
        "FTW!"
        
[<Test>]
let ``Output contains container name followed by koan results. Stops on failure`` () =
    let runner = KoanRunner([ContainerOne(); ContainerTwo()])
    let result = runner.ExecuteKoans
    
    let expected = 
        "

When contemplating ContainerOne:
    One has expanded your awareness.
    Two has expanded your awareness.
    Three has expanded your awareness.

When contemplating ContainerTwo:
    Four has expanded your awareness.
    Five has damaged your karma."
    
    
    Assert.AreEqual(expected, result.Message)