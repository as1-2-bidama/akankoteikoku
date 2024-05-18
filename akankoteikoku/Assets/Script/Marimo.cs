using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marimo : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 screenPoint;
    private Vector3 offset;
    private Animator anim;
    private bool isMain = false;    ///掘っているかどうか判別
    private bool isTaskMain = false;    /// 掘るタスクがあるかどうか判別
    private float xp = 0.0f;        ///経験値量
    private float main_timer = 0.0f;    ///
    private int lv = 1;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Main();
        if (xp >= 100)
        {
            lv = 2;
        } else if (xp >= 200)
        {
            lv = 3;
        }
    }
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        ///this.gameObject.SetActive(false);
        isTaskMain = true;
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
                xp += 15.0f;
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
        Debug.Log("残り時間(秒)" + main_time);
    }
}
