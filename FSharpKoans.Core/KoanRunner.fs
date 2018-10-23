namespace FSharpKoans.Core

open System
open System.Reflection

type KoanRunner(containers) =
    let findFailureOrLastResult (values:seq<KoanResult>) =
        let e = values.GetEnumerator()
        let rec helper() =
            let last = e.Current
            if e.MoveNext() then
                match e.Current with
                | Success _ -> helper()
                | Failure _ -> e.Current
            else
                last
        helper()

    let buildKoanResult builderString (current:KoanResult) (next:KoanResult) =
        next
        |> KoanResult.map (sprintf builderString current.Message)

    let getContainerResult (container: Type) =
        let name = container.Name
        let lineOne = sprintf "%s:" name

        container |> KoanContainer.runKoans
        |> Seq.scan (buildKoanResult "%s\n    %s") (Success lineOne)
        |> findFailureOrLastResult

    new () =
        let containers =
            Assembly.GetCallingAssembly().GetTypes()
            |> Array.map (fun t -> t, t.GetCustomAttributes(typeof<KoanAttribute>, true))
            |> Array.filter (not << Seq.isEmpty << snd)
            |> Array.sortBy (fun (t, attrs) -> (attrs.[0] :?> KoanAttribute).Sort)
            |> Array.map fst
        KoanRunner(containers)
        
    member this.ExecuteKoans() =
        let result = 
            containers
            |> Seq.map getContainerResult
            |> Seq.scan (buildKoanResult "%s\n\n%s") (Success "")
            |> findFailureOrLastResult

        match result with
        | Success m -> Success (m.Replace("\n", Environment.NewLine))
        | Failure (m, e) -> Failure (m.Replace("\n", Environment.NewLine), e)
