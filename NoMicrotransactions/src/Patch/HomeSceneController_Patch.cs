using HarmonyLib;
using Home.HomeScene;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace NoMicrotransactions.Patch;

[HarmonyPatch(typeof(HomeSceneController))]
public class HomeSceneController_Patch
{
    [HarmonyPatch(nameof(HomeSceneController.ValidateLeftButtons))]
    [HarmonyPostfix]
    private static void ValidateLeftButtons_Postfix()
    {
        var obj = GameObject.Find("/HomeUI(Clone)/HomeScreenMainCanvas/SafeArea");

        if (!Settings.GetBool(Mod.Settings.Home_Shop))
        {
            obj.transform.Find("LeftButtons/Shop_Renamed").gameObject.SetActive(false);
            Mod.Logger.LogInfo("Deactivated LeftButtons/Shop_Renamed (HomeScene)");
        }

        if (!Settings.GetBool(Mod.Settings.Home_Cauldron))
        {
            obj.transform.Find("LeftButtons/Cauldron").gameObject.SetActive(false);
            Mod.Logger.LogInfo("Deactivated LeftButtons/Cauldron (HomeScene)");
        }

        if (!Settings.GetBool(Mod.Settings.Home_Battlepass))
        {
            obj.transform.Find("BattlePassStatusPanel").gameObject.SetActive(false);
            Mod.Logger.LogInfo("Deactivated BattlePassStatusPanel (HomeScene)");
        }

        if (!Settings.GetBool(Mod.Settings.Home_NewsTab))
        {
            obj.transform.Find("HomeNewsTab/ThumbnailContainer").gameObject.SetActive(false);
            Mod.Logger.LogInfo("Deactivated HomeNewsTab (HomeScene)");
        }

        if (!Settings.GetBool(Mod.Settings.Home_DailyDeal))
        {
            obj.transform.Find("HomeFeatureItemsAndDailyDealsElementsUI/MainPanelGroup/DailyDealUI").gameObject.SetActive(false);
            Mod.Logger.LogInfo("Deactivated DailyDealUI (HomeScene)");
        }
    }
}