using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingManager : MonoBehaviour
{
    
    [Header("Extension settings")]
    public Transform Gun;
    public Transform Bullet;
    public float shootingSpeed = 500f;
    public float cooldown = 1f;
    private float _tempTime;
    public KeyCode shootButton = KeyCode.E;
    public float bulletDestroyTime = 5f;

    [Header("Settings for demo")]
    public float rotSpeed = 5f;
    public bool OffOn = false;


    void RotateObject () {
        if (!OffOn) return;
        transform.Rotate(new Vector3(0, Input.GetAxisRaw("Horizontal") * rotSpeed, 0));
    }

    private void Start() {
        _tempTime = cooldown;
    }

    private void Update() {
        RotateObject();
        shootTimer();
        Shoot();
    }

    void shootTimer() {
        if (Gun == null) return;
        if (_tempTime > 0) _tempTime -= Time.deltaTime; return;   
    }

    void Shoot() {
        if (_tempTime >= 0) return;
        if(Input.GetKeyDown(shootButton)) {
            Transform _tempBullet = Instantiate(Bullet, transform.position, transform.rotation);
            _tempBullet.GetComponent<Rigidbody>().AddForce(transform.right * shootingSpeed);
            Destroy(_tempBullet.gameObject, bulletDestroyTime);
            _tempTime = cooldown;
        }
    }



}
