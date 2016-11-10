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
let PrintDeck = 
    [
        for s in [Clubs; Hearts; Spades; Diamonds] do 
            for v in [Ace; King; Queen; Jack] do 
                yield (v, s)
    ]

[<EntryPoint>]
let main argv = 
    printfn "%A" PrintDeck
    0 // return an integer exit code
