module KoansRunner.Test.FindingKoans

open FSharpKoans.Core
open FSharpKoans.Core.KoanContainer

open System.IO

open Expecto

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

[<Tests>]
let tests =
    testList "discovery" [

        testCase "Koans are returned in defined order regardless of name" <| fun () ->
            let koanNames = getKoanNames typeof<TestContainer2>
            let expected =  [ "Z"; "A"; "a"; "_0"; "0" ]
            Expect.sequenceEqual koanNames expected "should be in order"

        testCase "getting koans from a container" <| fun () ->
            let koanNames = getKoanNames typeof<TestContainer>
            let expected =  [ "Koan1"; "Koan2" ]
            Expect.sequenceEqual koanNames expected "should have same test list"
    ]
