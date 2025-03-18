using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public static NoteManager s_this;
    public static List<BaseNote> s_Notes;

    void Awake()
    {
        if (s_this = null) { s_this = this; }
        s_Notes = new List<BaseNote>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
