using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public Logic logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("LogicC").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            if (GameObject.FindGameObjectWithTag("Dcoin"))
            {
                logic.AddScore(1);
            }
            else
            {
                logic.AddScore(5);
            }
        }
    }
}
