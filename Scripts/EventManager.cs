using System;

public abstract class EventManager
{
    public static Action onDay;
    public static Action onNight;
    public static Action<int> onVisible;
}
