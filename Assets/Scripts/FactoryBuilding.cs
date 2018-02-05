using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;


    public class FactoryBuilding : Building
    {
        //varibles
        private string unitType;
        private int spawnRate;
        private int XposofSpawnedunit;
        private int YposofSpawnedUnit;

       // private  char faction = 'h' ;

        //properties
        public string UnitType
        {
            get
            {
                return unitType;
            }

            set
            {
                unitType = value;
            }
        }

        public int SpawnRate
        {
            get
            {
                return spawnRate;
            }

            set
            {
                spawnRate = value;
            }
        }

        public int XposofSpawnedunit1
        {
            get
            {
                return XposofSpawnedunit;
            }

            set
            {
                XposofSpawnedunit = value;
            }
        }

        public int YposofSpawnedUnit1
        {
            get
            {
                return YposofSpawnedUnit;
            }

            set
            {
                YposofSpawnedUnit = value;
            }
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

        //constructor
        public FactoryBuilding(int xpos, int ypos, int health, char faction, char symbol, string unitType, int spawnRate) : base(xpos, ypos, health, faction, symbol)
        {
            spawnRate = SpawnRate = 2;
            unitType = UnitType;
        }

        //methods
        public Unit CreateUnit()
        {
            int tempX = X;
            int tempY = Y + 1;
            UnityEngine.Random r = new UnityEngine.Random();
            int Unittype = UnityEngine.Random.Range(0, 2);
            Unit k;
            if (Y == 19)
            {
                tempY = Y - 1;
            }
            if (Unittype == 0)
            {
                if (Faction == 'H')
                {
                    k = new MeleeUnit(tempX, tempY, 10, 1, 2, 1, 'H', 'M', "soldier");
                    return k;
                }
                else
                {
                    k = new MeleeUnit(tempX, tempY, 10, 1, 2, 1, 'h', 'm', "savage");
                    return k;
                }
            }
            else if (Unittype == 1)
            {
                if (Faction == 'H')
                {
                    k = new RangedUnit(tempX, tempY, 8, 1, 1, 2, 'H', 'R', "archer");
                    return k;
                }
                else
                {
                    k = new RangedUnit(tempX, tempY, 8, 1, 1, 2, 'h', 'r', "slinger");
                    return k;
                }
            }
            else
            {
                return null;
            }
        }
        public override bool RIDead(int HP)
        {

            bool dead;

            if (HP <= 0)
            {
                dead = true;
               Console.WriteLine("I am dead.");
            }
            else
            {
                dead = false;
               Console.WriteLine("I am not dead.");
            }

            return dead;
        }
        public override string ToString()
        {
            return ("I am a FactoryBuilding I have the following stats" + Hp2 + "My and display symbol and faction is" + Symbol + Faction);
        }




        public string saveString()
        {
            return (Hp2 + "," + Symbol + "," + Faction + "," + X + "," + Y);
        }
        public override void save()
        {
            if (Directory.Exists("Info") != true)
            {
                Directory.CreateDirectory("Info");
                Console.WriteLine("New Directory Created");
            }
            if (File.Exists("Info/factorybuilding.file") != true)
            {
                File.Create("Info/factorybuilding.file").Close();
                Console.WriteLine("Created file");
            }
            FileStream saveFactoryBuilding = new FileStream("Info/factorybuilding.file", FileMode.Open, FileAccess.Write);
            StreamWriter save = new StreamWriter(saveFactoryBuilding);
            save.WriteLine(saveString());
            save.Close();
            saveFactoryBuilding.Close();
            return;
        }
    }

