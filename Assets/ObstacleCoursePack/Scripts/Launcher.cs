
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView player;
    public PhotonView cam;
    //private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        //try to connect
        PhotonNetwork.ConnectUsingSettings();
        
    }
    public override void OnConnectedToMaster()
    {
        //we connected
        Debug.Log("connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }
    public override void OnJoinedRoom()
    {
        
        Debug.Log("Joined a room successfully");
        var Cam = (GameObject) PhotonNetwork.Instantiate(cam.name, new Vector3(-0.4081676f, 1.67f, -6.56f), Quaternion.identity);
        var Player = (GameObject)PhotonNetwork.Instantiate(player.name, new Vector3(-0.6674247f, 3, -0.5542111f), Quaternion.identity);
        /*Player.name = "playername" + i;
        Cam.name = "playercam" + i;
        Debug.Log(Player.name);
        Debug.Log(Cam.name);
        i++;*/
    }
}
