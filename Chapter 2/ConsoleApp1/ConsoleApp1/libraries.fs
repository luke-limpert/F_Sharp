/// Chapter 2 libraries 
/// open doesnt load or reference a library it only reveals functionality from previously loaded libraries
/// therefore we have to use -r or #r to actually load the library
#r "C:/Users/limpertl/Documents/F_Sharp/packages/FSharp.Data/lib/net45/FSharp.Data.dll"

/// now that it is loaded we can open it
open FSharp.Data

type Species = HtmlProvider<"http://en.wikipedia.org/wiki/The_world's_100_most_threatened_species">

let species =
    [ for x in Species.GetSample()
    .Tables
    .``Species list``.Rows -> x.Type, x.``Common name``]

/// Use the acute key for after the .Tables line of the code (top left corner of keyboard)
/// The 3 lines above performed a screen scrape and downloaded the significant data set

let speciesSorted = 
    species
        |> List.countBy fst
        |> List.sortByDescending snd

/// Starting a web server and serving data using F# packages
#r "C:/Users/limpertl/Documents/F_Sharp/packages/Suave/lib/netstandard2.1/Suave.dll"

open Suave
open Suave.Web

let html = 
    [ yield "<html><body><ul>"
      for (category,count) in speciesSorted do
         yield sprintf "<li>Category <b>%s</b>: <b>%d</b></li>" category count
      yield "</ul></body></html>" ]
    |> String.concat "\n"

startWebServer defaultConfig (Successful.OK html)

/// The text reference loading Suave.Http.Successful, but the Suave.io just includes
/// successful in the statement to start the web server - Instead of (OK html) like 
/// the text, use (Successful.OK html)

/// a popular web programming framework called angular is described next
open Suave

let angularHeader = """<head>
<link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/css/bootstrap.
min.css">
<script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.2.26/angular.min.js"></script>
</head>"""

let fancyText = 
    [ yield """<html>"""
      yield angularHeader
      yield """ <body> """
      yield """  <table class="table table-striped">"""
      yield """   <thead><tr><th>Category</th><th>Count</th></tr></thead>"""
      yield """   <tbody> """
      for (category,count) in speciesSorted do
        yield sprintf "<tr><td>%s</td><td>%d</td></tr>" category count
      yield """   </tbody>"""
      yield """  </table>"""
      yield """ </body>"""
      yield """</html>""" ]
    |> String.concat "\n"

startWebServer defaultConfig (Successful.OK fancyText)
