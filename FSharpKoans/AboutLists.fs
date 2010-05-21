namespace FSharpKoans
open FSharpKoans.Core
open System.Collections.Generic

type ``about lists``() =

    [<Koan>]
    member this.CreatingLists() =
        let list = ["apple"; "pear"; "grape"; "peach"]
        
        //Note: Lists in F# are linked lists, and indexing elements is O(n). 
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        AssertEquality list.Length __

        (* .NET developers coming from other languages may be surprised
           that F#'s list type is not the same as the base class library's
           List<T>. In other words, the following assertion is true *)

        let dotNetList = new List<string>()
        AssertInequality (list.GetType()) (dotNetList.GetType())

    [<Koan>]
    member this.ListImmutability() =
        let statement1 = "let list = [1; 2; 4]"
        let statement2 = "let newTail = [3; 5]"
        let statement3 = "list.Tail <- newTail"
        
        let error = compileCode [statement1; statement2; statement3]

        AssertEquality error __

    [<Koan>]
    member this.MoreListImmutability() =
        let statement1 = "let list = [1; 2; 4]"
        let statement2 = "list.Head <- 0"
        
        let error = compileCode [statement1; statement2]

        AssertEquality error __

    (* THINK ABOUT IT: If you can't modify the head or tail of the list, 
       can you change the contents of F# lists? *)

    [<Koan>]
    member this.BuildingListsWithCons() =
        let first = ["grape"; "peach"]
        let second = "pear" :: first
        let third = "apple" :: second

        //Note: "::" is known as "cons"
        
        AssertEquality ["apple"; "pear"; "grape"; "peach"] third
        AssertEquality second __
        AssertEquality first __

    [<Koan>]
    member this.ConcatenatingLists() =
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
    member this.CreatingListsWithARange() =
        let list = [0..4]
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        
    [<Koan>]
    member this.CreatingListsWithComprehensions() =
        let list = [for i in 0..4 do yield i ]
                            
        AssertEquality list __
    
    [<Koan>]
    member this.ComprehensionsWithConditions() =
        let list = [for i in 0..10 do 
                        if i % 2 = 0 then yield i ]
                            
        AssertEquality list __

    [<Koan>]
    member this.TransofmingListsWithMap() =
        let square x =
            x * x

        let original = [0..5]
        let result = List.map square original

        AssertEquality original __
        AssertEquality result __

    [<Koan>]
    member this.FilteringListsWithWhere() =
        let isEven x =
            x % 2 = 0

        let original = [0..5]
        let result = List.filter isEven original

        AssertEquality original __
        AssertEquality result __

    [<Koan>]
    member this.DividingListsWithPartition() =
        let isOdd x =
            not(x % 2 = 0)

        let original = [0..5]
        let result1, result2 = List.partition isOdd original
        
        AssertEquality result1 __
        AssertEquality result2 __

    (* Note: There are many other useful methods in the List module. Check them
       via intellisense in Visual Studio by typing '.' after List, or online at
       http://msdn.microsoft.com/en-us/library/ee353738.aspx *)