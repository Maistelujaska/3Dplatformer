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
    /*
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 8)
        {
            
            if (gameObject.tag == "Dcoin")
            {
                logic.AddScore(1);
                collision.
            }
            else
            {
                logic.AddScore(5);
            }
            
            //logic.AddScore(3);
        }
    }
    */
}
