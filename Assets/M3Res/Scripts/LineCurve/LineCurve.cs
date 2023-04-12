using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LineCurve : MonoBehaviour
{
    LineRenderer _line;

    [SerializeField]
    Transform _fromPos;
    public Transform fromPos {get => _fromPos; set {_fromPos = value; NeedUpdate(); } }

    [SerializeField]
    Transform _toPos;
    public Transform toPos {get => _toPos; set {_toPos = value; NeedUpdate(); } }

    [SerializeField]
    float _param1;
    public float    param1 {get {return _param1;} set {_param1 = value; NeedUpdate(); } }

    [SerializeField]
    float _param2;
    public float    param2 {get {return _param2;} set {_param2 = value; NeedUpdate(); } }

    [SerializeField]
    bool _autoFlipX;
    public bool    autoFlipX {get {return _autoFlipX;} set {_autoFlipX = value; NeedUpdate(); } }

    [SerializeField]
    bool _autoFlipY;
    public bool    autoFlipY {get {return _autoFlipY;} set {_autoFlipY = value; NeedUpdate(); } }

    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        UpdatePositions();
    }

    bool needUpdate = false;

    Vector3 BezierPathCalculation(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {	
        float tt = t * t;
        float ttt = t * tt;
        float u = 1.0f - t;
        float uu = u * u;
        float uuu = u * uu;
        
        Vector3 B = new Vector3();
        B = uuu * p0;
        B += 3.0f * uu * t * p1;
        B += 3.0f * u * tt * p2;
        B += ttt * p3;
        
        return B;
    }    

    const int POINTCOUNT = 16;

    Vector3 savedPos1, savedPos2;

    void UpdatePositions() {

        if (_line == null || _fromPos == null || toPos == null)
            return;
        if (param1 == 0 && param2 == 0) {
            _line.positionCount = 2;
            _line.SetPosition(0, _fromPos.position);
            _line.SetPosition(1, _toPos.position);
        } else {
            Vector3 p1 = _fromPos.position;
            Vector3 p2 = _toPos.position;
            Vector2 dv = (p2 - p1);
            dv = new Vector2(-dv.y, dv.x).normalized;

            float f1 = param1;
            float f2 = param2;
            if (_autoFlipX && p2.x < p1.x) {
                f1 = -f1;
                f2 = -f2;
            }
            if (_autoFlipY && p2.y < p1.y) {
                f1 = -f1;
                f2 = -f2;
            }
            // Vector3 nor = Vector3.Cross(p1, p2).normalized;
            // Vector3.RotateTowards(nor, )
            Vector3 mid1 = p1 + (p2 - p1) * 0.25f + new Vector3(dv.x * f1, dv.y * f1);
            Vector3 mid2 = p1 + (p2 - p1) * 0.75f + new Vector3(dv.x * f2, dv.y * f2);

            _line.positionCount = POINTCOUNT + 1;
            for (int i = 0; i <= POINTCOUNT; i ++)
            {
                float t = (float)i / POINTCOUNT;
                Vector3 point = BezierPathCalculation (p1, mid1, mid2, p2, t);
                _line.SetPosition(i, point);
            }            
        }

        savedPos1 = _fromPos.position;
        savedPos2 = _toPos.position;
    }

    public void NeedUpdate() {
        needUpdate = true;       
    }

    void Update()
    {
        if (_line == null || _fromPos == null || toPos == null)
            return;
        if (savedPos1 != _fromPos.position || savedPos2 != _toPos.position)
            needUpdate = true;

        if (needUpdate) {
            needUpdate = false;
            UpdatePositions();
        }
    }
}
