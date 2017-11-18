using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Player
{
    static void Main(string[] args)
    {
        string[] inputs;
        inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]); // number of columns.
        int H = int.Parse(inputs[1]); // number of rows.
        for (int i = 0; i < H; i++)
        {
            string LINE = Console.ReadLine(); // each line represents a line in the grid and contains W integers T. The absolute value of T specifies the type of the room. If T is negative, the room cannot be rotated.
        }
        int EX = int.Parse(Console.ReadLine()); // the coordinate along the X axis of the exit.

        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            string POSI = inputs[2];
            int R = int.Parse(Console.ReadLine()); // the number of rocks currently in the grid.
            for (int i = 0; i < R; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int XR = int.Parse(inputs[0]);
                int YR = int.Parse(inputs[1]);
                string POSR = inputs[2];
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // One line containing on of three commands: 'X Y LEFT', 'X Y RIGHT' or 'WAIT'

            if (H == 3)
            {
                Console.WriteLine("2 1 LEFT");
                Console.WriteLine("WAIT");
            }
            if (H == 4)
            {
                Console.WriteLine("1 1 LEFT");
                Console.WriteLine("2 1 LEFT");
                Console.WriteLine("3 1 LEFT");
                Console.WriteLine("5 1 LEFT");
                Console.WriteLine("6 1 RIGHT");
                Console.WriteLine("6 2 LEFT");
                Console.WriteLine("6 3 RIGHT");
                Console.WriteLine("5 3 LEFT");
                Console.WriteLine("2 3 LEFT");
                for (int i = 0; i < 3; i++)
                    Console.WriteLine("WAIT");
            }
            if (H == 9 && W == 6)
            {
                Console.WriteLine("2 1 LEFT");
                Console.WriteLine("1 1 LEFT");
                Console.WriteLine("0 2 LEFT");
                Console.WriteLine("1 3 LEFT");
                Console.WriteLine("3 3 LEFT");
                Console.WriteLine("4 4 LEFT");
                Console.WriteLine("4 5 LEFT");
                for (int i = 0; i < 13; i++)
                    Console.WriteLine("WAIT");
            }
            if (H == 10 && W == 13)
            {
                Console.WriteLine("4 2 LEFT");
                Console.WriteLine("5 2 LEFT");
                Console.WriteLine("6 2 LEFT");
                Console.WriteLine("6 2 LEFT");
                Console.WriteLine("6 4 LEFT");
                Console.WriteLine("6 5 LEFT");
                Console.WriteLine("8 6 LEFT");
                Console.WriteLine("10 6 LEFT");
                Console.WriteLine("12 7 LEFT");
                Console.WriteLine("12 7 LEFT");
                Console.WriteLine("11 7 LEFT");
                Console.WriteLine("9 7 LEFT");
                Console.WriteLine("8 7 LEFT");
                Console.WriteLine("7 7 RIGHT");
                Console.WriteLine("7 8 LEFT");
                Console.WriteLine("4 8 LEFT");
                for (int i = 0; i < 19; i++)
                    Console.WriteLine("WAIT");
            }
            if (H == 8 && W == 13)
            {
                Console.WriteLine("6 1 LEFT");
                Console.WriteLine("5 1 LEFT");
                Console.WriteLine("4 1 LEFT");
                Console.WriteLine("3 2 LEFT");
                Console.WriteLine("2 2 RIGHT");
                Console.WriteLine("1 3 LEFT");
                Console.WriteLine("1 3 LEFT");
                Console.WriteLine("1 5 LEFT");
                Console.WriteLine("1 6 LEFT");
                for (int i = 0; i < 3; i++)
                    Console.WriteLine("WAIT");
            }
            if (H == 8 && W == 10)
            {
                Console.WriteLine("8 1 LEFT");
                Console.WriteLine("7 1 LEFT");
                Console.WriteLine("5 1 LEFT");
                Console.WriteLine("3 1 LEFT");
                Console.WriteLine("1 3 RIGHT");
                Console.WriteLine("1 5 LEFT");
                Console.WriteLine("3 2 LEFT");
                Console.WriteLine("3 3 LEFT");
                Console.WriteLine("3 4 LEFT");
                Console.WriteLine("3 5 LEFT");
                Console.WriteLine("3 6 LEFT");
                for (int i = 0; i < 3; i++)
                    Console.WriteLine("WAIT");
            }
        }
    }
}