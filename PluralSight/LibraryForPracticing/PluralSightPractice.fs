#if INTERACTIVE
#else
module JumpStart
#endif

let x = 42
let hi = "Hello"

let Greeting name = 
    if System.String.IsNullOrWhiteSpace(name) then
        "whoever you are"
    else
        name
// Type interference when changing %s to %i
let SayHiTo me = 
    printfn "hi, %s" (Greeting me)

// ;; terminating operator
// needs to follow all ending lines in F# interactive

let Square x = x * x

let Area length height = 
    length * height
// at the moment the above example is 2 integers
 // you can force the types by doing the following

let Area2 (length : float)(height : float) = 
    length * height

let PrintNumbers min max = 
    for x in min..max do
        printfn"%i" x

let PrintNumbersSquares min max =
    let square n =
        n * n
    for x in min..max do
        printfn "%i %i" x (square x)

// Removing the brackets from the randomposition funciton
// makes it a value and immediately evaluates it

let RandomPosition() = 
    let r = new System.Random()
    r.NextDouble(), r.NextDouble()

//experimenting with loops and knowledge so far
let TimesTables (n1 : int)(n2 : int) = 
    for x in n1..n2 do
        printfn "___________"
        for y in n1..n2 do
            let z =
                x * y
            printfn "%i" z




