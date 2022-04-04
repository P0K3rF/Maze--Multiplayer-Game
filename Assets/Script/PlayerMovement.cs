using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : Photon.MonoBehaviour
{
    public GameObject PlayerCamera;
    public new PhotonView photonView;
    public Text PlayerName;
    public CharacterController control;
    public float speed = 15f;
    public Transform groundcheck;
    public float groundDistance = 0.5f;
    public LayerMask groundMask;
    public float Gravity = -9.81f;
    Vector3 velocity;
    bool isGrounded;
    public float jump = 3f;
    private void Awake(){
        if(photonView.isMine){
            PlayerCamera.SetActive(true);
            PlayerName.text=PhotonNetwork.playerName; 

        }
        else{
             PlayerName.text = photonView.owner.NickName;
            PlayerName.color=Color.cyan;        }
    }
        private void Update(){
            if(photonView.isMine){
                CheckInput();
                
            }
        }

   private void CheckInput() {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        control.Move(move * speed * Time.deltaTime);
        isGrounded = Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += Gravity * Time.deltaTime;
        control.Move(velocity * Time.deltaTime);
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            
            velocity.y = Mathf.Sqrt(jump * -2f * Gravity);
        }

    }
}