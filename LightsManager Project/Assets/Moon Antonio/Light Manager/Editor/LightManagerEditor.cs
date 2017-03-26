//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// LightManagerEditor.cs (26/03/2017)											\\
// Autor: Antonio Mateo (Moon Antonio) 									        \\
// Descripcion:		Herramienta para controlar las luces de al escena.			\\
// Fecha Mod:		26/03/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using UnityEditor;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Herramienta para controlar las luces de al escena</para>
	/// </summary>
	[ExecuteInEditMode]
	public class LightManagerEditor : EditorWindow
	{
		#region Menu
		/// <summary>
		/// <para>Iniciador de Manager Light</para>
		/// </summary>
		[MenuItem("Moon Antonio/ManagerLight",false,1)]
		public static void Init()// Iniciador de Manager Light
		{
			Texture icono = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Moon Antonio/Light Manager/Icon/icon.lightmanager.png");
			var window = GetWindow<LightManagerEditor>();
			window.minSize = new Vector2(0, 0);
			GUIContent tituloContenido = new GUIContent(" Light Manager", icono);
			window.titleContent = tituloContenido;
			window.Show();
		}
		#endregion
	}
}
