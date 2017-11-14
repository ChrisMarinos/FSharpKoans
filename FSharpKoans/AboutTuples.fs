namespace FSharpKoans

open Expecto

//---------------------------------------------------------------
// About Tuples
//
// Tuples are used to easily group together values in F#. They're
// another fundamental construct of the language.
//---------------------------------------------------------------

module ``about tuples`` =
  let tests =
    testList "teaching about tuples" [
      testCase "creating tuples" <| fun () ->
        let items = ("apple", "dog")

        AssertEquality items ("apple", __)

      testCase "accessing tuple elements" <| fun () ->
        let items = ("apple", "dog")

        let fruit = fst items
        let animal = snd items

        AssertEquality fruit __
        AssertEquality animal __

      testCase "accessing tuple elements with pattern matching" <| fun () ->
        (* fst and snd are useful in some situations, but they only work with
            tuples containing two elements. It's usually better to use a
            technique called pattern matching to access the values of a tuple.

            Pattern matching works with tuples of any arity, and it allows you to
            simultaneously break apart the tuple while assigning a name to each
            value. Here's an example. *)

        let items = ("apple", "dog", "Mustang")

        let fruit, animal, car = items

        AssertEquality fruit __
        AssertEquality animal __
        AssertEquality car __

      testCase "ignoring values with pattern matching" <| fun () ->
        let items = ("apple", "dog", "Mustang")

        let _, animal, _ = items

        AssertEquality animal __

      (* NOTE:  pattern matching is found in many places
                throughout F#, and we'll revisit it again later *)

      testCase "returning multiple values from a function" <| fun () ->
        let squareAndCube x =
          (x ** 2.0, x ** 3.0)

        let squared, cubed = squareAndCube 3.0

        AssertEquality squared __
        AssertEquality cubed __

    (* THINK ABOUT IT:  Is there really more than one return value?
                        What type does the squareAndCube function
                        return? *)

      testCase "the truth behind multiple return values" <| fun () ->
        let squareAndCube x =
          (x ** 2.0, x ** 3.0)

        let result = squareAndCube 3.0

        AssertEquality result __
    ]