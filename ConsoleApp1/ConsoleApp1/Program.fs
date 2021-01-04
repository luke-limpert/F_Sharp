// Learn more about F# at http://fsharp.org

// First F# program

/// Split a string into words at spaces
let splitAtSpaces (text: string) = 
    text.Split ' '
    |> Array.toList

/// Analyze a string for duplicate words
let wordCount text = 
    let words = splitAtSpaces text
    let numWords = words.Length
    let distinctWords = List.distinct words
    let numDups = numWords - distinctWords.Length
    (numWords, numDups)

/// Analyze a string for duplicate words and display the results
let showWordCount text = 
    let numWords, numDups = wordCount text
    printfn "--> %d words in the text" numWords
    printfn "--> %d duplicate words" numDups

let (numWords, numDups) = wordCount "Does this program work and count duplicate words?";;

///Explanation of program

/// you can run this program in F interactive by using the ctrl + alt + f
/// to send the text, select what you want to send and press alt + enter
