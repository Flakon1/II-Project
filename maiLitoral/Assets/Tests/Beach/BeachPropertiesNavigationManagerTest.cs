// using NUnit.Framework;
// using UnityEngine;
// using System.Reflection;

// public class BeachPropertiesNavigationManagerTest
// {
//     private BeachPropertiesNavigationManager CreateManager(
//         GameObject zoneBeaches,
//         GameObject beachProperties,
//         GameObject[] propertyPanels
//     )
//     {
//         GameObject obj = new GameObject();
//         BeachPropertiesNavigationManager manager =
//             obj.AddComponent<BeachPropertiesNavigationManager>();

//         typeof(BeachPropertiesNavigationManager)
//             .GetField("zoneBeaches", BindingFlags.NonPublic | BindingFlags.Instance)
//             .SetValue(manager, zoneBeaches);

//         typeof(BeachPropertiesNavigationManager)
//             .GetField("beachProperties", BindingFlags.NonPublic | BindingFlags.Instance)
//             .SetValue(manager, beachProperties);

//         typeof(BeachPropertiesNavigationManager)
//             .GetField("propertyPanels", BindingFlags.NonPublic | BindingFlags.Instance)
//             .SetValue(manager, propertyPanels);

//         return manager;
//     }

//     [Test]
//     public void OpenBeachProperties_ShouldShowOnlySelectedPanel()
//     {
//         GameObject zoneBeaches = new GameObject();
//         GameObject beachProperties = new GameObject();

//         GameObject[] panels =
//         {
//             new GameObject(),
//             new GameObject(),
//             new GameObject()
//         };

//         BeachPropertiesNavigationManager manager =
//             CreateManager(zoneBeaches, beachProperties, panels);

//         manager.OpenBeachProperties(1);

//         Assert.IsFalse(zoneBeaches.activeSelf);
//         Assert.IsTrue(beachProperties.activeSelf);

//         Assert.IsFalse(panels[0].activeSelf);
//         Assert.IsTrue(panels[1].activeSelf);
//         Assert.IsFalse(panels[2].activeSelf);
//     }

//     [Test]
//     public void BackToBeaches_ShouldShowBeachListAndHideAllPropertyPanels()
//     {
//         GameObject zoneBeaches = new GameObject();
//         GameObject beachProperties = new GameObject();

//         GameObject[] panels =
//         {
//             new GameObject(),
//             new GameObject(),
//             new GameObject()
//         };

//         BeachPropertiesNavigationManager manager =
//             CreateManager(zoneBeaches, beachProperties, panels);

//         manager.OpenBeachProperties(2);
//         manager.BackToBeaches();

//         Assert.IsTrue(zoneBeaches.activeSelf);
//         Assert.IsFalse(beachProperties.activeSelf);

//         Assert.IsFalse(panels[0].activeSelf);
//         Assert.IsFalse(panels[1].activeSelf);
//         Assert.IsFalse(panels[2].activeSelf);
//     }
// }