// using NUnit.Framework;
// using UnityEngine;
// using TMPro;
// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Reflection;

// public class SearchAutoCompleteControllerTest
// {
//     [Test]
//     public void OnSearchValueChanged_ShouldShowSuggestion_WhenInputMatches()
//     {
//         GameObject obj = new GameObject();
//         SearchManager controller = obj.AddComponent<SearchManager>();

//         Type controllerType = typeof(SearchManager);

//         GameObject textObj = new GameObject();
//         TextMeshProUGUI autoText = textObj.AddComponent<TextMeshProUGUI>();

//         FieldInfo autoTextField = controllerType.GetField(
//             "autoCompleteText",
//             BindingFlags.NonPublic | BindingFlags.Instance
//         );

//         autoTextField.SetValue(controller, autoText);

//         Type itemType = controllerType.GetNestedType(
//             "SearchItem",
//             BindingFlags.NonPublic
//         );

//         object item = Activator.CreateInstance(itemType);

//         itemType.GetField("label").SetValue(item, "Mamaia");
//         itemType.GetField("targetObject").SetValue(item, new GameObject());

//         Type listType = typeof(List<>).MakeGenericType(itemType);
//         IList list = (IList)Activator.CreateInstance(listType);
//         list.Add(item);

//         FieldInfo searchItemsField = controllerType.GetField(
//             "searchItems",
//             BindingFlags.NonPublic | BindingFlags.Instance
//         );

//         searchItemsField.SetValue(controller, list);

//         MethodInfo method = controllerType.GetMethod(
//             "OnSearchValueChanged",
//             BindingFlags.NonPublic | BindingFlags.Instance
//         );

//         method.Invoke(controller, new object[] { "ma" });

//         Assert.AreEqual("Mamaia", autoText.text);
//     }
// }