using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;
    [SerializeField]
    public GameObject laserPrefab;
    [SerializeField]
    private GameObject TripleShotPrefab;
    [SerializeField]
    private GameObject ShieldVisualizer;
    [SerializeField]
    private float _fireRate = 0.001f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;
    [SerializeField]
    private bool TripleShotActive = false;
    [SerializeField]
    private bool ShieldIsActive = false;
    void Start()
    {

        transform.position = new Vector3(-9.4f, 0.4f, 15);
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

        if (_spawnManager == null)
        {
            Debug.LogError("The _spawnMagager is NULL");
        }

    }

    void Update()
    {
        calculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }

    void calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime;

        if (transform.position.y >= 5.1)
        {
            transform.position = new Vector3(transform.position.x, 5.1f, 15);
        } 
        else if (transform.position.y <= 0.37) 
        {
            transform.position = new Vector3(transform.position.x, 0.37f, 15);
        }

        else if (transform.position.x <= -15.57)
        {
            transform.position = new Vector3(-3.45f, transform.position.y, 15);
        }
        else if (transform.position.x >= -3.45)
        {
            transform.position = new Vector3(-15.57f, transform.position.y, 15);
        }

    }

    void FireLaser() {

         _canFire = Time.time + _fireRate;
        
        if (TripleShotActive == true)
        {
            Instantiate(TripleShotPrefab, transform.position, Quaternion.identity);
        } else
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
        
    }

    public void Damadge()
    {
        if (ShieldIsActive == false)
        {
            _lives--;
        } 

        // check if dead
        if (_lives  < 1)
        {
            _spawnManager.OnPlayerDeath(); 

            Destroy(this.gameObject);
        }
    }

    public void TripleShotActivate()
    {
        TripleShotActive = true;
        StartCoroutine(TripleShotPowerDownRuntime());
    }

    IEnumerator TripleShotPowerDownRuntime()
    {
        yield return new WaitForSeconds(10);
        TripleShotActive = false;
    }

    public void SpeedPowerupActivate()
    {
        speed = 20;
        StartCoroutine(SpeedPowerupRuntime());
    }

    IEnumerator SpeedPowerupRuntime()
    {
        yield return new WaitForSeconds(10);
        speed = 10;
    }

    public void ShieldPowerupActive()
    {
        ShieldIsActive = true;
        ShieldVisualizer.SetActive(true);
        StartCoroutine(ShieldPowerupRuntime());
    }

    IEnumerator ShieldPowerupRuntime()
    {
        yield return new WaitForSeconds(7);
        ShieldIsActive = false;
        ShieldVisualizer.SetActive(false);
    }
}
