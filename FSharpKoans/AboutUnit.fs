namespace FSharpKoans
open FSharpKoans.Core
open Microsoft.FSharp.Reflection

//---------------------------------------------------------------
// About Unit
//
// The unit type is a special type that represents the lack of
// a value. It's similar to void in other languages, but unit
// is actually considered to be a type in F#.
//---------------------------------------------------------------
type ``about unit``() =

    [<Koan>]
    member this.UnitIsUsedWhenThereIsNoReturnValueForAFunction() =
        let sendData data =
            //...sending the data to the server...
            ()

        let x = sendData "data"
        AssertEquality x __ //Don't overthink this

    [<Koan>]
    member this.ParameterlessFuncitonsTakeUnitAsTheirArgument() =
        let sayHello() =
            "hello"

        let result = sayHello()
        AssertEquality result __