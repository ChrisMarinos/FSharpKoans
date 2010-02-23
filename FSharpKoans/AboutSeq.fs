namespace FSharpKoans
open FSharpKoans.Core

type ``about seq``() =
    
    let Square x =
        x * x
    
    [<Koan>]
    member this.MapTransformsValuesInASequence()=
        let numbers = [0;1;2;3;4;5]
        
        let result = 
            numbers
            |> Seq.map Square
        
        AssertEquality result __