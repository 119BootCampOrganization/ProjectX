using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMovement : MonoBehaviour
{
    public float Gspeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Gspeed * Time.deltaTime);
    }
}
