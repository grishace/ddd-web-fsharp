namespace FizzBuzz

open WebSharper
open WebSharper.JavaScript
open WebSharper.Html.Client

[<JavaScript>]
module Client =

    let (|DivisibleBy|_|) divisor i = 
      if i % divisor = 0 then Some () else None


    let fizzbuzz' n =
      match n with
      | DivisibleBy 3 & DivisibleBy 5 -> "FizzBuzz"
      | DivisibleBy 3 -> "Fizz" 
      | DivisibleBy 5 -> "Buzz" 
      | _ -> string n


    let fizzbuzz n =
      seq {
        for i in 1..n do 
          yield fizzbuzz' i
      } |> Seq.toArray


    let generate (input: string) =
         let num = min (int(input)) 100
         fizzbuzz num |> Array.toList |> List.map(fun f -> LI [ Text (string f) ])

    let generateOutput v (o:Element) =
       (generate v) |> Seq.iter(o.Append)

    [<Literal>]
    let DefaultValue = "100"

    let Main () =
        let input = Input [Attr.Value DefaultValue] -< []
        let output = OL []
        generateOutput DefaultValue output

        Div [
            input
            Button [Text "Generate"]
            |>! OnClick (fun _ _ ->
                output.Clear()
                generateOutput input.Value output
                )
            HR []
            Div [Attr.Class "fb"] -< [output]
        ]
