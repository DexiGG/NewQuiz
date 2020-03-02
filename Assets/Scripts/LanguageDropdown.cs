using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageDropdown : MonoBehaviour
{
    [SerializeField]
    private GamePanel gamePanel;

    public void Dropdown_IndexChanged(int index)
    {
	gamePanel.LanguagePress(index);
    }  

}
