using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int V = 0;
    public GameObject PlayerPrefab;
    public GameObject SceneCamera;
    public GameObject GameCanvas;
    public Text Ping;
    public GameObject ExitCanvas;

    private void Awake(){
        GameCanvas.SetActive(true);
    }
    private void Update(){
        Ping.text="Ping: "+ PhotonNetwork.GetPing();
        if(Input.GetKeyDown(KeyCode.Escape)){
            ExitCanvas.SetActive(true);
           
        }
        
        
    }
    public void SpawnPlayer(){
        PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3 (0f,1.5f,0f),Quaternion.identity,0);
        GameCanvas.SetActive(false);
        SceneCamera.SetActive(false);
    }
    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");

    }
   
}
