namespace FizzBuzz.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Mvc
open FizzBuzz.Models
open FizzBuzzModule

type HomeController() = 
    inherit Controller()

    member this.Index(n : Nullable<int>) = 
        let num = if n.HasValue then n.Value else 100
        this.View(this.Generate num)

    [<HttpPost()>]
    member this.DoPost(fb : FizzBuzzModel) = 
        this.RedirectToAction("Index", { n = fb.Number })

    member fb.Generate (n) : FizzBuzzModel = 
        { Number = n; FizzBuzz = fizzbuzz n }

    member this.Error() = this.View()
