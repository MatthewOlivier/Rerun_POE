using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.IO;


    class ResourceBuilding :Building
    {
        public int Amount = -5;
        private string ResourceType = "gold";
        private int MaxResources = 1000;
        private int RemainingResource = 1000;
        private int ResourcePerTick = 5;
        
        //constructor
        public ResourceBuilding(int x, int y, int hp2, char faction, char symbol, string ResourceType, int RemainingResource, int ResourcesPerTick, int MaxResources) : base (x, y, hp2, faction, symbol)
        {

        }
        //properties
         public int ResourcePerTick1
        {
            get
            {
                return ResourcePerTick;
            }

            set
            {
                ResourcePerTick = value;
            }
        }

        public int RemainingResource1
        {
            get
            {
                return RemainingResource;
            }

            set
            {
                RemainingResource = value;
            }
        }

        public int MaxResources1
        {
            get
            {
                return MaxResources;
            }

            set
            {
                MaxResources = value;
            }
        }

        public string ResourceType1
        {
            get
            {
                return ResourceType;
            }

            set
            {
                ResourceType = value;
            }
        }

        public string Health1 { get; private set; }
        public string Symbol1 { get; private set; }
        public char Faction1 { get; private set; }




        //methods 
        public void GenerateResources()
        {
            while (RemainingResource > 0 && Amount <= 1000)
            {
                ToString();
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
            Amount = Amount + ResourcePerTick;
            RemainingResource = RemainingResource - ResourcePerTick;
            return ("Initial Resources: " + MaxResources + ResourceType + ". Remaining Resource: " + RemainingResource + ", Generated Resource: " + Amount + ResourceType);
            
        }




        public string saveString()
        {
            return (Health1 + "," + Symbol1 + "," + Faction1 + "," + X + "," + Y + "," + ResourceType + "," + RemainingResource1 + "," + Amount + "," + MaxResources);
        }
        public override void save()
        {
            if (Directory.Exists("Info") != true)
            {
                Directory.CreateDirectory("Info");
                Console.WriteLine("New Directory Created");
            }
            if (File.Exists("Info/resourcebuilding.file") != true)
            {
                File.Create("Info/resourcebuilding.file").Close();
                Console.WriteLine("Created file");
            }
            FileStream saveResourceBuilding = new FileStream("Info/resourcebuilding.file", FileMode.Open, FileAccess.Write);
            StreamWriter save = new StreamWriter(saveResourceBuilding);
            save.WriteLine(saveString());
            save.Close();
            saveResourceBuilding.Close();
            return;
        }
    }

