namespace FSharpKoans.Core

open System

type KoanResult = 
    | Success of string
    | Failure of string * Exception
with
    member this.Message =
        match this with
        | Success x -> x
        | Failure (x, _) -> x
