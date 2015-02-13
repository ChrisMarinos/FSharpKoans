namespace FSharpKoans

open NUnit.Framework

module Binding = 
   [<Test>]
   let ``Basic 'let' binding`` = 
      let x = 50
      x |> should equal __

   let ``Nest your 'let' statements as deeply as you'd like`` =
      let a =
         let b =
            let c =
               let d = 63
               d
            c
         b + 7
      a |> should equal ___
   
   [<Test>]
   let ``The type of symbols in variable patterns are inferred``() = 
      let x = 50
      let y = "a string"
      let z = -4.23
      let a = false
      let b = 't'
      x |> should be ofExactType<int>
      y |> should be ofExactType<FILL_ME_IN>
      z |> should be ofExactType<FILL_ME_IN>
      a |> should be ofExactType<FILL_ME_IN>
      b |> should be ofExactType<FILL_ME_IN>
   
   let [<Test>] ``Constant patterns succeed if both sides match`` () =
      let 900 = ___
      let "Can't win all the time" = __
      ()

   let [<Test;ExpectedException("MatchFailureException")>] ``Constant patterns fail if the sides don't match exactly`` () =
      let "FILL_ME_IN" = __
      ()