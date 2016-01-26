namespace FSharpKoans
open NUnit.Framework

(*
    A discriminated union is a disjoint set of named cases, where each case
    may have some linked/associated data.  If a discriminated union case has
    associated data, the case name is a function which takes the associated
    data as input and gives a value of the discriminated union type as output.
*)


module ``10: The Good Kind of Discrimination`` = 
    type Subject = // <-- feel free to add your own subjects!
    | Philosophy
    | Linguistics
    | ComputerScience
    | Mathematics
    | Economics
    | Management

    type UndergraduateDegree = 
    | BSc of Subject * Subject
    | BCom of Subject * Subject
    | BPharm
    | BA of Subject * Subject

    type PostgraduateDegree =
    | Honours of Subject
    | Masters of Subject

    [<Test>]
    let ``01 A case isn't the same as a type`` () = 
        let aDegree = BSc (Linguistics, ComputerScience)
        let anotherDegree = BPharm
        let philosopherKing = Masters Philosophy
        aDegree |> should be ofType<FILL_ME_IN> 
        anotherDegree |> should be ofType<FILL_ME_IN> 
        philosopherKing |> should be ofType<FILL_ME_IN> 
   
    [<Test>]
    let ``02 Creating & pattern-matching a discriminated union`` () = 
        let randomOpinion degree =
            match degree with
            | BSc (_, ComputerScience) | BSc (ComputerScience, _) -> "Good choice!"
            | BSc _ -> "!!SCIENCE!!"
            | BPharm -> "Meh, it's OK."
            | FILL_ME_IN -> "Money, money, money."
            | FILL_ME_IN -> "A thinker, eh?"
        randomOpinion __ |> should equal "Good choice!"
        randomOpinion __ |> should equal "!!SCIENCE!!"
        randomOpinion (BCom (Management, Economics)) |> should equal "Money, money, money."
        randomOpinion (BCom (Linguistics, Management)) |> should equal "Money, money, money."
        randomOpinion (BA (Linguistics, Philosophy)) |> should equal "A thinker, eh?"
        randomOpinion __ |> should equal "Meh, it's OK."

    type EquipmentStatus =
    | Available
    | Broken of int // takes an int, gives back en EquipmentStatus
    | Rented of string

    [<Test>]
    let ``03 A discriminated union case with associated data is a function`` () =
        Broken |> should be ofType<FILL_ME_IN>
        Rented |> should be ofType<FILL_ME_IN>

    type Genealogy =
    | UnknownAncestor
    | Child of string * Genealogy * Genealogy

    [<Test>]
    let ``04 A discriminated union can refer to itself (i.e., it can be recursive).`` () =
        let rec countAncestors x =
            match x with
            | UnknownAncestor -> 0
            | Child (_, mother, father) -> countAncestors mother + countAncestors father
        let a = __ // <-- you may want to spread this over multiple lines and/or let-bindings ...!
        countAncestors a |> should equal 4
