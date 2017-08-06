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
    testListRev "teaching about record types" [
      testCase "records have properties" <| fun () ->
        let mario = { Name = "Mario"; Occupation = "Plumber"; }

        AssertEquality mario.Name __
        AssertEquality mario.Occupation __

      testCase "creating from an existing record" <| fun () ->
        let mario = { Name = "Mario"; Occupation = "Plumber"; }
        let luigi = { mario with Name = "Luigi"; }

        AssertEquality mario.Name __
        AssertEquality mario.Occupation __

        AssertEquality luigi.Name __
        AssertEquality luigi.Occupation __

      testCase "comparing records" <| fun () ->
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

      testCase "you can pattern match against records" <| fun () ->
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
    ]
