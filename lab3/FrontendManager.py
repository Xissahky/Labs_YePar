from Employee import Employee
from EmployeeManager import EmployeeManager

class FrontendManager:
    def __init__(self):
        self.manager = EmployeeManager()

    def validate_admin_login(self):
        username = input("Podaj login: ")
        password = input("Podaj hasło: ")
        return username == "admin" and password == "admin"

    def display_employees(self):
        employees = self.manager.get_all_employees()
        if employees:
            for emp in employees:
                print(f"Imię: {emp.name}, Wiek: {emp.age}, Wynagrodzenie: {emp.salary}")
        else:
            print("Brak pracowników w systemie.")

    def add_employee(self):
        name = input("Podaj imię i nazwisko: ")
        age = input("Podaj wiek: ")
        salary = input("Podaj wynagrodzenie: ")
        if not age.isdigit() or not salary.replace('.', '', 1).isdigit():
            print("Nieprawidłowe dane. Spróbuj ponownie.")
            return
        self.manager.add_employee(Employee(name, int(age), float(salary)))
        print(f"Pracownik {name} został dodany.")

    def remove_employees_by_age_range(self):
        min_age = input("Podaj minimalny wiek: ")
        max_age = input("Podaj maksymalny wiek: ")
        if not min_age.isdigit() or not max_age.isdigit():
            print("Nieprawidłowe dane. Spróbuj ponownie.")
            return
        self.manager.remove_employees_by_age_range(int(min_age), int(max_age))
        print(f"Pracownicy w przedziale wiekowym {min_age}-{max_age} zostali usunięci.")

    def update_salary(self):
        name = input("Podaj imię i nazwisko pracownika: ")
        salary = input("Podaj nowe wynagrodzenie: ")
        if not salary.replace('.', '', 1).isdigit():
            print("Nieprawidłowe dane. Spróbuj ponownie.")
            return
        if self.manager.update_employee_salary(name, float(salary)):
            print(f"Wynagrodzenie dla {name} zostało zaktualizowane.")
        else:
            print(f"Pracownik o imieniu {name} nie został znaleziony.")

    def run(self):
        if not self.validate_admin_login():
            print("Nieprawidłowy login lub hasło. Dostęp zabroniony.")
            return

        while True:
            print("\n1. Dodaj pracownika")
            print("2. Wyświetl wszystkich pracowników")
            print("3. Usuń pracowników w przedziale wiekowym")
            print("4. Zaktualizuj wynagrodzenie pracownika")
            print("5. Wyjdź")
            choice = input("Wybierz opcję: ")

            if choice == "1":
                self.add_employee()
            elif choice == "2":
                self.display_employees()
            elif choice == "3":
                self.remove_employees_by_age_range()
            elif choice == "4":
                self.update_salary()
            elif choice == "5":
                print("Wyjście z systemu.")
                break
            else:
                print("Nieprawidłowy wybór. Spróbuj ponownie.")