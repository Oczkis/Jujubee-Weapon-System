using UnityEngine;

public class Player : MonoBehaviour
{
    private InventoryManager _inventoryManager;
    private PlayerManager _playerManager;
    private Animator _animator;

    void Awake() => _animator = GetComponent<Animator>();

    void Start()
    {
        GameManager.Instance.TryGetManager(out _inventoryManager);
        GameManager.Instance.TryGetManager(out _playerManager);

        _inventoryManager.OnSlotSelected += PlayWeaponSwitchAnimation;

        _playerManager.SetLocalPlayer(this);
    }

    void OnDestroy()
    {
        _inventoryManager.OnSlotSelected -= PlayWeaponSwitchAnimation;
    }
    public void PlayAnimation(string animationName) => _animator.Play(animationName);

    private void PlayWeaponSwitchAnimation(Slot slot) => PlayAnimation("Weapon Switch");
}
