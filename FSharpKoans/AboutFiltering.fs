namespace FSharpKoans
open FSharpKoans.Core

module NumberFilterer =

    let someIfEven x =
        if x % 2 = 0 then Some x
        else None

//---------------------------------------------------------------
// Getting Started with Filtering Lists
//
// Lists in F# can be filtered in a number of ways. 
// This koan looks at:
//  - filter
//  - find / tryFind
//  - choose
//  - pick
//---------------------------------------------------------------

[<Koan(Sort = 22)>]
module ``about filtering`` =
    open NumberFilterer

    [<Koan>]
    let FilteringAList() =
        let names = [ "Alice"; "Bob"; "Eve"; ]
                
        // Find all the names starting with "A" using an anonymous function
        let actual_names = 
            names
            |> List.filter (fun name -> name.StartsWith( "A" ))
     
        AssertEquality actual_names [ __ ]

        //Or passing a function to filter
        let startsWithTheLetterB (s: string) =
            s.StartsWith("B")

        let namesBeginningWithB =
            names
            |> List.filter startsWithTheLetterB

        AssertEquality namesBeginningWithB [ __ ]

    [<Koan>]
    let FindingJustOneItem() =
        let names = [ "Alice"; "Bob"; "Eve"; ]
        let expected_name = "Bob"
                
        // find will return just one item, or throws an exception

        let actual_name = 
            names
            |> List.find (fun name -> name = __ )
            
        //??? What would happen if there are 2 Bobs in the List?

        AssertEquality expected_name actual_name

    [<Koan>]
    let FindingJustOneOrZeroItem() =
        let names = [ "Alice"; "Bob"; "Eve"; ]
                
        // tryFind returns an option so you can handle 0 rows returned
        let eve = 
            names
            |> List.tryFind (fun name -> name = "Eve" )
        let zelda = 
            names
            |> List.tryFind (fun name -> name = "Zelda" )
            
        AssertEquality eve.IsSome __
        AssertEquality zelda.IsSome __

    [<Koan>]
    let ChoosingItemsFromAList() =
        let numbers = [ 1; 2; 3; ]
        
        // choose takes a function that transforms the input into an option
        // And filters out the results that are None.
        let evenNumbers =
            numbers
            |> List.choose someIfEven

        AssertEquality evenNumbers  [ __ ]

        //You can also use the "id" function on types of 'a option list 
        //"id" will return just those that are "Some"
        let optionNames = [ None; Some "Alice"; None; ]

        let namesWithValue = 
            optionNames
            |> List.choose id

        //Notice the type of namesWithValue is 'string list', whereas optionNames is 'string option list'
        AssertEquality namesWithValue [ __ ]

    [<Koan>]
    let PickingItemsFromAList() =
        let numbers = [ 5..10 ]
       
        //Pick is similar to choose, but returns the first element, or throws an exception if there are no
        //items that return "Some" (a bit like find does)
        let firstEven =
            numbers
            |> List.pick someIfEven

        AssertEquality firstEven __

        //As with choose, you can also use the "id" function on types of 'a option list 
        //to return just those that are "Some"
        let optionNames = [ None; Some "Alice"; None; Some "Bob"; ]

        let firstNameWithValue = 
            optionNames
            |> List.pick id

        AssertEquality firstNameWithValue  __

        //There is also a tryPick which works like tryFind, returning "None" instead of throwing an exception.
