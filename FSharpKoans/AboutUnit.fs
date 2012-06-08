﻿namespace FSharpKoans
open FSharpKoans.Core
open Microsoft.FSharp.Reflection

//---------------------------------------------------------------
// About Unit
//
// The unit type is a special type that represents the lack of
// a value. It's similar to void in other languages, but unit
// is actually considered to be a type in F#.
//---------------------------------------------------------------
[<Koan(Sort = 5)>]
module ``about unit`` =

    [<Koan>]
    let UnitIsUsedWhenThereIsNoReturnValueForAFunction() =
        let sendData data =
            //...sending the data to the server...
            ()

        let x = sendData "data"
        AssertEquality x __ //Don't overthink this

    [<Koan>]
    let ParameterlessFuncitonsTakeUnitAsTheirArgument() =
        let sayHello() =
            "hello"

        let result = sayHello()
        AssertEquality result __
