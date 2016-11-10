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

let suitToBinary card = 
    match card with 
    | Spades
    | Clubs -> 0
    | Diamonds
    | Hearts -> 1
let printDeck = 
    [
        for s in [Clubs; Hearts; Spades; Diamonds] do 
            for v in [Ace; King; Queen; Jack] do 
                yield Card (v, s)
            for r in [2..10] do 
                yield Card (Rank r, s)
    ]
let findWindow (bits) =
  [
      
  ]

[<EntryPoint>]
let main argv = 
    // printfn "Tell me a suit and I will tell you the binary representation"
    // let s = Console.ReadLine(); // Clubs
    // let binarySuit = stringToSuit >> suitToBinary
    // printfn "%A" (binarySuit s) // 0

    printfn "Tell me five binary digits and I will tell you whether there is a matching window" // 00000
    printfn "%A" // true

    // printfn "Tell me something about the people who chose the cards:"
    // let window = Console.ReadLine();
    // 11111     
    // printfn "%s" window
    // printfn "The cards that they card are these:"
    // Jack of Hearts
    // Two of Clubs
    // Three of Diamonds
    // Seven of Spades
    // Nine of Hearts

    printfn "Magic exists"
    0 // return an integer exit code