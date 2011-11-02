namespace FSharpKoans
open FSharpKoans.Core

type ``about option types``() =

    [<Koan>]
    member this.OptionTypesMightContainAValue() =
        let someValue = Some 10
        
        AssertEquality someValue.IsSome __
        AssertEquality someValue.IsNone __
        AssertEquality someValue.Value __

    [<Koan>]
    member this.OrTheyMightNot() =
        let noValue = None

        AssertEquality noValue.IsSome __
        AssertEquality noValue.IsNone __
        AssertThrows<FILL_IN_THE_EXCEPTION> (fun () -> noValue.Value __)