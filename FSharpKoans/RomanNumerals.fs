module RomanNumerals =

    type Glyph = string * int

    let I = "I", 1
    let IV = "IV", 4
    let V = "V", 5
    let IX = "IX", 9
    let X = "X", 10

    let alphabet = [I; IV; V; IX; X]


    let getGlyphFromString (romanNumeral:string) =
        let twoLetterMatch = List.tryFind (fun x -> (fst x) = romanNumeral.[0..1]) alphabet
        let oneLetterMatch = List.tryFind (fun x -> (fst x) = romanNumeral.[0..0]) alphabet
        match (twoLetterMatch, oneLetterMatch) with
        | Some x, _ -> x
        | None, Some x -> x
        | _ -> failwith "Invalid Numeral"
            

    let rec private fromRomanNumeralRecursive baseNumber (romanNumeral:string) =
        match romanNumeral.Length with
        | 0 -> baseNumber
        | _ ->
            let currentSymbol, currentNumber = getGlyphFromString romanNumeral
            fromRomanNumeralRecursive (baseNumber + currentNumber) (romanNumeral.Substring currentSymbol.Length)

    let fromRomanNumeral = fromRomanNumeralRecursive 0