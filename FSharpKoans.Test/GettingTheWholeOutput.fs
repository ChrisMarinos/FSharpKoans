module KoansRunner.Test.GetttingTheWholeOutput
open FSharpKoans.Core
open Expecto

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
        failwith "Expected"


    [<Koan>]
    static member Six() =
        "FTW!"

[<Tests>]
let tests =
    testCase "Output contains container name followed by koan results. Stops on failure" <| fun () ->
        let runner = KoanRunner([| typeof<ContainerOne>; typeof<ContainerTwo> |])
        let result = runner.ExecuteKoans()

        let expected ="""
ContainerOne:
    One passed
    Two passed
    Three passed

ContainerTwo:
    Four passed
    Five failed."""

        Expect.equal result.Message expected "should have test output"