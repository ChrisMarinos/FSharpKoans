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


    [<Koan>]
    member this.NonCurriedFunctions() =
        (* The normal function syntax for F# allows you to partially apply 
           arguments as you just saw. Functions defined in this form are said 
           to be curried. However, you can also write functions in an uncurried 
           form to make them easier to use from languages like C# where currying 
           is not as commonly used. *)

        let add(x, y) =
            x + y

        (* NOTE: "add 5" will not compile now. You have to pass both arguments 
                 at once *)

        let result = add(5, 40)

        AssertEquality result __

        (* THINK ABOUT IT: You learned earlier that functions with multiple 
                           return values are really just functions that return
                           tuples. Do functions defined in the uncurried form
                           really accept more than one argument at a time? *)