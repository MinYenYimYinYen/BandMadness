using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Models.ManyToMany
{
	public  class MemberSelection
	{
		public MemberSelection(IHaveMembers iMembers)
		{
			IHaveMembers = iMembers;
		}
		public IHaveMembers IHaveMembers { get; set; }

		private BMContext db____;
		public BMContext DB
		{
			get
			{
				if (db____ == null)
				{
					db____ = new BMContext();
				}
				return db____;
			}
		}

		private List<SelectListItem> sliMembers;
		public List<SelectListItem> GetMemberSelectListItems()
		{
			//if (sliMembers == null)
			{
				sliMembers = new List<SelectListItem>();
				foreach (var memb in DB.Members)
				{
					var slMember = new SelectListItem
					{
						Value = memb.MemberID.ToString(),
						Text = memb.DisplayName,
						Selected = 
							IHaveMembers
							.Members
							.Select(m=>m.MemberID)
							.Contains(memb.MemberID) ? true : false
					};
					sliMembers.Add(slMember);
				}
			}
			return sliMembers;
		}

		private MultiSelectList mslMembers;
		public MultiSelectList MSLMembers
		{
			get
			{
				//if (mslMembers == null)
				{
					var items = GetMemberSelectListItems();

					var selected =
						items
						.Where(slm => slm.Selected)
						.Select(slm => slm)
						.ToList();

					mslMembers = new MultiSelectList
						(items.OrderBy(m => m.Text), "Value", "Text", selected);
				}
				return mslMembers;
			}
		}

		private List<string> memberStringIDs;
		public List<string> MemberStringIDs
		{
			get
			{
				if (memberStringIDs == null) memberStringIDs = new List<string>();
				return memberStringIDs;
			}
			set
			{
				memberStringIDs = value;
			}
		}





	}
}