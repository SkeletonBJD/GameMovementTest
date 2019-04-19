using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerController playerController = Player.GetComponent<PlayerController>();

    }

    public float speed = 5.0f;
    //攻击需要多长时间，这里是0.2秒
    public float attackspeed = 0.2f;

    bool attacking;
    float attacktimer=0;
    // Update is called once per frame

    public void attack()
    {
        if (!attacking)
        {
            Debug.Log("Launching Attack");
            attacktimer = attackspeed;
            attacking=true;
        }
    }


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Mouse Released");
            attack();
        }
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float D = 0;
        if (attacking)
        {
            transform.position = transform.parent.position;
            Debug.Log("Attack timer: " + attacktimer);
            attacktimer -= Time.deltaTime;
            if (attacktimer < 0)
            {
                attacktimer = 0;
                attacking = false;
            }
            float t = 4* ((attackspeed - attacktimer) / attackspeed - 0.5f);
            D = 0.2f * t*t;
            transform.Translate(D, 0, 0);
        }
        float rotationalAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotationalAngle -= 180;
        Quaternion rotation = Quaternion.AngleAxis(rotationalAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
