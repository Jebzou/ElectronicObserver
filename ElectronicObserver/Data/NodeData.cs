using ElectronicObserver.Data.Battle;
using ElectronicObserver.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data
{
	public class NodeData : APIWrapper
	{
		public NodeType NodeType;

		public int NodeId;

		public int WorldId;

		public int MapId;

		public BattleResultData BattleResult;

		public BattleData BattleData;

		public string Info => BattleResult != null ? BattleResult.Rank : "";

		public string Reward
		{
			get
			{
				string reward = "";

				// --- Drops
				if (BattleResult != null)
				{
					if (BattleResult.DroppedShipID > 0 && KCDatabase.Instance.MasterShips.ContainsKey(BattleResult.DroppedShipID))
					{
						reward += KCDatabase.Instance.MasterShips[BattleResult.DroppedShipID].NameWithClass;
					}

					if (BattleResult.DroppedItemID > 0 && KCDatabase.Instance.MasterUseItems.ContainsKey(BattleResult.DroppedItemID))
					{
						if (!string.IsNullOrEmpty(reward)) reward += " + ";
						reward += KCDatabase.Instance.MasterUseItems[BattleResult.DroppedItemID].Name;
					}
				}

				// --- Map gain and lose todo
				if (NodeType == NodeType.Ressources)
				{

				}

				if (NodeType == NodeType.Maelstrom)
				{

				}

				return reward;
			}
		}

		public string AbyssalFleet
		{
			get
			{
				string fleet = "";

				if (BattleData != null)
				{
					foreach (ShipDataMaster ship in BattleData.Initial.EnemyMembersInstance)
					{
						if (ship is null) continue;
						fleet += ship.ShipTypeName + " ";
					}

					if (BattleData.IsEnemyCombined)
					{
						fleet += "+ ";

						foreach (ShipDataMaster ship in BattleData.Initial.EnemyMembersEscortInstance)
						{
							if (ship is null) continue;
							fleet += ship.ShipTypeName + " ";
						}
					}
				}

				return fleet;
			}
		}

		public string NodeName => FormMain.Instance.Translator.GetMapNodesOptimized(WorldId, MapId, NodeId);

		public override void LoadFromResponse(string apiname, dynamic data)
		{
			switch (apiname)
			{
				case "api_req_map/start":
					this.NodeId = (int)data.api_no;
					this.WorldId = (int)data.api_maparea_id;
					this.MapId = (int)data.api_mapinfo_no;
					break;
				case "api_req_map/next":
					this.NodeId = (int)data.api_no;
					this.WorldId = (int)data.api_maparea_id;
					this.MapId = (int)data.api_mapinfo_no;
					break;
			}

			NodeType = GetNodeType(data);
		}

		public NodeType GetNodeType(dynamic data)
		{
			if (data.api_select_route()) return NodeType.RouteSelection;
			if ((int)data.api_event_id == 6 || (int)data.api_event_id == 1) return NodeType.EmptyNode;
			if (data.api_itemget()) return NodeType.Ressources;
			if (data.api_happening()) return NodeType.Maelstrom;
			if ((int)data.api_event_id == 7 && (int)data.api_event_kind == 0) return NodeType.AerialReconnaissance;
			if (data.api_itemget_eo_comment()) return NodeType.Anchor;
			if ((int)data.api_event_id == 9) return NodeType.Transport;
			if ((int)data.api_event_id == 10) return NodeType.AnchorageRepair;
			if ((int)data.api_event_kind > 0 && new int[] { 4, 5, 7 }.Contains((int)data.api_event_id)) return NodeType.Battle;

			return NodeType.Default;
		}

		public string NodeTypeString
		{
			get
			{
				switch (this.NodeType)
				{
					case NodeType.Default: return "";
					case NodeType.RouteSelection: return "Route selection";
					case NodeType.EmptyNode: return "Empty";
					case NodeType.Ressources: return "Ressource";
					case NodeType.Maelstrom: return "Maelstrom";
					case NodeType.AerialReconnaissance: return "Aerial reconnaissance";
					case NodeType.Anchor: return "Anchor";
					case NodeType.Transport: return "Transport";
					case NodeType.AnchorageRepair: return "Anchorage repair";
					case NodeType.Battle: return "Battle";
					default: return "";
				}
			}
		}
	}

	public enum NodeType : byte
	{
		Default = 0, // --- api_event_id = 0 Does not exists
		RouteSelection = 1, // --- api_select_route !== "undefined"
		EmptyNode = 2, // --- api_event_id === 6 || api_event_id === 1
		Ressources = 3, // --- api_itemget !== "undefined"
		Maelstrom = 4, // --- api_happening !== "undefined"
		AerialReconnaissance = 5, // --- api_event_id === 7 && api_event_kind === 0
		Anchor = 6, // --- api_itemget_eo_comment !== "undefined"
		Transport = 7, // --- api_event_id === 9
		AnchorageRepair = 8, // --- nodeData.api_event_id === 10
		Battle = 9, // --- api_event_kind {1,2,3,4,5,6,7,8} && api_event_id {4,5,7}
	}
}
