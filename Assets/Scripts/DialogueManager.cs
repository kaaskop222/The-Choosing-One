using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    private Queue<string> sentences;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartConversation(Dialogue dialogue){

        nameText.text = dialogue.name;

        player.GetComponent<PlayerMovement>().inConversation = true;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        
        if(sentences.Count == 0){
            EndConversation();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        
        
    }
    
    void EndConversation(){
        player.GetComponent<PlayerMovement>().inConversation = false;
    }
}
