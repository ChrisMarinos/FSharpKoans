namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// Getting Started
//
// The F# Koans are a set of exercises designed to get you familiar 
// with F#. By the time you're done, you'll have a basic 
// understanding of the syntax of F# and learn a little more
// about functional programming in general.
//
// Answering Problems
// 
// This is where the fun begins! Each Koan method contains
// an example designed to teach you a lesson about the F# language. 
// If you execute the program defined in this project, you will get
// a message that the AssertEquality koan below has failed. Your
// job is to fill in the blank (the __ symbol) to make it pass. Once
// you make the change, re-run the program to make sure the koan
// passes, and continue on to the next failing koan.  With each 
// passing koan, you'll learn more about F#, and add another
// weapon to your F# programming arsenal.
//---------------------------------------------------------------
[<Koan(Sort = 1)>]
module ``about asserts`` =

    [<Koan>]
    let AssertExpectation() =
        let expected_value = 1 + 1
        let actual_value = 2 //start by changing this line
     
        AssertEquality expected_value actual_value
 
    //Easy, right? Now try one more

    [<Koan>]
    let FillInValues() =
        AssertEquality (1 + 1) 2
