using UnityEngine;

public class ItemLight : MonoBehaviour
{
    [SerializeField] private int numLight;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out SwitchLight switchLight))
        {
            switchLight.Switch(numLight);
            Destroy(gameObject);
        }
    }
}
