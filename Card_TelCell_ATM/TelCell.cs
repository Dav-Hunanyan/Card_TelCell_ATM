using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class TelCell
    {
        public string Name { get; set; }
        public int Valid_money { get; private set; }

        public TelCell()
        {
            Name = "TelCell";
            Valid_money = 50000;
        }

        public void Set_money(Card card)
        {
            if (card.Using_Date < DateTime.Now)
            {
                Console.WriteLine("Your can't use your card...date isn't valid");
                return;
            }
            else if (card.Limited == false)
            {
                Console.WriteLine("Your card is limited");
                return;
            }

            Console.Write("Please enter your card ID: ");
            int card_id = int.Parse(Console.ReadLine());
            if (card_id != card.Card_Id)
            {
                Console.WriteLine("Wrong Id");
                return;
            }
            else
            {
                Console.Write("Enter money you want to set(0-50,000): ");
                int money = int.Parse(Console.ReadLine());
                if (money > Valid_money)
                {
                    Console.WriteLine("You can't set so much money");
                    return;
                }
                card.Money += money;
                Console.WriteLine("You succsed");
            }
        }


    }
}
