using UnityEngine;

public class swordCollectable : MonoBehaviour
{
    public SpriteMask myMask;
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
    public void collectSword(){
        Destroy(gameObject); 
    }
}
