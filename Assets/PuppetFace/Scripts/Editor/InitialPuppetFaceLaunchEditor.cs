using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PuppetFace
{
	[InitializeOnLoad]
	public class InitialPuppetFaceLaunchEditor : MonoBehaviour
	{
		static InitialPuppetFaceLaunchEditor()
		{
			if (AssetDatabase.IsValidFolder("Assets/PuppetFace/Gizmos"))
			{
				if (!AssetDatabase.IsValidFolder("Assets/Gizmos"))
				{
					FileUtil.MoveFileOrDirectory("Assets/PuppetFace/Gizmos", "Assets/Gizmos");
					FileUtil.DeleteFileOrDirectory("Assets/PuppetFace/Gizmos.meta");
				}
				else
				{
					if (AssetDatabase.IsValidFolder("Assets/PuppetFace/Gizmos"))
					{
						if (!AssetDatabase.IsValidFolder("Assets/Gizmos/PuppetFace"))
						{
							FileUtil.MoveFileOrDirectory("Assets/PuppetFace/Gizmos/PuppetFace", "Assets/Gizmos/PuppetFace");
						}
					}

				}
				Debug.Log("Puppet Face is installed.");
			}

		}
	}

}