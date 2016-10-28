#r @"..\packages\Suave.1.1.3\lib\net40\Suave.dll"

#load "FizzBuzz.fsx"
open FizzBuzz


open Suave
open Suave.Filters
open Suave.Operators
open Suave.Successful
open Suave.Json
open Suave.Writers
open System
open System.Threading
open System.Text


let json<'a> : ('a -> WebPart) = toJson >> Encoding.UTF8.GetString >> OK


let app = 
  choose [
    choose [
      GET >=> choose [ path "/api/fizzbuzz" >=> json(fizzbuzz 100) ]
      GET >=> choose [ pathScan "/api/fizzbuzz/%d" (fun n -> fizzbuzz' n |> json) ]
      GET >=> choose [ pathScan "/api/fizzbuzz/seq/%d" (fizzbuzz >> json) ]
    ] >=> setMimeType "application/json; charset=utf-8"
    RequestErrors.NOT_FOUND ""
  ]


// https://github.com/SuaveIO/suave/issues/454
let cts = new CancellationTokenSource()
let conf = { defaultConfig with cancellationToken = cts.Token }
let listening, server = startWebServerAsync conf app
Async.Start(server, cts.Token)
Console.ReadLine() |> ignore
cts.Cancel()
