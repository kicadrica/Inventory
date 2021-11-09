using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkZoneChecker : MonoBehaviour
{
    public Transform Player;
    private SpriteRenderer sr;

    private void Start() {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        var dir = transform.position - Player.position;
        Debug.DrawLine(transform.position - dir.normalized, Player.position + dir.normalized);
        foreach(var contact in Physics2D.LinecastAll(transform.position - dir.normalized, Player.position + dir.normalized))
        {
            if (contact.collider.GetComponent<ICollectable>() != null) continue;
            sr.enabled = true;
            return;
        }
        sr.enabled = false;
    }
}
