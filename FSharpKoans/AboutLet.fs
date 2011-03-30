namespace FSharpKoans
open FSharpKoans.Core

type ``about let``() =

    [<Koan>]
    member this.LetBindsANameToAValue() =
        let x = 50
        
        AssertEquality x __
    
    [<Koan>]
    member this.LetInfersTheTypesOfValuesWherePossible() =
        let x = 50
        let typeOfX = x.GetType()
        AssertEquality typeOfX typeof<int>

        let y = "a string"
        let expectedType = y.GetType()
        AssertEquality expectedType typeof<FILL_ME_IN>
    
    [<Koan>]
    member this.ModifyingTheValueOfVariables() =
        let mutable x = 100
        x <- 200

        AssertEquality x __

    [<Koan>]
    member this.YouCannotModifyALetBoundValueIfItIsNotMutable() =
        let x = 50
        
        //What happens if you uncomment the following?
        //
        //x <- 100

        //NOTE: Although you can't modify immutable values, it is possible
        //      to reuse the name of a value in some cases using "shadowing".
        let x = 100
         
        AssertEquality x __