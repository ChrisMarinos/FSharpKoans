namespace FSharpKoans
open FSharpKoans.Core

type Person = {
    Name: string
    Occupation: string
}

type ``about record types``() =

    [<Koan>]
    member this.RecordsHaveProperties() =
        let mario = { Name = "Mario"; Occupation = "plumber"; }

        AssertEquality mario.Name __
        AssertEquality mario.Occupation __

    [<Koan>]
    member this.CreatingFromAnExistingRecord() =
        let mario = { Name = "Mario"; Occupation = "plumber"; }
        let luigi = { mario with Name = "Luigi"; }

        AssertEquality mario.Name __
        AssertEquality mario.Occupation __

        AssertEquality luigi.Name __
        AssertEquality luigi.Occupation __

    [<Koan>]
    member this.ComparingRecords() =
        let greenKoopa = { Name = "Koopa"; Occupation = "soilder"; }
        let bowser = { Name = "Bowser"; Occupation = "kidnapper"; }
        let redKoopa = { Name = "Koopa"; Occupation = "soilder"; }

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

        AssertEquality koopaComparison __
        AssertEquality bowserComparison __