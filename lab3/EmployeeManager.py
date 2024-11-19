import json
from functools import reduce

from Employee import Employee

class EmployeeManager(Employee):
    def __init__(self, file_path="employees.json"):
        self.file_path = file_path
        self.employees = self.load_employees()

    def load_employees(self):
        try:
            with open(self.file_path, "r") as file:
                data = json.load(file)
                return [Employee.from_dict(emp) for emp in data]
        except FileNotFoundError:
            return []

    def save_employees(self):
        with open(self.file_path, "w") as file:
            json.dump([emp.to_dict() for emp in self.employees], file, indent=4)

    def add_employee(self, employee: Employee):
        self.employees.append(employee)
        self.save_employees()

    def get_all_employees(self):
        return self.employees

    def remove_employees_by_age_range(self, min_age, max_age):
        self.employees = [emp for emp in self.employees if not (min_age <= emp.age <= max_age)]
        self.save_employees()

    def find_employee_by_name(self, name):
        for emp in self.employees:
            if emp.name.lower() == name.lower():
                return emp
        return None

    def update_employee_salary(self, name, new_salary):
        employee = self.find_employee_by_name(name)
        if employee:
            employee.salary = new_salary
            self.save_employees()
            return True
        return False