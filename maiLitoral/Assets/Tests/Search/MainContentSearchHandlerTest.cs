// using NUnit.Framework;
// using UnityEngine;

// public class MainContentSearchHandlerTest
// {
//     [Test]
//     public void ShouldActivateMamaiaPanel_WhenSearchTextIsMamaia()
//     {
//         BeachSearchData.searchText = "mamaia";

//         GameObject obj = new GameObject();
//         MainContentSearchHandler handler = obj.AddComponent<MainContentSearchHandler>();

//         handler.beachesPanel_Nord = new GameObject();
//         handler.beachesPanel_MamaiaNord = new GameObject();
//         handler.beachesPanel_Mamaia = new GameObject();
//         handler.beachesPanel_Constanta = new GameObject();
//         handler.beachesPanel_Eforie = new GameObject();
//         handler.beachesPanel_Costinesti = new GameObject();
//         handler.beachesPanel_SudLitoral = new GameObject();
//         handler.beachesPanel_Mangalia = new GameObject();
//         handler.beachesPanel_VamaVeche = new GameObject();

//         handler.SendMessage("Start");

//         Assert.IsTrue(handler.beachesPanel_Mamaia.activeSelf);
//         Assert.IsFalse(handler.beachesPanel_Nord.activeSelf);
//         Assert.IsFalse(handler.beachesPanel_Eforie.activeSelf);
//     }
// }