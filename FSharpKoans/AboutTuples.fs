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
    koans "about tuples" [
      koan "creating tuples" {
        let items = ("apple", "dog")

        AssertEquality items ("apple", __)
      }

      koan "accessing tuple elements" {
        let items = ("apple", "dog")

        let fruit = fst items
        let animal = snd items

        AssertEquality fruit __
        AssertEquality animal __
      }

      koan "accessing tuple elements with pattern matching" {
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
      }

      koan "ignoring values with pattern matching" {
        let items = ("apple", "dog", "Mustang")

        let _, animal, _ = items

        AssertEquality animal __

      (* NOTE:  pattern matching is found in many places
                throughout F#, and we'll revisit it again later *)
      }

      koan "returning multiple values from a function" {
        let squareAndCube x =
          (x ** 2.0, x ** 3.0)

        let squared, cubed = squareAndCube 3.0

        AssertEquality squared __
        AssertEquality cubed __

        (* THINK ABOUT IT:  Is there really more than one return value?
                            What type does the squareAndCube function
                            return? *)
      }

      koan "the truth behind multiple return values" {
        let squareAndCube x =
          (x ** 2.0, x ** 3.0)

        let result = squareAndCube 3.0

        AssertEquality result __
      }
    ]