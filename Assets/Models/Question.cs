using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question
{
    public int id;
    public string name_ru;
    public string name_eng;
    public int right_answer_id;
    public List<Option> options;
}
