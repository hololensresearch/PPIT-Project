
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

//speech recognition tutorial: https://www.youtube.com/watch?v=HwT6QyOA80E
public class VoiceCommands_Body: MonoBehaviour{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();

    void Start(){
        Add_Commands();

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    } 

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    /*
    private void In(){
        Debug.Log("You said In");
        transform.Translate(, 0, 0);
    }
    */

    private void Add_Commands(){
        //  adds commands to the actions dictionary
        actions.Add("hide", () =>{
            Debug.Log("You said hide");
            gameObject.SetActive(false);
        });

        actions.Add("show", () =>{
            Debug.Log("You said show");
            gameObject.SetActive(true);
        });
    }
}
