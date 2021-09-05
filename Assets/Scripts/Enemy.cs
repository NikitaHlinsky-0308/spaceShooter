using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    [SerializeField]
    private float _speed = 3.0f;   
    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        if (transform.position.y < -5f)
        {
            float randomX = Random.Range(-13.65f, -5.43f);
            transform.position = new Vector3( randomX, 7, 15);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if (other.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();

            if (player != null) 
            {
                player.Damadge();
            }

            Destroy(this.gameObject);
        }

        if(other.tag == "Laser")
        {
            Destroy(other.gameObject);
            // add 10 to score
            if (_player != null)
            {
                _player.AddScore();
            }

            Destroy(this.gameObject);   
        }
    }
}
