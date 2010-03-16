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
        
        let expectedType = x.GetType()
        
        AssertEquality expectedType typeof<FILL_ME_IN>
    
    [<Koan>]
    member this.YouCannotModifyAnImmutableValue() =
    
        // the following is syntactically invalid F# code, so
        // we compile it using strings: 
        let statement1 = "let x = 50"
        let statement2 = "x <- 100"
         
        let error = compileCode [statement1; statement2] 

        //What compile error does statement2 cause?
        //Hint: execute the above statements in F# Interactive
        AssertEquality error __
    
    [<Koan>]
    member this.YouCanModifyMutableVariables() =
        let mutable x = 100
        x <- 200

        AssertEquality x __