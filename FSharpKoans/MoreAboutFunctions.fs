namespace FSharpKoans
open FSharpKoans.Core

type ``more about functions``() =
    
    [<Koan>]
    member this.DefiningLambdas() =
        
        let colors = ["maize"; "blue"]

        let echo = 
            colors
            |> List.map (fun x -> x + " " + x)

        AssertEquality echo __

        (* The fun keyword allows you to create a function inline without giving
           it a name. These functions are known as anonymous functions, lambdas,
           or lambda functions. *)