namespace FSharpKoans
open NUnit.Framework

(* **********
IMPORTANT!

Before looking at the tests, take a look at the types defined below.
********** *)

type Subject = // <-- feel free to add your own major subject ^_^
| Philosophy
| Linguistics
| ComputerScience
| Mathematics

type UndergraduateDegree = 
| BSc of Subject * Subject
| BCom of Subject * Subject
| BPharm
| BA of Subject * Subject

type PostgraduateDegree =
| Honours of Subject
| Masters of Subject

type Student = 
| Undergrad of string * UndergraduateDegree
| Postgrad of string * PostgraduateDegree

module ``Discriminated Unions`` = 
   let [<Test>] ``A case isn't the same as a type`` () = 
      let aDegree = BSc (Linguistics, ComputerScience)
      let anotherDegree = BPharm
      let philosopherKing = Masters Philosophy
      
      aDegree |> should be ofExactType<FILL_ME_IN> 
      anotherDegree |> should be ofExactType<FILL_ME_IN> 
      philosopherKing |> should be ofExactType<FILL_ME_IN> 
   
   let [<Test>] ``Creating & pattern-matching a discriminated union`` () = 
      let myDegree = ___
      let randomOpinion =
         match myDegree with
         | BSc (_, ComputerScience) -> "Good choice!"
         | BSc (ComputerScience, _) -> "Nice degree!"
         | BSc _ -> "!!SCIENCE!!"
         | BPharm -> "Meh, it's OK."
         | BCom _ -> "Money, money, money."
         | BA _ -> "A thinker, eh?"
      randomOpinion |> should equal "Money, money, money."
