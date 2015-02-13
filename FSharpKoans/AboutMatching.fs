namespace FSharpKoans
open NUnit.Framework

module ``Match expressions`` = 
   let [<Test>] ``Basic match expression`` () =
      match 8000 with
      | FILL_ME__IN -> "Insufficient power-level"
      ()

   let [<Test>] ``Match expressions are expressions, not statements`` () =
      let result =
         match 9001 with
         | FILL_ME__IN -> // <-- use a variable pattern here!
            match ___ + 1000 with
            | 10001 -> "Hah! It's a palindromic number!"
            | x -> "Some number."
         | x -> "I should have matched the other expression."
      result |> should equal "Hah! It's a palindromic number!"