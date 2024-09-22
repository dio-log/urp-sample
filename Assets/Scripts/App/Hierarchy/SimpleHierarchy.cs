using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleHierarchy : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas canvas;
    void Start()
    {
       // Rect rect = new Rect();

       var go = new GameObject();
       // go.AddComponent<RectTransform>();
       go.AddComponent<Image>();

       
       go.transform.SetParent(canvas.transform);


    }

    void Update()
    {
        
    }
}
