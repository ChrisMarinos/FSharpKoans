open FSharpKoans
open FSharpKoans.Core

let (containers: obj list) = [ ``about asserts``(); 
                               ``about let``();
                               ``about functions``();
                               ``about the order of evaluation``();
                               ``about unit``();
                               ``about tuples``();
                               ``about branching``();
                               ``about lists``();
                               ``about pipelining``();
                               ``more about functions``();
                               ``about record types``();
                               ``about option types``();
                               ``about descriminated unions``();
                               ``about modules``();
                               ``about classes``();
                               ]
let runner = KoanRunner(containers)
let result = runner.ExecuteKoans

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
