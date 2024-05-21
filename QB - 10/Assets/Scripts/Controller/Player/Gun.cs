using System.Collections;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float gunDamage = 15f;
    public float range = 90f;
    public float fireRate = 20f;
    public float impactForce = 30f;

    public int maxAmmo = 15;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    public Transform gun;
    public ParticleSystem muzzleShot;
    public GameObject impactShot;

    public float nextTimeToFire = 5f;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;    
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleShot.Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(gun.transform.position, gun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            Enemy enemy = hit.transform.GetComponent<Enemy>();

            if (target != null)
            {
                target.RecieveDamage(gunDamage);
            }

            if(enemy != null)
            {
                enemy.TakeDamage(gunDamage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactShot, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo,1f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reload", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("Reload", false);
        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
