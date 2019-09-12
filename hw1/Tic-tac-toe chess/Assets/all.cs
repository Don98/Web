using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class all : MonoBehaviour
{
	int now_turn;
	int[,] state = new int[3,3]{{0,0,0},{0,0,0},{0,0,0}};
	int time = 0;
    void reset()
    {
        now_turn = 1;
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                state[i, j] = 0;
            }
        }
    }
    void Start()
    {
        reset();
    }
    void Update()
    {
		// int result = win_or_not();
    }
	int win_or_not()
    {
		int[] flag = new int[]{1,1,1,1};
		for (int i = 0; i < 3; i++){
			for(int j = 0;j < 2;j++)
				flag[j] = 1;
			for (int j = 1; j < 3; j++){
				if (state [i , j] == 0 || state [i , j] != state[i , 0]){
					flag[0] = 0;
				}
			}
			if (flag[0] == 1)	return state [i , 0];
			for (int j = 1; j < 3; j++){
				if (state [j , i] == 0 || state [j , i] != state[0 , i]){
					flag[1] = 0;
				}
			}
			if (flag[1] == 1)	return state [0 , i];
			if(i > 0){
				if (flag[2] != 0 && state [i , i] != state [i - 1 ,i - 1]){
					flag[2] = 0;
				}
				if (flag[3] != 0 && state [i , 2 - i] != state [i - 1 ,3 - i]){
					flag[3] = 0;
				}
			}
		}
		if (flag[2] == 1 || flag[3] == 1) return state [1 , 1];
		return 0;
    }
	void OnGUI()
    {
        GUI.Box(new Rect(496, 100, 160, 350), "");
        GUIStyle style = new GUIStyle ();
        style.normal.textColor = new Color (46f / 256f, 163f / 256f, 256f / 256f);
        style.fontSize = 32;
        if (GUI.Button (new Rect (525, 380, 100, 50), "reset")) {
            reset ();
        }
        int result = win_or_not ();
        if (result == 1) {
            GUI.Label (new Rect (530, 300, 100, 50), "√ win!!!", style);
        } else if (result == 2) {
            GUI.Label (new Rect (530, 300, 100, 50), "X win!!!", style);
        }
        int flag = 0;
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (state [i, j] == 0)
                    flag = 1;
            }
        }
        if (flag == 0) {
            GUI.Label (new Rect (550, 300, 100, 50), "平局", style);
        }
        for (int i = 0; i < 3; i++) {
            for (int j = 0; j < 3; j++) {
                if (state [i, j] == 1) {
                    GUI.Button (new Rect (i * 50+500, j * 50+100, 50, 50), "√");
                }
                if (state [i, j] == 2) {
                    GUI.Button (new Rect (i * 50+500, j * 50+100, 50, 50), "X");
                }
                if (GUI.Button (new Rect (i * 50+500, j * 50+100, 50, 50), "")) {
                    if (result == 0) {
                        if (now_turn == 1)
                            state [i, j] = 1;
                        else
                            state [i, j] = 2;
                        now_turn = -now_turn;
                    }
                }
            }
        }
    }
}
