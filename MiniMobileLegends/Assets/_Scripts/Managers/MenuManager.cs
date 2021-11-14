using UnityEngine;

public static class MenuManager
{
   private static GameObject mainMenu, teamColorMenu, enemyColorMenu;
   private static bool isInitialized;
   public static void Init()
   {
      GameObject canvas = GameObject.Find("Canvas");
      mainMenu = canvas.transform.Find("Main Menu").gameObject;
      teamColorMenu = canvas.transform.Find("Team Color Menu").gameObject;
      enemyColorMenu = canvas.transform.Find("Enemy Color Menu").gameObject;

      isInitialized = true;
   }

   public static void OpenMenu(Menu menu, GameObject callingMenu)
   {
      if(!isInitialized)
         Init();
      
      switch (menu)
      {
         case Menu.MainMenu:
            mainMenu.SetActive(true);
            break;
         case Menu.TeamColor:
            teamColorMenu.SetActive(true);
            break;
         case Menu.EnemyColor:
            enemyColorMenu.SetActive(true);
            break;
      }
      
      callingMenu.SetActive(false);
   }
}
