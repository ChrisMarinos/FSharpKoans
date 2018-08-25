namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About Strings
//
// Most languages have a set of utilities for manipulating 
// strings. F# is no different.
//---------------------------------------------------------------
[<Koan(Sort = 7)>]
module ``about strings`` =

    [<Koan>]
    let StringValue() =
        let message = "hello"

        AssertEquality message "hello"

    [<Koan>]
    let StringConcatValue() =
        let message = "hello " + "world"

        AssertEquality message "hello world"

    [<Koan>]
    let FormattingStringValues() =
        let message = sprintf "F# turns it to %d!" 11

        AssertEquality message "F# turns it to 11!"

        //NOTE: you can use printf to print to standard output

        (* TRY IT: What happens if you change 11 to be something besides 
                   a number? *)

    [<Koan>]
    let FormattingOtherTypes() =
        let message = sprintf "hello %s" "world"

        AssertEquality message "hello world"

    [<Koan>]
    let FormattingAnything() =
        let message = sprintf "Formatting other types is as easy as: %A" (1, 2, 3)

        AssertEquality message "Formatting other types is as easy as: (1, 2, 3)"

    (* NOTE: For all the %formatters that you can use with string formatting 
             see: http://msdn.microsoft.com/en-us/library/ee370560.aspx *)

    [<Koan>]
    let CombineMultiline() =
        let message = "super\
                        cali\
                        fragilistic\
                        expiali\
                        docious"

        AssertEquality message "supercalifragilisticexpialidocious"

    [<Koan>]
    let Multiline() =
        let message = "This
                        is
                        on
                        five
                        lines"

        AssertEquality
              message "This
                        is
                        on
                        five
                        lines"

    [<Koan>]
    let ExtractValues() =
        let message = "hello world"

        let first = message.[0]
        let other = message.[4] 

 (* A single character is denoted using single quotes, example: 'c',
        not double quotes as you would use for a string *)
           
        AssertEquality first 'h'
        AssertEquality other 'o'

    [<Koan>]
    let ApplyWhatYouLearned() =
        (* It's time to apply what you've learned so far. Fill in the function below to
           make the asserts pass *)
        let getFunFacts x =
            let xD = x * 2
            let xT = x * 3
            (xD, xT)

        let funFactsAboutNum x =
            let doubled, tripled = getFunFacts x
            sprintf "%d doubled is %d, and %d tripled is %d!" x doubled x tripled

        let funFactsAboutThree = funFactsAboutNum 3
        let funFactsAboutSix = funFactsAboutNum 6

        AssertEquality "3 doubled is 6, and 3 tripled is 9!" funFactsAboutThree
        AssertEquality "6 doubled is 12, and 6 tripled is 18!" funFactsAboutSix 
