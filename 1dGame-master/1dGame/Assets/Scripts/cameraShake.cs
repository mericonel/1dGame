using UnityEngine;
using System.Collections;

public class cameraShake : MonoBehaviour {

    Vector3 initialL;
    Quaternion initialR;

    public float shakeDuration = 0.1f;
    public float magnitude = 0.1f;

    // Use this for initialization
    void Start()
   {
        initialL = transform.position;
        initialR = transform.rotation;
   }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
            {
            StartCoroutine("shakeCam");
            }

        if (Input.GetKeyDown(KeyCode.L))
            {
            StartCoroutine("shakeCam");
            }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CollisionH")
        {
            StartCoroutine("shakeCam");
        }

        else if (other.gameObject.tag == "CollisionW")
        {
            StartCoroutine("shakeCam");
        }

    }





            IEnumerator shakeCam()
    {
        float timeLeft = shakeDuration;
        while (timeLeft > 0)
        {
            transform.position = initialL + Random.insideUnitSphere * magnitude;
            timeLeft -= Time.deltaTime;
            yield return null;
        }

        transform.position = initialL;
        transform.rotation = initialR;
    }
}


