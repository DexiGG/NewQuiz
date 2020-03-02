using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;

    [SerializeField]
    private Game game;

    [SerializeField]
    private Text resultCalcText, allCountText, correctCountText;

    [SerializeField]
    private Button retryBtn, quitlBtn;

    private void Start()
    {
        root.gameObject.SetActive(false);
        retryBtn.onClick.AddListener(OnRetryClick);
        quitlBtn.onClick.AddListener(OnQuitClick);
    }

    public void SetPanelActive(bool state)
    {
        root.gameObject.SetActive(state);
    }

    public void SetText(int all, int correct)
    {
	double result = 0;
	if(all != 0)
	{
		result = Math.Truncate((correct/(double) all) * 100);
	}

	resultCalcText.text = "РЕЗУЛЬТАТ :  " + result;
        allCountText.text = "КОЛИЧЕСТВО ВОПРОСОВ :  " + all;
        correctCountText.text = "ПРАВИЛЬНЫХ ОТВЕТОВ :  " + correct;
    }

    private void OnRetryClick()
    {
        // отключаем панель на рестарте игры
        root.gameObject.SetActive(false);
	// рестарт игры
        game.Start();
    }

    private void OnQuitClick()
    {
      	Application.Quit();
    }

    private void OnDestroy()
    {
        retryBtn.onClick.RemoveAllListeners();
        quitlBtn.onClick.RemoveAllListeners();
    }

}
