namespace FSharpKoans
open NUnit.Framework

type Game = 
   { Name : string
     Platform : string
     Score : int option }

module Options = 
   [<Test>]
   let ``An Option might contain a value`` () = 
      let someValue = Some 10
      someValue.IsSome |> should equal __
      someValue.IsNone |> should equal __
      someValue.Value |> should equal __
   
   [<Test>]
   let ``An Option might not contain a value`` () = 
      let noValue = None
      noValue.IsSome |> should equal __
      noValue.IsNone |> should equal __
   
   [<Test>]
   let ``Using Options with pattern-matching`` () = 
      let chronoTrigger = 
         { Name = "Chrono Trigger"
           Platform = "SNES"
           Score = Some 5 }
      
      let halo = 
         { Name = "Halo"
           Platform = "Xbox"
           Score = None }
      
      let translate score = 
         match score with
         | 5 -> "Great"
         | 4 -> "Good"
         | 3 -> "Decent"
         | 2 -> "Bad"
         | 1 -> "Awful"
         | _ -> "Unknown"
      
      let getScore game = 
         match game.Score with
         | Some score -> translate score
         | None -> "Unknown"
      
      getScore chronoTrigger |> should equal __
      getScore halo |> should equal __