using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public ParticleSystem hit;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject player;
    public int maxHealth = 100;
    public int currentHealth;
    public Slider slider;
    public GameObject dark;
    public GameObject black;
    Vector2 movement;
    bool stopped = false;
    private void Start()
    {
        currentHealth = maxHealth;
        slider.value = maxHealth;
        slider.maxValue = maxHealth;
    }
    

    private void Update()
    {
        //movement  
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        slider.maxValue = maxHealth;
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0)
        {
            dark.SetActive(true);
            stopped = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0 && stopped == true)
        {
            stopped = false;
            dark.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Continue()
    {
        dark.SetActive(false);
        Time.timeScale = 1;
    }
    public void Exit()
    {
        Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
        gun.reset(1);
        Counter counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();
        counter.Kills(1);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    void FixedUpdate()
    {
        //movement
        Vector2 direction = movement.normalized;
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
    }
    public void addHP(int HP)
    {
        if(maxHealth>=(HP+currentHealth)){
            currentHealth += HP;
            slider.value = currentHealth;
        }
    }
    public void TakeDamagePlayer(int damage)
    {

        currentHealth -= damage;
        slider.value = currentHealth;
        Instantiate(hit,transform.position, transform.rotation);

        if (currentHealth <= 0)
        {
            Gun gun = GameObject.FindGameObjectWithTag("Gun").GetComponent<Gun>();
            gun.reset(1);
   
            Counter counter = GameObject.FindGameObjectWithTag("Counter").GetComponent<Counter>();
            counter.Kills(1);
            black.SetActive(true);
            Time.timeScale = 0;
            

        }
    }
    public void upgradeMS(float msadd)
    {
        moveSpeed = moveSpeed + msadd;
    }
    public void upgradeHP (int moreHP)
    {
        maxHealth += moreHP;
    }

    public IEnumerator TemporarySpeed()
    {
        moveSpeed += 2.5f;
        yield return new WaitForSeconds(1);
        moveSpeed -= 2.5f;
    }
  
}
