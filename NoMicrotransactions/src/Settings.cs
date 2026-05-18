using SML;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBeMadeStatic.Global

namespace NoMicrotransactions;

[DynamicSettings]
public class Settings
{
    // this method has to exist because common curtis L
    public static bool GetBool(ModSettings.CheckboxSetting setting)
    {
        try
        {
            return ModSettings.GetBool(setting.Name);
        }
        catch //(ModSettings.MissingSettingNameException)
              // WHY IS AN EXCEPTION EVEN PRIVATE??? CURTIS!!!
              // https://learn.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1064
        {
            return setting.DefaultValue;
        }
    }

    private static UnityAction<bool> OnHomeChange(string gameObjectName)
    {
        return active =>
        {
            if (SceneManager.GetActiveScene().name != "HomeScene")
            {
                return;
            }

            var canvas = GameObject.Find("/HomeUI(Clone)/HomeScreenMainCanvas/SafeArea");

            canvas.transform.Find(gameObjectName).gameObject.SetActive(active);
        };
    }

    public ModSettings.CheckboxSetting Home_Shop => new()
    {
        Name = "Home › Shop",
        Description = "Disable this setting to hide the Shop button on the Home screen.\n\n" +
                      "NOTE: Disabling this setting will prevent you from buying items with TP.",
        DefaultValue = true,
        Available = true,
        AvailableInGame = false,
        OnChanged = OnHomeChange("LeftButtons/Shop_Renamed")
    };

    public ModSettings.CheckboxSetting Home_Cauldron => new()
    {
        Name = "Home › Cauldron",
        Description = "Disable this setting to hide the Cauldron button on the Home screen.\n\n" +
                      "NOTE: Disabling this setting will prevent you from claiming free daily potions.",
        DefaultValue = true,
        Available = true,
        AvailableInGame = false,
        OnChanged = OnHomeChange("LeftButtons/Cauldron")
    };

    public ModSettings.CheckboxSetting Home_Battlepass => new()
    {
        Name = "Home › Battlepass",
        Description = "Disable this setting to hide the Battlepass (bottom) on the Home screen.\n\n" +
                      "NOTE: Disabling this setting will prevent you from claiming rewards from the free Battlepass track.",
        DefaultValue = true,
        Available = true,
        AvailableInGame = false,
        OnChanged = OnHomeChange("BattlePassStatusPanel")
    };

    public ModSettings.CheckboxSetting Home_NewsTab => new()
    {
        Name = "Home › News Tab",
        Description = "Disable this setting to hide the News Tab panel (bottom-right) on the Home screen.",
        DefaultValue = true,
        Available = true,
        AvailableInGame = false,
        OnChanged = OnHomeChange("HomeNewsTab/ThumbnailContainer")
    };

    public ModSettings.CheckboxSetting Home_DailyDeal => new()
    {
        Name = "Home › Daily Deal",
        Description = "Disable this setting to hide the Daily Deal button (right) on the Home screen.",
        DefaultValue = false,
        Available = true,
        AvailableInGame = false,
        OnChanged = OnHomeChange("HomeFeatureItemsAndDailyDealsElementsUI/MainPanelGroup/DailyDealUI")
    };

    public ModSettings.CheckboxSetting Battlepass_PremiumTrack => new()
    {
        Name = "Battlepass › Premium Track",
        Description = "Disable this setting to hide the Premium track on the Battlepass window.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Battlepass.Name)
    };

    public ModSettings.CheckboxSetting Personalize_TomeOfFate => new()
    {
        Name = "Personalize › Tome of Fate",
        Description = "Disable this setting to hide the Tome of Fate from the Personalize menu.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = true
    };

    public ModSettings.CheckboxSetting Personalize_TomeOfFateBoostSkip => new()
    {
        Name = "Personalize › Tome of Fate Boost/Skip",
        Description = "Disable this setting to hide the Tome of Fate's Boost and Skip buttons.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Personalize_TomeOfFate.Name)
    };

    public ModSettings.CheckboxSetting Cauldron_ImproveCauldron => new()
    {
        Name = "Cauldron › Improve Cauldron",
        Description = "Disable this setting to hide the \"Improve Your Cauldron\" panel (top-left) on the Cauldron screen.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Cauldron.Name)
    };

    public ModSettings.CheckboxSetting Cauldron_CauldronLevel => new()
    {
        Name = "Cauldron › Cauldron Level",
        Description = "Disable this setting to hide the panel showing your Cauldron level (bottom-left) on the Cauldron screen.",
        DefaultValue = true,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Cauldron.Name)
    };

    public ModSettings.CheckboxSetting Cauldron_PremiumPotions => new()
    {
        Name = "Cauldron › Premium Potions",
        Description = "Disable this setting to hide purchasable potions on the Cauldron screen.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Cauldron.Name)
    };

    public ModSettings.CheckboxSetting Shop_BundlesSection => new()
    {
        Name = "Shop › Bundles Section",
        Description = "Disable this setting to hide the Bundles section in the Shop.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Shop.Name)
    };

    public ModSettings.CheckboxSetting Shop_AccountItemsSection => new()
    {
        Name = "Shop › Account Items Section",
        Description = "Disable this setting to hide the Account Items section in the Shop.\n\n" +
                      "NOTE: Disabling this setting will prevent you from accessing the \"Creator Code\", \"Redeem Code\" and the Extra Scroll Slots items.",
        DefaultValue = true,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Shop.Name)
    };

    public ModSettings.CheckboxSetting Shop_TownPointsSection => new()
    {
        Name = "Shop › Town Points Section",
        Description = "Disable this setting to hide the Town Points section in the Shop.",
        DefaultValue = false,
        AvailableInGame = false,
        Available = ModSettings.GetBool(Home_Shop.Name)
    };
}