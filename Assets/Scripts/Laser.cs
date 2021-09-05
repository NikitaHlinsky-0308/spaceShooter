using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed = 8f;
    

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        if (transform.position.y > 8f)
        {
            // Check if that object has parent
            // destroy the parent too

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);            
            }

            Destroy(this.gameObject, 5f);
        }
    }
}
