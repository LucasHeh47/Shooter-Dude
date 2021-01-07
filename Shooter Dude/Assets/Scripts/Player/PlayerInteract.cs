using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public static PlayerInteract Instance;
    public ShopManager shop;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (shop.InRange && Input.GetKeyDown(KeyCode.E))
        {
            shop.gameObject.SetActive(!shop.gameObject.activeSelf);
        }
    }
}
