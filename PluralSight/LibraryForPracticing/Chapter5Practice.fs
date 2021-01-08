#if INTERACTIVE
#else
module Chapter5
#endif

//Immutability 
//Shadowing
//How to bypass immutability

//Immutability is the property of a value that once it is set, it can't be changed

let ImmutabilityDemo() =
    let x = 42
    // this value is not mutable
    //x <- 43
    let x = 43
    //the line above does work, but this is an example of shadowing which causes problems in deeper nested functions
    x

//consider this
let ImmutabilityDemo2() = 
    let x = 42
    printfn "x: %i" x
    if 1 = 1 then
        let x = x + 1
        printfn "x: %i" x
    printfn "x: %i" x

//output 42
//43
//42

//once you leave the scope of the if statement the original x becomes visible again in this example and can cause bugs

//Advantages of Immutability
//Immutability makes code simpler
//Functions have no side effects
//  Referential Transparency
//safer multithreading

//Overriding immutability if you want it to be

let MutabilityDemo() = 
    let mutable x = 42
    printfn "x: %i" x
    x <- x + 1
    printfn "x: %i" x

//adding the mutable keyword allows values to be mutable

let RefCellDemo() = 
    let x = ref 42
    x := 43
    printfn "X: %i" !x

//example of when you would need to use ref instead of mutable
let PrintLines() = 
    seq {
        let mutable finished = false
        while not finished do
            match System.Console.ReadLine() with
            | null -> finished <- true
            | s -> yield s
        }

//in the pluralsight example this is used in an invalid way 

let PrintLines2() = 
    seq {
        let finished = ref false
        while not !finished do
            match System.Console.ReadLine() with
            | null -> finished := true
            | s -> yield s
        }

//In F# 4.0 you can use mutable in the mutable context above
//it is best to use mutation for optimization after you have a set of 
//unittests to compare performance with mutation


