using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject player;
    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;
    public GameObject bullett;
    public Text ACount;
    public int ammoCount;
    public int maxAC = 6;
    private int y = 0;
    int z = 0;
    bool x = true;
    private float fixedDeltaTime;
    bool c = false;
    public int damage = 35;
    int reloadSpeed = 2;
    private float startTime;
    private float Firerate = 10;
    private float TimeBeforeShooting;
    public int a = 0;
    public AudioSource shooting1;
    public AudioSource shooting2;
    public AudioSource shooting3;
    public AudioSource shooting4;
    public AudioSource shootingRifle1;
    public AudioSource shootingRifle2;
    int s = 0;
    string minutes = 0.ToString();
    string seconds = 0.ToString();
    float t = 0;
    private float resetTime;
    public GameObject grenade;
    bool Grenades = false;
    int gCount = 0;
    bool nades = false;
    public GameObject tag;
    bool gTag = false;
    private int cc = 4;
    public GameObject gPic;
    bool isFinished = false;
    public GameObject reloading;
    public CameraShake cameraShake;
    private void Start()
    {

        
        Time.timeScale = 0f;
        ammoCount = 6;
        this.fixedDeltaTime = Time.fixedDeltaTime;
        maxAC = 6;
        TimeBeforeShooting = 1 / Firerate;
        a = 0;
        minutes = 0.ToString();
        seconds = 0.ToString();
 

    }

    void Update()
    {
        t += Time.deltaTime;
        minutes = ((int)t / 60).ToString();
        seconds = (t % 60).ToString("f1");
        if (Grenades == false) {
            if (ammoCount == 0)
            {
                reloading.SetActive(true);
                ACount.text = "   : " + "\n" + "\n" + "Timer " + minutes + ":" + seconds;
            }
            else
            {
                reloading.SetActive(false);
                ACount.text =  "   : " + ammoCount + "\n" + "\n" + "Timer " + minutes + ":" + seconds;
            }
        }
        if (Grenades == true)
        {
            if (ammoCount == 0)
            {
                reloading.SetActive(true);
                ACount.text = "   : " + "\n" + "    : " + gCount + "\n" + "Timer " + minutes + ":" + seconds;
            }
            else
            {
                reloading.SetActive(false);
                ACount.text = "   : " + ammoCount + "\n" + "    : " + gCount + "\n" + "Timer " + minutes + ":" + seconds;
            }
        }
        if (z == 0)
        {
            
                Time.timeScale = 1f;
                x = false;
                
                z = z + 1;
                Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
                time();
                //startTime = 0;
                //seconds = 0.ToString();
                //minutes = 0.ToString();

            
        }
        if (x == false && c == false && Time.timeScale != 0)
        {
            if (a == 0)
            {
                //ked stlacime lmb tak vyvolame funkciu Shoot
                if (Input.GetMouseButtonDown(0))
                {
                    if (ammoCount > 0)
                    {
                        Shoot();
                        StartCoroutine(cameraShake.Shake(.15f,.001f));

                        ammoCount = ammoCount - 1;
                        if (s == 0)
                        {
                            shooting1.Play();
                            s += 1;
                        }
                        if (s == 1)
                        {
                            shooting2.Play();
                            s += 1;
                        }
                        if (s == 2)
                        {
                            shooting3.Play();
                            s += 1;
                        }
                        if (s == 3)
                        {
                            shooting4.Play();
                            s = 0;
                        }
                    }
                    if (ammoCount == 0 && y == 0)
                    {
                        y = 1;
                    }
                    if (y == 1)
                    {
                        StartCoroutine(Wait());
                        //StartCoroutine(Timer());
                        y = 2;
                    }

                }
            }
            if (a == 1)
            {
                //ked stlacime lmb tak vyvolame funkciu Shoot

                if (Input.GetMouseButton(0))
                {
                    if (TimeBeforeShooting <= 0f)
                    {
                        if (ammoCount > 0)
                        {
                            Shoot();
                            ammoCount = ammoCount - 1;
                            if (s == 0)
                            {
                                shootingRifle1.Play();
                                s += 1;
                            }
                            if (s == 1)
                            {
                                shootingRifle2.Play();
                                s -= 1;
                            }
                        }
                        if (ammoCount == 0 && y == 0)
                        {
                            y = 1;
                        }
                        if (y == 1)
                        {
                            StartCoroutine(Wait());
                            y = 2;
                        }
                        TimeBeforeShooting = 1 / Firerate;
                    }
                    else
                    {
                        TimeBeforeShooting -= Time.deltaTime;
                    }
                }
                else
                {
                    TimeBeforeShooting = 0f;
                }
            }
            if (a == 2)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (ammoCount > 0)
                    {
                        ShootShotgun();

                        ammoCount = ammoCount - 1;
                        if (s == 0)
                        {
                            shooting1.Play();
                            s += 1;
                        }
                        if (s == 1)
                        {
                            shooting2.Play();
                            s += 1;
                        }
                        if (s == 2)
                        {
                            shooting3.Play();
                            s += 1;
                        }
                        if (s == 3)
                        {
                            shooting4.Play();
                            s = 0;
                        }
                    }
                    if (ammoCount == 0 && y == 0)
                    {
                        y = 1;
                    }
                    if (y == 1)
                    {
                        StartCoroutine(Wait());
                        y = 2;
                    }

                }
            }
            if (a == 3)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (ammoCount > 0)
                    {
                        ShootSniper();

                        ammoCount = ammoCount - 1;
                        if (s == 0)
                        {
                            shooting1.Play();
                            s += 1;
                        }
                        if (s == 1)
                        {
                            shooting2.Play();
                            s += 1;
                        }
                        if (s == 2)
                        {
                            shooting3.Play();
                            s += 1;
                        }
                        if (s == 3)
                        {
                            shooting4.Play();
                            s = 0;
                        }
                    }
                    if (ammoCount == 0 && y == 0)
                    {
                        y = 1;
                    }
                    if (y == 1)
                    {
                        StartCoroutine(Wait());
                        y = 2;
                    }

                }
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Wait());
                ammoCount = 0;
            }

        }
        if (x == false && Grenades == true && gCount > 0) 
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                Instantiate(grenade, transform.position, transform.rotation);
                gCount--;
                if(gTag == true)
                {
                    tag.SetActive(false);
                    gTag = false;
                }
            }
        }
        if (Grenades == true && nades == true)
        {
            StartCoroutine(cd(cc));
        }
    }

    void Shoot()
    {
        //Vytvorime bullet na poziciu zbrane
        Quaternion als = firePoint.rotation;

        Instantiate(bullett, firePoint.position, als);
        bum();
    }
    void ShootSniper()
    {
        //Vytvorime bullet na poziciu zbrane
        Quaternion als = firePoint.rotation;

        Instantiate(bullett, firePoint.position, als);
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject Bullet in bullets)
        {
            Bullet bullet = Bullet.GetComponent<Bullet>();
            bullet.SniperYes();
        }
        bum();
    }
    void ShootShotgun()
    {
        Quaternion als = firePoint.rotation;
        Quaternion als1 = firePoint2.rotation;
        Quaternion als2 = firePoint3.rotation;

        Instantiate(bullett, firePoint.position, als);
        Instantiate(bullett, firePoint2.position, als1);
        Instantiate(bullett, firePoint3.position, als2);
        bum();
    }
    public void upgradeDMG(int upDMG)
    {
        damage = damage + upDMG;
    }
    void bum()
    {
        //TEN KTO VIDI TENTO KOD VIDI ASI HODINU PRACE!!!!!!!!!!!!!!!!!!
        GameObject[] bullets = GameObject.FindGameObjectsWithTag("Bullet");
        foreach (GameObject Bullet in bullets)
        {
            Bullet bullet = Bullet.GetComponent<Bullet>();
            bullet.DMG(damage);
        }
    }


    public void ACUpgrade(int ACU)
    {
        maxAC = maxAC + ACU;
    }
    public void reloadSpeedd(int RS)
    {
        reloadSpeed = reloadSpeed - RS;
    }
    IEnumerator Wait()
    {
        c = true;
        yield return new WaitForSeconds(reloadSpeed);
        ammoCount = maxAC;
        y = 0;
        c = false;
    }
    public void time()
    {
        startTime = Time.time;
    }
    public void reset(int reset)
    {
        if(reset == 1)
        {
            resetTime = Time.timeSinceLevelLoad;
            reset = 0;
        }
    }
    public void Automatic(int xx)
    {
        a = xx;
    }
    public void Bem()
    {
        Grenades = true;
        nades = true;
        gCount = 1;
        gTag = true;
        gPic.SetActive(true);
    }
    IEnumerator cd(int time)
    {
    nades = false;
    Debug.Log(time);
    yield return new WaitForSeconds(time);
    nades = true;
    gCount++;
    }
   
    public void Finished(bool finish)
    {
        isFinished = finish;
    }
    public void gCounter()
    {
        cc = 2;
    }
}
