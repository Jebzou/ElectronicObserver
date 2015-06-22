﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElectronicObserver.Window;

namespace ElectronicObserver.Data {

	/// <summary>
	/// 任務のデータを保持します。
	/// </summary>
	[DebuggerDisplay( "[{ID}] : {Name}" )]
	public class QuestData : ResponseWrapper, IIdentifiable {

		/// <summary>
		/// 任務ID
		/// </summary>
		public int QuestID {
			get { return (int)RawData.api_no; }
		}

		/// <summary>
		/// 任務カテゴリ
		/// </summary>
		public int Category {
			get { return (int)RawData.api_category; }
		}

		/// <summary>
		/// 任務出現タイプ
		/// 1=一回限り, 2=デイリー, 3=ウィークリー, 6=マンスリー
		/// </summary>
		public int Type {
			get { return (int)RawData.api_type; }
		}

		/// <summary>
		/// 遂行状態
		/// 1=未受領, 2=遂行中, 3=達成
		/// </summary>
		public int State {
			get { return (int)RawData.api_state; }
		}

		/// <summary>
		/// 任務名
		/// </summary>
		public string Name {
			get { return FormMain.Instance.Translator.GetTranslation((string)RawData.api_title, Utility.TranslationType.QuestTitle); }
		}

		/// <summary>
		/// 説明
		/// </summary>
		public string Description {
			get { return FormMain.Instance.Translator.GetTranslation((string)RawData.api_detail,Utility.TranslationType.QuestDetail); }
		}

		//undone:api_bonus_flag

		/// <summary>
		/// 進捗
		/// </summary>
		public int Progress {
			get { return (int)RawData.api_progress_flag; }
		}



		public int ID {
			get { return QuestID; }
		}

	}

}
