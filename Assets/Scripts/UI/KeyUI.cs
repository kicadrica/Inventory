using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    private Text _keyCount;
    private void Start()
    {
        _keyCount = GetComponent<Text>();
        ChangeKeyUI(0);
        KeyHolder.OnKeyChange += ChangeKeyUI;
    }

    private void OnDestroy()
    {
        KeyHolder.OnKeyChange -= ChangeKeyUI;
    }

    private void ChangeKeyUI(int key)
    {
        _keyCount.text = key.ToString();
    }
}
