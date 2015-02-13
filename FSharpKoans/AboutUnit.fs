namespace FSharpKoans
open NUnit.Framework

module Unit = 
   [<Test>]
   let ``Unit is used when there is no return value for a function``() = 
      let sendData data = ()
      //...sending the data to the server...
      sendData "data" |> should equal __ // ... don't overthink this one ^_^
   
   [<Test>]
   let ``Unit is used for functions that just discard their parameter``() = 
      let sayHello() = "hello"
      let result = sayHello()
      result |> should equal __
