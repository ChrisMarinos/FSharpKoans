[<AutoOpenAttribute>]
module FSharpKoans.Core.Helpers
open System.CodeDom
open Microsoft.FSharp.Compiler.CodeDom
open NUnit.Framework

let __ = "FILL ME IN"

let AssertWithMessage x message = Assert.IsTrue(x, message)

let AssertEquality (x:'a) (y:'b) = Assert.AreEqual(x,y)   

let Assert x = Assert.IsTrue(x)


let compileCode statements =
    let code = 
        statements
        |> String.concat System.Environment.NewLine
    
    let finalCode = "module tmp" + System.Environment.NewLine + code
    
    use provider = new FSharpCodeProvider()
    let parameters = new Compiler.CompilerParameters()
    parameters.GenerateInMemory <- true
    
    let results = provider.CompileAssemblyFromSource(parameters, [|finalCode|])
    
    if results.Errors.HasErrors then
        results.Errors.[0].ErrorText
    else
        ""