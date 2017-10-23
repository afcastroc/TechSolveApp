using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float velocity = 0f;
    public Vector3 coords;
    private bool active = false;

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Rotate(coords, velocity * Time.deltaTime);
        }
    }
}
