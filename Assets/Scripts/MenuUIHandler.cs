using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public void StartGame()
    {
        TMP_InputField nickname = gameObject.GetComponentInChildren<TMP_InputField>();
        GameManager.Instance.nickname = nickname.text;

        SceneManager.LoadScene(1);
    }
}
