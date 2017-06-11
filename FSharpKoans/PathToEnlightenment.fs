open FSharpKoans
open Expecto
open Expecto.Impl

let testOrder =
  [ ``about asserts``.tests
    ``about let``.tests
    ``about functions``.tests ] |> List.rev
  // have to reverse to get the correct order

let tests = testList "Path to enlightenment" testOrder

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

let printSuccess ``module`` tests =
  printfn "%s:" ``module``
  tests |> List.iter (printfn "\t'%s' passed")
  printfn "\n"

let printFailure ``module`` test =
  printfn "%s:" ``module``
  printfn "\t'%s' failed" test

let printErrorMessage (ex: exn) =
  printfn ""
  printfn ""
  printfn "You have not yet reached enlightenment ..."
  printfn "%s" ex.Message
  printfn ""
  printfn "Please meditate on the following code:"
  printfn "%s" ex.StackTrace

let toGroupName (test: FlatTest) =
  let parts = test.name.Split([|"/"|], System.StringSplitOptions.None)
  parts.[1], parts.[2]

let successes =
  result
  |> List.takeWhile (fun (test, summary) -> isSuccess summary)
  |> List.map (fst >> toGroupName)
  |> List.groupBy fst
  |> List.map (fun (key,tests) -> key, tests |> List.map snd)

let firstFailure =
  result
  |> List.tryFind (fun (test, summary) ->  not (isSuccess summary))
  |> Option.map (fun (test, summary) -> toGroupName test, summary)

successes |> List.iter (fun (``module``, tests) -> printSuccess ``module`` tests)

match firstFailure with
| Some ((``module``, testName), summary) ->
  let error, exn =
    match summary.result with
    | Failed msg -> msg, None
    | Error exn -> exn.Message, Some exn
    | Passed -> failwith "should never happen"
    | Ignored s -> failwithf "should never happen: %s" s

  printFailure ``module`` testName
  exn |> Option.iter printErrorMessage

| None -> ()
