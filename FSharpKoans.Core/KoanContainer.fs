namespace FSharpKoans.Core

open System.IO
open System.Reflection

module KoanContainer =
    let findKoanMethods container =
    
        let hasKoanAttribute (info:MethodInfo) =
            info.GetCustomAttributes(typeof<KoanAttribute>, true)
            |> Seq.isEmpty
            |> not
            
        container.GetType().GetMethods()
        |> Seq.filter hasKoanAttribute
        
    let runKoans container =
        let getKoanResult (m:MethodInfo) =
            try
                m.Invoke(container, [||]) |> ignore
                Success <| sprintf "%s has expanded your awareness." m.Name
            with
            | ex -> 
                let outcome = sprintf "%s has damaged your karma." m.Name
                Failure(outcome, ex.InnerException)
            
        container
        |> findKoanMethods
        |> Seq.map getKoanResult