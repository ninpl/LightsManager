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
using System.Collections.Generic;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Herramienta para controlar las luces de al escena</para>
	/// </summary>
	[ExecuteInEditMode]
	public class LightManagerEditor : EditorWindow
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Lista de luces en la escena.</para>
		/// </summary>
		public List<Light> luces = new List<Light>();				// Lista de luces en la escena
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Luces para el escaneo.</para>
		/// </summary>
		private Light[] lights;										// Luces para el escaneo
		#endregion

		#region Menu
		/// <summary>
		/// <para>Iniciador de Manager Light</para>
		/// </summary>
		[MenuItem("Moon Antonio/ManagerLight",false,1)]
		public static void Init()// Iniciador de Manager Light
		{
			Texture icono = AssetDatabase.LoadAssetAtPath<Texture>("Assets/Moon Antonio/Light Manager/Icon/icon.lightmanager.png");
			GUIContent tituloContenido = new GUIContent(" Light Manager", icono);

			var window = GetWindow<LightManagerEditor>();

			window.minSize = new Vector2(0, 0);
			window.titleContent = tituloContenido;
			window.Show();
		}

		/// <summary>
		/// <para>Cuando esta activo LightManagerEditor</para>
		/// </summary>
		public void OnEnable()// Cuando esta activo LightManagerEditor
		{
			// Escaneo de las luces de la escena
			Escaneo();
		}
		#endregion

		#region UI
		/// <summary>
		/// <para>Interfaz de LightManagerEditor</para>
		/// </summary>
		private void OnGUI()// Interfaz de LightManagerEditor
		{
			for (int n = 0; n < luces.Count; n++)
			{
				EditorGUILayout.LabelField(luces[n].name);
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Escanea las luces de la escena.</para>
		/// </summary>
		private void Escaneo()// Escanea las luces de la escena
		{
			lights = FindObjectsOfType(typeof(Light)) as Light[];
			foreach (Light light in lights)
			{
				luces.Add(light);
			}
		}
		#endregion
	}
}
