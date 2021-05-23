using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Button continueButton;

    public void OnClick()
    {
        SceneManager.LoadScene("Title");
    }
}
