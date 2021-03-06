using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;
    public int pointValue;

    public AudioClip crashSound;
    private AudioSource audioSource;
    public ParticleSystem explosionParticle;

    private GameManager gameManager;

    public MeshRenderer meshRenderer;
	



    private Rigidbody targetRb;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
		targetRb.AddForce(RandomForce(), ForceMode.Impulse);
		targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpwanPos();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        audioSource = GetComponent<AudioSource>();
        meshRenderer = GetComponent<MeshRenderer>();
     
    }

   
    Vector3 RandomForce()
	{
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
	}

    float RandomTorque()
	{
        return Random.Range(-maxTorque, maxTorque);
	}
    
    Vector3 RandomSpwanPos()
	{
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
	}
	private void OnMouseDown()
	{
		if (gameManager.isGameActive)
		{
            
            audioSource.PlayOneShot(crashSound, 1.0f);
            meshRenderer.enabled = false;
            Destroy(gameObject,1.0f);

            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
        
    }
	private void OnTriggerEnter(Collider other)
	{

        Destroy(gameObject);
		if (gameObject.tag!="Bad")
		{
            gameManager.GameOver();
            
		}
        
    }

    
}
