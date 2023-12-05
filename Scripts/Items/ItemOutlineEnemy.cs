using System;
using UnityEngine;

public class ItemOutlineEnemy : MonoBehaviour
{
    private Collider _collider;

    private void OnEnable()
    {
        _collider = GetComponent<Collider>();
        EventManager.onDay += Day;
        EventManager.onNight += Night;
    }
    
    private void OnDisable()
    {
        EventManager.onDay -= Day;
        EventManager.onNight -= Night;
    }

    private void Day()
    {
        _collider.enabled = true;
        transform.GetChild(0).gameObject.SetActive(true);
    }

    private void Night()
    {
        _collider.enabled = false;
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            EventManager.onVisible(player.NumPlayer);
            _collider.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
