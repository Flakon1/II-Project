using NUnit.Framework;
using UnityEngine;
using System.Reflection;

public class NotificationsSelectionManagerTest
{
    private NotificationsSelectionManager CreateManager(
        GameObject notifications,
        GameObject recommendations,
        GameObject news,
        GameObject eventsPanel
    )
    {
        GameObject obj = new GameObject();
        var manager = obj.AddComponent<NotificationsSelectionManager>();

        var type = typeof(NotificationsSelectionManager);

        type.GetField("notificationsPanel", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, notifications);

        type.GetField("beachRecommendationsPanel", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, recommendations);

        type.GetField("newsUpdatesPanel", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, news);

        type.GetField("seasonalEventsPanel", BindingFlags.NonPublic | BindingFlags.Instance)
            .SetValue(manager, eventsPanel);

        return manager;
    }

    [Test]
    public void OpenRecommendationsPanel_ShouldShowOnlyRecommendations()
    {
        GameObject notifications = new GameObject();
        GameObject recommendations = new GameObject();
        GameObject news = new GameObject();
        GameObject eventsPanel = new GameObject();

        var manager = CreateManager(notifications, recommendations, news, eventsPanel);

        manager.OpenRecommendationsPanel();

        Assert.IsFalse(notifications.activeSelf);
        Assert.IsTrue(recommendations.activeSelf);
        Assert.IsFalse(news.activeSelf);
        Assert.IsFalse(eventsPanel.activeSelf);
    }

    [Test]
    public void BackToNotificationsPanel_ShouldShowOnlyNotifications()
    {
        GameObject notifications = new GameObject();
        GameObject recommendations = new GameObject();
        GameObject news = new GameObject();
        GameObject eventsPanel = new GameObject();

        var manager = CreateManager(notifications, recommendations, news, eventsPanel);

        manager.OpenNewsPanel();
        manager.BackToNotificationsPanel();

        Assert.IsTrue(notifications.activeSelf);
        Assert.IsFalse(recommendations.activeSelf);
        Assert.IsFalse(news.activeSelf);
        Assert.IsFalse(eventsPanel.activeSelf);
    }
}