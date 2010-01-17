namespace FSharpKoans.Core

open System

[<AttributeUsage(AttributeTargets.Method, AllowMultiple = false)>]
type KoanAttribute () =
    inherit Attribute()