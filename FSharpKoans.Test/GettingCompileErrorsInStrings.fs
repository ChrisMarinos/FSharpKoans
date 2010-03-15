module KoansRunner.Test.GettingCompileErrorsInStrings
open FSharpKoans.Core
open NUnit.Framework

(* I want to get the following to work. Unfortunately, the current version
   of the F# FSharpCodeProvider requires that fsc.exe be in your path. 
   This is too big of a headache to deal with now. If you run this
   from TestDriven.NET or modify your path, it works *)
[<Test>]
let ``The first compile error is returned for bad code`` () =
    let statement1 = "let x = 50"
    let statement2 = "x <- 100"
     
    let error = compileCode [statement1; statement2] 
    
    Assert.AreEqual("This value is not mutable", error)