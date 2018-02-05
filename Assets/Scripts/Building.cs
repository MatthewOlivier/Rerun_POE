using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


   public abstract class Building : MonoBehaviour
    {
        private int x;
        private int y;
        private int hp2, maxhp2 = 100;
        private char faction;
        private char symbol;

        public Building(int x, int y, int hp2, char faction, char symbol)
        {
            this.X = x;
            this.Y = y;
            this.Hp2 = hp2;
            this.Faction = faction;
            this.Symbol = symbol;
        }
        //deconstructor
        ~Building()
        {

        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public int Hp2
        {
            get
            {
                return hp2;
            }

            set
            {
                hp2 = value;
            }
        }

        public char Faction
        {
            get
            {
                return faction;
            }

            set
            {
                faction = value;
            }
        }

        public char Symbol
        {
            get
            {
                return symbol;
            }

            set
            {
                symbol = value;
            }
        }



        //public abstract methods
        public abstract bool RIDead( int HP);
        public abstract override string ToString();
        public abstract void save();
       
    }



















