using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public List<Question> Questions { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Questions= new List<Question>();
    }
}
