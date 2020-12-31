using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public GameObject SpriteController;
    public string ChosenPlayer;
    public bool PlayerChosen;

    public string PlayerOneColor;
    public string PlayerTwoColor;

    GameObject gm;
    gameManager gms;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.name == "Red")

                {
                    //Debug.Log(hit.collider.gameObject.name + " clicked.");
                    ChosenPlayer = hit.collider.gameObject.name;
                    PlayerOneColor = ChosenPlayer;
                    if (PlayerOneColor == "Red")
                    {
                        PlayerTwoColor = "Blue";
                    }
                    PlayerChosen = true;
                    gms.GameStart = true;
                }

                if (hit.collider.gameObject.name == "Blue")

                {
                    //Debug.Log(hit.collider.gameObject.name + " clicked.");
                    ChosenPlayer = hit.collider.gameObject.name;
                    PlayerOneColor = ChosenPlayer;
                    if (PlayerOneColor == "Blue")
                    {
                        PlayerTwoColor = "Red";
                    }
                    PlayerChosen = true;
                    PlayerChosen = true;
                    gms.GameStart = true;
                }
            }
        }

    }

    public void Move(int steps)
    {
        gm = GameObject.Find("Scripts");
        gms = gm.GetComponent<gameManager>();
        StartCoroutine(MovePiece(steps));
    }

    IEnumerator MovePiece (int steps)
    {
        if(gms.CurrentPlaying == "Player1")
        {
            Debug.Log("MovePiece Method Entered");
            gms.PlayerOneSpace = gms.PlayerOneSpace + steps;
            //Debug.Log(gms.PlayerOneSpace);
            gms.getBoxPos(gms.allPos[gms.PlayerOneSpace]);
            gms.GameStart = true;
            gms.TurnEnded = false;
            gms.GamePrep = false;
            gms.Pieces();
            gms.GamePrep = true;
            yield return new WaitForSeconds(0.5f);
            gms.TurnEnded = false;
        }

        if (gms.CurrentPlaying == "Player2")
        {
            if(gms.TurnEnded == true)
            {
                Debug.Log("MovePiece Method Entered");
                gm = GameObject.Find("Scripts");
                gms = gm.GetComponent<gameManager>();
                gms.PlayerTwoSpace = gms.PlayerTwoSpace + steps;
                //Debug.Log(gms.PlayerOneSpace);
                gms.getBoxPos(gms.allPos[gms.PlayerTwoSpace]);
                gms.GameStart = true;
                gms.GamePrep = false;
                gms.TurnEnded = false;
                gms.Pieces();
                gms.GamePrep = true;
                yield return new WaitForSeconds(0.5f);
            }
            gms.TurnEnded = true;
            
        }


    }

    public void SetBoard()
    {
        gm = GameObject.Find("Scripts");
        gms = gm.GetComponent<gameManager>();

        gms.PiecesCreated = true;
        gms.GamePrep = true; 
        gms.Pieces();
        //gms.GamePrep = false;
    }

    
}