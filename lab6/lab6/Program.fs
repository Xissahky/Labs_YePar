type Person(name: string, age: int) =
    //pola prywatne
    let mutable privateAge = age

    //public
    //val mutable public Name:string

    //właściwości
    member this.Name=name

    //get i set
    member this.Age
        with get() = privateAge
        and set(value)=
            if value > 0 then
                privateAge <- value
            else 
                printfn "Wiek musi być liczbą dodatnią"

    //metoda
    member this.View() = 
        printfn "Witaj %s masz %d lat." this.Name this.Age

//klasa pohodna
type Student(name:string, age:int, nrAlbumu: string) = 
    inherit Person(name, age)

    //właściwość
    member this.nrAlbumu=nrAlbumu

    override this.View() =
        printfn "Witaj %s masz %d lat, nr albumu %s." this.Name this.Age this.nrAlbumu


//obiekt klasy
let person = Person("Huesos", 19)
person.View()

[<AbstractClass>]
type Shape()=
    abstract member Area: unit -> float

    member this.View()=
        printfn " to jest zwykla metoda klasy abstrakcyjnej"

type Circle(radius: float)=
    inherit Shape()

    override this.Area ()=
        System.Math.PI * radius * radius


type IShape =

    abstract member Area: float
    abstract member Area1: unit -> float

type Circle1(radius: float) =
    interface IShape with
        //właśiwości
        member this.Area = System.Math.PI * radius * radius

        //metoda
        member this.Area1 (): float = 
            System.Math.PI * radius * radius

//book
type Book(title: string, author:string, pages:int) =
    member this.Title=title
    member this.Author=author
    member this.Pages=pages

    //metoda
    member this.GetInfo() = 
        sprintf "Tytuł: %s, Author: %s, Liczba stron: %d" this.Title this.Author this.Pages
    
//user
type User(name: string) =

    //lista książek
    let borrowBooks = System.Collections.Generic.List<Book>()
    member this.Name=name

    member this.BorrowBook(book: Book) =
        borrowBooks.Add(book)
        printfn "idi nahuj, %s wypożyczł \"%s\"" this.Name book.Title

    member this.ReturnBook(book: Book) = 
        if borrowBooks.Contains(book) then
            borrowBooks.Remove(book)
            printf "Spasibo %s za \"%s\", idi nahuj" this.Name book.Title
        else
            printfn "Idi nahuj %s, ty nie pożyczał \"%s\"" this.Name book.Title

    //metoda do wyświetlenia listy wypożyczonych
    member this.ListBorrowBooks()=
        if borrowBooks.Count > 0 then 
            borrowBooks
            |> Seq.map(fun book -> book.GetInfo())
            |> String.concat "\n"
            |> printfn "Książki wypozyczone przez %s: \n%s" this.Name
        else
            printfn "%s nie ma wypożyczonych książek" this.Name

type Library() = 
    let mutable books = System.Collections.Generic.List<Book>()

    member this.AddBook(book: Book) = 
        books.Add(book)
        printfn "+ \"%s\"" book.Title

    member this.RemoveBook(book: Book) = 
        if books.Contains(book) then 
            books.Remove(book)
            printfn "Idi anhuj f#"
        else
            printfn "Nie ma takiej książki"
    
    member this.ListBook() =
        if books.Count > 0 then 
            books
            |> Seq.map(fun book -> book.GetInfo())
            |> String.concat "\n"
            |> printfn "Książki w bibliotece: \n%s" 
        else
            printfn "W bibliotece nie ma książek"
    
let main()=
