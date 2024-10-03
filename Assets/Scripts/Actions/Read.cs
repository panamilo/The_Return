using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
    public override void RespondToInput(GameController controller, string noun)
    {

        if(ReadItem(controller, controller.player.currentLocation.items, noun))
            return;

        if(ReadItem(controller, controller.player.inventory, noun))
            return;
        
        controller.currentText.text = "There is no " + noun;
    }

    private bool ReadItem(GameController controller, List<Item> items, string noun){
        foreach(Item item in items){
            if(item.itemName == noun){
                if(controller.player.CanReadItem(controller,item))
                if(item.InteractWith(controller,"read"))
                    return true;
                controller.currentText.text = "The " + noun + " has nothing written on it.";
                return true;
            }
        }
        return false;
    }

}
