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

    public float speed = 5f;
    // Update is called once per frame
    void Update()
    {

            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotationalAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rotationalAngle -= 180;
            Quaternion rotation = Quaternion.AngleAxis(rotationalAngle, Vector3.forward);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

    }
}
