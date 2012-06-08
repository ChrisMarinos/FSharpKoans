module KoansRunner.Test.FindingKoans

open FSharpKoans.Core
open FSharpKoans.Core.KoanContainer

open NUnit.Framework

open System.IO
    
type TestContainer() =
    [<Koan>]
    static member Koan1 () =
        ()

    [<Koan>]
    static member Koan2() =
        ()

let getKoanNames container =
    container
    |> findKoanMethods
    |> Seq.map (fun x -> x.Name)
    |> Seq.toList
        
[<Test>]
let ``getting koans from a container`` () = 
    let koanNames = getKoanNames typeof<TestContainer>
    let expected =  [ "Koan1"; "Koan2" ]
    Assert.AreEqual(expected, koanNames)
    
type TestContainer2() =
    [<Koan>]
    static member Z () =
        ()

    [<Koan>]
    static member A () =
        ()
        
    [<Koan>]
    static member a () =
        ()
        
    [<Koan>]
    static member _0 () =
        ()
        
    [<Koan>]
    static member ``0`` () =
        ()
        
[<Test>]
let ``Koans are returned in defined order regardless of name`` () =
    let koanNames = getKoanNames typeof<TestContainer2>
    let expected =  [ "Z"; "A"; "a"; "_0"; "0" ]
    Assert.AreEqual(expected, koanNames)
