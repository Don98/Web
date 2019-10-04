using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class Judge{
		public CoastController fromCoast;
		public CoastController toCoast;
		public BoatController boat;
		public Judge(CoastController fromCoast1,CoastController toCoast1,BoatController boat1){
			fromCoast = fromCoast1;
			toCoast = toCoast1;
			boat = boat1;
		}
		public void update(CoastController fromCoast1,CoastController toCoast1,BoatController boat1){
			fromCoast = fromCoast1;
			toCoast = toCoast1;
			boat = boat1;
		}
		public int Check()
		{   // 0->not finish, 1->lose, 2->win
			int from_priest = 0;
			int from_devil = 0;
			int to_priest = 0;
			int to_devil = 0;

			int[] fromCount = fromCoast.GetobjectsNumber();
			from_priest += fromCount[0];
			from_devil += fromCount[1];

			int[] toCount = toCoast.GetobjectsNumber();
			to_priest += toCount[0];
			to_devil += toCount[1];

			if (to_priest + to_devil == 6)      // win
				return 2;

			int[] boatCount = boat.GetobjectsNumber();
			if (boat.get_State() == -1)
			{   // boat at toCoast
				to_priest += boatCount[0];
				to_devil += boatCount[1];
			}
			else
			{   // boat at fromCoast
				from_priest += boatCount[0];
				from_devil += boatCount[1];
			}
			if (from_priest < from_devil && from_priest > 0)
			{       // lose
				return 1;
			}
			if (to_priest < to_devil && to_priest > 0)
			{
				return 1;
			}
			return 0;           // not finish
		}
	}