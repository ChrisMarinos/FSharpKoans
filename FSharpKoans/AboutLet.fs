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
    member this.YouCanMakeTypesExplicit() =
        let (x:int) = 42
        let typeOfX = x.GetType()

        let y:string = "forty two"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<FILL_ME_IN>
        AssertEquality typeOfY typeof<FILL_ME_IN>

        (* You don't usually need to provide explicit type annotations types for 
           local varaibles, but type annotations can come in handy in other 
           contexts as you'll see later. *)
    
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