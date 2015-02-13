namespace FSharpKoans
open NUnit.Framework

(*
Each of the tests teaches you something about functional programming and/or F#.
By the time you're done, you should have a basic understanding of how features
fit together and are used.

It's STRONGLY recommended that you read through the module notes as you go
through this.  The order of the tests matches the order in which the material in
the notes is presented!
*)

// In each test, you will see things like __ or FILL_ME_IN .
// ONLY change those things, and you'll do fine :).
// Good luck, and enjoy the journey!

module Testing = 
   [<Test>]
   let ``How this works``() = 
      let expected_value = 1 + 1
      let actual_value = __ //start by changing this line
      actual_value |> should equal expected_value
   
   // Easy, right? Now try one more
   [<Test>]
   let ``Fill in the values``() = (1 + 1) |> should equal __
