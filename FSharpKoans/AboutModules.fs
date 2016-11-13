namespace FSharpKoans
open FSharpKoans.Core

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
[<Koan(Sort = 19)>]
module ``about modules`` =

    [<Koan>]
    let ModulesCanContainValuesAndTypes() =

        AssertEquality MushroomKingdom.Mario.Name "Mario"
        AssertEquality MushroomKingdom.Mario.Occupation "Plumber"
        
        let moduleType = MushroomKingdom.Mario.GetType()
        AssertEquality moduleType typeof<MushroomKingdom.Character>

    [<Koan>]
    let ModulesCanContainFunctions() =
        let superMario = MushroomKingdom.powerUp MushroomKingdom.Mario

        AssertEquality superMario.Power (Some MushroomKingdom.Power.Mushroom)

(* NOTE: In previous sections, you've seen modules like List and Option that 
         contain useful functions for dealing with List types and Option types
         respectively. *)

open MushroomKingdom

[<Koan(Sort = 20)>]
module ``about opened modules`` =
    [<Koan>]
    let OpenedModulesBringTheirContentsInScope() = 
        AssertEquality Mario.Name "Mario"
        AssertEquality Mario.Occupation "Plumber"
        AssertEquality Mario.Power None