using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayScript : MonoBehaviour
{
    public void startgame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
