using UnityEngine;
using UnityEngine.SceneManagement;

public class outsideDoor : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnCollisionEnter2D(Collision2D other) {
        MainCharacterSimple player = other.gameObject.GetComponent<MainCharacterSimple>();
        if(player != null){
            SceneManager.LoadScene("LoreScene");
        }
    }
}
