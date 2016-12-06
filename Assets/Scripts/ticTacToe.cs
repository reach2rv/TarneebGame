using UnityEngine;
using System.Collections;
using GameSparks.Api.Requests;

public class ticTacToe : MonoBehaviour
{

	//Singleton
	private static ticTacToe _instance;
	public static ticTacToe instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = GameObject.FindObjectOfType<ticTacToe>();
			}
			return _instance;
		}
	}

	//Instance Vars
	//We use the challengeInstanceId in our LogChallengeEventRequest to specify which instance we are taking a turn on.
	public string challengeInstanceId;
	
	//This is our Tic Tac Toe board, we fill this in with information from the cloud code
	public string[] gameBoard;

	//NGUI
	public UISprite[] nGUIButtonImages;
	public TweenAlpha nGUIGamePanel, win, draw, sent;

	//If player 1 we are "x", if its our turn we can place a piece, if we've clicked a square, it's no longer our turn
	public bool isPlayerOne = false, currentPlayerTurn = false, playerClicked = false;

	bool gameOver = false;

	//update our board with information provided from Running Game's game board
	public void GetBoard()
	{
		for (int i = 0; i < gameBoard.Length; i++)
		{
			if (gameBoard[i] == "x")
			{
				nGUIButtonImages[i].spriteName = "cross";
				nGUIButtonImages[i].GetComponent<UIButton>().normalSprite = "cross";
				nGUIButtonImages[i].MarkAsChanged();
			}
			if (gameBoard[i] == "o")
			{
				nGUIButtonImages[i].spriteName = "circle";
				nGUIButtonImages[i].GetComponent<UIButton>().normalSprite = "circle";
				nGUIButtonImages[i].MarkAsChanged();
			}
		}
		nGUIGamePanel.PlayForward();
		win.PlayReverse();
		draw.PlayReverse();
	}

	//Set pieces when a button is pressed. nGUIButtons contains the code to pass one the position
	public void SetPiece(int pos, string playerIcon)
	{
		//If the player has clicked a place and it's not already got an X or an O and the game isn't over
		if (playerClicked && gameBoard[pos] == "" && !gameOver)
		{
			//Just like in the cloud code the position will equal whatever icon we are
			gameBoard[pos] = playerIcon;
			
			//We change the GUI to reflect this 
			if (playerIcon == "x")
			{
				nGUIButtonImages[pos].spriteName = "cross";
				nGUIButtonImages[pos].GetComponent<UIButton>().normalSprite = "cross";
				nGUIButtonImages[pos].MarkAsChanged();
			}
			else
			{
				nGUIButtonImages[pos].spriteName = "circle";
				nGUIButtonImages[pos].GetComponent<UIButton>().normalSprite = "circle";
				nGUIButtonImages[pos].MarkAsChanged();
			}
			
			//Now that we have the position and which Icon was placed, we can update the game state in the cloud
			//We use LogChallengeEventRequest with the challenge Instance Id of this particular game.
			new LogChallengeEventRequest().SetChallengeInstanceId(challengeInstanceId)
				.SetEventKey("takeTurn") //The event we are calling is "takeTurn", we set this up on the GameSparks Portal
				.SetEventAttribute("pos", pos) //takeTurn has an attribute for position called "pos", we supply it with the pos we placed our icon at
				.SetEventAttribute("playerIcon", playerIcon) //takeTurn also has an attribute called "playerIcon, we set to our X or O
				.Send((response) =>
				{
					if (response.HasErrors)
					{

					}
					else
					{
						// If our ChallengeEventRequest was successful we inform the player
						sent.PlayForward();
					}
				});

			//We've made our move so it's no longer our turn
			currentPlayerTurn = false;
			playerClicked = true;
			
			//If we've won inform the player and prevent any further movement
			if (PlayerHasWon(playerIcon))
			{
				win.PlayForward();
				gameOver = true;
			}
			
			//If we've drawn inform the player and prevent any further movement
			if (CheckDraw())
			{
				draw.PlayForward();
				gameOver = true;
			}
		}
	}

	//Check for a winner
	public bool PlayerHasWon(string playerIcon)
	{
		if (gameBoard[0] == playerIcon && gameBoard[1] == playerIcon && gameBoard[2] == playerIcon)
			return true;
		else if (gameBoard[3] == playerIcon && gameBoard[4] == playerIcon && gameBoard[5] == playerIcon)
			return true;
		else if (gameBoard[6] == playerIcon && gameBoard[7] == playerIcon && gameBoard[8] == playerIcon)
			return true;
		else if (gameBoard[0] == playerIcon && gameBoard[3] == playerIcon && gameBoard[6] == playerIcon)
			return true;
		else if (gameBoard[1] == playerIcon && gameBoard[4] == playerIcon && gameBoard[7] == playerIcon)
			return true;
		else if (gameBoard[2] == playerIcon && gameBoard[5] == playerIcon && gameBoard[8] == playerIcon)
			return true;
		else if (gameBoard[0] == playerIcon && gameBoard[4] == playerIcon && gameBoard[8] == playerIcon)
			return true;
		else if (gameBoard[2] == playerIcon && gameBoard[4] == playerIcon && gameBoard[6] == playerIcon)
			return true;
		else
			return false;
	}
	
	//Check for a draw
	public bool CheckDraw()
	{
		for (int i = 0; i < 8; i++)
		{
			if(gameBoard[i]==""){
				return false;
			}
		}
		return true;
	}
	
	//When this is called we reset the game instance to a blank state
	public void ClearInstance()
	{
		for (int i = 0; i < gameBoard.Length; i++)
		{
			nGUIButtonImages[i].spriteName = "empty";
			nGUIButtonImages[i].GetComponent<UIButton>().normalSprite = "empty";
			nGUIButtonImages[i].MarkAsChanged();
		}
		win.PlayReverse();
		draw.PlayReverse();
		sent.PlayReverse();
		isPlayerOne = false;
		currentPlayerTurn = false;
		playerClicked = false;
		gameOver = false;
	}
}