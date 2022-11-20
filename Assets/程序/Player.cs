using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Player : MonoBehaviour
{
    public int Jie;
    public List<GameObject> ST = new List<GameObject>();
    public GameObject STYZ;
    public float speed = 0.1f;
    public float ZL;
    public float ZLIANG;

    Rigidbody2D rb2d;
    GameObject _player;
    int _w;
    int _s;
    int _a;
    int _d;
    bool _isMove = true;
    float moveCD = 0.5f;
    List<BoxCollider2D> listco2d = new List<BoxCollider2D>();
    List<GameObject> _ST = new List<GameObject>();
    RaycastHit2D rayw;
    RaycastHit2D rays;
    RaycastHit2D raya;
    RaycastHit2D rayd;
    GameObject objw;
    GameObject objs;
    GameObject obja;
    GameObject objd;
    // Start is called before the first frame update
    void Start()
    {
        _player = this.gameObject;
        for (int i = 0; i < Jie; i++)
        {
            Chuangjian(-1 * i);
        }
        ChuangjianPengzhaung();
    }

    // Update is called once per frame
    void Update()
    {
        _w = ((int)Input.GetAxisRaw("W"));
        _s = ((int)Input.GetAxisRaw("S"));
        _a = ((int)Input.GetAxisRaw("A"));
        _d = ((int)Input.GetAxisRaw("D"));
        SheXian();
        if (_w != 0)
        {
            if (_isMove)
            {
                Debug.Log("w");
                //射线判断周围是否有苹果，有苹果采用另一套移动方案
                if (rayw.collider != null)//如果发生了碰撞
                {
                    objw = rayw.collider.gameObject;
                    Debug.Log(objw.name + "  " + "w");

                    if (objw.CompareTag("地面"))
                    {
                        return;
                    }
                    else if (objw.CompareTag("苹果"))
                    {
                        //启用第二套移动方案
                        //吃掉苹果
                        _isMove = false;
                        if (rb2d != null)
                        {
                        Destroy(rb2d);
                        }
                        Destroy(objw.gameObject);
                        //在苹果处生成头
                        
                        var go = Instantiate(STYZ, ST[ST.Count-1].transform.position, Quaternion.identity, transform);
                        ST.Add(go);
                        Jie++;
                        Move(0, 1, 0);
                        Move1();
                        //在原有的基础上生成新的身体
                        //删除原来的身体
                        //重新生成碰撞箱
                        return;
                    }
                    else if (objw.CompareTag("Player"))
                    {
                        return;
                    }
                }
                else
                {
                    //关闭移动
                    _isMove = false;
                    if (rb2d != null)
                    {
                        Destroy(rb2d);
                    }
                    //移动，向目标点移动
                    //后面的身体向上一节身体的坐标移动
                    Move(0, 1, 0);
                    Move1();
                    return;
                }
            }
            return;
        }
        if (_s != 0)
        {
            if (_isMove)
            {
                Debug.Log("s");
                //射线判断周围是否有苹果，有苹果采用另一套移动方案
                if (rays.collider != null)//如果发生了碰撞
                {
                    objs = rays.collider.gameObject;
                    Debug.Log(objs.name + "  " + "s");

                    if (objs.CompareTag("地面"))
                    {
                        return;
                    }
                    else if (objs.CompareTag("苹果"))
                    {
                        //启用第二套移动方案
                        //吃掉苹果
                        _isMove = false;
                        if (rb2d != null)
                        {
                        Destroy(rb2d);
                        }
                        Destroy(objs.gameObject);
                        //在苹果处生成头
                        
                        var go = Instantiate(STYZ, ST[ST.Count-1].transform.position, Quaternion.identity, transform);
                        ST.Add(go);
                        Jie++;
                        Move(0, -1, 0);
                        Move1();
                        //在原有的基础上生成新的身体
                        //删除原来的身体
                        //重新生成碰撞箱
                        return;
                    }
                    else if (objs.CompareTag("Player"))
                    {
                        return;
                    }
                }
                else
                {
                    //关闭移动
                    _isMove = false;
                    if (rb2d != null)
                    {
                        Destroy(rb2d);
                    }
                    //移动，向目标点移动
                    //后面的身体向上一节身体的坐标移动
                    Move(0, -1, 0);
                    Move1();
                    return;
                }
            }
            return;
        }
        if (_a != 0)
        {
            if (_isMove)
            {
                Debug.Log("a");
                //射线判断周围是否有苹果，有苹果采用另一套移动方案
                if (raya.collider != null)//如果发生了碰撞
                {
                    obja = raya.collider.gameObject;
                    Debug.Log(obja.name + "  " + "a");

                    if (obja.CompareTag("地面"))
                    {
                        return;
                    }
                    else if (obja.CompareTag("苹果"))
                    {
                        //启用第二套移动方案
                        //吃掉苹果
                        _isMove = false;
                        if (rb2d != null)
                        {
                        Destroy(rb2d);
                        }
                        Destroy(obja.gameObject);
                        //在苹果处生成头
                        
                        var go = Instantiate(STYZ, ST[ST.Count-1].transform.position, Quaternion.identity, transform);
                        ST.Add(go);
                        Jie++;
                        Move(-1,0, 0);
                        Move1();
                        //在原有的基础上生成新的身体
                        //删除原来的身体
                        //重新生成碰撞箱
                        return;
                    }
                    else if (obja.CompareTag("Player"))
                    {
                        return;
                    }
                }
                else
                {
                    //关闭移动
                    _isMove = false;
                    if (rb2d != null)
                    {
                        Destroy(rb2d);
                    }
                    //移动，向目标点移动
                    //后面的身体向上一节身体的坐标移动
                    Move(-1,0, 0);
                    Move1();
                    return;
                }
            }
            return;
        }
        if (_d != 0)
        {
            if (_isMove)
            {
                Debug.Log("d");
                //射线判断周围是否有苹果，有苹果采用另一套移动方案
                if (rayd.collider != null)//如果发生了碰撞
                {
                    objd = rayd.collider.gameObject;
                    Debug.Log(objd.name + "  " + "d");

                    if (objd.CompareTag("地面"))
                    {
                        return;
                    }
                    else if (objd.CompareTag("苹果"))
                    {
                        //启用第二套移动方案
                        //吃掉苹果
                        _isMove = false;
                        if (rb2d != null)
                        {
                        Destroy(rb2d);
                        }
                        Destroy(objd.gameObject);
                        //在苹果处生成头
                        
                        var go = Instantiate(STYZ, ST[ST.Count-1].transform.position, Quaternion.identity, transform);
                        ST.Add(go);
                        Jie++;
                        Move(1,0, 0);
                        Move1();
                        //在原有的基础上生成新的身体
                        //删除原来的身体
                        //重新生成碰撞箱
                        return;
                    }
                    else if (objd.CompareTag("Player"))
                    {
                        return;
                    }
                }
                else
                {
                    //关闭移动
                    _isMove = false;
                    if (rb2d != null)
                    {
                        Destroy(rb2d);
                    }
                    //移动，向目标点移动
                    //后面的身体向上一节身体的坐标移动
                    Move(1,0, 0);
                    Move1();
                    return;
                }
            }
            return;
        }
    }
    void Chuangjian(int i)
    {
        var go = Instantiate(STYZ, new Vector3(i, 0, 0) + _player.transform.position, Quaternion.identity, transform);
        ST.Add(go);
    }
    void Chuangjian()
    {
        for (int i = 0; i < ST.Count - 1; i++)
        {
            var go = Instantiate(STYZ, ST[i].transform.position, Quaternion.identity, transform);
            _ST.Add(go);
        }
    }
    void SheXian()
    {
        Ray2D ray1 = new Ray2D(new Vector3(0.7f, 0, 0) + ST[0].transform.position, Vector2.right);
        Debug.DrawRay(ray1.origin, ray1.direction, Color.blue);
        rayd = Physics2D.Raycast(ray1.origin, ray1.direction, 0.5f);
        Ray2D ray2 = new Ray2D(new Vector3(-0.7f, 0, 0) + ST[0].transform.position, Vector2.left);
        raya = Physics2D.Raycast(ray2.origin, ray2.direction, 0.5f);
        Debug.DrawRay(ray2.origin, ray2.direction, Color.green);
        Ray2D ray3 = new Ray2D(new Vector3(0, 0.7f, 0) + ST[0].transform.position, Vector2.up);
        rayw = Physics2D.Raycast(ray3.origin, ray3.direction, 0.5f);
        Debug.DrawRay(ray3.origin, ray3.direction, Color.black);
        Ray2D ray4 = new Ray2D(new Vector3(0, -0.7f, 0) + ST[0].transform.position, Vector2.down);
        rays = Physics2D.Raycast(ray4.origin, ray4.direction, 0.5f);
        Debug.DrawRay(ray4.origin, ray4.direction, Color.red);
    }
    void Move(float x, float y, int i)
    {
        ST[i].transform.DOMove(new Vector3(x, y, 0) + ST[i].transform.position, speed);
    }
    IEnumerator kaiqiMove(float i)
    {
        yield return new WaitForSeconds(i);
        _isMove = true;
        StopAllCoroutines();
    }
    IEnumerator Chuangjianpz(float i)
    {
        yield return new WaitForSeconds(i);
        if (_isMove == false)
            ChuangjianPengzhaung();
    }
    void ChuangjianPengzhaung()
    {
        rb2d = gameObject.AddComponent<Rigidbody2D>();
        rb2d.mass = ZLIANG;
        rb2d.gravityScale = ZL;
        rb2d.freezeRotation = true;
        if (listco2d.Count != 0)
        {
            for (int i = 0; i < ST.Count; i++)
            {
                if(i!=listco2d.Count)
                Destroy(listco2d[i]);
            }
            listco2d.Clear();
        }
        if (_ST.Count != 0)
        {
            for (int i = 0; i < _ST.Count; i++)
            {
                if(i!=_ST.Count)
                Destroy(_ST[i]);
            }
            _ST.Clear();
        }
        for (int i = 0; i < ST.Count; i++)
        {
            BoxCollider2D bc2d = gameObject.AddComponent<BoxCollider2D>();
            listco2d.Add(bc2d);
            bc2d.offset = ST[i].transform.position - transform.position;
            bc2d.size = new Vector2(1, 1);
        }
    }
    void Move1()
    {
        for (int i = 1; i < ST.Count; i++)
        {
            float _x = ST[i - 1].transform.position.x - ST[i].transform.position.x;
            float _y = ST[i - 1].transform.position.y - ST[i].transform.position.y;
            Move(_x, _y, i);
        }
        //创建新的身体部分当诱饵
        //旧的尾巴隐藏
        Chuangjian();
        //删除碰撞体
        //删除刚体
        //移动完成时每个身体的位置创建一个碰撞体
        //创建刚体
        //删除诱饵
        StartCoroutine(kaiqiMove(moveCD));
        StartCoroutine(Chuangjianpz(speed + 0.1f));
    }

}
