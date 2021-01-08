#if INTERACTIVE
#else
module Chapter4
#endif

//Focus of this module is on records, option types, discriminated unions and pattern matching

//records let you build super lightweight containers for small groups of values
//option types let you eliminate the null reference exception from your code
//discriminated unions and pattern matching let you represent your process structure data in reliable ways.

//new key word : type for creating a record

type Person = 
    {
        FirstName : string
        LastName : string
    }

let person = { FirstName = "Luke"; LastName = "Limpert" }

//dot notation to access the fields
printfn "%s, %s" person.LastName person.FirstName

//To modify the record you don't actually modify it you create a new record using the with statement
let person2 = { person with FirstName = "Jaxson" }

//Records by default have structural equality meaning that if the contents are the same 
//between 2 records they can be compared (also called content equality)

//reference equality is another type of equality which would mean that these would not be equal because 
//they were created at different times and are stored at a different location in memory


//OptionTypes Section

type Company = 
    {
        Name : string
        SalesTaxNumber : int option
    }

//by using the option key word you also need to use the "some" keyword when declaring if there is 
//a sales tax number to make it explicit if there is a value or not

let company1 = { Name = "Kit Enterprises"; SalesTaxNumber = None }
let company2 = { Name = "Acme Systems"; SalesTaxNumber = Some 12345}

// using this data
// new keyword "match"

let PrintCompany (company : Company) = 
    
    let taxNumberString = 
        match company.SalesTaxNumber with
        | Some n -> sprintf " [%i]" n
        | None -> ""

    printfn "%s%s" company.Name taxNumberString


//You could use an if statement to do the same thing, but match statements are the safer and more idiomatic approach
// example of same code using if statements

let PrintCompany2 (company : Company) =

    let taxNumberString = 
        if company.SalesTaxNumber.IsSome then
            sprintf " [%i]" company.SalesTaxNumber.Value
        else
            ""

    printfn "%s%s" company.Name taxNumberString

//accessing the value of a value that is None will trigger a NullException error which is another reason this method 
//should be avoided in lieu of the match statement

//Discriminated Unions and Pattern Matching

type Shape = 
    | Square of float
    | Rectangle of float * float
    | Circle of float

let s = Square 3.4
let r = Rectangle(2.2, 1.9)
let c = Circle(1.0)

let drawing = [|s; r; c|]

let Area (shape : Shape) = 
    match shape with
    | Square x -> x * x
    | Rectangle(h, w) -> h * w
    | Circle r -> System.Math.PI * r * r

let total = drawing |> Array.sumBy Area

//Pattern matching on arrays
let one = [|50|]
let two = [|60; 61|]
let many = [|0..99|]

//in the pattern matching below the "_" character acts as a wild card for all cases we do not want to observe
let Describe arr = 
    match arr with
    | [|x|] -> sprintf "One element: %i" x
    | [|x; y|] -> sprintf "Two elements: %i, %i" x y
    | _ -> sprintf "a longer array"
