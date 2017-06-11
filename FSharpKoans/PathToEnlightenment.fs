open FSharpKoans
open Expecto
open Expecto.Impl

let tests = testList "Path to enlightenment" []

let config =
    { defaultConfig with
        ``parallel`` = false
        printer = TestPrinters.silent }

let result =
    Expecto.Impl.evalTests config tests
    |> Async.RunSynchronously

let isSuccess (summary : TestSummary) =
    match summary.result with
    | Passed -> true
    | _ -> false

let printSuccess (test: FlatTest) = printfn "%s passed" test.name
let printFailure (test: FlatTest) = printfn "%s failed" test.name

let successes = result |> List.takeWhile (fun (test, summary) -> isSuccess summary)
let firstFailure = result |> List.tryFind (fun (test, summary) ->  not (isSuccess summary))

successes |> List.iter (fst >> printSuccess)

match firstFailure with
| Some (test, summary) ->
    let error, exn =
        match summary.result with
        | Failed msg -> msg, None
        | Error exn -> exn.Message, Some exn
        | Passed -> failwith "should never happen"
        | Ignored s -> failwithf "should never happen: %s" s
    printfn "%s" error
    exn |> Option.iter (fun ex ->
        printfn ""
        printfn ""
        printfn ""
        printfn ""
        printfn "You have not yet reached enlightenment ..."
        printfn "%s" ex.Message
        printfn ""
        printfn "Please meditate on the following code:"
        printfn "%s" ex.StackTrace
    )
| None -> ()

printfn ""
printfn ""
printfn ""
printfn ""
printf "Press any key to continue..."
System.Console.ReadKey() |> ignore
