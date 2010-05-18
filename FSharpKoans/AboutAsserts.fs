namespace FSharpKoans
open FSharpKoans.Core

type ``about asserts``() =

    // We shall contemplate truth by testing reality, via asserts.

    [<Koan>]
    member this.AssertTruth() =
        // This should be true
        Assert false 
        
    (* Enlightenment may be more easily achieved with appropriate
       messages. *)

    [<Koan>]
    member this.AssertWithMessage() =
        AssertWithMessage false "This should be true -- Please fix this"
 
    (* To understand reality, we must compare our expectations against
       reality. *)
       
    [<Koan>]
    member this.AssertEquality() =
        let expected_value = 1 + 1
        let actual_value = __
     
        AssertEquality expected_value actual_value
 
    // Sometimes we will ask you to fill in the values
    [<Koan>]
    member this.FillInValues() =
        AssertEquality (1 + 1) __