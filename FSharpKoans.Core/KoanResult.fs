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

[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module KoanResult =
    let map f (x:KoanResult) =
        match x with
        | Success m -> Success <| f m
        | Failure (m, e) -> Failure (f m, e)
