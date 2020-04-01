using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Windows.Speech;

//speech recognition tutorial: https://www.youtube.com/watch?v=HwT6QyOA80E
public class VoiceCommands_Jig: MonoBehaviour{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, System.Action> actions = new Dictionary<string, System.Action>();
    private float movement = 0.05f;
    private float movementDefault = 0.05f;
    private float movementMin = 0.01f;
    private float movementMax = 0.10f;
    private float movementChange = 0.01f;

    private float rotation = 5f;
    private float rotationDefault = 5;
    private float rotationMin = 1f;
    private float rotationMax = 20;
    private float rotationChange = 1f;

    void Start(){
        // == add the voice commands to the actions dictionary
        Add_Movement();
        Add_Rotation();
        Add_MovementModification();
        Add_RotationModification();

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

    private void Add_Movement(){
        // == movement ==
        //  adds commands to the actions dictionary
            // == right
        actions.Add("move right", () =>{
            Debug.Log("You said right");
            transform.Translate(movement, 0, 0);
        });
            // == left
        actions.Add("move left", () =>{
            Debug.Log("You said left");
            transform.Translate(-movement, 0, 0);
        });
            // == in
        actions.Add("move in", () =>{
            Debug.Log("You said in");
            transform.Translate(0, -movement, 0);
        });
            // == out
        actions.Add("move out", () =>{
            Debug.Log("You said out");
            transform.Translate(0, movement, 0);
        });
            // == up 
        actions.Add("move up", () =>{
            Debug.Log("You said up");
            transform.Translate(0, 0, -movement);
        });
            // == out
        actions.Add("move down", () =>{
            Debug.Log("You said down");
            transform.Translate(0, 0, movement);
        });

    }

    private void Add_Rotation(){
        // == rotation ==
        //  adds commands to the actions dictionary
            // == right
        actions.Add("rotate right", () =>{
            Debug.Log("You said rotate right");
            transform.Rotate(0, 0, rotation);
        });
            // == left
        actions.Add("rotate left", () =>{
            Debug.Log("You said rotate left");
            transform.Rotate(0, 0, -rotation);
        });
            // == up 
        actions.Add("rotate up", () =>{
            Debug.Log("You said rotate up");
            transform.Rotate(rotation, 0, 0);
        });
            // == down 
        actions.Add("rotate down", () =>{
            Debug.Log("You said rotate down");
            transform.Rotate(-rotation, 0, 0);
        });

    }

    private void Add_MovementModification(){
        actions.Add("increase movement", () =>{
            Debug.Log("You said increase movement");
            if (movement < movementMax)
                movement += movementChange;
            else
                Debug.Log("Movement already at maximun value");
            Debug.Log("Movement: " + movement);
        });
        actions.Add("decrease movement", () =>{
            Debug.Log("You said increase movement");
            if (movement > movementMin)
                movement -= movementChange;
            else
                Debug.Log("Movement already at minimun value");
            Debug.Log("Movement: " + movement);
        });

        actions.Add("max movement", () =>{
            Debug.Log("You said max movement");
            movement = movementMax;
            Debug.Log("Movement: " + movement);
        });

        actions.Add("min movement", () =>{
            Debug.Log("You said min movement");
            movement = movementMin;
            Debug.Log("Movement: " + movement);
        });

        actions.Add("reset movement", () =>{
            Debug.Log("You said reset movement");
            movement = movementDefault;
            Debug.Log("Movement: " + movement);
        });

    }

    private void Add_RotationModification(){
        actions.Add("increase rotation", () =>{
            Debug.Log("You said increase rotation");
            if (rotation < rotationMax)
                rotation += rotationChange;
            else
                Debug.Log("Rotation already at maximun value");
            Debug.Log("Rotation: " + rotation);
        });
        actions.Add("decrease rotation", () =>{
            Debug.Log("You said increase rotation");
            if (rotation > rotationMin)
                rotation -= rotationChange;
            else
                Debug.Log("Rotation already at minimun value");
            Debug.Log("Rotation: " + rotation);
        });

        actions.Add("max rotation", () =>{
            Debug.Log("You said max rotation");
            rotation = rotationMax;
            Debug.Log("Rotation: " + rotation);
        });

        actions.Add("min rotation", () =>{
            Debug.Log("You said min rotation");
            rotation = rotationMin;
            Debug.Log("Rotation: " + rotation);
        });

        actions.Add("reset rotation", () =>{
            Debug.Log("You said reset rotation");
            rotation = rotationDefault;
            Debug.Log("Rotation: " + rotation);
        });
    }
}
