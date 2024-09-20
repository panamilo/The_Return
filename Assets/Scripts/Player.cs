using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Location currentLocation;
    public List<Item> inventory = new List<Item>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeLocation(GameController controller, string connectionNoun){
        Connection connection = currentLocation.GetConnection(connectionNoun);
        if(connection != null ) {
            if(connection.connectionEnabled){
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }
}
