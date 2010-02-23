namespace FSharpKoans
open FSharpKoans.Core

type ``about branching``() =
    
    [<Koan>]
    member this.BasicBranching() =
        let isEven x =
            if x % 2 = 0 then
                "true"
            else
                "false"
                
        let result = isEven 2                
        AssertEquality result __
    
    [<Koan>]
    member this.IfStatementsReturnValues() =
        let result = 
            if 2 = 3 then
                "something is REALLY wrong"
            else
                "no problem here"

        AssertEquality result __

    [<Koan>]
    member this.PatternMatchingIsAnotherWayToBranch() =
        let isApple x =
            match x with
            | "apple" -> true
            | _ -> false
        
        let result1 = isApple "apple"
        let result2 = isApple "apple"
        
        AssertEquality result1 __
        AssertEquality result2 __
    
    [<Koan>]
    member this.UsingTuplesWithIfStatementsCanBeClumsy() =
        
        let getDinner x = 
            let name = fst x
            let foodChoice = snd x
            
            if foodChoice = "veggies" || foodChoice ="fish" || 
               foodChoice = "chicken" then
                name + " doesn't want red meat"
            else
                name + " wants 'em some " + foodChoice
         
        let person1 = ("Chris", "steak")
        let person2 = ("Dave", "veggies")
        
        AssertEquality (getDinner person1) __
        AssertEquality (getDinner person2) __
        
    [<Koan>]
    member this.PatternMatchingIsNicer() =
    
        let getDinner x =
            match x with
            | (name, "veggies")
            | (name, "fish")
            | (name, "chicken") -> name + " doesn't want red meat"
            | (name, foodChoice) -> name + "wants 'em some " + foodChoice 
            
        let person1 = ("Bob", "fish")
        let person2 = ("Sally", "Burger")
        
        AssertEquality (getDinner person1) __
        AssertEquality (getDinner person2) __