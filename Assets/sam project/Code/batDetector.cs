using UnityEngine;

public class batDetector : MonoBehaviour
{
    public GameObject batParent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
         MainCharacter player = other.gameObject.GetComponent<MainCharacter>();

         if(player != null){
            batParent.GetComponent<Bat>().activateBat();
         }
    }
}
