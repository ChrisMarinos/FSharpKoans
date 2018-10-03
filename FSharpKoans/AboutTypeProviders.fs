namespace FSharpKoans
open FSharpKoans.Core


//---------------------------------------------------------------
// Getting Started with F# Type Providers
//
// F# Type Providers make things like processing data from a 
// variety of providers easily done in a typed fashion.
//
// 
// For a more thorough introduction to TypeProviders
// https://docs.microsoft.com/en-us/dotnet/fsharp/tutorials/type-providers/
//---------------------------------------------------------------

[<Koan(Sort = 23)>]
module ``about type providers`` =
    open FSharp.Data
    open System.IO

    type Simple = CsvProvider<"data/Simple.csv">

    let getContent =
        use file = File.OpenRead("data/Simple.csv")
        Simple.Load(file).Rows


    [<Koan>]
    let CountingLinesInACSV() =
        // you can count items with a sequence operation over the data
        let countOfItems = 
            getContent
            |> Seq.length

        AssertEquality countOfItems __


    [<Koan>]
    let GetCsvContentAndPerformAProjection() = 
        // you can do other transformations like projects in a typed fashion
        let popularities = 
            getContent
            |> Seq.map (fun x -> x.Popularity) 
            |> Seq.sort
            |> Seq.toArray 
            
        let sumOfPopularities = popularities |> Seq.sum

        AssertEquality sumOfPopularities __

        AssertEquality popularities __