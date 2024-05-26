using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.AI;
using UnityEngine.Animations.Rigging;
using Photon.Pun;


public class Skills : MonoBehaviour 
{
    public TwoBoneIKConstraint handIK;
    public GameObject rifle;

    public GameObject bomba;
    public float range = 5;
    bool degis;
    Vector3 bombSpawnHere;
    GameObject[] enemies;
    public float bombRadius;
    public float mortaRange;
    public float mortaRadius;

    public GameObject bombArea;
    public GameObject mortarArea;

    Vector3 mortarAreaSpawnHere;

    public TextMeshProUGUI bombText;
  //  public TextMeshProUGUI bandajText;
  //  public TextMeshProUGUI mortarText;

    public float bombaSayisi;
   // public float mortarBeklemeSüresi;

    public float bandajSayisi=2;

    private Animator asker_bomba_tut;
    private Animator asker_bomba_com;
    private bool bombaTut;
    private bool bomba_At;

    public GameObject BombexploEffect;
    public GameObject mortarEffect;

    public float MortarHitTime = 2f;

    public AudioClip grenadeExplo;
    public AudioClip mortarExplo;

    public mortarUi mortarUI;
    public healtExtUi healthforce;

    GameObject[] enemieBase;
    void Start()
    {
        asker_bomba_tut = GetComponent<Animator>();
        mortarUI.StartCooldown(MortarHitTime);
        healthforce.StartBandagePack(bandajSayisi);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            mortarUI.Cooldown(MortarHitTime);
            healthforce.BandagePack(bandajSayisi);
        }

        if (GetComponent<PhotonView>().IsMine)
        {
            useSkill();
        }
        
      
    }

    public void useSkill()
    {
        //bomba atma
       // if (GetComponent<PhotonView>().IsMine)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                degis = !degis;
                rifle.SetActive(!degis);
                bombArea.SetActive(degis);
                asker_bomba_tut.SetBool("tut", degis);
                asker_bomba_tut.SetBool("comelTut", degis);
                if (degis)
                {
                    handIK.weight = 0;
                }
                else
                {
                    handIK.weight = 1;
                }

            }
            if (degis)
            {
                // bomb();
                GetComponent<PhotonView>().RPC("bomb", RpcTarget.All);
            }

            //heal kontrol
            if (bandajSayisi > 0)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    //healing();
                    GetComponent<PhotonView>().RPC("healing", RpcTarget.All);
                    bandajSayisi -= 1;
                }
            }



            //mortar sayi kontrol
            if (MortarHitTime > 0)
            {
                if (Input.GetKeyDown(KeyCode.R))
                {

                    MortarHitTime -= 1;
                    //mortar();
                    GetComponent<PhotonView>().RPC("mortar", RpcTarget.All);

                }
            }

        }
    }
    [PunRPC]
    void bomb()
    {
        bombText.text = bombaSayisi.ToString();
        if (bombaSayisi > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (Vector3.Distance(transform.position, hit.point) <= range)
                    {

                        bombaSayisi -= 1.0f;
                        
                       
                        Debug.Log("hit bomb " + hit.collider.name);
                        bombSpawnHere = hit.point;
                        Invoke("spawnBomb", 1);
                        asker_bomba_tut.SetTrigger("at");
                        asker_bomba_tut.SetTrigger("comelAt");


                    }


                }
            }
        }
       
        
    }

    [PunRPC]
    // player healing
    void healing()
    {
        if (GetComponent<PlayerStats>().currentHealth < 100)
            GetComponent<PlayerStats>().currentHealth += 20;
       // bandajSayisi -= 1.0f;
       // bandajText.text = bandajSayisi.ToString();
    }
    [PunRPC]
    // mortaring enemies bot
    void mortar()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                if (Vector3.Distance(transform.position, hit.point) <= mortaRange)
                {
                    Debug.Log("hit mortar");
                    
                    mortarAreaSpawnHere = hit.point;
                    Invoke("mortarAreaSpawn", 0);


                    

                    enemies = GameObject.FindGameObjectsWithTag("enemy");
                    foreach (GameObject enemy in enemies)
                    {
                        if (Vector3.Distance(hit.point, enemy.transform.position) <= mortaRadius)
                        {
                           // enemy.GetComponent<EnemyStats>().TakeDamage(500);
                        enemy.GetComponent<PhotonView>().RPC("TakeDamage",RpcTarget.All,500);
                        }
                    }

                    enemieBase = GameObject.FindGameObjectsWithTag("enemyBase");
                    foreach (GameObject ene in enemieBase)
                    {
                        if (Vector3.Distance(hit.point, ene.transform.position) <= mortaRadius)
                        {
                        // ene.GetComponent<enemyspawnbaseStat>().TakeDamage(500);
                        ene.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, 500);
                    }
                    }

                }
            }
        
        
    }


    [PunRPC]
    // bomb object spawning
    void spawnBomb()
    {
        
        //bombayý olusturma
        GameObject spawn = PhotonNetwork.Instantiate("bomba", bombSpawnHere, Quaternion.identity);
        //
        GetComponent<AudioSource>().PlayOneShot(grenadeExplo); 
        PhotonNetwork.Instantiate("Particle System",spawn.transform.position, Quaternion.identity);

        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemy in enemies)
        {
            if (Vector3.Distance(spawn.transform.position, enemy.transform.position) <= bombRadius)
            {
                //enemy.GetComponent<EnemyStats>().TakeDamage(100);
                enemy.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, 100);
            }
        }

        enemieBase = GameObject.FindGameObjectsWithTag("enemyBase");
        foreach (GameObject ene in enemieBase)
        {
            if (Vector3.Distance(spawn.transform.position, ene.transform.position) <= bombRadius)
            {
                // ene.GetComponent<enemyspawnbaseStat>().TakeDamage(100);
                ene.GetComponent<PhotonView>().RPC("TakeDamage", RpcTarget.All, 100);
            }
        }



    }
    [PunRPC]
    void mortarAreaSpawn()
    {
        
        GameObject spawnMortarAreaPrefab = PhotonNetwork.Instantiate("mortar_area_nw",mortarAreaSpawnHere ,Quaternion.identity);
       PhotonNetwork.Instantiate("mortarParticleSystem", spawnMortarAreaPrefab.transform.position, spawnMortarAreaPrefab.transform.rotation);
      

        GetComponent<AudioSource>().PlayOneShot(mortarExplo);
        // spawnMortarAreaPrefab.transform.Rotate(new Vector3(90,0,0));

        spawnMortarAreaPrefab.transform.localScale = new Vector3(mortaRange, mortaRange, mortaRange);

       PhotonNetwork.Destroy(spawnMortarAreaPrefab);
    }

    
}