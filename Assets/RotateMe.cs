using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RotateMe : MonoBehaviour
{

    public int ObjectNumber;
	public float Q;
    private static Matrix4x4 _initialTransform;
	
	public void Slider_Change(float f)
    {

		Q = f;
    }
	
	public static Vector3 GetTranslation(ref Matrix4x4 matrix)
    {
        return new Vector3(matrix.m03, matrix.m13, matrix.m23);
    }

    public static Quaternion GetRotation(ref Matrix4x4 matrix)
    {
        return matrix.rotation;
    }

    public static Vector3 GetScale(ref Matrix4x4 matrix)
    {
        return new Vector3(
            matrix.GetColumn(0).magnitude,
            matrix.GetColumn(1).magnitude,
            matrix.GetColumn(2).magnitude
        );
    }

    public static void ApplyMatrix(Transform transform, Matrix4x4 matrix)
    {
        //transform.localPosition = GetTranslation(ref matrix);
        transform.localRotation = GetRotation(ref matrix);
        //transform.localScale = GetScale(ref matrix);
    }

    public static void ApplyTranslation(Transform transform, Matrix4x4 matrix)
    {
        transform.localPosition = GetTranslation(ref matrix);
       
    }

    // Matrice de Rotation axe Y
    public static Matrix4x4 GetT0(float q0)
    {
        return new Matrix4x4(
            new Vector4(Mathf.Cos(q0), 0, -Mathf.Sin(q0), 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(Mathf.Sin(q0), 0, Mathf.Cos(q0), 0),
            new Vector4(0, 0, 0, 1)
        );
    }

    // Matrice de Rotation axe Z
    public static Matrix4x4 GetT1(float q1)
    {
        return new Matrix4x4(
            new Vector4(Mathf.Cos(q1), Mathf.Sin(q1), 0, 0),
            new Vector4(-Mathf.Sin(q1), Mathf.Cos(q1), 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );
    }

    // Matrice de Rotation axe X
    public static Matrix4x4 GetT2(float q1)
    {
        return new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, Mathf.Cos(q1), -Mathf.Sin(q1), 0),
            new Vector4(0, Mathf.Sin(q1), Mathf.Cos(q1), 0),
            new Vector4(0, 0, 0, 1)
        );
    }

    public static Matrix4x4 TranslateX(float q)
    {
        return new Matrix4x4(
            new Vector4(1, 0, 0, _initialTransform.GetColumn(3)[0] + q),
            new Vector4(0, 1, 0, _initialTransform.GetColumn(3)[1]),
            new Vector4(0, 0, 1, _initialTransform.GetColumn(3)[2]),
            new Vector4(0, 0, 0, 1)
        );
    }

    public static Matrix4x4 TranslateY(float q)
    {
        return new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, q),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        );
    }

    public static Matrix4x4 TranslateZ(float q)
    {
        return new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(0, 0, 1, q),
            new Vector4(0, 0, 0, 1)
        );
    }

    // Start is called before the first frame update
    void Start()
    {

        _initialTransform = Matrix4x4.Rotate(Quaternion.Euler(0.0f, 0.0f, 0.0f));

        


    }

    // Update is called once per frame
    void Update()
    {
        switch (ObjectNumber)
        {
            case 0:
                ApplyMatrix(transform, _initialTransform * GetT0(Q * Mathf.Deg2Rad));
                break;
            case 1:
                ApplyMatrix(transform, _initialTransform * GetT0(Q * Mathf.Deg2Rad));
                break;
            case 2:
                ApplyMatrix(transform, _initialTransform * GetT0(Q * Mathf.Deg2Rad));
                break;
            case 3:
                ApplyMatrix(transform, _initialTransform * GetT0(Q * Mathf.Deg2Rad));
                break;
            case 4:
                ApplyMatrix(transform, _initialTransform * GetT0(Q * Mathf.Deg2Rad));
                break;
            case 5:
                ApplyMatrix(transform, _initialTransform * GetT0(Q * Mathf.Deg2Rad));
                //ApplyTranslation(transform, _initialTransform * TranslateX(Q));
                break;
            
        }


    }
}