# from abc import ABC, abstractmethod
#
# class Zwierze(ABC):
#     @abstractmethod
#     def dzwiek(self):
#         pass
#
#
# class Lew(Zwierze):
#     def dzwiek(self):
#         return "Lew wydaje RArararararr"
#
# lew = Lew()
# print(lew.dzwiek())
# class Pojazd:
#     def __init__(self, marka):
#         self.marka=marka
#
#     def opis(self):
#         return f"Pojazd marki: {self.marka}"
#
#
#
#
# class Auto(Pojazd):
#     def __init__(self, marka, model, rok):
#         super().__init__(marka)
#         self.model=model
#         self.rok=rok
#
#     def opis(self):
#         return f"{self.marka} {self.model} {self.rok}"
#
#
# #tworzenie obiektu
# auto1 = Auto('toyota', 'corolla', 2024)
# print(auto1.opis())


# from Employee import Employee
# from EmployeeManager import EmployeeManager
from FrontendManager import FrontendManager

# siemion=EmployeeManager("Siemion", "Sidoranka", 19, 0, [])
# siemion.addNewEmployee("Hesos", "Dzekowicz",130, 100)
# siemion.addNewEmployee("Hesos2", "Dzekowicz",129, 99)
# siemion.addNewEmployee("Hesos3", "Dzekowicz",64, 99)

# siemion.ageCheckEmployee(67)
# siemion.updateSalary("Hesos3", "Dzekowicz", 98)
# print(siemion.showListOfEmployees())
# print(siemion.findMeEmployee("Hesos3", "Dzekowicz"))

frontend = FrontendManager()
frontend.run()