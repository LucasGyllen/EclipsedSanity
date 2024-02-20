using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("References")]
    [SerializeField] gunData gunData;
    [SerializeField] private Transform muzzleEffect;

    public ImpactInfo[] ImpactElemets = new ImpactInfo[0];
    [Space]
    public GameObject ImpactEffect;

    public AudioClip gunFire;
    public AudioClip gunReload;
    public AudioClip gunEmpty;
    private AudioSource audioSource;
    private Animator animator;

    bool isCrouching = false;
    float timeSinceLastShot;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        audioSource = player.GetComponent<AudioSource>();

        animator = GetComponent<Animator>();

        gunData.reloading = false; //Makes sure the gunData reloading bool doesn't start as true
    }

    public void StartReload()
    {
        if (!gunData.reloading || !PauseManager.IS_PAUSED)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {

        //Plays sound if clip not full. Change in future so that this plays together with animation. If the "if" is removed this plays even when the gun is full.
        if ((!gunData.reloading && gunData.currentAmmo < gunData.magSize))
            PlaySound(gunReload);

        gunData.reloading = true;
        animator.SetBool("IsReloading", true);

        yield return new WaitForSeconds(gunData.reloadTime);
        gunData.currentAmmo = gunData.magSize;
        animator.SetBool("IsReloading", false);
        gunData.reloading = false;
    }

    private bool CanShoot() => !PauseManager.IS_PAUSED && !gunData.reloading && timeSinceLastShot > 1f / (gunData.fireRate / 60f);

    public void Shoot()
    {
        if (CanShoot())
        {
            if (gunData.currentAmmo > 0)
            {
                PlaySound(gunFire);
                animator.Play("Shoot");

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, gunData.maxDistance))
                {
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.Damage(gunData.damage);

                    /*The ImpactEffect was somehow running the shoot function multiple times when shooting an enemy, 
                        resulting in the player dealing massive damage to enemies almost one shooting them,
                        this removes the ImpactEffect for objects with Enemy tags.*/
                    if (!hitInfo.collider.CompareTag("Enemy"))
                    {
                        var effect = GetImpactEffect(hitInfo.transform.gameObject);
                        if (effect == null)
                            return;
                        var effectIstance = Instantiate(effect, hitInfo.point, new Quaternion()) as GameObject;
                        effectIstance.transform.LookAt(hitInfo.point + hitInfo.normal);
                        Destroy(effectIstance, 20);
                    }
                    var impactEffectIstance = Instantiate(ImpactEffect, muzzleEffect.position, muzzleEffect.rotation) as GameObject;

                    Destroy(impactEffectIstance, 4); 
                }

                gunData.currentAmmo--;
                timeSinceLastShot = 0;
                OnGunShoot();

                Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * gunData.maxDistance, Color.red, 1.0f);
            }
            else
            {
                PlaySound(gunEmpty);
                timeSinceLastShot = 0;
                animator.Play("Shoot");
                Debug.Log("Out of ammo!");
            }
        }
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * gunData.maxDistance, Color.green, 0.1f);
    }

    [System.Serializable]
    public class ImpactInfo
    {
        public MaterialType.MaterialTypeEnum MaterialType;
        public GameObject ImpactEffect;
    }

    GameObject GetImpactEffect(GameObject impactedGameObject)
    {
        var materialType = impactedGameObject.GetComponent<MaterialType>();

        if (materialType == null)
            return null;

        foreach (var impactInfo in ImpactElemets)
        {
            if (impactInfo.MaterialType == materialType.TypeOfMaterial)
                return impactInfo.ImpactEffect;
        }
        return null;
    }

    private void PlaySound(AudioClip soundClip)
    {
        audioSource.Stop();

        audioSource.clip = soundClip;
        audioSource.Play(); 
    }

    private void OnGunShoot()
    {

    }
}
