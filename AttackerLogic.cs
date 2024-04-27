using UnityEngine;

public class AttackerLogic : MonoBehaviour
{
    public GameObject projectilePrefab;
    public AudioClip shootingSound;
    public float firingDistance = 10f;
    public float movementSpeed = 5f;
    public float projectileSpawnDistance = 1f;
    public float fireRate = 5f;

    private GameObject currentTarget;
    private AudioSource audioSource;
    private float nextFireTime = 0f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ChooseNearestTarget(); // Choisit la cible la plus proche au début
    }

    void Update()
    {
        // Choisir une nouvelle cible si l'actuelle est nulle ou détruite
        if (currentTarget == null || !currentTarget.activeSelf)
        {
            ChooseNearestTarget();
            if (currentTarget == null) return;
        }

        // Orienter le vaisseau vers la cible
        OrientTowardsTarget();

        // Se déplacer vers la cible si elle est dans la ligne de mire
        if (IsFacingTarget() && Vector3.Distance(transform.position, currentTarget.transform.position) > firingDistance)
        {
            MoveTowardsTarget();
        }

        // Tirer si c'est le moment et si on est à la bonne distance
        if (IsWithinFiringDistance() && Time.time >= nextFireTime)
        {
            ShootTarget();
            nextFireTime = Time.time + fireRate;
        }
    }

    void OrientTowardsTarget()
    {
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * movementSpeed);
    }

    bool IsFacingTarget()
    {
        Vector3 targetDirection = currentTarget.transform.position - transform.position;
        return Vector3.Angle(transform.forward, targetDirection) < 10.0f; // Le vaisseau est considéré comme face à la cible si l'angle est inférieur à 10 degrés
    }

    bool IsWithinFiringDistance()
    {
        return Vector3.Distance(transform.position, currentTarget.transform.position) <= firingDistance;
    }

    void MoveTowardsTarget()
    {
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.transform.position, step);
    }

    void ShootTarget()
    {
        Vector3 projectileSpawnPoint = transform.position + transform.forward * projectileSpawnDistance;
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint, transform.rotation);
        Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>());
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * 10f;

        if (audioSource && shootingSound)
        {
            audioSource.PlayOneShot(shootingSound);
        }

        // Réinitialisez la cible actuelle pour en chercher une nouvelle
        currentTarget = null;
    }

    void ChooseNearestTarget()
    {
        GameObject[] possibleTargets = GameObject.FindGameObjectsWithTag("Target");
        GameObject nearestTarget = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject target in possibleTargets)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            if (distanceToTarget < minDistance)
            {
                nearestTarget = target;
                minDistance = distanceToTarget;
            }
        }

        currentTarget = nearestTarget;
    }
}
