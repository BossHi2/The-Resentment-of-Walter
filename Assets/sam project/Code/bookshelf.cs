using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class bookshelf : MonoBehaviour
{
    public SpriteMask myMask;
    public GameObject paperUI;
    Animator paperAnim;

    bool isPaperOpened = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        paperAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPaperOpened == true && Input.GetKeyDown(KeyCode.Space)){
            paperUI.SetActive(false);
        }
    }

    public void lightUp(){
        myMask.enabled = true;
    }
    public void lightDown(){
        myMask.enabled = false;
    }

    public void getPaper(){
        if(isPaperOpened == false){
            StartCoroutine(dropPaperAnimation());
        } else{
            paperUI.SetActive(false);
            isPaperOpened = false;
        }
        
    }
    IEnumerator dropPaperAnimation(){
        
        paperAnim.Play("paperDropping");

        yield return new WaitForSeconds(1f);

        isPaperOpened = true;
        paperUI.SetActive(true);
        
    }
}
