using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CheckPointTests
    {
        private GameObject player;
        private GameObject enemy;
        private CheckPoint newCheckPoint;

        [SetUp]
        public void Setup()
		{
            player = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Player"), new Vector3(0, 0, 0), Quaternion.identity);
            player.GetComponent<Rigidbody>().useGravity = false;

            enemy = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/Enemy"), new Vector3(200, 0, 0), Quaternion.identity);
            enemy.GetComponent<Rigidbody>().useGravity = false;
        }

        [TearDown]
        public void Teardown()
        {
            GameObject.Destroy(player);
            GameObject.Destroy(enemy);
            GameObject.Destroy(newCheckPoint.gameObject);
            CheckPoint.CheckPointsList.Clear();
        }

        [UnityTest]
        public IEnumerator CheckPointIsCreatedProperly()
		{
            GameObject checkPointGameObject = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Prefabs/CheckPoint"), new Vector3(100, 0, 0), Quaternion.identity);
            newCheckPoint = checkPointGameObject.GetComponent<CheckPoint>();
            yield return new WaitForSeconds(0.1f);

            Assert.AreEqual(1, CheckPoint.CheckPointsList.Count, "There should be only 1 checkpoint created.");
            Assert.False(newCheckPoint.Activated, "The created checkpoint should be deactivated.");
        }

        [UnityTest]
        public IEnumerator CheckPointIsActivatedByThePlayer()
		{
            yield return CheckPointIsCreatedProperly();

            player.transform.position = newCheckPoint.transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.True(newCheckPoint.Activated, "The checkpoint should be activated after player enters in it.");
        }

        [UnityTest]
        public IEnumerator PlayerAppearsInTheRightCheckPointAfterDeath()
		{
            yield return CheckPointIsActivatedByThePlayer();

            player.transform.position = enemy.transform.position;
            yield return new WaitForSeconds(0.1f);

            Assert.True(player.transform.position == newCheckPoint.transform.position, "After death, the player should be in the same position as the last activated checkpoint.");
        }
    }
}
