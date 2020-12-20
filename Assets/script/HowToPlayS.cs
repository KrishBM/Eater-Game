using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayS : MonoBehaviour
{
    public GameObject kharu;

    // Start is called before the first frame update
    void Start()
    {
        kharu.SetActive(false);
        StartCoroutine(stop());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator stop()
    {

        yield return new WaitForSeconds(27);
        kharu.SetActive(true);
    }
}
