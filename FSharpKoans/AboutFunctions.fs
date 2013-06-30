namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About Functions
//
// Now that you've seen how to bind a name to a value with let,
// you'll learn to use the let keyword to create functions.
//---------------------------------------------------------------
[<Koan(Sort = 3)>]
module ``about functions`` =

    (* By default, F# is whitespace sensitive.
       For functions, this means that the last
       line of a function is its return value,
       and the body of a function is denoted
       by indentation. *)

    let add x y =
        x + y

    [<Koan>]
    let CreatingFunctionsWithLet() =
        let result1 = add 2 2
        let result2 = add 5 2
        
        AssertEquality result1 4
        AssertEquality result2 7

    [<Koan>]
    let NestingFunctions() =
        let quadruple x =    
            let double x =
                x * 2

            double(double(x))

        let result = quadruple 4
        AssertEquality result 16

    [<Koan>]
    let AddingTypeAnnotations() =

        (* Sometimes you need to help F#'s type inference system out with an
           explicit type annotation *)
    
        let sayItLikeAnAuctioneer (text:string) =
            text.Replace(" ", "")

        let auctioneered = sayItLikeAnAuctioneer "going once going twice sold to the lady in red"
        AssertEquality auctioneered "goingoncegoingtwicesoldtotheladyinred"

        //TRY IT: What happens if you remove the type annotation on text?

    [<Koan>]
    let VariablesInTheParentScopeCanBeAccessed() =
        let suffix = "!!!"

        let caffinate (text:string) =
            let exclaimed = text + suffix
            let yelled = exclaimed.ToUpper()
            yelled.Trim()

        let caffinatedReply = caffinate "hello there"

        AssertEquality caffinatedReply "HELLO THERE!!!"

        (* NOTE: Accessing the suffix variable in the nested caffinate function 
                 is known as a closure. 
                 
                 See http://en.wikipedia.org/wiki/Closure_(computer_science) 
                 for more about about closure. *)

        (* TRY IT: What happens if you make suffix into a mutable variable? *)
