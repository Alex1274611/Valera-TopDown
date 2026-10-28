using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ShootController : MonoBehaviour
{
    public Transform bulletPlace;
    public GameObject bullet;
    public float fireRate = 0.1f;

    IEnumerator ShootTimer()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            StartCoroutine("ShootTimer");
        }
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            StopCoroutine("ShootTimer");
        }

    }
    private void Shoot()
    {
        Instantiate(bullet, bulletPlace.position, transform.rotation);
    }
}

