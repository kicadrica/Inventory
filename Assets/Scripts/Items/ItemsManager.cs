using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsManager : MonoBehaviour
{
    public static ItemsManager _instance;
    public MushroomSO[] MushroomList;
    public static ItemsManager Instance {
        get {
            if (_instance == null) {
                _instance = FindObjectOfType<ItemsManager>();
                _instance.Init();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (Instance == this) {
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    private void Init()
    {
        MushroomList = Resources.LoadAll<MushroomSO>("Mushrooms");
    }

}
