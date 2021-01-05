#if INTERACTIVE
#else
module JumpStart
#endif

let x = 42
let hi = "Hello"

let SayHiTo me = 
    printfn "hi, %s" me

let Square x = x * x

