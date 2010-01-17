open FSharpKoans
open FSharpKoans.Core

let runner = KoanRunner([AboutAsserts()])
let result = runner.ExecuteKoans

match result with
| Success message -> printf "%s"message
| Failure (message, ex) -> 
    printf "%s" message
    printfn ""
    printfn ""
    printfn ""
    printfn ""
    printfn "%s" ex.Message
    printfn "%s" ex.StackTrace
    
printfn ""
printfn ""
printfn ""
printfn ""
printf "Press any key to continue..."
System.Console.ReadKey() |> ignore
