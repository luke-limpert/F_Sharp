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
let squares = 
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
    let longWords : string [] = Array.filter (fun w -> w.length > 8) words
    let sortedLongWords = Array.sort longWords
    Array.iter (fun w -> printfn "%s" w) sortedLongWords

//Reworked Verbose using forward pipe operator
let PrintLongWords2 (words : string[]) = 
    words
    |> Array.filter (fun w -> w.Length > 8)
    |> Array.sort
    |> Array.iter (fun w -> printfn "%s" w)
//I really like this style. Looks a lot cleaner and it reduces redundancy

