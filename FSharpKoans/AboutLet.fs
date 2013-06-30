namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About Let
//
// The let keyword is one of the most fundamental parts of F#.
// You'll use it in almost every line of F# code you write, so
// let's get to know it well! (no pun intended)
//---------------------------------------------------------------
[<Koan(Sort = 2)>]
module ``about let`` =

    [<Koan>]
    let LetBindsANameToAValue() =
        let x = 50
        
        AssertEquality x 50
    
    (* In F#, values created with let are inferred to have a type like
       "int" for integer values, "string" for text values, and "bool" 
       for true or false values. *)
    [<Koan>]
    let LetInfersTheTypesOfValuesWherePossible() =
        let x = 50
        let typeOfX = x.GetType()
        AssertEquality typeOfX typeof<int>

        let y = "a string"
        let expectedType = y.GetType()
        AssertEquality expectedType typeof<string>

    [<Koan>]
    let YouCanMakeTypesExplicit() =
        let (x:int) = 42
        let typeOfX = x.GetType()

        let y:string = "forty two"
        let typeOfY = y.GetType()

        AssertEquality typeOfX typeof<int>
        AssertEquality typeOfY typeof<string>

        (* You don't usually need to provide explicit type annotations types for 
           local varaibles, but type annotations can come in handy in other 
           contexts as you'll see later. *)
    
    [<Koan>]
    let FloatsAndInts() =
        (* Depending on your background, you may be surprised to learn that
           in F#, integers and floating point numbers are different types. 
           In other words, the following is true. *)
        let x = 20
        let typeOfX = x.GetType()

        let y = 20.0
        let typeOfY = y.GetType()

        //you don't need to modify these
        AssertEquality typeOfX typeof<int>
        AssertEquality typeOfY typeof<float>

        //If you're coming from another .NET language, float is F# slang for
        //the double type.

    [<Koan>]
    let ModifyingTheValueOfVariables() =
        let mutable x = 100
        x <- 200

        AssertEquality x 200

    [<Koan>]
    let YouCannotModifyALetBoundValueIfItIsNotMutable() =
        let x = 50
        
        //What happens if you uncomment the following?
        //
        //x <- 100

        //NOTE: Although you can't modify immutable values, it is possible
        //      to reuse the name of a value in some cases using "shadowing".
        let x = 100
         
        AssertEquality x 100
