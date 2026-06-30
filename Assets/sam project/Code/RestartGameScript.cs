using UnityEngine;
using UnityEngine.SceneManagement; 
public class RestartGameScript : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("Outside"); 
    }
}
