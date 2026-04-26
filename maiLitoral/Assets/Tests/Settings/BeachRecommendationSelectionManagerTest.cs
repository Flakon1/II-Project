using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class BeachRecommendationSelectionManagerTest
{
    private BeachRecommendationSelectionManager CreateManager(
        GameObject popular,
        GameObject quiet,
        GameObject family
    )
    {
        GameObject obj = new GameObject();
        var manager = obj.AddComponent<BeachRecommendationSelectionManager>();

        var type = typeof(BeachRecommendationSelectionManager);

        type.GetField("popularCheck", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, popular);

        type.GetField("quietCheck", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, quiet);

        type.GetField("familyCheck", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, family);

        return manager;
    }

    [SetUp]
    public void SetUp()
    {
        PlayerPrefs.DeleteKey("BeachRecommendationType");
    }

    [Test]
    public void SelectPopular_ShouldSelectPopularOnly()
    {
        GameObject popular = new GameObject();
        GameObject quiet = new GameObject();
        GameObject family = new GameObject();

        popular.SetActive(false);
        quiet.SetActive(false);
        family.SetActive(false);

        var manager = CreateManager(popular, quiet, family);

        manager.SelectPopular();

        Assert.IsTrue(popular.activeSelf);
        Assert.IsFalse(quiet.activeSelf);
        Assert.IsFalse(family.activeSelf);
        Assert.AreEqual("Popular", manager.GetSelectedRecommendation());
        Assert.IsTrue(manager.AreNotificationsEnabled());
    }

    [Test]
    public void SelectPopular_WhenAlreadySelected_ShouldClearSelection()
    {
        GameObject popular = new GameObject();
        GameObject quiet = new GameObject();
        GameObject family = new GameObject();

        popular.SetActive(false);
        quiet.SetActive(false);
        family.SetActive(false);

        var manager = CreateManager(popular, quiet, family);

        manager.SelectPopular();
        manager.SelectPopular();

        Assert.IsFalse(popular.activeSelf);
        Assert.AreEqual("", manager.GetSelectedRecommendation());
        Assert.IsFalse(manager.AreNotificationsEnabled());
    }
}