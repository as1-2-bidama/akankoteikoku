using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marimo : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 screenPoint;
    private Vector3 offset;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private bool isMain = false;    ///Œ@‚Á‚Ä‚¢‚é‚©‚Ç‚¤‚©”»•Ê
    private bool isTaskMain = false;    /// Œ@‚éƒ^ƒXƒN‚ª‚ ‚é‚©‚Ç‚¤‚©”»•Ê
    private bool isPoint = false;
    private float xp = 0.0f;        ///ŒoŒ±’l—Ê
    private float main_timer = 0.0f;    ///
    private int lv = 1;
    [SerializeField] private Sprite lv1_Sprite;
    [SerializeField] private Sprite lv2_Sprite;
    [SerializeField] private Sprite lv3_Sprite;
    [SerializeField] private Sprite point_lv1_Sprite;
    [SerializeField] private Sprite point_lv2_Sprite;
    [SerializeField] private Sprite point_lv3_Sprite;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = lv1_Sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPoint == true)
        {
            Debug.Log("ispoint = true");
            if (lv == 1)
            {
                spriteRenderer.sprite = point_lv1_Sprite;
            }else if (lv == 2)
            {
                spriteRenderer.sprite = point_lv2_Sprite;
            }else if(lv == 3)
            {
                spriteRenderer.sprite = point_lv3_Sprite;
            }
            if (Input.GetKey(KeyCode.M)) {
                isTaskMain = true;
            }
        }else if (isPoint == false)
        {
            if (lv == 1)
            {
                spriteRenderer.sprite = lv1_Sprite;
            }
            else if (lv == 2)
            {
                spriteRenderer.sprite = lv2_Sprite;
            }
            else if (lv == 3)
            {
                spriteRenderer.sprite = lv3_Sprite;
            }
        }
        Main();
        if (xp >= 100)
        {
            lv = 2;
            spriteRenderer.sprite = lv2_Sprite;
            anim.SetBool("Next_lv2", true);

        }
        else if (xp >= 200)
        {
            lv = 3;
            spriteRenderer.sprite = lv3_Sprite;
            anim.SetBool("Next_lv3",true);
        }
    }
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if (isPoint == false)
        {
            isPoint = true;
            Debug.Log("true");
        }
        else if (isPoint ==  true)
        {
            isPoint = false;
            Debug.Log("false");
        }
        Debug.Log("mouse");

    }
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
    }
    void Main()
    {

        if (isTaskMain == true)
        {
            if (isMain == false)
            {
                float main_timer = Time.time;
                isMain = true;
            }

        }
        float main_time = Time.time - main_timer;
        if (lv == 1)
        {
            if (main_time >= 10 && isMain == true)
            {
                isMain = false;
                isTaskMain = false;
                anim.SetBool("Bl_lv1", false);
                xp += 50.0f;
            }
            else if (isMain == true)
            {
                anim.SetBool("Bl_lv1", true);
            }
            else if (isMain == false)
            {
                anim.SetBool("Bl_lv1", false);
                main_timer = Time.time;
            }
        }
        else if (lv == 2)
        {
            if (main_time >= 7 && isMain == true)
            {
                isMain = false;
                isTaskMain = false;
                anim.SetBool("Bl_lv2", false);
                xp += 15.0f;
            }
            else if (isMain == true)
            {
                anim.SetBool("Bl_lv2", true);
            }
            else if (isMain == false)
            {
                anim.SetBool("Bl_lv2", false);
                main_timer = Time.time;
            }
        }
        else if (lv == 3)
        {
            if (main_time >= 5 && isMain == true)
            {
                isMain = false;
                isTaskMain = false;
                anim.SetBool("Bl_lv3", false);
                xp += 15.0f;
            }
            else if (isMain == true)
            {
                anim.SetBool("Bl_lv3", true);
            }
            else if (isMain == false)
            {
                anim.SetBool("Bl_lv3", false);
                main_timer = Time.time;
            }
        }
        ///Debug.Log("Žc‚èŽžŠÔ(•b)" + main_time);
    }
}
