// using NUnit.Framework;
// using UnityEngine;
// using TMPro;

// public class SearchBarScriptTest
// {
//     [Test]
//     public void SearchBeach_WithEmptyInput_ShouldNotSaveSearchText()
//     {
//         BeachSearchData.searchText = "old value";

//         GameObject obj = new GameObject();
//         SearchBarScript script = obj.AddComponent<SearchBarScript>();

//         GameObject inputObj = new GameObject();
//         TMP_InputField input = inputObj.AddComponent<TMP_InputField>();

//         input.text = "";
//         script.nameInput = input;

//         script.SearchBeach();

//         Assert.AreEqual("old value", BeachSearchData.searchText);
//     }
// }
