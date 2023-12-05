using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button button;

    public void ActivatorButton(bool isActivate, LightRaycasts lightRaycasts)
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(lightRaycasts.DeadEnemy);
        button.gameObject.SetActive(isActivate);
    }
}
