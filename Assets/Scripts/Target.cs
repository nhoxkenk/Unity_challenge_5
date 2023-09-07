using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;

    private Rigidbody targetRigidbody;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;

    private float minSpeed = 12.0f;
    private float maxSpeed = 16.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = -2.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRigidbody.AddForce(randomForce(), ForceMode.Impulse);
        targetRigidbody.AddTorque(randomTorque(), randomTorque(), randomTorque(), ForceMode.Impulse); //Add force to rotate the Target

        transform.position = randomPosition();
    }

    //private void OnMouseDown()
    //{
        
        
    //}

    public void DestroyTarget()
    {
        if (gameManager.isGameActive && !gameManager.isPause)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.updateScore(pointValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.updateLives();
            if(gameManager.lives == 0)
            {
                gameManager.gameOver();
            }
        }
    }

    Vector3 randomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float randomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 randomPosition()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
