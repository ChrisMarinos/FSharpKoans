namespace FSharpKoans
open Expecto

//---------------------------------------------------------------
// About Functions
//
// Now that you've seen how to bind a name to a value with let,
// you'll learn to use the let keyword to create functions.
//---------------------------------------------------------------
module ``about functions`` =
  let tests =
    testList "learning about functions" [
      (*  By default, F# is whitespace sensitive.
          For functions, this means that the last
          line of a function is its return value,
          and the body of a function is denoted
          by indentation.  *)
      testCase "creating functions with let" <| fun () ->
        let add x y =
          x + y

        let result1 = add 2 2
        let result2 = add 5 2

        AssertEquality result1 __
        AssertEquality result2 __

      testCase "nesting functions" <| fun () ->
        let quadruple x =
            let double x =
                x * 2

            double(double(x))

        let result = quadruple 4
        AssertEquality result __

      testCase "adding type annotations" <| fun () ->
        (*  Sometimes you need to help F#'s type inference system out with an
            explicit type annotation *)

        let sayItLikeAnAuctioneer (text:string) =
            text.Replace(" ", "")

        let auctioneered = sayItLikeAnAuctioneer "going once going twice sold to the lady in red"
        AssertEquality auctioneered __

        //TRY IT: What happens if you remove the type annotation on text?

      testCase "variables in the parent scope can be accessed" <| fun () ->
        let suffix = "!!!"

        let caffeinate (text:string) =
            let exclaimed = text.Trim() + suffix
            let yelled = exclaimed.ToUpper()
            yelled

        let caffeinatedReply = caffeinate "hello there"

        AssertEquality caffeinatedReply __

        (* NOTE:  Accessing the suffix variable in the nested caffeinate function
                  is known as a closure.

                  See http://en.wikipedia.org/wiki/Closure_(computer_science)
                  for more about about closure. *)
  ]
