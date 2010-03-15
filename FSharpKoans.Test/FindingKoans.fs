module KoansRunner.Test.FindingKoans
open FSharpKoans.Core
open FSharpKoans.Core.KoanContainer

open NUnit.Framework

open System.IO
    
type TestContainer() =
    [<Koan>]
    member this.Koan1 () =
        ()

    [<Koan>]
    member this.Koan2() =
        ()

let getKoanNames container =
    container
    |> findKoanMethods
    |> Seq.map (fun x -> x.Name)
    |> Seq.toList
        
[<Test>]
let ``getting koans from a container`` () = 
    let koanNames = getKoanNames <| new TestContainer()
    let expected =  [ "Koan1"; "Koan2" ]
    Assert.AreEqual(expected, koanNames)
    
type TestContainer2() =
    [<Koan>]
    member this.Z () =
        ()

    [<Koan>]
    member this.A () =
        ()
        
    [<Koan>]
    member this.a () =
        ()
        
    [<Koan>]
    member this._0 () =
        ()
        
    [<Koan>]
    member this.``0`` () =
        ()
        
[<Test>]
let ``Koans are returned in defined order regardless of name`` () =
    let koanNames = getKoanNames <| new TestContainer2()
    let expected =  [ "Z"; "A"; "a"; "_0"; "0" ]
    Assert.AreEqual(expected, koanNames)