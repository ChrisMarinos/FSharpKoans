module FSharpKoans.Core.KoanContainer

open System
open System.IO
open System.Reflection
open Expecto
open Expecto.Impl
open FSharp.Reflection

let hasKoanAttribute (info:MethodInfo) =
    info.GetCustomAttributes(typeof<KoanAttribute>, true)
    |> Seq.isEmpty
    |> not

let findKoanMethods (container: Type) =
    container.GetMethods(BindingFlags.Public ||| BindingFlags.Static)
    |> Seq.filter hasKoanAttribute

exception TestFailedException of testName : string * message : string

let runKoans container : KoanResult seq =
    let inline makeTest (m : MethodInfo) = testCase m.Name <| fun _ -> m.Invoke(null, [||]) |> ignore

    let runTests tests =
        let config = { Expecto.Impl.ExpectoConfig.defaultConfig with
                        ``parallel`` = false
                        verbosity = Logging.LogLevel.Fatal
                        printer = TestPrinters.silent }
        Expecto.Impl.evalTests config tests

    let getKoanResult flatTest result =
        match result with
        | Passed -> Success <| sprintf "%s passed" flatTest.name
        | Ignored s | Failed s ->
            let outcome = sprintf "%s failed" flatTest.name
            Failure(outcome, TestFailedException(flatTest.name, s))
        | Error e ->
            let outcome = sprintf "%s blew up" flatTest.name
            Failure(outcome, e)

    container
    |> findKoanMethods
    |> Seq.map makeTest
    |> List.ofSeq
    |> List.rev
    |> testList container.Module.Name
    |> runTests
    |> Async.RunSynchronously
    |> Seq.map (fun (test, summary) -> getKoanResult test summary.result)
