using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesHintScript : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        time = SaveScript.secondsLeft;
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.secondsLeft < time * 0.99)
        {
            gameObject.SetActive(true);
            Debug.Log("löajsdf");
        }
    }
}
