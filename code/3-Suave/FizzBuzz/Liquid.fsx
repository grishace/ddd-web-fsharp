#r @"..\packages\Suave.1.1.3\lib\net40\Suave.dll"
#r @"..\packages\DotLiquid.2.0.55\lib\net451\DotLiquid.dll"
#r @"..\packages\Suave.DotLiquid.1.1.3\lib\net40\Suave.DotLiquid.dll"


#load "FizzBuzz.fsx"
open FizzBuzz


open Suave
open Suave.DotLiquid
open DotLiquid
open Suave.Filters
open Suave.Operators
open Suave.Successful
open System
open System.Threading


type Model = { Title : string; Number: int; FizzBuzz: string[] }


[<Literal>]
let pageTitle = "F#zzBuzz"
let model = { Title = pageTitle; Number = 100; FizzBuzz = fizzbuzz 100 }

let files = 
  choose [
    Filters.GET >=> choose [ Filters.path "/" >=> Files.file "index.html"; Files.browseHome ]
  ]

let app =
  choose [
    choose [
      GET >=> choose [ path "/" >=> page "index.liquid" model ]
      GET >=> choose [ pathScan "/%d" (fun n -> 
        let num = min n 100
        let model = { Title = pageTitle; Number = num; FizzBuzz = fizzbuzz num }
        page "index.liquid" model
      )]
      POST >=> choose [ path "/" >=> request (fun req ->
        let n = match req.formData "Number" with
                | Choice1Of2 n -> n
                | Choice2Of2 n -> n
        Redirection.FOUND ("/" + string n)
      )]
    ]
    files
    RequestErrors.NOT_FOUND ""
  ]

setTemplatesDir (__SOURCE_DIRECTORY__ + "\Views")

let cts = new CancellationTokenSource()
let conf = { 
  defaultConfig with 
    cancellationToken = cts.Token;
    homeFolder = Some(__SOURCE_DIRECTORY__ + "\wwwroot")
  }
let listening, server = startWebServerAsync conf app
Async.Start(server, cts.Token)
Console.ReadLine() |> ignore
cts.Cancel()

