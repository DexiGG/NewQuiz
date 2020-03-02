using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

   [SerializeField]
   private GamePanel gamePanel;

   [SerializeField]
   private ResultPanel resultPanel;
   private int i;
   private int countCorrect;
   private bool isGame;

   private IList<Question> list;

    public void Init(IList<Question> listValue)
    {
        list = listValue;
    }

    public void Start()
    {
        i = 0;
        countCorrect = 0;
        gamePanel.SetPanelActive(true);
	gamePanel.Init(list[i]);
       
    }
    public void SetAnswer(int answer)
    {
            if (answer == list[i].right_answer_id)
            {
                countCorrect++;
            }
            if( i == (list.Count - 1))
            {
                gamePanel.SetPanelActive(false);
                resultPanel.SetPanelActive(true);
		resultPanel.SetText(i + 1, countCorrect);
            }
            else
            {
                i++;
		gamePanel.Init(list[i]);
            }
    }

}
