namespace FSharpKoans

open NUnit.Framework
open FsUnit

module Binding = 
   [<Test>]
   let ``Basic 'let' binding`` = 
      let x = 50
      x |> should equal __
   
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
      0

   let [<Test;ExpectedException("MatchFailureException")>] ``Constant patterns fail if the sides don't match exactly`` () =
      let "FILL_ME_IN" = __
      0

(*
   let YouCanMakeTypesExplicit() = 
      let (x : int) = 42
      let typeOfX = x.GetType()
      let y : string = "forty two"
      let typeOfY = y.GetType()
      AssertEquality typeOfX typeof<FILL_ME_IN>
      AssertEquality typeOfY typeof<FILL_ME_IN>
*)  