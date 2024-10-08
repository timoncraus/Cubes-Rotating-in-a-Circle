using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E3 : MonoBehaviour
{
    // public Transform target;
    public E3 cubes2;
    public KeyCode key;


    public List<Transform> crossingCubes;
    public List<int> twoCoords;

    private List<Transform> massiveForChildren;
    private Transform[] massive;

    private Vector3[] saveMassive;
    private Vector3[] saveMassive2;
    private bool move = false;
    private int howManyAlmoustHere = 0;
    private int shift = 0;
    private int shiftAfter = 0;
    private int index;
    private int index2;
    private int IndexPasteCrossCubes;

    public Transform[] getMassive()
    {
        return massive;
    }
    public void changeMassive(int someIndex, Transform changing)
    {
        massive[someIndex] = changing;
    }
    public int getShift()
    {
        return shift;
    }
    public bool getMove()
    {
        return move;
    }


    void Start()
    {
        massiveForChildren = GetComponentsInChildren<Transform>().ToList();
        massiveForChildren.Remove(transform);

        saveMassive = new Vector3[massiveForChildren.Count + crossingCubes.Count];
        massive = new Transform[massiveForChildren.Count + crossingCubes.Count];
        if (crossingCubes.Count != 0)
        {
            IndexPasteCrossCubes = twoCoords[0];
        }
        else
        {
            IndexPasteCrossCubes = -1;
        }

        for (int i = 0; i < massiveForChildren.Count + crossingCubes.Count; i++)
        {
            if (i != IndexPasteCrossCubes)
            {
                massive[i] = massiveForChildren[i - shiftAfter];
            }
            else
            {
                if (crossingCubes.Count != 0)
                {
                    massive[i] = crossingCubes[shiftAfter];
                    shiftAfter += 1;
                }
            }
        }
    }

    void Update()
    {
        //Debug.Log(shift);
        if (Input.GetKeyDown(key))
        {
            if (!move && !cubes2.getMove())
            {
                move = true;
                shift += 1;
                if (shift == massive.Length)
                {
                    shift = 0;
                }

                saveMassive[massive.Length - 1] = massive[0].position;
                for (int i = 0; i < massive.Length - 1; i++)
                {
                    saveMassive[i] = massive[i + 1].position;
                }
            }
            // transform.RotateAround(pivot.position, Vector3.up, 10 * Time.deltaTime);
        }

        if (move)
        {
            howManyAlmoustHere = 0;
            for (int i = 0; i < massive.Length; i++)
            {
                var target = saveMassive[i];
                var cube = massive[i];
                if (Vector3.Distance(cube.position, target) > 0.01f)
                {
                    cube.position += (target - cube.position).normalized * 10 * Time.deltaTime;
                }
                else
                {
                    howManyAlmoustHere += 1;
                }
            }
            if (howManyAlmoustHere == massive.Length)
            {
                move = false;

                //for (int i = 0; i < twoCoords.Count / 2; i++)
                //{
                if (twoCoords[1] - cubes2.getShift() < 0) { index2 = cubes2.getMassive().Length + 1 - cubes2.getShift(); }
                else { index2 = twoCoords[1] - cubes2.getShift(); }

                if (twoCoords[0] - shift < 0) { index = massive.Length + 1 - shift; }
                else { index = twoCoords[0] - shift; }


                cubes2.changeMassive(index2, massive[index]);
                Debug.Log(massive[index]);
                Debug.Log(index);
                Debug.Log(shift);
                //}
            }
        }
    }
}