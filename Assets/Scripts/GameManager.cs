using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class GameManager : MonoBehaviour
{
   [SerializeField]
   private Game game;

    IList<Question> list;

    private void Start()
    {

      list = ReadJson();

      if (list != null)
      {
	 game.Init(list);
      }

    }

   // считать JSON-файл в List()
    private IList<Question> ReadJson()
    {
      string filename = Path.Combine(Application.streamingAssetsPath, "Questions.json");
      if (File.Exists(filename))
      {
         string inputString = File.ReadAllText(filename);
         RootObject ro = JsonUtility.FromJson<RootObject>(inputString);
         return ro.Questions;
      }
      else
      {
         Debug.Log("File '" + filename + "' not found!");
         return null;
      }
    }

}
