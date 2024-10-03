using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
  public override void RespondToInput(GameController controller, string noun){
    controller.currentText.text = "Type a Verb followed by a noun (e.g. \"go north\")";
    controller.currentText.text += "\nAllowed verbs: Go, Examine, Get, Give, Use, Inventory, TalkTo, Read, Help";
  }
}
