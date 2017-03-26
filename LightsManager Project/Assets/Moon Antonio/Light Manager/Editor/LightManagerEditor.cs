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
using System;
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
		public List<Light> luces = new List<Light>();               // Lista de luces en la escena

		/// <summary>
		/// <para>Lista de las reflection probes en la escena</para>
		/// </summary>
		public List<ReflectionProbe> reflection = new List<ReflectionProbe>();// Lista de las reflection probes en la escena
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Luces para el escaneo.</para>
		/// </summary>
		private Light[] lights;                                     // Luces para el escaneo
		/// <summary>
		/// <para>Reflection probes para el escaneo</para>
		/// </summary>
		private ReflectionProbe[] reflec;							// Reflection probes para el escaneo
		/// <summary>
		/// <para>Estado de la herramienta.</para>
		/// </summary>
		private int estadoherramienta = 0;							// Estado de la herramienta
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
			EditorGUILayout.BeginVertical("box");

			EditorGUILayout.BeginHorizontal("box");
			if (GUILayout.Button("Lights")) estadoherramienta = 0;
			if (GUILayout.Button("Reclection Probes")) estadoherramienta = 1;
#if LIGHTSHAFTS
			if (GUILayout.Button("Light shafts")) estadoherramienta = 2;
#endif
			EditorGUILayout.EndHorizontal();

			switch (estadoherramienta)
			{
				#region Luces
				case 0:
					EditorGUILayout.BeginHorizontal("box");

					EditorGUILayout.LabelField("Estado", GUILayout.MinWidth(100), GUILayout.Width(50));
					EditorGUILayout.LabelField("Nombre", GUILayout.MinWidth(100), GUILayout.Width(140));
					EditorGUILayout.LabelField("Tipo", GUILayout.MinWidth(100), GUILayout.Width(100));
					EditorGUILayout.LabelField("Modo", GUILayout.MinWidth(100), GUILayout.Width(100));
					EditorGUILayout.LabelField("Color", GUILayout.MinWidth(100), GUILayout.Width(50));
					EditorGUILayout.LabelField("Intensidad", GUILayout.MinWidth(100), GUILayout.Width(200));

					EditorGUILayout.EndHorizontal();

					for (int n = 0; n < luces.Count; n++)
					{
						EditorGUILayout.BeginHorizontal("box");

						luces[n].enabled = EditorGUILayout.Toggle(luces[n].enabled, GUILayout.MinWidth(100), GUILayout.Width(50));
						luces[n].name = EditorGUILayout.TextField(luces[n].name, GUILayout.MinWidth(100), GUILayout.Width(140));
						luces[n].type = (LightType)EditorGUILayout.EnumPopup(luces[n].type, GUILayout.MinWidth(100), GUILayout.Width(100));
						luces[n].lightmappingMode = (LightmappingMode)EditorGUILayout.EnumPopup(luces[n].lightmappingMode, GUILayout.MinWidth(100), GUILayout.Width(100));
						luces[n].color = EditorGUILayout.ColorField(luces[n].color, GUILayout.MinWidth(100), GUILayout.Width(50));
						luces[n].intensity = EditorGUILayout.Slider(luces[n].intensity, 0, 10, GUILayout.MinWidth(100), GUILayout.Width(200));

						EditorGUILayout.EndHorizontal();
					}
					break;
				#endregion

				#region Reclection Probes
				case 1:
					EditorGUILayout.BeginHorizontal("box");

					EditorGUILayout.LabelField("Estado", GUILayout.MinWidth(100), GUILayout.Width(50));
					EditorGUILayout.LabelField("Nombre", GUILayout.MinWidth(100), GUILayout.Width(140));
					EditorGUILayout.LabelField("Tipo", GUILayout.MinWidth(100), GUILayout.Width(100));
					EditorGUILayout.LabelField("Intensidad", GUILayout.MinWidth(100), GUILayout.Width(200));

					EditorGUILayout.EndHorizontal();

					for (int n = 0; n < reflection.Count; n++)
					{
						EditorGUILayout.BeginHorizontal("box");

						reflection[n].enabled = EditorGUILayout.Toggle(reflection[n].enabled, GUILayout.MinWidth(100), GUILayout.Width(50));
						reflection[n].name = EditorGUILayout.TextField(reflection[n].name, GUILayout.MinWidth(100), GUILayout.Width(140));
						reflection[n].mode = (UnityEngine.Rendering.ReflectionProbeMode)EditorGUILayout.EnumPopup(reflection[n].mode, GUILayout.MinWidth(100), GUILayout.Width(100));
						reflection[n].intensity = EditorGUILayout.Slider(reflection[n].intensity, 0, 10, GUILayout.MinWidth(100), GUILayout.Width(200));

						EditorGUILayout.EndHorizontal();
					}
					break;
				#endregion

				#region Lights Probes
#if LIGHTSHAFTS
				case 2:
					break;
#endif
				#endregion

				default:
					estadoherramienta = 0;
					break;
			}

			EditorGUILayout.EndVertical();
		}
		#endregion

		#region Metodos
		/// <summary>
		/// <para>Escanea las luces de la escena.</para>
		/// </summary>
		private void Escaneo()// Escanea las luces de la escena
		{
			// Limpiar lista y array
			Array.Clear(lights, 0, lights.Length);
			Array.Clear(reflec, 0, reflec.Length);
			luces.Clear();
			reflection.Clear();


			// Agregar las luces a la lista
			lights = FindObjectsOfType(typeof(Light)) as Light[];
			foreach (Light light in lights)
			{
				luces.Add(light);
			}

			// Agregar las reclection a la lista
			reflec = FindObjectsOfType(typeof(ReflectionProbe)) as ReflectionProbe[];
			foreach (ReflectionProbe reflectionP in reflec)
			{
				reflection.Add(reflectionP);
			}
		}
		#endregion
	}
}
