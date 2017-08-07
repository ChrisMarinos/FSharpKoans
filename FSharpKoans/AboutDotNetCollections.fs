namespace FSharpKoans

open Expecto
open System.Collections.Generic

//---------------------------------------------------------------
// About .NET Collections
//
// Since F# is built for seamless interop with other CLR
// languages, you can use all of the basic .NET collections types
// you're already familiar with if you're a C# or VB programmer.
//---------------------------------------------------------------

module ``about dot net collections`` =
  let tests =
    koans "about .Net collections" [
      koan "creating .Net lists(Resizeable Arrays)" {
        (*  NOTE: this is not the F# List, because we've overriden the type List by opening
            the `System.Collections.Generic` namespace above *)
        let fruits = new List<string>()

        fruits.Add("apple")
        fruits.Add("pear")

        AssertEquality fruits.[0] __
        AssertEquality fruits.[1] __
      }

      koan "creating .Net dictionaries" {
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        AssertEquality addressBook.["Chris"] __
        AssertEquality addressBook.["SkillsMatter"] __
      }

      koan "you use combinators with .Net types" {
        let addressBook = new Dictionary<string, string>()

        addressBook.["Chris"] <- "Ann Arbor"
        addressBook.["SkillsMatter"] <- "London"

        let verboseBook =
            addressBook
            |> Seq.map (fun kvp -> sprintf "Name: %s - City: %s" kvp.Key kvp.Value)
            |> Seq.toArray

        (* NOTE:  The seq type in F# is an alias for .NET's IEnumerable interface.
                  Like the List and Array module, the Seq module contains functions
                  that you can combine to perform operations on types implementing
                  seq/IEnumerable. *)

        AssertEquality verboseBook.[0] __
        AssertEquality verboseBook.[1] __
      }

      koan "skipping elements" {
        let original = [0..5]
        let result = Seq.skip 2 original

        AssertEquality result __
      }

      koan "finding the max" {
        let values = new List<int>()

        values.Add(11)
        values.Add(20)
        values.Add(4)
        values.Add(2)
        values.Add(3)

        let result = Seq.max values

        AssertEquality result __
      }

      koan "finding the max using a condition" {
        let getNameLength (name:string) =
          name.Length

        let names = [| "Harry"; "Lloyd"; "Nicholas"; "Mary"; "Joe"; |]
        let result = Seq.maxBy getNameLength names

        AssertEquality result __
      }
    ]
