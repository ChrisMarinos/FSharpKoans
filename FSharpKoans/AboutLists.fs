namespace FSharpKoans
open FSharpKoans.Core

type ``about lists``() =

    [<Koan>]
    member this.CreatingLists() =
        let list = [1;2;3;4]
        
        (* Note: Lists in F# are linked lists, so indexing elements is O(n). 
                 If you're coming from another .NET language, lists in F# 
                 are not System.Collections.Generic.List! *)
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        
    [<Koan>]
    member this.BuildingLists() =
        let first = [3; 4]
        let second = 2 :: first
        let third = 1 :: second
        
        AssertEquality [1; 2; 3; 4] third
        AssertEquality second __
        AssertEquality first __
        
    [<Koan>]
    member this.CreatingListsWithARange() =
        let list = [0..4]
        
        AssertEquality list.Head __
        AssertEquality list.Tail __
        
    [<Koan>]
    member this.CreatingListsWithComprehensions() =
        let list = [for i in 0..10 do
                        if i % 2 = 0 then
                            yield i ]
                            
        AssertEquality list.Head __
        AssertEquality list.Tail __