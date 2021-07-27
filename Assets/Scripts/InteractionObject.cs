using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public GameObject player;

    public bool inventory;
    public bool talks;
    public bool NPC;

    public SpriteRenderer spriteRenderer;

    public Sprite idleUp;
    public Sprite idleDown;
    public Sprite idleRight;
    public Sprite idleLeft;

    private Sprite standardSprite;

    public Dialogue dialogue;    

    private void Start() {
        standardSprite = spriteRenderer.sprite;
    }

    public void FacePlayer(){
        if(player.transform.position.x ==  transform.position.x){
            if(player.transform.position.y > transform.position.y){
                spriteRenderer.sprite = idleUp;
            }else{
                spriteRenderer.sprite = idleDown;
            }
        }else{
            if(player.transform.position.x > transform.position.x){
                spriteRenderer.sprite = idleRight;
            }else{
                spriteRenderer.sprite = idleLeft;
            }
        }
    }    

    public void Talk(){
        if(!player.GetComponent<PlayerMovement>().inConversation){
            FindObjectOfType<DialogueManager>().StartConversation(dialogue);
        }else{
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }
    }
}
