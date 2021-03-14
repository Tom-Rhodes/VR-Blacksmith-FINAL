using UnityEngine;
using System.Collections.Generic;

public class TreeGen : MonoBehaviour
{
    public int width, length;
    public List<GameObject> Trees;
    public int treeNum;
    private GameObject pos;
    private Quaternion rotation;
    void Awake()
    {
        pos = new GameObject();
        for (int i = 0; i<treeNum; i++)
        {
            pos.transform.position = randVec();
            rotation = Quaternion.AngleAxis(Random.Range(-180, 181), Vector3.up);
            Instantiate(Trees[Random.Range(1,4)], pos.transform.position, rotation, Trees[0].transform);
            foreach(MeshRenderer treeGen in Trees[0].GetComponentsInChildren<MeshRenderer>())
            {
                float xyRange = Random.Range(0.7F, 1);
                treeGen.transform.localScale = new Vector3(xyRange, Random.Range(0.7F, 1), xyRange);
            }
        }
    }    

    Vector3 randVec()
    {
        Vector3 vec = new Vector3(Random.Range(-30, 31), 0, Random.Range(-30, 31));
        while((vec.x>-10 && vec.x<10) && (vec.z > -10 && vec.z < 10))
        {
            vec = new Vector3(Random.Range(-30, 31), 0, Random.Range(-30, 31));
        }
        for(int i = 15; 30 >= i; i += 5)
        {
            if((vec.x>i || vec.x <-i) || (vec.z > i || vec.z < -i))
            {
                vec.y += 1;
            }
        }
        return vec;
    }
}
