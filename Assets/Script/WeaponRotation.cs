using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }


    private float rotation = 0;

    // Update is called once per frame
    void Update()
    {

        gameObject.transform.Rotate(Input.mousePosition);
    }
}
