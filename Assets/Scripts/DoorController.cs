using UnityEngine;

public class DoorController : MonoBehaviour
{
    public GameObject playerObject;
    [SerializeField] int pointsRemaining;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        pointsRemaining = playerObject.GetComponent<Player>().superJumpsRemaining;
        if (pointsRemaining > 10)
        {
            AudioManager.Instance.PlaySFX("DoorOpen");
                Destroy(gameObject);
        }
        
    }



}
