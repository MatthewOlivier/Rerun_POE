using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;



    class RangedUnit : Unit
    {
        public RangedUnit(int x, int y, int Hp, int Spd, int Atk, int AtkRange, char Faction, char Symbol, string Name) : base (x,y,Hp,Spd, Atk, AtkRange, Faction, Symbol, Name )
        {
            this.X = x;
            this.Y = y;
            this.Hp1 = 100;
            this.MaxHp1 = 100;
            this.Spd1 = 2;
            this.Atk1 = 5;
            this.AtkRng1 = 2;
            this.Faction1 = Faction;
            this.Symbol1 = Symbol;
            this.Name1 = "Ranged";
        }

        public override bool AtkRng(Unit currentUnit, Unit tempenemyUnit)
        {
            bool Inrange = false;

            int Xdif, Ydif, total;

            Xdif = currentUnit.X - tempenemyUnit.X;
            Ydif = currentUnit.Y - tempenemyUnit.Y;

            total = Math.Abs(Xdif) + Math.Abs(Ydif);

            if (total <= 1)
            {
                Inrange = true;
                Console.WriteLine("I'm in range of a unit.");
            }
            else
            {
                Inrange = false;
                Console.WriteLine("I'm not in range of a unit.");
            }


            return Inrange;
        }

        public override Unit closestUnit(Unit[] unitTemp, Unit currentUnit, Unit tempenemyunit)
        {
            int Xdif, Ydif, totalDiff, smaller = 1000000000;

            for (int i = 0; i < unitTemp.Length; i++)
            {
                if (unitTemp[i] != null && currentUnit.Faction1 != unitTemp[i].Faction1)
                {
                    Xdif = currentUnit.X - unitTemp[i].X;
                    Ydif = currentUnit.Y - unitTemp[i].Y;
                    totalDiff = Math.Abs(Xdif) + Math.Abs(Ydif);
                    Console.WriteLine(totalDiff);
                    if (totalDiff != 0)
                    {
                        if (totalDiff < smaller)
                        {
                            tempenemyunit = unitTemp[i];
                            smaller = totalDiff;
                            Console.WriteLine("I am not your friend.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("I am your friend.");
                }

            }



            Console.WriteLine("Unit checking done.");
            return tempenemyunit;
        }

        public override void combat(Unit tempenemyUnit)
        {
            tempenemyUnit.Hp1 = tempenemyUnit.Hp1 - this.Atk1;
            Console.WriteLine("Unit successfully attacked I guess");
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override int move(Unit currentUnit, Unit tempenemyUnit)
        {
            int Xdif, Ydif, move = 0;


            Xdif = currentUnit.X - tempenemyUnit.X;
            Ydif = currentUnit.Y - tempenemyUnit.Y;

            if (Xdif > Ydif)
            {
                if (Xdif > 0 && currentUnit.X - 1 != 0)
                {
                    move = 1;
                }
                else if (currentUnit.X + 1 != 21)
                {
                    move = 2;
                }
            }
            else
            {
                if (Ydif > 0 && currentUnit.Y - 1 != 0)
                {
                    move = 3;
                }
                else if (currentUnit.Y + 1 != 21)
                {
                    move = 4;
                }
            }


            return move;
        }

        public override bool RIDead(int HP)
        {
            bool dead;
            if (MaxHp1 <= 0)
            {
                Console.WriteLine("I'm dead idiot.");
                dead = true;
            }
            else
            {
                Console.WriteLine("I'm not dead yet.");
                dead = false;
            }

            return dead;

        }

        public override int RunAway()
        {
            UnityEngine.Random r = new UnityEngine.Random();
            int move = UnityEngine.Random.Range(1, 4);
            return move;
        }

        public string saveString()
        {
            return (Name1 + "," + Spd1 + "," + Atk1 + "," + AtkRng1 + "," + Symbol1 + "," + Faction1 + "," + X + "," + Y);
        }


        public override string ToString()
        {
            return ("I am" + Name1 + "I have the following stats" + Hp1+ "," + Spd1 + "," + Atk1 + "," + AtkRng1 + "," + "My and display symbol and faction is " + Symbol1 + "," + Faction1 + "," + " My cordinates are" + X + "X," + Y + "Y.");
        }

        public override bool BuildRng(Unit currentUnit, Building tempBuilding)
        {
            bool Inrange = false;


            int xdiff, ydiff, total;

            xdiff = currentUnit.X - tempBuilding.X;
            ydiff = currentUnit.Y - tempBuilding.Y;

            total = Math.Abs(xdiff) + Math.Abs(ydiff);

            if (total <= 1)
            {
                Inrange = true;
                Console.WriteLine("I am in range of a building.");
            }
            else
            {
                Inrange = false;
                Console.WriteLine("I am not in range of a building.");
            }


            return Inrange;
        }

        public override Building ClosestBuilding(Building[] buildingTemp, Unit currentUnit, Building tempBuilding)
        {

            int xdiff, ydiff, totalDiff, smaller = 1000000000;

            for (int i = 0; i < buildingTemp.Length; i++)
            {
                if (buildingTemp[i] != null && currentUnit.Faction1 != buildingTemp[i].Faction)
                {
                    xdiff = currentUnit.X - buildingTemp[i].X;
                    ydiff = currentUnit.Y - buildingTemp[i].Y;
                    totalDiff = Math.Abs(xdiff) + Math.Abs(ydiff);
                    Console.WriteLine(totalDiff);
                    if (totalDiff != 0)
                    {
                        if (totalDiff < smaller)
                        {
                            tempBuilding = buildingTemp[i];
                            smaller = totalDiff;
                            Console.WriteLine("I am not your friend.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("I am your friend.");
                }

            }


            Console.WriteLine("Building checking done.");
            return tempBuilding;
        }

        public override void BuildCombat(Building enemyBuilding)
        {
            enemyBuilding.Hp2 = enemyBuilding.Hp2 - this.Atk1;
            Console.WriteLine("Building attacked successfully");
        }

        public override int BuildMove(Unit currentUnit, Building tempBuilding)
        {
            int xdiff, ydiff, move = 0;


            xdiff = currentUnit.X - tempBuilding.X;
            ydiff = currentUnit.Y - tempBuilding.Y;

            if (xdiff > ydiff)
            {
                if (xdiff > 0 && currentUnit.X - 1 != 0)
                {
                    move = 1;
                }
                else if (currentUnit.X + 1 != 20)
                {
                    move = 2;
                }
            }
            else
            {
                if (ydiff > 0 && currentUnit.Y - 1 != 0)
                {
                    move = 3;
                }
                else if (currentUnit.Y + 1 != 20)
                {
                    move = 4;
                }
            }


            return move;
        }
    }

