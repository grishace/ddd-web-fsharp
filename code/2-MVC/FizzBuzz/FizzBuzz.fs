[<AutoOpen()>]
module FizzBuzzModule

  let fizzbuzz' num =
    match num % 3, num % 5 with
    | 0, 0 -> "FizzBuzz"
    | 0, _ -> "Fizz"
    | _, 0 -> "Buzz"
    | _ -> string num

  let fizzbuzz n =
    [1..n]
    |> List.map fizzbuzz'
