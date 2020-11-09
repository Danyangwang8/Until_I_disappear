using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour {

    public Text Anna_Text;
    public Text Me_Text;

    private Queue<string> sentences;
    private Queue<string> Anna;

	// Use this for initialization
	void Start () {
        Anna = new Queue<string>();
        sentences = new Queue<string>();
       
	}
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start Dialogue"+dialogue.Anna);
        Anna.Clear();
        sentences.Clear();
        
        foreach (string anna in dialogue.Anna)
        {
            Anna.Enqueue(anna);
        }
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }
    public void DisplayAnnaNextSentence()
    {
        if (Anna.Count == 0)
        {
            EndDialogue();
            return;
        }
        string anna = Anna.Dequeue();
        Debug.Log(anna);
        StopAllCoroutines();
        Anna_Text.text = anna;
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 )
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
       
        Debug.Log(sentence);
        
        StopAllCoroutines();
        // StartCoroutine(TypeSentence(sentence));
        Me_Text.text = sentence;
    }
 
    //IEnumerator TypeSentence (string sentence)
    //{
    //    AnnaText.text = "";
    //    MeText.text = "";
    //    foreach(char letter in sentence.ToCharArray())
    //    {
    //        AnnaText.text += letter;
    //        MeText.text += letter;
    //        yield return null;
    //    }

    //}
    void EndDialogue()
    {
        Debug.Log("End of conversation.");
    }

}
