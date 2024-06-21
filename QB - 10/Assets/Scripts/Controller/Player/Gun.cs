using System.Collections;
using UnityEngine;

//Thanks to Brackeys for the code
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

    public bool Weapon = false;

    /*[Header("Armed-Positioning")]
    public Transform armedHolder;
    public Vector3 armedPosition;
    public Vector3 armedRotation;

    [Header("Unarmed-Positioning")]
    public Transform unArmedHolder;
    public Vector3 unArmedPosition;
    public Vector3 unArmedRotation;*/

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
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

            if (enemy != null)
            {
                enemy.TakeDamage(gunDamage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGo = Instantiate(impactShot, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 1f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("isReload", true);

        yield return new WaitForSeconds(reloadTime - 0.25f);
        animator.SetBool("isReload", false);
        yield return new WaitForSeconds(0.25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    /*void EquipWeapon()
    {
        if (Weapon != null)
        {
            GetCurrentWeaponProperties();

            Weapon.transform.SetParent(armedHolder);
            Weapon.transform.localPosition = armedPosition;
            Qauternion equipRot = Qauternion.Euler(armedRotation);
            Weapon.transform.localRotation = equipRot;
            Weapon.GetComponent<Rigidbody>().isKinematic = true;
            Weapon.GetComponent<Collider>().enable = false;
            anim.SetInteger("Weapon", weapontype);
            IKisOn = true;
        }
    }

    void HosterWeapon()
    {
        if (Weapon != null)
        {
            Weapon.transform.SetParent(unArmedHolder);
            Weapon.transform.localPosition = unArmedPosition;
            Quaternion equipRot = Quaternion.Euler(unArmedRotation);
            Weapon.transform.localRotation = equipRot;
            IKisON = false;
            Weapon = null;
        }
        if (Weapon == null)
        {
            Debug.Log("No weapon");
            return;
        }
    }

    void GetCurrentWeaponProperties()
    {
        if (Weapon == null)
        {
            return;
        }

        if (Weapon != null)
        {
            weaponManager WM = Weapon.GetComponent<weaponManager>();
            armedHolder = WM.armedHolder;
            armedPosition = WM.armedPosition;
            armedRotation = WM.armedRotation;

            unarmedHolder = WM.unarmedHolder;
            unarmedPosition = WM.unarmedPosition;
            unarmedRotation = WM.unarmedRotation;
            weaponDamage = WM.gunDamage;
        }
    }*/
}
