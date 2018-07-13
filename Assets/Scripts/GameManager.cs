using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float m_NumRounds = 3f;
    public float m_StartDelay = 3f;
    public float m_EndDelay = 3f;
    public GameObject m_CameraOnePrefab;
    public GameObject m_CameraTwoPrefab;
    public CameraControllerBehaviour m_CameraOne;
    public CameraControllerBehaviour m_CameraTwo;
    public GameObject m_BikeOnePrefab;
    public GameObject m_BikeTwoPrefab;
    private GameObject m_SpawnedBikeOne;
    private GameObject m_SpawnedBikeTwo;
    public BikeManager m_BikeOne;
    public BikeManager m_BikeTwo;
    public Text m_Text;
    public bool m_WasHit = false;

    private int m_RoundNumber;
    private WaitForSeconds m_StartWait;
    private WaitForSeconds m_EndWait;
    private BikeManager m_RoundWinner;
    private BikeManager m_GameWinner;

	// Use this for initialization
	void Start ()
    {
        m_StartWait = new WaitForSeconds(m_StartDelay);
        m_EndWait = new WaitForSeconds(m_EndDelay);

        SpawnAllBikes();
	}

    private void SpawnAllCameras()
    {
        //m_CameraOne = Instantiate(m_CameraOnePrefab, m_CameraOne.transform.parent, Quaternion.identity) as GameObject;
    }

    private void SpawnAllBikes()
    {
        m_SpawnedBikeOne = Instantiate(m_BikeOnePrefab, m_BikeOne.m_SpawnPoint.position, Quaternion.identity) as GameObject;
        m_SpawnedBikeTwo = Instantiate(m_BikeTwoPrefab, m_BikeTwo.m_SpawnPoint.position, Quaternion.Euler(0, 180, 0)) as GameObject;
            
        m_BikeOne.Setup();
        m_BikeTwo.Setup();
            
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStart());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnd());

        if(m_GameWinner != null)
        {
            SceneManager.LoadScene("Luke");
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }

    private IEnumerator RoundStart()
    {
        ResetAllBikes();
        DisableBikeControl();

        //m_cameraController.SetStartPosition();
        m_RoundNumber++;

        yield return m_StartWait;
    }

    private IEnumerator RoundPlaying()
    {
        EnableBikeControl();
        m_Text.text = string.Empty;

        while(m_WasHit == false)
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnd()
    {
        DisableBikeControl();
        m_RoundWinner = null;
        m_RoundWinner = GetRoundWinner();

        if(m_RoundWinner != null)
        {
            m_RoundWinner.m_RoundWin++;
        }

        yield return m_EndWait;
    }

    private BikeManager GetRoundWinner()
    {
            if (Input.GetButton("Fire1"))
            {
                ResetAllBikes();
            }
        return null;
    }

    //private BikeManager GetGameWinner()
    //{
    //}

    private void ResetAllBikes()
    {
        m_BikeOne.Reset();
        m_BikeTwo.Reset();
    }

    private void EnableBikeControl()
    {
        m_BikeOne.EnableControls();
        m_BikeTwo.EnableControls();
    }

    private void DisableBikeControl()
    {
        m_BikeOne.DisableControls();
        m_BikeTwo.DisableControls();
    }
}
