using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Lives : MonoBehaviour
{
    int lives = 8;

    public void LoseLife()
    {
        lives--;
    }

    private void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Lives: " + lives;

        if (lives <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
