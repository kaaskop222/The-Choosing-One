using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactObject = null;
    public InteractionObject interObjScript = null;

    void Update(){
        if(Input.GetButtonUp("Submit") && interactObject){
            
            if(interObjScript.talks){
                interObjScript.Talk();
            }

            if(interObjScript.NPC){
                interObjScript.FacePlayer();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("InterObject"))
        interactObject = other.gameObject;
        interObjScript = other.GetComponent<InteractionObject>();
    }

    void OnTriggerExit2D(Collider2D other){
       if(other.CompareTag("InterObject") && interactObject == other.gameObject)
        interactObject = null;
        
    }



}
