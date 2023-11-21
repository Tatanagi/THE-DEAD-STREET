using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class shoot : MonoBehaviour
{
    public TextMeshProUGUI Ammo_Counter;
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public int maxAmmo = 10; 
    private int currentAmmo;
    public AudioSource ShootSound;
    public AudioClip pickupAmmoSound; 

    // Start is called before the first frame update
    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentAmmo > 0 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Shoot();
            ShootSound.Play();
        }

        Ammo_Counter.text = currentAmmo.ToString();
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        if (transform.localScale.x < 0)
        {
            bullet.GetComponent<bullet2>().speed *= -1;
        }
        currentAmmo--;
    }

    // Collision Effect
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Grab Ammo
        if (collision.CompareTag("Ammo"))
        {
            currentAmmo += 25;
            PlayPickupAmmoSound();
            Destroy(collision.gameObject);
        }
    }

    private void PlayPickupAmmoSound()
    {
        if (pickupAmmoSound != null)
        {
            
            AudioSource.PlayClipAtPoint(pickupAmmoSound, transform.position);
        }
    }
}