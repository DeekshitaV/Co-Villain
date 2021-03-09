using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    private CharacterController _controller;
    public Vector3 moveVector;
    [SerializeField]
    private float _speed= 1.0f;
    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = Vector3.zero;
        if (Input.touchCount > 0)
        {

            var touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width / 2)
            {
                 moveVector.x += 2.5f;
            }
            else
            {
                 moveVector.x += -  2.5f;
            }


        }
        else
        {
            moveVector.x += 0;
        }
        moveVector.z = _speed;
 
        _controller.Move(moveVector * Time.deltaTime);
       
    }

    

}
