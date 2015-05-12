using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ByteParty
{
    static int getTheBit(byte position, byte number)
    {
        int nRightPosition = number >> position;
        int bit = nRightPosition & 1;
        return bit;
    }

    static byte SetBitsToZero(byte position, byte number)
    {
        int mask = ~(1 << position);
        int result = number & mask;
        return (byte)result;
    }

    static byte SetBitsToOne(byte position, byte number)
    {
        int mask = 1 << position;
        int result = number | mask;
        return (byte)result;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        //input and save n 8-bit unsigned integers in list
        List<byte> integers = new List<byte>();
        for (int i = 0; i < n; i++)
        {
            byte integer = byte.Parse(Console.ReadLine());
            integers.Add(integer);
        }

        //input and save commands to list of commands until "party over" is given
        string command = "";
        char separator = ' ';
        List<string[]> commands = new List<string[]>();

    again:
        while (command.ToLower() != "party over")
        {
            command = Console.ReadLine();

            if (command.ToLower() == "party over")
            {
                break;
            }

            string[] commandArr = command.Split(separator);

            if (int.Parse(commandArr[0]) < -1 || int.Parse(commandArr[0]) > 1 || int.Parse(commandArr[1]) < 0 || int.Parse(commandArr[1]) > 7)
            {
                goto again;
            }
            else
            {
                commands.Add(commandArr);
            }
        }

        //changing the bits of inserted 8-bit unsigned integers from list according to the commands from list
        for (int i = 0; i < commands.Count; i++)
        {
            string[] commandArr = commands[i];
            if (int.Parse(commandArr[0]) == -1)
            {
                for (int j = 0; j < integers.Count; j++)
                {
                    byte integer = integers[j];
                    if (getTheBit(byte.Parse(commandArr[1]), integer) == 0)
                    {
                        integers[j] = SetBitsToOne(byte.Parse(commandArr[1]), integer);
                    }
                    else
                    {
                        integers[j] = SetBitsToZero(byte.Parse(commandArr[1]), integer);
                    }
                }
            }
            else if (int.Parse(commandArr[0]) == 0)
            {
                for (int j = 0; j < integers.Count; j++)
                {
                    byte integer = integers[j];
                    integers[j] = SetBitsToZero(byte.Parse(commandArr[1]), integer);
                }
            }
            else
            {
                for (int j = 0; j < integers.Count; j++)
                {
                    byte integer = integers[j];
                    integers[j] = SetBitsToOne(byte.Parse(commandArr[1]), integer);
                }
            }
        }

        //printing the 8-bit unsigned integers from list after changes
        foreach (var integer in integers)
        {
            Console.WriteLine(integer);
        }
    }
}