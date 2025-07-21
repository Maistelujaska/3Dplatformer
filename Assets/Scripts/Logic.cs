using UnityEngine;
using TMPro;


public class Logic : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public Logic logic;

    [ContextMenu("Increase Score")]
    public void AddScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Reduce Score")]
    public void RemoveScore(int scoreToRemove)
    {
        playerScore = playerScore - scoreToRemove;
        scoreText.text = playerScore.ToString();
    }
    /*
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicC").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        logic.addScore(1);
    }
    */
}
