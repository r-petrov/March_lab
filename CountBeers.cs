using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CountBeers
{
    static void Main(string[] args)
    {
        string input = "";
        int beers = 0;
        int stacks = 0;
        char separator = ' ';

        for (int i = 0; i < 999; i++)
        {
        again:
            input = Console.ReadLine();
            if (input.ToLower() == "end")
            {
                break;
            }

            string[] inputArr = input.Split(separator);
            Console.WriteLine(string.Join, inputArr);
            int count = int.Parse(inputArr[0]);
            if (count >= 1 && count <= 99)
            {
                if (inputArr[1] == "beers")
                {
                    beers += count;
                }
                else if (inputArr[1] == "stacks")
                {
                    stacks += count;
                }
                else
                {
                    goto again;
                }
            }
            else
            {
                goto again;
            }
        }

        int stacksFromBeers = beers / 20;
        stacks += stacksFromBeers;
        beers %= 20;

        //Console.WriteLine("{0} stacks + {1} beers", stacks, beers);
        Console.WriteLine(stacks + " stacks " + beers + " beers");
    }
}
