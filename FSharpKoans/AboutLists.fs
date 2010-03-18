namespace FSharpKoans
open FSharpKoans.Core

type ``about lists``() =

    [<Koan>]
    member this.CreatingLists() =
        let list = ["apple"; "pear"; "grape"; "peach"]
        
        //Note: Lists in F# are linked lists, and indexing elements is O(n). 
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        AssertEquality list.Length __

        (* .NET developers coming from other languages may be surprised
          that the following assertion is true. Note that F#'s built in 
          list type is not the same as the base class library's List<T> *)
        AssertInequality (list.GetType()) typeof<System.Collections.Generic.List<string>>
        
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

    (* THINK ABOUT IT:
       In general, what performs better for 
       building lists, :: or @? Why?
       
       Hint:
       There is no way to modify "first" in
       the above example. It's immutable.
       With that in mind, how can ["peach"] be
       appended to "first" to create "second"? *)
        
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