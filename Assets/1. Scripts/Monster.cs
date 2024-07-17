using System.Xml.Serialization;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float monsterHP = 30f;
    public float monsterDamaged = 2f;
    public float monsterExp = 3;

    private float moveTime = 0;
    private float turnTime = 0;
    private bool isDie = false;

    public float moveSpeed = 3f;
    public GameObject[] itemObj;

    private Animator monsterAnim;

    void Start()
    {
        monsterAnim = GetComponent<Animator>();
    }

    void Update()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        if (isDie) return;

        moveTime += Time.deltaTime;

        if (moveTime <= turnTime)
        {
            this.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            turnTime = Random.RandomRange(1, 5);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDie) return;

        if (collision.gameObject.tag == "Player")
        {
            monsterAnim.SetTrigger("Attack");
            GameManager.Instance.playerStat.hp -= monsterDamaged;
        }

        if (collision.gameObject.tag == "Attack")
        {
            monsterAnim.SetTrigger("Damaged");
            monsterHP -= collision.gameObject.GetComponent<Attack>().attackDamage;

            if (monsterHP <= 0)
            {
                MonsterDie();
            }
        }
    }

    private void MonsterDie()
    {
        isDie = true;
        monsterAnim.SetTrigger("Die");
        GameManager.Instance.playerStat.exp += monsterExp;

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 1.5f);
    }

    private void OnDestroy()
    {
        int itemRandom = Random.Range(0, itemObj.Length);
        if (itemRandom < itemObj.Length)
        {
            Instantiate(itemObj[itemRandom], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }
}
