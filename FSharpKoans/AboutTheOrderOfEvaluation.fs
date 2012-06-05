namespace FSharpKoans
open FSharpKoans.Core

type ``about the order of evaluation``() =

    [<Koan>]
    member this.SometimesYouNeedParenthesisToGroupThings() =
        let add x y =
            x + y

        let result = add (add 5 8) (add 1 1)

        AssertEquality result __

        (* TRY IT: What happens if you remove the parenthesis?*)

    [<Koan>]
    member this.TheBackwardPipeOperatorCanHelpWithGrouping() =
        let add x y =
            x + y

        let result = add <| add 5 8 <| add 1 1

        AssertEquality result __