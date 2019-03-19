open System
open FSharpKoans
open FSharpKoans.Core

let runner = KoanRunner()
let result = runner.ExecuteKoans()

match result with
| Success message -> printf "%s" message
| Failure (message, ex) -> 
    printf "%s" message
    printfn ""
    printfn ""
    printfn ""
    printfn ""
    printfn "You have not yet reached enlightenment ..."
    printfn "%s" 
        (match ex with
        | None -> "No error message could be found!"
        | Some(ex) -> ex.Message)
    printfn ""
    printfn "Please meditate on the following code:"
    printfn ""
    printfn "%s" 
        (match ex with
        | None -> "No stack trace could be found!"
        | Some(ex) -> ex.StackTrace)
    Environment.ExitCode <- 1
    
printfn ""
printfn ""
printfn ""
printfn ""
printf "Press any key to continue..."
System.Console.ReadKey() |> ignore