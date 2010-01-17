namespace FSharpKoans
open Core
open NUnit.Framework

type AboutAsserts() =

    // We shall contemplate truth by testing reality, via asserts.
    
    [<Koan>]
    member this.AssertTruth() =
        // This should be true 
        Assert.IsTrue(false) 
        
    (* Enlightenment may be more easily achieved with appropriate
       messages. *)
    
    [<Koan>]  
    member this.AssertWithMessage() =
        Assert.IsTrue(false, "This should be true -- Please fix this")