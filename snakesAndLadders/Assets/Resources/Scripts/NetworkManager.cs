using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public GUIStyle TextStyle = new GUIStyle();
    public GameObject myPlayer;
    public static string PlayerName;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
        PhotonNetwork.logLevel = PhotonLogLevel.Full;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnJoinedLobby()
    {
        //when connected to lobby auto join to room
        PhotonNetwork.JoinRandomRoom();
    }

    void OnPhotonRandomJoinFailed()
    {
        //if room does not exist, create one automatically
        PhotonNetwork.CreateRoom(null);
    }

    void OnJoinedRoom()
    {
        print("Connected To Room");

        //myPlayer = PhotonNetwork.Instantiate("Player", Vector3.up, Quaternion.identity, 0);
        GameObject.Find("Main Camera");
            

        if (PhotonNetwork.isMasterClient == false)
        {
            print("This instance is not the master client");
           
        }


        if (PhotonNetwork.playerList.Length == 1)
            PlayerName = "Player1";

        else if (PhotonNetwork.playerList.Length == 2)
            PlayerName = "Player2";

        print("Assigned Player Name:" + PlayerName);


    }

    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString(), TextStyle);
    }
}
