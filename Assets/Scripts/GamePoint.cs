using UnityEngine;


public class GamePoint : MonoBehaviour
{
    public int point;
    private GameObject triggerOb;

    public void GainPoint()
    {
        if(Input.GetButton("Fire3"))
        {
            point++;
        }
    }
}
