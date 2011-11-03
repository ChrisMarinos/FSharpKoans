namespace FSharpKoans
open FSharpKoans.Core

type Game = {
    Name: string
    Platform: string
    Score: int option
}

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
        AssertThrows<FILL_IN_THE_EXCEPTION> (fun () -> noValue.Value)

    [<Koan>]
    member this.UsingOptionTypesWithPatternPatching() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let gta = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let translate score =
            match score with
            | 5 -> "Great"
            | 4 -> "Good"
            | 3 -> "Decent"
            | 2 -> "Bad"
            | 1 -> "Awful"
            | _ -> "Unknown"

        let getScore game =
            match game.Score with
            | Some score -> translate score
            | None -> "Unknown"

        AssertEquality (getScore chronoTrigger) __
        AssertEquality (getScore gta) __

    [<Koan>]
    member this.ProjectingValuesFromOptionTypes() =
        let chronoTrigger = { Name = "Chrono Trigger"; Platform = "SNES"; Score = Some 5 }
        let gta = { Name = "Halo"; Platform = "Xbox"; Score = None }

        let decideOn game =

            game.Score
            |> Option.map (fun score -> if score > 3 then "play it" else "don't play")

        //HINT: look at the return type of the decide on function
        AssertEquality (decideOn chronoTrigger) __
        AssertEquality (decideOn chronoTrigger) __