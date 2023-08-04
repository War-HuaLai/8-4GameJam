using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ScrollWheel : MonoBehaviour
{
    private Collider2D _coll;
    private Collider2D _groundColl;
    [SerializeField][Range(0,120)] private float WindRoteSpeed = 12f;
    [SerializeField] private float PlayerForce = 10f;
    private Control control;
    public Rigidbody2D Player;
    [SerializeField]Vector2 MouseDir;
    bool isPressed;
    [SerializeField,Tooltip("可以吹的最长时间")] private float _blowCD;
    [SerializeField]private float _blowTimer = 0f;
    [SerializeField]private bool _canBlow = true;
    [SerializeField,Tooltip("碰到地面重置的时间")] private float _groundedCD;
    [SerializeField] private float _maxVelo;
    [SerializeField] bool _onGroundedDetect;
    [SerializeField] private ParticleSystem _wind;

    [SerializeField] private UnityEngine.UI.Image _arrow;

    private void Awake()
    {
        control = new Control();
        _coll = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        _groundColl = GameObject.FindGameObjectWithTag("Ground").GetComponent<Collider2D>();
        control.Player.WindDir.started += Dir;
        control.Player.WindDir.performed += Dir;
        control.Player.WindDir.canceled += Dir;

        control.Player.Force.started += PushForce;
        control.Player.Force.performed += PushForce;
        control.Player.Force.canceled += PushForce;
    }

    public void InputStop()
    {
        control.Disable();
    }

    public void InputStart()
    {
        control.Enable();
    }

    void Update()
    {
        WindingDir();
        DetectGrounded();
    }

    private void FixedUpdate()
    {
        ForcePlayer();
        SetArrow();

    }

    private void DetectGrounded()
    {
        if (_coll.IsTouching(_groundColl))
        {
            if (!_onGroundedDetect)
            {
                Debug.Log("nmsl");
                StartCoroutine(CorGrounded());
            }
        }
    }

    private void SetArrow()
    {
        _arrow.fillAmount = 1 - _blowTimer / _blowCD;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            if (!_onGroundedDetect)
            {
                Debug.Log("nmsl");
                StartCoroutine(CorGrounded());
            }
        }
    }

    void Dir(InputAction.CallbackContext context)
    {
        //if(context.phase == InputActionPhase.Started)
        MouseDir = context.ReadValue<Vector2>();

       
    }
    void PushForce(InputAction.CallbackContext context)
    {
        isPressed=context.ReadValueAsButton();
        Debug.Log(context.ReadValueAsButton());
        if (isPressed && _canBlow)
        {
            AudioManger.Instance.PlayMusic("wind");
            //if (_coll.IsTouching(_groundColl))
            AudioManger.Instance.PlaySFX("jump");
        }
        else if (!isPressed)
            AudioManger.Instance.StopMusic();

    }

    void WindingDir()//风向旋转速度
    {
        if(MouseDir!=null)
        {
            transform.Rotate(0, 0, MouseDir.y / WindRoteSpeed);
        }
    }

    void ForcePlayer()
    {
        if (isPressed)
        {
            // 获取物体的X轴方向向量
            Vector2 forceDirection = transform.right;


            if (_canBlow)
            {
                _wind.transform.rotation = Quaternion.LookRotation(transform.right);
                _wind.Play();
                // 给Player添加力，使其沿着X轴方向飞行
                //_corBlow =  StartCoroutine(CorBlow(forceDirection));
                //Debug.Log("1");

                Player.AddForce(forceDirection * PlayerForce, ForceMode2D.Force);
                var veloX= Mathf.Clamp(Player.velocity.x, -_maxVelo, _maxVelo);
                var veloY= Mathf.Clamp(Player.velocity.y, -_maxVelo, _maxVelo);
                Player.velocity = new Vector2(veloX, veloY);
                _blowTimer += Time.fixedDeltaTime;
                if (_blowTimer >= _blowCD)
                {
                    _canBlow = false;
                    AudioManger.Instance.StopMusic();
                }
            }
        }
    }



    IEnumerator CorGrounded()
    {
        _onGroundedDetect = true;
        yield return new WaitForSeconds(_groundedCD);
        _blowTimer = 0f;
        _canBlow = true;
        _onGroundedDetect = false;
        _arrow.fillAmount = 1;
    }

    #region
    private void OnEnable()
    {
        control.Player.Enable();
    }
    private void OnDisable()
    {
        control.Player.Disable();
    }
    #endregion
}
