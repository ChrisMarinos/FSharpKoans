namespace FSharpKoans.Core
open System

//TODO: refactor this filth
type KoanRunner(containers) =
    let combine joinMessages message (next:KoanResult) =
        let message = joinMessages message next.Message
        
        match next with
        | Success _ -> Success(message)
        | Failure (_, ex) -> Failure(message, ex)
        
    let combineUnlessFailed joinMessages state next =
        match state with
        | Success s -> combine joinMessages s next
        | Failure _ -> state
            
    let executeContainer container =
        let name = container.GetType().Name.ToString()
        let lineOne = sprintf "When contemplating %s:" name
        
        let joinLines x y = String.Concat(x, System.Environment.NewLine,
                                          "    ",  y)
        
        container
        |> KoanContainer.runKoans
        |> Seq.fold (combineUnlessFailed joinLines) (Success lineOne)
    
    member this.ExecuteKoans =
        let joinContainers x y = String.Concat(x, System.Environment.NewLine, 
                                                  System.Environment.NewLine, y)
            
        containers
        |> Seq.map executeContainer
        |> Seq.fold (combineUnlessFailed joinContainers) (Success "")
