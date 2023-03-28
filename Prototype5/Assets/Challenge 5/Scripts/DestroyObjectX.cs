using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Destroy(gameObject);
        }
    }


}
