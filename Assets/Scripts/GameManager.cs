using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float m_NumRounds = 3f;
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    //this was confusing-luke
    //but watch
    [SerializeField]
    private List<BikeManager> m_Bikes;

    private int m_RoundNumber;
    private BikeManager m_RoundWinner;
    private BikeManager m_GameWinner;
    private bool m_WasHit = false;

    //the gamemanger is responsible for enabling and disabling the bikes
    //if we only have one reference to a bike ex: m_bike we can only control one
    //let's use a list of bikemanager and control them that way

    // Use this for initialization
    void Start()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);
        StartCoroutine(GameLoop());
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStart());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnd());

        if (m_GameWinner != null)
        {
            if (Input.GetButton("Fire1"))
            {
                LoadScene();
            }
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }

    private IEnumerator RoundStart()
    {
        DisableBikeControl();

        m_RoundNumber++;

        yield return m_StartWait;
    }

    private IEnumerator RoundPlaying()
    {
        EnableBikeControl();

        while (m_WasHit == false)
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnd()
    {
        DisableBikeControl();
        m_RoundWinner = null;
        //m_RoundWinner = GetRoundWinner();

        if (m_RoundWinner != null)
        {
            m_RoundWinner.m_RoundWin++;
        }

        yield return m_EndWait;
    }

    //private BikeManager GetRoundWinner()
    //{
    //}

    //private BikeManager GetGameWinner()
    //{
    //}

    private void EnableBikeControl()
    {
        foreach (var bike in m_Bikes)
        {
            bike.EnableControls();
        }
    }

    private void DisableBikeControl()
    {
        m_Bikes.ForEach(bike => bike.DisableControls());
    }

    public void LoadScene()
    {
        Debug.Log("scene load" + name);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
