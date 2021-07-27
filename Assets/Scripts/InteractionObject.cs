using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public GameObject player;
    
    public bool talks;
    public bool NPC;


    public Dialogue dialogue;    

    public void FacePlayer(){
        // if(player.transform.position.x ==  transform.position.x){
        //     if(player.transform.position.y > transform.position.y){
        //         Debug.Log("up");
        //     }else{
        //         Debug.Log("down");
        //     }
        // }else{
        //     if(player.transform.position.x > transform.position.x){
        //         Debug.Log("right");
        //     }else{
        //         Debug.Log("left");
        //     }
        // }
    }    

    public void Talk(){
        if(!player.GetComponent<PlayerMovement>().inConversation){
            FindObjectOfType<DialogueManager>().StartConversation(dialogue);
        }else{
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
