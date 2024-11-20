using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PageTransitionByButton))]
public class PageTransitionEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        PageTransitionByButton pageTransitionByButton = (PageTransitionByButton)target;
        List<GameObject> pages = PageManagement.GetPages();
        string[] pageNames = pages.Select(page => page.name).ToArray();

        int firstPageIndex = pageTransitionByButton.GetIndex();
        int selectedIndex = EditorGUILayout.Popup("Page", firstPageIndex, pageNames);

        if (selectedIndex != firstPageIndex)
        {
            pageTransitionByButton.SetIndex(selectedIndex);
        }
    }
}