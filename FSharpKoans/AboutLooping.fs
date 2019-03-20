namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About Looping
//
// While it's more common in F# to use the Seq, List, or Array
// modules to perform looping operations, you can still fall 
// back on traditional imperative looping techniques that you may 
// be more familiar with.
//---------------------------------------------------------------
[<Koan(Sort = 12)>]
module ``about looping`` =
    [<Koan>]
    let LoopingOverAList() =
        let values = [0..10]

        let mutable sum = 0
        for value in values do
            sum <- sum + value

        AssertEquality sum 55
       
    [<Koan>]
    let LoopingWithExpressions() =
        let mutable sum = 0

        for i = 1 to 5 do
            sum <- sum + i

        AssertEquality sum 15

    [<Koan>]
    let LoopingWithWhile() =
        let mutable sum = 1

        while sum < 10 do
            sum <- sum + sum

        AssertEquality sum 16

    (* NOTE: While these looping constructs can come in handy from time to time,
             it's often better to use a more functional approach for looping
             such as the functions you learned about in the List module. *)
