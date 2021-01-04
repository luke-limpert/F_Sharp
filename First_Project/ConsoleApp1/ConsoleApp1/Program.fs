// Learn more about F# at http://fsharp.org

// First F# program

/// Split a string into words at spaces
let splitAtSpaces (text: string) = 
    text.Split ' '
    |> Array.toList

/// Analyze a string for duplicate words
/// the "let" keyword defines the function and the local value
/// "wordcount" = function, "words" = value
/// This function takes 1 argument (text) - similar to python:
/// def wordCount(text)

let wordCount text = 
    let words = splitAtSpaces text
    let numWords = words.Length
    let distinctWords = List.distinct words
    let numDups = numWords - distinctWords.Length
    (numWords, numDups)

/// the value at the end of the function expression is the return value for that function
/// in the case above it is the tuple (numWords, numDups)
/// to extract a portion of a tuple use the fst and snd function
/// fst wordCount;;
/// let dupCount = snd wordCount;;

/// Analyze a string for duplicate words and display the results
let showWordCount text = 
    let numWords, numDups = wordCount text
    printfn "--> %d words in the text" numWords
    printfn "--> %d duplicate words" numDups

let (numWords, numDups) = wordCount "Does this program work and count duplicate words?";;

///Explanation of program

/// you can run this program in F interactive by using the ctrl + alt + f
/// to send the text, select what you want to send and press alt + enter

/// the reason that "let" is used to declare values and not variables is because F# 
//// is immutable by default, so the value isn't variable or mutable - 
/// This is mostly just a small point on the language specification, but important

/// The F# interactive below shows a "val" keyword explaining the "type" assosciated 
/// how to read this is as follows:
/// val wordCount: text:string (this indicates the input) -> int * int (everything after
/// the arrow indicates an output, so in this case a pair of integers. 
/// the -> indicates that wordCount is a function

/// to call a function use the syntax of the folliowing example
/// splitAtSpaces "hello world";;
/// This will call the function and run it with the sentence to the right 
/// The output is val it : string list = ["hello"; "world"] (looks very similar to python list)

/// breakout programming example of working with Tuples
let site1 = ("www.cnn.com", 10)
let site10 = ("news.bbc.com", 5)
let site11 = ("www.msnbc.com", 4)
let sites = (site1, site10, site11);;

