using UnityEngine;
using System.Collections;

public class SelectPanel : MonoBehaviour {

    public InterfaceScript interfaceScripte;

    public AttackBehaviorBase attackBehaviorObject;

    public void OnButton(GameObject aButton) { OnButton(aButton.name); }

    private string PlayMode;

    public void OnButton(string aButtonName)
    {
        Debug.Log("[InterfaceScript] OnButton received: " + aButtonName);

        switch (aButtonName)
        {
            case "SelectBack":
                {
                    interfaceScripte.selectPanel.SetActive(false);

                    interfaceScripte.startPanel.SetActive(true);
                    break;
                }
            case "StartGame":
                {
                    interfaceScripte.selectPanel.SetActive(false);
                    interfaceScripte.gamePanel.SetActive(true);
                    interfaceScripte.game.SetActive(true);

                    //attackBehaviorObject.mode = 
                    break;
                }
            case "PlayerMode1":
                {
                    PlayMode = aButtonName;
                    break;
                }
            case "PlayerMode2":
                {
                    PlayMode = aButtonName;
                    break;
                }
            case "PlayerMode3":
                {
                    PlayMode = aButtonName;
                    break;
                }

        }
    }
}
