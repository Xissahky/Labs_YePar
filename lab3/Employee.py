class Employee():
    def __init__(self, name, surname, age, salary):
        self.name=name
        self.surname=surname
        self.age=age
        self.salary=salary

    def to_dict(self):
        return {"name": self.name, "age": self.age, "salary": self.salary}

    @staticmethod
    def from_dict(data):
        return Employee(name=data["name"], age=data["age"], salary=data["salary"])


    def view(self):
        return f"Pracownik: \t{self.name + " " + self.surname} Wiek: \t{self.age} Salary: \t{self.salary}"