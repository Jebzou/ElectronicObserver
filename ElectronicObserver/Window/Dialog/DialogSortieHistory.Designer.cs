namespace ElectronicObserver.Window.Dialog
{
	partial class DialogSortieHistory
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewSortieHistory = new System.Windows.Forms.DataGridView();
            this.Map = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fleet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.branchingDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortieDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.MapInfoID = new System.Windows.Forms.ComboBox();
            this.MapAreaID = new System.Windows.Forms.ComboBox();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TableFleet = new System.Windows.Forms.TableLayoutPanel();
            this.FleetFriend = new ElectronicObserver.Window.Control.ImageLabel();
            this.FleetEnemyEscort = new ElectronicObserver.Window.Control.ImageLabel();
            this.FleetFriendEscort = new ElectronicObserver.Window.Control.ImageLabel();
            this.FleetEnemy = new ElectronicObserver.Window.Control.ImageLabel();
            this.dataGridViewNodesList = new System.Windows.Forms.DataGridView();
            this.Node = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AbyssalFleet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rewardDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nodeDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSortieHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortieDataBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.TableFleet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNodesList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 615);
            this.panel1.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridViewSortieHistory);
            this.splitContainer1.Panel1.Controls.Add(this.MapInfoID);
            this.splitContainer1.Panel1.Controls.Add(this.MapAreaID);
            this.splitContainer1.Panel1.Controls.Add(this.dockPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridViewNodesList);
            this.splitContainer1.Size = new System.Drawing.Size(1159, 615);
            this.splitContainer1.SplitterDistance = 510;
            this.splitContainer1.TabIndex = 32;
            // 
            // dataGridViewSortieHistory
            // 
            this.dataGridViewSortieHistory.AutoGenerateColumns = false;
            this.dataGridViewSortieHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSortieHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Map,
            this.Date,
            this.Fleet,
            this.branchingDataGridViewTextBoxColumn});
            this.dataGridViewSortieHistory.DataSource = this.sortieDataBindingSource;
            this.dataGridViewSortieHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSortieHistory.Location = new System.Drawing.Point(0, 30);
            this.dataGridViewSortieHistory.Name = "dataGridViewSortieHistory";
            this.dataGridViewSortieHistory.Size = new System.Drawing.Size(510, 585);
            this.dataGridViewSortieHistory.TabIndex = 32;
            this.dataGridViewSortieHistory.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSortieHistory_CellEnter);
            this.dataGridViewSortieHistory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewSortieHistory_CellFormatting);
            // 
            // Map
            // 
            this.Map.DataPropertyName = "Map";
            this.Map.HeaderText = "Map";
            this.Map.Name = "Map";
            this.Map.ReadOnly = true;
            this.Map.Width = 50;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "SortieDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            // 
            // Fleet
            // 
            this.Fleet.DataPropertyName = "FleetComposition";
            this.Fleet.HeaderText = "Fleet";
            this.Fleet.Name = "Fleet";
            this.Fleet.ReadOnly = true;
            this.Fleet.Width = 200;
            // 
            // branchingDataGridViewTextBoxColumn
            // 
            this.branchingDataGridViewTextBoxColumn.DataPropertyName = "Branching";
            this.branchingDataGridViewTextBoxColumn.HeaderText = "Branching";
            this.branchingDataGridViewTextBoxColumn.Name = "branchingDataGridViewTextBoxColumn";
            this.branchingDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sortieDataBindingSource
            // 
            this.sortieDataBindingSource.DataSource = typeof(ElectronicObserver.Data.SortieData);
            // 
            // MapInfoID
            // 
            this.MapInfoID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapInfoID.FormattingEnabled = true;
            this.MapInfoID.Location = new System.Drawing.Point(59, 3);
            this.MapInfoID.Name = "MapInfoID";
            this.MapInfoID.Size = new System.Drawing.Size(50, 21);
            this.MapInfoID.TabIndex = 29;
            this.MapInfoID.SelectedIndexChanged += new System.EventHandler(this.MapInfoID_SelectedIndexChanged);
            // 
            // MapAreaID
            // 
            this.MapAreaID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MapAreaID.FormattingEnabled = true;
            this.MapAreaID.Location = new System.Drawing.Point(3, 3);
            this.MapAreaID.Name = "MapAreaID";
            this.MapAreaID.Size = new System.Drawing.Size(50, 21);
            this.MapAreaID.TabIndex = 28;
            this.MapAreaID.SelectedIndexChanged += new System.EventHandler(this.MapAreaID_SelectedIndexChanged);
            // 
            // dockPanel1
            // 
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(510, 30);
            this.dockPanel1.Styles = null;
            this.dockPanel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.Controls.Add(this.TableFleet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 265);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(4);
            this.panel2.Size = new System.Drawing.Size(645, 350);
            this.panel2.TabIndex = 1;
            // 
            // TableFleet
            // 
            this.TableFleet.AutoSize = true;
            this.TableFleet.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TableFleet.ColumnCount = 4;
            this.TableFleet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableFleet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableFleet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableFleet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TableFleet.Controls.Add(this.FleetFriend, 0, 0);
            this.TableFleet.Controls.Add(this.FleetEnemyEscort, 2, 0);
            this.TableFleet.Controls.Add(this.FleetFriendEscort, 1, 0);
            this.TableFleet.Controls.Add(this.FleetEnemy, 3, 0);
            this.TableFleet.Location = new System.Drawing.Point(7, 7);
            this.TableFleet.Name = "TableFleet";
            this.TableFleet.RowCount = 9;
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.TableFleet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.TableFleet.Size = new System.Drawing.Size(144, 168);
            this.TableFleet.TabIndex = 2;
            // 
            // FleetFriend
            // 
            this.FleetFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FleetFriend.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FleetFriend.Location = new System.Drawing.Point(3, 3);
            this.FleetFriend.Name = "FleetFriend";
            this.FleetFriend.Size = new System.Drawing.Size(19, 15);
            this.FleetFriend.TabIndex = 0;
            this.FleetFriend.Text = "Ally";
            this.FleetFriend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FleetEnemyEscort
            // 
            this.FleetEnemyEscort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FleetEnemyEscort.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FleetEnemyEscort.Location = new System.Drawing.Point(67, 3);
            this.FleetEnemyEscort.Name = "FleetEnemyEscort";
            this.FleetEnemyEscort.Size = new System.Drawing.Size(33, 15);
            this.FleetEnemyEscort.TabIndex = 19;
            this.FleetEnemyEscort.Text = "Escort";
            this.FleetEnemyEscort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FleetFriendEscort
            // 
            this.FleetFriendEscort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FleetFriendEscort.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FleetFriendEscort.Location = new System.Drawing.Point(28, 3);
            this.FleetFriendEscort.Name = "FleetFriendEscort";
            this.FleetFriendEscort.Size = new System.Drawing.Size(33, 15);
            this.FleetFriendEscort.TabIndex = 1;
            this.FleetFriendEscort.Text = "Escort";
            this.FleetFriendEscort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FleetEnemy
            // 
            this.FleetEnemy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.FleetEnemy.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.FleetEnemy.Location = new System.Drawing.Point(106, 3);
            this.FleetEnemy.Name = "FleetEnemy";
            this.FleetEnemy.Size = new System.Drawing.Size(35, 15);
            this.FleetEnemy.TabIndex = 2;
            this.FleetEnemy.Text = "Enemy";
            this.FleetEnemy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridViewNodesList
            // 
            this.dataGridViewNodesList.AutoGenerateColumns = false;
            this.dataGridViewNodesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNodesList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Node,
            this.Type,
            this.AbyssalFleet,
            this.Rank,
            this.rewardDataGridViewTextBoxColumn});
            this.dataGridViewNodesList.DataSource = this.nodeDataBindingSource;
            this.dataGridViewNodesList.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewNodesList.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewNodesList.Name = "dataGridViewNodesList";
            this.dataGridViewNodesList.Size = new System.Drawing.Size(645, 265);
            this.dataGridViewNodesList.TabIndex = 0;
            this.dataGridViewNodesList.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNodesList_CellEnter);
            // 
            // Node
            // 
            this.Node.DataPropertyName = "NodeName";
            this.Node.HeaderText = "Node";
            this.Node.Name = "Node";
            this.Node.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "NodeTypeString";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // AbyssalFleet
            // 
            this.AbyssalFleet.DataPropertyName = "AbyssalFleet";
            this.AbyssalFleet.HeaderText = "Abyssal fleet";
            this.AbyssalFleet.Name = "AbyssalFleet";
            this.AbyssalFleet.ReadOnly = true;
            this.AbyssalFleet.Width = 200;
            // 
            // Rank
            // 
            this.Rank.DataPropertyName = "Info";
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            this.Rank.ReadOnly = true;
            // 
            // rewardDataGridViewTextBoxColumn
            // 
            this.rewardDataGridViewTextBoxColumn.DataPropertyName = "Reward";
            this.rewardDataGridViewTextBoxColumn.HeaderText = "Reward";
            this.rewardDataGridViewTextBoxColumn.Name = "rewardDataGridViewTextBoxColumn";
            this.rewardDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nodeDataBindingSource
            // 
            this.nodeDataBindingSource.DataSource = typeof(ElectronicObserver.Data.NodeData);
            // 
            // DialogSortieHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 615);
            this.Controls.Add(this.panel1);
            this.Name = "DialogSortieHistory";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DialogSortieHistory_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSortieHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sortieDataBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.TableFleet.ResumeLayout(false);
            this.TableFleet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNodesList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nodeDataBindingSource)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridViewSortieHistory;
		private System.Windows.Forms.ComboBox MapInfoID;
		private System.Windows.Forms.ComboBox MapAreaID;
		private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
		private System.Windows.Forms.DataGridView dataGridViewNodesList;
		private System.Windows.Forms.BindingSource sortieDataBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn Map;
		private System.Windows.Forms.DataGridViewTextBoxColumn Date;
		private System.Windows.Forms.DataGridViewTextBoxColumn Fleet;
		private System.Windows.Forms.DataGridViewTextBoxColumn branchingDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource nodeDataBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn Node;
		private System.Windows.Forms.DataGridViewTextBoxColumn Type;
		private System.Windows.Forms.DataGridViewTextBoxColumn AbyssalFleet;
		private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
		private System.Windows.Forms.DataGridViewTextBoxColumn rewardDataGridViewTextBoxColumn;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TableLayoutPanel TableFleet;
		private Control.ImageLabel FleetFriend;
		private Control.ImageLabel FleetEnemyEscort;
		private Control.ImageLabel FleetFriendEscort;
		private Control.ImageLabel FleetEnemy;
	}
}