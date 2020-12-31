using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class BattleshipGrid
{

    public List<Block> blocks;
    public GameObject parent;

    public BattleshipGrid()
    {
        blocks = new List<Block>();
    }
    public void makeClickable()
    {
        foreach (Block b in blocks)
        {
            b.toptile.AddComponent<Clicker>();
            b.setClickCoordinates();

        }
    }
}
public class Block
{
    
    public GameObject toptile, bottomtile, player1, player2;
    public int indexX, indexY;
    public bool filled;

    public void setClickCoordinates()
    {
        if (toptile.GetComponent<Clicker>() != null)
        {
            toptile.GetComponent<Clicker>().indexX = indexX;
            toptile.GetComponent<Clicker>().indexY = indexY;
        }
    }
}
public class gameManager : MonoBehaviour
{

    public bool PiecesCreated = false;

    string NextPlayer = "Player 1";
    public int PlayerOneSpace = 0;
    public int PlayerTwoSpace = 0;

    public int randomNumberSteps;

    public BattleshipGrid playerGrid;
    public List<string> allPos = new List<string>(101);
    public List<string> ProperLabeling = new List<string>(101);
    GameObject rowLabel, rowL, buttonPrefab, timerText, theTimer;

    Block b = new Block();

    GameObject sq ,player, player1, player2;
    

    public int shipid;
    public Button currentbutton;

    String PlayerOneColor;
    String PLayerTwoColor;

    

    public float xPos;
    public float yPos;

    GameObject gm;
    PlayerSelect gms;

    bool PlayersSaved = false;
    public bool GamePrep = false;
    public bool GameStart = false;
    public string CurrentPlaying = "Player1";
    public bool TurnEnded = false;

    
    public void getBoxPos(string blockNum)
    {
        string[] tokens = blockNum.Split(',');
        string x = tokens[0];
        string y = tokens[1];
        

        xPos = float.Parse(x);
        yPos = float.Parse(y);

        xPos = xPos * 3;
        yPos = yPos * 3;
    }

    public void Pieces()
    {        
        if (PiecesCreated == false)
        {
            
            GameObject anchor = new GameObject("Players");

            b.player1 = Instantiate(player, new Vector3(-4.5f * 3, -6f * 3), Quaternion.identity);
            b.player1.GetComponent<SpriteRenderer>().color = Color.red;
            b.player1.transform.SetParent(anchor.transform);
            b.player1.transform.localScale = new Vector3(3f, 3f);
            b.player1.name = "Red";

            b.player2 = Instantiate(player, new Vector3(-2.5f * 3, -6f * 3), Quaternion.identity);
            b.player2.GetComponent<SpriteRenderer>().color = Color.blue;
            b.player2.transform.SetParent(anchor.transform);
            b.player2.transform.localScale = new Vector3(3f, 3f);
            b.player2.name = "Blue";

            PiecesCreated = true;
        }        

        if(GamePrep == true)
        {
            getBoxPos(allPos[0]);
            b.player1.transform.localScale = new Vector3(1f, 1f);
            b.player1.transform.position = new Vector3(xPos-0.6f, yPos);

            b.player2.transform.localScale = new Vector3(1f, 1f);
            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);

            //Debug.Log(xPos + " " + yPos);
            //GamePrep = false;
        }
        

        Debug.Log(GameStart);
        if(GameStart == true)
        {

            if (CurrentPlaying == "Player1")
            {
                if (PlayerOneColor == "Red")
                {
                    if (TurnEnded == false)
                    {
                        Debug.Log("First Looop Active");
                        Debug.Log("Which player Pressed the button : " + NetworkManager.PlayerName);
                        Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);
                        getBoxPos(ProperLabeling[PlayerOneSpace]);
                        Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);

                        //Ladders
                        if (PlayerOneSpace == 1)
                        {
                            getBoxPos(ProperLabeling[44]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 44;
                        }
                        if (PlayerOneSpace == 3)
                        {
                            getBoxPos(ProperLabeling[26]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 26;
                        }
                        if (PlayerOneSpace == 8)
                        {
                            getBoxPos(ProperLabeling[30]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 30;
                        }
                        if (PlayerOneSpace == 46)
                        {
                            getBoxPos(ProperLabeling[83]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 83;
                        }
                        //Ladders

                        //Snakes
                        if (PlayerOneSpace == 15)
                        {
                            getBoxPos(ProperLabeling[7]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 7;
                        }
                        if (PlayerOneSpace == 51)
                        {
                            getBoxPos(ProperLabeling[27]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 27;
                        }
                        if (PlayerOneSpace == 77)
                        {
                            getBoxPos(ProperLabeling[24]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 24;
                        }
                        if (PlayerOneSpace == 92)
                        {
                            getBoxPos(ProperLabeling[88]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 88;
                        }
                        if (PlayerOneSpace == 94)
                        {
                            getBoxPos(ProperLabeling[74]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 74;
                        }
                        if (PlayerOneSpace == 98)
                        {
                            getBoxPos(ProperLabeling[20]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 20;
                        }
                        //Snakes

                        b.player1.transform.position = new Vector3(xPos - 0.6f, yPos);
                        CurrentPlaying = "Player2";
                        TurnEnded = true;
                    }
                }

                if (PlayerOneColor == "Blue")
                {
                    if (TurnEnded == false)
                    {
                        Debug.Log("First Looop Active");
                        Debug.Log("Which player Pressed the button : " + NetworkManager.PlayerName);
                        Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);
                        getBoxPos(ProperLabeling[PlayerOneSpace]);
                        Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);

                        //Ladders
                        if (PlayerOneSpace == 1)
                        {
                            getBoxPos(ProperLabeling[44]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 44;
                        }
                        if (PlayerOneSpace == 3)
                        {
                            getBoxPos(ProperLabeling[26]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 26;
                        }
                        if (PlayerOneSpace == 8)
                        {
                            getBoxPos(ProperLabeling[30]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 30;
                        }
                        if (PlayerOneSpace == 46)
                        {
                            getBoxPos(ProperLabeling[83]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 83;
                        }
                        //Ladders

                        //Snakes
                        if (PlayerOneSpace == 15)
                        {
                            getBoxPos(ProperLabeling[7]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 7;
                        }
                        if (PlayerOneSpace == 51)
                        {
                            getBoxPos(ProperLabeling[27]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 27;
                        }
                        if (PlayerOneSpace == 77)
                        {
                            getBoxPos(ProperLabeling[24]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 24;
                        }
                        if (PlayerOneSpace == 92)
                        {
                            getBoxPos(ProperLabeling[88]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 88;
                        }
                        if (PlayerOneSpace == 94)
                        {
                            getBoxPos(ProperLabeling[74]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 74;
                        }
                        if (PlayerOneSpace == 98)
                        {
                            getBoxPos(ProperLabeling[20]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerOneSpace = 20;
                        }
                        //Snakes

                        b.player2.transform.position = new Vector3(xPos - 0.6f, yPos);
                        CurrentPlaying = "Player2";
                        TurnEnded = true;
                    }
                }
            }

            if (CurrentPlaying == "Player2")
            {
                if (PLayerTwoColor == "Blue")
                {
                    if (TurnEnded == false)
                    {
                        Debug.Log("Second Looop Active");
                        //Debug.Log("GameStart Method Entered");
                        //Debug.Log("Which player Pressed the button : " + NetworkManager.PlayerName);
                        //Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);                        
                        getBoxPos(ProperLabeling[PlayerTwoSpace]);
                        Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);

                        //Ladders
                        if (PlayerTwoSpace == 1)
                        {
                            getBoxPos(ProperLabeling[44]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 44;
                        }
                        if (PlayerTwoSpace == 3)
                        {
                            getBoxPos(ProperLabeling[26]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 26;
                        }
                        if (PlayerTwoSpace == 8)
                        {
                            getBoxPos(ProperLabeling[30]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 30;
                        }
                        if (PlayerTwoSpace == 46)
                        {
                            getBoxPos(ProperLabeling[83]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 83;
                        }
                        //Ladders

                        //Snakes
                        if (PlayerTwoSpace == 15)
                        {
                            getBoxPos(ProperLabeling[7]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 7;
                        }
                        if (PlayerTwoSpace == 51)
                        {
                            getBoxPos(ProperLabeling[27]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 27;
                        }
                        if (PlayerTwoSpace == 77)
                        {
                            getBoxPos(ProperLabeling[24]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 24;
                        }
                        if (PlayerTwoSpace == 92)
                        {
                            getBoxPos(ProperLabeling[88]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 88;
                        }
                        if (PlayerTwoSpace == 94)
                        {
                            getBoxPos(ProperLabeling[74]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 74;
                        }
                        if (PlayerTwoSpace == 98)
                        {
                            getBoxPos(ProperLabeling[20]);
                            b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 20;
                        }
                        //Snakes
                        b.player2.transform.position = new Vector3(xPos + 0.6f, yPos);
                        CurrentPlaying = "Player1";
                        TurnEnded = true;
                    }
                }

                if (PLayerTwoColor == "Red")
                {
                    if (TurnEnded == false)
                    {
                        Debug.Log("Second Looop Active");
                        //Debug.Log("GameStart Method Entered");
                        //Debug.Log("Which player Pressed the button : " + NetworkManager.PlayerName);
                        //Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);
                        getBoxPos(ProperLabeling[PlayerTwoSpace]);

                        //Ladders
                        if (PlayerTwoSpace == 1)
                        {
                            getBoxPos(ProperLabeling[44]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 44;
                        }
                        if (PlayerTwoSpace == 3)
                        {
                            getBoxPos(ProperLabeling[26]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 26;
                        }
                        if (PlayerTwoSpace == 8)
                        {
                            getBoxPos(ProperLabeling[30]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 30;
                        }
                        if (PlayerTwoSpace == 46)
                        {
                            getBoxPos(ProperLabeling[83]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 83;
                        }
                        //Ladders

                        //Snakes
                        if (PlayerTwoSpace == 15)
                        {
                            getBoxPos(ProperLabeling[7]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 7;
                        }
                        if (PlayerTwoSpace == 51)
                        {
                            getBoxPos(ProperLabeling[27]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 27;
                        }
                        if (PlayerTwoSpace == 77)
                        {
                            getBoxPos(ProperLabeling[24]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 24;
                        }
                        if (PlayerTwoSpace == 92)
                        {
                            getBoxPos(ProperLabeling[88]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 88;
                        }
                        if (PlayerTwoSpace == 94)
                        {
                            getBoxPos(ProperLabeling[74]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 74;
                        }
                        if (PlayerTwoSpace == 98)
                        {
                            getBoxPos(ProperLabeling[20]);
                            b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                            PlayerTwoSpace = 20;
                        }
                        //Snakes

                        Debug.Log(PlayerOneSpace + " " + xPos + " " + yPos);                        
                        b.player1.transform.position = new Vector3(xPos + 0.6f, yPos);
                        CurrentPlaying = "Player1";
                        TurnEnded = true;
                    }
                }
            }
        }        
    }
   
    void Start()
    {
        sq = Resources.Load<GameObject>("Prefabs/Square");

        player = Resources.Load<GameObject>("Prefabs/Circle");

        rowLabel = Resources.Load<GameObject>("Prefabs/TextPrefab");

        buttonPrefab = Resources.Load<GameObject>("Prefabs/myButton");

        GameObject anchor = new GameObject("playergrid");


        playerGrid = GenerateGrid(anchor);
        playerGrid.parent.transform.position = new Vector3(0f, 0f);
        playerGrid.parent.transform.localScale = new Vector3(3f, 3f);
        playerGrid.makeClickable();




       

        Pieces();       

        gm = GameObject.Find("Red");
        gms = gm.GetComponent<PlayerSelect>();

        
    }


   


    


    public BattleshipGrid GenerateGrid(GameObject parentObject)
    {
       
        int rowcounter = 0;
        int columncounter = 0;
        int boxnumber = 0;
        Vector3 pos;
        
       
        BattleshipGrid grid = new BattleshipGrid();

        for (float ycoord = -4.5f; ycoord <= 4.5f; ycoord++)
        {
            rowcounter++;
            

            for (float xcoord = -4.5f; xcoord <= 4.5f; xcoord++)
            {
                
                columncounter++;
                boxnumber++;
                
                b.bottomtile = Instantiate(sq, new Vector3(xcoord, ycoord), Quaternion.identity);
                b.toptile = Instantiate(sq, new Vector3(xcoord, ycoord), Quaternion.identity);
                b.toptile.transform.localScale = new Vector3(0.9f, 0.9f);
                b.toptile.name = "TopTile";
                b.toptile.AddComponent<BoxCollider2D>();
                b.toptile.GetComponent<BoxCollider2D>().isTrigger = true;
                b.bottomtile.GetComponent<SpriteRenderer>().color = Color.black;
                b.toptile.transform.SetParent(parentObject.transform);
                b.bottomtile.transform.SetParent(parentObject.transform);
                b.bottomtile.name = "BottomTile " + boxnumber;
                //setting the indexes of the blocks
                b.indexX = columncounter;
                b.indexY = rowcounter;

               

                pos = (GameObject.Find("BottomTile " + boxnumber).transform.position);
                //Debug.Log(pos);
                string pos1 = pos.x.ToString() + "," +  pos.y.ToString();
                //Debug.Log(pos1);
                allPos.Add(pos1);
                grid.blocks.Add(b);
                
            }
            columncounter = 0;   
        }

        int counter = 0;
        int positionReduction = 19;
        string currentposition;
        while (counter != 10)
        {
            currentposition = allPos[counter];
            ProperLabeling.Add(currentposition);
            counter++;
        }
        while (counter != 20)
        {
            currentposition = allPos[positionReduction];
            positionReduction--;
            ProperLabeling.Add(currentposition);
            counter++;
        }
        while (counter != 30)
        {
            currentposition = allPos[counter];
            ProperLabeling.Add(currentposition);
            counter++;
        }
        positionReduction = 39;
        while (counter != 40)
        {
            currentposition = allPos[positionReduction];
            positionReduction--;
            ProperLabeling.Add(currentposition);
            counter++;
        }
        while (counter != 50)
        {
            currentposition = allPos[counter];
            ProperLabeling.Add(currentposition);
            counter++;
        }
        positionReduction = 59;
        while (counter != 60)
        {
            currentposition = allPos[positionReduction];
            positionReduction--;
            ProperLabeling.Add(currentposition);
            counter++;
        }
        while (counter != 70)
        {
            currentposition = allPos[counter];
            ProperLabeling.Add(currentposition);
            counter++;
        }
        positionReduction = 79;
        while (counter != 80)
        {
            currentposition = allPos[positionReduction];
            positionReduction--;
            ProperLabeling.Add(currentposition);
            counter++;
        }
        while (counter != 90)
        {
            currentposition = allPos[counter];
            ProperLabeling.Add(currentposition);
            counter++;
        }
        positionReduction = 99;
        while (counter != 100)
        {
            currentposition = allPos[positionReduction];
            positionReduction--;
            ProperLabeling.Add(currentposition);
            counter++;
        }
        grid.parent = parentObject;
        return grid;        
    }
    public void SetPlayerColors()
    {        
        //Debug.Log("Player 1 : " + gms.ChosenPlayer);       

        if (gms.PlayerOneColor == "Red")
        {
            PlayerOneColor = "Red";
            PLayerTwoColor = "Blue";
            //Debug.Log("Player 2 : Blue");
            PlayersSaved = true;
            //NetworkLayer.SetColor("Player 2", "Blue");
        }

        else
        {
            PlayerOneColor = "Blue";
            PLayerTwoColor = "Red";
            PlayersSaved = true;
            //Debug.Log("Player 2 : Red");
            //NetworkLayer.SetColor("Player 2", "Red");
        }
    }        

    public void GenerateRandomNumber()
    {

        GameStart = true;
        
       
        randomNumberSteps = UnityEngine.Random.Range(1, 7);
        Debug.Log(randomNumberSteps);
        randomNumberSteps = 1;
        NetworkLayer.Move(NetworkManager.PlayerName, randomNumberSteps);
        
    }

    void Update()
    {
        if (gms.PlayerChosen == true & PlayersSaved == false)
        {
            NetworkLayer.SetColor(NetworkManager.PlayerName, gms.ChosenPlayer);            
            PlayersSaved = true;
        }

        if (PlayersSaved == true & GamePrep == false)
        {

            NetworkLayer.SetBoard(PlayerOneColor);            
        }

        
    }

}
