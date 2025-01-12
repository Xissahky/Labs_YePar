module ZadaniaFunkcje = 
    let sumaIter n = 
        let mutable suma = 0
        for i in 1..n do
            suma <- suma + 1
        suma

    let wynik = sumaIter 5
    printf "Suma iteracyjnie: %d\n" wynik


    let rec sumaRek n =
        if n <= 0 then 0
        else n + sumaRek (n-1)

    let wynik1 = sumaRek 5
    printf "Suma rekurencyjna: %d\n" wynik1


    let rec sumaRekTail n acc =
        if n <= 0 then acc
        else sumaRekTail (n-1) (acc + n)

    let wynik2 = sumaRek 5
    printf "Suma rekurencyjna ogonowa: %d\n" wynik2


    let rec silniaOgonowa n acc =
        if n <=1 then acc
        else silniaOgonowa (n-1) (n * acc)

    let wynik3 = silniaOgonowa 5 1
    printf "5! = %d\n" wynik3


    let rec fibRec n =
        if n <= 0 then 0
        elif n = 1 then 1
        else fibRec (n-1) + fibRec (n-2)

    
    let rec fibRecTail n a b =
        if n <= 0 then a
        elif n = 1 then b
        else fibRecTail (n - 1) b (a + b)
    
    let rec hanoi n fromRod toRod auxRod =
        if n = 1 then
            printfn "Przenieś dysk z %A na %A" fromRod toRod
        else
            hanoi (n - 1) fromRod auxRod toRod
            printfn "Przenieś dysk z %A na %A" fromRod toRod
            hanoi (n - 1) auxRod toRod fromRod

    let rec quickSort lista =
        match lista with
        | [] -> []
        | pivot :: tail ->
            let left = List.filter (fun x -> x < pivot) tail
            let right = List.filter (fun x -> x >= pivot) tail
            quickSort left @ [pivot] @ quickSort right



[<EntryPoint>]
let main argv =
    let wynik = ZadaniaFunkcje.fibRecTail 4 1 1
    printf "wynik fibbonaci: %d \n" wynik

    printf "Wynik hanoi to: "
    ZadaniaFunkcje.hanoi 3 "A" "C" "B"

    let lista1 = [9; 2; 3]
    let lista2 = [4; 8; 6]
    let wynik1 = ZadaniaFunkcje.quickSort (lista1 @ lista2) 
    printf "wynik quickSorta: %A \n" wynik1

    0  