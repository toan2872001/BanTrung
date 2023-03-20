using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public GameObject gameoverPannel;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    public void SetScoreText(string txt)
    {
        if (scoreText)
        {
            scoreText.text = txt;
        }
    }
    public void ShowGameoverPannel(bool isShow)
    {
        if (gameoverPannel)
        {
            gameoverPannel.SetActive(isShow);
        }
    }
    
}
