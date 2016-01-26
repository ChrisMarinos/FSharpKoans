namespace FSharpKoans
open NUnit.Framework

(*
Reversing a list.
*)

module ``13: Reversing a list`` =

    [<Test>]
    let ``Reversing a list, the hard way`` () =
        let rev (xs : 'a list) : 'a list =
            __ // write a function to reverse a list here.
        rev [9;8;7] |> should equal [7;8;9]
        rev [] |> should equal []
        rev [0] |> should equal [0]
        rev [9;3;4;1;6;5;4] |> should equal [4;5;6;1;4;3;9]

    // Hint: https://msdn.microsoft.com/en-us/library/ee340277.aspx
    [<Test>]
    let ``Reversing a list, the easy way`` () =
        __ [9;8;5;8;45] |> should equal [45;8;5;8;9]
