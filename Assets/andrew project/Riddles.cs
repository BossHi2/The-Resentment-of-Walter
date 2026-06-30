using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Riddles : MonoBehaviour
{
    public static string code = "";
    public static string safeCode = "";
    public static Dictionary<int, string> digitToRiddle = new Dictionary<int, string>();
    public GameObject scrollUI;
    public TextMeshProUGUI scrollText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scrollText.text = "Safe code: " + safeCode;
    }

    void Awake()
    {
        for(int i=0; i<5; i++)
        {
            int randomNum = Random.Range(0, 10);
            while (code.IndexOf("" + randomNum) > -1)
            {
                randomNum = Random.Range(0, 10);
            }
            code += randomNum;
            int randomNum2 = Random.Range(0, 10);
            while (safeCode.IndexOf("" + randomNum2) > -1)
            {
                randomNum2 = Random.Range(0, 10);
            }
            safeCode += randomNum2;
        }
        digitToRiddle.Add(0, "There is nothing left in this mansion.");
        digitToRiddle.Add(1, "It's getting very lonely here.");
        digitToRiddle.Add(2, "Sometimes, it takes a second try to get things right");
        digitToRiddle.Add(3, "It only took a bit less than half a week for this mansion to be reduced to shambles");
        digitToRiddle.Add(4, "I wish I had a clover right now, as I heard that they bring luck");
        digitToRiddle.Add(5, "From 11am to 4pm every weekend, people would visit this mansion. Life was good.");
        digitToRiddle.Add(6, "Before things went wrong, I had a fanbase of 6 million people.");
        digitToRiddle.Add(7, "From now on, whoever enters this mansion will need a lot of luck to escape");
        digitToRiddle.Add(8, "It took two years less than a decade for me to finally achieve my dream of becoming a millionaire");
        digitToRiddle.Add(9, "I've always wished that I had a cat. Myths say that they have many lives.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
