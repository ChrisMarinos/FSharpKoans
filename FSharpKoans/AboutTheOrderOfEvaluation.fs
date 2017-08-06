namespace FSharpKoans
open Expecto

//---------------------------------------------------------------
// About the Order of Evaluation
//
// Sometimes you'll need to be explicit about the order in which
// functions are evaluated. F# offers a couple mechanisms for
// doing this.
//---------------------------------------------------------------

module ``about the order of evaluation`` =
  let tests =
    testListRev "teaching about precedence" [
      testCase "sometimes you need parenthesis to group things" <| fun () ->
        let add x y =
          x + y

        let result = add (add 5 8) (add 1 1)
        AssertEquality result __

        (* TRY IT: What happens if you remove the parenthesis?*)

      testCase "the backwards pipe can also help with grouping" <| fun () ->
        let add x y =
          x + y

        let double x =
          x * 2

        let result = double <| add 5 8
        AssertEquality result __
    ]