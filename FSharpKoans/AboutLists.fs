namespace FSharpKoans

open NUnit.Framework

module Lists = 
   let [<Test>] ``Creating a list (Syntax 1)`` () = 
      let myList = [ __; __; __; __ ]
      myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
   
   let [<Test>] ``Creating a list (Syntax 2)`` () =
      let myList = __::__::__::__::[]
      let myOtherList = __::__::__::[ __ ]
      let myLastList = __::__::____
      myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
      myOtherList |> should equal [ "orange"; "lemon"; "princess"; "queen" ]
      myLastList |> should equal [ "naartjie"; "raisin"; "apple"; "grape"; "pear"; "biscuit" ]

   let [<Test>] ``Creating a list (via concatenation)`` () =
      let a = [902; 10]
      let b = [3; 13; 37]
      let result = ____ @ ____
      result |> should equal [902; 10; 3; 13; 37]

   let [<Test>] ``Cons does not modify an existing list`` () = 
      let first = [ "grape"; "peach" ]
      let second = "pear" :: first
      let third = "apple" :: second
      third |> should equal ["apple"; "pear"; "grape"; "peach"]
      second |> should equal ____
      first |> should equal ____