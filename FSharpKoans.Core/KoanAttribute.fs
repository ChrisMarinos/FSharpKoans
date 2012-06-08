namespace FSharpKoans.Core

open System

[<AttributeUsage(AttributeTargets.Class ||| AttributeTargets.Method, AllowMultiple = false)>]
type KoanAttribute () =
    inherit Attribute()
    let mutable sortOrder = 0
    member x.Sort
        with get() = sortOrder
        and set(v) = sortOrder <- v
