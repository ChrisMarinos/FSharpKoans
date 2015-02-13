namespace FSharpKoans
open NUnit.Framework

module Tuples = 
   let [<Test>] ``Creating tuples`` () = 
      let items = "apple", "dog"
      items |> should equal ("apple", __)

   let [<Test>] ``Elements of a tuple can be different types`` () =
      let stuff = "Rivet", false, 22.5
      stuff |> should equal ( __ )

   let [<Test>] ``Decompose a tuple using tuple pattern`` () =
      let aida = 2020, "cranberry", false, "wait, what?"
      let a, b, c, d = aida
      a |> should equal __
      b |> should equal __
      c |> should equal __
      d |> should equal __

   let [<Test>] ``Using a tuple in a match expression`` () =
      let result =
         match "Teresa", "pasta" with
         | name, "veggies" -> name + " likes vegetables"
         | name, "fish" -> name + " likes seafood"
         | name, "chicken" -> name + " crows about their food"
         | FILL__ME_IN, FILL__ME_IN -> __ + " loves to eat " + __
      result |> should equal "Teresa loves to eat pasta"   
   
   let [<Test>] ``Using the wildcard pattern`` () = 
      let name, _, _, weapon_name = "Shinji", 9103, true, "Unit 01"
      name |> should equal __
      weapon_name |> should equal __