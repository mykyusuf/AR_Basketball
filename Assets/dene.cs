using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class dene : MonoBehaviour {

    private KeywordRecognizer keywordRecoginizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    public void Start()
    {
        actions.Add("forward", Forward);
        actions.Add("back", Back);
        actions.Add("up", Up);
        actions.Add("down", Down);

        keywordRecoginizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecoginizer.OnPhraseRecognized += RecSpeech;
        keywordRecoginizer.Start();

    }

    private void RecSpeech(PhraseRecognizedEventArgs speech)
    {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }

    private void Forward()
    {

    }
    private void Back()
    {

    }
    private void Up()
    {

    }
    private void Down()
    {

    }
}
