using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    public static UIHealthBar instance {get; private set;}
    public Image mask;
    float originalSize;

    void Awake(){
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originalSize = mask.rectTransform.rect.width;
    }
    public void SetValue(float value){
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize * value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
