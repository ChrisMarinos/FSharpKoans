namespace FSharpKoans

open NUnit.Framework

(* **********
IMPORTANT!

Before you skip over to the tests, take a look at the type definitions under this comment.
********** *)

type Pokemon = 
   {
      Name : string
      Attack : int
      Defense : int
   }

type Book = { Title : string ; Author: string; Year : int }

// and now, the tests:

module Records = 
   let RecordsHaveProperties() = 
      let mario = 
         { Name = "Mario"
           Occupation = "Plumber" }
      AssertEquality mario.Name __
      AssertEquality mario.Occupation __
   
   [<Test>]
   let CreatingFromAnExistingRecord() = 
      let mario = 
         { Name = "Mario"
           Occupation = "Plumber" }
      
      let luigi = { mario with Name = "Luigi" }
      AssertEquality mario.Name __
      AssertEquality mario.Occupation __
      AssertEquality luigi.Name __
      AssertEquality luigi.Occupation __
   
   [<Test>]
   let ComparingRecords() = 
      let greenKoopa = 
         { Name = "Koopa"
           Occupation = "Soldier" }
      
      let bowser = 
         { Name = "Bowser"
           Occupation = "Kidnapper" }
      
      let redKoopa = 
         { Name = "Koopa"
           Occupation = "Soldier" }
      
      let koopaComparison = 
         if greenKoopa = redKoopa then "all the koopas are pretty much the same"
         else "maybe one can fly"
      
      let bowserComparison = 
         if bowser = greenKoopa then "the king is a pawn"
         else "he is still kind of a koopa"
      
      AssertEquality koopaComparison __
      AssertEquality bowserComparison __
   
   [<Test>]
   let YouCanPatternMatchAgainstRecords() = 
      let mario = 
         { Name = "Mario"
           Occupation = "Plumber" }
      
      let luigi = 
         { Name = "Luigi"
           Occupation = "Plumber" }
      
      let bowser = 
         { Name = "Bowser"
           Occupation = "Kidnapper" }
      
      let determineSide character = 
         match character with
         | { Occupation = "Plumber" } -> "good guy"
         | _ -> "bad guy"
      
      AssertEquality (determineSide mario) __
      AssertEquality (determineSide luigi) __
      AssertEquality (determineSide bowser) __
