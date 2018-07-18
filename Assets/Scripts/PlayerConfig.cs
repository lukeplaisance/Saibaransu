using UnityEngine;

[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [Header("Input Values")]
    [SerializeField]
    public string _horizontalinput = "P1Horizontal";
    [SerializeField]
    public string _verticalinput = "P1Vertical";
    [SerializeField]
    public string _fireinput1 = "P1Fire2";
    [SerializeField]
    public string _fireinput2 = "P1Fire1";

    [Header("Events")]
    [SerializeField]
    public GameEvent InputFire1;
    [SerializeField]
    public GameEvent InputFire2;
    [SerializeField]
    public GameEvent OnFirstPersonSwitch;

}