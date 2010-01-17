namespace FSharpKoans
open FSharpKoans.Core

type ``about asserts``() =

    // We shall contemplate truth by testing reality, via asserts.

    [<Koan>]
    member this.``Assert truth``() =
        // This should be true 
        Assert false 
        
    (* Enlightenment may be more easily achieved with appropriate
       messages. *)

    [<Koan>]
    member this.``Assert with message``() =
        AssertWithMessage false "This should be true -- Please fix this"
 
    (* To understand reality, we must compare our expectations against
       reality. *)
       
    [<Koan>]
    member this.``Assert equality``() =
        let expected_value = __
        let actual_value = 1 + 1
     
        AssertEquality expected_value actual_value
 
    // Sometimes we will ask you to fill in the values
    [<Koan>]
    member this.``Fill in values``() =
        AssertEquality __ (1 + 1)