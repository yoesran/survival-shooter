using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public Text warningText;

    public GameObject screenFader;

    public GameObject warning;

    Animator anim;           

    void Awake()
    {
        warning.SetActive(false);
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("GameOver");
            
            screenFader.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
        anim.SetTrigger("Warning");
        warning.SetActive(true);
    }
}