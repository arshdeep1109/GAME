using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gm = new GameManager();
            gm.Run();
        }
    }

    class GameManager
    {
        ArrayList Players = new ArrayList();

        public void CreatePlayers()
        {
            for (int i = 0; i < 4; i++)
            {
                Players.Add(new Player(10000));
            }
        }
        public void Run()
        {
            this.CreatePlayers();
            int n = -1;
            while (true)
            {
                n++;
                Console.WriteLine("Player {0}'s Turn", n);
                doStuff((Player)Players[n]);
                if (n > Players.Count - 2) { n = -1; }
            }
        }
        public void doStuff(Player aPlayer)
        {
            Console.WriteLine("Move how many spaces?");
            int numberOfSpacesToMove = Convert.ToInt16(Console.ReadLine());
            aPlayer.CurrentAddress = MovePlayer(numberOfSpacesToMove, aPlayer);
        }

        public Property MovePlayer(int HowManySpaces, Player aPlayer)
        {
            // get a handle on the ARRAY INDEX NUMBER of the CURRENT ADDRESS for the player
            aPlayer.CurrentAddress
            // ADD to that the number of spaces they want to move
            // figure out what PROPERTY corrsponds to that new index
            // ASSIGN the player's current address to that new property object reference

            return new Property();
        }
    }

    class Player
    {
        public double CurrentBalance;
        public Property CurrentAddress;
        public ArrayList PropertiesOwned;

        public Player(double InitialBalance)
        {
            this.CurrentBalance = InitialBalance;
            this.CurrentAddress = null;
        }

        public void BuyAProperty()
        {

        }

        public void PayRent(Player PropertyOwner)
        {

        }

        public void DeclareBankruptcy(Player PlayerToPayTo)
        {

        }

        public void DisplayStatus()
        {
            // print out current balance and list of properties owned
        }
    }

    class Property
    {
        Random r1 = new Random();
        double PropertyValue;
        public Property()
        {
            this.PropertyValue = r1.NextDouble();
        }
    }

    class GameBoard
    {
        public static ArrayList MyGameBoard;

        public void SetupMyGameBoard()
        {
            // create 100 Properties on The Board
            for (int i = 0; i < 100; i++)
            {
                MyGameBoard.Add(new Property());
            }
        }

        public int FindLocationOfProperty(Property PropertyToLookFor)
        {
            int IndexInArray = 0;
            foreach (Property aProperty in MyGameBoard)
            {
                if (PropertyToLookFor == aProperty)
                {
                    return IndexInArray;
                }
                IndexInArray++;
            }
            return -1;
        }
    }
}