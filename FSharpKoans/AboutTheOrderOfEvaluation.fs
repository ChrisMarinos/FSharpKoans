namespace FSharpKoans
open NUnit.Framework

//---------------------------------------------------------------
// About the Order of Evaluation
//
// Sometimes you'll need to be explicit about the order in which
// functions are evaluated. F# offers a couple mechanisms for
// doing this.
//---------------------------------------------------------------
module ``about the order of evaluation`` =

    [<Test>]
    let SometimesYouNeedParenthesisToGroupThings() =
        let add x y =
            x + y

        let result = add (add 5 8) (add 1 1)

        AssertEquality result __

        (* TRY IT: What happens if you remove the parenthesis?*)

    [<Test>]
    let TheBackwardPipeOperatorCanAlsoHelpWithGrouping() =
        let add x y =
            x + y

        let double x =
            x * 2

        let result = double <| add 5 8

        AssertEquality result __
