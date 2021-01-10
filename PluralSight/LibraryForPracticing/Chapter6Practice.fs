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
//Mutable backing store values with getters and setters
// to use getters and setters you need the val keyword (validation)

type MutableGetter(forename : string, surname : string) =
    member val Forename = forename with get, set
    member val Surname = surname with get, set

// this would allow you to alter the forename and surname as a mutable type

//Doing work in the constructor

open System 

type SafePerson (forename : string, surname : string) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException())
    do 
        validateString forename
        validateString surname
    member val Forename = forename with get, set
    member val Surname = surname with get, set

//declaring and implementing interfaces
type IPerson = 
    abstract member Forename : string
    abstract member Surname : string
    abstract member Fullname : string

type PersonFromInterface(forename : string, surname : string) =
    let validateString str = 
        if String.IsNullOrWhiteSpace str then
            raise (ArgumentException())
    do
        validateString forename
        validateString surname

    interface IPerson with
        member __.Forename = forename
        member __.Surname = surname
        member __.Fullname = sprintf "%s %s" forename surname

// in order to make the Fullname property work you need to cast the instance your dealing with to the interface
// (person :> IPerson).Fullname
//:> is the upcasting property and its purpose is to upcast from the person to the IPerson to get access to the Fullname property
//makes it clear if you are relying on a method of the type or interface and in cases where multiple interfaces are implemented, which one you want to implement

//Calling F# code from C#
//Both are Common Language Infrastructures (CLI)
//The next portion of the video unpacks a lot of different things, like adding a C# project, then referencing the project, using nuget to add nunit and renaming
//We reference the F# Project in the C# project
//Use the NuGet package manager to add the NUnit package
//For some reason I couldn't get the C# to recognize the LibraryForPracticing, so I couldn't pull from the chapter6Practice.fs
//will redo it later under a new project name and without information from the other exercises


