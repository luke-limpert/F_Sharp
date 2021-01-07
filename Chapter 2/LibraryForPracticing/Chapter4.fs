#if INTERACTIVE
#else
module Chapter4
#endif

//Records, Option Types, Discriminated Unions and pattern matching
//Records let you build super lightweight containers for small groups of values
//Option types let you eliminate the null reference exception
//Discriminated unions and pattern matching let you 
//represent and process structured data

//declaring a new record
type Person = 
    {
        FirstName : string
        LastName : string
    }

//instantiating records
let person = { FirstName = "Luke"; LastName = "Limpert" }

//using the given instance name you use dot notation to access the fields
printfn "%s, %s" person.LastName person.FirstName

//creating new records
let person2 = { person with FirstName = "Christian" }

//records have structural equality / content equality and
//are not build with reference equality therefore a 
//record with the same content can be compared to other 
//records

