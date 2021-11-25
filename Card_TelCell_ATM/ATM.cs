using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace ConsoleApp1
{
    class ATM
    {
        public string Card_Type { get; private set; }
        private int Money = 10000000;
        public ATM(string cardtype)
        {
            Card_Type = cardtype;
        }

        public void Give_money(Card card)
        {

            if (card.Type != Card_Type)
            {
                Console.WriteLine("This bancomad is reading only " + Card_Type);
                return;
            }
            else if (card.Using_Date < DateTime.Now)
            {
                Console.WriteLine("Your can't use your card...date isn't valid");
                return;
            }
            else if (card.Limited == false)
            {
                Console.WriteLine("Your card is limited");
                return;
            }
            else
            {
                int password;
                int count = 0;
                do
                {
                    Console.Write("Please enter your password: ");
                    password = int.Parse(Console.ReadLine());
                    if (card.Password != password)
                    {
                        Console.WriteLine("Wrong Password");
                        count++;
                    }


                } while (password != card.Password && count < 3);
                if (count == 3)
                {
                    card.Limited = false;
                    Console.WriteLine("Your card is limited");
                    return;
                }
                Console.Write("How much money you want to get: ");
                int money = int.Parse(Console.ReadLine());
                if (money > card.Money)
                {
                    Console.WriteLine("You havn't so much money on your card");
                    return;
                }
                else
                {
                    card.Money -= money;
                    Console.WriteLine("You succsed");
                }
            }
        }
    }
}
