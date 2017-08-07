namespace FSharpKoans

open Expecto

module MushroomKingdom =
    type Power =
        | Mushroom
        | Star
        | FireFlower

    type Character = {
        Name: string
        Occupation: string
        Power: Power option
    }

    let Mario = { Name = "Mario"; Occupation = "Plumber"; Power = None}

    let powerUp character =
        { character with Power = Some Mushroom }

//---------------------------------------------------------------
// About Modules
//
// Modules are used to group functions, values, and types.
// They're similar to .NET namespaces, but they have slightly
// different semantics as you'll see below.
//---------------------------------------------------------------

module ``about modules`` =
  let tests =
    koans "about modules" [
      koan "modules can contain values and types" {
        AssertEquality MushroomKingdom.Mario.Name __
        AssertEquality MushroomKingdom.Mario.Occupation __

        let moduleType = MushroomKingdom.Mario.GetType()
        AssertEquality moduleType typeof<FILL_ME_IN>
      }

      koan "modules can contain functions" {
        let superMario = MushroomKingdom.powerUp MushroomKingdom.Mario

        AssertEquality superMario.Power __

        (* NOTE:  In previous sections, you've seen modules like List and Option that
                  contain useful functions for dealing with List types and Option types
                  respectively. *)
      }
    ]

open MushroomKingdom

module ``about opened modules`` =
  let tests =
      koan "opened modules bring their contents into scope" {
        AssertEquality Mario.Name __
        AssertEquality Mario.Occupation __
        AssertEquality Mario.Power __
      }