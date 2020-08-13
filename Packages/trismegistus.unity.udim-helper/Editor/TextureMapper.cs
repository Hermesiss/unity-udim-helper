using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


namespace Trismegistus.UdimHelper.Editor {
	public class TextureMapper : EditorWindow {
		[MenuItem("Trismegistus/Udim/TextureMapper")]
		public static void ShowWindow() {
			var window = GetWindow<TextureMapper>();
			window.titleContent = new GUIContent("UDIM Texture Mapper");

			window.minSize = new Vector2(250, 50);
		}

		private void OnEnable() {
			var root = rootVisualElement;

			// Loads and clones our VisualTree (eg. our UXML structure) inside the root.
			var quickToolVisualTree = Resources.Load<VisualTreeAsset>($"{nameof(TextureMapper)}_Main");
			var style = Resources.Load<StyleSheet>($"{nameof(TextureMapper)}_Style");
			root.styleSheets.Add(style);
			quickToolVisualTree.CloneTree(root);

			// Queries all the buttons (via type) in our root and passes them
			// in the SetupButton method.
			var toolButtons = root.Query<Button>();
			toolButtons.ForEach(SetupButton);
		}
		
		private void SetupButton(Button button) 
		{
			// Reference to the VisualElement inside the button that serves
			// as the button’s icon.
			var buttonIcon = button.Q(className: "texture-mapper-button-icon");

			// Icon’s path in our project.
			var iconPath = "Icons/icon-" + button.parent.name;

			// Loads the actual asset from the above path.
			var iconAsset = Resources.Load<Texture2D>(iconPath);
			iconAsset.wrapMode = TextureWrapMode.Clamp;

			// Applies the above asset as a background image for the icon.
			buttonIcon.style.backgroundImage = iconAsset;

			// Instantiates our primitive object on a left click.
			//button.clickable.clicked += () => CreateObject(button.parent.name);

			// Sets a basic tooltip to the button itself.
			button.tooltip = button.parent.name;
		}
	}
}