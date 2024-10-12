using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nerfGun : MonoBehaviour
{
    public int damage;
    public double fireRate;
    public Transform firePoint;
    public GameObject bullet;
    private Camera mainCam;
    private Vector3 mousePos;
    private bool canFire;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rotZ);
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > (1 / fireRate))
            {
                canFire = true;
                timer = 0;
            }
        }
        if (Input.GetMouseButton(0) && canFire)
        {
            canFire = false;
            Instantiate(bullet, firePoint.position, Quaternion.identity);
        }
    }
}
