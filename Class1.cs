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

class Room
{
    int X = 0;
    int Y = 0;
    int type = 0;
    int baseType = 0;
    int index = 0;
    int[] trans;
    //string direct = "";
    //string from = "";
    bool EX = false;

    public Room(int x, int y, int t)
    {
        X = x;
        Y = y;
        baseType = t;
        type = t;
        //Console.WriteLine(X.ToString() + " " + Y.ToString()+ " " + baseType);

        switch (t)
        {
            case 0:
            case 1:
                trans = null;
                break;
            case 2:
            case 3:
                trans = new int[2] { 2, 3 };
                break;
            case 4:
            case 5:
                trans = new int[2] { 4, 5 };
                break;
            case 6:
            case 7:
            case 8:
            case 9:
                trans = new int[4] { 6, 7, 8, 9 };
                break;
            case 10:
            case 11:
            case 12:
            case 13:
                trans = new int[4] { 10, 11, 12, 13 };
                break;
        }
        if (baseType > 1)
            for (int i = 0; i < trans.Length; i++)
                if (trans[i] == baseType)
                    index = i;
    }

    public bool nextType()
    {
        if (baseType > 1)
        {
            index = (index + 1) % trans.Length;
            type = trans[index];
        }
        if (type == baseType)
            return false;
        return true;
    }

    public int[] getNextXY(string from)
    {
        switch ((type < 0) ? -type : type)
        {
            case 1:
            case 3:
            case 7:
            case 8:
            case 9:
            case 12:
            case 13:
                return new int[] { XI + 1, YI };
            case 2:
            case 6:
                return (from.Equals("RIGHT")) ? new int[] { XI, YI - 1 } : new int[] { XI, YI + 1 };
            case 4:
                return (from.Equals("RIGHT")) ? new int[] { XI + 1, YI } : new int[] { XI, YI - 1 };
            case 5:
                return (from.Equals("LEFT")) ? new int[] { XI + 1, YI } : new int[] { XI, YI + 1 };
            case 10:
                return new int[] { XI, YI - 1 };
            case 11:
                return new int[] { XI, YI + 1 };
            default:
                return null;
        }
    }

    public string getOut(string from)
    {
        switch ((type < 0) ? -type : type)
        {
            case 1:
            case 3:
            case 7:
            case 8:
            case 9:
            case 12:
            case 13:
                return "TOP";
            case 2:
            case 6:
                return (from.Equals("RIGHT")) ? from : "LEFT";
            case 4:
                return (from.Equals("RIGHT")) ? "TOP" : "RIGHT";
            case 5:
                return (from.Equals("LEFT")) ? "TOP" : "RIGHT";
            case 10:
                return "RIGHT";
            case 11:
                return "LEFT";
            default:
                return null;
        }
    }

    public int rotate()
    {
        if (type == baseType)
        {
            //Console.WriteLine("Console.WriteLine(\"WAIT\");");
            return 0;
        }
        int my_index = 0;
        for (int i = index + 1; i >= 0; i++)
        {
            if (trans[i % trans.Length] == baseType)
            {
                my_index = i % trans.Length;
                break;
            }
        }
        if (my_index < index)
            if (index - my_index >= trans.Length - index + my_index)
                for (int i = 0; i < trans.Length - index + my_index; i++)
                    Console.WriteLine("{0} {1} LEFT", YI, XI);
            else
                for (int i = 0; i < index - my_index; i++)
                    Console.WriteLine("{0} {1} RIGHT", YI, XI);
        else
            if (my_index - index >= trans.Length - my_index + index)
                for (int i = 0; i < trans.Length - my_index + index; i++)
                    Console.WriteLine("{0} {1} RIGHT", YI, XI);
            else
                for (int i = 0; i < my_index - index; i++)
                    Console.WriteLine("{0} {1} LEFT", YI, XI);
        return 1;
    }

    public bool EXIT
    {
        get { return EX; }
        set { EX = value; }
    }

    public int XI
    {
        get { return X; }
    }

    public int YI
    {
        get { return Y; }
    }

    /*public string Direct
    {
        get { return direct; }
        set { direct = value; }
    }

    public string FROM
    {
        get { return from; }
        set { from = value; }
    }*/

    public int TYPE
    {
        get { return (type < 0) ? -type : type; }
    }
}

class Player
{
    static int[] top = { 1, 3, 4, 5, 7, 9, 10, 11 };
    static int[] right = { 1, 2, 4, 6, 7, 8, 12 };
    static int[] left = { 1, 2, 5, 6, 8, 9, 13 };
    static Room[,] rooms;
    static int W = 0;
    static int H = 0;
    static Stack trace = new Stack();

    static void Main(string[] args)
    {
        string[] inputs;

        inputs = Console.ReadLine().Split(' ');
        W = int.Parse(inputs[0]); // number of columns.
        H = int.Parse(inputs[1]); // number of rows.
        Console.Error.WriteLine("{0} {1}", W, H);
        rooms = new Room[H, W];
        for (int i = 0; i < H; i++)
        {
            string[] LINE = Console.ReadLine().Split(' ');
            for (int j = 0; j < W; j++)
            {
                rooms[i, j] = new Room(i, j, int.Parse(LINE[j]));
                Console.Error.Write(LINE[j] + " ");
            }
            Console.Error.WriteLine();
        }
        int EX = int.Parse(Console.ReadLine());
        rooms[H - 1, EX].EXIT = true;
        bool flag = false;
        int count = 0;
        int wait = 0;
        // game loop
        while (true)
        {
            inputs = Console.ReadLine().Split(' ');
            int XI = int.Parse(inputs[0]);
            int YI = int.Parse(inputs[1]);
            string POSI = inputs[2];
            int R = int.Parse(Console.ReadLine());
            //Console.Error.WriteLine("Debug messages...{0}, {1}, {2}", XI,YI, POSI);
            for (int i = 0; i < R; i++)
            {
                inputs = Console.ReadLine().Split(' ');
                int XR = int.Parse(inputs[0]);
                int YR = int.Parse(inputs[1]);
                string POSR = inputs[2];
            }

            if (!flag)
            {
                search(YI, XI, POSI);
                count = trace.Count;
                flag = true;
                Console.Error.WriteLine("Debug messages count=" + count);
            }
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            if (trace.Count > 0)
            {
                Room test = trace.Pop() as Room;
                while (test.rotate() == 0)
                {
                    wait++;
                    if (trace.Count == 0) break;
                    test = trace.Pop() as Room;
                }
            }
            if (trace.Count == 0)
                for (int i = 0; i < wait + 1; i++)
                    Console.WriteLine("WAIT");

        }
    }
    static int search(int xi, int yi, string posi)
    {
        //Console.Error.WriteLine("Debug messages...{0}, {1}, {2}", xi,yi, posi);
        int[] next = rooms[xi, yi].getNextXY(posi);
        if (next == null)
        {
            Console.Error.WriteLine("Debug messages NULL");
            //Console.WriteLine("next=null");
            return -1;
        }
        if (next[0] < 0 || next[0] >= H || next[1] < 0 || next[1] >= W)
        {
            Console.Error.WriteLine("Debug messages OUT {0} {1}", next[0], next[1]);
            //Console.WriteLine("Out grid: (" + next[0] + ", " + next[1] + ") for " + xi + "," + yi);
            return -1;
        }
        while (true)
        {
            if (rooms[next[0], next[1]].TYPE == 0)
                return 0;
            do
            {
                switch (rooms[xi, yi].getOut(posi))
                {
                    case "TOP":
                        if (!top.Contains(rooms[next[0], next[1]].TYPE))
                            continue;
                        break;
                    case "LEFT":
                        if (!left.Contains(rooms[next[0], next[1]].TYPE))
                            continue;
                        break;
                    case "RIGHT":
                        if (!right.Contains(rooms[next[0], next[1]].TYPE))
                            continue;
                        break;
                }
                if (rooms[next[0], next[1]].EXIT)
                {
                    //Console.WriteLine("Exit is found!");
                    //Console.WriteLine(next[0] + " " + next[1]);
                    Console.Error.WriteLine("Debug messages EXIT IS FOUND");
                    return 1;
                }
                switch (search(next[0], next[1], rooms[xi, yi].getOut(posi)))
                {
                    case -1:
                        Console.Error.WriteLine("Debug messages -1");
                        return -1;
                    case 0:
                        Console.Error.WriteLine("Debug messages 0");
                        //return 0;
                        break;
                    case 1:
                        //Console.WriteLine(next[0] + " " + next[1]);
                        //Console.Error.WriteLine("Debug messages to push");
                        trace.Push(rooms[next[0], next[1]]);
                        return 1;
                }
            } while (rooms[next[0], next[1]].nextType());
        }
    }
}