using UnityEngine;

public class NPC : MonoBehaviour
{
    public float displayTime = 10f;
    public GameObject dialogBox;
    float timeDisplayed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogBox.SetActive(false);
        timeDisplayed = -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeDisplayed >= 0)
        {
            timeDisplayed -= Time.deltaTime;

            if(timeDisplayed < 0)
            {
                dialogBox.SetActive(false);
            }
        }
    }

    public void DisplayDialog()
    {
        timeDisplayed = displayTime;
        dialogBox.SetActive(true);
    }
}
