using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BandMadness.Models.ManyToMany
{
	public class MemberSelection
	{
		public MemberSelection() { }

		public MemberSelection(IHaveMembers iMembers)
		{
			IHaveMembers = iMembers;
		}
		private readonly IHaveMembers IHaveMembers;

	


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

		public MultiSelectList MultiSelectList
		{
			get
			{
				if (IHaveMembers == null) throw new Exception("MultiSelectList is only available to IHaveMembers.");
				var members = DB.Members.ToList().OrderBy(i => i.DisplayName);
				var selectedMemberIDs = IHaveMembers.Members.Select(m => m.MemberID).ToList();
				var selected = new List<int>();
				foreach (var member in members)
				{
					if (selectedMemberIDs.Contains(member.MemberID))
					{
						selected.Add(member.MemberID);
					}
				}
				return new MultiSelectList(members, "MemberID", "DisplayName", selected);
			}
		}

		public  SelectList SelectList
		{
			get
			{
				var db = new BMContext();
				var members = db.Members
					.OrderBy(m => m.FirstName)
					.AsEnumerable()
					.Select(m => new SelectListItem
					{
						Value = m.MemberID.ToString(),
						Text = m.FirstName
					});
				return new SelectList(members, "Value", "Text", null); //5th overload. 
			}
		}

		public List<string> MemberIDs { get; set; }
	}
}