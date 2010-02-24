namespace FSharpKoans
open FSharpKoans.Core

type ``about lists``() =

    [<Koan>]
    member this.CreatingLists() =
        let list = ["apple"; "pear"; "grape"; "peach"]
        
        //Note: Lists in F# are linked lists, and indexing elements is O(n). 
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        AssertInequality (list.GetType()) typeof<System.Collections.Generic.List<string>>
        
    [<Koan>]
    member this.BuildingLists() =
        let first = ["grape"; "peach"]
        let second = "pear" :: first
        let third = "apple" :: second
        
        AssertEquality ["apple"; "pear"; "grape"; "peach"] third
        AssertEquality second __
        AssertEquality first __
        
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