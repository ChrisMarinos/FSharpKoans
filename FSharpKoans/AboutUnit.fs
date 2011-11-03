namespace FSharpKoans
open FSharpKoans.Core
open Microsoft.FSharp.Reflection

type ``about unit``() =

    [<Koan>]
    member this.UnitIsUsedWhenThereIsNoReturnValueForAFunction() =
        let sendData data =
            //send the data to the server
            ()

        let x = sendData "data"
        AssertEquality x __ //Don't overthink this

    [<Koan>]
    member this.ParameterlessFuncitonsTakeUnitAsTheirArgument() =
        let sayHello() =
            "hello"

        let result = sayHello()
        AssertEquality result __