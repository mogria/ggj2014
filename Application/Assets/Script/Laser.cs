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
		public class Laser : Tool
		{
				public Laser () : base()
				{
				}

				override public string GetPrefabPath()
				{
					return "roboter/Laser";
				}

				public override void Action ()
				{
					Debug.Log ("SHOOT");
				}
		}
}

