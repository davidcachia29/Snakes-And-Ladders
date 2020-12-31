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




    public static void SetColor(string playerName, string color)
    {
        ScriptsPhotonView.RPC("SetColorRPC", PhotonTargets.All, playerName, color);
    }
    [PunRPC]
    public void SetColorRPC(string playerName, string color)
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




    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info )
    {

    }
}
