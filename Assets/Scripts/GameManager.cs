using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text boxCountText; 
    public RectTransform endGameContainer;
    public Transform boxesParent;
    public int boxCount = 3;
    public float highestBoxY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateHighestBox();
        UpdateLabel();
    }

    void CalculateHighestBox()
    {
        float maxY = 0f;
        foreach (Transform box in boxesParent)
        {
            if (box.position.y > maxY)
            {
                maxY = box.position.y;
            }
        }
        highestBoxY = maxY + 1.0f; // Assuming box height is 1 unit
    }

    public void EndGame()
    {
        endGameContainer.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void UpdateLabel() {
      boxCountText.text = "Height: " + highestBoxY.ToString("0.0") + "m  Boxes: " + boxCount;
    }

    public void AddBox() {
      boxCount++;
    }
}
