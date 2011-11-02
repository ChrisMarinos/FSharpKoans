namespace FSharpKoans
open FSharpKoans.Core

type Condiment =
    | Mustard
    | Ketchup
    | Relish
    | Vinegar

type Favorite =
    | Bourbon of string
    | Number of int

type ``about descriminated unions``() =
    [<Koan>]
    member this.DescriminatedUnionsCaptureASetOfOptions() =

        let toColor condiment = 
            match condiment with
            | Mustard -> "yellow"
            | Ketchup -> "red"
            | Relish -> "green"
            | Vinegar -> "brownish?"

        let choice = Mustard

        AssertEquality (toColor choice) __

        (* TRY IT: What happens if you remove a case from the above pattern 
                   match? *)

    [<Koan>]
    member this.DescriminatedUnionCasesCanHaveTypes() =

        let saySomethingAboutYourFavorite favorite =
            match favorite with
            | Number 7 -> "me too!"
            | Bourbon "Bookers" -> "me too!"
            | Bourbon b -> "I prefer Bookers to " + b
            | Number _ -> "I'm partial to 7"

        let bourbonResult = saySomethingAboutYourFavorite <| Bourbon "Maker's Mark"
        let numberResult = saySomethingAboutYourFavorite <| Number 7
        
        AssertEquality bourbonResult __
        AssertEquality numberResult __