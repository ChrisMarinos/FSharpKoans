namespace FSharpKoans
open NUnit.Framework

module ``15: Advanced techniques`` = 
    [<Test>]
    let ``01 Unit is used when there is no return value for a function``() = 
        let sendData data = () //<-- a function which is invoked for its side-effect(s)
        sendData "data" |> should equal ___ // ... don't overthink this one!
   
    [<Test>]
    let ``02 Unit, as an input, conveys no data`` () = 
        let sayHello () = "hello"
        let result = sayHello ()
        sayHello |> should be ofType<FILL_ME_IN>
        sayHello () |> should be ofType<FILL_ME_IN>
        sayHello () |> should equal __

(*
    When we develop real systems, we often run into problems
    around time and timing.  For example, consider how a web
    browser might work.  It loads images and videos and text
    and all sorts of things on a webpage.  But only a small
    portion of that webpage is visible to a user at a time, and it
    is wasteful (and affects performance!) to pull down an image
    that might never be seen, or to do the work of decoding a
    video which can't be seen by the user.  So, what do we do?
    
    If you think carefully about it, you will realize that this is a
    timing problem.  We don't know what the user will do, and
    we don't know when (if ever!) a particular thing will be
    required.  What we want is a way to *DEFER* work, so that
    it is only done when it needs to be done.

    We can use a ( unit->'a ) function to do this.  The function
    contains the code that *would* be executed to achieve the goal,
    but DOES NOT EXECUTE the code until it is called.  Remember
    that DEFINING a function is not the same as CALLING a function!
    Then, if/when we need to, we can call the function to perform
    the work only when it is necessary to do so.
*)

    [<Test>]
    let ``03 Unit is often used to defer code execution`` () =
        let webpageWork x = // this simulates the different tasks that a web browser might perform
            match x%5 with
            | 0 -> fun () -> "Load video"
            | 1 -> fun () -> "Load image"
            | 2 -> fun () -> "Play audio"
            | _ -> fun () -> "Render text"
        let scrollPositions = // this is the "work" that needs to be done when scrolling up and down the page.
            List.init 100 webpageWork
        let getWorkAtPosition p =
            match p < List.length scrollPositions && p >= 0 with
            | true -> scrollPositions.[p]
            | _ -> fun () -> "Nothing to do"
        scrollPositions |> should be ofType<FILL_ME_IN>
        getWorkAtPosition |> should be ofType<FILL_ME_IN>
        getWorkAtPosition 3 |> should be ofType<FILL_ME_IN>
        (getWorkAtPosition 3) () |> should be ofType<FILL_ME_IN>
        getWorkAtPosition 250 |> should be ofType<FILL_ME_IN>
        (getWorkAtPosition 250) () |> should be ofType<FILL_ME_IN>
        (getWorkAtPosition 5) () |> should equal __
        (getWorkAtPosition -7) () |> should equal __

    (*
        Sometimes we want to do something purely for a side-effect
        that it has.  For example, we may want to read a line from a
        file just so that we can get to the next line.  In these cases,
        we use the `ignore` function to throw away a return value.
    *)

    [<Test>]
    let ``04 The 'ignore' function is used to map anything to 'unit'`` () =
        let doSomethingForTheSideEffect x =
            // ...perform side effect...
            x // return x
        doSomethingForTheSideEffect 5 |> should equal __
        ignore (doSomethingForTheSideEffect "blorp") |> should equal __
        doSomethingForTheSideEffect 19.66 |> ignore |> should equal __

    [<Test>]
    let ``05 Partially specifying arguments (Part 1).`` () =
        // this shows you how you can partially specify particular arguments to
        // reuse functionality.  This technique is exceptionally flexible and often
        // seen in functional code, so you should try to understand it fully.
        let f animal noise = animal + " says " + noise
        let kittehs = __ "cat"
        __ "nyan" |> should equal "cat says nyan"

    [<Test>]
    let ``06 Partially specifying arguments (Part 2).`` () =
        // as above, but what do you do when the arguments aren't in the order
        // that you want them to be in?
        let f animal noise = animal + " says " + noise
        let howl k = __ // <- multiple words on this line.  You MUST use `f`.
        howl "dire wolf" |> should equal "dire wolf says slash/crunch/snap"
        howl "direr wolf" |> should equal "direr wolf says slash/crunch/snap"

    [<Test>]
    let ``07 Partially specifying arguments (Part 3).`` () =
        // Extending a bit more, what do you do when you want to apply a function,
        // but modify the result before you give it back?
        let f animal noise = animal + " says " + noise
        let cows = __ // <-- multiple words on this line, or you may want to make this a multi-line thing.  You MUST use `f`.
        cows "moo" |> should equal "cow says moo, de gozaru"
        cows "MOOooOO" |> should equal "cow says MOOooOO, de gozaru"

    [<Test>]
    let ``08 Getting closure`` () =
        let calculate initial final = // note the number of inputs.
            let middle = (final - initial) / 2
            fun t -> t-middle, t+middle
        // note the number of inputs provided below.  Do you see why I can do this?
        calculate 10 20 5 |> should equal __
        calculate 0 600 250 |> should equal __

    [<Test>]
    let ``09 Using a value defined in an inner scope`` () =
        // this is very similar to the previous test.
        let g t =
            let result =
                match t%2 with
                | 0 -> 10
                | 1 -> 65
            fun x -> result - x
        g 5 8 |> should equal __
        g 8 5 |> should equal __
        // PS. I hope this one brought you some closure.
