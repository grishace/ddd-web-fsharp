// Define the fizz function with one parameter:
// tuple of number, boolean, and string
let fizz (ns:int * bool * string) =
  // decompose the tuple into 3 values,
  // but only the first component - number -
  // will be used
  let (n, _, _) = ns
  // divisible by 3?
  if n % 3 = 0 
    // construct new output tuple
    then (n, true, "Fizz")
    else (n, false, sprintf "%d" n)


// Const. F# way
[<Literal>]
let buzzstr = "Buzz"


// Define the buzz function with one parameter.
// We're not specifying its type here, but the
// F# compiler will infer it from the context
let buzz ns =
  // match tuple
  match ns with
  // if the second component is true, and 
  // the first is divisible by 5 - FizzBuzz case
  | (n, true, s) when n % 5 = 0 ->
    // construct new tuple as the result
    (n, true, s + buzzstr)
  // in any other case, i.e. the tuple was not
  // processed earlier, check the Buzz case
  | (n, _, _) -> 
    if n % 5 = 0 
      then (n, true, buzzstr) 
      else ns


// Compose fizz, buzz, and lambda functions
// to extract the third tuple component
let fizz_buzz = fizz >> buzz >> (fun ns -> 
  let (_, _, s) = ns
  s)


let fizzbuzz =
  // initial sequence of numbers from 1 to 100
  {1 .. 100} 
  // convert to sequence of tuples
  |> Seq.map (fun n -> (n, false, sprintf "%d" n))
  // composed function is applied to sequence elements
  |> Seq.map fizz_buzz


let fizzbuzz' = 
  // local function returning FizzBuzz for input n
  let fb n = match n with
             | i when i % 3 = 0 && i % 5 = 0 -> "FizzBuzz"
             | i when i % 3 = 0 -> "Fizz"
             | i when i % 5 = 0 -> "Buzz"
             | _ -> sprintf "%d" n
  // Sequence generation with unfold:
  // lambda function to create Option 
  // tuple of the current sequence element (fb n)
  // and the next state (n + 1);
  // the last parameter is the initial state (1)
  Seq.unfold (fun n -> Some((fb n), n + 1)) 1


let fizzbuzz'' = 
  // local recursive sequence generator
  let rec fb n = seq {
    // yield FizzBuzz into the output sequence
    match n with
    | i when i % 15 = 0 -> yield "FizzBuzz"
    | i when i % 3 = 0 -> yield "Fizz"
    | i when i % 5 = 0 -> yield "Buzz"
    | _ -> yield sprintf "%d" n
    // recursive sequence starting with the
    // next (+1) number
    yield! fb (n + 1)
  }
  // start generation from 1
  fb 1


// take first 100 elements of the sequence 
// and print them
Seq.take 100 fizzbuzz |> Seq.iter( printfn "%s" )
