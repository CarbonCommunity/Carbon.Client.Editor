using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Humanlights.Editor
{
    public class FindMissingScripts : EditorWindow
    {
        [MenuItem ( "Tools/FindMissingScripts" )]
        public static void ShowWindow ()
        {
            GetWindow ( typeof ( FindMissingScripts ) );
        }

        public Vector2 Scroll { get; set; }
        public List<MissingObject> MissingObjects { get; set; } = new List<MissingObject> ();

        public int GameObjectCount { get; set; } = 0;
        public int ComponentCount { get; set; } = 0;
        public int MissingCount { get; set; } = 0;

        public void OnGUI ()
        {
            GUILayout.BeginVertical ( "Box" );

            if ( GUILayout.Button ( "In Project" ) )
            {
                FindInProject ();
            }

            if ( GUILayout.Button ( "In Scene" ) )
            {
                FindInScene ();
            }

            if ( GUILayout.Button ( "In Selection" ) )
            {
                FindInSelection ();
            }

            if ( GUILayout.Button ( "Remove All" ) )
            {
                for ( int i = 0; i < MissingObjects.Count; i++ )
                {
                    var gameObject = MissingObjects [ i ].gameObject;

                    // We must use the GetComponents array to actually detect missing components
                    var components = gameObject.GetComponents<Component> ();

                    // Create a serialized object so that we can edit the component list
                    var serializedObject = new SerializedObject ( gameObject );
                    // Find the component list property
                    var prop = serializedObject.FindProperty ( "m_Component" );

                    // Track how many components we've removed
                    int r = 0;

                    // Iterate over all components
                    for ( int j = 0; j < components.Length; j++ )
                    {
                        // Check if the ref is null
                        if ( components [ j ] == null )
                        {
							Debug.Log($"Removed in {gameObject.name}");
							DestroyImmediate(components[j]);
							// If so, remove from the serialized component array
							var test = prop.GetArrayElementAtIndex(j - r);
							Debug.Log($"{test}");
							prop.DeleteArrayElementAtIndex ( j - r );
                            // Increment removed count
                            r++;
                        }
                    }

                    // Apply our changes to the game object
                    serializedObject.ApplyModifiedProperties ();
                   // if ( r > 0 ) AssetDatabase.SaveAsset ( gameObject );
                }
            }

            GUILayout.EndVertical ();

            GUILayout.Space ( 10 );
            DrawList ();
        }

        public void DrawList ()
        {
            if ( MissingObjects == null )
            {
                return;
            }

            Scroll = GUILayout.BeginScrollView ( Scroll );

            for ( int i = 0; i < MissingObjects.Count; i++ )
            {
                MissingObject o = MissingObjects [ i ];

                GUILayout.BeginHorizontal ( "Box" );

                GUILayout.Label ( string.Format ( "{0}", o.objectName ) );
                GUILayout.FlexibleSpace ();
                if ( GUILayout.Button ( "Select It", GUILayout.ExpandWidth ( false ) ) )
                {
                    Selection.activeObject = o.gameObject;
                }

                GUILayout.EndHorizontal ();
            }

            GUILayout.EndScrollView ();
        }

        private void FindInProject ()
        {
            GameObjectCount = 0;
            MissingCount = 0;
            ComponentCount = 0;
            MissingObjects.Clear ();

            var go = AssetDatabase.FindAssets ( "" ).Select ( x => AssetDatabase.LoadAssetAtPath<GameObject> ( AssetDatabase.GUIDToAssetPath ( x ) ) );

            foreach ( var g in go )
            {
                FindInGO ( g );
            }

            Print ();
        }
        private void FindInScene ()
        {
            GameObjectCount = 0;
            MissingCount = 0;
            ComponentCount = 0;
            MissingObjects.Clear ();

            var go = UnityEngine.SceneManagement.SceneManager.GetActiveScene ().GetRootGameObjects ();
            foreach ( GameObject g in go )
            {
                FindInGO ( g );
            }

            Print ();
        }
        private void FindInSelection ()
        {
            GameObjectCount = 0;
            MissingCount = 0;
            ComponentCount = 0;
            MissingObjects.Clear ();

            var go = Selection.gameObjects;
            foreach ( GameObject g in go )
            {
                FindInGO ( g );
            }

            Print ();
        }
        private void Print ()
        {
            Debug.Log ( string.Format ( "GameObject Count: {0} | Components Count: {1} | Missing Components Count: {2}", GameObjectCount.ToString ( "n0" ), ComponentCount.ToString ( "n0" ), MissingCount.ToString ( "n0" ) ) );
        }

        private void FindInGO ( GameObject g )
        {
            if ( g == null ) return;
			var property = new SerializedObject(g);

            GameObjectCount++;
            Component [] components = g.GetComponents<Component> ();
            for ( int i = 0; i < components.Length; i++ )
            {
                ComponentCount++;

                if ( components [ i ] == null )
                {
					DestroyImmediate(components[i]);

					var prop = property.FindProperty("m_Component");
					Debug.Log($"Found {prop.arraySize}");

					prop.GetArrayElementAtIndex(1).DeleteCommand();

					MissingCount++;

                    var s = g.name;
                    var t = g.transform;
                    while ( t.parent != null )
                    {
                        s = t.parent.name + "/" + s;
                        t = t.parent;
                    }

                    var missing = new MissingObject ()
                    {
                        gameObject = g,
                        objectName = s
                    };
                    MissingObjects.Add ( missing );
                }
            }

            foreach ( Transform childT in g.transform )
            {
                FindInGO ( childT.gameObject );
            }
        }

        [System.Serializable]
        public class MissingObject
        {
            public string objectName;
            public GameObject gameObject;
        }
    }
}
