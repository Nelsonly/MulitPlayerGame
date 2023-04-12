 using UnityEngine;
 using UnityEditor;
 
 [CustomEditor(typeof(LineCurve))]
 public class LineCurveEditor : Editor {
    public override void OnInspectorGUI () 
    {
        base.OnInspectorGUI();
        LineCurve lc = (LineCurve)target;
        lc.NeedUpdate();
    }
 }