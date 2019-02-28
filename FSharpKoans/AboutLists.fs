namespace FSharpKoans

open NUnit.Framework

(*
Lists are immutable, ordered, finite sequences of a single type.
*)

module ``12: I Have Here In My Hand A List`` = 
    [<Test>]
    let ``01 Creating a list (Syntax 1).`` () = 
        let myList = [ __; __; __; __ ]
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
   
    [<Test>]
    let ``02 Creating a list (Syntax 2).`` () =
        let myList = __::__::__::__::[]
        let myOtherList = __::__::__::[ __ ]
        let myNextList = __::__::__ // you may use [ and ] symbols on this line.
        let myLastList = __::__::__ // DO NOT use [ or ] symbols on this line!
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
        myOtherList |> should equal [ "orange"; "lemon"; "princess"; "queen" ]
        myNextList |> should equal ["lily"; "sunflower"; "daisy"; "carrot"]
        myLastList |> should equal [ "naartjie"; "raisin"; "apple"; "grape"; "pear"; "biscuit" ]

    [<Test>]
    let ``03 Creating a list (via concatenation).`` () =
        let a = [902; 10]
        let b = [3; 13; 37]
        let result = __ @ __
        result |> should equal [902; 10; 3; 13; 37]

    [<Test>]
    let ``04 The : : operator (called "cons") does not modify an existing list`` () = 
        let first = [ "grape"; "peach" ]
        let second = "pear" :: first
        let third = "apple" :: second
        third |> should equal __
        second |> should equal __
        first |> should equal __

    [<Test>]
    let ``05 Pattern-matching a list (Part 1).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let a::_ = fruits
        a |> should equal __

    [<Test>]
    let ``06 Pattern-matching a list (Part 2).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let b::c::_ = fruits
        b |> should equal __
        c |> should equal __

    [<Test>]
    let ``07 Pattern-matching a list (Part 3).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::d::e = fruits
        d |> should equal __
        e |> should equal __

    [<Test>]
    let ``08 Pattern-matching a list (Part 4).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let f::_::_::g::_ = fruits
        f |> should equal __
        g |> should equal __

    [<Test>]
    let ``09 Pattern-matching a list (Part 5).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::_::_::h = fruits
        h |> should equal __

    [<Test>]
    let ``10 Pattern-matching a list (Part 6).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [i;j;k;l;m;n] = fruits
        i |> should equal __
        j |> should equal __
        k |> should equal __
        l |> should equal __
        m |> should equal __
        n |> should equal __

    [<Test>]
    let ``11 Pattern-matching a list (Part 7).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::o::_::[p;q;r] = fruits
        o |> should equal __
        p |> should equal __
        q |> should equal __
        r |> should equal __

    [<Test>]
    let ``12 Pattern-matching a list (Part 8).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [_;s;_;_;t;_] = fruits
        s |> should equal __
        t |> should equal __

    [<Test>]
    let ``13 Pattern-matching a list (Part 9).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let k =
            match fruits with
            | [a;b;c;d;e] -> "prune"
            | _::t::_::u::_ -> t + u
            | _ -> "fig"
        k |> should equal __