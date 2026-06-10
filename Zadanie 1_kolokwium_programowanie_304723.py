import re

class Helpers:
    def add_spaces_before_capitals(self, text):
        result = re.sub(r'(?<=[a-z])(?=[A-Z])', ' ', text)
        return result

helpers = Helpers()

value = input("Podaj wartość: ")
result = helpers.add_spaces_before_capitals(value)
print("Wynik to:")
print(result)

