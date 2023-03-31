using ShoppingList.Models;

var shoppingList = new List<Item>();
var badWords = new List<string>() { "dupa", "pupa" };
string? error = null;

while (true)
{
    Console.Clear();
    Console.WriteLine("Lista zakupów");
    Console.WriteLine("----------------------------");
    for (int index = 0; index < shoppingList.Count; index++)
    {
        var item = shoppingList[index];
        var isDone = item.IsDone;
        //var markAsDoneDate = item.MarkAsDoneDate;

        Console.WriteLine((index + 1) + ". " + item.Name + " ");

    }
    Console.WriteLine("----------------------------");
    Console.WriteLine("Produkty kupione");
    Console.WriteLine("----------------------------");

    for (int index = 0; index < shoppingList.Count; index++)    //kupione
    {
        var item = shoppingList[index];
        var isDone = item.IsDone;
        var markAsDoneDate = item.MarkAsDoneDate;

        if (markAsDoneDate != null)
        {
            Console.WriteLine((index + 1) + ". " + (isDone ? "[X] " : "[O] ") + item.Name + " " + markAsDoneDate);
        }
        else
        {
            Console.WriteLine("");
        }
        //index jako np number, intex bez 0, 
    }
    Console.WriteLine("----------------------------");
    Console.WriteLine("Produkty ważne");
    Console.WriteLine("----------------------------");
    for (int index = 0; index < shoppingList.Count; index++)    //ważne
    {
        var item = shoppingList[index];
        var isImportant = item.IsImportant;

        if (isImportant != false)
        {
            Console.WriteLine((index + 1) + ". " + item.Name + " " + (isImportant ? " - PAMIĘTAJ O TYM!" : ""));
        }
        else
        {
            Console.WriteLine("");
        }

    }
    Console.WriteLine("----------------------------");
    Console.WriteLine("Produkty nieważne");
    Console.WriteLine("----------------------------");
    for (int index = 0; index < shoppingList.Count; index++)    //nieważne
    {
        var item = shoppingList[index];
        var isImportant = item.IsImportant;

        if (isImportant != true)
        {
            Console.WriteLine((index + 1) + ". " + item.Name + " " + (isImportant ? "" : " - LEPIEJ NIE KUPUJ ;)"));
        }
        else
        {
            Console.WriteLine("");
        }

    }

    Console.WriteLine("----------------------------");
    Console.WriteLine("Wybierz odpowiedni numer: 1 - dodaj produkt," +
            "2 - usuń produkt, " +
            "3 - zaznacz jako kupiony, " +
            "4 - zaznacz jako niekupiony, " +
            "5 - zaznacz jako ważny, " +
            "6 - zaznacz jako nieważny, " +
            "0 - zamknij listę zakupów");

    if (error != null)
    {
        Console.WriteLine("Błąd: " + error);
        error = null;
    }

    var numberOfAction = Console.ReadLine();

    if (numberOfAction == "1")
    {
        Console.WriteLine("Wpisz nazwę kolejnego produktu:");
        var newItemName = Console.ReadLine();

        for (int index = 0; index < badWords.Count; index++)
        {
            if (newItemName.Replace(" ", "").ToLower().Contains(badWords[index]))
            {
                error = "Nieładnie!";
            }
        }
        if (error == null)
        {
            newItemName = newItemName.Trim();

            var newItem = new Item(newItemName);

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
    else if (numberOfAction == "3")
    {
        Console.WriteLine("Wpisz numer produktu, który chcesz zaznaczyć:");
        string newItemDone = Console.ReadLine();
        int numberDone = int.Parse(newItemDone);

        if (numberDone <= shoppingList.Count)
        {

            shoppingList[numberDone - 1].MarkAsDone();

        }
        else
        {
            error = "Podaj właściwy numer";
        }

    }
    else if (numberOfAction == "4")
    {
        Console.WriteLine("Wpisz numer produktu, który chcesz odznaczyć:");
        string newItemNotDone = Console.ReadLine();
        int numberNotDone = int.Parse(newItemNotDone);

        if (numberNotDone <= shoppingList.Count)
        {

            shoppingList[numberNotDone - 1].MarkAsNotDone();
        }
        else
        {
            error = "Podaj właściwy numer";
        }

    }
    else if (numberOfAction == "5")
    {
        Console.WriteLine("Wpisz numer produktu, który chcesz oznaczyć jako ważny:");
        string newItemImportant = Console.ReadLine();
        int numberImportant = int.Parse(newItemImportant);

        if (numberImportant <= shoppingList.Count)
        {

            shoppingList[numberImportant - 1].ImportantProduct();
        }
        else
        {
            error = "Podaj właściwy numer";
        }

    }
    else if (numberOfAction == "6")
    {
        Console.WriteLine("Wpisz numer produktu, który chcesz oznaczyć jako nieważny:");
        string newItemNotImportant = Console.ReadLine();
        int numberNotImportant = int.Parse(newItemNotImportant);

        if (numberNotImportant <= shoppingList.Count)
        {

            shoppingList[numberNotImportant - 1].NotImportantProduct();
        }
        else
        {
            error = "Podaj właściwy numer";
        }
    }

    else if (numberOfAction == "0")
    {
        Console.Clear();
        break;

    }
    else
    {
        error = "Niepoprawna opcja.";
    }
}

