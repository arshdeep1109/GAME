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
            gm.CreatePlayers();
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
        }
    }

    class Player
    {
        private double CurrentBalance;
        private Property CurrentAddress;
        private ArrayList PropertiesOwned;

        public Player(double InitialBalance)
        {
            this.CurrentBalance = InitialBalance;
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
    }
}