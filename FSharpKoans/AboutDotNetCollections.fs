namespace FSharpKoans
open FSharpKoans.Core
open System.Collections.Generic

//---------------------------------------------------------------
// About .NET Collections
//
// Since F# is bulit for seamless interop with other CLR 
// languages, you can use all of the basic .NET collections types
// you're already familiar with if you're a C# or VB programmer.
//---------------------------------------------------------------
type ``about dot net collections``() =

    [<Koan>]
    member this.CreatingDotNetLists() =
        let fruits = new List<string>()

        fruits.Add("apple")
        fruits.Add("pear")
 
        AssertEquality fruits.[0] __
        AssertEquality fruits.[1] __

    [<Koan>]
    member this.CreatingDotNetDictionaries() =
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        AssertEquality addressBook.["Chris"] __
        AssertEquality addressBook.["SkillsMatter"] __

    [<Koan>]
    member this.YouUseCombinatorsWithDotNetTypes() =
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        let verboseBook = 
            addressBook
            |> Seq.map (fun kvp -> sprintf "Name: %s - City: %s" kvp.Key kvp.Value)
            |> Seq.toArray

        //NOTE: The seq type in F# is an alias for .NET's IEnumerable interface
        //      Like the List and Array module, the Seq module contains functions 
        //      that you can combine to perform operations on types implementing 
        //      seq/IEnumerable.

        AssertEquality verboseBook.[0] __
        AssertEquality verboseBook.[1] __

    [<Koan>]
    member this.SkippingElements() =
        let original = [0..5]
        let result = Seq.skip 2 original
        
        AssertEquality result __

    [<Koan>]
    member this.FindingTheMax() =
        let values = new List<int>()

        values.Add(11)
        values.Add(20)
        values.Add(4)
        values.Add(2)
        values.Add(3)

        let result = Seq.max values
        
        AssertEquality result __
    
    [<Koan>]
    member this.FindingTheMaxUsingACondition() =
        let getNameLength (name:string) =
            name.Length
        
        let names = [| "Harry"; "Lloyd"; "Nicholas"; "Mary"; "Joe"; |]
        let result = Seq.maxBy getNameLength names 
        
        AssertEquality result __