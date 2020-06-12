using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class VoiceControl : MonoBehaviour {

    // Voice command vars
    private Dictionary<string, Action> keyActs = new Dictionary<string, Action>();
    private KeywordRecognizer recognizer;

    // Var needed for color manipulation
    private MeshRenderer cubeRend;

    // Var needed for spin manipulation
    private bool spinningRight;

    // Var needed for sound playback
    private AudioSource soundSource;
    public AudioClip[] sounds;

    private void Start()
    {
        cubeRend = GetComponent<MeshRenderer>();
        soundSource = GetComponent<AudioSource>();

        //  Voice commands for changing color 
        keyActs.Add("red", Red);
        keyActs.Add("green", Green);
        keyActs.Add("Blue", Blue);
        keyActs.Add("white", White);

        //  Voice commands for spinning
        keyActs.Add("spin right", SpinRight);
        keyActs.Add("spin left", SpinLeft);

        //  Voice commands for playing sounds
        keyActs.Add("please say something", Talk);

        //  Voice commands for playing sounds
        keyActs.Add("please say something", Talk);

        //  Voice command to show how complex it can get.
        keyActs.Add("pizza is a wonderful food", FactAcknowledgement);

        recognizer = new KeywordRecognizer(keyActs.Keys.ToArray());
        recognizer.OnPhraseRecognized += OnKeywordsRecognized;
        recognizer.Start();
    }

    void OnKeywordsRecognized(PhraseRecognizedEventArgs args)
    {
        Debug.Log("Command: " + args.text);
        keyActs[args.text].Invoke();
    }
    void Red()
    {
        cubeRend.material.SetColor("_Color", Color.red);
    }
    void Green()
    {
        cubeRend.material.SetColor("_Color", Color.green);
    }
    void Blue()
    {
        cubeRend.material.SetColor("_Color", Color.blue);
    }
    void White()
    {
        cubeRend.material.SetColor("_Color", Color.white);
    }
    void SpinRight ()
    {
        spinningRight = true;
        StartCoroutine(RotateObject(1f));
    }
    void SpinLeft()
    {
        spinningRight = false;
        StartCoroutine(RotateObject(1f));
    }

    private IEnumerator RotateObject(float duration)
    {
        float startRot = transform.eulerAngles.x;
        float endRot;

        if (spinningRight)
            endRot = startRot - 360f;
        else
            endRot = startRot + 360f;

        float t = 0f;
        float yrot;

        while (t<duration)
        {
            t += Time.deltaTime;
            yrot = Mathf.Lerp(startRot, endRot, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yrot, transform.eulerAngles.z);
            yield return null;

        }
    }
    void Talk()
    {
        soundSource.clip = sounds[UnityEngine.Random.Range(0, sounds.Length)];
        soundSource.Play();
    }
    void FactAcknowledgement ()
    {
        Debug.Log("How right you are.");
    }
}




