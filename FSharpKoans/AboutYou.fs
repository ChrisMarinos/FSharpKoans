namespace FSharpKoans
open NUnit.Framework

(*
Yay, you're here, so you know all about functional programming
and F#, right?

Um.

Erm.

Oh, this is awkward.

How can I put this gently?

No.

No, you don't.  Sorry.

You now know enough to write simple functional programs
in F#.  But F# is a multi-paradigm language, and we haven't
touched on its object-oriented capabilities or its opt-in dynamic
resolution of types or its static duck-typing and constraints
or extension methods or member functions or overloading or
mutable variables or reference cells or .Net integration or interop
or much of anything else.  There just hasn't been time, and that
stuff hasn't been my focus.  I've tried to show you the functional
side of things.  It's up to you to explore the non-functional stuff.

But you know all about the functional side of things now, right?

Ah.

Well.

So awkward!

No.  Sorry again, but the answer is "no".

We haven't gone into computation expressions or
isolating side-effects with monads or more advanced
functional programming techniques.  Or a bunch of other things,
now that I come to think of it...

But, hey, don't be down.  Don't be despondent, don't be
depressed!  Because you now know the fundamentals, and
everything else in the language is built on the fundamentals.
You've got the mental tools to push on as far as you'd like.
So, if you want to expand your knowledge and become a
better functional programmer, there's no time like the present,
while the functional stuff is still fresh in your head.  Come and
talk to me, and/or visit a nice website like

fsharpforfunandprofit.com

... and I wish you the best as you embark on this voyage of
discovery.  Functional programming is a rich, amazing experience.
I hope that you'll enjoy it as much as I do ^_^.
*)

module ``24: About You`` =
    [<Test>]
    let ``Where to now?`` () =
        let resources = ["http://fsharpforfunandprofit.com"; "http://fssnip.net"; "http://stackoverflow.com"]
        let visited = __ // <-- as you visit, add to a list here!
        visited |> should equal resources