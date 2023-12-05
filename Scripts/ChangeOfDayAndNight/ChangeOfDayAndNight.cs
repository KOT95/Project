using UnityEngine;

public class ChangeOfDayAndNight : MonoBehaviour
{
    [SerializeField] private Light directionList;
    [SerializeField] private float timeDay, timeNight;
    [SerializeField] private float lightIntensityDay, lightIntensityNight;

    private const string DAY = "Day";
    private const string NIGHT = "Night";
    
    private float _time;
    private string _condition;

    private void Awake()
    {
        EventManager.onDay?.Invoke();
        _time = 0;
        _condition = DAY;
    }

    private void Update()
    {
        if (_condition == DAY)
        {
            directionList.intensity = lightIntensityDay;
            _time += Time.deltaTime;

            if (_time >= timeDay)
            {
                EventManager.onNight?.Invoke();
                _time = 0;
                _condition = NIGHT;
            }
        }
        else if (_condition == NIGHT)
        {
            directionList.intensity = lightIntensityNight;
            _time += Time.deltaTime;

            if (_time >= timeNight)
            {
                EventManager.onDay?.Invoke();
                _time = 0;
                _condition = DAY;
            }
        }
    }
}
