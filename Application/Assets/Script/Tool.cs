//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.1008
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;

namespace AssemblyCSharp
{
		public class Tool
		{
				public static Tool ActiveTool;

				GameObject Voxel;
				public Tool ()
				{
					Voxel = GameObject.Find(GetPrefabPath());
					if(Voxel) Hide();
				}

				public virtual string GetPrefabPath()
				{
					return string.Empty;
				}

				public virtual void Action()
				{
					
				}

				public void Show()
				{
					Voxel.SetActive (true);
				}

				public void Hide()
				{
					if(Voxel) Voxel.SetActive (false);
				}
		}
}

