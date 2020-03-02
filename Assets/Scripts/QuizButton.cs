using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizButton : MonoBehaviour
{
    [SerializeField]
    private Text label;

    [SerializeField]
    private Button button;

    private int id;

    public Action<int> onClick;
    public void Init(int id, string text){
        this.id = id;
        label.text = text;
    }

    private void Start(){
        button.onClick.AddListener(OnButtonPressed);
    }

    private void OnButtonPressed(){
        if(onClick != null){
            onClick(id);
        }
    }

    private void OnDestroy() {
        button.onClick.RemoveAllListeners();
    }

}