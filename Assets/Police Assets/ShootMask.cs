using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMask : MonoBehaviour
{
    public Rigidbody mask;
    public Vector3 gap;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        gap.x = 0.2f;
        gap.y = 1;
        gap.z = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("GAME CHALLING>>");
    }

    public void shoot()
    {
        Rigidbody bullet = Instantiate(mask, transform.position + gap , Quaternion.identity) as Rigidbody;
        bullet.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        Destroy(bullet.gameObject, 2f);
    }


}
