using UnityEngine;
using TMPro;

public class BookScript : MonoBehaviour
{

    public int riddleNum;
    public GameObject paperUI;
    public TextMeshProUGUI paperText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText()
    {
        paperText.text = GetPaperText();
        paperUI.SetActive(true);
    }

    string GetPaperText()
    {
        string text = "Clue for exit digit " + riddleNum + ":\n";
        text += Riddles.digitToRiddle[int.Parse("" + Riddles.code[riddleNum - 1])];
        return text;
    }
}
