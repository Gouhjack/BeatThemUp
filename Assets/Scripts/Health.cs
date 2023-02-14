using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 100;
    [SerializeField] Animator _animator;
    [SerializeField] private GameObject _record;
    [SerializeField] private GameObject _tape;
    [SerializeField] private IntVariable _enemyScore;
    [SerializeField] private int _score;
    private bool isDead;

    private int MAX_HEALTH = 100;

    private void Start()
    {
        isDead = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
             //Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }

        if ( health <= 0 && isDead == false)
        {

            StartCoroutine(coroutine());

            isDead = true;
            
            _animator.SetBool("isDead", true);

            
            


        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        Debug.Log(MAX_HEALTH);
        this.health -= amount;

        if (health <= 0)
        {
            
            
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 8; i++)
        {
            yield return new WaitForSeconds(0.15f);
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            yield return new WaitForSeconds(0.15f);
            GetComponentInChildren<SpriteRenderer>().enabled = true;
        }
        Destroy(gameObject);
        _enemyScore.m_value += _score;
        DropItem();
    }

    private void DropItem()
    {
        Vector3 position = transform.position;
        GameObject record = Instantiate(_record, position, Quaternion.identity);
        GameObject tape = Instantiate(_tape, position, Quaternion.identity);
        record.SetActive(true);
        tape.SetActive(true);
        Destroy(record, 5f);
        Destroy(tape, 5f);
    }

    private void Die()
   {
       
       
       Debug.Log("I am Dead!");
       
       Destroy(gameObject);
   }
}
