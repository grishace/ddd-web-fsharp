module FizzBuzz

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
