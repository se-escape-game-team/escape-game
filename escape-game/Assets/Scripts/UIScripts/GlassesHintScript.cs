using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassesHintScript : MonoBehaviour
{
    [SerializeField] GameObject hint;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            hint.SetActive(true);
            Debug.Log("löajsdf");
        }
    }
}
