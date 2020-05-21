using ElectronicObserver.Data;
using ElectronicObserver.Utility;
using ElectronicObserver.Window.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicObserver.Window.Dialog
{
	public partial class DialogSortieHistory : Form
	{
		private Dictionary<int, List<SortieData>> Sorties = new Dictionary<int, List<SortieData>>();
		private Dictionary<int, List<int>> Worlds = new Dictionary<int, List<int>>();

		private readonly Size DefaultBarSize = new Size(80, 20);
		private readonly Size SmallBarSize = new Size(60, 20);

		private List<Label> HPBars;

		public Font MainFont { get; set; }
		public Font SubFont { get; set; }

		public DialogSortieHistory()
		{
			InitializeComponent();

			/*List<SortieData> sortieData = KCDatabase.Instance.SortieHistory;
			this.dataGridViewSortieHistory.Rows.Add(sortieData.WorldId + "-" + sortieData.MapId, sortieData.SortieDate.ToString(), sortieData.Branching, sortieData.FleetComposition);

			foreach (NodeData node in sortieData.Nodes)
			{
				this.dataGridViewNodesList.Rows.Add(node.NodeName, node.NodeType, node.Info, node.AbyssalFleet);
			}*/

			HPBars = new List<Label>(24);

			TableFleet.SuspendLayout();
			for (int i = 0; i < 24; i++)
			{
				HPBars.Add(new Label());
				HPBars[i].Size = DefaultBarSize;
				HPBars[i].AutoSize = false;
				HPBars[i].Margin = new Padding(2, 0, 2, 0);
				HPBars[i].Anchor = AnchorStyles.Left | AnchorStyles.Right;

				if (i < 6)
				{
					TableFleet.Controls.Add(HPBars[i], 0, i + 1);
				}
				else if (i < 12)
				{
					TableFleet.Controls.Add(HPBars[i], 1, i - 5);
				}
				else if (i < 18)
				{
					TableFleet.Controls.Add(HPBars[i], 3, i - 11);
				}
				else
				{
					TableFleet.Controls.Add(HPBars[i], 2, i - 17);
				}
			}
			TableFleet.ResumeLayout();
		}

		private delegate void InitForm();

		private void InitSortieFilter()
		{
			/*if (!Directory.Exists(Directory.GetCurrentDirectory() + "/BattleLog")) return;

			List<string> BattleLogsFiles = new List<string>(Directory.GetFiles(Directory.GetCurrentDirectory() + "/BattleLog"));

			// --- remove pvp
			BattleLogsFiles.RemoveAll((file => file.Contains("practice")));

			Worlds = new Dictionary<int, List<int>>();
			BattleLogs = new Dictionary<int, List<string>>();

			BattleLogsFiles = BattleLogsFiles
				.Select(file => file.Split(new string[] { "BattleLog\\" }, StringSplitOptions.None)[1])
				.OrderBy(file => file.Split('@')[0])
				.ToList();

			for (int i = 0; i < BattleLogsFiles.Count; i++)
			{
				int world = int.Parse(BattleLogsFiles[i].Split('@')[1].Split('-')[0]);
				int node = int.Parse(BattleLogsFiles[i].Split('@')[1].Split('-')[1]);

				if (!Worlds.ContainsKey(world))
				{
					Worlds.Add(world, new List<int>());
					BattleLogs.Add(world, new List<string>());
				}

				if (!Worlds[world].Contains(node))
				{
					Worlds[world].Add(node);
				}

				BattleLogs[world].Add(BattleLogsFiles[i]);
			}

			MapAreaID.DataSource = Worlds.Keys.OrderBy(world => world).ToList();*/

			foreach (SortieData sortie in KCDatabase.Instance.SortieHistory)
			{
				if (!Worlds.ContainsKey(sortie.WorldId))
				{
					Worlds.Add(sortie.WorldId, new List<int>());
					Sorties.Add(sortie.WorldId, new List<SortieData>());
				}

				if (!Worlds[sortie.WorldId].Contains(sortie.MapId))
				{
					Worlds[sortie.WorldId].Add(sortie.MapId);
				}

				Sorties[sortie.WorldId].Add(sortie);
			}

			MapAreaID.DataSource = Worlds.Keys.OrderBy(world => world).ToList();
		}

		private void InitSortieList(int world, int map)
		{
			this.dataGridViewSortieHistory.Rows.Clear();

			if (!Sorties.ContainsKey(world)) InitWorldSortieList(world);

			sortieDataBindingSource.DataSource = Sorties[world].FindAll(sortie => sortie.MapId == map).ToList();
		}

		private void InitWorldSortieList(int world)
		{
			/*Sorties[world] = new List<SortieData>();
			SortieData lastSortieData = new SortieData();
			int lastNode = 999;

			foreach (string battle in BattleLogs[world])
			{
				string date = battle.Split('@')[0]; // todo: parse the fucking date
				int map = int.Parse(battle.Split('@')[1].Split('-')[1]);
				int node = int.Parse(battle.Split('@')[1].Split('-')[2].Split('.')[0]);

				if (lastSortieData.Map != map || node < lastNode || node == lastNode)
				{
					lastSortieData = new SortieData()
					{
						Map = map,
						World = world,
						Branching = Window.FormMain.Instance.Translator.GetMapNodesOptimized(world, map, node),
						Date = date,
						FileName = battle,
					};

					Sorties[world].Add(lastSortieData);
				} 
				else
				{
					lastSortieData.Branching += " - " + Window.FormMain.Instance.Translator.GetMapNodesOptimized(world, map, node);
				}

				lastNode = node;
			}*/
		}


		private void DialogSortieHistory_Load(object sender, EventArgs e)
		{
			Task load = new Task(() =>
			{
				this.Invoke(new InitForm(InitSortieFilter));
			});

			load.Start();
		}

		private void LoadSortieData(SortieData sortie)
		{
			dataGridViewNodesList.DataSource = sortie.Nodes;

			for (int i = 0; i < 12; i++)
			{
				DisableHPBar(i);
			}

			int index = 0;
			foreach (ShipData ship in sortie.Fleet.Fleets[1].MembersInstance)
			{
				if (ship is null)
				{
					DisableHPBar(index);
				}
				else
				{
					EnableHPBar(index, ship.MasterShip.ShipTypeName + ' ' + ship.MasterShip.Name);
				}
				index++;
			}

			if (sortie.Fleet.CombinedFlag > 0)
			{
				index = 6;
				foreach (ShipData ship in sortie.Fleet.Fleets[2].MembersInstance)
				{
					if (ship is null)
					{
						DisableHPBar(index);
					}
					else
					{
						EnableHPBar(index, ship.MasterShip.ShipTypeName + ' ' + ship.MasterShip.Name);
					}
					index++;
				}
			}
		}

		private void LoadNodeData(NodeData node)
		{
			for (int i = 12; i < 24; i++)
			{
				DisableHPBar(i);
			}

			int index = 12;
			if (node.BattleData is null) return;
			foreach (ShipDataMaster ship in node.BattleData.Initial.EnemyMembersInstance)
			{
				if (ship is null)
				{
					DisableHPBar(index);
				}
				else
				{
					EnableHPBar(index, ship.Name);
				}
				index++;
			}

			if (node.BattleData.IsEnemyCombined)
			{
				index = 18;
				foreach (ShipDataMaster ship in node.BattleData.Initial.EnemyMembersEscortInstance)
				{
					if (ship is null)
					{
						DisableHPBar(index);
					}
					else
					{
						EnableHPBar(index,ship.Name);
					}
					index++;
				}
			}
		}

		void EnableHPBar(int index, string label)
		{
			if (HPBars.Count <= index) return;

			HPBars[index].Text = label;
			HPBars[index].Visible = true;
		}

		void DisableHPBar(int index)
		{
			if (HPBars.Count <= index) return;

			HPBars[index].Visible = false;
		}

		private void MapAreaID_SelectedIndexChanged(object sender, EventArgs e)
		{
			MapInfoID.DataSource = Worlds[(int)MapAreaID.SelectedValue].OrderBy(map => map).ToList(); ;
		}

		private void MapInfoID_SelectedIndexChanged(object sender, EventArgs e)
		{
			InitSortieList((int)MapAreaID.SelectedValue, (int)MapInfoID.SelectedValue);
		}

		private void dataGridViewSortieHistory_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewSortieHistory.Rows[e.RowIndex] != null && dataGridViewSortieHistory.Rows[e.RowIndex].DataBoundItem != null)
				LoadSortieData((SortieData)dataGridViewSortieHistory.Rows[e.RowIndex].DataBoundItem);
		}

		private void dataGridViewSortieHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (dataGridViewSortieHistory.Rows[e.RowIndex] != null && dataGridViewSortieHistory.Rows[e.RowIndex].DataBoundItem != null)
				dataGridViewSortieHistory.Rows[e.RowIndex].Cells[e.ColumnIndex].ToolTipText = ((SortieData)dataGridViewSortieHistory.Rows[e.RowIndex].DataBoundItem).UsedRessourcesString;
		}

		private void dataGridViewNodesList_CellEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (dataGridViewNodesList.Rows[e.RowIndex] != null && dataGridViewNodesList.Rows[e.RowIndex].DataBoundItem != null)
				LoadNodeData((NodeData)dataGridViewNodesList.Rows[e.RowIndex].DataBoundItem);
		}
	}
}
