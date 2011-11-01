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

    [<Koan>]
    member this.PartialApplication() =
        let add x y = 
            x + y

        (* You already know that you can pass multiple arguments to a function 
           at once *)
        let thirteen = add 6 7
        AssertEquality thirteen __

        (* but you can also pass arguments one at a time to create residual 
          functions. This is called Partial Application. *)
        let addSeven = add 7
        let unluckyNumber = addSeven 6
        let luckyNumber = addSeven 0

        AssertEquality unluckyNumber __
        AssertEquality luckyNumber __