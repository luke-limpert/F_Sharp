/// Follow up program to the 1st in chapter 2
/// This program teaches you how to access the .NET libraries
/// The following is the code provided by the book

open System.IO
open System.Net

/// Get the contents of the URL via a web request
let http (url: string) = 
    let req = WebRequest.Create(url)
    let resp = req.GetResponse()
    let stream = resp.GetResponseStream()
    let reader = new StreamReader(stream)
    let html = reader.ReadToEnd()
    resp.Close()
    html

/// while i was writing this the let prompted an error that the value was unused
/// This is because the expression is evaluated top-down making order important

http "http://news.bbs.co.uk"

/// System.IO is an example of namespaces (packages in python)
/// If these items didnt open you would have to change the syntax to be a bit verbose
/// let req = WebRequest.Create(url) -> System.Net.WebRequest.Create(url)

///F# interactive entries to fetch a web page
open System.IO;;
open System.Net;;
let req = WebRequest.Create("http://news.bbc.co.uk");;
let resp = req.GetResponse();;
let stream = resp.GetResponseStream();;
let reader = new StreamReader(stream);;
let html = reader.ReadToEnd();;

/// alternatively to call the http function use
http "http://news.bbc.co.uk";;
