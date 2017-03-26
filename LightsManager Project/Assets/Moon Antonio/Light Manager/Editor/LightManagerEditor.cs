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
	public class LightManagerEditor : Editor 
	{
		#region Menu
		/// <summary>
		/// <para>Iniciador de Manager Light</para>
		/// </summary>
		[MenuItem("Moon Antonio/ManagerLight",false,1)]
		public static void Init()// Iniciador de Manager Light
		{

		}
		#endregion
	}
}
