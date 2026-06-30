using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class flashlightLight : MonoBehaviour
{
    public float sizeChangeSpeed = 5f;


    public float originalScale = 9f;
    bool isCollided = false;
    bool hasExited = false;
    bool hasCollidedAfterExiting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UnityEngine.Debug.Log("objects that block the light is called light blockers. Flashlight goes to flashlight layer");
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollided == false){
            if(transform.localScale.y + sizeChangeSpeed * Time.deltaTime < originalScale)
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + sizeChangeSpeed * Time.deltaTime, transform.localScale.z);
            else{
                transform.localScale = new Vector3(transform.localScale.x, originalScale, transform.localScale.z);
            }
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        UnityEngine.Debug.Log(other);
        isCollided = true;
        if(hasExited)
            hasCollidedAfterExiting = true;
        
        if((transform.localScale.y - sizeChangeSpeed * Time.deltaTime) > 0)
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - sizeChangeSpeed * Time.deltaTime, transform.localScale.z);

    }
    void OnTriggerExit2D(Collider2D other)
    {
        hasExited = true;
        StartCoroutine(wait());
    }

    IEnumerator wait(){
        yield return new WaitForSeconds(0.5f);
        if(hasCollidedAfterExiting == false){
            isCollided = false;
            
        }
        hasExited = false;
        hasCollidedAfterExiting = false;
            
    }
}
