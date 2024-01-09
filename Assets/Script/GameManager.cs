using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections;
public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public GameObject levelUpAssets;
    public GameObject gameoverAssets;
    private CoinManager coins;
    public bool isWin = false;
    void Start()
    {
        coins = GameObject.Find("Player").GetComponent<CoinManager>();

    }
    void Update()
    {
        CoinText();
        if (coins.coin == 5)
        {
            levelUp();
        }
    }
    void CoinText()
    {
        coinText.text = "Coin =" + coins.coin;
    }
    public void levelUp()
    {
        coinText.enabled = false;
        levelUpAssets.SetActive(true);
        isWin = true;
    }
    public void gameOver()
    {
        coinText.enabled = false;
        gameoverAssets.SetActive(true);
        StartCoroutine(delayRestart());
    }
    IEnumerator delayRestart()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Level01up()
    {
        SceneManager.LoadScene("Level02");

    }
    public void Level02up()
    {
        SceneManager.LoadScene("Level03");

    }
    public void MaınMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }

}
