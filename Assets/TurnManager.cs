using System.Collections;
using UnityEngine;

using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
	[System.Serializable]
	public struct Move
	{
		public TextMeshProUGUI stateDisplay;
		public bool signal;

		[Space]
		public float useCost;

		public void SetState()
		{
			stateDisplay.text = $"{signal.GetHashCode()}";
		}
	}

	public TextMeshProUGUI actionStateDisplay;
	public Slider playerHealth, enemyHealth;
	public Move[] PlayerMoves, EnemyMoves;
	public int moveLimitPerTurn;
	
	[Header("Move Costs")]
	public float playerUsablePoints;
	public float enemeyUsablePoints;
	public float playerUsedPoints, enemyUsedPoints;
	
	[Space]
	public Slider playerCostBar;
	public Slider enemyCostBar;

	[Header("Entity Info")]
	public string playerName;
	public string enemyGroupName;
	public bool playersTurn;

	public int selectedMoves, enemyMoves;
	public int playerNumber, enemyNumber;
	int playerSignalSign;

	float playerCostDifference, enemyCostDifference;

	private GameObject playerCharacter;


	private void OnEnable() {
		actionStateDisplay.text = $"{playerName}'s turn";
		playerCharacter = GameObject.FindGameObjectWithTag("Player");
	}
	
	//Move selection function only usable to the player
	public void SelectMove(int index)
	{
		if(playersTurn)
		{
			playerCostDifference = playerUsablePoints - playerUsedPoints;

			if(PlayerMoves[index].useCost > playerCostDifference)
			{
				//If the signal is set to true despite the move not being usable due to costs, undo the changes the signal made
				if(PlayerMoves[index].signal)
				{
					PlayerMoves[index].signal = !PlayerMoves[index].signal;
					PlayerMoves[index].SetState();
				
					selectedMoves--;
					playerUsedPoints -= PlayerMoves[index].useCost;
					playerNumber -= (int)Mathf.Pow(2, index);
				}
				else //Give a warning signal to the players
					actionStateDisplay.text = "You don't have enough points!";
			}
			else
			{
				//Set the signal to its opposite state and update the UI
				// Reason: Every clck will either set or unset the UI value. Using the NOT operator is faster and cheaper than using conditional statements
				PlayerMoves[index].signal = !PlayerMoves[index].signal;
				PlayerMoves[index].SetState();

				//Set the multiplier to either add or subtract from the player number
				// Reason: The boolean logic is easy to compute using math instead of logic conditions like the ternary operator, not to mention it's functionally similar to 
				// the principles of Negative Number Theory
				playerSignalSign = ((2 * PlayerMoves[index].signal.GetHashCode()) - 1);
				
				selectedMoves += playerSignalSign;
				playerNumber += (int)Mathf.Pow(2, index) * ((2 * PlayerMoves[index].signal.GetHashCode()) - 1);

				playerUsedPoints += PlayerMoves[index].useCost * playerSignalSign;
			}

			playerCostBar.value = playerUsablePoints - playerUsedPoints;
		}
	}

	public void DetermineEnemyMove()
	{
		if(selectedMoves == 0) //If no moves are selected
		{
			actionStateDisplay.text = "Please select at least 1 move!";
			return;
		}

		if(selectedMoves <= moveLimitPerTurn) //If the number of moves selected aren't past the limit, confirm the move execution, and let the enemy start thinking
		{
			playersTurn = false;
			actionStateDisplay.text = $"{enemyGroupName} is thinking...";
			StartCoroutine(EnemyThinkTime());
		}
		else // If the number of moves selected is past the limit, give a warning
			actionStateDisplay.text = $"Only a max of {moveLimitPerTurn} moves per turn!";
	}

	IEnumerator EnemyThinkTime()
	{
		yield return new WaitForSeconds(1); // Delay to give the impression of the enemy thinking
		EnemyMove();

		playersTurn = true;
		actionStateDisplay.text = $"{playerName}'s turn";
	}

	void EnemyMove()
	{
		enemyUsedPoints = enemyMoves = 0;
		int x = 0;
		
		//Reset all enemy move signals upon the next iteration of recursion
		for (int t = 0; t < EnemyMoves.Length; t++)
		{
			EnemyMoves[t].signal = false;
			EnemyMoves[t].SetState();
		}

		//Randomly select a move
		for (int i = 0; i < EnemyMoves.Length; i++)
		{
			x = Random.Range(0, 2);
			EnemyMoves[i].signal = x > 0;
			EnemyMoves[i].SetState();

			enemyCostDifference = enemeyUsablePoints - enemyUsedPoints;

			if(EnemyMoves[i].signal)
			{
				if(EnemyMoves[i].useCost <= enemyCostDifference)
				{
					enemyNumber += (int)Mathf.Pow(2, i);
					
					enemyUsedPoints += EnemyMoves[i].useCost;
					enemyCostBar.value = enemeyUsablePoints - enemyUsedPoints;

					enemyMoves++;
				}
				
				if(enemyMoves >= moveLimitPerTurn)
					break;
			}
		}

		if(enemyMoves == 0) // If the enemy didn't pick a single move, run the cycle again
			EnemyMove();
		else
		{
			if(playerNumber > enemyNumber) // If the player beat the enemy number, deplete enemy health
				enemyHealth.value -= playerNumber;
			
			if(playerNumber < enemyNumber) // If the enemy beat the player number, deplete player health
				playerHealth.value -= enemyNumber;
			
			if(playerNumber == enemyNumber) // If a stalemate happened, deplete both health bars
			{
				enemyHealth.value -= playerNumber;
				playerHealth.value -= enemyNumber;
			}
			
			enemyUsedPoints = enemyNumber = 0; //Reset the enemy point and number

			if(enemyHealth.value <= 0)
            {
				Debug.Log("Player Win");
				SceneManager.LoadScene("Overworld");
            }
			if(playerHealth.value <= 0)
            {
				Debug.Log("Enemy Win");
				SceneManager.LoadScene("Overworld");
				playerCharacter.SetActive(true);
            }
		}
	}
}