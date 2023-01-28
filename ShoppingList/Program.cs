// See https://aka.ms/new-console-template for more information

var badWords = new List<string>() { "dupa", "pupa" };

var shoppingList = new List<string>();

shoppingList.Add("Apple");
shoppingList.Add("Orange");
shoppingList.Add("Beer 0%");
shoppingList.Add("Wine 0%");

string? error = null;

while (true) 
{
    Console.Clear();
    Console.WriteLine("Shopping List");
    Console.WriteLine("----------------------------");
    for (int index = 0; index < shoppingList.Count; index++)
    {
        Console.WriteLine((index + 1) + ". " + shoppingList[index]);
    }
    Console.WriteLine("----------------------------");
    Console.WriteLine("Jeśli chcesz dodać produkt wybierz 1, jeśli chcesz usunąć produkt wybierz 2, jeśli chcesz wyłączyć listę wybierz 3");

    if (error != null)
    {
        Console.WriteLine("Błąd: " + error);
        error = null;
    }

    var numberOfAction = Console.ReadLine();

    if (numberOfAction == "1")
    {
        Console.WriteLine("Wpisz nazwę kolejnego produktu:");
        var newItem = Console.ReadLine();

        for (int index = 0; index < badWords.Count; index++)
        {
            if (newItem.Replace(" ", "").ToLower().Contains(badWords[index]))
            {
                error = "Nieładnie!";
            }
        }
        if (error == null)
        {
            newItem = newItem.Trim();

            shoppingList.Add(newItem);
        }

    }
    else if (numberOfAction == "2")
    {
        
        Console.WriteLine("Wpisz numer produktu, który chcesz usunąć:");
        string newItemRemove = Console.ReadLine();
        int numberRemove = int.Parse(newItemRemove);

        if (numberRemove <= shoppingList.Count)
        {

            shoppingList.RemoveAt(numberRemove - 1);
        }
        else
        {
            error = "Podaj właściwy numer";
        }

       
    }
    else  if  (numberOfAction == "3")
    {
        Console.Clear();
        break;

    }
    else
    {
        error = "Niepoprawna opcja.";
    }
}




// Shopping List
// 1. Apple
// ...
// 4. Wine
// ------------
// Wpisz nazwę kolejnego produktu: __

// Shopping List
// 1. Apple
// ...
// 4. Wine
// ------------
// Wpisz nazwę kolejnego produktu: Czipsy

// Shopping List
// 1. Apple
// ...
// 4. Wine
// 5. Czipsy
// ------------
// Wpisz nazwę kolejnego produktu: 