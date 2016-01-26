namespace FSharpKoans
open NUnit.Framework

(*
    Let's introduce a bit of terminology here:
    - immutable: cannot be changed
    - indexable: can be indexed (e.g., you can say `x.[4]` to get the 5th element of `x`)
    - eager: items are generated when the data structure is created
    - lazy: items are generated on-demand
    - finite: there is necessarily an upper limit on the number of items in the data structure
    - infinite: there is no necessary upper limit on the number of items in the data structure

    Lists are immutable, indexable, eager, finite sequences of a single type.

    Arrays are mutable, indexable, eager, finite sequences of a single type.

    Sequences are immutable, lazy, infinite sequences of a single type.  ALL other
    sequence types, including arrays and lists, can be treated as sequences.
    
    You've already seen List.fold, List.map, List.tryFind, and so on.  Many of these
    functions are also available for sequences and arrays; you'll find Seq.fold, Seq.map,
    Seq.tryFind, etc, and also Array.fold, Array.map, Array.tryFind, etc.  These have
    exactly the same semantics as they do for Lists; they simply operate on different
    data structures.  Note, however, that if you try to do something like find the length
    of an infinite sequence, you'll effectively freeze your program: infinite means infinite.
    The same applies for sorting an infinite sequence and other such operations.

    We can convert between Array, List, and Seq using the following functions:

        - from Array to List: use `List.ofArray` or `Array.toList`
        - from Array to Seq: use `Seq.ofArray` or `Array.toSeq`
        - from List to Array: use `Array.ofList` or `List.toArray`
        - from List to Seq: use `Seq.ofList` or `List.toSeq`
        - from Seq to Array: use `Array.ofSeq` or `Seq.toArray`
        - from Seq to List: use `List.ofSeq` or `Seq.toList`
*)

module ``21: Sequences and Arrays`` =
    (*
        Because sequences are potentially infinite, we have some functions to
        make them a bit easier to handle.
        - `Seq.head x` returns the first element of the sequence `x`
        - `Seq.take n x` returns the first `n` elements of the sequence `x`.  It is
          an error to try to take more elements than exist in `x`.
        - `Seq.skip n x` skips the first `n` elements of the sequence `x`, and
          returns the remainder of the sequence.  It is an error to try to skip
          more elements than exist in `x`.

        There are also more interesting Seq functions, such as `takeWhile` and
        so on.  I'll leave it to you to find some of them here:
            
            https://msdn.microsoft.com/en-us/library/ee353635.aspx
    *)

    [<Test>]
    let ``Creating a sequence (Method 1).`` () =
        let a = Seq.init 10 id // this creates a finite sequence.
        let b = __ // <-- should be a sequence going from 1..15 inclusive
        Seq.length b |> should equal 15
        Seq.head b |> should equal 1

    [<Test>]
    let ``Creating a sequence (Method 2).`` () =
        // this creates an infinite sequence.
        // (well, infinite enough...!  It might wrap around when we get to
        // the maximum value of a 32-bit signed integer.)
        let evenNumbers = Seq.initInfinite (fun n -> n*2)
        let multiplesOfFive = __
        Seq.take 10 multiplesOfFive |> Seq.toList |> should equal [0;5;10;15;20;25;30;35;40;45]
        Seq.skip 1 multiplesOfFive |> Seq.head |> should equal 5
        Seq.skip 2139 multiplesOfFive |> Seq.head |> should equal 10695

    [<Test>]
    let ``Creating a sequence (Method 3).`` () =
        // this creates a sequence based on some "seed" value.
        let puffery seed =
            Seq.unfold (fun state ->
                match String.length state with
                | 0 -> None
                | 1 -> Some(state, "")
                | _ ->
                    let result = state.[..String.length state - 2]
                    Some (state, result)
            ) seed
        // if you understood that, you should be able to do this:
        // https://en.wikipedia.org/wiki/Collatz_conjecture#Statement_of_the_problem
        // ... when the sequence reaches 1, stop.
        let hailstone seed =
            __
        hailstone 6 |> Seq.toList |> should equal [6; 3; 10; 5; 16; 8; 4; 2; 1]
        hailstone 19 |> Seq.toList |> should equal [19; 58; 29; 88; 44; 22; 11; 34; 17; 52; 26; 13; 40; 20; 10; 5; 16; 8; 4; 2; 1]

    [<Test>]
    let ``Creating a sequence (Method 4).`` () =
        // this is called a sequence expression.
        // It can `yield` values, and it can `yield!` sequences.
        let rec hailstone x =
            seq {
                yield x // I'm giving back a generated value here
                match x with
                | 1 -> ()
                | _ ->
                    let result =
                        match x%2 with
                        | 0 -> x/2
                        | _ -> 3*x+1
                    yield! hailstone result // I'm giving back values taken from a sequence here
            }
        let rec puffery x =
            __ // you've seen the 'puffery' function in the previous test, yes?
            // Implement that here, using a sequence expression.
        puffery "Whizz!" |> Seq.toList |> should equal ["Whizz!"; "Whizz"; "Whiz"; "Whi"; "Wh"; "W"]
        puffery "ZchelnIk" |> Seq.toList |> should equal ["ZchelnIk"; "ZchelnI"; "Zcheln"; "Zchel"; "Zche"; "Zch"; "Zc"; "Z"]

    [<Test>]
    let ``Arrays are much like lists`` () =
        // Arrays use [| and |], and Lists use [ and ] .
        let oneToFifteen = __ // <-- WITHOUT using Array.init
        let a = Array.init 5 __
        oneToFifteen |> should equal [|1;2;3;4;5;6;7;8;9;10;11;12;13;14;15|]
        a |> should equal [|1;2;3;4;5|]