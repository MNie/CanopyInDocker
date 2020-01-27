open Example.Fetcher
open canopy
open System

[<EntryPoint>]
let main _ =
    configuration.chromeDir <- AppDomain.CurrentDomain.BaseDirectory
    printf "%s" (Fetcher.fetchHtml "Gdańsk")
    0 // return an integer exit code
