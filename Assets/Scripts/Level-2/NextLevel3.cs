using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel3 : MonoBehaviour
{
    public TMP_Text textNextLevel;

    public TMP_Text textNotEnoughHp;

    private Health _health;

    private void OnTriggerStay2D(Collider2D collision)
    {
        _health = collision.GetComponent<Health>();
        if (_health != null && _health.HealthComponent == ConstantValue._coinsHpToLevel3)
        {
            textNextLevel.gameObject.SetActive(true);
            Invoke(nameof(LoadNextScene), 3f);
        }
        else if (_health != null && _health.HealthComponent < ConstantValue._coinsHpToLevel3)
        {
            textNotEnoughHp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        textNotEnoughHp.gameObject.SetActive(false);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(ConstantValue._level3);
    }
}
