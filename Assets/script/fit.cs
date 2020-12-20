using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fit : MonoBehaviour
{
    private int fullscreen;

    private void Start()
    {
    }
    private void Awake()
    {
        RectTransform objectRectTransform = gameObject.GetComponent<RectTransform>();
        //objectRectTransform.anchoredPosition3D = new Vector2(1, Screen.height);
        objectRectTransform.anchoredPosition = new Vector2(100,1);
        float a = objectRectTransform.rect.width;
        objectRectTransform.sizeDelta = new Vector2(Screen.width , Screen.height * -1.63f);
        print('d');
    }
}
