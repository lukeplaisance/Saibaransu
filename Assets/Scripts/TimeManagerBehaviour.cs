using UnityEngine;
using UnityEngine.Assertions.Comparers;

public class TimeManagerBehaviour : MonoBehaviour
{
    public float slowDownDuration = 2f;
    public AnimationCurve ac;
    public float currentTime = 0;

    public bool IsSlowDown;
    private void Update()
    {
        if (currentTime >= slowDownDuration)
        {
            ResetSlowDown();
            return;
        }

        if (IsSlowDown)
        {
            Time.timeScale = ac.Evaluate(currentTime / slowDownDuration);
            currentTime += Time.unscaledDeltaTime;
        }
    }

    public void SlowDown()
    {
        currentTime = 0;
        IsSlowDown = true;
    }

    public void ResetSlowDown()
    {
        currentTime = 0;
        Time.timeScale = 1;
        IsSlowDown = false;
    }
}