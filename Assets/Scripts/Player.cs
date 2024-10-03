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
    public void Teleport(GameController controller, Location destination){
        currentLocation = destination;
        controller.DisplayLocation();
    }

    public bool CanUseItem(GameController controller, Item item){
        if(item.targetItem == null)
            return true;
        if(HasItem(item.targetItem))
            return true;
        if(currentLocation.HasItem(item.targetItem))
            return true;
        controller.currentText.text = "You need the " + item.targetItem.itemName + " to use the " + item.itemName;
        return false;
    }

    public bool CanReadItem(GameController controller, Item item){
        if(item.targetItem == null)
            return true;
        if(HasItem(item.targetItem))
            return true;
        if(currentLocation.HasItem(item.targetItem))
            return true;
        return false;
    }
    public bool HasItem(Item itemToCheck){
        foreach(Item item in inventory)
        if(item == itemToCheck && item.itemEnabled)
            return true;
        return false;
    }

    public bool CanTalkToItem(GameController controller, Item item){
        return item.playerCanTalkTo;
    }

    public bool CanGiveToItem(GameController controller, Item item){
        return item.playerCanGiveTo;
    }

    public bool HasItemByName(string noun){
        foreach(Item item in inventory)
        if(item.itemName.ToLower() == noun.ToLower())
            return true;
        return false;
    }
}
