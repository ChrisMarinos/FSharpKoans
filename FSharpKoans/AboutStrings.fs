namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About Strings
//
// Most languages have a set of utilities for manipulating 
// strings. F# is no different.
//---------------------------------------------------------------
type ``about strings``() =

    [<Koan>]
    member this.StringValue() =
        let message = "hello"

        AssertEquality message __

    [<Koan>]
    member this.StringConcatValue() =
        let message = "hello " + "world"

        AssertEquality message __

    [<Koan>]
    member this.FormattingStringValues() =
        let message = sprintf "F# turns it to %d!" 11

        AssertEquality message __

        //NOTE: you can use printf to print to standard output

        (* TRY IT: What happens if you change 11 to be something besides 
                   a number? *)

    [<Koan>]
    member this.FormattingOtherTypes() =
        let message = sprintf "hello %s" "world"

        AssertEquality message __

    [<Koan>]
    member this.FormattingAnything() =
        let message = sprintf "Formatting other types is as easy as: %A" (1, 2, 3)

        AssertEquality message __

    (* NOTE: For all the %formatters that you can use with string formatting 
             see: http://msdn.microsoft.com/en-us/library/ee370560.aspx *)

    [<Koan>]
    member this.CombineMultiline() =
        let message = "super\
                        cali\
                        fragilistic\
                        expiali\
                        docious"

        AssertEquality message __

    [<Koan>]
    member this.Multiline() =
        let message = "This
                        is
                        on
                        five
                        lines"

        AssertEquality
              message __

    [<Koan>]
    member this.ExtractValues() =
        let message = "hello world"

        let first = message.[0]
        let other = message.[4] 

        AssertEquality first __
        AssertEquality other __

    [<Koan>]
    member this.ApplyWhatYouLearned() =
        (* It's time to apply what you've learned so far. Fill in the function below to
           make the asserts pass *)
        let getFunFacts x =
            __

        let funFactsAboutThree = getFunFacts 3
        let funFactsAboutSix = getFunFacts 6

        AssertEquality "3 doubled is 6, and the square of 3 is 9!" funFactsAboutThree 
        AssertEquality "6 doubled is 12, and the square of 6 is 36!" funFactsAboutSix 