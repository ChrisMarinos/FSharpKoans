namespace FSharpKoans
open NUnit.Framework
open FsUnit

//---------------------------------------------------------------
// About Branching
//
// Branching is used to tell a program to conditionally perform
// an operation. It's another fundamental part of F#.
//---------------------------------------------------------------
module ``Match expressions`` = 
   let [<Test>] ``Basic match expression`` () =
      match 8000 with
      | FILL_ME__IN -> "Insufficient power-level"

   let [<Test>] ``Match expressions are expressions, not statements`` () =
      let result =
         match 9001 with
         | FILL_ME__IN -> // <-- use a variable pattern here!
            match ___ + 1000 with
            | 10001 -> "Hah! It's a palindromic number!"
            | x -> "Some number."
         | x -> "I should have matched the other expression."
      result |> should equal "Hah! It's a palindromic number!"

(*   
   [<Test>]
   let UsingTuplesWithIfStatementsQuicklyBecomesClumsy() = 
      let getDinner x = 
         let name, foodChoice = x
         if foodChoice = "veggies" || foodChoice = "fish" || foodChoice = "chicken" then 
            sprintf "%s doesn't want red meat" name
         else sprintf "%s wants 'em some %s" name foodChoice
      
      let person1 = ("Chris", "steak")
      let person2 = ("Dave", "veggies")
      AssertEquality (getDinner person1) __
      AssertEquality (getDinner person2) __
*)

(*   
   [<Test>]
   let PatternMatchingIsNicer() = 
      let getDinner x = 
         match x with
         | (name, "veggies") | (name, "fish") | (name, "chicken") -> sprintf "%s doesn't want red meat" name
         | (name, foodChoice) -> sprintf "%s wants 'em some %s" name foodChoice
      
      let person1 = ("Bob", "fish")
      let person2 = ("Sally", "Burger")
      AssertEquality (getDinner person1) __
      AssertEquality (getDinner person2) __
*)