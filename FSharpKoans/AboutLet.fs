namespace FSharpKoans
open FSharpKoans.Core

type ``about let``() =

    [<Koan>]
    member this.LetBindsANameToAValue() =
        let x = 50
        
        AssertEquality x __ 
    
    (* I want to get the following to work. Unfortunately, the current version
       of the F# FSharpCodeProvider requires that fsc.exe be in your path. 
       This is too big of a headache to deal with now.
    [<Koan>]
    member this.YouCannotModifyAValueOnceItIsBound() =
    
        // the following is syntactically invalid F# code, so it is in a string: 
        let statement1 = "let x = 50"
        let statement2 = "x <- 100"
         
        let error = compileCode [statement1; statement2] 

        //What compile error does statement2 cause?
        //Hint: execute the above statements in F# Interactive
        AssertEquality __ error *)
    
    [<Koan>]
    member this.LetCanAlsoCreateAFunction() =
        let add x y =
            x + y
        
        let result1 = add 2 2
        let result2 = add 5 2
        
        AssertEquality result1 __
        AssertEquality result2 __