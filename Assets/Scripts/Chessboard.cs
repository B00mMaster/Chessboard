using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessboard : MonoBehaviour
{
    public GameObject Object;
   
    
    public float time;
    
   

    GameObject[] white;
    GameObject[] black;
    public bool[] ocupedSpace;

    private void Start()
    {
        white = GameObject.FindGameObjectsWithTag("blancas");
        black = GameObject.FindGameObjectsWithTag("negras");
        ocupedSpace = new bool[white.Length+black.Length];
            

        StartCoroutine(Instantiate());

        
       
    }

    IEnumerator Instantiate()
    {
        while(FreeSpace())
        {
            int place;
            do
            {
                place= Random.Range(0, white.Length + black.Length);
            }
            while (ocupedSpace[place]);
            Vector3 newPos = Vector3.zero;

            if (place < white.Length)
            {
                newPos= white[place].transform.position;
            }
            else
            {
                newPos=black[place-white.Length].transform.position;
            }
            Instantiate(Object, newPos, Quaternion.identity);

            ocupedSpace[place] = true;
            yield return new WaitForSeconds(time);
        }
    }

        bool FreeSpace()
    {
        foreach(bool ocuped in ocupedSpace)
        {
            if (!ocuped)
                return true;

        }
        return false;
    }
}


