using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FaceDatabaseSO")]
public class FaceDatabaseSO : ScriptableObject
{
    public Sprite[] faces;
    public Sprite[] hats;
    public Sprite[] eyes;
    public Sprite[] ears;
    public Sprite[] noses;
    public Sprite[] mouths;
}
