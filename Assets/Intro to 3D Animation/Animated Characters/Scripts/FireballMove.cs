using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed; 
    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.forward * speed * Time.deltaTime);  
    }
}
