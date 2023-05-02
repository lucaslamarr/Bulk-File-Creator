using UnityEngine;
using UnityEditor;
using System.IO;

public class BulkFileCreator : EditorWindow
{
    private static int _maxNumberOfScripts = 10; 
    private static int _numberOfScripts = 1; //Starting value

    private static string[] _scriptNames = new string[_maxNumberOfScripts];
    private static bool[] _interfaceCount = new bool[_maxNumberOfScripts]; //Checks to see if the current index should be treated as an interface or not.

    private static bool _autoRefresh = true; //Will the asset database be refreshed automatically after creating a new script.

    private static string _savePath = ""; //Where the scripts will be saved

    [MenuItem("Window/Custom Tools/Bulk File Creator")]
    private static void CreateWindow() {
        GetWindow(typeof(BulkFileCreator));
    }
    
    private void OnGUI() {
        GUI.skin.label.wordWrap = true;
        EditorGUIUtility.labelWidth = 50;

        GUILayout.Space(20);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.Label("Number of Scripts");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        _numberOfScripts = EditorGUILayout.IntSlider(_numberOfScripts, 1, _maxNumberOfScripts);
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        GUILayout.Space(270);

        GUILayout.Label("Interface");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        for (int counter = 0; counter < _numberOfScripts; counter++) {
            GUILayout.BeginHorizontal();
            GUILayout.FlexibleSpace();

            _scriptNames[counter]    = EditorGUILayout.TextField("Name", _scriptNames[counter], GUILayout.Width(265), GUILayout.Height(20));

            _interfaceCount[counter] = EditorGUILayout.Toggle(_interfaceCount[counter], GUILayout.Width(50), GUILayout.Height(20));

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if(GUILayout.Button("Create", GUILayout.Width(215), GUILayout.Height(30)))
            CreateScripts();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        _autoRefresh = GUILayout.Toggle(_autoRefresh, "Automatic Asset Folder Refresh");
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUILayout.Label("To ensure that your new scripts will appear in the assets folder, the database needs to be refreshed whenever a new script is created. If you would prefer to create a large number of scripts and refresh them all at the same time, disable this option.",
            GUILayout.Width(300), GUILayout.Height(100));
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();

        GUILayout.Space(10);

        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        if (GUILayout.Button("Refresh Assets Folder", GUILayout.Width(215), GUILayout.Height(30)))
            RefreshAssets();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
    }
    
    private static void CreateScripts() {
        SelectSavePath();

        for (int counter = _numberOfScripts; counter < _maxNumberOfScripts; counter++) {
            _scriptNames[counter] = "";
        }

        for(int counter = 0; counter < _numberOfScripts; counter++) {
            string path = _savePath + "/" + _scriptNames[counter] + ".cs"; //Custom path set by the user

            string defaultClassContents = "using UnityEngine; \n\npublic class " + _scriptNames[counter] + " : MonoBehaviour \n { \n\tprivate void Start() \n\t{ \n\n\t} \n \n\tprivate void Update() \n\t{ \n\n\t}\n}";
            string defaultInterfaceContents = "public interface " + _scriptNames[counter] + "\n{\n\n}";
            string scriptContents;
            if (!_interfaceCount[counter])
                scriptContents = defaultClassContents; //Default monobehaviour template
            else
                scriptContents = defaultInterfaceContents; //Default interface template

            if (!string.IsNullOrEmpty(_scriptNames[counter])) {
                var script = File.CreateText(path);
                script.WriteLine(scriptContents);
                script.Close();
                if(_autoRefresh) {
                    AssetDatabase.Refresh();
                }
            }
        }
    }
    
    private static void RefreshAssets() {
        AssetDatabase.Refresh();
    }
    
    private static void SelectSavePath() {
        _savePath = EditorUtility.OpenFolderPanel("Script Save Location", "Assets", "");
    }
}
