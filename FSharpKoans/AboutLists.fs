﻿namespace FSharpKoans
open FSharpKoans.Core
open System.Collections.Generic

//---------------------------------------------------------------
// About Lists
//
// Lists are important building blocks that you'll use frequently
// in F# programming. They are used to group arbitrarily large 
// sequences of values. It's very common to store values in a 
// list and perform operations across each value in the 
// list.
//---------------------------------------------------------------
[<Koan(Sort = 9)>]
module ``about lists`` =

    [<Koan>]
    let CreatingLists() =
        let list = ["apple"; "pear"; "grape"; "peach"]
        
        //Note: The list data type in F# is a singly linked list, 
        //      so indexing elements is O(n). 
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        AssertEquality list.Length __

        (* .NET developers coming from other languages may be surprised
           that F#'s list type is not the same as the base class library's
           List<T>. In other words, the following assertion is true *)

        let dotNetList = new List<string>()
        //you don't need to modify the following line
        AssertInequality (list.GetType()) (dotNetList.GetType())

    [<Koan>]
    let BuildingNewLists() =
        let first = ["grape"; "peach"]
        let second = "pear" :: first
        let third = "apple" :: second

        //Note: "::" is known as "cons"
        
        AssertEquality ["apple"; "pear"; "grape"; "peach"] third
        AssertEquality second __
        AssertEquality first __

        //What happens if you uncomment the following?

        //first.Head <- "apple"
        //first.Tail <- ["peach"; "pear"]

        //THINK ABOUT IT: Can you change the contents of a list once it has been
        //                created?


    [<Koan>]
    let ConcatenatingLists() =
        let first = ["apple"; "pear"; "grape"]
        let second = first @ ["peach"]

        AssertEquality first __
        AssertEquality second __

    (* THINK ABOUT IT: In general, what performs better for building lists, 
       :: or @? Why?
       
       Hint: There is no way to modify "first" in the above example. It's
       immutable. With that in mind, what does the @ function have to do in
       order to append ["peach"] to "first" to create "second"? *)
        
    [<Koan>]
    let CreatingListsWithARange() =
        let list = [0..4]
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        
    [<Koan>]
    let CreatingListsWithComprehensions() =
        let list = [for i in 0..4 do yield i ]
                            
        AssertEquality list __
    
    [<Koan>]
    let ComprehensionsWithConditions() =
        let list = [for i in 0..10 do 
                        if i % 2 = 0 then yield i ]
                            
        AssertEquality list __

    [<Koan>]
    let TransformingListsWithMap() =
        let square x =
            x * x

        let original = [0..5]
        let result = List.map square original

        AssertEquality original __
        AssertEquality result __

    [<Koan>]
    let FilteringListsWithWhere() =
        let isEven x =
            x % 2 = 0

        let original = [0..5]
        let result = List.filter isEven original

        AssertEquality original __
        AssertEquality result __

    [<Koan>]
    let DividingListsWithPartition() =
        let isOdd x =
            not(x % 2 = 0)

        let original = [0..5]
        let result1, result2 = List.partition isOdd original
        
        AssertEquality result1 __
        AssertEquality result2 __

    (* Note: There are many other useful methods in the List module. Check them
       via intellisense in Visual Studio by typing '.' after List, or online at
       http://msdn.microsoft.com/en-us/library/ee353738.aspx *)
