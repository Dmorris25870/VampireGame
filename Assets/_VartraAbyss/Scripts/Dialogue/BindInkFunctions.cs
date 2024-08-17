using Ink.Runtime;
using UnityEngine;
using UnityEngine.AI;

namespace VartraAbyss
{
	public class BindInkFunctions : MonoBehaviour
	{
		[Header("Objects")]
		[SerializeField] private GameObject m_screenTint;
		[SerializeField] private GameObject m_breakableWall; //Wall gating player in cell
		[SerializeField] private GameObject zeroBossDoor; //wall gating player in zero boss room
		[SerializeField] private GameObject finalBossDoor; //wall gating player fromfelix boss room
		[SerializeField] private GameObject letterFromBea; //UI element with image directing player to the final boss

		[Header("Story Npc Characters")]
		[SerializeField] private GameObject BeatrixIntroPrefab;
		[SerializeField] private GameObject FirstFightPrefab;
		[SerializeField] private GameObject FirstPowerPrefab;
		[SerializeField] private GameObject AvoidPrefab;
		[SerializeField] private GameObject PetrPrefab;
		[SerializeField] private GameObject BarkeepPasswordPrefab;
		[SerializeField] private GameObject VictoriaIntroPrefab;
		[SerializeField] private GameObject IntercomFelixPrefab;
		[SerializeField] private GameObject BarkeepMessagePrefab;
		[SerializeField] private GameObject BeaGetsPowersPrefab;
		[SerializeField] private GameObject FelixFinalBattlePrefab;
		[SerializeField] private GameObject AfterZeroPrefab;

		[Header("Extra NPC Characters")]
		[SerializeField] private GameObject VicBeforeBarkeepPrefab;
		[SerializeField] private GameObject TempBeatrixPrefab;
		[SerializeField] private GameObject BasicBarkeepPrefab;
		[SerializeField] private GameObject WaitingBeaPrefab;
		[SerializeField] private GameObject VictoriaNoTalkyPrefab;
		[SerializeField] private GameObject WaitingVicPrefab;
		//[SerializeField] private GameObject Guard01Prefab;
		[SerializeField] private GameObject Citizen01Prefab;

		[SerializeField] private Dialogue_trigger m_playerTrigger;

		[Header("Prefabs")]
		[SerializeField] private GameObject EnemySet01;
        [SerializeField] private GameObject EnemySet02;
        [SerializeField] private GameObject GuardSet01;


        private void Awake()
		{
			m_screenTint.SetActive(false);
			m_breakableWall.GetComponent<NavMeshObstacle>().carving = true;
			m_playerTrigger.GetComponent<Dialogue_trigger>();
			EnemySet02.SetActive(false);
		}
		public void BindExternalFunction(Story story)
		{
			story.BindExternalFunction("ExplosionScreen" , (int number) =>
			{

				if(number <= 1) //if num is 1 turn on curtain
				{
					m_screenTint.SetActive(true);
					//Debug.Log("ExplosionScreenOn");
					m_breakableWall.GetComponent<NavMeshObstacle>().carving = false;
					m_breakableWall.SetActive(false);
				}
				else if(number > 1)//if num is 2 turn off curtain
				{
					m_screenTint.SetActive(false);
					//Debug.Log("ExplosionScreenOff");

				}

			});

			story.BindExternalFunction("ChangeWorld", (int number) =>
			{
				if (number == 1)
				{
					//Add barrel to lab
					EnemySet02.SetActive(true);
					EnemySet01.SetActive(false);
				}

			});

			story.BindExternalFunction("CharacterEvent" , (int number) =>
			{
				if(number == 1) //Intro Bea 
				{
					BeatrixIntroPrefab.SetActive(false);
					ResetPlayerInRange();

				}
				else if(number == 2) //First fight
				{
					FirstFightPrefab.SetActive(false);
					ResetPlayerInRange();
				}
				else if(number == 3) //First power
				{
					FirstPowerPrefab.SetActive(false);
					EventManager.OnBloodProjectileAbilityUnlocked?.Invoke();
					ResetPlayerInRange();
				}
				else if(number == 4) //Turn off Petr and Avoid in Petr story
				{
					AvoidPrefab.SetActive(false);
					EventManager.OnBiteAbilityUnlocked?.Invoke();
					ResetPlayerInRange();
				}
				else if(number == 5) //BarkeepPassword
				{
					BarkeepPasswordPrefab.SetActive(false);
                    BasicBarkeepPrefab.SetActive(true);
                    PetrPrefab.SetActive(false);
					ResetPlayerInRange();
					VictoriaIntroPrefab.SetActive(true);
					VicBeforeBarkeepPrefab.SetActive(false);

				}
				else if(number == 6)//Meet Victoria and spawn temp Beatrix
				{

					TempBeatrixPrefab.SetActive(true);
					VictoriaIntroPrefab.SetActive(false);
					ResetPlayerInRange();


				}
				else if(number == 7) //Intercom felix and Patient Zero fight
				{
					ResetPlayerInRange();
					IntercomFelixPrefab.SetActive(false);//Disable Intercom Felix
					BarkeepMessagePrefab.SetActive(true);//Enable Messenger Barkeep
					BasicBarkeepPrefab.SetActive(false); //Disable Basic barkeep and temp bea
					TempBeatrixPrefab.SetActive(false);
					//Guard01Prefab.SetActive(false);
					FelixFinalBattlePrefab.SetActive(true); //Turn on final boss talk
					AfterZeroPrefab.SetActive(true); //turn on self talk prefab
					GuardSet01.SetActive(false);
					//m_wall.SetActive(false);

				}
				else if(number == 8) //Back to barkeep with letter
				{
					ResetPlayerInRange();
					BarkeepMessagePrefab.SetActive(false);//turn of message barkeep and enable basic barkeep
					BasicBarkeepPrefab.SetActive(true);
					BeaGetsPowersPrefab.SetActive(true); //Spawn BeaGetsPowers and Victoria no dialogue
					VictoriaNoTalkyPrefab.SetActive(true);
					letterFromBea.SetActive(true);

				}
				else if(number == 9) //Found Bea and about to find Felix
				{
					ResetPlayerInRange();
					BeaGetsPowersPrefab.SetActive(false);//Turn off BeaGetsPowers
					VictoriaNoTalkyPrefab.SetActive(false);//Turn off no talky vic
					WaitingBeaPrefab.SetActive(true); //Turn on WaitingBeatrix waiting Victoria
					WaitingVicPrefab.SetActive(true);
				}
				else if(number == 10) //Fight felix
				{
					ResetPlayerInRange();
					//Turn off Final felix battle
					FelixFinalBattlePrefab.SetActive(false);
					//Spawn Felix boss
				}
				else if (number == 11) //turn off after patient zero self talk
				{
					AfterZeroPrefab.SetActive(false);
					zeroBossDoor.SetActive(false);
				}

			});
		}

		public void Unbind(Story story)
		{
			story.UnbindExternalFunction("ExplosionScreen");
			story.UnbindExternalFunction("CharacterEvent");
		}

		public void ResetPlayerInRange()
		{
			m_playerTrigger.playerInRange = false;
		}
	}
}
