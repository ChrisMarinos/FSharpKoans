namespace FSharpKoans

open Expecto

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

module ``about record types`` =
  let tests =
    koans "about record types" [
      koan "records have properties" {
        let mario = { Name = "Mario"; Occupation = "Plumber"; }

        AssertEquality mario.Name __
        AssertEquality mario.Occupation __
      }

      koan "creating from an existing record" {
        let mario = { Name = "Mario"; Occupation = "Plumber"; }
        let luigi = { mario with Name = "Luigi"; }

        AssertEquality mario.Name __
        AssertEquality mario.Occupation __

        AssertEquality luigi.Name __
        AssertEquality luigi.Occupation __
      }

      koan "comparing records" {
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

        AssertEquality koopaComparison __
        AssertEquality bowserComparison __
      }

      koan "you can pattern match against records" {
        let mario = { Name = "Mario"; Occupation = "Plumber"; }
        let luigi = { Name = "Luigi"; Occupation = "Plumber"; }
        let bowser = { Name = "Bowser"; Occupation = "Kidnapper"; }

        let determineSide character =
          match character with
          | { Occupation = "Plumber" } -> "good guy"
          | _ -> "bad guy"

        AssertEquality (determineSide mario) __
        AssertEquality (determineSide luigi) __
        AssertEquality (determineSide bowser) __
      }
    ]
