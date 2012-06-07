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
    printfn "%s" ex.Message
    printfn ""
    printfn "Please meditate on the following code:"
    printfn "%s" ex.StackTrace
    
printfn ""
printfn ""
printfn ""
printfn ""
printf "Press any key to continue..."
System.Console.ReadKey() |> ignore
