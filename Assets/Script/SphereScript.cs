using System.Collections;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public bool isFall = true;
    public bool isAddForce = false;
    private Rigidbody sphereRb;
    [SerializeField] float sphereFallTime = 3f;
    [SerializeField] float sphereAddForceTime = 1.5f;
    void Start()
    {
        sphereRb = GetComponent<Rigidbody>();
        if (isFall == true)
        {
            StartCoroutine(sphereFall());
        }

    }
    void Update()
    {
        if (isAddForce == true)
        {
            StartCoroutine(sphereAF());
        }
    }
    IEnumerator sphereFall()
    {
        sphereRb.useGravity = false;
        yield return new WaitForSeconds(sphereFallTime);
        sphereRb.useGravity = true;
    }
    IEnumerator sphereAF()
    {
        yield return new WaitForSeconds(sphereAddForceTime);
        sphereRb.AddForce(0, 0, -2000 * Time.deltaTime, ForceMode.Force);
    }
}
