namespace FSharpKoans
open FSharpKoans.Core

type ``about let``() =

    [<Koan>]
    member this.LetBindsANameToAValue() =
        let x = 50
        
        AssertEquality x 50
    
    [<Koan>]
    member this.LetInfersTheTypesOfValuesWherePossible() =
        let x = 50
        
        let expectedType = x.GetType()
        
        AssertEquality expectedType typeof<___>
    
    [<Koan>]
    member this.YouCannotModifyAValueOnceItIsBound() =
    
        // the following is syntactically invalid F# code, so
        // we compile it using strings: 
        let statement1 = "let x = 50"
        let statement2 = "x <- 100"
         
        let error = compileCode [statement1; statement2] 

        //What compile error does statement2 cause?
        //Hint: execute the above statements in F# Interactive
        AssertEquality __ error
    
    [<Koan>]
    member this.LetCanAlsoCreateFunctions() =
        let add x y =
            x + y
        
        let result1 = add 2 2
        let result2 = add 5 2
        
        AssertEquality result1 __
        AssertEquality result2 __