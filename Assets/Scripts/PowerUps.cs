using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerupID;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // move down at a speed of 3
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        // when leave screen - destroy
        if (transform.position.y < -5f)
        {
            Destroy(this.gameObject);
        }
    }

    // onTriggerCollision 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if (player != null)
            {
                if (_powerupID == 0)
                {
                    player.TripleShotActivate();
                } else if (_powerupID == 1)
                {
                    player.SpeedPowerupActivate();
                    Debug.Log("Speed powerup collected");
                } else if (_powerupID == 2)
                {
                    player.ShieldPowerupActive();
                    Debug.Log("Shield powerup collected");
                }
            }
            Destroy(this.gameObject);

        }
    }
}
