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
    koans "about unit" [
      koan "unit is used when there is no return value for a function" {
        let sendData data =
          //...sending the data to the server...
          ()

        let x = sendData "data"
        //Don't overthink this. Note also the value "()" displays as "null" in some cases.
        AssertEquality x __
      }

      koan "parameterless functions take unit as their only argument" {
        let sayHello () =
          "hello"

        let result = sayHello ()
        AssertEquality result __
      }
    ]
