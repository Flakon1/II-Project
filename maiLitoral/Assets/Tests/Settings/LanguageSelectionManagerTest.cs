using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class LanguageSelectionManagerTest
{
    private LanguageSelectionManager CreateManager(
        GameObject romanian,
        GameObject english
    )
    {
        GameObject obj = new GameObject();
        var manager = obj.AddComponent<LanguageSelectionManager>();

        var type = typeof(LanguageSelectionManager);

        type.GetField("romanianCheck", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, romanian);

        type.GetField("englishCheck", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, english);

        return manager;
    }

    [Test]
    public void SelectRomanian_ShouldEnableRomanianAndDisableEnglish()
    {
        GameObject romanian = new GameObject();
        GameObject english = new GameObject();

        romanian.SetActive(false);
        english.SetActive(true);

        var manager = CreateManager(romanian, english);

        manager.SelectRomanian();

        Assert.IsTrue(romanian.activeSelf);
        Assert.IsFalse(english.activeSelf);
    }

    [Test]
    public void SelectEnglish_ShouldEnableEnglishAndDisableRomanian()
    {
        GameObject romanian = new GameObject();
        GameObject english = new GameObject();

        romanian.SetActive(true);
        english.SetActive(false);

        var manager = CreateManager(romanian, english);

        manager.SelectEnglish();

        Assert.IsFalse(romanian.activeSelf);
        Assert.IsTrue(english.activeSelf);
    }
}