using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class AppearanceSelectionManagerTest
{
    private AppearanceSelectionManager CreateManager(
        GameObject palette,
        GameObject theme,
        GameObject appearance
    )
    {
        GameObject obj = new GameObject();
        var manager = obj.AddComponent<AppearanceSelectionManager>();

        var type = typeof(AppearanceSelectionManager);

        type.GetField("paletteSelection", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, palette);

        type.GetField("themeSelection", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, theme);

        type.GetField("appearancePanel", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, appearance);

        return manager;
    }

    [Test]
    public void TogglePaletteSelection_ShouldShowPaletteAndHideTheme()
    {
        GameObject palette = new GameObject();
        GameObject theme = new GameObject();
        GameObject appearance = new GameObject();

        palette.SetActive(false);
        theme.SetActive(true);

        var manager = CreateManager(palette, theme, appearance);

        manager.TogglePaletteSelection();

        Assert.IsTrue(palette.activeSelf);
        Assert.IsFalse(theme.activeSelf);
    }

    [Test]
    public void HandleBackButton_ShouldCloseAppearancePanel_WhenNoSubPanelIsOpen()
    {
        GameObject palette = new GameObject();
        GameObject theme = new GameObject();
        GameObject appearance = new GameObject();

        palette.SetActive(false);
        theme.SetActive(false);
        appearance.SetActive(true);

        var manager = CreateManager(palette, theme, appearance);

        manager.HandleBackButton();

        Assert.IsFalse(appearance.activeSelf);
    }
}