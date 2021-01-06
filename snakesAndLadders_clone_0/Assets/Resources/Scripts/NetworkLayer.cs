using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkLayer : MonoBehaviour
{
    private static PhotonView ScriptsPhotonView;
    // Start is called before the first frame update
    void Start()
    {
        ScriptsPhotonView = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Move(string playerName, int numberOfSteps)
    {
        playerName = "Red";
        ScriptsPhotonView.RPC("MoveStepsRPC", PhotonTargets.All, playerName, numberOfSteps);      
    }
    [PunRPC]
    public void MoveStepsRPC(string playerName, int numberOfSteps)
    {
        //print("Network Layer : " + playerName + " - " + numberOfSteps);
        GameObject.Find(playerName).GetComponent<PlayerSelect>().Move(numberOfSteps);          
    }




    public static void SetColor()
    {
        ScriptsPhotonView.RPC("SetColorRPC", PhotonTargets.All);
    }
    [PunRPC]
    public void SetColorRPC()
    {
        GameObject.Find("Scripts").GetComponent<gameManager>().SetPlayerColors();
    }




    public static void SetBoard(string playerName)
    {
        ScriptsPhotonView.RPC("SetBoardRPC", PhotonTargets.All,playerName);
    }
    [PunRPC]
    public void SetBoardRPC(string playerName)
    {
        Debug.Log(playerName);
        
        GameObject.Find(playerName).GetComponent<PlayerSelect>().SetBoard();
    }



    public static void SetNames(string playerName)
    {
        ScriptsPhotonView.RPC("SetNamesRPC", PhotonTargets.All, playerName);
    }
    [PunRPC]
    public void SetNamesRPC(string playerName)
    {
        
        GameObject.Find("Scripts").GetComponent<gameManager>().SetPlayerName(playerName);
    }




    public static void Generate(string playerName)
    {
        ScriptsPhotonView.RPC("GenerateRpc", PhotonTargets.All, playerName);
    }
    [PunRPC]
    public void GenerateRpc(string playerName)
    {

        GameObject.Find("Scripts").GetComponent<gameManager>().GenerateRandomNumber();
    }




    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info )
    {

    }
}
