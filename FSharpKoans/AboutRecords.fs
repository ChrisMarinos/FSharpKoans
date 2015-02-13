namespace FSharpKoans
open NUnit.Framework

(* **********
IMPORTANT!

Before you skip over to the tests, take a look at the record definitions under this comment.
********** *)

type Pokemon = 
   { Name : string
     Attack : int
     Defense : int }

type Book = 
   { Title : string
     Author : string
     Year : int }

// and now, the tests:
module Records =
   let [<Test>] ``The type of a record is inferred`` () =
      let myRecord = { Name="Pikachu"; Attack=55; Defense=40 }
      let myOtherRecord =
         {
            Title="Discipline and Punish"
            Author="Michel Foucault"
            Year=1975
         }
      myRecord |> should be ofExactType<FILL_ME_IN>
      myOtherRecord |> should be ofExactType<FILL_ME_IN>

   let [<Test>] ``Creating records`` () =
      let myRecord = __
      myRecord |> should equal { Title="Steelheart"; Author="Brandon Sanderson"; Year=2013 }

   let [<Test>] ``Decomposing with a record pattern`` () =
      let book = { Title="Dune"; Author="Frank Herbert"; Year=1965 }
      let { Author=x; Year=y } = book
      x |> should equal __
      y |> should equal __

   let [<Test>] ``Decomposing in a match expression`` () =
      let result =
         match { Name="Raichu"; Attack=90; Defense=55 } with
         | { Name="Pikachu"; Attack=a } -> a/2
         | { Name="Raichu"; Attack=a } -> a/3
         | { Attack=blah; Defense=lol } -> (blah + lol) / 2
      result |> should equal __

   let [<Test>] ``Accessing record members using dot syntax`` () =
      let book = { Title="Tigana"; Author="Guy Gavriel Kay"; Year=1990 }
      let k = __
      let j = __
      k |> should equal "Tigana"
      j |> should equal 1990

   let [<Test>] ``Creating records based on other records`` () =
      let first = { Title="A Game of Thrones"; Author="George R. R. Martin"; Year=1996 }
      let second = { first with Title="A Clash of Kings"; Year=first.Year+2 } // <-- Pssst - see what I did here?
      let third = { second with Title="A Storm of Swords"; Year=2000 }
      let {Year=y0}, {Year=y1}, {Year=y2} = first, second, third
      y0 |> should equal __
      y1 |> should equal __
      y2 |> should equal __
