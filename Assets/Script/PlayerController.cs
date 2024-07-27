using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
    }

    public int maxWeapons;
    public List<Weapon> unassignedWeapons, assignedWeapons;
    [HideInInspector]
    public List<Weapon> fullyLevelWeapons = new List<Weapon>();
    //public Weapon activeWeapon;
    public float moveSpeed;
    public Animator anim;
    public float pickUpRange;
    // Start is called before the first frame update
    void Start()
    {
        AddWeapon(Random.Range(0, unassignedWeapons.Count));   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveInput = new Vector3(0f, 0f, 0f);
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        if (moveInput != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void AddWeapon(int weaponNumber)
    {
        if (weaponNumber < unassignedWeapons.Count)
        {
            assignedWeapons.Add(unassignedWeapons[weaponNumber]);
            unassignedWeapons[weaponNumber].gameObject.SetActive(true);
            unassignedWeapons.RemoveAt(weaponNumber);
        }
    }
    public void AddWeapon(Weapon weapponToAdd)
    {
        assignedWeapons.Add(weapponToAdd);
        weapponToAdd.gameObject.SetActive(true);
        unassignedWeapons.Remove(weapponToAdd);
    }
}
