using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class Unit : MonoBehaviour
{

    


        //constructor
        public Unit(int x, int y, int Hp, int Spd, int Atk, int AtkRange, char Faction, char Symbol, string Name)
        {
           this.y = y;
            this.x = x;
            this.Hp = Hp;
            this.Spd = Spd;
            this.Atk = Atk;
            this.AtkRange = AtkRange;
            this.Faction = Faction;
            this.Symbol = Symbol;
            this.Name = Name;
        }
        //destructor
        ~Unit()
        {

        }
       
        private int x;   public int Hp1
        {
            get
            {
                return Hp;
            }

            set
            {
                Hp = value;
            }
        }
        private int y;
        private int MaxHp = 100;
        private int Hp = 0;
        private int Spd;
        private int Atk;
        private int AtkRange;
        private char Faction;
        private char Symbol;
        private string Name = "";
        private bool ICF;
        
        
        
        
        
        //properties
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

        public int MaxHp1
        {
            get
            {
                return MaxHp;
            }

            set
            {
                MaxHp = value;
            }
        }
    
        public int Spd1
        {
            get
            {
                return Spd;
            }

            set
            {
                Spd = value;
            }
        }

        public int Atk1
        {
            get
            {
                return Atk;
            }

            set
            {
                Atk = value;
            }
        }

        public int AtkRng1
        {
            get
            {
                return AtkRange;
            }

            set
            {
                this.AtkRange = value;
            }
        }

        internal int getYpos()
        {
            throw new NotImplementedException();
        }
        internal int getXpos()
        {
            throw new NotImplementedException();
        }

        public char Faction1
        {
            get
            {
                return Faction;
            }

            set
            {
                Faction = value;
            }
        }

        public char Symbol1
        {
            get
            {
                return Symbol;
            }

            set
            {
                Symbol = value;
            }
        }

        public string Name1
        {
            get
            {
                return Name;
            }

            set
            {
                Name = value;
            }
        }

        public bool ICF1
        {
            get
            {
                return ICF;
            }

            set
            {
                ICF = value;
            }
        }
        
        //public abstract methods
        public abstract int move(Unit currentUnit, Unit tempenemyUnit);
        public abstract void combat(Unit tempenemyUnit);
        public abstract bool AtkRng(Unit currentUnit, Unit tempenemyUnit);
        public abstract Unit closestUnit(Unit[] unitTemp, Unit currentUnit, Unit tempenemyunit);
        public abstract int RunAway();
        public abstract bool RIDead(int HP);
        public abstract override string ToString();   
        public abstract bool BuildRng(Unit currentUnit, Building tempBuilding);
        public abstract Building ClosestBuilding(Building[] buildingTemp, Unit currentUnit, Building tempBuidling);
        public abstract void BuildCombat(Building enemyBuilding);
        public abstract int BuildMove(Unit currentUnit, Building tempBuilding);

    }


    

