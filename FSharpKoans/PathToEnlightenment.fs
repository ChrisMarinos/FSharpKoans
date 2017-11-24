open FSharpKoans
open Expecto
open Expecto.Impl

let tests =
  TestList(
    [ ``about asserts``.tests
      ``about let``.tests
      ``about functions``.tests
      ``about the order of evaluation``.tests
      ``about unit``.tests
      ``about tuples``.tests
      ``about strings``.tests
      ``about branching``.tests
      ``about lists``.tests
      ``about pipelining``.tests
      ``about arrays``.tests
      ``about looping``.tests
      ``more about functions``.tests
      ``about dot net collections``.tests
      ``about the stock example``.tests
      ``about record types``.tests
      ``about option types``.tests
      ``about discriminated unions``.tests
      ``about modules``.tests
      ``about opened modules``.tests
      ``about classes``.tests
      ``about filtering``.tests ], FocusState.Normal)

let config =
  { defaultConfig with
      ``parallel`` = false
      printer = TestPrinters.silent }

let result =
  Expecto.Impl.evalTests config tests
  |> Async.RunSynchronously
  |> List.rev

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
  parts.[0], parts.[1]

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
