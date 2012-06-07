namespace FSharpKoans
open FSharpKoans.Core

module ``about asserts`` =

    // We shall contemplate truth by testing reality, via asserts.

    [<Koan>]
    let AssertTruth() =
        // This should be true
        Assert false
        
    (* Enlightenment may be more easily achieved with appropriate
       messages. *)

    [<Koan>]
    let AssertWithMessage() =
        AssertWithMessage false "This should be true -- Please fix this"
 
    (* To understand reality, we must compare our expectations against
       reality. *)
       
    [<Koan>]
    let AssertExpectation() =
        let expected_value = 1 + 1
        let actual_value = __
     
        AssertEquality expected_value actual_value
 
    // Sometimes we will ask you to fill in the values
    [<Koan>]
    let FillInValues() =
        AssertEquality (1 + 1) __
