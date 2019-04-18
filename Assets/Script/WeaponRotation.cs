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

    bool HasMouseMoved()
    {
        return (Input.GetAxis("Mouse X") != 0 || (Input.GetAxis("Mouse Y") != 0));
    }

    // Update is called once per frame
    void Update()
    {

        if (HasMouseMoved())
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 0;

            Vector3 objectPos = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = mousePos.x - objectPos.x;
            mousePos.y = mousePos.y - objectPos.y;

            float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            angle -= 180;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
