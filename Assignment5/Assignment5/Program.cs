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
            GameBoard.SetupMyGameBoard();
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
            this.MovePlayer(numberOfSpacesToMove, aPlayer);
            aPlayer.DisplayStatus();
            // #TODO: IF the current owner == NULL, present user with option to purchase
            // else charge then rent
            // if they try to purchase and do not have sufficient funds, back out of the transaction
            // if The System tries to charge them RENT, and they have an INSUFFICIENT BALANCE, 
            //  A. Transfer all their money to the property's owner
            //  B. Inform them they are BANKRUPT.
            //  C. Remove that Player Object from the Array List of Players
        }

        public void MovePlayer(int HowManySpaces, Player aPlayer)
        {
            // get a handle on the ARRAY INDEX NUMBER of the CURRENT ADDRESS for the player
            int ARRAY_INDEX_CURRENT_ADDRESS = GameBoard.FindLocationOfProperty(aPlayer.CurrentAddress);
            // ADD to that the number of spaces they want to move
            int NewPlayerAddress_IndexLocation = ARRAY_INDEX_CURRENT_ADDRESS + HowManySpaces;
            // figure out what PROPERTY corrsponds to that new index
            aPlayer.CurrentAddress = (Property)GameBoard.MyGameBoard[NewPlayerAddress_IndexLocation];
            // ASSIGN the player's current address to that new property object reference

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
            Console.WriteLine("{0}", this.CurrentBalance);
        }
    }

    class Property
    {
        Random r1 = new Random();
        double PropertyValue;
        public Property()
        {
            this.PropertyValue = 100 + 700 * r1.NextDouble();
        }
    }

    class GameBoard
    {
        public static ArrayList MyGameBoard = new ArrayList();

        public static void SetupMyGameBoard()
        {
            // create 100 Properties on The Board
            for (int i = 0; i < 100; i++)
            {
                MyGameBoard.Add(new Property());
            }
        }

        public static int FindLocationOfProperty(Property PropertyToLookFor)
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