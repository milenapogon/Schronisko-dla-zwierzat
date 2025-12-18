class Animal:
    def __init__(self, name, species):
        self.name = name
        self.species = species
        self.adopted = False


class Volunteer:
    def __init__(self, name):
        self.name = name


class Adoption:
    def __init__(self, animal, volunteer):
        self.animal = animal
        self.volunteer = volunteer


animals = []
volunteers = []
adoptions = []

while True:
    print("\n SCHRONISKO DLA ZWIERZĄT ")
    print("1. Dodaj zwierzę")
    print("2. Dodaj wolontariusza")
    print("3. Adoptuj zwierzę")
    print("4. Lista zwierząt")
    print("0. Wyjście")

    choice = input("Wybierz: ")

    if choice == "1":
        name = input("Imię pupila: ")
        species = input("Gatunek: ")
        animals.append(Animal(name, species))
        print("Pupil dodany.")

    elif choice == "2":
        name = input("Imię wolontariusza: ")
        volunteers.append(Volunteer(name))
        print("Wolontariusz dodany.")

    elif choice == "3":
        if not animals or not volunteers:
            print("Brak zwierząt lub wolontariuszy.")
        else:
            print("Zwierzęta:")
            for i, a in enumerate(animals):
                status = "adoptowane" if a.adopted else "dostępne"
                print(i, a.name, "-", a.species, "-", status)

            index = int(input("Podaj numer zwierzęcia: "))

            if animals[index].adopted:
                print("To zwierzę jest już adoptowane.")
            else:
                volunteer = volunteers[0]
                animals[index].adopted = True
                adoptions.append(Adoption(animals[index], volunteer))
                print("Adopcja zakończona sukcesem!")

    elif choice == "4":
        for a in animals:
            status = "adoptowane" if a.adopted else "dostępne"
            print(a.name, "-", a.species, "-", status)

    elif choice == "0":
        print("Dziękujemy, do widzenia!")
        break

    else:
        print("Nieprawidłowy wybór")
