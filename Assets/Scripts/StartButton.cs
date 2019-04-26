using UnityEngine;

public class StartButton : MonoBehaviour
{
    public GameObject player;
    private TextMesh text;
    private Animator animator;
    private BoxCollider boxCollider;
    private bool startingLock = false;

    void Start()
    {
        text = GetComponent<TextMesh>();
        animator = player.GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        this.Init();
    }

    void Init()
    {
        text.text = "START";
        boxCollider.enabled = true;
        animator.ResetTrigger("toVr");
        startingLock = false;
    }

    public void Starting()
    {
        if (!startingLock)
        {
            startingLock = true;
            boxCollider.enabled = false;
            text.text = "STARTED...";
            animator.SetTrigger("toVr");
        }
    }

    void Update()
    {
        if (!animator.GetBool("toVr") && !boxCollider.enabled) {
            this.Init();
        }
    }
}
