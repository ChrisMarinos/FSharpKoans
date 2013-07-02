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

//---------------------------------------------------------------
// About Discriminated Unions
//
// Discriminated unions are used to represent data that can be
// one of a fixed number of cases. To start off, you can think
// of them like a much more powerful version of enums in other
// languages.
//---------------------------------------------------------------
[<Koan(Sort = 18)>]
module ``about discriminated unions`` =
    [<Koan>]
    let DiscriminatedUnionsCaptureASetOfOptions() =

        let toColor condiment = 
            match condiment with
            | Mustard -> "yellow"
            | Ketchup -> "red"
            | Relish -> "green"
            | Vinegar -> "brownish?"

        let choice = Mustard

        AssertEquality (toColor choice) "yellow"

        (* TRY IT: What happens if you remove a case from the above pattern 
                   match? *)

    [<Koan>]
    let DiscriminatedUnionCasesCanHaveTypes() =

        let saySomethingAboutYourFavorite favorite =
            match favorite with
            | Number 7 -> "me too!"
            | Bourbon "Bookers" -> "me too!"
            | Bourbon b -> "I prefer Bookers to " + b
            | Number _ -> "I'm partial to 7"

        let bourbonResult = saySomethingAboutYourFavorite <| Bourbon "Maker's Mark"
        let numberResult = saySomethingAboutYourFavorite <| Number 7
        
        AssertEquality bourbonResult "I prefer Bookers to Maker's Mark"
        AssertEquality numberResult "me too!"
