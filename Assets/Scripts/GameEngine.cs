using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GameEngine : MonoBehaviour
{
    
    Unit[] UnitArray = new Unit[6];
    Building[] BuildArray = new Building[2];
    private float offset = 2.56f;
    private int gametime = 0;
    private const int Refresh = 60;
    int Hp;
    int MaxHp;

    public int tick = 0;
    
    // Use this for initialization            
    void Start ()
    {
        
        float size = Camera.main.orthographicSize;
        float Xpos = -4 * size + size + 2.56f;
        float Ypos = size + 1;
       
        DrawMap(Xpos, Ypos);
        getHp();
        PopulateMap();
        PlayGame();
        Move(null, null);

    }
	
	// Update is called once per frame
	void Update ()
    {
       //Application.targetFrameRate = 0;
        if (gametime % Refresh == 0 ) 
        { 
            SpwnUnit();
            PlayGame();
            getHp();
            Redraw();
            Move(null,null);
        }
            tick++;
        gametime++;

    }
    //map stuff
    void DrawMap (float x, float y)
    {
        for (int i = 0; i < 20; i++)
        {
            for (int k = 0; k < 20; k++)
            {
                Instantiate(Resources.Load("Grass_Tile"), new Vector3(i * offset, -k * offset, -1), Quaternion.identity);
            }
        }
    }

    void PopulateMap()
    {
        CreateUnit();
        CreateBuilding();
       
    }

    public string getHp()
    {
        string returnval = "Hp";
        double HpPercentage = (double)Hp / (double)MaxHp * 10;
        float roundedHp = Mathf.Ceil((float)HpPercentage);
        returnval = returnval + roundedHp;
        if (roundedHp >= 91 && roundedHp < 100)
        {
            returnval = "Hp_10";
        }
        if (roundedHp >= 81 && roundedHp < 91)
        {
            returnval = "Hp_9";
        }
        if (roundedHp >= 71 && roundedHp < 81)
        {
            returnval = "Hp_8";
        }
        if (roundedHp >= 61 && roundedHp < 71)
        {
            returnval = "Hp_7";
        }
        if (roundedHp >= 51 && roundedHp < 61)
        {
            returnval = "Hp_6";
        }
        if (roundedHp >= 41 && roundedHp < 51)
        {
            returnval = "Hp_5";
        }
        if (roundedHp >= 31 && roundedHp < 41)
        {
            returnval = "Hp_4";
        }
        if (roundedHp >= 21 && roundedHp < 31)
        {
            returnval = "Hp_3";
        }
        if (roundedHp >= 11 && roundedHp < 21)
        {
            returnval = "Hp_2";
        }
        if (roundedHp >= 1 && roundedHp < 11)
        {
            returnval = "Hp_1";
        }
        if (roundedHp == 0)
        {
            returnval = "Hp_0";
        }
        return returnval;
    }

    //units and building stuff
    Unit[] UnitArray1
        {
            get
            {
                return UnitArray;
            }

            set
            {
                UnitArray = value;
            }
        }
    public  FactoryBuilding CreateUnit()
    {
        for (int i = 0; i < UnitArray1.Length; i++)
        {
            
            float tempX = UnityEngine.Random.Range(0, 48.64f);
            float tempY = UnityEngine.Random.Range(0, -48.64f);
       
            int Unittype = UnityEngine.Random.Range(0, 4);

            if (Unittype == 0)
            {
                Instantiate(Resources.Load("H_Warrior"), new Vector3(tempX, tempY, -2), Quaternion.identity);
                Instantiate(Resources.Load("Hp_10"), new Vector3(tempX, tempY, -3), Quaternion.identity);
            } 
             
    
            else if (Unittype == 1)
            {
                Instantiate(Resources.Load("H_Archer"), new Vector3(tempX, tempY, -2), Quaternion.identity);
                Instantiate(Resources.Load("Hp_10"), new Vector3(tempX, tempY, -3), Quaternion.identity);
            }
            else if (Unittype == 2)
            {
                Instantiate(Resources.Load("E_Warrior"), new Vector3(tempX, tempY, -2), Quaternion.identity);
                Instantiate(Resources.Load("Hp_10"), new Vector3(tempX, tempY, -3), Quaternion.identity);
            }
            else if (Unittype == 3)
            {
                Instantiate(Resources.Load("E_Archer"), new Vector3(tempX, tempY, -2), Quaternion.identity);
                Instantiate(Resources.Load("Hp_10"), new Vector3(tempX, tempY, -3), Quaternion.identity);
            }
        }
        return null;
    }
            
    Building[] BuildArray1
    {
        get
        {
            return BuildArray;
        }

        set
        {
            BuildArray = value;
        }
    }
    public void CreateBuilding()
    {
        Instantiate(Resources.Load("E_Barracks"), new Vector3(48.64f, 0, -2), Quaternion.identity);
        Instantiate(Resources.Load("H_Barracks"), new Vector3(0, 0, -2), Quaternion.identity);
        Instantiate(Resources.Load("Hp_10"), new Vector3(0, 0, -3), Quaternion.identity);
        Instantiate(Resources.Load("Hp_10"), new Vector3(48.64f, 0, -3), Quaternion.identity);

        Instantiate(Resources.Load("H_Mine"), new Vector3(0, -48.64f, -2), Quaternion.identity);
        Instantiate(Resources.Load("Hp_10"), new Vector3(0, -48.64f, -3), Quaternion.identity);
         
        Instantiate(Resources.Load("E_Mine"), new Vector3(48.64f, -48.64f, -2), Quaternion.identity);
        Instantiate(Resources.Load("Hp_10"), new Vector3(48.64f, -48.64f, -3), Quaternion.identity);
          
        }
    
    public void SpwnUnit()
    {

        int Unittype = UnityEngine.Random.Range(0, 2);

        if (Unittype == 0)
        {
            Instantiate(Resources.Load("H_Warrior"), new Vector3(0, -2.56f, -2), Quaternion.identity);
            Instantiate(Resources.Load("Hp_10"), new Vector3(0, -2.56f, -3), Quaternion.identity);
        }


        else if (Unittype == 1)
        {
            Instantiate(Resources.Load("H_Archer"), new Vector3(0, -2.56f, -2), Quaternion.identity);
            Instantiate(Resources.Load("Hp_10"), new Vector3(0, -2.56f, -3), Quaternion.identity);
        }

        if (Unittype == 0)
        {
            Instantiate(Resources.Load("E_Warrior"), new Vector3(48.64f, -2.56f, -2), Quaternion.identity);
            Instantiate(Resources.Load("Hp_10"), new Vector3(48.64f, -2.56f, -3), Quaternion.identity);
        }
        else if (Unittype == 1)
        {
            Instantiate(Resources.Load("E_Archer"), new Vector3(48.64f, -2.56f, -2), Quaternion.identity);
            Instantiate(Resources.Load("Hp_10"), new Vector3(48.64f, -2.56f, -3), Quaternion.identity);
        }
    }



  


    public void PlayGame()
    {
        Unit[] unitTemp = null;
        Building tempBuilding = null;
        Unit tempEnemyUnit = null;
        Unit currentUnit = null;
        int move;
        int arraySize = 6;
        int GameTick = 1;
        int frameRate = 100;
        int UnitTotalDiff, buildingTotalDiff;
        bool inUnitRange, inBuildingRange;


        for (int i = 0; i < arraySize; i++)
        {
            if (UnitArray1[i].RIDead(UnitArray1[i].Hp1) == true)
            {
              
               UnitArray1[i] = null;

            }
            else if (UnitArray1[i].RIDead(UnitArray1[i].Hp1) == false)
            {

                Debug.Log("I am a " + UnitArray1[i].Faction1 + ", " + UnitArray1[i].Name1 + " unit at index " + i + " and my current health is " + UnitArray1[i].Hp1 + ". My location is X: " + UnitArray1[i].X + ", Y: " + UnitArray1[i].Y);

                if (UnitArray1[i].Hp1 < 20)
                {
                    move = UnitArray1[i].RunAway();

                    switch (move)
                    {
                        case 1:
                            if (UnitArray1[i].X + 1 != 48.64f)
                            {
                                Debug.Log("I have run away.");
                                UnitArray1[i].X = UnitArray1[i].X + 1;
                                Instantiate(Resources.Load("H_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                                Instantiate(Resources.Load("Hp_10"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -3), Quaternion.identity);
                                //UpdateUnit(UnitArray1[i], UnitArray1[i].X, UnitArray1[i].Y);
                            }
                            break;
                        case 2:
                            if (UnitArray1[i].X - 1 != -1)
                            {
                                Debug.Log("I have run away.");
                                UnitArray1[i].X = UnitArray1[i].X - 1;
                               //UpdateUnit(UnitArray1[i], UnitArray1[i].X, UnitArray1[i].Y);
                            }
                            break;
                        case 3:
                            if (UnitArray1[i].Y + 1 != 1)
                            {
                                Debug.Log("I have run away.");
                                UnitArray1[i].Y = UnitArray1[i].Y + 1;
                              //UpdateUnit(UnitArray1[i], UnitArray1[i].X, UnitArray1[i].Y);
                            }
                            break;
                        case 4:
                            if (UnitArray1[i].Y - 1 != -48.64f)
                            {
                                Debug.Log("I have run away.");
                                UnitArray1[i].Y = UnitArray1[i].Y - 1;
                                //UpdateUnit(UnitArray1[i], UnitArray1[i].X, UnitArray1[i].Y);
                            }
                            break;
                    }
                }

                else
                {
                    tempEnemyUnit = UnitArray1[i].closestUnit(UnitArray1, UnitArray1[i], tempEnemyUnit);
                    tempBuilding = UnitArray1[i].ClosestBuilding(BuildArray1, UnitArray1[i], tempBuilding);
                    if (i == 0)
                    {

                    }
                    Debug.Log(tempEnemyUnit);
                    Debug.Log(tempBuilding);

                    if (tempEnemyUnit != null && tempEnemyUnit.RIDead(tempEnemyUnit.Hp1) != true)
                    {
                        Debug.Log("I am the closest Unit at X:" + tempEnemyUnit.X + ", Y: " + tempEnemyUnit.Y);
                        UnitTotalDiff = System.Math.Abs((UnitArray1[i].X - tempEnemyUnit.X)) + System.Math.Abs((UnitArray1[i].Y - tempEnemyUnit.Y));
                    }
                    else
                    {
                        UnitTotalDiff = 600000000;
                        tempEnemyUnit = null;
                    }

                    if (tempBuilding != null && tempBuilding.RIDead(tempBuilding.Hp2) != true)
                    {
                        Debug.Log("I am the closest Building at X:" + tempBuilding.X + ", Y: " + tempBuilding.Y);
                        buildingTotalDiff = System.Math.Abs((UnitArray1[i].X - tempBuilding.X)) + System.Math.Abs((UnitArray1[i].Y - tempBuilding.Y));
                    }
                    else
                    {
                        buildingTotalDiff = 600000000;
                        tempBuilding = null;
                    }

                    Debug.Log(UnitTotalDiff);
                    Debug.Log(buildingTotalDiff);

                    if (UnitTotalDiff <= buildingTotalDiff && tempEnemyUnit != null)
                    {


                        if (UnitArray1[i].ICF1 == true)
                        {
                            Debug.Log("I am still attacking a unit.");
                            UnitArray1[i].combat(tempEnemyUnit);
                        }
                        else
                        {
                            inUnitRange = UnitArray1[i].AtkRng(UnitArray1[i], tempEnemyUnit);

                            if (inUnitRange == true)
                            {
                                Debug.Log("I am attacking a unit.");
                                UnitArray1[i].ICF1 = true;
                                UnitArray1[i].combat(tempEnemyUnit);
                            }
                            else if (GameTick % UnitArray1[i].Spd1 == 0)
                            {
                                move = UnitArray1[i].move(UnitArray1[i], tempEnemyUnit);

                                switch (move)
                                {
                                    case 1:
                                        Debug.Log("I have moved towards the Unit.");
                                        UnitArray1[i].X = UnitArray1[i].X - 1;
                                        Instantiate(Resources.Load("H_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                                        Instantiate(Resources.Load("Hp_10"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -3), Quaternion.identity);
                                        break;
                                    case 2:
                                        Debug.Log("I have moved towards the Unit.");
                                       UnitArray1[i].X = UnitArray1[i].X + 1;
                                        break;
                                    case 3:
                                        Debug.Log("I have moved towards the Unit.");
                                        UnitArray1[i].Y = UnitArray1[i].Y - 1;
                                        break;
                                    case 4:
                                        Debug.Log("I have moved towards the Unit.");
                                        UnitArray1[i].Y = UnitArray1[i].Y + 1;
                                        break;
                                }


                            }
                        }

                        if (tempEnemyUnit.RIDead(tempEnemyUnit.Hp1) == true)
                        {
                           UnitArray1[i].ICF1 = false;
                        }

                    }
                    else if (tempBuilding != null)
                    {
                        if (UnitArray1[i].ICF1 == true)
                        {
                            Debug.Log("I am still attacking a building.");
                           UnitArray1[i].BuildCombat(tempBuilding);
                        }
                        else
                        {
                            inBuildingRange =UnitArray1[i].BuildRng(UnitArray1[i], tempBuilding);

                            if (inBuildingRange == true)
                            {
                                Debug.Log("I am attacking a building.");
                                UnitArray1[i].ICF1 = true;
                                UnitArray1[i].BuildCombat(tempBuilding);
                            }

                            else if (GameTick % UnitArray1[i].Spd1 == 0)
                            {
                                move = UnitArray1[i].BuildMove(UnitArray1[i], tempBuilding);

                                switch (move)
                                {
                                    case 1:
                                        Debug.Log("I have moved towards the building.");
                                       UnitArray1[i].X = UnitArray1[i].X - 1;
                                        break;
                                    case 2:
                                        Debug.Log("I have moved towards the building.");
                                       UnitArray1[i].X = UnitArray1[i].X + 1;
                                        break;
                                    case 3:
                                        Debug.Log("I have moved towards the building.");
                                       UnitArray1[i].Y = UnitArray1[i].Y - 1;
                                        break;
                                    case 4:
                                       Debug.Log("I have moved towards the building.");
                                        UnitArray1[i].Y = UnitArray1[i].Y + 1;
                                        break;
                                    case 5:
                                        break;
                                }


                            }
                        }

                        if (tempBuilding.RIDead(tempBuilding.Hp2) == true)
                        {
                            UnitArray1[i].ICF1 = false;
                        }

                    }
                }

            }
        }
     


        tick++;

        //check for remaining resources
        foreach (Building Name in BuildArray1)
        {
            if (Name.GetType().ToString() == "GADE_A1_A2_redone.ResourceBuilding")
            {
                if ((Name as ResourceBuilding).RemainingResource1 <= 0)
                {
                    (Name as ResourceBuilding).GenerateResources();
                }
            }
            else if (Name.GetType().ToString() == "GADE_A1_A2_redone.FactoryBuilding")
            {
                if (tick % (Name as FactoryBuilding).SpawnRate == 0)
                {
                    // inceases Unit array size
                    Unit[] Tempunits = new Unit[UnitArray1.Length + 1];
                    for (int i = 0; i < UnitArray1.Length; i++)
                    {
                        Tempunits[i] = UnitArray1[i];
                    }
                    //sets new units to map arrary
                    Tempunits[UnitArray1.Length] = (Name as FactoryBuilding).CreateUnit();
                   // CharArray1[Tempunits[Tempunits.Length - 1].Y, Tempunits[Tempunits.Length - 1].X] = Tempunits[Tempunits.Length - 1].Symbol1;
                    UnitArray1 = Tempunits;
                }
            }
        }

    }
    
    private void UpdateUnit(Unit unit, int x, int y)
    {
        CreateUnit();
    }

    public void Move(Unit currentUnit, Unit tempenemyUnit)
    {
        int Xdif, Ydif, move = 0;


        Xdif = currentUnit.X - tempenemyUnit.X;
        Ydif = currentUnit.Y - tempenemyUnit.Y;
        for (int i = 0; i < UnitArray1.Length; i++)
        {
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

                if (gametime % UnitArray1[i].Spd1 == 0)
                {
                    move = UnitArray1[i].move(UnitArray1[i], tempenemyUnit);

                    switch (move)
                    {
                        case 1:
                            Debug.Log("I have moved towards the Unit.");
                            UnitArray1[i].X = UnitArray1[i].X - 1;
                            Instantiate(Resources.Load("H_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("H_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("Hp_10"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -3), Quaternion.identity);
                            break;
                        case 2:
                            Debug.Log("I have moved towards the Unit.");
                            Instantiate(Resources.Load("H_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("H_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("Hp_10"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -3), Quaternion.identity);
                            UnitArray1[i].X = UnitArray1[i].X + 1;
                            break;
                        case 3:
                            Debug.Log("I have moved towards the Unit.");
                            Instantiate(Resources.Load("H_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("H_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("Hp_10"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -3), Quaternion.identity);
                            UnitArray1[i].Y = UnitArray1[i].Y - 1;
                            break;
                        case 4:
                            Debug.Log("I have moved towards the Unit.");
                            Instantiate(Resources.Load("H_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Warrior"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("H_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("E_Archer"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -2), Quaternion.identity);
                            Instantiate(Resources.Load("Hp_10"), new Vector3(UnitArray1[i].X + 1, UnitArray1[i].Y, -3), Quaternion.identity);
                            UnitArray1[i].Y = UnitArray1[i].Y + 1;
                            break;
                    }

                }
            }
        }
    }


            
        
    void Redraw()
    {
        GameObject[] Deletethis = GameObject.FindGameObjectsWithTag("RedrawSprites");
        foreach (GameObject temp in Deletethis)
        {
            Destroy(temp.gameObject);
        }
        
    }
}
   

    

    




