using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class loreText : MonoBehaviour
{
    public TMP_Text loreTxt;
    public float typeSpeed;
    public float timeBetweenSentences;
    public AudioSource type;

    float currTime = 0f;
    string[] texts = new string[]{"The mansion you are about to visit is the mansion of Walter.",  "Walter is a rich millionare who had been accidentally murdered by your mother.", "The ghost version of Walter now haunts this mansion...",  "He is now spending the rest of his afterlife seeking revenge on your bloodline.", "Good luck."};
    int currIndex = 1;
    int textIndex = 0;
    float currTimeBetweenSentences = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        loreTxt.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if(currTime >= typeSpeed){
            if((currIndex + 1) <= (texts[textIndex].Length+1)){
                if (!type.isPlaying)
                {
                    type.Play();
                }
                currTime = 0;
                loreTxt.text = texts[textIndex].Substring(0, currIndex);
                currIndex++;
            } else{
                type.Pause();
                currTimeBetweenSentences += Time.deltaTime;
                if(currTimeBetweenSentences >= timeBetweenSentences){
                    currTime = 0;
                    loreTxt.text = "";
                    currIndex = 1;
                    textIndex++;
                    currTimeBetweenSentences = 0;
                    if(textIndex == texts.Length){
                        SceneManager.LoadScene("Mansion(1)");
                    }
                }
            }
                
        } else{
            currTime += Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            type.Pause();
            if(loreTxt.text == texts[textIndex]){
                loreTxt.text = "";
                currTime = 0;
                currIndex = 1;
                textIndex++;
                currTimeBetweenSentences = 0;
                if(textIndex == texts.Length){
                    SceneManager.LoadScene("Mansion(1)");
                }
            } else{
                loreTxt.text = texts[textIndex];
                currIndex = texts[textIndex].Length+1;
            }
        }
    }
}
