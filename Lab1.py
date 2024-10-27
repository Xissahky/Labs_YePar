#Zadanie 1
def podzielPaczek(wagi, max_waga):
    for waga in wagi:
        if waga>max_waga:
            raise ValueError(f"Paczka o wadze {waga} przekraca max dozwolaną wagę kursu ({max_waga} kg).")
    wagi_sort = sorted(wagi, reverse=True)
    kursy =[]
    for waga in wagi_sort:
        dodano=False
        for kurs in kursy:
            if sum(kurs)+waga<=max_waga:
                kurs.append(waga)
                dodano=True
                break

        if not dodano:
            kursy.append([waga])
    return len(kursy), kursy


wagi=[20,5,15,10,10,7,8]
max_waga=25

#print(podzielPaczek(wagi, max_waga))

#liczba_kursow, kursy=podzielPaczek(wagi, max_waga)
#for i, kurs in enumerate(kursy, 1):
#    print(f"kurs {i}: {kurs} - suma wag: {sum(kurs)} kg")

#Zadanie 2
from collections import deque

G={
    '1':['2','3','5'],
    '2':['1','4'],
    '3':['1','5','6'],
    '4':['2','7'],
    '5':['1','3','7'],
    '6':['3','8'],
    '7':['4','5','8'],
    '8':['6','7']
}


def bfcs(G, start, end):
    queue = deque(start)
    while queue:
        path = queue.popleft()
        node = path[-1]
        if node == end:
            return path

        else:
            for adjacent in G.get(node, []):
                queue.append(list(path) + [adjacent])

#print(bfcs(G, '1', '8'))

#Zadanie 3

zadania=[[5, 15],[2,10],[3,8],[1,3]]


def optymalizacjaZadan(zadania):
    sorted_zadania = sorted(zadania, key=lambda x: x[1] / x[0], reverse=True)
    res_czas=0
     
    for zadanie in sorted_zadania:
        res_czas+=zadanie[0]
            
    return sorted_zadania, res_czas
#print(optymalizacjaZadan(zadania))

#Zadanie 4
#items=[[waga1,wartosc1], ....]
items=[[10,25],[5,8],[13,20],[15,28],[9,18],[4,16]]
max_waga_items=20

def plecak(items, max_waga_items):
    result = []
    res_money=0
    sorted_items = sorted(items, key=lambda x: x[1] / x[0], reverse=True)
    for item in sorted_items:
        if item[0]<=max_waga_items:
            result.append(item)
            max_waga_items-=item[0]
            res_money+=item[1]
            
    return res_money, result

# print(plecak(items, max_waga_items))

#Zadanie 5
