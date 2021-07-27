using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public GameObject interactObject = null;
    public InteractionObject interObjScript = null;

    private Inventory inventory;

    public SpriteRenderer spriteRenderer;

    public Sprite idleUp;
    public Sprite idleDown;
    public Sprite idleRight;
    public Sprite idleLeft;

    void Start() {
        inventory = this.gameObject.GetComponent<Inventory>();
    }

    void Update(){
        if(Input.GetButtonUp("Submit") && interactObject){
            
            if(interObjScript.inventory){
                inventory.AddItem(interactObject);
            }

            
            if(interObjScript.talks){
                if(FaceObject(interactObject)){
                    interObjScript.Talk();
                }
            }

            if(interObjScript.NPC){
                if(FaceObject(interactObject)){
                    interObjScript.FacePlayer();
                }
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

    bool FaceObject(GameObject objToFace){
        if(transform.position.x == objToFace.transform.position.x){

            if(transform.position.y > objToFace.transform.position.y){

                if(spriteRenderer.sprite == idleDown){
                    return true;
                }else{
                    return false;
                }
            
            } else{

                if(spriteRenderer.sprite == idleUp){
                    return true;
                }else{
                    return false;
                }

            }

        } else if(transform.position.y == objToFace.transform.position.y){

            if(transform.position.x > objToFace.transform.position.x){

                if(spriteRenderer.sprite == idleLeft){
                    return true;
                }else{
                    return false;
                }
            } else{

                if(spriteRenderer.sprite == idleRight){
                    return true;
                } else{
                    return false;
                }
            }

        }else{
            return false;
        }
    }

}
