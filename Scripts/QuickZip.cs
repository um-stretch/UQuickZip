using UnityEngine;
using UnityEditor;
using System.IO;
using System.IO.Compression;

public class QuickZip
{
    [MenuItem("Assets/QuickZip/Extract In Place")]
    private static void ExtractInPlace()
    {
        Object file = Selection.activeObject;
        if (file != null)
        {
            try
            {
                string filePath = AssetDatabase.GetAssetPath(file);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string extractPath = Path.GetDirectoryName(filePath);
                System.IO.Compression.ZipFile.ExtractToDirectory(filePath, $"{extractPath}/{fileName}");
                AssetDatabase.DeleteAsset(filePath);
                AssetDatabase.Refresh();
            }
            catch { }
        }
    }

    [MenuItem("Assets/QuickZip/Zip In Place")]
    private static void ZipInPlace()
    {
        Object file = Selection.activeObject;
        if (file != null)
        {
            try
            {
                string filePath = AssetDatabase.GetAssetPath(file);
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string zipPath = Path.GetDirectoryName(filePath);
                System.IO.Compression.ZipFile.CreateFromDirectory(filePath, $"{zipPath}/{fileName}.zip");
                AssetDatabase.DeleteAsset(filePath);
                AssetDatabase.Refresh();
            }
            catch { }
        }
    }
}