using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BinaryComponents.SuperList;
using BinaryComponents.Utility.Collections;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;

namespace Infrastructure.UserInterface.WinForms
{
	public class ListViewControl : ListControl
	{
		private Column fillColumn = null;
		public Column FillColumn
		{
			get { return fillColumn; }
			set
			{
				fillColumn = value;
				ResizeFillColumn();
			}
		}

		public ListViewControl()
		{
			Resize += (o, e) => ResizeFillColumn();
			Columns.DataChanged += new EventHandler<EventingList<Column>.EventInfo>(Columns_DataChanged);
			ShowCustomizeSection = false;
			MultiSelect = false;
			Font = KryptonManager.CurrentGlobalPalette.GetContentShortTextFont(PaletteContentStyle.LabelNormalControl, PaletteState.Normal);

			// FIXME: Without this, sorting doesn't work (crash: "couldn't compare two values of an array")
			Items.ObjectComparer = new BugFixComparer();
		}

		private class BugFixComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				// FIXME: This is strange.
				return 1;
			}
		}

		void Columns_DataChanged(object sender, EventingList<Column>.EventInfo e)
		{
			if (e.EventType == EventingList<Column>.EventType.Added)
			{
				foreach (var column in e.Items)
				{
					column.MoveBehaviour = Column.MoveToGroupBehaviour.Copy;
					column.IsFixedWidth = true;
				}
			}

			ResizeFillColumn();
		}

		private void ResizeFillColumn()
		{
			if (fillColumn == null)
				return;

			var currentWidth = ClientRectangle.Width;

			var columnWidth = 0;

			foreach (var column in Columns)
				if (column != fillColumn)
					columnWidth += column.Width;

			var fillSize = currentWidth - columnWidth - 10;
			fillColumn.Width = fillSize >= 10 ? fillSize : 10;
		}
	}
}
