namespace FSharpKoans

open Expecto

//---------------------------------------------------------------
// About Classes
//
// As a full fledged Object Oriented language, F# allows you to
// create traditional classes to contain data and methods.
//---------------------------------------------------------------

type Zombie() =
    member this.FavoriteFood = "brains"

    member this.Eat food =
        match food with
        | "brains" -> "mmmmmmmmmmmmmmm"
        | _ -> "grrrrrrrr"

type Person(name:string) =
    member this.Speak() =
        "Hi my name is " + name

type Zombie2() =
    let favoriteFood = "brains"

    member this.Eat food =
        if food = favoriteFood then "mmmmmmmmmmmmmmm" else "grrrrrrrr"

type Person2(name:string) =
    let mutable internalName = name

    member this.Name
        with get() = internalName
        and set(value) = internalName <- value

    member this.Speak() =
        "Hi my name is " + this.Name


module ``about classes`` =
  let tests =
    testListRev "teaching about classes" [
      testCase "classes can have properties" <| fun () ->
        let zombie = new Zombie()

        AssertEquality zombie.FavoriteFood __

      testCase "classes can have methods" <| fun () ->
        let zombie = new Zombie()

        let result = zombie.Eat "brains"
        AssertEquality result __

      testCase "classes can have constructors" <| fun () ->
        let person = new Person("Shaun")

        let result = person.Speak()
        AssertEquality result __

      testCase "classes can have let bindings inside them" <| fun () ->
        let zombie = new Zombie2()

        let result = zombie.Eat "chicken"
        AssertEquality result __

        (* TRY IT:  Can you access the let bound value Zombie2.favoriteFood
                    outside of the class definition? *)

      testCase "classes can have read/write properties" <| fun () ->
        let person = new Person2("Shaun")

        let firstPhrase = person.Speak()
        AssertEquality firstPhrase __

        person.Name <- "Shaun of the Dead"
        let secondPhrase = person.Speak()
        AssertEquality secondPhrase __
    ]
