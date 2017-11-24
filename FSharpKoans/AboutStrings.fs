namespace FSharpKoans

open Expecto

//---------------------------------------------------------------
// About Strings
//
// Most languages have a set of utilities for manipulating
// strings. F# is no different.
//---------------------------------------------------------------

module ``about strings`` =
  let tests =
    koans "about strings" [
      koan "string value" {
        let message = "hello"

        AssertEquality message __
      }

      koan "string concat value" {
        let message = "hello " + "world"

        AssertEquality message __
      }

      koan "formatting string values" {
        let message = sprintf "F# turns it to %d!" 11

        AssertEquality message __

        //NOTE: you can use printf to print to standard output
        (* TRY IT:  What happens if you change 11 to be something besides
                    a number? *)
      }

      koan "formatting other types" {
        let message = sprintf "hello %s" "world"

        AssertEquality message __
      }

      koan "formatting anything" {
        let message = sprintf "Formatting other types is as easy as: %A" (1, 2, 3)

        AssertEquality message __

        (* NOTE:  For all the %formatters that you can use with string formatting
                  see: http://msdn.microsoft.com/en-us/library/ee370560.aspx *)
      }

      koan "combine multiline" {
        let message = "super\
                        cali\
                        fragilistic\
                        expiali\
                        docious"

        AssertEquality message __
      }

      koan "multiline" {
        let message = "This
                        is
                        on
                        five
                        lines"

        AssertEquality message __
      }

      koan "extract values" {
        let message = "hello world"

        let first = message.[0]
        let other = message.[4]

        (*  A single character is denoted using single quotes, example: 'c',
            not double quotes as you would use for a string *)

        AssertEquality first __
        AssertEquality other __
      }

      koan "apply what you've learned" {
        (*  It's time to apply what you've learned so far. Fill in the function below to
            make the asserts pass *)
        let getFunFacts x =
            __

        let funFactsAboutThree = getFunFacts 3
        let funFactsAboutSix = getFunFacts 6

        AssertEquality "3 doubled is 6, and 3 tripled is 9!" funFactsAboutThree
        AssertEquality "6 doubled is 12, and 6 tripled is 18!" funFactsAboutSix
      }
    ]