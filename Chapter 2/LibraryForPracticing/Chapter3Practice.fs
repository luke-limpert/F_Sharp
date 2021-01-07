#if INTERACTIVE
#else
module Chapter3
#endif

let arr = [|1; 2; 4|]
let fruits = 
    [|
        "apple"
        "orange"
        "pear"
    |]

let numbers = [|0.0 .. 0.1 .. 9.0|]

let squares = [| for i in 0..99 do yield i * i|]

let RandomFruits count = 
    let r = System.Random()
    let fruits = [|"apple"; "orange"; "pear"|]
    [|
        for i in 1..count do
            let index = r.Next(3)
            yield fruits.[index]
    |]

let RandomFruits2 count = 
    let r = System.Random()
    let fruits = [|"apple"; "orange"; "pear"|]
    Array.init count (fun _ ->
        let index = r.Next(3)
        fruits.[index]
    )

//Array processing section
let rf = RandomFruits 10;;

//Output : val rf : string [] =[|"pear"; "pear"; "pear"; "pear"; "pear"; "orange"; "apple"; "apple"; "pear";"apple"|]
//Look at the fruits individually

let first = rf.[0];;

//interating over an array
let LikeSomeFruit fruits = 
    for fruit in fruits do 
        printfn "I like %s" fruit

//iteration across a range of values
let SaySomeNumbers() = 
    for i in 0..9 do 
        printfn "Number: %i" i

//using the filter function
let squares2 = 
    [|
        for i in 0..99 do
            yield i*i
    |]

let IsEven n =
    n % 2 = 0

let evenSquares = Array.filter (fun x -> IsEven x) squares
// breakdown of the line above - squares is passed as an argument and the isEven function is used
// as the filter for each value in the squares array. These are very similar to lambda functions. 

//iterate over an array
let LikeSomeFruits2 fruits = 
    Array.iter (fun fruit -> printfn "I like %s" fruit) fruits

//sort an array
let sortedFruit = Array.sort [|"pear"; "orange"; "apple"|]

//Verbose combination of iter, filter and sort
let PrintLongWords (words : string[]) = 
    let longWords : string [] = Array.filter (fun w -> w.Length > 8) words
    let sortedLongWords = Array.sort longWords
    Array.iter (fun w -> printfn "%s" w) sortedLongWords

//Reworked Verbose using forward pipe operator
let PrintLongWords2 (words : string[]) = 
    words
    |> Array.filter (fun w -> w.Length > 8)
    |> Array.sort
    |> Array.iter (fun w -> printfn "%s" w)
//I really like this style. Looks a lot cleaner and it reduces redundancy

// Array .map usage
//Original Function
let PrintSquares min max =
    let square n = 
        n*n
    for i in min..max do
        printfn "%i" (square i)

//Using map
let PrintSquaresMap min max = 
    let square n =
        n*n
    [|min..max|]
    |> Array.map (fun i -> square i)
    |> Array.iter (fun s -> printfn "%i" s)

//Using map and eliminating Redundancy
let PrintSquaresMap2 min max = 
    let square n =
        n*n
    [|min..max|]
    |> Array.map square
    |> Array.iter (printfn "%i")

//Array elements are mutable by default 
//F# lists are similar to Arrays, but immutable by default
//You can change something from an array to a list by removing the 
//pipe symbol ("|") from the array declaration and changing the 
//call for usage of list higher order functions

//Using list instead of array
let PrintSquaresMapList min max = 
    let square n =
        n*n
    [min..max]
    |> List.map square
    |> List.iter (printfn "%i")

//Sequences

//Anything implementing IEnumerable interface
//This is a collection of the same type with a property that
//allows you to process one element at a time

let myFiles = System.IO.Directory.EnumerateFiles(@"c:\temp\*.txt")
// Multiple ways to create sequences
//Way #1
let smallNumbers = {0..99};;

//Way #2
let smallNumbers2 = Seq.init 100 (fun i -> i);;

//Way #3 if you want to create code between the curly brackets you have to use seq
let smallNumbers3 = 
    seq {
        for i in 0..99 do
            yield i
    }

// Cycling through files 
open System.IO

let bigFiles = 
    Directory.EnumerateFiles(@"c:\windows")
    |> Seq.map (fun name -> FileInfo name)
    |> Seq.filter (fun fi -> fi.Length > 100000L)
    |> Seq.map (fun fi -> fi.Name)

//Chapter 3 summary