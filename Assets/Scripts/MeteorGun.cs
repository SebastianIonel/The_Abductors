using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorGun : MonoBehaviour
{
    [SerializeField] private float laserDuration = 3.0f;
    [SerializeField] private GameObject laserBeam;
    [SerializeField] private GameObject explosion;
    [SerializeField] private ObjectClickHandler selectAsteroid;
    [SerializeField] private Score score;

    public bool isFiring;

    public void Shoot(bool scan, float distance, GameObject astroid)
    {
        if (!isFiring) {
            StartCoroutine(FireLaser(scan, distance, astroid));
        }
    }

    private IEnumerator FireLaser(bool scan, float distance, GameObject astroid)
    {
        isFiring = true;
        laserBeam.SetActive(true);

        var particleSystem = laserBeam.GetComponent<ParticleSystem>().main;
        particleSystem.startSpeed = distance * 4;

        if (scan) {
            particleSystem.startColor = Color.green;
            particleSystem.startSize = 0.5f;
        } else {
            particleSystem.startColor = Color.red;
            particleSystem.startSize = 1.5f;
        }

        // Wait for the laser duration
        yield return new WaitForSeconds(laserDuration);

        if (!scan) {
            if (selectAsteroid.displayAsteroid.GetType().Equals(astroid.GetType())) {
                selectAsteroid.HideAsteroidUI();
            }
            Instantiate(explosion, astroid.transform.position, Quaternion.identity);

            AsteroidData asteroidData = astroid.GetComponent<AsteroidData>();
            score.AddPoints(asteroidData.points);
            Destroy(astroid);
            PlayerPrefs.SetInt(astroid.name + "Destroyed", 1);
            PlayerPrefs.SetInt("ScoreChimie", score.score);
        }

        // Disable the laser
        laserBeam.SetActive(false);
        isFiring = false;
    }
}
