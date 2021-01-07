using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerGun : MonoBehaviour
{

    public static PlayerGun Instance;
    public GunManager manager;

    public Gun DefaultGun;

    public Gun[] Equipped;
    public int CurrentWeapon = 0;
    public Gun WeaponHolding;

    // FRONT END
    public SpriteRenderer GunImage;
    public Sprite NoGunInv;
    public Image GunInv1;
    public Image GunInv2;

    public TextMeshProUGUI AmmoText;

    public GameObject Inv1Background;
    public GameObject Inv2Background;
    public TextMeshProUGUI Inv1Text;
    public TextMeshProUGUI Inv2Text;

    public GameObject bullet;
    public Transform bulletSpawn;

    public float ReloadSpeed = 1.00f;

    // SHOOTING
    private float nextTime;
    private float delay;

    public float ReloadTime;

    public bool isReloading;
    public TextMeshProUGUI reloadingText;


    void Start()
    {
        Equipped = new Gun[2];
        Equipped[0] = DefaultGun;
        WeaponHolding = Equipped[CurrentWeapon];
        Instance = this;
        SetGunsToCommon();
        ChangeInv();
        delay = GetFireRate(WeaponHolding);
        ReloadTime = WeaponHolding.ReloadTime;

        ReloadAllGunsCompletely();
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
    }

    public void AddNewGun(Gun newGun)
    {
        if(Equipped[0] == null)
        {
            Equipped[0] = newGun;
        } else if(Equipped[1] == null)
        {
            Equipped[1] = newGun;
        }
        else
        {
            Equipped[CurrentWeapon] = newGun;
        }
        WeaponHolding = Equipped[CurrentWeapon];
        GunImage.sprite = WeaponHolding.GunImage;
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
        delay = GetFireRate(WeaponHolding);
        ReloadTime = WeaponHolding.ReloadTime;
        ChangeInv();
    }

    void ChangeInv()
    {
        if(Equipped[0] != null) GunInv1.sprite = Equipped[0].GunImageInvView;
        if (Equipped[1] != null) GunInv2.sprite = Equipped[1].GunImageInvView;
        if (Equipped[0] != null) Inv1Text.SetText(Equipped[0].GunName);
        if (Equipped[1] != null) Inv2Text.SetText(Equipped[1].GunName);
        SetRarityColors();
    }

    void SetRarityColors()
    {
        if (Equipped[0] != null)
        {
            Inv1Background.GetComponent<Image>().color = manager.GetColor(Equipped[0].Rarity);
        }
        else
        {
            Inv1Background.GetComponent<Image>().color = manager.NoColor;
        }
        if (Equipped[1] != null)
        {
            Inv2Background.GetComponent<Image>().color = manager.GetColor(Equipped[1].Rarity);
        }
        else
        {
            Inv2Background.GetComponent<Image>().color = manager.NoColor;
        }
    }

    void SetGunsToCommon()
    {
        for(int i = 0; i < manager.AllGuns.Length; i++)
        {
            manager.AllGuns[i].Rarity = GunManager.RarityTypes.Common;
        }
    }

    void ReloadGun(Gun gun)
    {
        gun.CurrentAmmo = gun.Ammo;
        gun.AmmoInClip = gun.ClipSize;
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
    }

    void ReloadGunsCompletely()
    {
        if (Equipped[0] != null) Equipped[0].CurrentAmmo = Equipped[0].Ammo;
        if (Equipped[1] != null) Equipped[1].CurrentAmmo = Equipped[1].Ammo;
        if (Equipped[0] != null) Equipped[0].AmmoInClip = Equipped[0].ClipSize;
        if (Equipped[1] != null) Equipped[1].AmmoInClip = Equipped[1].ClipSize;
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
    }

    void ReloadAllGunsCompletely()
    {
        for (int i = 0; i < manager.AllGuns.Length; i++)
        {
            manager.AllGuns[i].CurrentAmmo = manager.AllGuns[i].Ammo;
            manager.AllGuns[i].AmmoInClip = manager.AllGuns[i].ClipSize;
        }
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
    }

    void Update()
    {
        if (isReloading)
            return;

        if (WeaponHolding.CurrentAmmo > 0)
        {
            if (WeaponHolding.AmmoInClip <= 0 || (Input.GetKeyDown(KeyCode.R) && WeaponHolding.AmmoInClip < WeaponHolding.ClipSize))
            {
                StartCoroutine(Reload());
                return;
            }
        }

        int updateWeaponCheck = CurrentWeapon;
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (CurrentWeapon == Equipped.Length - 1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (CurrentWeapon == 0)
            {
                CurrentWeapon = Equipped.Length - 1;
            }
            else
            {
                CurrentWeapon--;
            }
        }
        if(updateWeaponCheck != CurrentWeapon)
        {
            if (Equipped[CurrentWeapon] != null)
            {
                EquipNewGun();
            }
            else
            {
                CurrentWeapon = updateWeaponCheck;
            }
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTime && !isReloading && WeaponHolding.AmmoInClip > 0 && !PlayerInteract.Instance.shop.gameObject.activeSelf)
        {
            Shoot();
        }

    }

    void Shoot()
    {
        nextTime = Time.time + 1f * delay/2;
        WeaponHolding.AmmoInClip--;
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());


        GameObject SpawnedBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        SpawnedBullet.GetComponent<SpriteRenderer>().sprite = WeaponHolding.ProjectileImage;
        Rigidbody2D rb = SpawnedBullet.GetComponent<Rigidbody2D>();
        rb.AddForce(SpawnedBullet.transform.right * WeaponHolding.BulletSpeed, ForceMode2D.Impulse);
        Destroy(SpawnedBullet, GetRange(WeaponHolding));
    }

    IEnumerator Reload()
    {
        isReloading = true;
        reloadingText.SetText("Reloading...");

        yield return new WaitForSeconds(ReloadTime/ReloadSpeed);
        int ammoReloaded = WeaponHolding.ClipSize - WeaponHolding.AmmoInClip;

        reloadingText.SetText(" ");

        if (WeaponHolding.AmmoInClip >= WeaponHolding.ClipSize)
        {
            WeaponHolding.CurrentAmmo = WeaponHolding.ClipSize;
            WeaponHolding.AmmoInClip -= ammoReloaded;
        }
        else
        {
            int totalAmmo = WeaponHolding.AmmoInClip + WeaponHolding.CurrentAmmo;
            if (totalAmmo <= WeaponHolding.ClipSize)
            {
                WeaponHolding.AmmoInClip = totalAmmo;
                WeaponHolding.CurrentAmmo = 0;
            }
            else
            {
                WeaponHolding.AmmoInClip = WeaponHolding.ClipSize;
                WeaponHolding.CurrentAmmo = totalAmmo - WeaponHolding.ClipSize;
            }
        }

        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
        isReloading = false;
    }

    void EquipNewGun()
    {
        WeaponHolding = Equipped[CurrentWeapon];
        GunImage.sprite = WeaponHolding.GunImage;
        AmmoText.SetText(WeaponHolding.AmmoInClip.ToString() + "/" + WeaponHolding.CurrentAmmo.ToString());
        delay = GetFireRate(WeaponHolding);
        ReloadTime = WeaponHolding.ReloadTime;
    }

    public bool DoesHaveGun(Gun gun)
    {
        if(Equipped[0] == gun)
        {
            return true;
        } else if(Equipped[1] == gun)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetDamage(Gun gun)
    {
        if(gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonDamage;
        } else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicDamage;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryDamage;
        }
        return 0;
    }

    public float GetFireRate(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicFireRate;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryFireRate;
        }
        return 0;
    }

    public float GetRange(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicRange;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return gun.LegendaryRange;
        }
        return 0;
    }

    public void UpgradeGunRarity(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            gun.Rarity = GunManager.RarityTypes.UnCommon;
            ChangeInv();
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            gun.Rarity = GunManager.RarityTypes.Rare;
            ChangeInv();
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            gun.Rarity = GunManager.RarityTypes.Epic;
            ChangeInv();
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            gun.Rarity = GunManager.RarityTypes.Legendary;
            ChangeInv();
        }
        else if (gun.Rarity == GunManager.RarityTypes.Legendary)
        {
            return;
        }
        ReloadGun(gun);
    }

    public float GetUpgradeCost(Gun gun)
    {
        if (gun.Rarity == GunManager.RarityTypes.Common)
        {
            return gun.CommonToUnCommonCost;
        }
        else if (gun.Rarity == GunManager.RarityTypes.UnCommon)
        {
            return gun.UnCommonToRareCost;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Rare)
        {
            return gun.RareToEpicCost;
        }
        else if (gun.Rarity == GunManager.RarityTypes.Epic)
        {
            return gun.EpicToLegendaryCost;
        }
        return 58353;
    }

}
