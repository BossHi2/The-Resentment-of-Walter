using UnityEngine;
using System.Collections;
using TMPro;

public class DialogueScript : MonoBehaviour
{
    public bool isFriend;
    public bool isMother;
    public bool isPolice;
    public TextMeshProUGUI dialogueBox;
    ArrayList dialogues = new ArrayList();
    int currentIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isFriend)
        {
            dialogues.Add("Hello! Have you heard what people are saying about the house behind me?");
            dialogues.Add("They say that a millionaire once owned this house, and one day died in it.");
            dialogues.Add("However, there are rumors that his ghost haunts the house and kills anyone who enters.");
            dialogues.Add("We don't know if these rumors are true or not, so why don't you enter and find out?");
        }
        if (isPolice)
        {
            dialogues.Add("You're alive? Thank goodness, we thought you were a goner.");
            dialogues.Add("We received a report that you went into this house.");
            dialogues.Add("You should've known that this house is extremely dangerous. His ghost never left, after all.");
            dialogues.Add("We'll be closing off this area from now on. Good job on making it out.");
        }
        dialogueBox.text = (string)dialogues[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentIndex++;
            if (currentIndex >= dialogues.Count)
            {
                currentIndex--;
            }
            dialogueBox.text = (string)dialogues[currentIndex];
        }
    }
}
