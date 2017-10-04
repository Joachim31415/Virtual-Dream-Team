using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using HappyFinish.Project;

public class PlatformStreamingFiles : ScriptableObject
{
#if UNITY_EDITOR
	public StreamingFile[] streamingFiles = new StreamingFile[0];

	[System.Serializable]
	public class StreamingFile
	{
		public string projectAssetLocation;
		public bool forceReplace;
		public AssetWithPlatform[] replacementAssets = new AssetWithPlatform[0];

		public void HandleReplace()
		{
			string location = Application.dataPath + "/" + projectAssetLocation;


			List<AssetWithPlatform> awp = new List<AssetWithPlatform>();
			foreach (AssetWithPlatform asset in replacementAssets)
			{
				if (asset.target == TargetType.BuildTarget && asset.buildTarget == UnityEditor.EditorUserBuildSettings.activeBuildTarget)
				{
					awp.Add(asset);
				}
				else if (asset.target == TargetType.PlatformTarget && FindObjectOfType<PlatformManager>().currentPlatform == asset.platformManagerTarget)
				{
					awp.Add(asset);
				}
			}

			if (awp.Count == 0)
			{
				Debug.LogError("Error copying platform dependent file, file doesn't exist for current platform");
				return;
			}
			else if (awp.Count > 1)
			{
				Debug.LogError("Error copying platform dependent file, more than one of the same file exist. Please check that only one file per platform is setup");
				return;
			}
			DirectoryInfo di = new DirectoryInfo(Application.dataPath);
			di = di.Parent;
			di = new DirectoryInfo(di.FullName + "/" + awp[0].assetPath);

			if (!forceReplace && FileCompare(new DirectoryInfo(location).FullName, di.FullName))
			{
				Debug.Log("Filed identical, leaving alone");
				return;
			}

			if (File.Exists(location))
			{
				File.Delete(location);
			}

			File.Copy(di.FullName, location);
			Debug.Log("Asset replaced successfully at: " + location);
		}

		public static bool CheckPaths(string projectPath = null, string replacementPath = null)
		{
			DirectoryInfo assetPath = new DirectoryInfo(Application.dataPath);

			if (!string.IsNullOrEmpty(projectPath))
			{
				DirectoryInfo ppDi = new DirectoryInfo(projectPath);
				if (ppDi.FullName.Contains(assetPath.FullName))
				{
					return true;
				}
			}
			else if (!string.IsNullOrEmpty(replacementPath))
			{
				DirectoryInfo rDi = new DirectoryInfo(replacementPath);

				if (!rDi.FullName.Contains(assetPath.FullName) && rDi.FullName.Contains(assetPath.Parent.FullName))
				{
					return true;
				}
			}

			Debug.LogError(
				"Path incorrect, check that your asset path is within the assets folder and " +
				"your replacement path is not in the assets folder but within the project folder");

			return false;
		}


		// Pulled from http://stackoverflow.com/questions/7931304/comparing-two-files-in-c-sharp
		// This method accepts two strings the represent two files to 
		// compare. A return value of 0 indicates that the contents of the files
		// are the same. A return value of any other value indicates that the 
		// files are not the same.
		private bool FileCompare(string file1, string file2)
		{
			int file1byte;
			int file2byte;
			FileStream fs1;
			FileStream fs2;

			// Determine if the same file was referenced two times.
			if (file1 == file2)
			{
				// Return true to indicate that the files are the same.
				return true;
			}

			// Open the two files.
			fs1 = new FileStream(file1, FileMode.Open, FileAccess.Read);
			fs2 = new FileStream(file2, FileMode.Open, FileAccess.Read);

			// Check the file sizes. If they are not the same, the files 
			// are not the same.
			if (fs1.Length != fs2.Length)
			{
				// Close the file
				fs1.Close();
				fs2.Close();

				// Return false to indicate files are different
				return false;
			}

			return true;
		}
	}

	[System.Serializable]
	public class AssetWithPlatform
	{
		public TargetType target;
		public UnityEditor.BuildTarget buildTarget;
		public PlatformManager.PlatformTarget platformManagerTarget;
		public string assetPath;
	}

	public enum TargetType
	{
		BuildTarget,
		PlatformTarget,
	}

	public void ReplaceForCurrectPlatform()
	{
		foreach (StreamingFile file in streamingFiles)
		{
			file.HandleReplace();
		}
		UnityEditor.AssetDatabase.Refresh();
	}
#endif
}
