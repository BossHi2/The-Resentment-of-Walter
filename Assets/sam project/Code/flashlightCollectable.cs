using UnityEngine;

public class flashlightCollectable : MonoBehaviour
{
    public SpriteMask myMask;
    public GameObject flashlightObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lightUp(){
        myMask.enabled = true;
    }
    public void lightDown(){
        myMask.enabled = false;
    }
    public void collectFlashlight(){
        flashlightObj.SetActive(true);
        Destroy(gameObject); 
    }
}
