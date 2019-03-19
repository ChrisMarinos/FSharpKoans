namespace FSharpKoans
open FSharpKoans.Core

type Character = {
    Name: string
    Occupation: string
}

//---------------------------------------------------------------
// About Record Types
//
// Record types are lightweight ways to construct new types.
// You can use them to group data in a more structured way than
// tuples.
//---------------------------------------------------------------
[<Koan(Sort = 16)>]
module ``about record types`` =

    [<Koan>]
    let RecordsHaveProperties() =
        let mario = { Name = "Mario"; Occupation = "Plumber"; }

        AssertEquality mario.Name "Mario"
        AssertEquality mario.Occupation "Plumber"

    [<Koan>]
    let CreatingFromAnExistingRecord() =
        let mario = { Name = "Mario"; Occupation = "Plumber"; }
        let luigi = { mario with Name = "Luigi"; }

        AssertEquality mario.Name "Mario"
        AssertEquality mario.Occupation "Plumber"

        AssertEquality luigi.Name "Luigi"
        AssertEquality luigi.Occupation "Plumber"

    [<Koan>]
    let ComparingRecords() =
        let greenKoopa = { Name = "Koopa"; Occupation = "Soldier"; }
        let bowser = { Name = "Bowser"; Occupation = "Kidnapper"; }
        let redKoopa = { Name = "Koopa"; Occupation = "Soldier"; }

        let koopaComparison =
             if greenKoopa = redKoopa then
                 "all the koopas are pretty much the same"
             else
                 "maybe one can fly"

        let bowserComparison = 
            if bowser = greenKoopa then
                "the king is a pawn"
            else
                "he is still kind of a koopa"

        AssertEquality koopaComparison "all the koopas are pretty much the same"
        AssertEquality bowserComparison "he is still kind of a koopa"

    [<Koan>]
    let YouCanPatternMatchAgainstRecords() =
        let mario = { Name = "Mario"; Occupation = "Plumber"; }
        let luigi = { Name = "Luigi"; Occupation = "Plumber"; }
        let bowser = { Name = "Bowser"; Occupation = "Kidnapper"; }

        let determineSide character =
            match character with
            | { Occupation = "Plumber" } -> "good guy"
            | _ -> "bad guy"

        AssertEquality (determineSide mario) "good guy"
        AssertEquality (determineSide luigi) "good guy"
        AssertEquality (determineSide bowser) "bad guy"
