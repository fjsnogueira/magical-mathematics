// Learn more about F# at http://fsharp.org

open System

type Value = 
    | Ace
    | King
    | Queen
    | Jack
    | Rank of int
    
type Suit =
    | Clubs
    | Hearts
    | Spades
    | Diamonds

type Card = Card of Value*Suit
let sequence = 
 [
    Card (Rank 8, Clubs) // 0
    Card (Ace, Clubs) // 0
    Card (Rank 2, Clubs) // 0
    Card (Rank 4, Clubs) // 0
    Card (Ace, Spades) // 0
    Card (Rank 2, Diamonds) // 1
    Card (Rank 5, Clubs) // 0
    Card (Rank 3, Spades)
    Card (Rank 6, Diamonds)
    Card (Rank 4, Spades)
    Card (Ace, Hearts)
    Card (Rank 3, Diamonds)
    Card (Rank 7, Clubs)
    Card (Rank 7, Spades)
    Card (Rank 7, Hearts)
    Card (Rank 6, Hearts)
    Card (Rank 4, Hearts)
    Card (Rank 8, Hearts)
    Card (Ace, Diamonds)
    Card (Rank 3, Clubs)
    Card (Rank 6, Clubs)
    Card (Rank 5, Spades)
    Card (Rank 3, Hearts)
    Card (Rank 7, Diamonds)
    Card (Rank 6, Spades)
    Card (Rank 5, Hearts)
    Card (Rank 2, Hearts)
    Card (Rank 5, Diamonds)
    Card (Rank 2, Spades)
    Card (Rank 4, Diamonds)
    Card (Rank 8, Spades)
    Card (Rank 8, Diamonds)
 ]
let stringToSuit (input:string) = 
    match input.ToLower() with 
    | "spades" -> Spades
    | "clubs" -> Clubs
    | "diamonds" -> Diamonds
    | "hearts" -> Hearts
    | _ -> failwith "That is not a suit dude."
let suitToBinary suit = 
    match suit with 
    | Spades
    | Clubs -> 0
    | Diamonds
    | Hearts -> 1
let cardToBinary card =
    match card with 
    | Card(_, suit) -> suitToBinary suit
let getWindowAsBinary =
  sequence |> List.map(cardToBinary) |> List.windowed(5) 
let convertBitsToString (bits:int list) =
    bits |> List.map(string) |> List.reduce((+))
let findChosenCards (bitInput:string) = // 00000
    sequence
    |> List.map(fun card -> (cardToBinary card, card))
    |> List.windowed(5)
    |> List.choose(fun window -> // window is going to be the first window of length 5
        let bitWindow = (window |> List.map(fst)) |> convertBitsToString
        if bitWindow = bitInput
        then Some(window |> List.map(snd))
        else None)
    |> List.head
let printCard card =
    match card with 
        | Card(Rank rank, suit) -> sprintf "%d of %A" rank suit
        | Card(name, suit) -> sprintf "%A of %A" name suit

// the number of periods minus one is the index of the person
let countSecretCode (input:string) : int = 
    input.ToCharArray() |> Array.filter(fun c -> c = '.') |> Array.length

let rec bitsFromConsole (bits: int array) = 
    printfn "What do you think of this red card holder?"
    let input = Console.ReadLine()
    let count = countSecretCode(input)
    if count > 0 then
        bits.[count - 1] <- 1
        bitsFromConsole bits
    else 
        bits

[<EntryPoint>]
let main argv = 
    printfn "I am a magic genie stuck in the computer."
    printfn "Please tell me something about the audience!"
    printfn "I will read their characters and minds!"

    // System.Threading.Thread.Sleep(2000);

    printfn "These humans are too compicated."
    printfn "I need more information."

    printfn "Ask the first red card holders to stand..."
    let bits = bitsFromConsole [|0;0;0;0;0|] 

    printfn "Okay... I can do this... please wait while I assess their minds."

    // System.Threading.Thread.Sleep(2000);

    printfn "Got it. The cards are... wait for it..."

    // System.Threading.Thread.Sleep(2000);

    printfn "%A" (bits |> Array.toList |> convertBitsToString)

    bits 
        |> Array.toList 
        |> convertBitsToString 
        |> findChosenCards 
        |> List.map(printCard)
        |> List.iter(printfn "%s")

    printfn "Magic exists"
    0 // return an integer exit code