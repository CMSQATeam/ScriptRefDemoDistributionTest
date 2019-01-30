using UnityEngine;
using System.Collections;

namespace UnityEditor
{
    ///     <summary>
        ///     GenericMenu lets you create custom context menus and dropdown menus.
        ///     </summary>
        ///     <description>
        ///     The example below opens an Editor window with a button. Clicking the button displays a context menu, which lets you change the color to apply to the GUI in the window. Copy the example's contents into a script called GenericMenuExample.cs and put it into a folder in your project called Editor.
        ///     ![GenericMenu](GenericMenu.png).
        ///     </description>
            public sealed class GenericMenu
    {
        // Callback function, called when a menu item is selected
        /// <summary>
        /// Callback function, called when a menu item is selected.
        /// </summary>
        /// <description>
        /// SA: GenericMenu, GenericMenu.MenuFunction2.
        /// </description>
        public delegate void MenuFunction();

        // Callback function with user data, called when a menu item is selected
        /// <summary>
        /// Callback function with user data, called when a menu item is selected.
        /// </summary>
        /// <description>
        /// SA: GenericMenu, GenericMenu.MenuFunction.
        /// </description>
        /// <param name="userData">
        /// The data to pass through to the callback function.
        /// </param>
        /// <description>
        /// SA: GenericMenu, GenericMenu.MenuFunction.
        /// </description>
        public delegate void MenuFunction2(object userData);

        // Add an item to the menu
        ///     <summary>
                ///     Add an item to the menu.
                ///     </summary>
                ///     <param name="content">
                ///     The GUIContent to add as a menu item.
                ///     </param>
                ///     <param name="on">
                ///     Specifies whether to show the item is currently activated (i.e. a tick next to the item in the menu).
                ///     </param>
                ///     <param name="func">
                ///     The function to call when the menu item is selected.
                ///     </param>
                ///     <description>
                ///     SA: GenericMenu.AddDisabledItem, GenericMenu.AddSeparator.
                ///     </description>
                        public void AddItem(GUIContent content, bool on, MenuFunction func)
        {
            menuItems.Add(new MenuItem(content, false, on, func));
        }

        // Add an item to the menu
        ///     <summary>
                ///     Add an item to the menu.
                ///     </summary>
                ///     <param name="content">
                ///     The GUIContent to add as a menu item.
                ///     </param>
                ///     <param name="on">
                ///     Specifies whether to show the item is currently activated (i.e. a tick next to the item in the menu).
                ///     </param>
                ///     <param name="func">
                ///     The function to call when the menu item is selected.
                ///     </param>
                ///     <param name="userData">
                ///     The data to pass to the function called when the item is selected.
                ///     </param>
                ///     <description>
                ///     SA: GenericMenu.AddDisabledItem, GenericMenu.AddSeparator.
                ///     </description>
                ///     <dw-legacy-code>
                ///     // This example shows how to create a context menu inside a custom EditorWindow.
                ///     using UnityEngine;
                ///     using UnityEditor;
                ///     public class MyWindow : EditorWindow
                ///     {
                ///         [MenuItem("TestContextMenu/Open Window")]
                ///         public static void Init()
                ///         {
                ///             var window = GetWindow(typeof(MyWindow));
                ///             window.position = new Rect(50, 50, 250, 60);
                ///             window.Show();
                ///         }
                ///         bool item2enabled = false;
                ///         public void Toggle()
                ///         {
                ///             item2enabled = !item2enabled;
                ///             Debug.Log("item2enabled: " + item2enabled);
                ///         }
                ///         public void Item2Callback()
                ///         {
                ///             Debug.Log("Item 2 Selected");
                ///         }
                ///         public void OnGUI()
                ///         {
                ///             Event evt = Event.current;
                ///             Rect contextRect = new Rect(10, 10, 100, 100);
                ///             if (evt.type == EventType.ContextClick)
                ///             {
                ///                 Vector2 mousePos = evt.mousePosition;
                ///                 if (contextRect.Contains(mousePos))
                ///                 {
                ///                     // Now create the menu, add items and show it
                ///                     GenericMenu menu = new GenericMenu();
                ///                     menu.AddItem(new GUIContent("Toggle item 2"), item2enabled, Toggle);
                ///                     if (item2enabled)
                ///                     {
                ///                         menu.AddItem(new GUIContent("Item 2"), false, Item2Callback);
                ///                     }
                ///                     else
                ///                     {
                ///                         menu.AddDisabledItem(new GUIContent("Item 2"));
                ///                     }
                ///                     menu.ShowAsContext();
                ///                     evt.Use();
                ///                 }
                ///             }
                ///         }
                ///     }
                ///     </dw-legacy-code>
                        public void AddItem(GUIContent content, bool on, MenuFunction2 func, object userData)
        {
            menuItems.Add(new MenuItem(content, false, on, func, userData));
        }

        // Add a disabled item to the menu
        ///     <summary>
                ///     Add a disabled item to the menu.
                ///     </summary>
                ///     <param name="content">
                ///     The GUIContent to display as a disabled menu item.
                ///     </param>
                ///     <description>
                ///     The example below shows a context menu with a disabled menu item that can be toggled on and off.
                ///     ![AddDisabledItem](AddDisabledItem.png)
                ///     SA: GenericMenu.AddItem, GenericMenu.AddSeparator.
                ///     </description>
                        public void AddDisabledItem(GUIContent content)
        {
            menuItems.Add(new MenuItem(content, false, false, null));
        }

        // Add a disabled item to the menu
        ///     <summary>
                ///     Add a disabled item to the menu.
                ///     </summary>
                ///     <param name="content">
                ///     The GUIContent to display as a disabled menu item.
                ///     </param>
                ///     <param name="on">
                ///     Specifies whether to show that the item is currently activated (i.e. a tick next to the item in the menu).
                ///     </param>
                        public void AddDisabledItem(GUIContent content, bool on)
        {
            menuItems.Add(new MenuItem(content, false, on, null));
        }

        // Add a seperator item to the menu
        ///     <summary>
                ///     Add a seperator item to the menu.
                ///     </summary>
                ///     <param name="path">
                ///     The path to the submenu, if adding a separator to a submenu. When adding a separator to the top level of a menu, use an empty string as the path.
                ///     </param>
                ///     <description>
                ///     SA: GenericMenu.AddItem, GenericMenu.AddDisabledItem.
                ///     </description>
                        public void AddSeparator(string path)
        {
            menuItems.Add(new MenuItem(new GUIContent(path), true, false, null));
        }

        // Get number of items in the menu
        ///     <summary>
                ///     Get number of items in the menu.
                ///     </summary>
                ///     <returns>
                ///     The number of items in the menu.
                ///     </returns>
                        public int GetItemCount()
        {
            return menuItems.Count;
        }

        ///     <summary>
                ///     Allow the menu to have multiple items with the same name.
                ///     </summary>
                        public bool allowDuplicateNames {get; set; }

        private ArrayList menuItems = new ArrayList();

        private sealed class MenuItem
        {
            public GUIContent content;
            public bool separator;
            public bool on;
            public MenuFunction func;
            public MenuFunction2 func2;
            public object userData;
            public MenuItem(GUIContent _content, bool _separator, bool _on, MenuFunction _func)
            {
                content = _content;
                separator = _separator;
                on = _on;
                func = _func;
            }

            public MenuItem(GUIContent _content, bool _separator, bool _on, MenuFunction2 _func, object _userData)
            {
                content = _content;
                separator = _separator;
                on = _on;
                func2 = _func;
                userData = _userData;
            }
        }

        // Show the menu under the mouse
        ///     <summary>
                ///     Show the menu under the mouse when right-clicked.
                ///     </summary>
                ///     <description>
                ///     SA: GenericMenu.DropDown.
                ///     </description>
                        public void ShowAsContext()
        {
            if (Event.current == null)
                return;
            DropDown(new Rect(Event.current.mousePosition, Vector2.zero));
        }

        // Show the menu at the given screen rect
        ///     <summary>
                ///     Show the menu at the given screen rect.
                ///     </summary>
                ///     <param name="position">
                ///     The position at which to show the menu.
                ///     </param>
                ///     <description>
                ///     SA: GenericMenu.ShowAsContext.
                ///     </description>
                        public void DropDown(Rect position)
        {
            string[] titles = new string[menuItems.Count];
            bool[] enabled = new bool[menuItems.Count];
            ArrayList selected = new ArrayList();
            bool[] separator = new bool[menuItems.Count];

            for (int idx = 0; idx < menuItems.Count; idx++)
            {
                MenuItem item = (MenuItem)menuItems[idx];
                titles[idx] = item.content.text;
                enabled[idx] = ((item.func != null) || (item.func2 != null));
                separator[idx] = item.separator;
                if (item.on)
                    selected.Add(idx);
            }

            EditorUtility.DisplayCustomMenuWithSeparators(position, titles, enabled, separator, (int[])selected.ToArray(typeof(int)), CatchMenu, null, true, allowDuplicateNames);
        }

        // Display as a popup with /selectedIndex/. How this behaves depends on the platform (on Mac, it'll try to scroll the menu to the right place)
        internal void Popup(Rect position, int selectedIndex)
        {
            DropDown(position);
        }

        private void CatchMenu(object userData, string[] options, int selected)
        {
            MenuItem i = (MenuItem)menuItems[selected];
            if (i.func2 != null)
                i.func2(i.userData);
            else if (i.func != null)
                i.func();
        }
    }
}
