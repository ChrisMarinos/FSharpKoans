namespace FSharpKoans
open FSharpKoans.Core

type ``about pipelining``() =

    (* Now that you've seen a few operations
       for working with lists, you will
       want to start combining these operations
       to do more interesting things *)

    let square x =
        x * x

    let isEven x =
        x % 2 = 0

    [<Koan>]
    member this.SquareEvenNumbersWithSeparateStatements() =
        (* One way to combine the operations is by
           using separate statements. This is
           a little clumsy since you have to name
           each result, though. *)

        let numbers = [0..5]

        let evens = List.filter isEven numbers
        let result = List.map square evens

        AssertEquality result __

    [<Koan>]
    member this.SquareEvenNumbersWithParens() =
        (* You can avoid this problem by using
           parens to pass the result of one
           funciton to another. This fixes one
           problem, but it can be difficult
           to read since you have to start from
           the innermost function and work your 
           way out. *)

        let numbers = [0..5]

        let result = List.map square (List.filter isEven numbers)

        AssertEquality result __

    [<Koan>]
    member this.SquareEvenNumbersWithPipelineOperator() =
        (* In F#, you can use the pipeline operator to
           get the benefit of the parens style with the
           readablity of the stateemnt style. *)

        let result =
            [0..5]
            |> List.filter isEven
            |> List.map square
        
        AssertEquality result __

    [<Koan>]
    member this.HowThePipeOperatorIsDefined() =
        let (|>) x y =
            y x

        let result =
            [0..5]
            |> List.filter isEven
            |> List.map square

        AssertEquality result __