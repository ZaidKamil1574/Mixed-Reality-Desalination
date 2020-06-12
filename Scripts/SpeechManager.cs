using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity.InputModule;

public class SpeechManager : MonoBehaviour
{


    private KeywordRecognizer keywordRecognizer = null;

    private Dictionary<string, System.Action> keywordsDictionary = new Dictionary<string, System.Action>();

    [Header("Set this with your particle system")]

    public GameObject particleSystemLocal;

    // Use this for initialization
    void Start()
    {
        keywordsDictionary.Add("Reload Scene", () =>
        {
            //eeeee
            this.BroadcastMessage("Reload");
        });


        keywordsDictionary.Add("Start App", () =>
        {
            GameObject focusedObject = GazeGestureManager.Instance.focusedObject;

            if (null != focusedObject)
            {


                focusedObject.SendMessage("StartApp", SendMessageOptions.DontRequireReceiver);
            }
        });

        keywordsDictionary.Add("White Christmas", () =>
        {
            particleSystemLocal.SetActive(!particleSystemLocal.activeInHierarchy);
        });

        keywordRecognizer = new KeywordRecognizer(keywordsDictionary.Keys.ToArray());

        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();

    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;

        if (keywordsDictionary.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();

        }
    }





    
	}
	
