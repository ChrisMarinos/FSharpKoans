namespace FSharpKoans

open Expecto
open Microsoft.FSharp.Reflection

//---------------------------------------------------------------
// About Unit
//
// The unit type is a special type that represents the lack of
// a value. It's similar to void in other languages, but unit
// is actually considered to be a type in F#.
//---------------------------------------------------------------

module ``about unit`` =
  let tests =
    testListRev "teaching about the unit value" [
      testCase "unit is used when there is no return value for a function" <| fun () ->
        let sendData data =
          //...sending the data to the server...
          ()

        let x = sendData "data"
        //Don't overthink this. Note also the value "()" displays as "null" in some cases.
        AssertEquality x __

      testCase "parameterless functions take unit as their only argument" <| fun () ->
        let sayHello () =
          "hello"

        let result = sayHello ()
        AssertEquality result __
    ]
