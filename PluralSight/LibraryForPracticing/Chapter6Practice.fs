#if INTERACTIVE
#else
module Chapter6
#endif

//Object oriented types
//work on using OO types like classes, constructors, Methods, and interfaces
//look at using C# interop (interoperatablility) to use C# in F#

//Declaring an OO type(class) in F#
type Person(forename : string, surname : string) =
    member this.Forename = forename
    member this.Surname = surname

// declare classname(constructors) =
//constructors must be tupled together and its normal to specify types
// member declaration then a self identifier which can be this or self
// how to instantiate some people

//either of the methods below all you to do so
let p1 = Person("Luke", "Limpert");;

let p3 = Person(forename = "Jaxson", surname ="Limpert");;

//These are immutable, so we cannot assign a member a new last name
//In this example a record may have been more appropriate
//Making this class mutable requires the following

type Persons(forename : string, surname : string) = 
    let mutable _forename = forename
    let mutable _surname = surname
    
    member this.Forename
        with get () = _forename
        and set value = _forename <- value
    
    member this.Surname
        with get () = _surname
        and set value = _surname <- value

let p4 = Persons("Nicole", "Mueting");;

p4.Surname <- "Limpert";;

//This allows you to change the surname and forename of a person
//Again, this would be much easier to do in records
