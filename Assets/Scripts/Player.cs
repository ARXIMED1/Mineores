using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int rt;
    private Rigidbody rb;
    public float speed = 0.01f;
    public float jumpForse = 200f;
    public Animator animator;
    public GameObject ground;
    public bool IsGround;
    public bool MoveUp;
    public bool MoveDown;
    public bool MoveLeft;
    public bool MoveRight;

    public GameObject furnace;
    public GameObject furnaceplace;
    public int furint = 0;

    public GameObject furnancemenu;
    public Inventory a;
    public GameObject craftmenu;
    public GameObject intbut;
    public GameObject AK;

    public float fulltime;
    public float timeLeft = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        IsGround = false;
        AK.SetActive(false);
        craftmenu.SetActive(true);
        furnancemenu.SetActive(false);
        intbut.SetActive(true);
    }
    //Проверка стоит ли на земле
    void OnCollisionEnter(Collision ground)
    {
        IsGround = true;
    }
    //else Проверка стоит ли на земле
    void OnCollisionExit(Collision ground)
    {
        IsGround = false;
    }


    void Update()
    {
        // Движение вперед
        if (Input.GetKeyDown(KeyCode.W))
            MoveUp = true;
        if (Input.GetKeyUp(KeyCode.W))
            MoveUp = false;
        if (MoveUp)
        {
            transform.Translate(-speed * 3, 0, speed * 2);
            animator.SetBool("Walking", true);
        }
        if (MoveUp == false)
        {
            animator.SetBool("Walking", false);
        }
        // Движение назад
        if (Input.GetKeyDown(KeyCode.S))
            MoveDown = true;
        if (Input.GetKeyUp(KeyCode.S))
            MoveDown = false;
        if (MoveDown)
        {
            transform.Translate(0, 0, -speed);
        }
        // Движение вправо
        if (Input.GetKeyDown(KeyCode.D))
            MoveRight = true;
        if (Input.GetKeyUp(KeyCode.D))
            MoveRight = false;
        if (MoveRight)
        {
            transform.Translate(speed, 0, 0);
            animator.SetBool("Right", true);
        }
        if (MoveRight == false)
        {
            animator.SetBool("Right", false);
        }
        // Движение влево
        if (Input.GetKeyDown(KeyCode.A))
            MoveLeft = true;
        if (Input.GetKeyUp(KeyCode.A))
            MoveLeft = false;
        if (MoveLeft)
        {
            transform.Translate(-speed, 0, 0);
            animator.SetBool("Left", true);
        }
        if (MoveLeft == false)
        {
            animator.SetBool("Left", false);
        }
        // Прыжок
        if (Input.GetKeyDown(KeyCode.Space) && IsGround)
        {
            rb.AddForce(0, jumpForse, 0);
        }
        if (IsGround == true)
        {
            animator.SetBool("Jumping", false);
            AK.SetActive(true);
        }
        if (IsGround == false)
        {
            animator.SetBool("Jumping", true);
            AK.SetActive(false);
        }
        // Спаун печки
        if (Input.GetKeyDown(KeyCode.F) && furint >= 1)
        {
            Instantiate(furnace, furnaceplace.transform.position, furnaceplace.transform.rotation);
            furint -= 1;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Woodtxt.Woodint += 10;
            Orestxt.Oresint += 10;
            IronBar.Iron += 10;
            Mushroomstxt.Mushroomsint += 10;
        }
    }
    // Включение интерфейса при подходе к печке
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Furnace"))
        {
            //furbool = true;
            furnancemenu.SetActive(true);
            a.inventor.SetActive(true);
            craftmenu.SetActive(false);
            intbut.SetActive(false);
        }
    }
    // Выключение интерфейса при отходе от печки
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Furnace"))
        {
            //furbool = false;
            furnancemenu.SetActive(false);
            a.inventor.SetActive(false);
            craftmenu.SetActive(true);
            intbut.SetActive(true);
        }
    }
    // Крафт печки
    public void Craftf()
    {
        if (Orestxt.Oresint >= 5 && Woodtxt.Woodint >= 2)
        {
            furint += 1;
            Orestxt.Oresint -= 5;
            Woodtxt.Woodint -= 2;
        }
    }
    // Крафт калаша
    public void Craftak()
    {
        if (IronBar.Iron >= 10 && Woodtxt.Woodint >= 5)
        {
            AK.SetActive(true);
            IronBar.Iron -= 10;
            Woodtxt.Woodint -= 5;
        }
    }
    // Крафт пуль
    public void Craftbul()
    {
        if (IronBar.Iron >= 5 && Mushroomstxt.Mushroomsint >= 10)
        {
            Gun.bulletint += 10;
            IronBar.Iron -= 5;
            Mushroomstxt.Mushroomsint -= 10;
        }
    }

    /*public IEnumerator StartTimer()
    {
        timeLeft = fulltime;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            yield return null;
        }
    }*/

    public void Craftbar()
    {
        //StartCoroutine(StartTimer());
        /*while (timeLeft > 0)
        {
            rt += 1;
        }*/
        timeLeft = fulltime;
        while (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            //yield return null;
        }
        if (Orestxt.Oresint >= 1 && Woodtxt.Woodint >= 5)
        {
            IronBar.Iron += 1;
            Orestxt.Oresint -= 1;
            Woodtxt.Woodint -= 5;
        }
    }
}
