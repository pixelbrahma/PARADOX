using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform[] _Points;
    public Transform[] _BulletPos;
    public GameObject Projectile;
    public float _Speed;
    public float bulletSpeed;
    GameObject Player;
    Vector3 PlayerPos;

    public Material[] materials;
    public bool vulnerable;

    public float HP = 100;
    bool Dead;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(Enemy());
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && !Dead)
        {
            Dead = true;
            GetComponent<Renderer>().material.color = Color.grey;
            StopCoroutine("Enemy");
        }
    }

    IEnumerator Enemy()
    {
        while (true)
        {

            //First Attack
            while (transform.position.x != _Points[0].position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(_Points[0].position.x, transform.position.y), _Speed);
                yield return null;
            }
            yield return new WaitForSeconds(0.5f);
            int i = 0;
            while (i < Random.Range(3, 6))
            {
                GameObject Bullet = (GameObject)Instantiate(Projectile, _BulletPos[Random.Range(0, 2)].position, Quaternion.Euler(0, 0, 90));
                Bullet.GetComponent<Rigidbody>().velocity = Vector2.left * bulletSpeed;
                i++;
                yield return new WaitForSeconds(0.7f);
            }

            //Second Attack
            GetComponent<Rigidbody>().isKinematic = true;
            while (transform.position != _Points[1].position)
            {
                transform.position = Vector2.MoveTowards(transform.position, _Points[1].position, _Speed);
                yield return null;
            }

            PlayerPos = Player.transform.position;
            yield return new WaitForSeconds(1f);
            GetComponent<Rigidbody>().isKinematic = false;
            while (transform.position.x != PlayerPos.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(PlayerPos.x, transform.position.y), _Speed);
                yield return null;
            }

            //this.tag == "Untagged";
            GetComponent<Renderer>().material = materials[1];
            vulnerable = true;
            yield return new WaitForSeconds(2);
            //this.tag == "Vulnerable";
            GetComponent<Renderer>().material = materials[0];
            vulnerable = false;

            //Third Attack
            Transform temp;
            if (transform.position.x > Player.transform.position.x)
                temp = _Points[0];
            else
                temp = _Points[2];

            while (transform.position.x != temp.position.x)
            {
                transform.position = Vector2.MoveTowards(transform.position, new Vector2(temp.position.x, transform.position.y), _Speed);
                yield return null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && vulnerable)
        {
            HP -= 10;
            vulnerable = false;
            GetComponent<Renderer>().material = materials[1];
        }
    }
}