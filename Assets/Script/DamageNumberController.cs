using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    private void Awake()
    {
        instance = this;
    }
    public DamageNumber damageToSpawn;
    public Transform numberCanvas;
    private List<DamageNumber> numbersPool = new List<DamageNumber>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnDamage(float damageAmount, Vector3 damageLocation)
    {
        DamageNumber newDamageNumber = GetFromPool();
        int round = Mathf.RoundToInt(damageAmount);
        newDamageNumber.transform.position = damageLocation;
        newDamageNumber.setUp(round);
        newDamageNumber.gameObject.SetActive(true);
    }
    private DamageNumber GetFromPool()
    {
        DamageNumber numberToOutPut;
        if (numbersPool.Count == 0)
        {
            numberToOutPut = Instantiate(damageToSpawn, numberCanvas);
        }
        else
        {
            numberToOutPut = numbersPool[0];
            numbersPool.RemoveAt(0);
        }
        return numberToOutPut;
    }
    public void PlaceInNumbersPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);
        numbersPool.Add(numberToPlace);
    }
}
