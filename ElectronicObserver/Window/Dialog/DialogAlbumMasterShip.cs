﻿using ElectronicObserver.Data;
using ElectronicObserver.Resource;
using ElectronicObserver.Resource.Record;
using ElectronicObserver.Utility.Mathematics;
using ElectronicObserver.Window.Control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElectronicObserver.Window.Dialog {
	public partial class DialogAlbumMasterShip : Form {


		public DialogAlbumMasterShip() {
			InitializeComponent();


			Fuel.ImageList =
			Ammo.ImageList =
			MaterialFuel.ImageList =
			MaterialAmmo.ImageList =
			MaterialSteel.ImageList =
			MaterialBauxite.ImageList =
			RemodelBeforeLevel.ImageList =
			RemodelBeforeAmmo.ImageList =
			RemodelBeforeSteel.ImageList =
			RemodelAfterLevel.ImageList =
			RemodelAfterAmmo.ImageList =
			RemodelAfterSteel.ImageList =
				ResourceManager.Instance.Icons;

			Equipment1.ImageList =
			Equipment2.ImageList =
			Equipment3.ImageList =
			Equipment4.ImageList =
			Equipment5.ImageList =
				ResourceManager.Instance.Equipments;

			Fuel.ImageIndex = (int)ResourceManager.IconContent.ResourceFuel;
			Ammo.ImageIndex = (int)ResourceManager.IconContent.ResourceAmmo;
			MaterialFuel.ImageIndex = (int)ResourceManager.IconContent.ResourceFuel;
			MaterialAmmo.ImageIndex = (int)ResourceManager.IconContent.ResourceAmmo;
			MaterialSteel.ImageIndex = (int)ResourceManager.IconContent.ResourceSteel;
			MaterialBauxite.ImageIndex = (int)ResourceManager.IconContent.ResourceBauxite;
			RemodelBeforeAmmo.ImageIndex = (int)ResourceManager.IconContent.ResourceAmmo;
			RemodelBeforeSteel.ImageIndex = (int)ResourceManager.IconContent.ResourceSteel;
			RemodelAfterAmmo.ImageIndex = (int)ResourceManager.IconContent.ResourceAmmo;
			RemodelAfterSteel.ImageIndex = (int)ResourceManager.IconContent.ResourceSteel;


			BasePanelShipGirl.Visible = false;

			//doublebuffered
			System.Reflection.PropertyInfo prop = typeof( TableLayoutPanel ).GetProperty( "DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );
			prop.SetValue( TableParameterMain, true, null );
			prop.SetValue( TableParameterSub, true, null );
			prop.SetValue( TableConsumption, true, null );
			prop.SetValue( TableEquipment, true, null );
			prop.SetValue( TableArsenal, true, null );
			prop.SetValue( TableRemodel, true, null );

			prop = typeof( DataGridView ).GetProperty( "DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic );
			prop.SetValue( ShipView, true, null );
			
		}

		public DialogAlbumMasterShip( int shipID )
			: this() {

			UpdateAlbumPage( shipID );
		}



		private void DialogAlbumMasterShip_Load( object sender, EventArgs e ) {

			ShipView.SuspendLayout();

			ShipView_ShipID.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			ShipView_ShipType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;


			ShipView.Rows.Clear();
			
			List<DataGridViewRow> rows = new List<DataGridViewRow>( KCDatabase.Instance.MasterShips.Values.Count( s => s.Name != "なし" ) );

			foreach ( var ship in KCDatabase.Instance.MasterShips.Values ) {

				if ( ship.Name == "なし" ) continue;

				DataGridViewRow row = new DataGridViewRow();
				row.CreateCells( ShipView );
				row.SetValues( ship.ShipID, KCDatabase.Instance.ShipTypes[ship.ShipType].Name, ship.NameWithClass );
				rows.Add( row );

			}
			ShipView.Rows.AddRange( rows.ToArray() );

			ShipView_ShipID.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			ShipView_ShipType.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;


			ShipView.ResumeLayout();

		}




		private void ShipView_SortCompare( object sender, DataGridViewSortCompareEventArgs e ) {

			if ( e.Column.Index == 1 ) {
				//艦種別ソート
				var ship1 = KCDatabase.Instance.MasterShips[(int)ShipView.Rows[e.RowIndex1].Cells[0].Value];
				var ship2 = KCDatabase.Instance.MasterShips[(int)ShipView.Rows[e.RowIndex2].Cells[0].Value];

				e.SortResult = ship1.ShipType - ship2.ShipType;
				if ( e.SortResult == 0 )
					e.SortResult = ship1.ShipID - ship2.ShipID;
				e.Handled = true;

			} else if ( e.Column.Index == 2 ) {
				//艦名別ソート
				
				//undone
			}

		}


		
		private void ShipView_CellMouseClick( object sender, DataGridViewCellMouseEventArgs e ) {

			if ( e.RowIndex >= 0 ) {
				int shipID = (int)ShipView.Rows[e.RowIndex].Cells[0].Value;

				if ( ( e.Button & System.Windows.Forms.MouseButtons.Right ) != 0 ) {
					new DialogAlbumMasterShip( shipID ).Show();

				} else if ( ( e.Button & System.Windows.Forms.MouseButtons.Left ) != 0 ) {
					UpdateAlbumPage( shipID );
				}
			}

		}

		
		

		private void UpdateAlbumPage( int shipID ) {

			KCDatabase db = KCDatabase.Instance;
			ShipDataMaster ship = db.MasterShips[shipID];

			if ( ship == null ) return;


			BasePanelShipGirl.SuspendLayout();


			//header
			ShipID.Tag = shipID;
			ShipID.Text = ship.ShipID.ToString();

			ShipType.Text = db.ShipTypes[ship.ShipType].Name;
			ShipName.Text = ship.NameWithClass;


			//main parameter
			TableParameterMain.SuspendLayout();

			HPMin.Text = ship.HPMin.ToString();
			HPMax.Text = ship.HPMaxMarried.ToString();

			FirepowerMin.Text = ship.FirepowerMin.ToString();
			FirepowerMax.Text = ship.FirepowerMax.ToString();

			TorpedoMin.Text = ship.TorpedoMin.ToString();
			TorpedoMax.Text = ship.TorpedoMax.ToString();

			AAMin.Text = ship.AAMin.ToString();
			AAMax.Text = ship.AAMax.ToString();

			ArmorMin.Text = ship.ArmorMin.ToString();
			ArmorMax.Text = ship.ArmorMax.ToString();

			ASWMin.Text = GetParameterMinBound( ship.ASW );
			ASWMax.Text = GetParameterMax( ship.ASW );

			EvasionMin.Text = GetParameterMinBound( ship.Evasion );
			EvasionMax.Text = GetParameterMax( ship.Evasion );

			LOSMin.Text = GetParameterMinBound( ship.LOS );
			LOSMax.Text = GetParameterMax( ship.LOS );

			LuckMin.Text = ship.LuckMin.ToString();
			LuckMax.Text = ship.LuckMax.ToString();

			UpdateLevelParameter( ship.ShipID );

			TableParameterMain.ResumeLayout();


			//sub parameter
			TableParameterSub.SuspendLayout();

			Speed.Text = Constants.GetSpeed( ship.Speed );
			Range.Text = Constants.GetRange( ship.Range );
			Rarity.Text = Constants.GetShipRarity( ship.Rarity );

			Fuel.Text = ship.Fuel.ToString();
			Ammo.Text = ship.Ammo.ToString();

			TableParameterSub.ResumeLayout();

			//equipment
			//どうにかできるなら修正すること
			TableEquipment.SuspendLayout();
			
			ImageLabel[] aircraft = new ImageLabel[] { Aircraft1, Aircraft2, Aircraft3, Aircraft4, Aircraft5 };
			ImageLabel[] slot = new ImageLabel[] { Equipment1, Equipment2, Equipment3, Equipment4, Equipment5 };

			for ( int i = 0; i < slot.Length; i++ ) {

				if ( ship.Aircraft[i] > 0 || i < ship.SlotSize )
					aircraft[i].Text = ship.Aircraft[i].ToString();
				else
					aircraft[i].Text = "";


				if ( ship.DefaultSlot == null ) {
					if ( i < ship.SlotSize ) {
						slot[i].Text = "???";
						slot[i].ImageIndex = (int)ResourceManager.EquipmentContent.Unknown;
					} else {
						slot[i].Text = "";
						slot[i].ImageIndex = (int)ResourceManager.EquipmentContent.Locked;
					}
					
				} else if ( ship.DefaultSlot[i] != -1 ) {
					EquipmentDataMaster eq = db.MasterEquipments[ship.DefaultSlot[i]];
					slot[i].Text = eq.Name;
					slot[i].ImageIndex = eq.EquipmentType[3];
				
				} else if ( i < ship.SlotSize ) {
					slot[i].Text = "(なし)";
					slot[i].ImageIndex = (int)ResourceManager.EquipmentContent.Nothing;
				
				} else {
					slot[i].Text = "";
					slot[i].ImageIndex = (int)ResourceManager.EquipmentContent.Locked;
				}
			}

			TableEquipment.ResumeLayout();


			//arsenal
			TableArsenal.SuspendLayout();
			//checkme
			BuildingTime.Text = DateTimeHelper.ToTimeRemainString( new TimeSpan( 0, ship.BuildingTime, 0 ) );

			MaterialFuel.Text = ship.Material[0].ToString();
			MaterialAmmo.Text = ship.Material[1].ToString();
			MaterialSteel.Text = ship.Material[2].ToString();
			MaterialBauxite.Text = ship.Material[3].ToString();

			PowerUpFirepower.Text = ship.PowerUp[0].ToString();
			PowerUpTorpedo.Text = ship.PowerUp[1].ToString();
			PowerUpAA.Text = ship.PowerUp[2].ToString();
			PowerUpArmor.Text = ship.PowerUp[3].ToString();

			TableArsenal.ResumeLayout();


			//remodel
			TableRemodel.SuspendLayout();

			if ( ship.RemodelBeforeShipID == 0 ) {
				RemodelBeforeShipName.Text = "(なし)";
				RemodelBeforeLevel.Text = "";
				RemodelBeforeLevel.ImageIndex = -1;
				RemodelBeforeAmmo.Text = "-";
				RemodelBeforeSteel.Text = "-";
			} else {
				ShipDataMaster sbefore = db.MasterShips[ship.RemodelBeforeShipID];
				RemodelBeforeShipName.Text = sbefore.Name;
				RemodelBeforeLevel.Text = string.Format( "Lv. {0}", sbefore.RemodelAfterLevel );
				RemodelBeforeLevel.ImageIndex = sbefore.NeedBlueprint > 0 ? (int)ResourceManager.IconContent.HQExpedition : -1;		//fixme
				RemodelBeforeAmmo.Text = sbefore.RemodelAmmo.ToString();
				RemodelBeforeSteel.Text = sbefore.RemodelSteel.ToString();
			}

			if ( ship.RemodelAfterShipID == 0 ) {
				RemodelAfterShipName.Text = "(なし)";
				RemodelAfterLevel.Text = "";
				RemodelAfterLevel.ImageIndex = -1;
				RemodelAfterAmmo.Text = "-";
				RemodelAfterSteel.Text = "-";
			} else {
				RemodelAfterShipName.Text = db.MasterShips[ship.RemodelAfterShipID].Name;
				RemodelAfterLevel.Text = string.Format( "Lv. {0}", ship.RemodelAfterLevel );
				RemodelAfterLevel.ImageIndex = ship.NeedBlueprint > 0 ? (int)ResourceManager.IconContent.HQExpedition : -1;		//fixme
				RemodelAfterAmmo.Text = ship.RemodelAmmo.ToString();
				RemodelAfterSteel.Text = ship.RemodelSteel.ToString();
			}
			TableRemodel.ResumeLayout();


			BasePanelShipGirl.ResumeLayout();
			BasePanelShipGirl.Visible = true;


			this.Text = "艦船図鑑 - " + ship.NameWithClass;

		}


		private void UpdateLevelParameter( int shipID ) {

			ShipDataMaster ship = KCDatabase.Instance.MasterShips[shipID];

			ASWLevel.Text = EstimateParameter( (int)ParameterLevel.Value, ship.ASW );
			EvasionLevel.Text = EstimateParameter( (int)ParameterLevel.Value, ship.Evasion );
			LOSLevel.Text = EstimateParameter( (int)ParameterLevel.Value, ship.LOS );

		}

		private string EstimateParameter( int level, ShipParameterRecord.Parameter param ) {

			if ( param == null || param.Maximum == ShipParameterRecord.Parameter.MaximumDefault )
				return "???";
			
			int min = (int)( param.MinimumEstMin + ( param.Maximum - param.MinimumEstMin ) * level / 99.0 );
			int max = (int)( param.MinimumEstMax + ( param.Maximum - param.MinimumEstMax ) * level / 99.0 );

			if ( min == max )
				return min.ToString();
			else
				return string.Format( "{0}～{1}", Math.Min( min, max ), Math.Max( min, max ) );
		}

		
		private string GetParameterMinBound( ShipParameterRecord.Parameter param ) {

			if ( param == null || param.MinimumEstMax == ShipParameterRecord.Parameter.MaximumDefault )
				return "???";
			else if ( param.MinimumEstMin == param.MinimumEstMax )
				return param.MinimumEstMin.ToString();
			else if ( param.MinimumEstMin == ShipParameterRecord.Parameter.MinimumDefault && param.MinimumEstMax == param.Maximum )
				return "???";
			else
				return string.Format( "{0}～{1}", param.MinimumEstMin, param.MinimumEstMax );
		
		}

		private string GetParameterMax( ShipParameterRecord.Parameter param ) {

			if ( param == null || param.Maximum == ShipParameterRecord.Parameter.MaximumDefault )
				return "???";
			else
				return param.Maximum.ToString();

		}


		private void ParameterLevel_ValueChanged( object sender, EventArgs e ) {
			if ( ShipID.Tag != null ) {
				UpdateLevelParameter( (int)ShipID.Tag );
			}
		}



		private void TableParameterMain_CellPaint( object sender, TableLayoutCellPaintEventArgs e ) {
			e.Graphics.DrawLine( Pens.Silver, e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
			/*/
			if ( e.Column == 0 )
				e.Graphics.DrawLine( Pens.Silver, e.CellBounds.Right - 1, e.CellBounds.Y, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
			//*/
		}

		private void TableParameterSub_CellPaint( object sender, TableLayoutCellPaintEventArgs e ) {
			e.Graphics.DrawLine( Pens.Silver, e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
		}

		private void TableConsumption_CellPaint( object sender, TableLayoutCellPaintEventArgs e ) {
			e.Graphics.DrawLine( Pens.Silver, e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
		}

		private void TableEquipment_CellPaint( object sender, TableLayoutCellPaintEventArgs e ) {
			e.Graphics.DrawLine( Pens.Silver, e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
		}

		private void TableArsenal_CellPaint( object sender, TableLayoutCellPaintEventArgs e ) {
			e.Graphics.DrawLine( Pens.Silver, e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
		}

		private void TableRemodel_CellPaint( object sender, TableLayoutCellPaintEventArgs e ) {
			if ( e.Row % 2 == 1 )
				e.Graphics.DrawLine( Pens.Silver, e.CellBounds.X, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1 );
		}



		private void RemodelBeforeShipName_MouseClick( object sender, MouseEventArgs e ) {

			if ( ShipID.Tag == null ) return;
			var ship = KCDatabase.Instance.MasterShips[(int)ShipID.Tag];

			if ( ship != null && ship.RemodelBeforeShipID != 0 ) {

				if ( ( e.Button & System.Windows.Forms.MouseButtons.Right ) != 0 )
					new DialogAlbumMasterShip( ship.RemodelBeforeShipID ).Show();

				else if ( ( e.Button & System.Windows.Forms.MouseButtons.Left ) != 0 )
					UpdateAlbumPage( ship.RemodelBeforeShipID );		
			}
		}

		private void RemodelAfterShipName_MouseClick( object sender, MouseEventArgs e ) {

			if ( ShipID.Tag == null ) return;
			var ship = KCDatabase.Instance.MasterShips[(int)ShipID.Tag];

			if ( ship != null && ship.RemodelAfterShipID != 0 ) {

				if ( ( e.Button & System.Windows.Forms.MouseButtons.Right ) != 0 )
					new DialogAlbumMasterShip( ship.RemodelAfterShipID ).Show();

				else if ( ( e.Button & System.Windows.Forms.MouseButtons.Left ) != 0 )
					UpdateAlbumPage( ship.RemodelAfterShipID );
			}
		}

		
	}
}