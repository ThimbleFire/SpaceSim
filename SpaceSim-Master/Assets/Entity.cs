public class Entity : MonoBehaviour
{
    protected byte Hunger { get; set; } = 255;
    protected byte Water { get; set; } = 255;
    protected byte Happiness { get; set; } = 255;
    protected byte Bladder { get; set; } = 255;
    protected byte Oxygen { get; set; } = 255;
    // Chain is the list of tiles returned by the pathfinder
    protected List<Node> _chain = new List<Node>();
    protected Vector3Int Coordinates { get; set; }
    protected Animator animator
    protected bool Moving { get; set; } = false;
    
    private void Awake() => animator = GetComponent<Animator>();
    protected void UpdateAnimator(Vector3Int dir) {
        if(dir == Vector3Int.zero)
            return;
            
        animator.SetInt("x", _chain.x - Coordinates.x);
        animator.SetInt("y", _chain.y - Coordinates.y);
        animator.SetBool("Moving", Moving);
    }
    protected virtual void Move() { }
    protected virtual void Interact() { }
    protected virtual void Action() {
        // AI stuff goes here    
    }      
}
