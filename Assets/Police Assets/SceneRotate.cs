using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRotate : MonoBehaviour
{
    float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
    }
}
