// Learn more about F# at http://fsharp.org

open System

// discriminating union
type Value = 
    | Ace
    | King
    | Queen
    | Jack
    | Rank of int
    
// discriminating union
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
let getWindowAsBinary (length) =
  sequence |> List.map(cardToBinary) |> List.windowed(length)

[<EntryPoint>]
let main argv = 
    printfn "%A" (getWindowAsBinary 5)

    printfn "Magic exists"
    0 // return an integer exit code