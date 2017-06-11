module KoansRunner.Test.RunningKoans

open FSharpKoans.Core
open Expecto

type FailureContainer() =
    [<Koan>]
    static member FailureKoan() =
       failwith "expected failure"

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
        failwith "Game over"

    [<Koan>]
    static member Two() =
        "OH YEAH!"

[<Tests>]
let tests =
  testList "failure" [
    testCase "A failing koan returns its exception" <| fun () ->
        let result =
            typeof<FailureContainer>
            |> KoanContainer.runKoans
            |> Seq.head

        let ex =
            match result with
            | Failure (_, ex) -> ex
            | _ -> null

        Expect.equal ex.Message "expected failure" "should fail"

    testCase "A failing koan returns a failure message" <| fun () ->
        let result =
            typeof<FailureContainer>
            |> KoanContainer.runKoans
            |> Seq.head

        Expect.equal result.Message "FailureKoan failed." "should fail"

    testCase "A successful koans returns a success message" <| fun () ->
        let result =
            typeof<SuccessContainer>
            |> KoanContainer.runKoans
            |> Seq.head

        Expect.equal result.Message "SuccessKoan passed" "should succeed"

    testCase "The outcome of all successful koans is returned" <| fun () ->
        let result =
            typeof<SomeSuccesses>
            |> KoanContainer.runKoans
            |> Seq.map (fun x -> x.Message)
            |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)

        let expected =
            "One passed" + System.Environment.NewLine +
            "Two passed"

        Expect.equal result expected "returns success"
    testCase "Failed Koans don't stop the enumeration" <| fun () ->
        let result =
            typeof<MixedBag>
            |> KoanContainer.runKoans
            |> Seq.map (fun x -> x.Message)
            |> Seq.reduce (fun x y -> x + System.Environment.NewLine + y)


        let expected =
            "One failed." + System.Environment.NewLine +
            "Two passed"

        Expect.equal result expected "failures don't stop"
]