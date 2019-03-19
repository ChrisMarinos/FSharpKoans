namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// More About Functions
//
// You've already learned a little about functions in F#, but
// since F# is a functional language, there are more tricks
// to learn!
//---------------------------------------------------------------
[<Koan(Sort = 13)>]
module ``more about functions`` =
    
    [<Koan>]
    let DefiningLambdas() =
        
        let colors = ["maize"; "blue"]

        let echo = 
            colors
            |> List.map (fun x -> x + " " + x)

        AssertEquality echo ["maize maize"; "blue blue"]

        (* The fun keyword allows you to create a function inline without giving
           it a name. These functions are known as anonymous functions, lambdas,
           or lambda functions. *)

    [<Koan>]
    let FunctionsThatReturnFunctions() =
        (* A neat functional programming trick is to create functions that 
           return other functions. This leads to some interesting behaviors. *)
        let add x =
            (fun y -> x + y)

        (* F#'s lightweight syntax allows you to call both functions as if there
           was only one *)
        let simpleResult = add 2 4
        AssertEquality simpleResult 6

        (* ...but you can also pass only one argument at a time to create
           residual functions. This technique is known as partial application. *)
        let addTen = add 10
        let fancyResult = addTen 14

        AssertEquality fancyResult 24

        //NOTE: Functions written in this style are said to be curried.

    [<Koan>]
    let AutomaticCurrying() =
        (* The above technique is common enough that F# actually supports this
           by default. In other words, functions are automatically curried. *)
        let add x y = 
            x + y

        let addSeven = add 7
        let unluckyNumber = addSeven 6
        let luckyNumber = addSeven 0

        AssertEquality unluckyNumber 13
        AssertEquality luckyNumber 7

    [<Koan>]
    let NonCurriedFunctions() =
        (* You should stick to the auto-curried function syntax most of the 
           time. However, you can also write functions in an uncurried form to
           make them easier to use from languages like C# where currying is not 
           as commonly used. *)

        let add(x, y) =
            x + y

        (* NOTE: "add 5" will not compile now. You have to pass both arguments 
                 at once *)

        let result = add(5, 40)

        AssertEquality result 45

        (* THINK ABOUT IT: You learned earlier that functions with multiple 
                           return values are really just functions that return
                           tuples. Do functions defined in the uncurried form
                           really accept more than one argument at a time? *)
