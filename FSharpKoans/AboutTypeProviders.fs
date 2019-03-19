namespace FSharpKoans
open FSharpKoans.Core


//---------------------------------------------------------------
// Getting Started with F# Type Providers
//
// F# Type Providers make things like processing data from a 
// variety of providers easily done in a typed fashion.
//
// Type Providers Available
//  * DbmlFile - http://msdn.microsoft.com/en-us/library/hh362326.aspx
//  * EdmxFile - http://msdn.microsoft.com/en-us/library/hh362313.aspx
//  * ODataService - http://msdn.microsoft.com/en-us/library/hh362325.aspx
//  * SqlDataConnection - http://msdn.microsoft.com/en-us/library/hh362320.aspx
//  * SqlEntityConnection - http://msdn.microsoft.com/en-us/library/hh362322.aspx
//  * WsdlService - http://msdn.microsoft.com/en-us/library/hh362328.aspx
//  * CSV - http://fsharp.github.io/FSharp.Data/library/CsvProvider.html
//  * HTML - http://fsharp.github.io/FSharp.Data/library/HtmlProvider.html
//  * JSON - http://fsharp.github.io/FSharp.Data/library/JsonProvider.html
//  * XML - http://fsharp.github.io/FSharp.Data/library/XmlProvider.html
//  * WorldBank - http://fsharp.github.io/FSharp.Data/library/WorldBank.html
// 
// For a more thorough introduction to TypeProviders
// https://docs.microsoft.com/en-us/dotnet/fsharp/tutorials/type-providers/
//---------------------------------------------------------------

[<Koan(Sort = 23)>]
module ``about type providers`` =
    open FSharp.Data
    open System.IO

    type Simple = CsvProvider<"data/Stocks.csv">

    let getCsvContent =
        use file = File.OpenRead("data/Stocks.csv")
        Simple.Load(file).Rows
        |> Seq.toList  // this is kind of a cheat to get around the fact that the stream needs to be closed

    [<Koan>]
    let CountingLinesInACSV() =
        // you can count items with a sequence operation over the data
        let countOfItems = 
            getCsvContent
            |> Seq.length

        AssertEquality countOfItems __ // fix this


    [<Koan>]
    let GetCsvContentAndPerformAProjection() = 
        // try transformations like projections in a typed fashion with a simple predicate 
        // typed to the column name
        let avgOpen = 
            getCsvContent
            // What column makes this work?
            |> Seq.averageBy ( fun x -> x.Open ) // write this projection

        AssertEquality 32.185217391304347826086956522m avgOpen

    [<Koan>]
    let RenameAColumnAndSeeACompileTimeBreak() =
        // one of the benefits of type providers is that when the source changes, the compiler will tell you!
        
        let avgAdjClose = 
            getCsvContent
            // Rename the CSV column "Adj Close" to "AdjustedClose" in data/Stocks.csv
            // compile the code to see the code on the next line break
            |> Seq.averageBy (fun x -> x.``Adj Close`` )

        AssertEquality 32.175217391304347826086956522m avgAdjClose


    type NugetStats = HtmlProvider<"https://www.nuget.org/packages/FSharp.Data">

    // helper function to analyze version numbers from Nuget
    let getMinorVersion (v:string) =  
        System.Text.RegularExpressions.Regex(@"\d.\d").Match(v).Value

    let getNugetStats =
        NugetStats().Tables.``Version History``.Rows
    
    [<Koan>]
    let TypeProvidersExistForWebRequestsAsWell() =
        // group by minor version and calculate download count
        
        let stats = 
          getNugetStats
          |> Seq.groupBy (fun r -> 
              getMinorVersion r.Version)
          |> Seq.map (fun (k, xs) -> 
            k, xs |> Seq.sumBy (fun x -> x.Downloads))
          
        AssertEquality __ __