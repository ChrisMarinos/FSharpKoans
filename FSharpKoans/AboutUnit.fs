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
[<Koan(Sort = 5)>]
module ``about unit`` =

    [<Koan>]
    let UnitIsUsedWhenThereIsNoReturnValueForAFunction() =
        let sendData data =
            //...sending the data to the server...
            ()

        let x = sendData "data"
        AssertEquality x () //Don't overthink this. Note also the value "()" displays as "null" in some cases.

    [<Koan>]
    let ParameterlessFunctionsTakeUnitAsTheirArgument() =
        let sayHello() =
            "hello"

        let result = sayHello()
        AssertEquality result "hello"
