using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    private bool isTyping = false;

    public GameObject player;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartConversation(Dialogue dialogue){
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        player.GetComponent<PlayerMovement>().inConversation = true;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if(!isTyping){

            if(sentences.Count == 0){
                EndConversation();
                return;
            }
        
            string sentence = sentences.Dequeue();
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    IEnumerator TypeSentence(string sentence){
        isTyping = true;
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
        dialogueText.text = sentence;
        isTyping = false;
    }
    
    void EndConversation(){

        
            player.GetComponent<PlayerMovement>().inConversation = false;
            animator.SetBool("isOpen", false);
        
    }
}
