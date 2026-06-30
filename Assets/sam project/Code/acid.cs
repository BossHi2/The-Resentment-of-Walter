using UnityEngine;

public class acid : MonoBehaviour
{
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
            player.ChangeHealth(-1);
        }
    }
}
