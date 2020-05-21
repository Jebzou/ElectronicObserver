using ElectronicObserver.Data.Battle;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data
{
	public class SortieData : APIWrapper
	{
		public DateTime SortieDate { get; set; }

		public int WorldId;

		public int MapId;

		public List<NodeData> Nodes = new List<NodeData>();

		public FleetManager Fleet;

		public int[] StartRessources;

		public int[] UsedRessources = new int[] { 0, 0, 0, 0, 0 };

		public string Branching
		{
			get
			{
				string branching = "";

				foreach (NodeData node in Nodes)
				{
					if (!string.IsNullOrEmpty(branching)) branching += " - ";
					branching += node.NodeName;
				}

				return branching;
			}
		}

		public string UsedRessourcesString
		{
			get
			{
				StringBuilder usedRes = new StringBuilder();

				usedRes.AppendFormat("Fuel: {0}{1}\n", UsedRessources[0] > 0 ? "+" : string.Empty, UsedRessources[0]);
				usedRes.AppendFormat("Ammo: {0}{1}\n", UsedRessources[1] > 0 ? "+" : string.Empty, UsedRessources[1]);
				usedRes.AppendFormat("Steel: {0}{1}\n", UsedRessources[2] > 0 ? "+" : string.Empty, UsedRessources[2]);
				usedRes.AppendFormat("Bauxite: {0}{1}\n", UsedRessources[3] > 0 ? "+" : string.Empty, UsedRessources[3]);
				usedRes.AppendFormat("Buckets: {0}{1}\n", UsedRessources[4] > 0 ? "+" : string.Empty, UsedRessources[4]);

				return usedRes.ToString();
			}
		}

		public string Map 
		{
			get
			{
				return WorldId + "-" + MapId;
			}
		}

		public string FleetComposition
		{
			get
			{
				string fleet = "";
				if (Fleet is null) return fleet;

				foreach (ShipData ship in Fleet.Fleets[1].MembersInstance)
				{
					if (ship is null) continue;
					fleet += ship.MasterShip.ShipTypeName+ " ";
				}

				if (Fleet.CombinedFlag > 0)
				{
					fleet += "+ ";

					foreach (ShipData ship in Fleet.Fleets[2].MembersInstance)
					{
						if (ship is null) continue;
						fleet += ship.MasterShip.ShipTypeName + " ";
					}
				}

				return fleet;
			}
		}

		public override void LoadFromResponse(string apiname, dynamic data)
		{
			this.SortieDate = DateTime.Now;

			this.WorldId = (int)data.api_maparea_id;
			this.MapId = (int)data.api_mapinfo_no;

			Nodes = new List<NodeData>();

			this.Fleet = KCDatabase.Instance.Fleet.Copy();

			this.StartRessources = new int[] {
				KCDatabase.Instance.Material.Fuel,
				KCDatabase.Instance.Material.Ammo,
				KCDatabase.Instance.Material.Steel,
				KCDatabase.Instance.Material.Bauxite,
				KCDatabase.Instance.Material.InstantRepair
			};
		}

		public void UpdateUsedRessources()
		{
			this.UsedRessources = new int[] {
				KCDatabase.Instance.Material.Fuel - this.StartRessources[0],
				KCDatabase.Instance.Material.Ammo - this.StartRessources[1],
				KCDatabase.Instance.Material.Steel - this.StartRessources[2],
				KCDatabase.Instance.Material.Bauxite - this.StartRessources[3],
				KCDatabase.Instance.Material.InstantRepair - this.StartRessources[4]
			};
		}

		public void LoadData()
		{
			/*if (data is null)
			{
				data = File.ReadAllLines(Directory.GetCurrentDirectory() + "/BattleLog/" + FileName);
			}

			// Parsing
			for (int i = 0; i < data.Length; i++)
			{
				if (data[i].Contains("== Participant =="))
				{
					while (!data[i].Contains("Enemy Fleet"))
					{
						if (data[i].Contains("#"))
							FleetTypes += data[i].Split(' ')[1] + " ";

						i++;
					}
				}
			}*/
		}
	}
}
