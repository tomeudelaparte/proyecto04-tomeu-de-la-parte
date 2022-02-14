using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 10;
    private GameObject focalPoint;

    private bool hasPowerUp;
    private float powerUpForce = 100f;

    public GameObject[] powerUpIndicators;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Powerup") && !hasPowerUp)
        {
            hasPowerUp = true;

            StartCoroutine(PowerUpCountDown());

            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (hasPowerUp && other.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = other.gameObject.GetComponent<Rigidbody>();

            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position).normalized;

            enemyRigidbody.AddForce(awayFromPlayer * powerUpForce, ForceMode.Impulse);
        }
    }


    private IEnumerator PowerUpCountDown()
    {
        for (int i = 0; i < powerUpIndicators.Length; i++)
        {
            powerUpIndicators[i].SetActive(true);

            yield return new WaitForSeconds(2);

            powerUpIndicators[i].SetActive(false);
        }

        hasPowerUp = false;
    }
}
