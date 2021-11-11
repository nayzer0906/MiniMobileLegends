using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject playerPrefab;
    [SerializeField] private int maxHealth;

    private PlayerMovement _playerMovement;
    private HealthBar _healthBar;
    public CameraFollow cameraFollow;

    private int currentHealth;

    private bool isCooldown = false;

    public void Init()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }
    public void SpawnPlayer()
    {
        currentHealth = maxHealth;
        var player = Instantiate(playerPrefab, transform);
        player.transform.position = new Vector3(-76.9f, 0f, -75.3f);
        player.transform.eulerAngles = new Vector3(0, 45, 0);
        _playerMovement.Init();
        _healthBar = GetComponentInChildren<HealthBar>();
        cameraFollow.target = player.transform;
    }

    public IEnumerator TakeDamage(int damage)
    {
        isCooldown = true;
        currentHealth -= damage;
        _healthBar.UpdateHealth((float)currentHealth / (float)maxHealth);

        yield return new WaitForSeconds(0.5f);
        isCooldown = false;

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public bool IsCooldown()
    {
        return isCooldown;
    }
}
