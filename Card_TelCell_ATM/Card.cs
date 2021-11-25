using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Card
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public int Password { get; private set; }
        public int Card_Id { get; private set; }
        public DateTime Using_Date { get; private set; }

        public int Money { get; set; }

        public bool Limited { get; set; }
        public string Type { get; private set; }

        public Card(string name, string surname, int password, int id, DateTime date, string type)
        {
            Name = name;
            Surname = surname;
            Password = password;
            Card_Id = id;
            Using_Date = date;
            Limited = true;
            Money = 10000;
            Type = type;
        }

    }
}
