// let x = 10
// let text = "Jan"
// let y = 10.3
// printfn "Wartość x = %d" x
// printfn "Wartość y = %.2f" y
// printfn "Wartość test = %s" text


open System

// printfn "Podaj Imię: "
// let name = Console.ReadLine()

// printfn "Witaj, %s" name


// let pi = 3.14159265358797323846
// let liczba = pi * 2.0


// let x = 5
// // + - * / > < <= >= % a<>b && || not
// if x > 0 then
//     printfn "liczba dodatnia"
// else
//     printfn "liczba ujemna"


// let lista = [1;2;3]
// let nowalista = 0:: lista

// for i = 1 to 5 do
//     printfn "Wartość %d" i

// for i = 5 downto 1 do
//     printfn "Wartość %d" i


// let mutable x = 1

// while x < 5 do
//     printfn "Wartość %d" x
//     x <- x+1


// type Osoba = {
//         Imie: string
//         Wiek: int
// }

// let osoba1 = {Imie = "Jan"; Wiek = 24}
// printfn "Imie: %s, Wiek: %d" osoba1.Imie osoba1.Wiek


let str = "3.14"
let liczba = System.Double.TryParse(str)

printfn "Podaj liczbę całkowitą"
let input = System.Console.ReadLine()
let liczba1 = System.Int32.Parse(input)

// let x = 3
// match x with    
//     | 1 -> "Jeden"
//     | 2 -> "Dwa"
//     | 3 -> "Trzy"
//     | _ -> "Inna"


let age = 20
match age with
    | x when x < 18 -> printfn "osoba niepełnoletnia"
    | x when x >= 18  && x <= 65-> printfn "osoba pełnoletnia"
    | _ -> printfn "osoba seniorska"


let rec suma n =
    if n <= 0 then 0
    else n + suma(n-1)

printfn "Suma liczb od 1 do 5= %d" (suma 5)


let tablica = [|10;20;30|]
for i = 0 to tablica.Length - 1 do
    printfn "element %d: %d" i tablica[i]


//// rekurencja ogonowa n = 5 suma = suma + n
let sumRekTail n =
    let rec loop n acc = 
        if n <= 0 then acc
        else loop (n-1) (acc+n) //rekurencja ogonowa
    loop n 0 // wywołanie funkcji pomocniczej


