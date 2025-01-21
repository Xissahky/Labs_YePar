// Zadanie 1
let count (input: string) =
    let words = input.Split([|' '; '\t'; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    let wordCount = words.Length
    let charCount = input.Replace(" ", "").Length
    printfn "Liczba słów: %d" wordCount
    printfn "Liczba znaków (bez spacji): %d" charCount

// Zadanie 2
let isPalindrome (input: string) =
    let normalized = input.ToLower().Replace(" ", "").Replace("\t", "").Replace("\n", "")
    normalized = (normalized |> Seq.toArray |> Array.rev |> System.String.Concat)
let checkPalindrome () =
    printf "Podaj tekst: "
    let input = System.Console.ReadLine()
    if isPalindrome input then
        printfn "Podany tekst jest palindromem."
    else
        printfn "Podany tekst nie jest palindromem."

// Zadanie 3
let removeDuplicates (input: string) =
    let words = input.Split([|' '; '\t'; '\n'|], System.StringSplitOptions.RemoveEmptyEntries)
    let uniqueWords = words |> Seq.distinct |> Seq.toArray
    printfn "Lista unikalnych słów: %A" uniqueWords

// Przykładowe wywołania funkcji
[<EntryPoint>]
let main argv =
    printf "Podaj tekst do analizy (liczba słów i znaków): "
    let text = System.Console.ReadLine()
    count text

    checkPalindrome()

    printf "Podaj słowa oddzielone spacjami (do usunięcia duplikatów): "
    let inputWords = System.Console.ReadLine()
    removeDuplicates inputWords

    0 