module KoansRunner.Test.GetttingTheWholeOutput
open FSharpKoans.Core
open NUnit.Framework

type ContainerOne() =
    [<Koan>]
    static member One() =
        "FTW!"
        
    [<Koan>]
    static member Two() =
        "FTW!"
        
    [<Koan>]
    static member Three() =
        "FTW!"
        
type ContainerTwo() =
    [<Koan>]
    static member Four() =
        "FTW!"
    
    [<Koan>]
    static member Five() =
        Assert.Fail("Expected")
        

    [<Koan>]
    static member Six() =
        "FTW!"
        
[<Test>]
let ``Output contains container name followed by koan results. Stops on failure`` () =
    let runner = KoanRunner([| typeof<ContainerOne>; typeof<ContainerTwo> |])
    let result = runner.ExecuteKoans()
    
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