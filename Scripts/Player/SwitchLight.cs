using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField] private GameObject[] lightRaycastsArray;
    [SerializeField] private Transform panelButtons;
    
    public void Switch(int num)
    {
        panelButtons.gameObject.SetActive(true);
        panelButtons.GetChild(num).gameObject.SetActive(true);

        for (int i = 0; i < lightRaycastsArray.Length; i++)
        {
            if(i == num)
                lightRaycastsArray[i].SetActive(true);
            else
                lightRaycastsArray[i].SetActive(false);
        }
    }
}
