namespace FSharpKoans
open FSharpKoans.Core

//----------------------------------------------------------------
// About Pipelining
//
// The forward pipe operator is one of the most commonly used
// symbols in F# programming. You can use it to combine operations
// on lists and other data structures in a readable way.
//----------------------------------------------------------------
[<Koan(Sort = 10)>]
module ``about pipelining`` =

    let square x =
        x * x

    let isEven x =
        x % 2 = 0

    [<Koan>]
    let SquareEvenNumbersWithSeparateStatements() =
        (* One way to combine the operations is by using separate statements.
           However, this can be clumsy since you have to name each result. *)

        let numbers = [0..5]

        let evens = List.filter isEven numbers
        let result = List.map square evens

        AssertEquality result [0;4;16]

    [<Koan>]
    let SquareEvenNumbersWithParens() =
        (* You can avoid this problem by using parens to pass the result of one
           function to another. This can be difficult to read since you have to 
           start from the innermost function and work your way out. *)

        let numbers = [0..5]

        let result = List.map square (List.filter isEven numbers)

        AssertEquality result [0;4;16]

    [<Koan>]
    let SquareEvenNumbersWithPipelineOperator() =
        (* In F#, you can use the pipeline operator to get the benefit of the 
           parens style with the readablity of the statement style. *)

        let result =
            [0..5]
            |> List.filter isEven
            |> List.map square
        
        AssertEquality result [0;4;16]

    [<Koan>]
    let HowThePipeOperatorIsDefined() =
        let (|>) x f =
            f x

        let result =
            [0..5]
            |> List.filter isEven
            |> List.map square

        AssertEquality result [0;4;16]
