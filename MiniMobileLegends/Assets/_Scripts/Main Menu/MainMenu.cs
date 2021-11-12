using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
   public void OnClickTeamColorMenu()
   {
      MenuManager.OpenMenu(Menu.TeamColor, gameObject);
   }
}
