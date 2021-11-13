using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public TMP_Text textNextLevel;

    public TMP_Text textNotEnoughPoints;

    public Score score;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if(score != null && score.CoinsAmount == ConstantValue._coinsToLevel2)
        {
            textNextLevel.gameObject.SetActive(true);
            Invoke(nameof(LoadNextScene),3f);
        }
        else if(score != null && score.CoinsAmount < ConstantValue._coinsToLevel2)
        {
            textNotEnoughPoints.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textNotEnoughPoints.gameObject.SetActive(false);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(ConstantValue._level2);
    }
}
