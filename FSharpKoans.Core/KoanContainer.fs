module FSharpKoans.Core.KoanContainer

open System
open System.IO
open System.Reflection

let hasKoanAttribute (info:MethodInfo) =
    info.GetCustomAttributes(typeof<KoanAttribute>, true)
    |> Seq.isEmpty
    |> not

let findKoanMethods (container: Type) =
    container.GetMethods(BindingFlags.Public ||| BindingFlags.Static)
    |> Seq.filter hasKoanAttribute
    
let runKoans container =
    let getKoanResult (m:MethodInfo) =
        try
            m.Invoke(null, [||]) |> ignore
            Success <| sprintf "%s has expanded your awareness." m.Name
        with
        | ex -> 
            let outcome = sprintf "%s has damaged your karma." m.Name
            Failure(outcome, ex.InnerException)
        
    container
    |> findKoanMethods
    |> Seq.map getKoanResult
