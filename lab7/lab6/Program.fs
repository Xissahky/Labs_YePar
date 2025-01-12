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
let person = Person("Heos", 19)
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









//Zadanie 1: System do zarządzania biblioteką
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
        printfn "%s wypozyczyl ksiazke:  \"%s\"" this.Name book.Title

    member this.ReturnBook(book: Book) = 
        if borrowBooks.Contains(book) then
            borrowBooks.Remove(book)
            printf "%s zwrócił ksiazke \"%s\"" this.Name book.Title
        else
            printfn "%s nie ma ksiazki do wrócenia \"%s\"" this.Name book.Title

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
            printfn "Książka \"%s\" została usunięta" book.Title
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

let main() = 
    let library = Library()
    let user = User("Ala")

    let book1 = Book("ksiazka1", "Autor1", 321)
    let book2 = Book("ksiazka2", "Autor3", 321)
    let book3 = Book("ksiazka3", "Autor3", 321)

    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)

    library.ListBooks()

    user.BorrowBook(book1)
    user.BorrowBook(book2)

    library.ListBooks()

    user.ListBorrowBooks()

    user.ReturnBook(book1)
    user.ListBorrowBooks()

main()










//Zadanie 2: System BankAccount
//bankAccount
type BankAccount(accountNumber: string, Balance: float) =
    let mutable privateBalance = Balance

    member this.AccountNumber = accountNumber
    member this.Balance
        with get() = privateBalance
        and set(value) = 
            if value > 0.0 then 
                privateBalance <- value
            else
                printfn "Balance musi byc dodatnim"
    
    member this.Deposit(amount: float) =
        if amount <= 0.0 then 
            printfn "Kwota wpłaty musi być >0"
        else
            this.Balance <- this.Balance + amount

    member this.Withdraw(amount: float) =
        if amount <= 0.0 then 
            printfn "Kwota wypłaty musi być >0"
        elif amount > this.Balance then
            printfn "Nie ma wystarczających środków na koncie :("
        else
            this.Balance <- this.Balance - amount

//bank
type Bank() =
    let mutable accounts = System.Collections.Generic.Dictionary<string, BankAccount>()

    member this.CreateAccount(Number: string, Balance: float) = 
        if accounts.ContainsKey(Number) then
            printfn "Konto o numerze \"%s\" już istnieje" Number
        else
            let account=BankAccount(Number, Balance) 
            accounts.Add(Number, account)
            printfn "Konto numer \"%s\" został dodany" account.AccountNumber
    
    member this.GetAccount(Number: string) = 
        if accounts.ContainsKey(Number) then
            accounts.[Number]
        else
            printfn "Konto o numerze \"%s\" już istnieje" Number

    member this.UpdateAccount(Number: string, NewBalance: float) =
        let account = this.GetAccount(accountNumber)
        account.Balance <- NewBalance

    member this.DeleteAccount(Number: string) = 
        if accounts.ContainsKey(Number) then
            accounts.Remove(Number)
            printfn "Konto o numerze \"%s\" zastał usunięty" Number
        else
            printfn "Nie znaleziono konta o podanym numerze."

let mainBank() =
    let bank = Bank()

    
    let account1 = bank.CreateAccount("12345", 1000.0)
    let account2 = bank.CreateAccount("67890", 500.0)
    let account3 = bank.CreateAccount("67123", 260.0)

    account1.Deposit(200.0)
    account2.Withdraw(100.0)

    bank.UpdateAccount("12345", 1500.0)
    //musi być komunikat o błędzie
    bank.UpdateAccount("67124", 1500.0)

    let retrievedAccount = bank.GetAccount("12345")
    
    bank.DeleteAccount("67890")
