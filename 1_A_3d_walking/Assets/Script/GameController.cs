using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{

    public static GameController Instance;

    public TextMeshProUGUI text;
    private float Score = 0;


    private void Awake()
    {
        Instance = this;
    }


    public void AddScore(float value)
    {
        Score += value;
        UpdateUI();
    }


    private void UpdateUI()
    {
        text.text = Score.ToString();
    }


}
