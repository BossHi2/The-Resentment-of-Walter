using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CodeScript : MonoBehaviour
{
    public TMP_InputField inputText;
    public TextMeshProUGUI prompt;
    public bool isSafe;
    public GameObject safe;
    public GameObject exitDoor;
    public GameObject safeCollider;
    public GameObject safeClue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            checkCode();
        }
    }

    public void checkCode()
    {
        string userInput = inputText.text;
        if ((userInput == Riddles.safeCode && isSafe) || (userInput == Riddles.code && !isSafe))
        {
            if (isSafe)
            {
                Destroy(safe);
                Destroy(safeCollider);
                safeClue.SetActive(true);
            }
            else
            {
                Destroy(exitDoor);
            }
        }
        else
        {
            prompt.text = "Incorrect";
        }
    }
}
