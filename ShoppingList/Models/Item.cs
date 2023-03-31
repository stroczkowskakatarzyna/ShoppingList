using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingList.Models;

internal class Item
{
    public Item(string name)
    {
        Name = name;
        IsDone = false;
        IsImportant = false;

    }

    public void MarkAsDone()
    {
        IsDone = true;
        MarkAsDoneDate = DateTime.Now;

    }

    public void MarkAsNotDone()
    {

        IsDone = false;
        MarkAsDoneDate = null;
    }


    public void ImportantProduct()
    {

        IsImportant = true;

    }

    public void NotImportantProduct()
    {

        IsImportant = false;


    }

    public string Name { get; }
    public bool IsDone { get; private set; }
    public bool IsImportant { get; private set; }
    public DateTime? MarkAsDoneDate { get; private set; }
}


//enum który mówi o statusach
