using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePanel : MonoBehaviour
{
    [SerializeField]
    private Transform root;

    [SerializeField]
    private Game game;

    [SerializeField]
    private QuizButton quizButton;

    [SerializeField]
    private Text questionText;

    [SerializeField]
    private Transform panelParent;

    [SerializeField]
    private Dropdown dropdown;
    private Question question;
    private int idLanguage;

    private void Awake()
    {
        idLanguage = PlayerPrefs.GetInt("idLanguage");
    	dropdown.value = idLanguage;
    }

    private void Start()
    {
        root.gameObject.SetActive(false);
	question = null;    }

    public void SetPanelActive(bool state)
    {
        root.gameObject.SetActive(state);
    }

    public void Init(Question ques)
    {
	question = ques;
	SetUI();
	
    }

    private void SetUI()
    {
	if (question == null)
	{
        	return;
	}
        questionText.text = GetQuestionName();
	foreach (Transform child in panelParent)
	{
		 Destroy(child.gameObject);
	}
        foreach (var item in question.options)
        {
            var button = Instantiate(quizButton, panelParent);
            button.Init(item.id, GetOptionName(item));
            button.onClick +=ButtonPress;
        }
    }

    private string GetQuestionName()
    {
	string result = "";
 	switch (idLanguage)
      	{
          case 0:
	      result = question.name_ru;
              break;
          case 1:
	      result = question.name_eng;
              break;
     	}
        return result;	
    }

    private string GetOptionName(Option option)
    {
	string result = "";
	switch (idLanguage)
      	{
          case 0:
	      result = option.name_ru;
              break;
          case 1:
	      result = option.name_eng;
              break;
     	}
        return result;	
    }

    private void ButtonPress(int id)
    {
 
        game.SetAnswer(id);
    }

  

    public void LanguagePress(int idLang)
    {
	idLanguage = idLang;
	SetUI();
    }

    public void OnDestroy()
    {
            PlayerPrefs.SetInt("idLanguage", idLanguage);
    }

}
