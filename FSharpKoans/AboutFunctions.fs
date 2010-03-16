namespace FSharpKoans
open FSharpKoans.Core

type ``about functions``() =

    (* By default, F# is whitespace sensitive.
       For functions, this means that the last
       line of a function is its return value,
       and the body of a function is denoted
       by indentation. *)

    let add x y =
        x + y

    [<Koan>]
    member this.CreatingFunctionsWithLet() =
        let result1 = add 2 2
        let result2 = add 5 2
        
        AssertEquality result1 __
        AssertEquality result2 __

    [<Koan>]
    member this.NestingFunctions() =
        let quadruple x =    
            let double x =
                x * 2

            double(double(x))

        let result = quadruple 4
        AssertEquality result __