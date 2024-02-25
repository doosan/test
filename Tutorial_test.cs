using SlotKingdoms;
using SlotKingdoms.Popup;
using SlotKingdoms.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static Spine.Unity.Examples.SpineboyFootplanter;

public class Tutorial_test : MonoBehaviour
{
    public TutorialPopup tutorialPopup;
    public TMP_InputField inputField;
    public Button button;

    private void Start()
    {
        button.interactable = false;
        StartCoroutine(PopupSystem.Instance.PrepareAssetsCoroutine(null, ()=>
        {
            button.interactable = true;
        }, null));
    }

    public void TestPlay()
    {
        if(tutorialPopup != null) 
        {
            PopupSystem.Instance.Close(tutorialPopup);
        }
        
        int Index = int.Parse(inputField.text);
        PopupSystem.Instance.OpenLoadPopup<TutorialPopup>(p =>
        {
            tutorialPopup = p;
            p.Initialize(Index);
        }
        , p =>
        {
            p.Open();
        });
    }    
}