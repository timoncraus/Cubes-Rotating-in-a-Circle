using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class E : MonoBehaviour
{
    // public Transform target;
    private Transform Player;

    public List<E> cubesMassive;
    public List<Transform> crossingCubes;
    public List<int> twoCoords;

    private List<Transform> massiveForChildren;
    private Transform[] massive;

    private Vector3[] saveMassive;
    private Vector3[] saveMassive2;
    private Material Material;
    private Material myMaterial;
    private bool move = false;
    private bool noOneIsMoving;
    private bool goodDistance;
    private int howManyAlmoustHere = 0;
    private int shift = 0;
    private int shiftAfter = 0;
    private int index;
    private int index2;
    private int someIndex;
    private bool myMaterialOn = true;
    private bool k = true;

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
    public bool doesItMove()
    {
        return move;
    }
    public bool hasGoodDistance()
    {
        return goodDistance;
    }
    public void setSettings(Transform player1, Material material1)
    {
        Player = player1;
        Material = material1;
    }

    void Start()
    {

        myMaterial = gameObject.GetComponent<MeshRenderer>().material;

        massiveForChildren = GetComponentsInChildren<Transform>().ToList();
        massiveForChildren.Remove(transform);

        saveMassive = new Vector3[massiveForChildren.Count + crossingCubes.Count];
        massive = new Transform[massiveForChildren.Count + crossingCubes.Count];

        for (int i = 0; i < massiveForChildren.Count + crossingCubes.Count; i++)
        {
            for (int j = 0; j < crossingCubes.Count; j++)
            {

                if (i == twoCoords[j * 2] && crossingCubes[j] != null)
                {
                    massive[i] = crossingCubes[shiftAfter];
                    shiftAfter += 1;
                    k = false;
                    break;
                }
            }

            if (k)
            {
                massive[i] = massiveForChildren[i + shiftAfter];
                k = true;
            }

        }
    }

    void Update()
    {
        //for (int i = 0; i < massive.Length; i++)
        //{
        //    Debug.Log(massive[i]);
        //}

        goodDistance = Vector3.Distance(Player.position, transform.position) <= transform.localScale.x / 2;
        k = false;
        for (int i = 0; i < cubesMassive.Count; i++)
        {
            k |= cubesMassive[i].hasGoodDistance();
        }
            
        if (goodDistance && !k)
        {
            gameObject.GetComponent<MeshRenderer>().material = Material;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = myMaterial;
        }



        if ((Input.GetKeyDown(KeyCode.Q) || (Input.GetKeyDown(KeyCode.E))) && goodDistance && !k)
        {
            noOneIsMoving = true;
            for (int i = 0; i < cubesMassive.Count; i++)
            {
                if (cubesMassive[i] && cubesMassive[i].doesItMove())
                {
                    noOneIsMoving = false;
                    break;
                }
            }
            if (!move && noOneIsMoving)
            {
                move = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
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
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    shift -= 1;
                    if (shift < 0)
                    {
                        shift = massive.Length - 1;
                    }

                    saveMassive[0] = massive[massive.Length - 1].position;
                    for (int i = 1; i < massive.Length; i++)
                    {
                        saveMassive[i] = massive[i - 1].position;
                    }
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
                someIndex = 0;

                for (int i = 0; i < twoCoords.Count / 2; i++)
                {
                    if (twoCoords[1 + someIndex * 2] - cubesMassive[someIndex].getShift() < 0)
                    { index2 = cubesMassive[someIndex].getMassive().Length + twoCoords[1 + someIndex * 2] - cubesMassive[someIndex].getShift(); }
                    else { index2 = twoCoords[1 + someIndex * 2] - cubesMassive[someIndex].getShift(); }

                    if (twoCoords[0 + someIndex * 2] - shift < 0) { index = massive.Length + twoCoords[0 + someIndex * 2] - shift; }
                    else { index = twoCoords[0 + someIndex * 2] - shift; }

                    cubesMassive[someIndex].changeMassive(index2, massive[index]);
                    someIndex += 1;
                }
            }
        }
    }
}