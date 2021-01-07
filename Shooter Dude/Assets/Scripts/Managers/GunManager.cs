using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{

    public Color NoColor;
    public Color CommonColor;
    public Color UnCommonColor;
    public Color RareColor;
    public Color EpicColor;
    public Color LegendaryColor;

    public Gun Pistol;
    public Gun AK47;
    public Gun Sniper;
    public Gun UZI;
    public Gun Remington;
    public Gun M16;

    public Gun[] AllGuns;

    public static GunManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Gun GetGunByBulletImage(Sprite sprite)
    {
        for(int i = 0; i < AllGuns.Length; i++)
        {
            if(AllGuns[i].ProjectileImage == sprite)
            {
                return AllGuns[i];
            }
        }
        Debug.Log("Null GetGunByBulletImage method at GunManager.cs");
        return null;
    }

    public enum RarityTypes { Common, UnCommon, Rare, Epic, Legendary };

    public Color GetColor(RarityTypes rarity)
    {
        if(rarity == RarityTypes.Common)
        {
            return CommonColor;
        } else if (rarity == RarityTypes.UnCommon)
        {
            return UnCommonColor;
        }
        else if (rarity == RarityTypes.Rare)
        {
            return RareColor;
        }
        else if (rarity == RarityTypes.Epic)
        {
            return EpicColor;
        }
        else if (rarity == RarityTypes.Legendary)
        {
            return LegendaryColor;
        }
        return NoColor;
    }

}
