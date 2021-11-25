using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm1 = new ATM("Master");
            ATM atm2 = new ATM("Visa");
            TelCell telCell1 = new TelCell();
            List<Card> cards = new List<Card>();
            List<ATM> atms = new List<ATM>();
            atms.Add(atm1);
            atms.Add(atm2);
            List<TelCell> telCells = new List<TelCell>();
            telCells.Add(telCell1);
            do
            {
                Command: Console.WriteLine("Please choose command");
                Console.Write("1.Create 2.Use  3.Exit : ");
                string command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.WriteLine("1.Card 2.ATM 3.Telcell");
                        string creat = Console.ReadLine();
                        switch (creat)
                        {
                            case "1":
                                Random random;
                                Console.Write("Name: ");
                                string name = Console.ReadLine();
                                Console.Write("Surname: ");
                                string surname = Console.ReadLine();
                                Password_: Console.Write("Password(4 numbers): ");
                                int password = int.Parse(Console.ReadLine());
                                if (password < 1000 || password > 9999)
                                {
                                    Console.WriteLine("Invalid Password");
                                    goto Password_;
                                }
                                Id: random = new Random();
                                int id = random.Next(100000, 999999);
                                for (int i = 0; i < cards.Count; i++)
                                {
                                    if (id == cards[i].Card_Id)
                                    {
                                        goto Id;

                                    }
                                }
                                DateTime date = new DateTime(2022, 5, 5);
                                Type: Console.WriteLine("Choose type 1.Visa 2.Master");
                                int choose = int.Parse(Console.ReadLine());
                                string cardtype;
                                if (choose == 1)
                                {
                                    cardtype = "Visa";
                                    cards.Add(new Card(name, surname, password, id, date, cardtype));

                                }
                                else if (choose == 2)
                                {
                                    cardtype = "Master";
                                    cards.Add(new Card(name, surname, password, id, date, cardtype));

                                }
                                else
                                {
                                    goto Type;
                                }


                                break;
                            case "2":
                                Console.WriteLine("Choose ATM type");
                                Console.WriteLine("1.Visa 2.Master");
                                string type = Console.ReadLine();
                                if (type == "1")
                                {
                                    atms.Add(new ATM("Visa"));
                                    Console.WriteLine("Succsed");

                                }
                                else if (type == "2")
                                {
                                    atms.Add(new ATM("Master"));
                                    Console.WriteLine("Succsed");

                                }
                                else
                                {
                                    Console.WriteLine("Wrong");
                                    goto Command;
                                }

                                break;
                            case "3":
                                telCells.Add(new TelCell());
                                Console.WriteLine("Succsed");
                                break;

                            default:
                                goto Command;

                        }
                        break;
                    case "2":
                        Console.WriteLine("Select card");
                        for (int i = 0; i < cards.Count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + cards[i].Name + " " + cards[i].Surname);
                        }
                        int cardnumber = int.Parse(Console.ReadLine());
                        if (cardnumber > cards.Count)
                        {
                            Console.WriteLine("There is no so many cards");
                            goto Command;

                        }
                        Console.WriteLine("Name." + cards[cardnumber - 1].Name + "  Surname." + cards[cardnumber - 1].Surname + "  Card type" + cards[cardnumber - 1].Type);
                        Console.WriteLine("Password." + cards[cardnumber - 1].Password + "  Id." + cards[cardnumber - 1].Card_Id + "  Money." + cards[cardnumber - 1].Money + "$");
                        if (cards[cardnumber - 1].Limited == false)
                        {
                            Console.WriteLine("Your card is limited");
                            break;
                        }
                        else if (cards[cardnumber - 1].Using_Date < DateTime.Now)
                        {
                            Console.WriteLine("Your card date is invalid");
                            break;
                        }
                        Console.WriteLine("Do you need 1.ATM 2.Telcell");
                        int command1 = int.Parse(Console.ReadLine());
                        switch (command1)
                        {
                            case 1:
                                for (int i = 0; i < atms.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + "." + atms[i].Card_Type);
                                }
                                Atm: Console.Write("Select ATM: ");
                                int atm = int.Parse(Console.ReadLine());
                                if (atm > atms.Count)
                                {
                                    Console.WriteLine("Choose right");
                                    goto Atm;
                                }
                                atms[atm - 1].Give_money(cards[cardnumber - 1]);
                                break;
                            case 2:
                                for (int i = 0; i < telCells.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + "." + telCells[i].Name);
                                }
                                Telcell: Console.Write("Select TelCell: ");
                                int telcell = int.Parse(Console.ReadLine());
                                if (telcell > telCells.Count)
                                {
                                    Console.WriteLine("Choose right");
                                    goto Telcell;
                                }
                                telCells[telcell - 1].Set_money(cards[cardnumber - 1]);
                                break;
                            default:
                                goto Command;
                        }

                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Wrong command");
                        goto Command;
                }
                Console.WriteLine();
              
            } while (true);

        }
    }
}
