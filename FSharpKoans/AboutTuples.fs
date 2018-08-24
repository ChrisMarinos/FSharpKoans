namespace FSharpKoans
open FSharpKoans.Core

//---------------------------------------------------------------
// About Tuples
//
// Tuples are used to easily group together values in F#. They're 
// another fundamental construct of the language.
//---------------------------------------------------------------
[<Koan(Sort = 6)>]
module ``about tuples`` =
    
    [<Koan>]
    let CreatingTuples() =
        let items = ("apple", "dog")
        
        AssertEquality items ("apple", "dog")
        
    [<Koan>]
    let AccessingTupleElements() =
        let items = ("apple", "dog")
        
        let fruit = fst items
        let animal = snd items
        
        AssertEquality fruit "apple"
        AssertEquality animal "dog"

    [<Koan>]
    let AccessingTupleElementsWithPatternMatching() =

        (* fst and snd are useful in some situations, but they only work with
           tuples containing two elements. It's usually better to use a 
           technique called pattern matching to access the values of a tuple. 
           
           Pattern matching works with tuples of any arity, and it allows you to 
           simultaneously break apart the tuple while assigning a name to each 
           value. Here's an example. *)
        
        let items = ("apple", "dog", "Mustang")
        
        let fruit, animal, car = items
        
        AssertEquality fruit "apple"
        AssertEquality animal "dog"
        AssertEquality car "Mustang"
        
    [<Koan>]
    let IgnoringValuesWithPatternMatching() =
        let items = ("apple", "dog", "Mustang")
        
        let _, animal, _ = items
        
        AssertEquality animal "dog"
    
    (* NOTE: pattern matching is found in many places
             throughout F#, and we'll revisit it again later *)
        
    [<Koan>]
    let ReturningMultipleValuesFromAFunction() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)
        
        let squared, cubed = squareAndCube 3.0
        
        
        AssertEquality squared 9.0
        AssertEquality cubed 27.0
    
    (* THINK ABOUT IT: Is there really more than one return value?
                       What type does the squareAndCube function
                       return? *)
    
    [<Koan>]
    let TheTruthBehindMultipleReturnValues() =
        let squareAndCube x =
            (x ** 2.0, x ** 3.0)
            
        let result = squareAndCube 3.0
       
        AssertEquality result (9.0, 27.0)
